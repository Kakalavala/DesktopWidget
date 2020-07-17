namespace DesktopWidget
{
    partial class DesktopWidget
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.MainContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CM_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_KillTasks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CM_Logs = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_OpenLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_OpenToday = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Move = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Move_TL = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Move_TR = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Move_BL = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Move_BR = new System.Windows.Forms.ToolStripMenuItem();
            this.CM_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.WidgetBody = new System.Windows.Forms.Panel();
            this.ProgressStatus = new System.Windows.Forms.Label();
            this.FullDateDisplay = new System.Windows.Forms.Label();
            this.SmallDateDisplay = new System.Windows.Forms.Label();
            this.SmallTimeDisplay = new System.Windows.Forms.Label();
            this.TimeDisplay = new System.Windows.Forms.Label();
            this.ConnectivityIcon = new System.Windows.Forms.PictureBox();
            this.ConnectionTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainContextMenu.SuspendLayout();
            this.WidgetBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectivityIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // MainContextMenu
            // 
            this.MainContextMenu.BackColor = System.Drawing.Color.White;
            this.MainContextMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.816325F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CM_Close,
            this.CM_Refresh,
            this.CM_KillTasks,
            this.toolStripSeparator1,
            this.CM_Logs,
            this.CM_Move,
            this.CM_Settings});
            this.MainContextMenu.Name = "ContextMenu";
            this.MainContextMenu.Size = new System.Drawing.Size(178, 142);
            // 
            // CM_Close
            // 
            this.CM_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.816325F);
            this.CM_Close.Image = global::DesktopWidget.Properties.Resources.hide;
            this.CM_Close.Name = "CM_Close";
            this.CM_Close.Size = new System.Drawing.Size(177, 22);
            this.CM_Close.Text = "Hide";
            this.CM_Close.ToolTipText = "Can be re-opened via the System Tray";
            // 
            // CM_Refresh
            // 
            this.CM_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.816325F);
            this.CM_Refresh.Image = global::DesktopWidget.Properties.Resources.reficon;
            this.CM_Refresh.Name = "CM_Refresh";
            this.CM_Refresh.Size = new System.Drawing.Size(177, 22);
            this.CM_Refresh.Text = "Refresh";
            // 
            // CM_KillTasks
            // 
            this.CM_KillTasks.Image = global::DesktopWidget.Properties.Resources.task;
            this.CM_KillTasks.Name = "CM_KillTasks";
            this.CM_KillTasks.ShortcutKeyDisplayString = "";
            this.CM_KillTasks.Size = new System.Drawing.Size(177, 22);
            this.CM_KillTasks.Text = "Run Task Disposal";
            this.CM_KillTasks.ToolTipText = "Kills non-responsive tasks";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // CM_Logs
            // 
            this.CM_Logs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CM_OpenLogs,
            this.CM_OpenToday});
            this.CM_Logs.Image = global::DesktopWidget.Properties.Resources.logicon;
            this.CM_Logs.Name = "CM_Logs";
            this.CM_Logs.Size = new System.Drawing.Size(177, 22);
            this.CM_Logs.Text = "Logs...";
            // 
            // CM_OpenLogs
            // 
            this.CM_OpenLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CM_OpenLogs.Name = "CM_OpenLogs";
            this.CM_OpenLogs.Size = new System.Drawing.Size(168, 22);
            this.CM_OpenLogs.Text = "Open Logs folder";
            // 
            // CM_OpenToday
            // 
            this.CM_OpenToday.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CM_OpenToday.Name = "CM_OpenToday";
            this.CM_OpenToday.Size = new System.Drawing.Size(168, 22);
            this.CM_OpenToday.Text = "View Today";
            // 
            // CM_Move
            // 
            this.CM_Move.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CM_Move_TL,
            this.CM_Move_TR,
            this.CM_Move_BL,
            this.CM_Move_BR});
            this.CM_Move.Image = global::DesktopWidget.Properties.Resources.moveicon;
            this.CM_Move.Name = "CM_Move";
            this.CM_Move.Size = new System.Drawing.Size(177, 22);
            this.CM_Move.Text = "Move to...";
            // 
            // CM_Move_TL
            // 
            this.CM_Move_TL.Name = "CM_Move_TL";
            this.CM_Move_TL.Size = new System.Drawing.Size(146, 22);
            this.CM_Move_TL.Tag = "0";
            this.CM_Move_TL.Text = "Top-Left";
            // 
            // CM_Move_TR
            // 
            this.CM_Move_TR.Name = "CM_Move_TR";
            this.CM_Move_TR.Size = new System.Drawing.Size(146, 22);
            this.CM_Move_TR.Tag = "1";
            this.CM_Move_TR.Text = "Top-Right";
            // 
            // CM_Move_BL
            // 
            this.CM_Move_BL.Name = "CM_Move_BL";
            this.CM_Move_BL.Size = new System.Drawing.Size(146, 22);
            this.CM_Move_BL.Tag = "2";
            this.CM_Move_BL.Text = "Bottom-Left";
            // 
            // CM_Move_BR
            // 
            this.CM_Move_BR.Name = "CM_Move_BR";
            this.CM_Move_BR.Size = new System.Drawing.Size(146, 22);
            this.CM_Move_BR.Tag = "3";
            this.CM_Move_BR.Text = "Bottom-Right";
            // 
            // CM_Settings
            // 
            this.CM_Settings.Image = global::DesktopWidget.Properties.Resources.cog;
            this.CM_Settings.Name = "CM_Settings";
            this.CM_Settings.Size = new System.Drawing.Size(177, 22);
            this.CM_Settings.Text = "Preferences...";
            // 
            // TrayIcon
            // 
            this.TrayIcon.Text = "DesktopWidget";
            // 
            // WidgetBody
            // 
            this.WidgetBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.WidgetBody.Controls.Add(this.ProgressStatus);
            this.WidgetBody.Controls.Add(this.FullDateDisplay);
            this.WidgetBody.Controls.Add(this.SmallDateDisplay);
            this.WidgetBody.Controls.Add(this.SmallTimeDisplay);
            this.WidgetBody.Controls.Add(this.TimeDisplay);
            this.WidgetBody.Controls.Add(this.ConnectivityIcon);
            this.WidgetBody.Font = new System.Drawing.Font("Calibri", 8.081633F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WidgetBody.Location = new System.Drawing.Point(48, 6);
            this.WidgetBody.Name = "WidgetBody";
            this.WidgetBody.Size = new System.Drawing.Size(297, 128);
            this.WidgetBody.TabIndex = 0;
            // 
            // ProgressStatus
            // 
            this.ProgressStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ProgressStatus.Font = new System.Drawing.Font("Calibri Light", 11.7551F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressStatus.ForeColor = System.Drawing.Color.White;
            this.ProgressStatus.Location = new System.Drawing.Point(36, 4);
            this.ProgressStatus.Name = "ProgressStatus";
            this.ProgressStatus.Size = new System.Drawing.Size(255, 26);
            this.ProgressStatus.TabIndex = 5;
            this.ProgressStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgressStatus.UseCompatibleTextRendering = true;
            this.ProgressStatus.Visible = false;
            // 
            // FullDateDisplay
            // 
            this.FullDateDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FullDateDisplay.BackColor = System.Drawing.Color.Transparent;
            this.FullDateDisplay.Font = new System.Drawing.Font("Calibri Light", 13.95918F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullDateDisplay.ForeColor = System.Drawing.Color.White;
            this.FullDateDisplay.Location = new System.Drawing.Point(191, 103);
            this.FullDateDisplay.Name = "FullDateDisplay";
            this.FullDateDisplay.Size = new System.Drawing.Size(100, 23);
            this.FullDateDisplay.TabIndex = 4;
            this.FullDateDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FullDateDisplay.UseCompatibleTextRendering = true;
            // 
            // SmallDateDisplay
            // 
            this.SmallDateDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SmallDateDisplay.BackColor = System.Drawing.Color.Transparent;
            this.SmallDateDisplay.Font = new System.Drawing.Font("Calibri Light", 13.95918F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmallDateDisplay.ForeColor = System.Drawing.Color.White;
            this.SmallDateDisplay.Location = new System.Drawing.Point(5, 103);
            this.SmallDateDisplay.Name = "SmallDateDisplay";
            this.SmallDateDisplay.Size = new System.Drawing.Size(150, 23);
            this.SmallDateDisplay.TabIndex = 3;
            this.SmallDateDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SmallDateDisplay.UseCompatibleTextRendering = true;
            // 
            // SmallTimeDisplay
            // 
            this.SmallTimeDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SmallTimeDisplay.BackColor = System.Drawing.Color.Transparent;
            this.SmallTimeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.7551F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmallTimeDisplay.ForeColor = System.Drawing.Color.White;
            this.SmallTimeDisplay.Location = new System.Drawing.Point(170, 3);
            this.SmallTimeDisplay.Name = "SmallTimeDisplay";
            this.SmallTimeDisplay.Size = new System.Drawing.Size(121, 23);
            this.SmallTimeDisplay.TabIndex = 1;
            this.SmallTimeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SmallTimeDisplay.UseCompatibleTextRendering = true;
            // 
            // TimeDisplay
            // 
            this.TimeDisplay.BackColor = System.Drawing.Color.Transparent;
            this.TimeDisplay.Font = new System.Drawing.Font("Calibri", 55.83673F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeDisplay.ForeColor = System.Drawing.Color.White;
            this.TimeDisplay.Location = new System.Drawing.Point(3, 30);
            this.TimeDisplay.Name = "TimeDisplay";
            this.TimeDisplay.Size = new System.Drawing.Size(291, 76);
            this.TimeDisplay.TabIndex = 2;
            this.TimeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TimeDisplay.UseCompatibleTextRendering = true;
            this.TimeDisplay.UseMnemonic = false;
            this.TimeDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.TimeDisplay_Paint);
            // 
            // ConnectivityIcon
            // 
            this.ConnectivityIcon.BackColor = System.Drawing.Color.Transparent;
            this.ConnectivityIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ConnectivityIcon.Location = new System.Drawing.Point(3, 4);
            this.ConnectivityIcon.Name = "ConnectivityIcon";
            this.ConnectivityIcon.Size = new System.Drawing.Size(27, 23);
            this.ConnectivityIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ConnectivityIcon.TabIndex = 1;
            this.ConnectivityIcon.TabStop = false;
            // 
            // DesktopWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(353, 141);
            this.ContextMenuStrip = this.MainContextMenu;
            this.Controls.Add(this.WidgetBody);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DesktopWidget";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DesktopWidget";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.DesktopWidget_Load);
            this.MainContextMenu.ResumeLayout(false);
            this.WidgetBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConnectivityIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox ConnectivityIcon;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Label TimeDisplay;
        private System.Windows.Forms.Label SmallTimeDisplay;
        private System.Windows.Forms.Label SmallDateDisplay;
        private System.Windows.Forms.Label FullDateDisplay;
        private System.Windows.Forms.ContextMenuStrip MainContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CM_Close;
        private System.Windows.Forms.ToolStripMenuItem CM_Refresh;
        private System.Windows.Forms.ToolStripMenuItem CM_Logs;
        private System.Windows.Forms.ToolStripMenuItem CM_OpenLogs;
        private System.Windows.Forms.ToolStripMenuItem CM_OpenToday;
        private System.Windows.Forms.Label ProgressStatus;
        private System.Windows.Forms.ToolStripMenuItem CM_Move_TL;
        private System.Windows.Forms.ToolStripMenuItem CM_Move_TR;
        private System.Windows.Forms.ToolStripMenuItem CM_Move_BL;
        private System.Windows.Forms.ToolStripMenuItem CM_Move_BR;
        private System.Windows.Forms.ToolStripMenuItem CM_Move;
        private System.Windows.Forms.ToolStripMenuItem CM_KillTasks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ToolStripMenuItem CM_Settings;
        public System.Windows.Forms.Panel WidgetBody;
        private System.Windows.Forms.ToolTip ConnectionTip;
    }
}

