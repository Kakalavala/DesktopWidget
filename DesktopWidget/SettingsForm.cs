using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWidget
{
    public partial class SettingsForm : Form
    {
        private Form _ParentForm;
        private string _tpf;
        private string _dpf;
        private string _sk;

        public SettingsForm(Form parent)
        {
            this.InitializeComponent();
            this._ParentForm = parent;
        }

        private void InitializeEventHandlers()
        {
            this.AdvancedButton.Click += new EventHandler(delegate { (new AdvancedSettings()).ShowDialog(); });
            this.ExitButton.Click += new EventHandler(delegate { this.Close(); });
            this.ApplyButton.Click += new EventHandler(this.ApplyChanges);
        }

        private void InitializeLateEventHandlers()
        {
            List<Control> children = new List<Control>();
            string[] whitelist = { "GroupBox", "CheckBox", "ComboBox" };

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
                else if (child.GetType().Name == "CheckBox")
                    ((CheckBox)child).CheckedChanged += new EventHandler(delegate { this.UpdateValueStates(); });
                else
                    ((ComboBox)child).SelectedIndexChanged += new EventHandler(delegate { this.UpdateValueStates(); });
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = "DesktopWidget \u2013 Preferences";

            this.LoadCurrentValues();

            this.VersionDisplay.Text = $"Version {Application.ProductVersion}";

            Engine.AddToolTip(this.ShowSeconds, "Note: Will only affect the Secondary Time.");
            Engine.AddToolTip(this.AllowDisposal, "If disabled, Task Disposal will be unavailable.");
            Engine.AddToolTip(this.AllowShortcut, "If disabled, the key shortcut will be unavailable.");

            this.RememberChoice.Enabled = (Screen.AllScreens.Count() > 2);

            if (!this.RememberChoice.Enabled)
                Engine.AddToolTip(this.RememberChoice, "This option is unavailable because you have less than 3 displays.");

            this.InitializeEventHandlers();
            this.InitializeLateEventHandlers();
        }

        private void LoadCurrentValues()
        {
            this.AllowDisposal.Checked = Properties.Settings.Default.AllowDisposal;
            this.AllowShortcut.Checked = Properties.Settings.Default.AllowShortcut;
            this.RunOnStartup.Checked = Properties.Settings.Default.AllowStartup;
            this.ShowSeconds.Checked = Properties.Settings.Default.ShowSeconds;
            this.DisplayIntStatus.Checked = Properties.Settings.Default.ShowIntStatus;
            this.ShowSideButtons.Checked = Properties.Settings.Default.ShowSideButtons;
            this.RememberChoice.Checked = Properties.Settings.Default.Remember;
            this.TransparencyCheckBox.Checked = Properties.Settings.Default.UseTransparency;

            this.TimeSelection.SelectedIndex = Properties.Settings.Default.TimeFormat;
            this.DateSelection.SelectedIndex = Properties.Settings.Default.DateFormat;
            this.ShortcutSelection.SelectedIndex = Properties.Settings.Default.Shortcut;

            this.UpdateValueStates();
        }

        private void UpdateValues()
        {
            Properties.Settings.Default.AllowDisposal = this.AllowDisposal.Checked;
            Properties.Settings.Default.AllowShortcut = this.AllowShortcut.Checked;
            Properties.Settings.Default.AllowStartup = this.RunOnStartup.Checked;
            Properties.Settings.Default.ShowSeconds = this.ShowSeconds.Checked;
            Properties.Settings.Default.ShowIntStatus = this.DisplayIntStatus.Checked;
            Properties.Settings.Default.ShowSideButtons = this.ShowSideButtons.Checked;
            Properties.Settings.Default.Remember = this.RememberChoice.Checked;
            Properties.Settings.Default.UseTransparency = this.TransparencyCheckBox.Checked;

            Properties.Settings.Default.TimeFormat = this.TimeSelection.SelectedIndex;
            Properties.Settings.Default.DateFormat = this.DateSelection.SelectedIndex;
            Properties.Settings.Default.Shortcut = this.ShortcutSelection.SelectedIndex;

            Properties.Settings.Default._tpf = this._tpf;
            Properties.Settings.Default._dpf = this._dpf;
            Properties.Settings.Default.ShortcutKeys = this._sk;

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void UpdateValueStates()
        {
            DateTime dt = DateTime.Now;

            this.ShortcutKeyGroupBox.Enabled = this.AllowDisposal.Checked;
            this.ShortcutSelection.Enabled = this.AllowShortcut.Checked;

            string tpf = "";

            switch (this.TimeSelection.SelectedItem.ToString())
            {
                case "24-Hour":
                    tpf = "HH:mm";
                    break;
                case "12-Hour":
                    tpf = "h:mm";
                    break;
                default:
                case "Inherit":
                    tpf = DateTimeFormatInfo.GetInstance(Thread.CurrentThread.CurrentCulture).ShortTimePattern.Replace("tt", "").Trim();
                    break;
            }

            if (this.ShowSeconds.Checked)
                tpf += ":ss";
            
            string dpf = this.DateSelection.SelectedItem.ToString();

            if (dpf == "Inherit")
                dpf = DateTimeFormatInfo.GetInstance(Thread.CurrentThread.CurrentCulture).ShortDatePattern;

            this._tpf = tpf;
            this._dpf = dpf;

            this.TimePreview.Text = dt.ToString(tpf);
            this.DatePreview.Text = dt.ToString(dpf);

            this._sk = this.ShortcutSelection.SelectedItem.ToString();
        }

        private void PaintGroupBox(object sender, PaintEventArgs e)
        {
            Engine.DrawGroupBox(this.BackColor, (GroupBox)sender, e.Graphics, Color.Black, Color.FromArgb(255, 160, 160, 160));
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            this.UpdateValues();
            this.Close();

            Application.Restart();
        }

        private void SelectFont(object sender, EventArgs e)
        {
            
        }
    }
}
