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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.modListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.configureModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInModsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowedModsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.installedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.availableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.linksContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.futureOfTheLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.UtilitiesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.gooseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.debugButton = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.RichTextBox();
            this.modListContextMenu.SuspendLayout();
            this.ShowedModsMenuStrip.SuspendLayout();
            this.linksContextMenu.SuspendLayout();
            this.UtilitiesContextMenu.SuspendLayout();
            this.OptionsContextMenu.SuspendLayout();
            this.resizingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.DownloadPanel.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.disableToolStripMenuItem1,
            this.configureModToolStripMenuItem,
            this.resourceHubToolStripMenuItem,
            this.openInModsToolStripMenuItem1,
            this.toolStripSeparator1,
            this.showModsToolStripMenuItem});
            this.modListContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.modListContextMenu.Name = "modListContextMenu";
            this.modListContextMenu.ShowImageMargin = false;
            this.modListContextMenu.Size = new System.Drawing.Size(131, 142);
            this.modListContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.modListContextMenu_Opening);
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.installToolStripMenuItem.Text = "Install";
            this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem1
            // 
            this.disableToolStripMenuItem1.Enabled = false;
            this.disableToolStripMenuItem1.Name = "disableToolStripMenuItem1";
            this.disableToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.disableToolStripMenuItem1.Text = "Disable";
            this.disableToolStripMenuItem1.Click += new System.EventHandler(this.disableToolStripMenuItem1_Click);
            // 
            // configureModToolStripMenuItem
            // 
            this.configureModToolStripMenuItem.Enabled = false;
            this.configureModToolStripMenuItem.Name = "configureModToolStripMenuItem";
            this.configureModToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.configureModToolStripMenuItem.Text = "Configure Mod";
            this.configureModToolStripMenuItem.Click += new System.EventHandler(this.configureModToolStripMenuItem_Click);
            // 
            // resourceHubToolStripMenuItem
            // 
            this.resourceHubToolStripMenuItem.Name = "resourceHubToolStripMenuItem";
            this.resourceHubToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.resourceHubToolStripMenuItem.Text = "ResourceHub";
            this.resourceHubToolStripMenuItem.Click += new System.EventHandler(this.resourceHubToolStripMenuItem_Click);
            // 
            // openInModsToolStripMenuItem1
            // 
            this.openInModsToolStripMenuItem1.Enabled = false;
            this.openInModsToolStripMenuItem1.Name = "openInModsToolStripMenuItem1";
            this.openInModsToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.openInModsToolStripMenuItem1.Text = "Open in Mods";
            this.openInModsToolStripMenuItem1.Click += new System.EventHandler(this.openInModsToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // showModsToolStripMenuItem
            // 
            this.showModsToolStripMenuItem.DropDown = this.ShowedModsMenuStrip;
            this.showModsToolStripMenuItem.Name = "showModsToolStripMenuItem";
            this.showModsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.showModsToolStripMenuItem.Text = "Show Mods...";
            // 
            // ShowedModsMenuStrip
            // 
            this.styleExtender.SetApplyMetroTheme(this.ShowedModsMenuStrip, true);
            this.ShowedModsMenuStrip.AutoClose = false;
            this.ShowedModsMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ShowedModsMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.ShowedModsMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ShowedModsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installedToolStripMenuItem,
            this.disabledToolStripMenuItem,
            this.availableToolStripMenuItem});
            this.ShowedModsMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.ShowedModsMenuStrip.Name = "modListContextMenu";
            this.ShowedModsMenuStrip.OwnerItem = this.showModsToolStripMenuItem;
            this.ShowedModsMenuStrip.ShowImageMargin = false;
            this.ShowedModsMenuStrip.Size = new System.Drawing.Size(163, 70);
            // 
            // installedToolStripMenuItem
            // 
            this.installedToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.installedToolStripMenuItem.Checked = true;
            this.installedToolStripMenuItem.CheckOnClick = true;
            this.installedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.installedToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.installedToolStripMenuItem.Name = "installedToolStripMenuItem";
            this.installedToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.installedToolStripMenuItem.Text = "Show Installed Mods";
            this.installedToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.disabledToolStripMenuItem.Checked = true;
            this.disabledToolStripMenuItem.CheckOnClick = true;
            this.disabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disabledToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.disabledToolStripMenuItem.Text = "Show Disabled Mods";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.disabledToolStripMenuItem_Click);
            // 
            // availableToolStripMenuItem
            // 
            this.availableToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.availableToolStripMenuItem.Checked = true;
            this.availableToolStripMenuItem.CheckOnClick = true;
            this.availableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.availableToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.availableToolStripMenuItem.Name = "availableToolStripMenuItem";
            this.availableToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.availableToolStripMenuItem.Text = "Show Available Mods";
            this.availableToolStripMenuItem.Click += new System.EventHandler(this.availableToolStripMenuItem_Click);
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
            this.linksContextMenu.OwnerItem = this.toolStripMenuItem8;
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
            this.toolStripMenuItem8.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem8.Text = "Links";
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
            this.UtilitiesContextMenu.OwnerItem = this.gooseToolStripMenuItem;
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
            this.gooseToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.gooseToolStripMenuItem.Text = "Goose";
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
            this.OptionsContextMenu.Size = new System.Drawing.Size(139, 114);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // giveUsFeedbackToolStripMenuItem
            // 
            this.giveUsFeedbackToolStripMenuItem.Name = "giveUsFeedbackToolStripMenuItem";
            this.giveUsFeedbackToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.giveUsFeedbackToolStripMenuItem.Text = "Give us feedback";
            this.giveUsFeedbackToolStripMenuItem.Click += new System.EventHandler(this.giveUsFeedbackToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.toolStripMenuItem7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem7.Text = "Settings";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroProgressBar1.Location = new System.Drawing.Point(0, 35);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(833, 11);
            this.metroProgressBar1.TabIndex = 20;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(363, 8);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(106, 19);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Installing Foobar";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton6
            // 
            this.metroButton6.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton6.Location = new System.Drawing.Point(185, 62);
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
            this.metroLabel3.Location = new System.Drawing.Point(718, 25);
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
            this.metroPanel2.AutoScrollMinSize = new System.Drawing.Size(0, 400);
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.ContextMenuStrip = this.ShowedModsMenuStrip;
            this.metroPanel2.HorizontalScrollbar = true;
            this.metroPanel2.HorizontalScrollbarBarColor = false;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 6;
            this.metroPanel2.Location = new System.Drawing.Point(20, 60);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(182, 437);
            this.metroPanel2.TabIndex = 33;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.VerticalScrollbar = true;
            this.metroPanel2.VerticalScrollbarBarColor = false;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 5;
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
            this.resizingPanel.Location = new System.Drawing.Point(20, 60);
            this.resizingPanel.Margin = new System.Windows.Forms.Padding(2);
            this.resizingPanel.Name = "resizingPanel";
            this.resizingPanel.Size = new System.Drawing.Size(182, 437);
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
            this.pictureBox2.Location = new System.Drawing.Point(53, 396);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // DownloadPanel
            // 
            this.DownloadPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DownloadPanel.Controls.Add(this.metroLabel1);
            this.DownloadPanel.Controls.Add(this.metroProgressBar1);
            this.DownloadPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DownloadPanel.HorizontalScrollbarBarColor = true;
            this.DownloadPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.DownloadPanel.HorizontalScrollbarSize = 8;
            this.DownloadPanel.Location = new System.Drawing.Point(20, 499);
            this.DownloadPanel.Margin = new System.Windows.Forms.Padding(2);
            this.DownloadPanel.Name = "DownloadPanel";
            this.DownloadPanel.Size = new System.Drawing.Size(835, 48);
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
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(2);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(70, 33);
            this.OptionsButton.TabIndex = 38;
            this.OptionsButton.Text = "Utilities";
            this.OptionsButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.OptionsButton.UseSelectable = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(372, 20);
            this.debugButton.Margin = new System.Windows.Forms.Padding(2);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(179, 33);
            this.debugButton.TabIndex = 41;
            this.debugButton.Text = "debug";
            this.debugButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.debugButton.UseSelectable = true;
            this.debugButton.Visible = false;
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(204, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 437);
            this.panel1.TabIndex = 43;
            // 
            // label3
            // 
            this.styleExtender.SetApplyMetroTheme(this.label3, true);
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.ReadOnly = true;
            this.label3.Size = new System.Drawing.Size(649, 435);
            this.label3.TabIndex = 43;
            this.label3.Text = "<m>Hover or click on the mod buttons (in list on the left) to see mod description" +
    "s.</m>\n\n<m>Click (on mod button) to see options!</m>\n";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(875, 567);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.debugButton);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.resizingPanel);
            this.Controls.Add(this.DownloadPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(728, 484);
            this.Name = "MainForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "ResourceHub Launcher";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.modListContextMenu.ResumeLayout(false);
            this.ShowedModsMenuStrip.ResumeLayout(false);
            this.linksContextMenu.ResumeLayout(false);
            this.UtilitiesContextMenu.ResumeLayout(false);
            this.OptionsContextMenu.ResumeLayout(false);
            this.resizingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.DownloadPanel.ResumeLayout(false);
            this.DownloadPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroStyleExtender styleExtender;
        private System.Windows.Forms.ContextMenuStrip modListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourceHubToolStripMenuItem;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ContextMenuStrip linksContextMenu;
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
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripMenuItem;
        private MetroFramework.Controls.MetroButton OptionsButton;
        private System.Windows.Forms.ContextMenuStrip OptionsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem gooseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem futureOfTheLauncherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giveUsFeedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private MetroFramework.Controls.MetroButton debugButton;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openInModsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configureModToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showModsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ShowedModsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem installedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem availableToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox label3;
    }
}