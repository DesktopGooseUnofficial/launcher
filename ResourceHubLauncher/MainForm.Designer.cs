namespace ResourceHubLauncher
{
    partial class MainForm
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
            this.otherMods = new System.Windows.Forms.ListBox();
            this.modListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.VersionLabel = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.enabledMods = new System.Windows.Forms.ListBox();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.disabledMods = new System.Windows.Forms.ListBox();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.RunGoose = new MetroFramework.Controls.MetroButton();
            this.modListContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // otherMods
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.otherMods, true);
            this.otherMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.otherMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.otherMods.ContextMenuStrip = this.modListContextMenu;
            this.otherMods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.otherMods.FormattingEnabled = true;
            this.otherMods.IntegralHeight = false;
            this.otherMods.Location = new System.Drawing.Point(11, 76);
            this.otherMods.Margin = new System.Windows.Forms.Padding(2);
            this.otherMods.Name = "otherMods";
            this.otherMods.Size = new System.Drawing.Size(171, 173);
            this.otherMods.TabIndex = 0;
            this.otherMods.TabStop = false;
            // 
            // modListContextMenu
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.modListContextMenu, true);
            this.modListContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.modListContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.modListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToolStripMenuItem,
            this.resourceHubToolStripMenuItem});
            this.modListContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.modListContextMenu.Name = "modListContextMenu";
            this.modListContextMenu.ShowImageMargin = false;
            this.modListContextMenu.Size = new System.Drawing.Size(121, 48);
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.installToolStripMenuItem.Text = "Install";
            this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
            // 
            // resourceHubToolStripMenuItem
            // 
            this.resourceHubToolStripMenuItem.Name = "resourceHubToolStripMenuItem";
            this.resourceHubToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.resourceHubToolStripMenuItem.Text = "ResourceHub";
            this.resourceHubToolStripMenuItem.Click += new System.EventHandler(this.resourceHubToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available mods:";
            this.label1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(428, 388);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(171, 19);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "ResourceHub Launcher 0.1.0";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.VersionLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(196, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 174);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mod description";
            this.label3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // enabledMods
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.enabledMods, true);
            this.enabledMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.enabledMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enabledMods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.enabledMods.FormattingEnabled = true;
            this.enabledMods.IntegralHeight = false;
            this.enabledMods.Location = new System.Drawing.Point(11, 273);
            this.enabledMods.Margin = new System.Windows.Forms.Padding(2);
            this.enabledMods.Name = "enabledMods";
            this.enabledMods.Size = new System.Drawing.Size(171, 134);
            this.enabledMods.TabIndex = 4;
            this.enabledMods.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 251);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Installed mods:";
            this.label4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 251);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Disabled mods:";
            this.label5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // disabledMods
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.disabledMods, true);
            this.disabledMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.disabledMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.disabledMods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.disabledMods.FormattingEnabled = true;
            this.disabledMods.IntegralHeight = false;
            this.disabledMods.Location = new System.Drawing.Point(198, 273);
            this.disabledMods.Margin = new System.Windows.Forms.Padding(2);
            this.disabledMods.Name = "disabledMods";
            this.disabledMods.Size = new System.Drawing.Size(171, 134);
            this.disabledMods.TabIndex = 7;
            this.disabledMods.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mod description:";
            this.label6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroStyleExtender1
            // 
            this.metroStyleExtender1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RunGoose
            // 
            this.RunGoose.Location = new System.Drawing.Point(381, 365);
            this.RunGoose.Margin = new System.Windows.Forms.Padding(2);
            this.RunGoose.Name = "RunGoose";
            this.RunGoose.Size = new System.Drawing.Size(218, 21);
            this.RunGoose.TabIndex = 14;
            this.RunGoose.TabStop = false;
            this.RunGoose.Text = "Run Goose";
            this.RunGoose.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RunGoose.UseSelectable = true;
            this.RunGoose.Click += new System.EventHandler(this.RunGoose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 417);
            this.Controls.Add(this.RunGoose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.disabledMods);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.enabledMods);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.otherMods);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "ResourceHub Launcher";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.modListContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox otherMods;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel VersionLabel;
        private MetroFramework.Controls.MetroLabel label3;
        private System.Windows.Forms.ListBox enabledMods;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label5;
        private System.Windows.Forms.ListBox disabledMods;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private System.Windows.Forms.ContextMenuStrip modListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
        private MetroFramework.Controls.MetroButton RunGoose;
        private System.Windows.Forms.ToolStripMenuItem resourceHubToolStripMenuItem;
    }
}

