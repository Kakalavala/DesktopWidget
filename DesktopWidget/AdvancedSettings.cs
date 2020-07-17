using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DesktopWidget
{
    public partial class AdvancedSettings : Form
    {
        private Thread eyeDropThread;
        private bool UpdateQueued = false;
        private bool JustInheritedTheme = false;
        private Color selectedThemeColor = Color.Transparent;
        private int themeOffset = 0;

        public AdvancedSettings()
        {
            this.InitializeComponent();
        }

        private void InitializeEventHandlers()
        {
            ColorDialog OpenColorDialog(bool useCurrent = false)
            {
                ColorDialog cd = new ColorDialog();

                cd.SolidColorOnly = true;
                cd.AnyColor = true;

                if (useCurrent)
                    cd.Color = this.selectedThemeColor;

                return cd;
            }

            List<Control> children = new List<Control>();
            string[] whitelist = { "GroupBox" };

            void GetRecursiveChildren(Control cnt)
            {
                foreach (Control cont in cnt.Controls)
                {
                    if (whitelist.Contains(cont.GetType().Name))
                        children.Add(cont);

                    if (cont.HasChildren)
                        GetRecursiveChildren(cont);
                }
            }

            GetRecursiveChildren(this);

            foreach (Control child in children)
            {
                if (child.GetType().Name == "GroupBox")
                    child.Paint += new PaintEventHandler(this.PaintGroupBox);
            }

            this.SetInheritBtn.Click += new EventHandler(delegate
            {
                this.selectedThemeColor = Color.Transparent;
                this.UpdateThemeSettings();
            });

            this.SetThemeColorBtn.Click += new EventHandler(delegate { this.UpdateThemeSettings(); });

            this.CustomizeColorBtn.Click += new EventHandler(delegate
            {
                ColorDialog cd = OpenColorDialog(true);
                cd.ShowDialog();

                this.JustInheritedTheme = true;
                this.selectedThemeColor = cd.Color;
                this.UpdateColorPreview();
            });

            this.ShowInheritBtn.Click += new EventHandler(delegate
            {
                this.JustInheritedTheme = true;
                this.selectedThemeColor = ThemeInfo.GetThemeColor();
                this.UpdateColorPreview();
            });

            this.ColorPreviewPanel.BackColorChanged += new EventHandler(delegate
            {
                if (Properties.Settings.Default.ThemeColor != Engine.ColorToHex(this.selectedThemeColor))
                    this.StatusMessage.Text = "Color not set.";
            });
            
            this.EyeDropBtn.Click += new EventHandler(delegate { this.EyeDropper(); });
            this.TryParseBtn.Click += new EventHandler(delegate { this.AttemptColorParse(); });

            this.RedSelector.ValueChanged += new EventHandler(delegate { this.ChangeTheme(); });
            this.GreenSelector.ValueChanged += new EventHandler(delegate { this.ChangeTheme(); });
            this.BlueSelector.ValueChanged += new EventHandler(delegate { this.ChangeTheme(); });
            this.Offset.ValueChanged += new EventHandler(delegate { this.ChangeTheme(); });
            
            this.BackBtn.Click += new EventHandler(delegate { this.UpdateValueSettings();  this.Dispose(); });
            this.DeleteLogsBtn.Click += new EventHandler(delegate { Engine.DeleteLogs(); });

            this.StartupUpdateBtn.Click += new EventHandler(delegate { this.UpdateStartupInfo(); });
            this.StartupRemoveBtn.Click += new EventHandler(delegate { this.UpdateStartupInfo(true); });
            this.QuitAppBtn.Click += new EventHandler(delegate { Application.Exit(); });
        }

        private void AdvancedSettings_Load(object sender, EventArgs e)
        {
            this.Text = "DesktopWidget \u2013 Advanced Preferences";

            this.AllowLogFilesCheckbox.Checked = Properties.Settings.Default.AllowLogging;
            this.DeleteLogsBtn.Enabled = Engine.DoesDirectoryExist();
            
            Engine.AddToolTip(this.QuitAppBtn, "Completely close the Widget");

            if (Properties.Settings.Default.ThemeColor != "Inherit")
            {
                this.JustInheritedTheme = true;
                this.selectedThemeColor = Engine.ColorFromHex(Properties.Settings.Default.ThemeColor);
                this.UpdateColorPreview();
            }

            System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 100;
            updateTimer.Enabled = true;
            updateTimer.Tick += new EventHandler(delegate {
                if (this.UpdateQueued)
                {
                    this.UpdateColorPreview();

                    if (Properties.Settings.Default.ThemeColor != Engine.ColorToHex(this.selectedThemeColor))
                        this.StatusMessage.Text = "Color not set.";

                    this.UpdateQueued = false;
                }
            });

            this.InitializeEventHandlers();
        }

        private void UpdateStartupInfo(bool justRemove = false)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Properties.Settings.Default.AllowStartup && !justRemove)
            {
                if (rk.GetValue(Application.ProductName) == null)
                    rk.SetValue(Application.ProductName, Application.ExecutablePath);
                else
                {
                    rk.DeleteValue(Application.ProductName, false);
                    this.UpdateStartupInfo();
                }
            }
            else
                rk.DeleteValue(Application.ProductName, false);
        }

        private void ChangeTheme()
        {
            if (this.JustInheritedTheme)
                return;

            this.JustInheritedTheme = true;

            int r = (int)this.RedSelector.Value;
            int g = (int)this.GreenSelector.Value;
            int b = (int)this.BlueSelector.Value;

            if (r - this.Offset.Value < 0 || g - this.Offset.Value < 0 || b - this.Offset.Value < 0)
            {
                this.themeOffset = 0;
                this.Offset.Value = 0;
            }

            this.themeOffset = (int)this.Offset.Value;
            this.selectedThemeColor = Color.FromArgb(255, r - this.themeOffset, g - this.themeOffset, b - this.themeOffset);

            this.UpdateColorPreview();
        }

        private string GetFinalizedThemeColor()
        {
            Color col = Color.FromArgb(255, this.selectedThemeColor.R - this.themeOffset, this.selectedThemeColor.G - this.themeOffset, this.selectedThemeColor.B - this.themeOffset);
            return Engine.ColorToHex(col);
        }

        private void AttemptColorParse()
        {
            string txt = this.ColorTextBox.Text.ToLower();
            bool hexMatch = Regex.IsMatch(txt.Replace("#", ""), @"^[a-fA-F0-9]{6}$");

            void Valid(int id)
            {
                this.ColorTextBox.ForeColor = Color.FromArgb(255, 0, 102, 0);
                this.ColorTextBox.BackColor = Color.FromArgb(255, 179, 255, 179);
                this.JustInheritedTheme = true;

                int[] v = GetValues();

                switch (id)
                {
                    case 0:
                        this.selectedThemeColor = Engine.ColorFromHex(txt);
                        break;
                    case 1:
                        this.selectedThemeColor = Color.FromArgb(255, v[0], v[1], v[2]);
                        break;
                }

                this.UpdateColorPreview();
            }

            void Invalid()
            {
                this.ColorTextBox.ForeColor = Color.FromArgb(255, 128, 0, 0);
                this.ColorTextBox.BackColor = Color.FromArgb(255, 255, 179, 179);
            }

            int[] GetValues()
            {
                MatchCollection matches = Regex.Matches(txt, @"(\d+)");

                if (matches.Count != 3)
                    return null;

                if (int.TryParse(matches[0].Value, out int r) && int.TryParse(matches[1].Value, out int g) && int.TryParse(matches[2].Value, out int b))
                    return new int[] { r, g, b };

                return new int[] { 0, 0, 0 };
            }

            bool CheckValid(int x1, int x2, int x3)
            {
                try
                {
                    int[] values = GetValues();
                    bool valid = false;

                    if ((values[0] <= x1 && values[0] >= 0) && (values[1] <= x2 && values[1] >= 0) && (values[2] <= x3 && values[2] >= 0))
                        valid = true;
                    else
                        return false;

                    return valid;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            if (txt.StartsWith("#") || hexMatch)
            {
                if (hexMatch) Valid(0);
                else Invalid();
            }
            else if (txt.StartsWith("rgb") || CheckValid(255, 255, 255))
            {
                if (CheckValid(255, 255, 255)) Valid(1);
                else Invalid();
            }
            else Invalid();
        }

        private void UpdateColorPreview()
        {
            this.ColorPreviewPanel.BackColor = this.selectedThemeColor;
            this.ColorHexLabel.Text = $"#{Engine.ColorToHex(this.selectedThemeColor)}";
            this.RedSelector.Value = this.selectedThemeColor.R;
            this.GreenSelector.Value = this.selectedThemeColor.G;
            this.BlueSelector.Value = this.selectedThemeColor.B;

            if (this.JustInheritedTheme)
                this.JustInheritedTheme = false;
        }
        
        private void UpdateThemeSettings()
        {
            this.StatusMessage.Text = "Color set.";

            Properties.Settings.Default.ThemeColor = (this.selectedThemeColor == Color.Transparent) ? "Inherit" : this.GetFinalizedThemeColor();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void UpdateValueSettings()
        {
            Properties.Settings.Default.AllowLogging = this.AllowLogFilesCheckbox.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void PaintGroupBox(object sender, PaintEventArgs e)
        {
            Engine.DrawGroupBox(this.BackColor, (GroupBox)sender, e.Graphics, Color.Black, Color.FromArgb(255, 160, 160, 160));
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        private void EyeDropper() 
        {
            Program.RunningEyeDropper = true;
            this.StatusMessage.Text = "Click wherever you wish to sample from.";
            this.JustInheritedTheme = true;

            void GetColorFromEyeDropper()
            {
                while (Program.CursorPosition.IsEmpty) continue;

                Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);

                Color GetColorAt(Point location)
                {
                    using (Graphics gdest = Graphics.FromImage(screenPixel))
                    {
                        using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                        {
                            IntPtr hSrcDC = gsrc.GetHdc();
                            IntPtr hDC = gdest.GetHdc();
                            int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                            gdest.ReleaseHdc();
                            gsrc.ReleaseHdc();
                        }
                    }

                    return screenPixel.GetPixel(0, 0);
                }
                
                this.selectedThemeColor = GetColorAt(Program.CursorPosition);
                this.UpdateQueued = true;
                Program.RunningEyeDropper = false;

                this.eyeDropThread.Abort();
            }

            this.eyeDropThread = new Thread(new ThreadStart(GetColorFromEyeDropper));
            this.eyeDropThread.Start();
        }
    }
}
