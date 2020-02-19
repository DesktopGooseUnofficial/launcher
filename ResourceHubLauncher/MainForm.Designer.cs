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
            this.NonInstalled = new System.Windows.Forms.ListBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.VersionLabel = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.Installed = new System.Windows.Forms.ListBox();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.Disabled = new System.Windows.Forms.ListBox();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.Install = new MetroFramework.Controls.MetroButton();
            this.Uninstall = new MetroFramework.Controls.MetroButton();
            this.ResourceHubPage = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.RunGooseButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // NonInstalled
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.NonInstalled, true);
            this.NonInstalled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NonInstalled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NonInstalled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NonInstalled.FormattingEnabled = true;
            this.NonInstalled.IntegralHeight = false;
            this.NonInstalled.Location = new System.Drawing.Point(11, 37);
            this.NonInstalled.Margin = new System.Windows.Forms.Padding(2);
            this.NonInstalled.Name = "NonInstalled";
            this.NonInstalled.Size = new System.Drawing.Size(171, 173);
            this.NonInstalled.TabIndex = 0;
            this.NonInstalled.TabStop = false;
            this.NonInstalled.SelectedIndexChanged += new System.EventHandler(this.NonInstalled_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Non-installed mods:";
            this.label1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(428, 348);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(171, 19);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "ResourceHub Launcher 0.1.0";
            this.VersionLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(196, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 174);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mod description";
            this.label3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Installed
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.Installed, true);
            this.Installed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Installed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Installed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Installed.FormattingEnabled = true;
            this.Installed.IntegralHeight = false;
            this.Installed.Location = new System.Drawing.Point(11, 233);
            this.Installed.Margin = new System.Windows.Forms.Padding(2);
            this.Installed.Name = "Installed";
            this.Installed.Size = new System.Drawing.Size(171, 134);
            this.Installed.TabIndex = 4;
            this.Installed.TabStop = false;
            this.Installed.SelectedIndexChanged += new System.EventHandler(this.Installed_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 212);
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
            this.label5.Location = new System.Drawing.Point(196, 212);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Disabled mods:";
            this.label5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Disabled
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this.Disabled, true);
            this.Disabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Disabled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Disabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Disabled.FormattingEnabled = true;
            this.Disabled.IntegralHeight = false;
            this.Disabled.Location = new System.Drawing.Point(196, 233);
            this.Disabled.Margin = new System.Windows.Forms.Padding(2);
            this.Disabled.Name = "Disabled";
            this.Disabled.Size = new System.Drawing.Size(171, 134);
            this.Disabled.TabIndex = 7;
            this.Disabled.TabStop = false;
            this.Disabled.SelectedIndexChanged += new System.EventHandler(this.Disabled_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mod description:";
            this.label6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Install
            // 
            this.Install.Location = new System.Drawing.Point(381, 233);
            this.Install.Margin = new System.Windows.Forms.Padding(2);
            this.Install.Name = "Install";
            this.Install.Size = new System.Drawing.Size(218, 21);
            this.Install.TabIndex = 9;
            this.Install.TabStop = false;
            this.Install.Text = "Install mod";
            this.Install.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Install.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Uninstall
            // 
            this.Uninstall.Location = new System.Drawing.Point(381, 258);
            this.Uninstall.Margin = new System.Windows.Forms.Padding(2);
            this.Uninstall.Name = "Uninstall";
            this.Uninstall.Size = new System.Drawing.Size(218, 21);
            this.Uninstall.TabIndex = 11;
            this.Uninstall.TabStop = false;
            this.Uninstall.Text = "Uninstall mod";
            this.Uninstall.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Uninstall.Click += new System.EventHandler(this.Uninstall_Click);
            // 
            // ResourceHubPage
            // 
            this.ResourceHubPage.Location = new System.Drawing.Point(381, 325);
            this.ResourceHubPage.Margin = new System.Windows.Forms.Padding(2);
            this.ResourceHubPage.Name = "ResourceHubPage";
            this.ResourceHubPage.Size = new System.Drawing.Size(218, 21);
            this.ResourceHubPage.TabIndex = 13;
            this.ResourceHubPage.TabStop = false;
            this.ResourceHubPage.Text = "Open ResourceHub page";
            this.ResourceHubPage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResourceHubPage.Click += new System.EventHandler(this.ResourceHubPage_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // RunGooseButton
            // 
            this.RunGooseButton.Location = new System.Drawing.Point(381, 283);
            this.RunGooseButton.Margin = new System.Windows.Forms.Padding(2);
            this.RunGooseButton.Name = "RunGooseButton";
            this.RunGooseButton.Size = new System.Drawing.Size(218, 21);
            this.RunGooseButton.TabIndex = 14;
            this.RunGooseButton.TabStop = false;
            this.RunGooseButton.Text = "Run Goose";
            this.RunGooseButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 380);
            this.Controls.Add(this.RunGooseButton);
            this.Controls.Add(this.ResourceHubPage);
            this.Controls.Add(this.Uninstall);
            this.Controls.Add(this.Install);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Disabled);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Installed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NonInstalled);
            this.DisplayHeader = false;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "ResourceHub Launcher";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox NonInstalled;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel VersionLabel;
        private MetroFramework.Controls.MetroLabel label3;
        private System.Windows.Forms.ListBox Installed;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel label5;
        private System.Windows.Forms.ListBox Disabled;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Controls.MetroButton Install;
        private MetroFramework.Controls.MetroButton Uninstall;
        private MetroFramework.Controls.MetroButton ResourceHubPage;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Controls.MetroButton RunGooseButton;
    }
}

