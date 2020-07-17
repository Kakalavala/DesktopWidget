namespace DesktopWidget
{
    partial class AdvancedSettings
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
            this.SystemGroup = new System.Windows.Forms.GroupBox();
            this.AllowLogFilesCheckbox = new System.Windows.Forms.CheckBox();
            this.StartupUpdateBtn = new System.Windows.Forms.Button();
            this.DeleteLogsBtn = new System.Windows.Forms.Button();
            this.StartupRemoveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FormatGroup = new System.Windows.Forms.GroupBox();
            this.ColorSelectorGroup = new System.Windows.Forms.GroupBox();
            this.SetInheritBtn = new System.Windows.Forms.Button();
            this.TryParseBtn = new System.Windows.Forms.Button();
            this.ShowInheritBtn = new System.Windows.Forms.Button();
            this.EyeDropBtn = new System.Windows.Forms.Button();
            this.ColorTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ColorPreviewGroup = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CustomizeColorBtn = new System.Windows.Forms.Button();
            this.Offset = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.BlueSelector = new System.Windows.Forms.NumericUpDown();
            this.GreenSelector = new System.Windows.Forms.NumericUpDown();
            this.RedSelector = new System.Windows.Forms.NumericUpDown();
            this.ColorHexLabel = new System.Windows.Forms.Label();
            this.ColorPreviewPanel = new System.Windows.Forms.Panel();
            this.SetThemeColorBtn = new System.Windows.Forms.Button();
            this.StatusMessage = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.QuitAppBtn = new System.Windows.Forms.Button();
            this.SystemGroup.SuspendLayout();
            this.FormatGroup.SuspendLayout();
            this.ColorSelectorGroup.SuspendLayout();
            this.ColorPreviewGroup.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // SystemGroup
            // 
            this.SystemGroup.Controls.Add(this.AllowLogFilesCheckbox);
            this.SystemGroup.Controls.Add(this.StartupUpdateBtn);
            this.SystemGroup.Controls.Add(this.DeleteLogsBtn);
            this.SystemGroup.Controls.Add(this.StartupRemoveBtn);
            this.SystemGroup.Controls.Add(this.label1);
            this.SystemGroup.Location = new System.Drawing.Point(12, 6);
            this.SystemGroup.Name = "SystemGroup";
            this.SystemGroup.Size = new System.Drawing.Size(384, 76);
            this.SystemGroup.TabIndex = 0;
            this.SystemGroup.TabStop = false;
            this.SystemGroup.Text = "System";
            // 
            // AllowLogFilesCheckbox
            // 
            this.AllowLogFilesCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AllowLogFilesCheckbox.Location = new System.Drawing.Point(14, 43);
            this.AllowLogFilesCheckbox.Name = "AllowLogFilesCheckbox";
            this.AllowLogFilesCheckbox.Size = new System.Drawing.Size(224, 24);
            this.AllowLogFilesCheckbox.TabIndex = 4;
            this.AllowLogFilesCheckbox.Text = " Allow DesktopWidget to create log files";
            this.AllowLogFilesCheckbox.UseCompatibleTextRendering = true;
            this.AllowLogFilesCheckbox.UseVisualStyleBackColor = true;
            // 
            // StartupUpdateBtn
            // 
            this.StartupUpdateBtn.Location = new System.Drawing.Point(240, 16);
            this.StartupUpdateBtn.Name = "StartupUpdateBtn";
            this.StartupUpdateBtn.Size = new System.Drawing.Size(65, 23);
            this.StartupUpdateBtn.TabIndex = 2;
            this.StartupUpdateBtn.Text = "Update";
            this.StartupUpdateBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteLogsBtn
            // 
            this.DeleteLogsBtn.Location = new System.Drawing.Point(240, 43);
            this.DeleteLogsBtn.Name = "DeleteLogsBtn";
            this.DeleteLogsBtn.Size = new System.Drawing.Size(132, 23);
            this.DeleteLogsBtn.TabIndex = 5;
            this.DeleteLogsBtn.Text = "Delete Log Files";
            this.DeleteLogsBtn.UseVisualStyleBackColor = true;
            // 
            // StartupRemoveBtn
            // 
            this.StartupRemoveBtn.Location = new System.Drawing.Point(307, 16);
            this.StartupRemoveBtn.Name = "StartupRemoveBtn";
            this.StartupRemoveBtn.Size = new System.Drawing.Size(65, 23);
            this.StartupRemoveBtn.TabIndex = 3;
            this.StartupRemoveBtn.Text = "Remove";
            this.StartupRemoveBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "DesktopWidget Startup Property";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // FormatGroup
            // 
            this.FormatGroup.Controls.Add(this.ColorSelectorGroup);
            this.FormatGroup.Location = new System.Drawing.Point(12, 88);
            this.FormatGroup.Name = "FormatGroup";
            this.FormatGroup.Size = new System.Drawing.Size(384, 222);
            this.FormatGroup.TabIndex = 6;
            this.FormatGroup.TabStop = false;
            this.FormatGroup.Text = "Format";
            // 
            // ColorSelectorGroup
            // 
            this.ColorSelectorGroup.Controls.Add(this.SetInheritBtn);
            this.ColorSelectorGroup.Controls.Add(this.TryParseBtn);
            this.ColorSelectorGroup.Controls.Add(this.ShowInheritBtn);
            this.ColorSelectorGroup.Controls.Add(this.EyeDropBtn);
            this.ColorSelectorGroup.Controls.Add(this.ColorTextBox);
            this.ColorSelectorGroup.Controls.Add(this.label4);
            this.ColorSelectorGroup.Controls.Add(this.ColorPreviewGroup);
            this.ColorSelectorGroup.Controls.Add(this.SetThemeColorBtn);
            this.ColorSelectorGroup.Location = new System.Drawing.Point(10, 19);
            this.ColorSelectorGroup.Name = "ColorSelectorGroup";
            this.ColorSelectorGroup.Size = new System.Drawing.Size(364, 189);
            this.ColorSelectorGroup.TabIndex = 7;
            this.ColorSelectorGroup.TabStop = false;
            this.ColorSelectorGroup.Text = "Color Selector";
            // 
            // SetInheritBtn
            // 
            this.SetInheritBtn.Location = new System.Drawing.Point(200, 19);
            this.SetInheritBtn.Name = "SetInheritBtn";
            this.SetInheritBtn.Size = new System.Drawing.Size(78, 23);
            this.SetInheritBtn.TabIndex = 10;
            this.SetInheritBtn.Text = "Set to Inherit";
            this.SetInheritBtn.UseVisualStyleBackColor = true;
            // 
            // TryParseBtn
            // 
            this.TryParseBtn.Location = new System.Drawing.Point(279, 50);
            this.TryParseBtn.Name = "TryParseBtn";
            this.TryParseBtn.Size = new System.Drawing.Size(77, 22);
            this.TryParseBtn.TabIndex = 14;
            this.TryParseBtn.Text = "Parse Color";
            this.TryParseBtn.UseVisualStyleBackColor = true;
            // 
            // ShowInheritBtn
            // 
            this.ShowInheritBtn.Location = new System.Drawing.Point(279, 19);
            this.ShowInheritBtn.Name = "ShowInheritBtn";
            this.ShowInheritBtn.Size = new System.Drawing.Size(77, 23);
            this.ShowInheritBtn.TabIndex = 11;
            this.ShowInheritBtn.Text = "Show Inherit";
            this.ShowInheritBtn.UseVisualStyleBackColor = true;
            // 
            // EyeDropBtn
            // 
            this.EyeDropBtn.Location = new System.Drawing.Point(7, 19);
            this.EyeDropBtn.Name = "EyeDropBtn";
            this.EyeDropBtn.Size = new System.Drawing.Size(130, 23);
            this.EyeDropBtn.TabIndex = 8;
            this.EyeDropBtn.Text = "Select with Eye-Dropper";
            this.EyeDropBtn.UseVisualStyleBackColor = true;
            // 
            // ColorTextBox
            // 
            this.ColorTextBox.Location = new System.Drawing.Point(107, 51);
            this.ColorTextBox.Name = "ColorTextBox";
            this.ColorTextBox.Size = new System.Drawing.Size(165, 20);
            this.ColorTextBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Format color from:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.UseCompatibleTextRendering = true;
            // 
            // ColorPreviewGroup
            // 
            this.ColorPreviewGroup.Controls.Add(this.groupBox4);
            this.ColorPreviewGroup.Controls.Add(this.ColorPreviewPanel);
            this.ColorPreviewGroup.Location = new System.Drawing.Point(7, 75);
            this.ColorPreviewGroup.Name = "ColorPreviewGroup";
            this.ColorPreviewGroup.Size = new System.Drawing.Size(349, 100);
            this.ColorPreviewGroup.TabIndex = 15;
            this.ColorPreviewGroup.TabStop = false;
            this.ColorPreviewGroup.Text = "Color Preview";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CustomizeColorBtn);
            this.groupBox4.Controls.Add(this.Offset);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.BlueSelector);
            this.groupBox4.Controls.Add(this.GreenSelector);
            this.groupBox4.Controls.Add(this.RedSelector);
            this.groupBox4.Controls.Add(this.ColorHexLabel);
            this.groupBox4.Location = new System.Drawing.Point(88, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 80);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // CustomizeColorBtn
            // 
            this.CustomizeColorBtn.Location = new System.Drawing.Point(174, 47);
            this.CustomizeColorBtn.Name = "CustomizeColorBtn";
            this.CustomizeColorBtn.Size = new System.Drawing.Size(68, 22);
            this.CustomizeColorBtn.TabIndex = 22;
            this.CustomizeColorBtn.Text = "Customize";
            this.CustomizeColorBtn.UseVisualStyleBackColor = true;
            // 
            // Offset
            // 
            this.Offset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Offset.Location = new System.Drawing.Point(122, 48);
            this.Offset.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.Offset.Name = "Offset";
            this.Offset.Size = new System.Drawing.Size(46, 20);
            this.Offset.TabIndex = 21;
            this.Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Theme Color Offset:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // BlueSelector
            // 
            this.BlueSelector.ForeColor = System.Drawing.Color.Blue;
            this.BlueSelector.Location = new System.Drawing.Point(195, 19);
            this.BlueSelector.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueSelector.Name = "BlueSelector";
            this.BlueSelector.Size = new System.Drawing.Size(46, 20);
            this.BlueSelector.TabIndex = 20;
            this.BlueSelector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GreenSelector
            // 
            this.GreenSelector.ForeColor = System.Drawing.Color.Green;
            this.GreenSelector.Location = new System.Drawing.Point(147, 19);
            this.GreenSelector.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenSelector.Name = "GreenSelector";
            this.GreenSelector.Size = new System.Drawing.Size(46, 20);
            this.GreenSelector.TabIndex = 19;
            this.GreenSelector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RedSelector
            // 
            this.RedSelector.ForeColor = System.Drawing.Color.Red;
            this.RedSelector.Location = new System.Drawing.Point(99, 19);
            this.RedSelector.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedSelector.Name = "RedSelector";
            this.RedSelector.Size = new System.Drawing.Size(46, 20);
            this.RedSelector.TabIndex = 18;
            this.RedSelector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColorHexLabel
            // 
            this.ColorHexLabel.BackColor = System.Drawing.Color.White;
            this.ColorHexLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorHexLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ColorHexLabel.Location = new System.Drawing.Point(14, 19);
            this.ColorHexLabel.Name = "ColorHexLabel";
            this.ColorHexLabel.Size = new System.Drawing.Size(80, 20);
            this.ColorHexLabel.TabIndex = 17;
            this.ColorHexLabel.Text = "Color Hex";
            this.ColorHexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ColorHexLabel.UseCompatibleTextRendering = true;
            // 
            // ColorPreviewPanel
            // 
            this.ColorPreviewPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ColorPreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ColorPreviewPanel.Location = new System.Drawing.Point(6, 19);
            this.ColorPreviewPanel.Name = "ColorPreviewPanel";
            this.ColorPreviewPanel.Size = new System.Drawing.Size(75, 75);
            this.ColorPreviewPanel.TabIndex = 16;
            // 
            // SetThemeColorBtn
            // 
            this.SetThemeColorBtn.Location = new System.Drawing.Point(139, 19);
            this.SetThemeColorBtn.Name = "SetThemeColorBtn";
            this.SetThemeColorBtn.Size = new System.Drawing.Size(60, 23);
            this.SetThemeColorBtn.TabIndex = 9;
            this.SetThemeColorBtn.Text = "Set Color";
            this.SetThemeColorBtn.UseVisualStyleBackColor = true;
            // 
            // StatusMessage
            // 
            this.StatusMessage.BackColor = System.Drawing.Color.Transparent;
            this.StatusMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.081633F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusMessage.Location = new System.Drawing.Point(151, 317);
            this.StatusMessage.Name = "StatusMessage";
            this.StatusMessage.Size = new System.Drawing.Size(174, 23);
            this.StatusMessage.TabIndex = 24;
            this.StatusMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(11, 317);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(133, 23);
            this.BackBtn.TabIndex = 23;
            this.BackBtn.Text = "Return to Preferences";
            this.BackBtn.UseVisualStyleBackColor = true;
            // 
            // QuitAppBtn
            // 
            this.QuitAppBtn.Location = new System.Drawing.Point(332, 317);
            this.QuitAppBtn.Name = "QuitAppBtn";
            this.QuitAppBtn.Size = new System.Drawing.Size(65, 23);
            this.QuitAppBtn.TabIndex = 25;
            this.QuitAppBtn.Text = "Quit App";
            this.QuitAppBtn.UseVisualStyleBackColor = true;
            // 
            // AdvancedSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 347);
            this.ControlBox = false;
            this.Controls.Add(this.QuitAppBtn);
            this.Controls.Add(this.StatusMessage);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.FormatGroup);
            this.Controls.Add(this.SystemGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Preferences";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AdvancedSettings_Load);
            this.SystemGroup.ResumeLayout(false);
            this.FormatGroup.ResumeLayout(false);
            this.ColorSelectorGroup.ResumeLayout(false);
            this.ColorSelectorGroup.PerformLayout();
            this.ColorPreviewGroup.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SystemGroup;
        private System.Windows.Forms.Button StartupRemoveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartupUpdateBtn;
        private System.Windows.Forms.GroupBox FormatGroup;
        private System.Windows.Forms.GroupBox ColorSelectorGroup;
        private System.Windows.Forms.Button SetThemeColorBtn;
        private System.Windows.Forms.GroupBox ColorPreviewGroup;
        private System.Windows.Forms.Panel ColorPreviewPanel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label ColorHexLabel;
        private System.Windows.Forms.NumericUpDown BlueSelector;
        private System.Windows.Forms.NumericUpDown GreenSelector;
        private System.Windows.Forms.NumericUpDown RedSelector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ColorTextBox;
        private System.Windows.Forms.Button EyeDropBtn;
        private System.Windows.Forms.Label StatusMessage;
        private System.Windows.Forms.Button ShowInheritBtn;
        private System.Windows.Forms.NumericUpDown Offset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CustomizeColorBtn;
        private System.Windows.Forms.Button TryParseBtn;
        private System.Windows.Forms.CheckBox AllowLogFilesCheckbox;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button SetInheritBtn;
        private System.Windows.Forms.Button DeleteLogsBtn;
        private System.Windows.Forms.Button QuitAppBtn;
    }
}