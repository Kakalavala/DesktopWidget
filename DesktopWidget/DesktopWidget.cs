using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DesktopWidget
{
    public partial class DesktopWidget : Form
    {
        private SettingsForm settingsForm;
        private TimeStamp stamp;
        private Connection MainConnection;
        private bool IsFormHidden = false;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;

                return cp;
            }
        }

        public DesktopWidget()
        {
            if (Screen.AllScreens.Count() <= 1)
            {
                MessageBox.Show($"You lack the minimum number of displays! (You have: {Screen.AllScreens.Count()})", "DesktopWidget", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (Screen.AllScreens.Count() > 2)
            {
                if (!Properties.Settings.Default.Remember)
                    (new DisplaySelector()).ShowDialog();
            }
            
            this.InitializeComponent();

            this.settingsForm = new SettingsForm(this);
            this.TrayIcon.Icon = Icon.FromHandle(new Bitmap(Properties.Resources.icon).GetHicon());
        }

        private void InitializeEventHandlers()
        {
            NetworkChange.NetworkAvailabilityChanged += this.ConnectivityChangeEvent;

            foreach (ToolStripDropDownItem item in this.CM_Move.DropDownItems)
                item.Click += new EventHandler(this.MoveTo);
            
            this.TrayIcon.Click += new EventHandler(this.ToggleWidget);
            this.CM_Close.Click += new EventHandler(this.ToggleWidget);
            this.CM_Refresh.Click += new EventHandler(this.DoRefresh);
            this.CM_OpenLogs.Click += new EventHandler(delegate { Engine.OpenLogsDirectory(); });
            this.CM_OpenToday.Click += new EventHandler(delegate { Engine.OpenCurrentLog(); });
            this.CM_KillTasks.Click += new EventHandler(this.DoTaskDisposal);
            this.CM_Settings.Click += new EventHandler(this.OpenSettingsForm);
        }

        private void DesktopWidget_Load(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Properties.Settings.Default.AllowStartup)
            {
                if (rk.GetValue(Application.ProductName) == null)
                    rk.SetValue(Application.ProductName, Application.ExecutablePath);
            }
            else
                rk.DeleteValue(Application.ProductName, false);

            if (Properties.Settings.Default.ThemeColor == "Inherit")
            {
                this.WidgetBody.BackColor = ThemeInfo.GetThemeColor();
                this.ProgressStatus.BackColor = ThemeInfo.GetThemeColor();

                Properties.Settings.Default.ThemeColor = Engine.ColorToHex(ThemeInfo.GetThemeColor());
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            else
            {
                this.WidgetBody.BackColor = Engine.ColorFromHex(Properties.Settings.Default.ThemeColor);
                this.ProgressStatus.BackColor = Engine.ColorFromHex(Properties.Settings.Default.ThemeColor);
            }

            this.Opacity = (Properties.Settings.Default.UseTransparency) ? 0.75 : 1;
            this.Location = this.GetPosition();

            this.UpdateContextMenuOptions();
            this.InitializeEventHandlers();

            if (Properties.Settings.Default.ShowSideButtons)
            {
                CustomButton exit_btn = new CustomButton("ExitButton", "Hide", new Point(5, 6), Properties.Resources.hide_icon, this.ToggleWidget);
                CustomButton refresh_btn = new CustomButton("RefreshButton", "Refresh", new Point(5, 49), Properties.Resources.refresh_icon, this.DoRefresh);

                if (Properties.Settings.Default.AllowDisposal)
                {
                    CustomButton disposal_btn = new CustomButton("DisposalButton", "Kill non-responsive tasks", new Point(5, 92), Properties.Resources.disposal_icon, this.DoTaskDisposal);
                    this.Controls.Add(disposal_btn);
                }

                this.Controls.Add(exit_btn);
                this.Controls.Add(refresh_btn);
            }

            // shortcut is handled in the program's Main method
            if (!Properties.Settings.Default.AllowDisposal)
            {
                if (this.Controls.ContainsKey("DisposalButton"))
                    this.Controls.RemoveByKey("DisposalButton");
            }

            if (Properties.Settings.Default.ShowIntStatus)
                this.UpdateConnectivity();
            else
                NetworkChange.NetworkAvailabilityChanged -= this.ConnectivityChangeEvent;
        }

        private void UpdateDisplay()
        {
            this.UpdateContextMenuOptions();

            string tpf = Properties.Settings.Default._tpf.Replace(":ss", "");
            string dpf = Properties.Settings.Default._dpf;

            if (tpf == "Inherit" || tpf == "")
                tpf = DateTimeFormatInfo.GetInstance(Thread.CurrentThread.CurrentCulture).ShortTimePattern.Replace("tt", "").Trim();

            if (dpf == "Inherit" || dpf == "")
                dpf = DateTimeFormatInfo.GetInstance(Thread.CurrentThread.CurrentCulture).ShortDatePattern;

            this.TimeDisplay.Text = this.stamp.DateTimeObject.ToString(tpf);
            this.FullDateDisplay.Text = this.stamp.DateTimeObject.ToString(dpf);

            tpf = (tpf.StartsWith("HH")) ? "h:mm" : "HH:mm";

            if (Properties.Settings.Default.ShowSeconds)
                tpf += ":ss";

            this.SmallTimeDisplay.Text = $"{this.stamp.DateTimeObject.ToString(tpf)} \u0387 {((this.stamp.IsAm) ? "AM" : "PM")}";
            this.SmallDateDisplay.Text = $"{this.stamp.WeekDay} \u2013 {this.stamp.Month} {this.stamp.Day}";
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (this.UpdateTimer.Interval == 100)
                this.UpdateTimer.Interval = 500;

            this.stamp = new TimeStamp();
            this.UpdateDisplay();
        }

        private void UpdateConnectivity()
        {
            List<Connection> connections = new List<Connection>();

            foreach (NetworkInterface net in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (net.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    connections.Add(new Connection(net.Name, net.NetworkInterfaceType, (net.OperationalStatus == OperationalStatus.Up)));
            }

            foreach (Connection con in connections)
            {
                if (con.HasConnection)
                {
                    this.MainConnection = con;
                    break;
                }
            }

            Image conType = (this.MainConnection.IsEthernetConnection) ? Properties.Resources.ethernet_icon : Properties.Resources.wireless_icon;
            Color conCol = (this.MainConnection.HasConnection) ? Color.Lime : Color.Red;

            this.ConnectivityIcon.Image = Engine.TintImage(conType, conCol);
        }

        private void DisplayProgressStatus(string msg, bool hideAfterDelay = false)
        {
            this.ProgressStatus.Text = msg + "\u2026";
            this.ProgressStatus.Visible = true;

            void HideDisplay(object sender, EventArgs e)
            {
                this.ProgressStatus.Text = "";
                this.ProgressStatus.Visible = false;
                ((System.Windows.Forms.Timer)sender).Dispose();
            }

            if (hideAfterDelay)
            {
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 5000;
                timer.Enabled = true;
                timer.Tick += new EventHandler(HideDisplay);
            }
        }

        private Point GetPosition()
        {
            Rectangle _ss = Screen.AllScreens[Properties.Settings.Default.DisplaySelected].WorkingArea;

            if (!Properties.Settings.Default.ShowSideButtons)
                _ss = new Rectangle(_ss.X - 42, _ss.Y, _ss.Width, _ss.Height);

            Point ss = _ss.Location;

            int buffer = (Properties.Settings.Default.ShowSideButtons) ? 52 : 5;

            switch (Engine.GetWidgetPosition())
            {
                default:
                case 0: //top-left
                    return ss;
                case 1: //top-right
                    return new Point(_ss.Right - (this.WidgetBody.Width + buffer), ss.Y);
                case 2: //bottom-left
                    return new Point(ss.X, _ss.Bottom - this.WidgetBody.Height - 12);
                case 3: //bottom-right
                    return new Point(_ss.Right - (this.WidgetBody.Width + buffer), _ss.Bottom - this.WidgetBody.Height - 12);
            }
        }

        private void UpdateContextMenuOptions()
        {
            int pos = Engine.GetWidgetPosition();

            foreach (ToolStripMenuItem item in this.CM_Move.DropDownItems)
            {
                item.Checked = (pos == int.Parse(item.Tag.ToString()));
                item.Enabled = !(pos == int.Parse(item.Tag.ToString()));
            }

            this.CM_OpenLogs.Enabled = Engine.DoesDirectoryExist();
            this.CM_OpenToday.Enabled = Engine.DoesCurrentLogExist();
            this.CM_KillTasks.Enabled = Properties.Settings.Default.AllowDisposal;
        }

        // Event handling

        private void OpenSettingsForm(object sender, EventArgs e)
        {
            if (this.settingsForm.IsDisposed)
                this.settingsForm = new SettingsForm(this);
            
            this.settingsForm.ShowDialog();
        }

        private void ToggleWidget(object sender, EventArgs e)
        {
            if (this.IsFormHidden)
            {
                this.WindowState = FormWindowState.Normal;
                Engine.FadeIn(this, 100);
            }
            else
            {
                Engine.FadeOut(this, 50);
                this.WindowState = FormWindowState.Minimized;
            }

            this.TrayIcon.Visible = !this.IsFormHidden;
            this.IsFormHidden = !this.IsFormHidden;
        }

        private void DoRefresh(object sender, EventArgs e)
        {
            this.DisplayProgressStatus("Refreshing", true);

            this.UpdateContextMenuOptions();
            this.UpdateDisplay();
            this.UpdateConnectivity();
        }

        private void MoveTo(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            Engine.SetWidgetPosition(int.Parse(item.Tag.ToString()));

            this.UpdateContextMenuOptions();
            this.Location = this.GetPosition();
        }

        private void ConnectivityChangeEvent(object sender, NetworkAvailabilityEventArgs e)
        {
            Engine.Log((e.IsAvailable) ? "Connectivity restored." : "Connectivity interupted.");
            this.ConnectivityIcon.Image = Engine.TintImage(this.ConnectivityIcon.Image, ((e.IsAvailable) ? Color.Lime : Color.Red));
        }

        public void DoTaskDisposal(object sender = null, EventArgs e = null)
        {
            if (this.IsFormHidden)
            {
                this.IsFormHidden = !this.IsFormHidden;
                this.WindowState = FormWindowState.Normal;
                Engine.FadeIn(this, 100);
                Thread.Sleep(500);
            }

            this.DisplayProgressStatus("Running Disposal");
            this.CM_KillTasks.Enabled = false;
            int count = Engine.KillTasks();
            string str = $"Disposed of {count} Task{((count > 1 || count == 0) ? "s" : "")}";
            this.CM_KillTasks.Enabled = true;

            Engine.Log(str);
            this.DisplayProgressStatus(str, true);
        }

        private void TimeDisplay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        }
    }
}
