using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopWidget
{
    public partial class CustomButton : Panel
    {
        private PictureBox btnIcon;
        private ToolTip btnTip;
        private Image icon;
        private EventHandler handler;
        private Thread returnThread;
        private Size _size = new Size(42, 42);

        private int CurrentState = 0;
        private bool IsActive = false;
        private int HoldActiveDuration = 5000;

        public CustomButton(string ButtonName, string HoverText, Point Location, Image ButtonImage, EventHandler handler)
        {
            this.CurrentState = 0;
            this.Size = this._size;
            this.Name = ButtonName;
            this.Location = Location;
            this.icon = ButtonImage;
            this.handler = handler;

            this.CreateIcon(HoverText);
            this.UpdateButton();
        }

        private void CreateIcon(string HoverText)
        {
            this.btnIcon = new PictureBox();
            this.btnIcon.Size = this._size;
            this.btnIcon.BorderStyle = BorderStyle.None;
            this.btnIcon.BackColor = Color.Transparent;
            this.btnIcon.Image = this.icon;

            this.btnTip = new ToolTip();
            this.btnTip.SetToolTip(this.btnIcon, HoverText);
            this.btnTip.AutomaticDelay = 1000;

            this.btnIcon.Click += this.ButtonClick;
            this.btnIcon.MouseEnter += this.ButtonHover;
            this.btnIcon.MouseLeave += this.ButtonLeave;

            this.Controls.Add(this.btnIcon);
        }

        private void UpdateButton(int changeState = -1)
        {
            Color tc = (Properties.Settings.Default.ThemeColor == "Inherit") ? ThemeInfo.GetThemeColor() : Engine.ColorFromHex(Properties.Settings.Default.ThemeColor);
            Color _col = Engine.ColorFromHex(Properties.Settings.Default.ThemeColor);

            if (changeState != -1)
                this.CurrentState = changeState;

            int _r = 0;
            int _g = 0;
            int _b = 0;

            switch (changeState)
            {
                default:
                case 0:
                    this.BackColor = tc;
                    break;
                case 1:
                    _r = (_col.R + 50 >= 225) ? -50 : 50;
                    _g = (_col.G + 50 >= 225) ? -50 : 50;
                    _b = (_col.B + 50 >= 225) ? -50 : 50;

                    this.BackColor = Color.FromArgb(255, tc.R + _r, tc.G + _g, tc.B + _b);
                    break;
                case 2:
                    _r = (_col.R + 50 >= 225) ? -100 : 100;
                    _g = (_col.G + 50 >= 225) ? -100 : 100;
                    _b = (_col.B + 50 >= 225) ? -100 : 100;

                    this.BackColor = Color.FromArgb(255, tc.R + _r, tc.G + _g, tc.B + _b);
                    break;
            }

            this.btnIcon.Image = this.icon;

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(this.Update));
            else this.Update();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (this.IsActive)
                return;

            this.IsActive = true;
            this.UpdateButton(2);
            this.handler.Invoke(sender, e);

            this.returnThread = new Thread(new ThreadStart(ReturnButtonToNormal));
            this.returnThread.Start();
        }

        private void ButtonHover(object sender, EventArgs e)
        {
            this.btnTip.Active = !this.IsActive;

            if (!this.IsActive)
                this.UpdateButton(1);
        }

        private void ButtonLeave(object sender, EventArgs e)
        {
            if (!this.IsActive)
                this.UpdateButton(0);
        }

        private async void ReturnButtonToNormal()
        {
            await this._DoReturn();

            this.returnThread.Abort();
            this.UpdateButton(0);
            this.IsActive = false;
        }

        private async Task<bool> _DoReturn()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(HoldActiveDuration);
                return true;
            });
        }
    }
}
