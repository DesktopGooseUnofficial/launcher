﻿namespace ResourceHubLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.modListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.installedModsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openInModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.styleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.linksContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.futureOfTheLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.UtilitiesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.gooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledModsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.giveUsFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.resizingPanel = new MetroFramework.Controls.MetroPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DownloadPanel = new MetroFramework.Controls.MetroPanel();
            this.OptionsButton = new MetroFramework.Controls.MetroButton();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modListContextMenu.SuspendLayout();
            this.installedModsContextMenu.SuspendLayout();
            this.linksContextMenu.SuspendLayout();
            this.UtilitiesContextMenu.SuspendLayout();
            this.disabledModsContextMenu.SuspendLayout();
            this.OptionsContextMenu.SuspendLayout();
            this.resizingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.DownloadPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.modListContextMenu.Size = new System.Drawing.Size(121, 48);
            this.modListContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.modListContextMenu_Opening);
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
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available mods:";
            this.label1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // installedModsContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.installedModsContextMenu, true);
            this.installedModsContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.installedModsContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.installedModsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.installedModsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.openInModsToolStripMenuItem,
            this.disableToolStripMenuItem});
            this.installedModsContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.installedModsContextMenu.Name = "modListContextMenu";
            this.installedModsContextMenu.ShowImageMargin = false;
            this.installedModsContextMenu.Size = new System.Drawing.Size(125, 70);
            this.installedModsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.installedModsContextMenu_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "Uninstall";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // openInModsToolStripMenuItem
            // 
            this.openInModsToolStripMenuItem.Name = "openInModsToolStripMenuItem";
            this.openInModsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openInModsToolStripMenuItem.Text = "Disable";
            this.openInModsToolStripMenuItem.Click += new System.EventHandler(this.openInModsToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.disableToolStripMenuItem.Text = "Open in Mods";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 55);
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
            // linksContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.linksContextMenu, true);
            this.linksContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.linksContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.linksContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.linksContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.githubToolStripMenuItem,
            this.discordToolStripMenuItem,
            this.twitterToolStripMenuItem,
            this.futureOfTheLauncherToolStripMenuItem});
            this.linksContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.linksContextMenu.Name = "modListContextMenu";
            this.linksContextMenu.ShowImageMargin = false;
            this.linksContextMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.githubToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.githubToolStripMenuItem.Text = "GitHub";
            this.githubToolStripMenuItem.Click += new System.EventHandler(this.githubToolStripMenuItem_Click_1);
            // 
            // discordToolStripMenuItem
            // 
            this.discordToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.discordToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            this.discordToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.discordToolStripMenuItem.Text = "Discord";
            this.discordToolStripMenuItem.Click += new System.EventHandler(this.discordToolStripMenuItem_Click_1);
            // 
            // twitterToolStripMenuItem
            // 
            this.twitterToolStripMenuItem.Name = "twitterToolStripMenuItem";
            this.twitterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.twitterToolStripMenuItem.Text = "Twitter";
            this.twitterToolStripMenuItem.Click += new System.EventHandler(this.twitterToolStripMenuItem_Click);
            // 
            // futureOfTheLauncherToolStripMenuItem
            // 
            this.futureOfTheLauncherToolStripMenuItem.Name = "futureOfTheLauncherToolStripMenuItem";
            this.futureOfTheLauncherToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.futureOfTheLauncherToolStripMenuItem.Text = "Upcoming Features";
            this.futureOfTheLauncherToolStripMenuItem.Click += new System.EventHandler(this.futureOfTheLauncherToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.toolStripMenuItem8.DropDown = this.linksContextMenu;
            this.toolStripMenuItem8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem8.Text = "Links";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.styleExtender.SetApplyMetroTheme(this.label3, true);
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label3.Location = new System.Drawing.Point(199, 77);
            this.label3.Name = "label3";
            this.label3.ReadOnly = true;
            this.label3.Size = new System.Drawing.Size(512, 389);
            this.label3.TabIndex = 28;
            this.label3.Text = "Hover or click on the mod buttons (in list on the left) to see mod descriptions a" +
    "nd options!";
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
            this.listBox1.Location = new System.Drawing.Point(198, 76);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(514, 391);
            this.listBox1.TabIndex = 29;
            this.listBox1.TabStop = false;
            this.listBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseUp);
            // 
            // UtilitiesContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.UtilitiesContextMenu, true);
            this.UtilitiesContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.UtilitiesContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.UtilitiesContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.UtilitiesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.UtilitiesContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.UtilitiesContextMenu.Name = "modListContextMenu";
            this.UtilitiesContextMenu.ShowImageMargin = false;
            this.UtilitiesContextMenu.Size = new System.Drawing.Size(74, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(73, 22);
            this.toolStripMenuItem2.Text = "Run";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(73, 22);
            this.toolStripMenuItem3.Text = "Stop";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // gooseToolStripMenuItem
            // 
            this.gooseToolStripMenuItem.DropDown = this.UtilitiesContextMenu;
            this.gooseToolStripMenuItem.Name = "gooseToolStripMenuItem";
            this.gooseToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.gooseToolStripMenuItem.Text = "Goose";
            // 
            // disabledModsContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.disabledModsContextMenu, true);
            this.disabledModsContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.disabledModsContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.disabledModsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.disabledModsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.disabledModsContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.disabledModsContextMenu.Name = "modListContextMenu";
            this.disabledModsContextMenu.ShowImageMargin = false;
            this.disabledModsContextMenu.Size = new System.Drawing.Size(125, 70);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem4.Text = "Uninstall";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem5.Text = "Enable";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem6.Text = "Open in Mods";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // OptionsContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.OptionsContextMenu, true);
            this.OptionsContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.OptionsContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.OptionsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.OptionsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.giveUsFeedbackToolStripMenuItem,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.gooseToolStripMenuItem});
            this.OptionsContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.OptionsContextMenu.Name = "modListContextMenu";
            this.OptionsContextMenu.ShowImageMargin = false;
            this.OptionsContextMenu.Size = new System.Drawing.Size(156, 136);
            // 
            // giveUsFeedbackToolStripMenuItem
            // 
            this.giveUsFeedbackToolStripMenuItem.Name = "giveUsFeedbackToolStripMenuItem";
            this.giveUsFeedbackToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.giveUsFeedbackToolStripMenuItem.Text = "Give us feedback";
            this.giveUsFeedbackToolStripMenuItem.Click += new System.EventHandler(this.giveUsFeedbackToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.toolStripMenuItem7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem7.Text = "Settings";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroProgressBar1.Location = new System.Drawing.Point(3, 28);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(368, 11);
            this.metroProgressBar1.TabIndex = 20;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(147, 8);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(106, 19);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Installing Foobar";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton6
            // 
            this.metroButton6.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton6.Location = new System.Drawing.Point(177, 77);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(16, 16);
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
            this.metroLabel3.Location = new System.Drawing.Point(576, 58);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(137, 15);
            this.metroLabel3.TabIndex = 27;
            this.metroLabel3.Text = "Launcher version 2.0 (DEV)";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel2.AutoScroll = true;
            this.metroPanel2.AutoScrollMinSize = new System.Drawing.Size(0, 481);
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.HorizontalScrollbar = true;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 6;
            this.metroPanel2.Location = new System.Drawing.Point(15, 76);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(184, 391);
            this.metroPanel2.TabIndex = 33;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.VerticalScrollbar = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 5;
            this.metroPanel2.SizeChanged += new System.EventHandler(this.metroPanel2_SizeChanged);
            // 
            // resizingPanel
            // 
            this.resizingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.resizingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resizingPanel.Controls.Add(this.pictureBox2);
            this.resizingPanel.HorizontalScrollbarBarColor = true;
            this.resizingPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.resizingPanel.HorizontalScrollbarSize = 8;
            this.resizingPanel.Location = new System.Drawing.Point(15, 76);
            this.resizingPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resizingPanel.Name = "resizingPanel";
            this.resizingPanel.Size = new System.Drawing.Size(179, 391);
            this.resizingPanel.TabIndex = 35;
            this.resizingPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.resizingPanel.VerticalScrollbarBarColor = true;
            this.resizingPanel.VerticalScrollbarHighlightOnWheel = false;
            this.resizingPanel.VerticalScrollbarSize = 8;
            this.resizingPanel.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.InitialImage = global::ResourceHubLauncher.Properties.Resources.RHLTSmall;
            this.pictureBox2.Location = new System.Drawing.Point(52, 154);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // DownloadPanel
            // 
            this.DownloadPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DownloadPanel.Controls.Add(this.metroLabel1);
            this.DownloadPanel.Controls.Add(this.metroProgressBar1);
            this.DownloadPanel.HorizontalScrollbarBarColor = true;
            this.DownloadPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.DownloadPanel.HorizontalScrollbarSize = 8;
            this.DownloadPanel.Location = new System.Drawing.Point(176, 437);
            this.DownloadPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DownloadPanel.Name = "DownloadPanel";
            this.DownloadPanel.Size = new System.Drawing.Size(376, 48);
            this.DownloadPanel.TabIndex = 36;
            this.DownloadPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.DownloadPanel.VerticalScrollbarBarColor = true;
            this.DownloadPanel.VerticalScrollbarHighlightOnWheel = false;
            this.DownloadPanel.VerticalScrollbarSize = 8;
            this.DownloadPanel.Visible = false;
            // 
            // OptionsButton
            // 
            this.OptionsButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.OptionsButton.Location = new System.Drawing.Point(271, 20);
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(70, 33);
            this.OptionsButton.TabIndex = 38;
            this.OptionsButton.Text = "Utilities";
            this.OptionsButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.OptionsButton.UseSelectable = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 481);
            this.ClientSize = new System.Drawing.Size(728, 484);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.DownloadPanel);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resizingPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(728, 484);
            this.Name = "MainForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "ResourceHub Launcher";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Ivory;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.modListContextMenu.ResumeLayout(false);
            this.installedModsContextMenu.ResumeLayout(false);
            this.linksContextMenu.ResumeLayout(false);
            this.UtilitiesContextMenu.ResumeLayout(false);
            this.disabledModsContextMenu.ResumeLayout(false);
            this.OptionsContextMenu.ResumeLayout(false);
            this.resizingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.DownloadPanel.ResumeLayout(false);
            this.DownloadPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel label1;
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
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ContextMenuStrip linksContextMenu;
        private System.Windows.Forms.RichTextBox label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroPanel resizingPanel;
        private MetroFramework.Controls.MetroPanel DownloadPanel;
        private System.Windows.Forms.ContextMenuStrip UtilitiesContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip disabledModsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripMenuItem;
        private MetroFramework.Controls.MetroButton OptionsButton;
        private System.Windows.Forms.ContextMenuStrip OptionsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem gooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem futureOfTheLauncherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giveUsFeedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

