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
            this.enabledMods = new System.Windows.Forms.ListBox();
            this.installedModsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.styleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.modInfo = new System.Windows.Forms.ListBox();
            this.linksContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.modListContextMenu.SuspendLayout();
            this.installedModsContextMenu.SuspendLayout();
            this.linksContextMenu.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // otherMods
            // 
            this.otherMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.styleExtender.SetApplyMetroTheme(this.otherMods, true);
            this.otherMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.otherMods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.otherMods.ContextMenuStrip = this.modListContextMenu;
            this.otherMods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.otherMods.FormattingEnabled = true;
            this.otherMods.IntegralHeight = false;
            this.otherMods.ItemHeight = 16;
            this.otherMods.Location = new System.Drawing.Point(27, 94);
            this.otherMods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.otherMods.Name = "otherMods";
            this.otherMods.Size = new System.Drawing.Size(226, 313);
            this.otherMods.TabIndex = 0;
            this.otherMods.TabStop = false;
            this.otherMods.SelectedIndexChanged += new System.EventHandler(this.otherMods_SelectedIndexChanged);
            // 
            // modListContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.modListContextMenu, true);
            this.modListContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.modListContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.modListContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.modListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installToolStripMenuItem,
            this.resourceHubToolStripMenuItem});
            this.modListContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.modListContextMenu.Name = "modListContextMenu";
            this.modListContextMenu.ShowImageMargin = false;
            this.modListContextMenu.Size = new System.Drawing.Size(142, 52);
            this.modListContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.modListContextMenu_Opening);
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.installToolStripMenuItem.Text = "Install";
            this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
            // 
            // resourceHubToolStripMenuItem
            // 
            this.resourceHubToolStripMenuItem.Name = "resourceHubToolStripMenuItem";
            this.resourceHubToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.resourceHubToolStripMenuItem.Text = "ResourceHub";
            this.resourceHubToolStripMenuItem.Click += new System.EventHandler(this.resourceHubToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available mods:";
            this.label1.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            this.enabledMods.ItemHeight = 16;
            this.enabledMods.Location = new System.Drawing.Point(260, 437);
            this.enabledMods.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enabledMods.Name = "enabledMods";
            this.enabledMods.Size = new System.Drawing.Size(226, 134);
            this.enabledMods.TabIndex = 4;
            this.enabledMods.TabStop = false;
            // 
            // installedModsContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.installedModsContextMenu, true);
            this.installedModsContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.installedModsContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.installedModsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.installedModsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.openInModsToolStripMenuItem});
            this.installedModsContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.installedModsContextMenu.Name = "modListContextMenu";
            this.installedModsContextMenu.ShowImageMargin = false;
            this.installedModsContextMenu.Size = new System.Drawing.Size(147, 52);
            this.installedModsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.installedModsContextMenu_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 24);
            this.toolStripMenuItem1.Text = "Uninstall";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // openInModsToolStripMenuItem
            // 
            this.openInModsToolStripMenuItem.Name = "openInModsToolStripMenuItem";
            this.openInModsToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.openInModsToolStripMenuItem.Text = "Open in Mods";
            this.openInModsToolStripMenuItem.Click += new System.EventHandler(this.openInModsToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Installed mods:";
            this.label4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
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
            this.modInfo.ItemHeight = 16;
            this.modInfo.Items.AddRange(new object[] {
            "Category:",
            "Rating:"});
            this.modInfo.Location = new System.Drawing.Point(717, 437);
            this.modInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modInfo.Name = "modInfo";
            this.modInfo.Size = new System.Drawing.Size(226, 134);
            this.modInfo.TabIndex = 22;
            this.modInfo.TabStop = false;
            // 
            // linksContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.linksContextMenu, true);
            this.linksContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.linksContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.linksContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.linksContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.githubToolStripMenuItem,
            this.discordToolStripMenuItem});
            this.linksContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.linksContextMenu.Name = "modListContextMenu";
            this.linksContextMenu.ShowImageMargin = false;
            this.linksContextMenu.Size = new System.Drawing.Size(105, 52);
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.githubToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.githubToolStripMenuItem.Text = "Github";
            this.githubToolStripMenuItem.Click += new System.EventHandler(this.githubToolStripMenuItem_Click_1);
            // 
            // discordToolStripMenuItem
            // 
            this.discordToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.discordToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            this.discordToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.discordToolStripMenuItem.Text = "Discord";
            this.discordToolStripMenuItem.Click += new System.EventHandler(this.discordToolStripMenuItem_Click_1);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.styleExtender.SetApplyMetroTheme(this.label3, true);
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label3.Location = new System.Drawing.Point(260, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.label3.Name = "label3";
            this.label3.ReadOnly = true;
            this.label3.Size = new System.Drawing.Size(683, 311);
            this.label3.TabIndex = 28;
            this.label3.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.styleExtender.SetApplyMetroTheme(this.listBox1, true);
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ContextMenuStrip = this.modListContextMenu;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(259, 94);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(685, 313);
            this.listBox1.TabIndex = 29;
            this.listBox1.TabStop = false;
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroProgressBar1.Location = new System.Drawing.Point(27, 557);
            this.metroProgressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(917, 14);
            this.metroProgressBar1.TabIndex = 20;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressBar1.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(490, 533);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(109, 20);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Installing Foobar";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.Visible = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(712, 410);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(67, 20);
            this.metroLabel2.TabIndex = 23;
            this.metroLabel2.Text = "Mod Info:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton6
            // 
            this.metroButton6.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton6.Location = new System.Drawing.Point(231, 95);
            this.metroButton6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(21, 20);
            this.metroButton6.TabIndex = 25;
            this.metroButton6.Text = "↻";
            this.metroButton6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton6.UseSelectable = true;
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(824, 75);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(120, 17);
            this.metroLabel3.TabIndex = 27;
            this.metroLabel3.Text = "Launcher version 1.3";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(3, 32);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(101, 28);
            this.metroButton1.TabIndex = 30;
            this.metroButton1.Text = "Settings";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(3, 2);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(101, 28);
            this.metroButton2.TabIndex = 31;
            this.metroButton2.Text = "Links";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click_1);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroButton2);
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(604, 508);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(107, 63);
            this.metroPanel1.TabIndex = 32;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // metroPanel2
            // 
            this.metroPanel2.AutoScroll = true;
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.HorizontalScrollbar = true;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(15, 94);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(238, 443);
            this.metroPanel2.TabIndex = 33;
            this.metroPanel2.VerticalScrollbar = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 596);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.modInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.enabledMods);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.otherMods);
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "ResourceHub Launcher";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Ivory;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.modListContextMenu.ResumeLayout(false);
            this.installedModsContextMenu.ResumeLayout(false);
            this.linksContextMenu.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox otherMods;
        private MetroFramework.Controls.MetroLabel label1;
        private System.Windows.Forms.ListBox enabledMods;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Components.MetroStyleExtender styleExtender;
        private System.Windows.Forms.ContextMenuStrip modListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourceHubToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip installedModsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ToolStripMenuItem openInModsToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.ListBox modInfo;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ContextMenuStrip linksContextMenu;
        private System.Windows.Forms.RichTextBox label3;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
    }
}

