namespace DesktopWidget
{
    partial class SettingsForm
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
            this.ApplyButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RunOnStartup = new System.Windows.Forms.CheckBox();
            this.ShowSideButtons = new System.Windows.Forms.CheckBox();
            this.RememberChoice = new System.Windows.Forms.CheckBox();
            this.DisplayIntStatus = new System.Windows.Forms.CheckBox();
            this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
            this.DateSelection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DatePreview = new System.Windows.Forms.Label();
            this.DateGroupBox = new System.Windows.Forms.GroupBox();
            this.TimeGroupBox = new System.Windows.Forms.GroupBox();
            this.TimeSelection = new System.Windows.Forms.ComboBox();
            this.TimePreview = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FormatGroupBox = new System.Windows.Forms.GroupBox();
            this.TransparencyCheckBox = new System.Windows.Forms.CheckBox();
            this.ShowSeconds = new System.Windows.Forms.CheckBox();
            this.DisposalGroupBox = new System.Windows.Forms.GroupBox();
            this.ShortcutKeyGroupBox = new System.Windows.Forms.GroupBox();
            this.ShortcutSelection = new System.Windows.Forms.ComboBox();
            this.AllowShortcut = new System.Windows.Forms.CheckBox();
            this.AllowDisposal = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.VersionDisplay = new System.Windows.Forms.Label();
            this.AdvancedButton = new System.Windows.Forms.Button();
            this.FontSelectionDisplay = new System.Windows.Forms.FontDialog();
            this.GeneralGroupBox.SuspendLayout();
            this.DateGroupBox.SuspendLayout();
            this.TimeGroupBox.SuspendLayout();
            this.FormatGroupBox.SuspendLayout();
            this.DisposalGroupBox.SuspendLayout();
            this.ShortcutKeyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(16, 403);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 22;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(268, 403);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 25;
            this.ExitButton.Text = "Cancel";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // RunOnStartup
            // 
            this.RunOnStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RunOnStartup.Location = new System.Drawing.Point(13, 19);
            this.RunOnStartup.Name = "RunOnStartup";
            this.RunOnStartup.Size = new System.Drawing.Size(147, 24);
            this.RunOnStartup.TabIndex = 1;
            this.RunOnStartup.Text = " Run on startup";
            this.RunOnStartup.UseCompatibleTextRendering = true;
            this.RunOnStartup.UseVisualStyleBackColor = true;
            // 
            // ShowSideButtons
            // 
            this.ShowSideButtons.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ShowSideButtons.Location = new System.Drawing.Point(176, 19);
            this.ShowSideButtons.Name = "ShowSideButtons";
            this.ShowSideButtons.Size = new System.Drawing.Size(151, 24);
            this.ShowSideButtons.TabIndex = 2;
            this.ShowSideButtons.Text = " Show side buttons";
            this.ShowSideButtons.UseCompatibleTextRendering = true;
            this.ShowSideButtons.UseVisualStyleBackColor = true;
            // 
            // RememberChoice
            // 
            this.RememberChoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RememberChoice.Location = new System.Drawing.Point(176, 39);
            this.RememberChoice.Name = "RememberChoice";
            this.RememberChoice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RememberChoice.Size = new System.Drawing.Size(151, 24);
            this.RememberChoice.TabIndex = 4;
            this.RememberChoice.Text = " Remember display choice";
            this.RememberChoice.UseCompatibleTextRendering = true;
            this.RememberChoice.UseVisualStyleBackColor = true;
            // 
            // DisplayIntStatus
            // 
            this.DisplayIntStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DisplayIntStatus.Location = new System.Drawing.Point(13, 39);
            this.DisplayIntStatus.Name = "DisplayIntStatus";
            this.DisplayIntStatus.Size = new System.Drawing.Size(147, 24);
            this.DisplayIntStatus.TabIndex = 3;
            this.DisplayIntStatus.Text = " Display internet status";
            this.DisplayIntStatus.UseCompatibleTextRendering = true;
            this.DisplayIntStatus.UseVisualStyleBackColor = true;
            // 
            // GeneralGroupBox
            // 
            this.GeneralGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.GeneralGroupBox.Controls.Add(this.DisplayIntStatus);
            this.GeneralGroupBox.Controls.Add(this.RememberChoice);
            this.GeneralGroupBox.Controls.Add(this.RunOnStartup);
            this.GeneralGroupBox.Controls.Add(this.ShowSideButtons);
            this.GeneralGroupBox.Location = new System.Drawing.Point(16, 12);
            this.GeneralGroupBox.Name = "GeneralGroupBox";
            this.GeneralGroupBox.Size = new System.Drawing.Size(327, 73);
            this.GeneralGroupBox.TabIndex = 0;
            this.GeneralGroupBox.TabStop = false;
            this.GeneralGroupBox.Text = "General";
            this.GeneralGroupBox.UseCompatibleTextRendering = true;
            // 
            // DateSelection
            // 
            this.DateSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DateSelection.FormattingEnabled = true;
            this.DateSelection.Items.AddRange(new object[] {
            "MM/dd/yyyy",
            "M/d/yyyy",
            "M/d/yy",
            "MM/dd/yy",
            "yy/MM/dd",
            "yyyy-MM-dd",
            "dd-MMM-yy",
            "Inherit"});
            this.DateSelection.Location = new System.Drawing.Point(6, 19);
            this.DateSelection.Name = "DateSelection";
            this.DateSelection.Size = new System.Drawing.Size(121, 21);
            this.DateSelection.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Format Preview:";
            // 
            // DatePreview
            // 
            this.DatePreview.BackColor = System.Drawing.Color.White;
            this.DatePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DatePreview.Location = new System.Drawing.Point(6, 59);
            this.DatePreview.Name = "DatePreview";
            this.DatePreview.Size = new System.Drawing.Size(121, 21);
            this.DatePreview.TabIndex = 13;
            this.DatePreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DatePreview.UseCompatibleTextRendering = true;
            // 
            // DateGroupBox
            // 
            this.DateGroupBox.Controls.Add(this.DateSelection);
            this.DateGroupBox.Controls.Add(this.DatePreview);
            this.DateGroupBox.Controls.Add(this.label2);
            this.DateGroupBox.Location = new System.Drawing.Point(176, 19);
            this.DateGroupBox.Name = "DateGroupBox";
            this.DateGroupBox.Size = new System.Drawing.Size(133, 94);
            this.DateGroupBox.TabIndex = 7;
            this.DateGroupBox.TabStop = false;
            this.DateGroupBox.Text = "Date";
            this.DateGroupBox.UseCompatibleTextRendering = true;
            // 
            // TimeGroupBox
            // 
            this.TimeGroupBox.Controls.Add(this.TimeSelection);
            this.TimeGroupBox.Controls.Add(this.TimePreview);
            this.TimeGroupBox.Controls.Add(this.label5);
            this.TimeGroupBox.Location = new System.Drawing.Point(18, 19);
            this.TimeGroupBox.Name = "TimeGroupBox";
            this.TimeGroupBox.Size = new System.Drawing.Size(133, 94);
            this.TimeGroupBox.TabIndex = 6;
            this.TimeGroupBox.TabStop = false;
            this.TimeGroupBox.Text = "Time";
            this.TimeGroupBox.UseCompatibleTextRendering = true;
            // 
            // TimeSelection
            // 
            this.TimeSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeSelection.FormattingEnabled = true;
            this.TimeSelection.Items.AddRange(new object[] {
            "12-Hour",
            "24-Hour",
            "Inherit"});
            this.TimeSelection.Location = new System.Drawing.Point(6, 19);
            this.TimeSelection.Name = "TimeSelection";
            this.TimeSelection.Size = new System.Drawing.Size(121, 21);
            this.TimeSelection.TabIndex = 8;
            // 
            // TimePreview
            // 
            this.TimePreview.BackColor = System.Drawing.Color.White;
            this.TimePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimePreview.Location = new System.Drawing.Point(6, 59);
            this.TimePreview.Name = "TimePreview";
            this.TimePreview.Size = new System.Drawing.Size(121, 21);
            this.TimePreview.TabIndex = 10;
            this.TimePreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TimePreview.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Format Preview:";
            // 
            // FormatGroupBox
            // 
            this.FormatGroupBox.Controls.Add(this.TransparencyCheckBox);
            this.FormatGroupBox.Controls.Add(this.ShowSeconds);
            this.FormatGroupBox.Controls.Add(this.TimeGroupBox);
            this.FormatGroupBox.Controls.Add(this.DateGroupBox);
            this.FormatGroupBox.Location = new System.Drawing.Point(16, 91);
            this.FormatGroupBox.Name = "FormatGroupBox";
            this.FormatGroupBox.Size = new System.Drawing.Size(327, 149);
            this.FormatGroupBox.TabIndex = 5;
            this.FormatGroupBox.TabStop = false;
            this.FormatGroupBox.Text = "Formatting";
            this.FormatGroupBox.UseCompatibleTextRendering = true;
            // 
            // TransparencyCheckBox
            // 
            this.TransparencyCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TransparencyCheckBox.Location = new System.Drawing.Point(176, 119);
            this.TransparencyCheckBox.Name = "TransparencyCheckBox";
            this.TransparencyCheckBox.Size = new System.Drawing.Size(133, 24);
            this.TransparencyCheckBox.TabIndex = 15;
            this.TransparencyCheckBox.Text = " Use Transparency";
            this.TransparencyCheckBox.UseCompatibleTextRendering = true;
            this.TransparencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShowSeconds
            // 
            this.ShowSeconds.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ShowSeconds.Location = new System.Drawing.Point(13, 119);
            this.ShowSeconds.Name = "ShowSeconds";
            this.ShowSeconds.Size = new System.Drawing.Size(147, 24);
            this.ShowSeconds.TabIndex = 14;
            this.ShowSeconds.Text = " Display seconds";
            this.ShowSeconds.UseCompatibleTextRendering = true;
            this.ShowSeconds.UseVisualStyleBackColor = true;
            // 
            // DisposalGroupBox
            // 
            this.DisposalGroupBox.Controls.Add(this.ShortcutKeyGroupBox);
            this.DisposalGroupBox.Controls.Add(this.AllowDisposal);
            this.DisposalGroupBox.Controls.Add(this.label6);
            this.DisposalGroupBox.Location = new System.Drawing.Point(16, 247);
            this.DisposalGroupBox.Name = "DisposalGroupBox";
            this.DisposalGroupBox.Size = new System.Drawing.Size(327, 150);
            this.DisposalGroupBox.TabIndex = 16;
            this.DisposalGroupBox.TabStop = false;
            this.DisposalGroupBox.Text = "Task Disposal";
            this.DisposalGroupBox.UseCompatibleTextRendering = true;
            // 
            // ShortcutKeyGroupBox
            // 
            this.ShortcutKeyGroupBox.Controls.Add(this.ShortcutSelection);
            this.ShortcutKeyGroupBox.Controls.Add(this.AllowShortcut);
            this.ShortcutKeyGroupBox.Location = new System.Drawing.Point(7, 81);
            this.ShortcutKeyGroupBox.Name = "ShortcutKeyGroupBox";
            this.ShortcutKeyGroupBox.Size = new System.Drawing.Size(314, 55);
            this.ShortcutKeyGroupBox.TabIndex = 19;
            this.ShortcutKeyGroupBox.TabStop = false;
            this.ShortcutKeyGroupBox.Text = "Shortcut Key";
            // 
            // ShortcutSelection
            // 
            this.ShortcutSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShortcutSelection.FormattingEnabled = true;
            this.ShortcutSelection.Items.AddRange(new object[] {
            "Break",
            "Break (Hold)",
            "Ctrl+Break",
            "Shift+Break",
            "Ctrl+Alt+Break",
            "Ctrl+Shift+Break"});
            this.ShortcutSelection.Location = new System.Drawing.Point(176, 20);
            this.ShortcutSelection.Name = "ShortcutSelection";
            this.ShortcutSelection.Size = new System.Drawing.Size(121, 21);
            this.ShortcutSelection.TabIndex = 21;
            // 
            // AllowShortcut
            // 
            this.AllowShortcut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AllowShortcut.Location = new System.Drawing.Point(17, 19);
            this.AllowShortcut.Name = "AllowShortcut";
            this.AllowShortcut.Size = new System.Drawing.Size(147, 24);
            this.AllowShortcut.TabIndex = 20;
            this.AllowShortcut.Text = " Allow shortcut usage";
            this.AllowShortcut.UseCompatibleTextRendering = true;
            this.AllowShortcut.UseVisualStyleBackColor = true;
            // 
            // AllowDisposal
            // 
            this.AllowDisposal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AllowDisposal.Location = new System.Drawing.Point(13, 51);
            this.AllowDisposal.Name = "AllowDisposal";
            this.AllowDisposal.Size = new System.Drawing.Size(147, 24);
            this.AllowDisposal.TabIndex = 18;
            this.AllowDisposal.Text = " Allow Task Disposal";
            this.AllowDisposal.UseCompatibleTextRendering = true;
            this.AllowDisposal.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(308, 32);
            this.label6.TabIndex = 17;
            this.label6.Text = "Task Disposal hunts down non-responsive processes and safely terminates them.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // VersionDisplay
            // 
            this.VersionDisplay.BackColor = System.Drawing.Color.Transparent;
            this.VersionDisplay.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.VersionDisplay.Location = new System.Drawing.Point(173, 403);
            this.VersionDisplay.Name = "VersionDisplay";
            this.VersionDisplay.Size = new System.Drawing.Size(89, 23);
            this.VersionDisplay.TabIndex = 24;
            this.VersionDisplay.Text = "Version";
            this.VersionDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.VersionDisplay.UseCompatibleTextRendering = true;
            // 
            // AdvancedButton
            // 
            this.AdvancedButton.Location = new System.Drawing.Point(92, 403);
            this.AdvancedButton.Name = "AdvancedButton";
            this.AdvancedButton.Size = new System.Drawing.Size(75, 23);
            this.AdvancedButton.TabIndex = 23;
            this.AdvancedButton.Text = "Advanced";
            this.AdvancedButton.UseVisualStyleBackColor = true;
            // 
            // FontSelectionDisplay
            // 
            this.FontSelectionDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FontSelectionDisplay.MaxSize = 12;
            this.FontSelectionDisplay.MinSize = 12;
            this.FontSelectionDisplay.ScriptsOnly = true;
            this.FontSelectionDisplay.ShowEffects = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(361, 433);
            this.ControlBox = false;
            this.Controls.Add(this.AdvancedButton);
            this.Controls.Add(this.VersionDisplay);
            this.Controls.Add(this.DisposalGroupBox);
            this.Controls.Add(this.FormatGroupBox);
            this.Controls.Add(this.GeneralGroupBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ApplyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.GeneralGroupBox.ResumeLayout(false);
            this.DateGroupBox.ResumeLayout(false);
            this.DateGroupBox.PerformLayout();
            this.TimeGroupBox.ResumeLayout(false);
            this.TimeGroupBox.PerformLayout();
            this.FormatGroupBox.ResumeLayout(false);
            this.DisposalGroupBox.ResumeLayout(false);
            this.ShortcutKeyGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.CheckBox RunOnStartup;
        private System.Windows.Forms.CheckBox RememberChoice;
        private System.Windows.Forms.CheckBox DisplayIntStatus;
        private System.Windows.Forms.CheckBox ShowSideButtons;
        private System.Windows.Forms.GroupBox GeneralGroupBox;
        private System.Windows.Forms.ComboBox DateSelection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DatePreview;
        private System.Windows.Forms.GroupBox DateGroupBox;
        private System.Windows.Forms.GroupBox TimeGroupBox;
        private System.Windows.Forms.ComboBox TimeSelection;
        private System.Windows.Forms.Label TimePreview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox FormatGroupBox;
        private System.Windows.Forms.CheckBox ShowSeconds;
        private System.Windows.Forms.GroupBox DisposalGroupBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox AllowDisposal;
        private System.Windows.Forms.GroupBox ShortcutKeyGroupBox;
        private System.Windows.Forms.CheckBox AllowShortcut;
        private System.Windows.Forms.ComboBox ShortcutSelection;
        private System.Windows.Forms.Label VersionDisplay;
        private System.Windows.Forms.Button AdvancedButton;
        private System.Windows.Forms.CheckBox TransparencyCheckBox;
        private System.Windows.Forms.FontDialog FontSelectionDisplay;
    }
}