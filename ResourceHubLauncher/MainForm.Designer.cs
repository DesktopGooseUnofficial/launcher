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
            this.NonInstalled = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Installed = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Disabled = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Install = new System.Windows.Forms.Button();
            this.Enable = new System.Windows.Forms.Button();
            this.Uninstall = new System.Windows.Forms.Button();
            this.Disable = new System.Windows.Forms.Button();
            this.ResourceHubPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NonInstalled
            // 
            this.NonInstalled.FormattingEnabled = true;
            this.NonInstalled.Location = new System.Drawing.Point(11, 24);
            this.NonInstalled.Margin = new System.Windows.Forms.Padding(2);
            this.NonInstalled.Name = "NonInstalled";
            this.NonInstalled.Size = new System.Drawing.Size(171, 173);
            this.NonInstalled.TabIndex = 0;
            this.NonInstalled.SelectedIndexChanged += new System.EventHandler(this.NonInstalled_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Non Installed Mods:";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(441, 344);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(148, 13);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "ResourceHub Launcher 0.1.0";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(198, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(391, 174);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mod Description";
            // 
            // Installed
            // 
            this.Installed.FormattingEnabled = true;
            this.Installed.Location = new System.Drawing.Point(11, 221);
            this.Installed.Margin = new System.Windows.Forms.Padding(2);
            this.Installed.Name = "Installed";
            this.Installed.Size = new System.Drawing.Size(171, 134);
            this.Installed.TabIndex = 4;
            this.Installed.SelectedIndexChanged += new System.EventHandler(this.Installed_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 205);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Installed Mods:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Disabled Mods:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Disabled
            // 
            this.Disabled.FormattingEnabled = true;
            this.Disabled.Location = new System.Drawing.Point(198, 221);
            this.Disabled.Margin = new System.Windows.Forms.Padding(2);
            this.Disabled.Name = "Disabled";
            this.Disabled.Size = new System.Drawing.Size(171, 134);
            this.Disabled.TabIndex = 7;
            this.Disabled.SelectedIndexChanged += new System.EventHandler(this.Disabled_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mod Description:";
            // 
            // Install
            // 
            this.Install.Location = new System.Drawing.Point(373, 221);
            this.Install.Margin = new System.Windows.Forms.Padding(2);
            this.Install.Name = "Install";
            this.Install.Size = new System.Drawing.Size(218, 23);
            this.Install.TabIndex = 9;
            this.Install.Text = "Install Mod";
            this.Install.UseVisualStyleBackColor = true;
            this.Install.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Enable
            // 
            this.Enable.Location = new System.Drawing.Point(373, 268);
            this.Enable.Margin = new System.Windows.Forms.Padding(2);
            this.Enable.Name = "Enable";
            this.Enable.Size = new System.Drawing.Size(218, 23);
            this.Enable.TabIndex = 10;
            this.Enable.Text = "Enable Mod";
            this.Enable.UseVisualStyleBackColor = true;
            this.Enable.Click += new System.EventHandler(this.Enable_Click);
            // 
            // Uninstall
            // 
            this.Uninstall.Location = new System.Drawing.Point(373, 245);
            this.Uninstall.Margin = new System.Windows.Forms.Padding(2);
            this.Uninstall.Name = "Uninstall";
            this.Uninstall.Size = new System.Drawing.Size(218, 23);
            this.Uninstall.TabIndex = 11;
            this.Uninstall.Text = "Uninstall Mod";
            this.Uninstall.UseVisualStyleBackColor = true;
            this.Uninstall.Click += new System.EventHandler(this.Uninstall_Click);
            // 
            // Disable
            // 
            this.Disable.Location = new System.Drawing.Point(373, 292);
            this.Disable.Margin = new System.Windows.Forms.Padding(2);
            this.Disable.Name = "Disable";
            this.Disable.Size = new System.Drawing.Size(218, 23);
            this.Disable.TabIndex = 12;
            this.Disable.Text = "Disable Mod";
            this.Disable.UseVisualStyleBackColor = true;
            this.Disable.Click += new System.EventHandler(this.Disable_Click);
            // 
            // ResourceHubPage
            // 
            this.ResourceHubPage.Location = new System.Drawing.Point(373, 315);
            this.ResourceHubPage.Margin = new System.Windows.Forms.Padding(2);
            this.ResourceHubPage.Name = "ResourceHubPage";
            this.ResourceHubPage.Size = new System.Drawing.Size(218, 23);
            this.ResourceHubPage.TabIndex = 13;
            this.ResourceHubPage.Text = "Open ResourceHub Page";
            this.ResourceHubPage.UseVisualStyleBackColor = true;
            this.ResourceHubPage.Click += new System.EventHandler(this.ResourceHubPage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.ResourceHubPage);
            this.Controls.Add(this.Disable);
            this.Controls.Add(this.Uninstall);
            this.Controls.Add(this.Enable);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "ResourceHub Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox NonInstalled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox Installed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox Disabled;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Install;
        private System.Windows.Forms.Button Enable;
        private System.Windows.Forms.Button Uninstall;
        private System.Windows.Forms.Button Disable;
        private System.Windows.Forms.Button ResourceHubPage;
    }
}

