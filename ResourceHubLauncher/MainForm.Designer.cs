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
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.enabledMods = new System.Windows.Forms.ListBox();
            this.installedModsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.styleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.modInfo = new System.Windows.Forms.ListBox();
            this.RunGoose = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.modListContextMenu.SuspendLayout();
            this.installedModsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // otherMods
            // 
            this.styleExtender.SetApplyMetroTheme(this.otherMods, true);
            this.otherMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.otherMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.otherMods.ContextMenuStrip = this.modListContextMenu;
            this.otherMods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.otherMods.FormattingEnabled = true;
            this.otherMods.IntegralHeight = false;
            this.otherMods.Location = new System.Drawing.Point(11, 76);
            this.otherMods.Margin = new System.Windows.Forms.Padding(2);
            this.otherMods.Name = "otherMods";
            this.otherMods.Size = new System.Drawing.Size(170, 173);
            this.otherMods.TabIndex = 0;
            this.otherMods.TabStop = false;
            this.otherMods.SelectedIndexChanged += new System.EventHandler(this.OtherMods_SelectedIndexChanged);
            // 
            // modListContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.modListContextMenu, true);
            this.modListContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.modListContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.modListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToolStripMenuItem,
            this.resourceHubToolStripMenuItem});
            this.modListContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.modListContextMenu.Name = "modListContextMenu";
            this.modListContextMenu.ShowImageMargin = false;
            this.modListContextMenu.Size = new System.Drawing.Size(121, 48);
            this.modListContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ModListContextMenu_Opening);
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.installToolStripMenuItem.Text = "Install";
            this.installToolStripMenuItem.Click += new System.EventHandler(this.InstallToolStripMenuItem_Click);
            // 
            // resourceHubToolStripMenuItem
            // 
            this.resourceHubToolStripMenuItem.Name = "resourceHubToolStripMenuItem";
            this.resourceHubToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.resourceHubToolStripMenuItem.Text = "ResourceHub";
            this.resourceHubToolStripMenuItem.Click += new System.EventHandler(this.ResourceHubToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available mods:";
            this.label1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(194, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 174);
            this.label3.TabIndex = 3;
            this.label3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // enabledMods
            // 
            this.enabledMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.styleExtender.SetApplyMetroTheme(this.enabledMods, true);
            this.enabledMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.enabledMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enabledMods.ContextMenuStrip = this.installedModsContextMenu;
            this.enabledMods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.enabledMods.FormattingEnabled = true;
            this.enabledMods.IntegralHeight = false;
            this.enabledMods.Location = new System.Drawing.Point(11, 275);
            this.enabledMods.Margin = new System.Windows.Forms.Padding(2);
            this.enabledMods.Name = "enabledMods";
            this.enabledMods.Size = new System.Drawing.Size(170, 91);
            this.enabledMods.TabIndex = 4;
            this.enabledMods.TabStop = false;
            // 
            // installedModsContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.installedModsContextMenu, true);
            this.installedModsContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.installedModsContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.installedModsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.openInModsToolStripMenuItem});
            this.installedModsContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.installedModsContextMenu.Name = "modListContextMenu";
            this.installedModsContextMenu.ShowImageMargin = false;
            this.installedModsContextMenu.Size = new System.Drawing.Size(125, 48);
            this.installedModsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.InstalledModsContextMenu_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "Uninstall";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // openInModsToolStripMenuItem
            // 
            this.openInModsToolStripMenuItem.Name = "openInModsToolStripMenuItem";
            this.openInModsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openInModsToolStripMenuItem.Text = "Open in Mods";
            this.openInModsToolStripMenuItem.Click += new System.EventHandler(this.OpenInModsToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 253);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Installed mods:";
            this.label4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mod description:";
            this.label6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // styleExtender
            // 
            this.styleExtender.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // modInfo
            // 
            this.modInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.styleExtender.SetApplyMetroTheme(this.modInfo, true);
            this.modInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.modInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.modInfo.FormattingEnabled = true;
            this.modInfo.IntegralHeight = false;
            this.modInfo.Items.AddRange(new object[] {
            "Category:",
            "Rating:"});
            this.modInfo.Location = new System.Drawing.Point(426, 275);
            this.modInfo.Margin = new System.Windows.Forms.Padding(2);
            this.modInfo.Name = "modInfo";
            this.modInfo.Size = new System.Drawing.Size(170, 91);
            this.modInfo.TabIndex = 22;
            this.modInfo.TabStop = false;
            // 
            // RunGoose
            // 
            this.RunGoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RunGoose.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.RunGoose.Location = new System.Drawing.Point(185, 342);
            this.RunGoose.Margin = new System.Windows.Forms.Padding(2);
            this.RunGoose.Name = "RunGoose";
            this.RunGoose.Size = new System.Drawing.Size(117, 24);
            this.RunGoose.TabIndex = 14;
            this.RunGoose.TabStop = false;
            this.RunGoose.Text = "Run Goose";
            this.RunGoose.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RunGoose.UseSelectable = true;
            this.RunGoose.Click += new System.EventHandler(this.RunGoose_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(345, 314);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(77, 24);
            this.metroButton1.TabIndex = 15;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "Settings";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(185, 314);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(77, 24);
            this.metroButton2.TabIndex = 16;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "Discord";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.MetroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton3.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton3.Location = new System.Drawing.Point(266, 314);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(75, 24);
            this.metroButton3.TabIndex = 17;
            this.metroButton3.TabStop = false;
            this.metroButton3.Text = "GitHub";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.MetroButton3_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton4.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton4.Location = new System.Drawing.Point(305, 342);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(117, 24);
            this.metroButton4.TabIndex = 18;
            this.metroButton4.TabStop = false;
            this.metroButton4.Text = "Stop Goose";
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.MetroButton4_Click);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroProgressBar1.Location = new System.Drawing.Point(185, 297);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(237, 12);
            this.metroProgressBar1.TabIndex = 20;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressBar1.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(200, 272);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(106, 19);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Installing Foobar";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.Visible = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(422, 253);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 19);
            this.metroLabel2.TabIndex = 23;
            this.metroLabel2.Text = "Mod Info:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton5.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton5.Location = new System.Drawing.Point(306, 342);
            this.metroButton5.Margin = new System.Windows.Forms.Padding(2);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(0, 24);
            this.metroButton5.TabIndex = 24;
            this.metroButton5.TabStop = false;
            this.metroButton5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton5.UseSelectable = true;
            // 
            // metroButton6
            // 
            this.metroButton6.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton6.Location = new System.Drawing.Point(165, 76);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(16, 16);
            this.metroButton6.TabIndex = 25;
            this.metroButton6.Text = "↻";
            this.metroButton6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton6.UseSelectable = true;
            this.metroButton6.Click += new System.EventHandler(this.MetroButton6_Click);
            // 
            // metroSpinner
            // 
            this.metroSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroSpinner.Location = new System.Drawing.Point(186, 275);
            this.metroSpinner.Maximum = 100;
            this.metroSpinner.Name = "metroSpinner";
            this.metroSpinner.Size = new System.Drawing.Size(16, 16);
            this.metroSpinner.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroSpinner.TabIndex = 26;
            this.metroSpinner.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroSpinner.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 380);
            this.Controls.Add(this.metroSpinner);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.modInfo);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.RunGoose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.enabledMods);
            this.Controls.Add(this.label3);
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
            this.installedModsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox otherMods;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label3;
        private System.Windows.Forms.ListBox enabledMods;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Components.MetroStyleExtender styleExtender;
        private System.Windows.Forms.ContextMenuStrip modListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
        private MetroFramework.Controls.MetroButton RunGoose;
        private System.Windows.Forms.ToolStripMenuItem resourceHubToolStripMenuItem;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.ContextMenuStrip installedModsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ToolStripMenuItem openInModsToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.ListBox modInfo;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroProgressSpinner metroSpinner;
    }
}

