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
            this.resourceHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInModsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowedModsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.installedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.availableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new MetroFramework.Controls.MetroLabel();
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
            this.OptionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giveUsFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.forModCreatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogRichTextBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BoldToolButton = new System.Windows.Forms.ToolStripButton();
            this.ItalicToolButton = new System.Windows.Forms.ToolStripButton();
            this.UnderlineToolButton = new System.Windows.Forms.ToolStripButton();
            this.StrikeoutToolButton = new System.Windows.Forms.ToolStripButton();
            this.ActualTextSizeButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.TextSizeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NormalSizeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MediumSizeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bigSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DescriptionContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.DownloadPanel = new MetroFramework.Controls.MetroPanel();
            this.OptionsButton = new MetroFramework.Controls.MetroButton();
            this.changelogPanel = new MetroFramework.Controls.MetroPanel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.descriptionButton = new MetroFramework.Controls.MetroButton();
            this.modListContextMenu.SuspendLayout();
            this.ShowedModsMenuStrip.SuspendLayout();
            this.linksContextMenu.SuspendLayout();
            this.UtilitiesContextMenu.SuspendLayout();
            this.OptionsContextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.TextSizeMenuStrip.SuspendLayout();
            this.DescriptionContextMenu.SuspendLayout();
            this.DownloadPanel.SuspendLayout();
            this.changelogPanel.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.metroPanel5.SuspendLayout();
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
            this.resourceHubToolStripMenuItem,
            this.openInModsToolStripMenuItem1,
            this.toolStripSeparator1,
            this.showModsToolStripMenuItem});
            this.modListContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.modListContextMenu.Name = "modListContextMenu";
            this.modListContextMenu.ShowImageMargin = false;
            this.modListContextMenu.Size = new System.Drawing.Size(125, 120);
            this.modListContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.modListContextMenu_Opening);
            // 
            // installToolStripMenuItem
            // 
            this.installToolStripMenuItem.Name = "installToolStripMenuItem";
            this.installToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.installToolStripMenuItem.Text = "Install";
            this.installToolStripMenuItem.Click += new System.EventHandler(this.installToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem1
            // 
            this.disableToolStripMenuItem1.Enabled = false;
            this.disableToolStripMenuItem1.Name = "disableToolStripMenuItem1";
            this.disableToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.disableToolStripMenuItem1.Text = "Disable";
            this.disableToolStripMenuItem1.Click += new System.EventHandler(this.disableToolStripMenuItem1_Click);
            // 
            // resourceHubToolStripMenuItem
            // 
            this.resourceHubToolStripMenuItem.Name = "resourceHubToolStripMenuItem";
            this.resourceHubToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.resourceHubToolStripMenuItem.Text = "ResourceHub";
            this.resourceHubToolStripMenuItem.Click += new System.EventHandler(this.resourceHubToolStripMenuItem_Click);
            // 
            // openInModsToolStripMenuItem1
            // 
            this.openInModsToolStripMenuItem1.Enabled = false;
            this.openInModsToolStripMenuItem1.Name = "openInModsToolStripMenuItem1";
            this.openInModsToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.openInModsToolStripMenuItem1.Text = "Open in Mods";
            this.openInModsToolStripMenuItem1.Click += new System.EventHandler(this.openInModsToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // showModsToolStripMenuItem
            // 
            this.showModsToolStripMenuItem.DropDown = this.ShowedModsMenuStrip;
            this.showModsToolStripMenuItem.Name = "showModsToolStripMenuItem";
            this.showModsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.showModsToolStripMenuItem.Text = "Show Mods...";
            // 
            // ShowedModsMenuStrip
            // 
            this.styleExtender.SetApplyMetroTheme(this.ShowedModsMenuStrip, true);
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
            this.ShowedModsMenuStrip.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.ShowedModsMenuStrip_Closing);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detected mods:";
            this.label1.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            this.toolStripMenuItem8.Size = new System.Drawing.Size(141, 22);
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
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.label3.Location = new System.Drawing.Point(199, 77);
            this.label3.Name = "label3";
            this.label3.ReadOnly = true;
            this.label3.Size = new System.Drawing.Size(512, 388);
            this.label3.TabIndex = 28;
            this.label3.Text = "<m>Hover or click on the mod buttons (in list on the left) to see mod description" +
    "s.</m>\n\n<m>Click (on mod button) to see options!</m>";
            this.label3.SelectionChanged += new System.EventHandler(this.label3_SelectionChanged);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.styleExtender.SetApplyMetroTheme(this.listBox1, true);
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.Location = new System.Drawing.Point(198, 76);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(514, 390);
            this.listBox1.TabIndex = 29;
            this.listBox1.TabStop = false;
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
            this.gooseToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
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
            this.gooseToolStripMenuItem,
            this.forModCreatorsToolStripMenuItem});
            this.OptionsContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.OptionsContextMenu.Name = "modListContextMenu";
            this.OptionsContextMenu.ShowImageMargin = false;
            this.OptionsContextMenu.Size = new System.Drawing.Size(142, 136);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // giveUsFeedbackToolStripMenuItem
            // 
            this.giveUsFeedbackToolStripMenuItem.Name = "giveUsFeedbackToolStripMenuItem";
            this.giveUsFeedbackToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.giveUsFeedbackToolStripMenuItem.Text = "Give us feedback";
            this.giveUsFeedbackToolStripMenuItem.Click += new System.EventHandler(this.giveUsFeedbackToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.toolStripMenuItem7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem7.Text = "Settings";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // forModCreatorsToolStripMenuItem
            // 
            this.forModCreatorsToolStripMenuItem.Name = "forModCreatorsToolStripMenuItem";
            this.forModCreatorsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.forModCreatorsToolStripMenuItem.Text = "For Mod Creators";
            this.forModCreatorsToolStripMenuItem.Click += new System.EventHandler(this.forModCreatorsToolStripMenuItem_Click);
            // 
            // changelogRichTextBox
            // 
            this.styleExtender.SetApplyMetroTheme(this.changelogRichTextBox, true);
            this.changelogRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.changelogRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.changelogRichTextBox.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changelogRichTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.changelogRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.changelogRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.changelogRichTextBox.Name = "changelogRichTextBox";
            this.changelogRichTextBox.ReadOnly = true;
            this.changelogRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.changelogRichTextBox.Size = new System.Drawing.Size(601, 376);
            this.changelogRichTextBox.TabIndex = 2;
            this.changelogRichTextBox.Text = resources.GetString("changelogRichTextBox.Text");
            // 
            // toolStrip1
            // 
            this.styleExtender.SetApplyMetroTheme(this.toolStrip1, true);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BoldToolButton,
            this.ItalicToolButton,
            this.UnderlineToolButton,
            this.StrikeoutToolButton,
            this.ActualTextSizeButton});
            this.toolStrip1.Location = new System.Drawing.Point(497, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(178, 25);
            this.toolStrip1.TabIndex = 42;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // BoldToolButton
            // 
            this.BoldToolButton.CheckOnClick = true;
            this.BoldToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BoldToolButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BoldToolButton.Image = ((System.Drawing.Image)(resources.GetObject("BoldToolButton.Image")));
            this.BoldToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BoldToolButton.Name = "BoldToolButton";
            this.BoldToolButton.Size = new System.Drawing.Size(23, 22);
            this.BoldToolButton.Text = "B";
            this.BoldToolButton.ToolTipText = "Bold";
            this.BoldToolButton.Click += new System.EventHandler(this.BoldToolButton_Click);
            // 
            // ItalicToolButton
            // 
            this.ItalicToolButton.CheckOnClick = true;
            this.ItalicToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ItalicToolButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.ItalicToolButton.Image = ((System.Drawing.Image)(resources.GetObject("ItalicToolButton.Image")));
            this.ItalicToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItalicToolButton.Name = "ItalicToolButton";
            this.ItalicToolButton.Size = new System.Drawing.Size(23, 22);
            this.ItalicToolButton.Text = "I";
            this.ItalicToolButton.ToolTipText = "Italic";
            this.ItalicToolButton.Click += new System.EventHandler(this.ItalicToolButton_Click);
            // 
            // UnderlineToolButton
            // 
            this.UnderlineToolButton.CheckOnClick = true;
            this.UnderlineToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UnderlineToolButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.UnderlineToolButton.Image = ((System.Drawing.Image)(resources.GetObject("UnderlineToolButton.Image")));
            this.UnderlineToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UnderlineToolButton.Name = "UnderlineToolButton";
            this.UnderlineToolButton.Size = new System.Drawing.Size(23, 22);
            this.UnderlineToolButton.Text = "U";
            this.UnderlineToolButton.ToolTipText = "Underline";
            this.UnderlineToolButton.Click += new System.EventHandler(this.UnderlineToolButton_Click);
            // 
            // StrikeoutToolButton
            // 
            this.StrikeoutToolButton.CheckOnClick = true;
            this.StrikeoutToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StrikeoutToolButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout);
            this.StrikeoutToolButton.Image = ((System.Drawing.Image)(resources.GetObject("StrikeoutToolButton.Image")));
            this.StrikeoutToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StrikeoutToolButton.Name = "StrikeoutToolButton";
            this.StrikeoutToolButton.Size = new System.Drawing.Size(23, 22);
            this.StrikeoutToolButton.Text = "S";
            this.StrikeoutToolButton.ToolTipText = "Strikeout";
            this.StrikeoutToolButton.Click += new System.EventHandler(this.StrikeoutToolButton_Click);
            // 
            // ActualTextSizeButton
            // 
            this.ActualTextSizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ActualTextSizeButton.DropDown = this.TextSizeMenuStrip;
            this.ActualTextSizeButton.Image = ((System.Drawing.Image)(resources.GetObject("ActualTextSizeButton.Image")));
            this.ActualTextSizeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActualTextSizeButton.Name = "ActualTextSizeButton";
            this.ActualTextSizeButton.Size = new System.Drawing.Size(83, 22);
            this.ActualTextSizeButton.Text = "Normal Size";
            // 
            // TextSizeMenuStrip
            // 
            this.styleExtender.SetApplyMetroTheme(this.TextSizeMenuStrip, true);
            this.TextSizeMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.TextSizeMenuStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.TextSizeMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TextSizeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NormalSizeStripMenuItem,
            this.MediumSizeStripMenuItem,
            this.bigSizeToolStripMenuItem});
            this.TextSizeMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.TextSizeMenuStrip.Name = "modListContextMenu";
            this.TextSizeMenuStrip.OwnerItem = this.ActualTextSizeButton;
            this.TextSizeMenuStrip.ShowImageMargin = false;
            this.TextSizeMenuStrip.Size = new System.Drawing.Size(118, 70);
            // 
            // NormalSizeStripMenuItem
            // 
            this.NormalSizeStripMenuItem.Name = "NormalSizeStripMenuItem";
            this.NormalSizeStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.NormalSizeStripMenuItem.Text = "Normal Size";
            this.NormalSizeStripMenuItem.Click += new System.EventHandler(this.NormalSizeStripMenuItem_Click);
            // 
            // MediumSizeStripMenuItem
            // 
            this.MediumSizeStripMenuItem.Name = "MediumSizeStripMenuItem";
            this.MediumSizeStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.MediumSizeStripMenuItem.Text = "Medium Size";
            this.MediumSizeStripMenuItem.Click += new System.EventHandler(this.MediumSizeStripMenuItem_Click);
            // 
            // bigSizeToolStripMenuItem
            // 
            this.bigSizeToolStripMenuItem.Name = "bigSizeToolStripMenuItem";
            this.bigSizeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.bigSizeToolStripMenuItem.Text = "Big Size";
            this.bigSizeToolStripMenuItem.Click += new System.EventHandler(this.bigSizeToolStripMenuItem_Click);
            // 
            // DescriptionContextMenu
            // 
            this.styleExtender.SetApplyMetroTheme(this.DescriptionContextMenu, true);
            this.DescriptionContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.DescriptionContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.DescriptionContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DescriptionContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.toolStripMenuItem4});
            this.DescriptionContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.DescriptionContextMenu.Name = "modListContextMenu";
            this.DescriptionContextMenu.ShowImageMargin = false;
            this.DescriptionContextMenu.Size = new System.Drawing.Size(86, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(85, 22);
            this.toolStripMenuItem1.Text = "Save";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_2);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(85, 22);
            this.toolStripMenuItem4.Text = "Cancel";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click_1);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroProgressBar1.Location = new System.Drawing.Point(0, 35);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(374, 11);
            this.metroProgressBar1.TabIndex = 20;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel1.Location = new System.Drawing.Point(0, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(374, 35);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Installing Foobar";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.metroLabel3.Location = new System.Drawing.Point(602, 58);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(107, 15);
            this.metroLabel3.TabIndex = 27;
            this.metroLabel3.Text = "Launcher version 2.0";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel2.AutoScroll = true;
            this.metroPanel2.AutoScrollMinSize = new System.Drawing.Size(0, 481);
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.ContextMenuStrip = this.ShowedModsMenuStrip;
            this.metroPanel2.HorizontalScrollbar = true;
            this.metroPanel2.HorizontalScrollbarBarColor = false;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 6;
            this.metroPanel2.Location = new System.Drawing.Point(15, 76);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(184, 390);
            this.metroPanel2.TabIndex = 33;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.VerticalScrollbar = true;
            this.metroPanel2.VerticalScrollbarBarColor = false;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 5;
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
            this.DownloadPanel.Location = new System.Drawing.Point(176, 436);
            this.DownloadPanel.Margin = new System.Windows.Forms.Padding(2);
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
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(2);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(70, 33);
            this.OptionsButton.TabIndex = 38;
            this.OptionsButton.Text = "Utilities";
            this.OptionsButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.OptionsButton.UseSelectable = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // changelogPanel
            // 
            this.changelogPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changelogPanel.Controls.Add(this.metroLabel4);
            this.changelogPanel.Controls.Add(this.metroPanel4);
            this.changelogPanel.HorizontalScrollbarBarColor = true;
            this.changelogPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.changelogPanel.HorizontalScrollbarSize = 8;
            this.changelogPanel.Location = new System.Drawing.Point(-716, -463);
            this.changelogPanel.Margin = new System.Windows.Forms.Padding(2);
            this.changelogPanel.Name = "changelogPanel";
            this.changelogPanel.Size = new System.Drawing.Size(728, 484);
            this.changelogPanel.TabIndex = 39;
            this.changelogPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.changelogPanel.VerticalScrollbarBarColor = true;
            this.changelogPanel.VerticalScrollbarHighlightOnWheel = false;
            this.changelogPanel.VerticalScrollbarSize = 8;
            this.changelogPanel.Visible = false;
            this.changelogPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.changelogPanel_MouseDown);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(322, 16);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(105, 19);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "Click to continue";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.changelogPanel_MouseDown);
            // 
            // metroPanel4
            // 
            this.metroPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel4.Controls.Add(this.metroLabel2);
            this.metroPanel4.Controls.Add(this.metroPanel5);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 8;
            this.metroPanel4.Location = new System.Drawing.Point(56, 57);
            this.metroPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(616, 367);
            this.metroPanel4.TabIndex = 2;
            this.metroPanel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 8;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(266, 0);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(108, 25);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Changelog:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroPanel5
            // 
            this.metroPanel5.AutoScroll = true;
            this.metroPanel5.Controls.Add(this.changelogRichTextBox);
            this.metroPanel5.HorizontalScrollbar = true;
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 8;
            this.metroPanel5.Location = new System.Drawing.Point(0, 37);
            this.metroPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(612, 325);
            this.metroPanel5.TabIndex = 4;
            this.metroPanel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel5.VerticalScrollbar = true;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 8;
            // 
            // descriptionButton
            // 
            this.descriptionButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.descriptionButton.Location = new System.Drawing.Point(345, 20);
            this.descriptionButton.Margin = new System.Windows.Forms.Padding(2);
            this.descriptionButton.Name = "descriptionButton";
            this.descriptionButton.Size = new System.Drawing.Size(128, 33);
            this.descriptionButton.TabIndex = 41;
            this.descriptionButton.Text = "Description Making";
            this.descriptionButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.descriptionButton.UseSelectable = true;
            this.descriptionButton.Visible = false;
            this.descriptionButton.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 481);
            this.ClientSize = new System.Drawing.Size(728, 484);
            this.Controls.Add(this.changelogPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.descriptionButton);
            this.Controls.Add(this.DownloadPanel);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(728, 484);
            this.Name = "MainForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "ResourceHub Launcher";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Ivory;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.modListContextMenu.ResumeLayout(false);
            this.ShowedModsMenuStrip.ResumeLayout(false);
            this.linksContextMenu.ResumeLayout(false);
            this.UtilitiesContextMenu.ResumeLayout(false);
            this.OptionsContextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.TextSizeMenuStrip.ResumeLayout(false);
            this.DescriptionContextMenu.ResumeLayout(false);
            this.DownloadPanel.ResumeLayout(false);
            this.changelogPanel.ResumeLayout(false);
            this.changelogPanel.PerformLayout();
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.metroPanel5.ResumeLayout(false);
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
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.ContextMenuStrip linksContextMenu;
        private System.Windows.Forms.RichTextBox label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
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
        private MetroFramework.Controls.MetroPanel changelogPanel;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private System.Windows.Forms.RichTextBox changelogRichTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openInModsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showModsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ShowedModsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem installedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem availableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forModCreatorsToolStripMenuItem;
        private MetroFramework.Controls.MetroButton descriptionButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BoldToolButton;
        private System.Windows.Forms.ToolStripButton ItalicToolButton;
        private System.Windows.Forms.ToolStripButton UnderlineToolButton;
        private System.Windows.Forms.ToolStripButton StrikeoutToolButton;
        private System.Windows.Forms.ContextMenuStrip DescriptionContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripDropDownButton ActualTextSizeButton;
        private System.Windows.Forms.ContextMenuStrip TextSizeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NormalSizeStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MediumSizeStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bigSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
    }
}