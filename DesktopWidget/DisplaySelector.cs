using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DesktopWidget
{
    public partial class DisplaySelector : Form
    {
        public DisplaySelector()
        {
            this.InitializeComponent();
        }

        private void InitializeEventHandlers()
        {
            this.comboBox1.SelectedIndexChanged += new EventHandler(delegate { this.UpdateValues(); });
            this.RememberCheckbox.CheckedChanged += new EventHandler(delegate { this.UpdateValues(); });
            this.ContinueButton.Click += new EventHandler(delegate { this.Continue(); });
        }

        private void DisplaySelector_Load(object sender, EventArgs e)
        {
            string GetSuffix(int num)
            {
                switch (num)
                {
                    case 1:
                    case 21:
                    case 31:
                        return "st";
                    case 2:
                    case 22:
                        return "nd";
                    case 3:
                    case 23:
                        return "rd";
                    default:
                        return "th";
                }
            }

            for (int i = 0; i < Screen.AllScreens.Length; i += 1)
            {
                if (!Screen.AllScreens[i].Primary)
                    this.comboBox1.Items.Add($"{i}{GetSuffix(i)} Display");
            }

            this.InitializeEventHandlers();
        }

        private void UpdateValues()
        {
            this.ContinueButton.Enabled = (this.comboBox1.SelectedIndex != -1);

            Properties.Settings.Default.DisplaySelected = int.Parse(Regex.Match(this.comboBox1.SelectedItem.ToString(), @"(\d+)").Value);
            Properties.Settings.Default.Remember = this.RememberCheckbox.Checked;

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void Continue()
        {
            this.UpdateValues();
            this.Dispose();
        }

        private void PaintGroupBox(object sender, PaintEventArgs e)
        {
            Engine.DrawGroupBox(this.BackColor, (GroupBox)sender, e.Graphics, Color.Black, Color.FromArgb(255, 160, 160, 160));
        }
    }
}
