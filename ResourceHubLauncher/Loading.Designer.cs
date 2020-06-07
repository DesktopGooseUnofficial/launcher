namespace ResourceHubLauncher {
    partial class Loading {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.styleExtender = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.progress = new MetroFramework.Controls.MetroProgressSpinner();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.progress.Location = new System.Drawing.Point(247, 74);
            this.progress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progress.Maximum = 100;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(53, 43);
            this.progress.TabIndex = 0;
            this.progress.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progress.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.metroLabel1.Location = new System.Drawing.Point(20, 74);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(175, 20);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Now checking for updates.";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.metroLabel2.Location = new System.Drawing.Point(20, 97);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(164, 20);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "This may take a moment.";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 130);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.progress);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Loading";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Launcher Updater";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleExtender styleExtender;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroProgressSpinner progress;
    }
}