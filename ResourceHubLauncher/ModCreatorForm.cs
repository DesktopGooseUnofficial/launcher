using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using RHL_Mod_Installer_API;

namespace ResourceHubLauncher
{
    class ModCreatorForm : MetroForm
    {
        private MetroButton installerPathButton;
        private MetroTextBox ModInstallerPath;
        public MetroTextBox NameTextBox;
        private MetroLabel metroLabel2;
        private MetroButton metroButton1;
        private MetroButton metroButton4;
        private MetroLabel metroLabel1;
        private MetroLabel metroLabel4;
        private MetroButton zipPathButton;
        private MetroTextBox zipTextBox;
        private OpenFileDialog InstallerFileDialog;
        private OpenFileDialog ZipFileDialog;
        private OpenFileDialog ConfiguratorFileDialog;
        public static ModCreatorForm thisForm;

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModCreatorForm));
            this.installerPathButton = new MetroFramework.Controls.MetroButton();
            this.ModInstallerPath = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.NameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.zipPathButton = new MetroFramework.Controls.MetroButton();
            this.zipTextBox = new MetroFramework.Controls.MetroTextBox();
            this.InstallerFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ZipFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ConfiguratorFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // installerPathButton
            // 
            this.installerPathButton.Location = new System.Drawing.Point(334, 101);
            this.installerPathButton.Margin = new System.Windows.Forms.Padding(4);
            this.installerPathButton.Name = "installerPathButton";
            this.installerPathButton.Size = new System.Drawing.Size(32, 28);
            this.installerPathButton.TabIndex = 20;
            this.installerPathButton.Text = "...";
            this.installerPathButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.installerPathButton.UseSelectable = true;
            this.installerPathButton.Click += new System.EventHandler(this.goosePathButton_Click);
            // 
            // ModInstallerPath
            // 
            // 
            // 
            // 
            this.ModInstallerPath.CustomButton.Image = null;
            this.ModInstallerPath.CustomButton.Location = new System.Drawing.Point(281, 2);
            this.ModInstallerPath.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.ModInstallerPath.CustomButton.Name = "";
            this.ModInstallerPath.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.ModInstallerPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ModInstallerPath.CustomButton.TabIndex = 1;
            this.ModInstallerPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ModInstallerPath.CustomButton.UseSelectable = true;
            this.ModInstallerPath.CustomButton.Visible = false;
            this.ModInstallerPath.Lines = new string[0];
            this.ModInstallerPath.Location = new System.Drawing.Point(25, 101);
            this.ModInstallerPath.Margin = new System.Windows.Forms.Padding(4);
            this.ModInstallerPath.MaxLength = 32767;
            this.ModInstallerPath.Name = "ModInstallerPath";
            this.ModInstallerPath.PasswordChar = '\0';
            this.ModInstallerPath.PromptText = "Mod Installer Path";
            this.ModInstallerPath.ReadOnly = true;
            this.ModInstallerPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ModInstallerPath.SelectedText = "";
            this.ModInstallerPath.SelectionLength = 0;
            this.ModInstallerPath.SelectionStart = 0;
            this.ModInstallerPath.ShortcutsEnabled = true;
            this.ModInstallerPath.Size = new System.Drawing.Size(307, 28);
            this.ModInstallerPath.TabIndex = 19;
            this.ModInstallerPath.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ModInstallerPath.UseSelectable = true;
            this.ModInstallerPath.WaterMark = "Mod Installer Path";
            this.ModInstallerPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ModInstallerPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 77);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(121, 20);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Mod Installer Path:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // NameTextBox
            // 
            // 
            // 
            // 
            this.NameTextBox.CustomButton.Image = null;
            this.NameTextBox.CustomButton.Location = new System.Drawing.Point(316, 2);
            this.NameTextBox.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.NameTextBox.CustomButton.Name = "";
            this.NameTextBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.NameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NameTextBox.CustomButton.TabIndex = 1;
            this.NameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NameTextBox.CustomButton.UseSelectable = true;
            this.NameTextBox.CustomButton.Visible = false;
            this.NameTextBox.Lines = new string[0];
            this.NameTextBox.Location = new System.Drawing.Point(24, 45);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.NameTextBox.MaxLength = 32767;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PasswordChar = '\0';
            this.NameTextBox.PromptText = "Mod Name";
            this.NameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameTextBox.SelectedText = "";
            this.NameTextBox.SelectionLength = 0;
            this.NameTextBox.SelectionStart = 0;
            this.NameTextBox.ShortcutsEnabled = true;
            this.NameTextBox.Size = new System.Drawing.Size(342, 28);
            this.NameTextBox.TabIndex = 22;
            this.NameTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.NameTextBox.UseSelectable = true;
            this.NameTextBox.WaterMark = "Mod Name";
            this.NameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(25, 21);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(82, 20);
            this.metroLabel2.TabIndex = 23;
            this.metroLabel2.Text = "Mod Name:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton1
            // 
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(25, 193);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(342, 28);
            this.metroButton1.TabIndex = 24;
            this.metroButton1.Text = "Test Installer";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton4.Location = new System.Drawing.Point(26, 229);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(341, 28);
            this.metroButton4.TabIndex = 29;
            this.metroButton4.Text = "Make and Preview Mod Description";
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(24, 133);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(94, 20);
            this.metroLabel4.TabIndex = 32;
            this.metroLabel4.Text = "Mod Zip Path:";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // zipPathButton
            // 
            this.zipPathButton.Location = new System.Drawing.Point(334, 157);
            this.zipPathButton.Margin = new System.Windows.Forms.Padding(4);
            this.zipPathButton.Name = "zipPathButton";
            this.zipPathButton.Size = new System.Drawing.Size(32, 28);
            this.zipPathButton.TabIndex = 31;
            this.zipPathButton.Text = "...";
            this.zipPathButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.zipPathButton.UseSelectable = true;
            this.zipPathButton.Click += new System.EventHandler(this.zipPathButton_Click);
            // 
            // zipTextBox
            // 
            // 
            // 
            // 
            this.zipTextBox.CustomButton.Image = null;
            this.zipTextBox.CustomButton.Location = new System.Drawing.Point(281, 2);
            this.zipTextBox.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.zipTextBox.CustomButton.Name = "";
            this.zipTextBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.zipTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.zipTextBox.CustomButton.TabIndex = 1;
            this.zipTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.zipTextBox.CustomButton.UseSelectable = true;
            this.zipTextBox.CustomButton.Visible = false;
            this.zipTextBox.Lines = new string[0];
            this.zipTextBox.Location = new System.Drawing.Point(25, 157);
            this.zipTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.zipTextBox.MaxLength = 32767;
            this.zipTextBox.Name = "zipTextBox";
            this.zipTextBox.PasswordChar = '\0';
            this.zipTextBox.PromptText = "Mod Zip Path";
            this.zipTextBox.ReadOnly = true;
            this.zipTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.zipTextBox.SelectedText = "";
            this.zipTextBox.SelectionLength = 0;
            this.zipTextBox.SelectionStart = 0;
            this.zipTextBox.ShortcutsEnabled = true;
            this.zipTextBox.Size = new System.Drawing.Size(307, 28);
            this.zipTextBox.TabIndex = 30;
            this.zipTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.zipTextBox.UseSelectable = true;
            this.zipTextBox.WaterMark = "Mod Zip Path";
            this.zipTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.zipTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // InstallerFileDialog
            // 
            this.InstallerFileDialog.Filter = "dll files (*.dll)|*.dll";
            this.InstallerFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.InstallerFileDialog_FileOk);
            // 
            // ZipFileDialog
            // 
            this.ZipFileDialog.Filter = "zip files (*.zip)|*.zip";
            // 
            // ConfiguratorFileDialog
            // 
            this.ConfiguratorFileDialog.Filter = "dll files (*.dll)|*.dll";
            // 
            // ModCreatorForm
            // 
            this.ClientSize = new System.Drawing.Size(391, 283);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.zipPathButton);
            this.Controls.Add(this.zipTextBox);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.installerPathButton);
            this.Controls.Add(this.ModInstallerPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModCreatorForm";
            this.Resizable = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ModCreatorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DialogResult MsgBox(object text, string title = "ResourceHub Launcher", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1) {
            return MetroMessageBox.Show(this, text.ToString(), title, buttons, icon, defaultButton);
        }

        public ModCreatorForm() {
            InitializeComponent();
            Config.Theme(this);
        }

        private void ModCreatorForm_Load(object sender, EventArgs e) {
            
            thisForm = this;
        }

        private void InstallerFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
            ModInstallerPath.Text = InstallerFileDialog.FileName;
        }

        private void goosePathButton_Click(object sender, EventArgs e) {
            InstallerFileDialog.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e) {
            ConfiguratorFileDialog.ShowDialog();
        }

        private void zipPathButton_Click(object sender, EventArgs e) {
            ZipFileDialog.ShowDialog();
        }

        private void metroButton1_Click(object sender, EventArgs e) {

            if(ModInstallerPath.Text=="") {
                MsgBox("Mod Installer Path cannot be empty!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (zipTextBox.Text == "") {
                MsgBox("Mod Zip Path cannot be empty!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (NameTextBox.Text == "") {
                MsgBox("Mod Name cannot be empty!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                Assembly installer = Assembly.LoadFile(ModInstallerPath.Text);
                MainForm.actualZipFilePath = zipTextBox.Text;
                MainForm.actualModPath = Path.Combine(MainForm.modPath, NameTextBox.Text);



                foreach (Type type in installer.GetTypes()) {
                    if (type.GetInterface("InstallerBasic") != null) {
                        InstallerBasic installerIns = (InstallerBasic)Activator.CreateInstance(type);

                        installerIns.Install();


                    }
                }
            }
            catch(Exception ex) {
                MsgBox(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void metroButton4_Click(object sender, EventArgs e) {
            if (NameTextBox.Text == "") {
                MsgBox("Mod Name cannot be empty!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainForm.OpenDescriptionPreview();
            Close();
        }
    }
}
