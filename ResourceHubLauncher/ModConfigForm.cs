using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RHL_Mod_Configurator_API;


namespace ResourceHubLauncher
{
    class ModConfigForm : MetroForm {
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox IntBox;
        private MetroLabel metroLabel3;
        private MetroLabel metroLabel4;
        private MetroTextBox metroTextBox1;
        private MetroCheckBox metroCheckBox1;
        private MetroLabel metroLabel5;
        private MetroTextBox metroTextBox3;
        private MetroButton metroButton2;
        private MetroButton metroButton3;
        private MetroButton ApplyButton;
        private MetroButton CancelConfigButton;
        private MetroButton DefaultButton;
        private MetroFramework.Controls.MetroButton metroButton1;

        List<ModConfigClasses.ModConfigBox> configGUI;
        List<KeyValuePair<string, ConfigFile>> configFiles;
        List<KeyValuePair<string, ConfigFile>> defaultConfigFiles;

        public ModConfigForm() {
            InitializeComponent();

        }
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModConfigForm));
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.IntBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox3 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.ApplyButton = new MetroFramework.Controls.MetroButton();
            this.CancelConfigButton = new MetroFramework.Controls.MetroButton();
            this.DefaultButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(23, 333);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(388, 23);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "link Button";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(366, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(23, 96);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(388, 23);
            this.metroTextBox2.TabIndex = 2;
            this.metroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 73);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(73, 20);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "String Box:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 127);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(53, 20);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Int Box:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // IntBox
            // 
            // 
            // 
            // 
            this.IntBox.CustomButton.Image = null;
            this.IntBox.CustomButton.Location = new System.Drawing.Point(366, 1);
            this.IntBox.CustomButton.Name = "";
            this.IntBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.IntBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.IntBox.CustomButton.TabIndex = 1;
            this.IntBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.IntBox.CustomButton.UseSelectable = true;
            this.IntBox.CustomButton.Visible = false;
            this.IntBox.Lines = new string[0];
            this.IntBox.Location = new System.Drawing.Point(23, 150);
            this.IntBox.MaxLength = 10;
            this.IntBox.Name = "IntBox";
            this.IntBox.PasswordChar = '\0';
            this.IntBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.IntBox.SelectedText = "";
            this.IntBox.SelectionLength = 0;
            this.IntBox.SelectionStart = 0;
            this.IntBox.ShortcutsEnabled = false;
            this.IntBox.Size = new System.Drawing.Size(388, 23);
            this.IntBox.TabIndex = 4;
            this.IntBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.IntBox.UseSelectable = true;
            this.IntBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.IntBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 23);
            this.metroLabel3.MaximumSize = new System.Drawing.Size(388, 9999999);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(70, 40);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Comment\r\n";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.WrapToLine = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 180);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(67, 20);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Float Box:";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(366, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(23, 203);
            this.metroTextBox1.MaxLength = 20;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = false;
            this.metroTextBox1.Size = new System.Drawing.Size(388, 23);
            this.metroTextBox1.TabIndex = 7;
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(23, 232);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(75, 17);
            this.metroCheckBox1.TabIndex = 9;
            this.metroCheckBox1.Text = "Bool Box";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(23, 252);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(59, 20);
            this.metroLabel5.TabIndex = 11;
            this.metroLabel5.Text = "File Box:";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTextBox3
            // 
            // 
            // 
            // 
            this.metroTextBox3.CustomButton.Image = null;
            this.metroTextBox3.CustomButton.Location = new System.Drawing.Point(343, 1);
            this.metroTextBox3.CustomButton.Name = "";
            this.metroTextBox3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox3.CustomButton.TabIndex = 1;
            this.metroTextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox3.CustomButton.UseSelectable = true;
            this.metroTextBox3.CustomButton.Visible = false;
            this.metroTextBox3.Lines = new string[0];
            this.metroTextBox3.Location = new System.Drawing.Point(23, 275);
            this.metroTextBox3.MaxLength = 20;
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.PasswordChar = '\0';
            this.metroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox3.SelectedText = "";
            this.metroTextBox3.SelectionLength = 0;
            this.metroTextBox3.SelectionStart = 0;
            this.metroTextBox3.ShortcutsEnabled = false;
            this.metroTextBox3.Size = new System.Drawing.Size(365, 23);
            this.metroTextBox3.TabIndex = 10;
            this.metroTextBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox3.UseSelectable = true;
            this.metroTextBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(388, 275);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(23, 23);
            this.metroButton2.TabIndex = 12;
            this.metroButton2.Text = "\\/";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            // 
            // metroButton3
            // 
            this.metroButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.metroButton3.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroButton3.Location = new System.Drawing.Point(23, 304);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(388, 23);
            this.metroButton3.TabIndex = 13;
            this.metroButton3.Text = "Color Box";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.UseCustomBackColor = true;
            this.metroButton3.UseCustomForeColor = true;
            this.metroButton3.UseSelectable = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.ApplyButton.Location = new System.Drawing.Point(329, 364);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(82, 25);
            this.ApplyButton.TabIndex = 14;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ApplyButton.UseSelectable = true;
            // 
            // CancelConfigButton
            // 
            this.CancelConfigButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.CancelConfigButton.Location = new System.Drawing.Point(241, 364);
            this.CancelConfigButton.Name = "CancelConfigButton";
            this.CancelConfigButton.Size = new System.Drawing.Size(82, 25);
            this.CancelConfigButton.TabIndex = 15;
            this.CancelConfigButton.Text = "Cancel";
            this.CancelConfigButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CancelConfigButton.UseSelectable = true;
            // 
            // DefaultButton
            // 
            this.DefaultButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.DefaultButton.Location = new System.Drawing.Point(141, 364);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(94, 25);
            this.DefaultButton.TabIndex = 16;
            this.DefaultButton.Text = "Set To Default";
            this.DefaultButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.DefaultButton.UseSelectable = true;
            // 
            // ModConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(434, 412);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.CancelConfigButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroTextBox3);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.IntBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTextBox2);
            this.Controls.Add(this.metroButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModConfigForm";
            this.Resizable = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ModConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ModConfigForm_Load(object sender, EventArgs e) {
            Config.Theme(this);
        }

        private DialogResult MsgBox(object text, string title = "ResourceHub Launcher", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1) {
            return MetroMessageBox.Show(this, text.ToString(), title, buttons, icon, defaultButton);
        }

        //will open new file if not opened before
        void OpenConfigFile(string configFilePath) {
            if (configFiles.FindIndex((c) => { return c.Key == configFilePath; })==-1) {
                configFiles.Add(new KeyValuePair<string, ConfigFile>(configFilePath, new ConfigFile(configFilePath)));
            }
        }

        public  void AddCommentFunction(string comment) {
            ModConfigClasses.Comment commentClass = new ModConfigClasses.Comment(comment);
            if (configGUI.Count > 0) {
                ((ModConfigClasses.ModConfigBox) commentClass).SetLocation(configGUI.Last().GetNextBoxLocation());
            } else {
                ((ModConfigClasses.ModConfigBox)commentClass).SetLocation( new Point(23, 23));
            }
            Controls.Add(commentClass);
            configGUI.Add(commentClass);
            
        }

        public  void AddStringBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.StringBox Box = new ModConfigClasses.StringBox(fileWithConfigPath, configOptionName, showedName);
            OpenConfigFile(fileWithConfigPath);
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
            if (configGUI.Count > 0) {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
            } else {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
            }
            Controls.Add(Box);
            configGUI.Add(Box);
        }

        public  void AddStringBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach(KeyValuePair<string,string> pair in configFiles.Last().Value.options) {
                ModConfigClasses.StringBox Box = new ModConfigClasses.StringBox(fileWithConfigPath, pair.Key, pair.Key+':');
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
                if (configGUI.Count > 0) {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
                } else {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
                }
                Controls.Add(Box);
                configGUI.Add(Box);
            }
        }

        public  void AddIntBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.IntBox Box = new ModConfigClasses.IntBox(fileWithConfigPath, configOptionName, showedName);
            OpenConfigFile(fileWithConfigPath);
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
            if (configGUI.Count > 0) {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
            } else {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
            }
            Controls.Add(Box);
            configGUI.Add(Box);
        }

        public  void AddIntBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach (KeyValuePair<string, string> pair in configFiles.Last().Value.options) {
                ModConfigClasses.IntBox Box = new ModConfigClasses.IntBox(fileWithConfigPath, pair.Key, pair.Key+':');
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
                if (configGUI.Count > 0) {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
                } else {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
                }
                Controls.Add(Box);
                configGUI.Add(Box);
            }
        }

        public  void AddFloatBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.FloatBox Box = new ModConfigClasses.FloatBox(fileWithConfigPath, configOptionName, showedName);
            OpenConfigFile(fileWithConfigPath);
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
            if (configGUI.Count > 0) {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
            } else {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
            }
            Controls.Add(Box);
            configGUI.Add(Box);
        }

        public  void AddFloatBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach (KeyValuePair<string, string> pair in configFiles.Last().Value.options) {
                ModConfigClasses.FloatBox Box = new ModConfigClasses.FloatBox(fileWithConfigPath, pair.Key, pair.Key+':');
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
                if (configGUI.Count > 0) {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
                } else {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
                }
                Controls.Add(Box);
                configGUI.Add(Box);
            }
        }

        public  void AddBoolBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.BoolBox Box = new ModConfigClasses.BoolBox(fileWithConfigPath, configOptionName, showedName);
            OpenConfigFile(fileWithConfigPath);
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
            if (configGUI.Count > 0) {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
            } else {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
            }
            Controls.Add(Box);
            configGUI.Add(Box);
        }

        public  void AddBoolBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach (KeyValuePair<string, string> pair in configFiles.Last().Value.options) {
                ModConfigClasses.BoolBox Box = new ModConfigClasses.BoolBox(fileWithConfigPath, pair.Key, pair.Key+':');
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
                if (configGUI.Count > 0) {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
                } else {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
                }
                Controls.Add(Box);
                configGUI.Add(Box);
            }
        }

        public  void AddFileBoxFunction(string showedName, OpenFileDialog FileDialog, Action<string> howToUsePath, string toFilePath) {

            ModConfigClasses.FileBox Box = new ModConfigClasses.FileBox(showedName, FileDialog, howToUsePath, toFilePath);
            Box.Text = toFilePath;
            if (configGUI.Count > 0) {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
            } else {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
            }
            Controls.Add(Box);
            configGUI.Add(Box);
        }

        public  void AddColorBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.ColorBox Box = new ModConfigClasses.ColorBox(fileWithConfigPath, configOptionName, showedName);
            OpenConfigFile(fileWithConfigPath);
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
            if (configGUI.Count > 0) {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
            } else {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
            }
            Controls.Add(Box);
            configGUI.Add(Box);
        }

        public  void AddColorBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach (KeyValuePair<string, string> pair in configFiles.Last().Value.options) {
                ModConfigClasses.ColorBox Box = new ModConfigClasses.ColorBox(fileWithConfigPath, pair.Key, pair.Key+':');
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(configFiles);
                if (configGUI.Count > 0) {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
                } else {
                    ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
                }
                Controls.Add(Box);
                configGUI.Add(Box);
            }
        }

        public  void AddLinkButtonFunction(string buttonText, string buttonLink) {
            ModConfigClasses.LinkButton Box = new ModConfigClasses.LinkButton(buttonText, buttonLink, MsgBox);
            if (configGUI.Count > 0) {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(configGUI.Last().GetNextBoxLocation());
            } else {
                ((ModConfigClasses.ModConfigBox)Box).SetLocation(new Point(23, 23));
            }
            Controls.Add(Box);
            configGUI.Add(Box);
        }


    }
}
