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
using System.IO;
using System.Reflection;


namespace ResourceHubLauncher
{
    
    class ModConfigForm : MetroForm {


        public class ModConfigData
        {
            public ModConfigData() {
                configGUI = new List<ModConfigClasses.ModConfigBox>();
                configFiles = new List<KeyValuePair<string, ConfigFile>>();
                defaultConfigFiles = new List<KeyValuePair<string, ConfigFile>>();
            }
            public List<ModConfigClasses.ModConfigBox> configGUI = new List<ModConfigClasses.ModConfigBox>();
            public List<KeyValuePair<string, ConfigFile>> configFiles = new List<KeyValuePair<string, ConfigFile>>();
            public List<KeyValuePair<string, ConfigFile>> defaultConfigFiles = new List<KeyValuePair<string, ConfigFile>>();

        }
        private MetroButton ApplyButton;
        private MetroButton CancelConfigButton;


        public static List<KeyValuePair<string, ModConfigData>> modsConfigs=new List<KeyValuePair<string, ModConfigData>>();
        public static ModConfigData actualModConfig;
        private ContextMenuStrip OptionOptionsContextMenu;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem DiscardChangesToolStripMenuItem;
        private ToolStripMenuItem SetToDefaultToolStripMenuItem;
        private ToolStripMenuItem optionsUsedBeforeToolStripMenuItem;
        private MetroButton metroButton1;
        private MetroButton metroButton2;
        public static ModConfigForm thisConfigForm;
        //public static ContextMenuStrip GUIContextMenu;

        public ModConfigForm() {
            InitializeComponent();

        }
        public ModConfigForm(ConfiguratorBasic configurator) {
            InitializeComponent();
            thisConfigForm = this;
            OpenMod(MainForm.modName, configurator);
            

            for (int i = 0; i < actualModConfig.configGUI.Count; i++) {
                actualModConfig.configGUI[i].ApplyValue(actualModConfig.configFiles);
            }

            for (int i=0;i< actualModConfig.configGUI.Count;i++) {
                Controls.Add((Control)actualModConfig.configGUI[i]);
                actualModConfig.configGUI[i].addControlsToControl(thisConfigForm);
                if (i > 0) {
                    actualModConfig.configGUI[i].SetLocation(actualModConfig.configGUI[i - 1].GetNextBoxLocation());
                } else {
                    actualModConfig.configGUI[i].SetLocation(new Point(23, 33));
                }
            }

            Size = new Size(Size.Width, actualModConfig.configGUI.Last().GetNextBoxLocation().Y + 25 + 23);

        }
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModConfigForm));
            this.ApplyButton = new MetroFramework.Controls.MetroButton();
            this.CancelConfigButton = new MetroFramework.Controls.MetroButton();
            this.OptionOptionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DiscardChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsUsedBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.OptionOptionsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.ApplyButton.Location = new System.Drawing.Point(329, 364);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(82, 25);
            this.ApplyButton.TabIndex = 14;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ApplyButton.UseSelectable = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelConfigButton
            // 
            this.CancelConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelConfigButton.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.CancelConfigButton.Location = new System.Drawing.Point(241, 364);
            this.CancelConfigButton.Name = "CancelConfigButton";
            this.CancelConfigButton.Size = new System.Drawing.Size(82, 25);
            this.CancelConfigButton.TabIndex = 15;
            this.CancelConfigButton.Text = "Cancel";
            this.CancelConfigButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CancelConfigButton.UseSelectable = true;
            this.CancelConfigButton.Click += new System.EventHandler(this.CancelConfigButton_Click);
            // 
            // OptionOptionsContextMenu
            // 
            this.OptionOptionsContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.OptionOptionsContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.OptionOptionsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.OptionOptionsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DiscardChangesToolStripMenuItem,
            this.SetToDefaultToolStripMenuItem,
            this.optionsUsedBeforeToolStripMenuItem});
            this.OptionOptionsContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.OptionOptionsContextMenu.Name = "modListContextMenu";
            this.OptionOptionsContextMenu.ShowImageMargin = false;
            this.OptionOptionsContextMenu.Size = new System.Drawing.Size(191, 76);
            // 
            // DiscardChangesToolStripMenuItem
            // 
            this.DiscardChangesToolStripMenuItem.Name = "DiscardChangesToolStripMenuItem";
            this.DiscardChangesToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.DiscardChangesToolStripMenuItem.Text = "Discard Changes";
            this.DiscardChangesToolStripMenuItem.Click += new System.EventHandler(this.DiscardChangesButton_Click);
            // 
            // SetToDefaultToolStripMenuItem
            // 
            this.SetToDefaultToolStripMenuItem.Name = "SetToDefaultToolStripMenuItem";
            this.SetToDefaultToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.SetToDefaultToolStripMenuItem.Text = "Set To Default";
            this.SetToDefaultToolStripMenuItem.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // optionsUsedBeforeToolStripMenuItem
            // 
            this.optionsUsedBeforeToolStripMenuItem.Name = "optionsUsedBeforeToolStripMenuItem";
            this.optionsUsedBeforeToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.optionsUsedBeforeToolStripMenuItem.Text = "Options Used Before";
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(23, 364);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(114, 25);
            this.metroButton1.TabIndex = 16;
            this.metroButton1.Text = "Discard Changes";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(143, 364);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(92, 25);
            this.metroButton2.TabIndex = 17;
            this.metroButton2.Text = "Set To Default";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // ModConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(434, 412);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.CancelConfigButton);
            this.Controls.Add(this.ApplyButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModConfigForm";
            this.Resizable = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ModConfigForm_Load);
            this.OptionOptionsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void ModConfigForm_Load(object sender, EventArgs e) {
            Config.Theme(this);
        }

        public static DialogResult MsgBox(object text, string title = "ResourceHub Launcher", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1) {
            return MetroMessageBox.Show(thisConfigForm, text.ToString(), title, buttons, icon, defaultButton);
        }

        //will open new file if not opened before
        public static void OpenConfigFile(string configFilePath) {
            if (actualModConfig.configFiles.FindIndex((c) => { return c.Key == configFilePath; })==-1) {
                actualModConfig.configFiles.Add(new KeyValuePair<string, ConfigFile>(configFilePath, new ConfigFile(configFilePath)));
            }
        }

        public static void OpenMod(string modName, ConfiguratorBasic configurator) {
            int modConfigIndex = modsConfigs.FindIndex((p) => { return p.Key == modName; });

            if (modConfigIndex == -1) {
                actualModConfig = new ModConfigData();
                modsConfigs.Add(new KeyValuePair<string, ModConfigData>(MainForm.modName, actualModConfig));
                configurator.Initialize();
                MakeDefaultFiles();

            } else {
                actualModConfig = modsConfigs[modConfigIndex].Value;
                actualModConfig.configGUI.Clear();
                for (int i = 0; i < actualModConfig.configFiles.Count; i++) {
                    actualModConfig.configFiles[i].Value.Reload();
                }
                
                configurator.Initialize();
                MakeDefaultFiles();
            }

        }

        public static string getInGooseFilePath(string path) {
            return path.Substring(Path.GetDirectoryName((string)Config.Options["gpath"]).Length+1);
        }

        static void MakeDefaultFiles() {
            foreach(KeyValuePair<string, ConfigFile> pair in actualModConfig.configFiles) {
                string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string forDefaultPath = getInGooseFilePath( pair.Key);
                string defaultPath = Path.Combine(exePath, "ModsFiles", MainForm.modName,"Default", forDefaultPath);
                try {
                    if(!Directory.Exists(Path.GetDirectoryName(defaultPath))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(defaultPath));
                    }
                    
                    File.Copy(pair.Key, defaultPath,false);
                }
                catch(IOException) {

                }
                actualModConfig.defaultConfigFiles.Add(new KeyValuePair<string, ConfigFile>(pair.Key,new ConfigFile(defaultPath)));
            }
        }

        void MakeSafetyCopy() {
            foreach (KeyValuePair<string, ConfigFile> pair in actualModConfig.configFiles) {
                string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string forDefaultPath = getInGooseFilePath(pair.Key);
                string defaultPath = Path.Combine(exePath, "ModsFiles", MainForm.modName, "Used Before", forDefaultPath);
                try {
                    if (!Directory.Exists(Path.GetDirectoryName(defaultPath))) {
                        Directory.CreateDirectory(Path.GetDirectoryName(defaultPath));
                    }

                    File.Copy(pair.Key, defaultPath, true);
                } catch (IOException) {

                }
            }
        }

        void UseDefaultOptions() {
            for(int i=0;i< actualModConfig.configGUI.Count;i++) {
                actualModConfig.configGUI[i].ApplyValue(actualModConfig.defaultConfigFiles);
            }
        }

        public static void UseSafetyCopy(string modName) {
            string safetyCopyPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", modName, "Used Before");

            foreach(KeyValuePair<string,ConfigFile> pair in actualModConfig.configFiles) {
                string inGoosePath = getInGooseFilePath(pair.Key);
                ConfigFile configFile = new ConfigFile(Path.Combine(safetyCopyPath,inGoosePath ));
                configFile.ApplyFrom(pair.Key);
                pair.Value.SaveChanges();
            }

            foreach( string file in Directory.GetFiles(safetyCopyPath, "*", SearchOption.AllDirectories)) {
                string forDefaultPath = file.Substring(safetyCopyPath.Length);
                
                File.Copy(file, Path.Combine((string)Config.Options["gpath"], forDefaultPath));
            }

        }

        public static void setPosition(ModConfigClasses.ModConfigBox box) {
            /*if (actualModConfig.configGUI.Count > 0) {
                box.SetLocation(actualModConfig.configGUI.Last().GetNextBoxLocation());
            } else {
                box.SetLocation(new Point(23, 33));
            }*/
        }

        public static void AddCommentFunction(string comment) {
            ModConfigClasses.Comment commentClass = new ModConfigClasses.Comment(comment);
            setPosition(commentClass);
            actualModConfig.configGUI.Add(commentClass);
            
        }

        public static void AddStringBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.StringBox Box = new ModConfigClasses.StringBox(fileWithConfigPath, configOptionName, showedName);
            OpenConfigFile(fileWithConfigPath);
            //Box.ContextMenuStrip = GUIContextMenu;
            
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
            setPosition(Box);
            actualModConfig.configGUI.Add(Box);
        }

        public static void AddStringBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach(KeyValuePair<string,string> pair in actualModConfig.configFiles.Last().Value.options) {
                ModConfigClasses.StringBox Box = new ModConfigClasses.StringBox(fileWithConfigPath, pair.Key, pair.Key);
                //Box.ContextMenuStrip = GUIContextMenu;
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
                setPosition(Box);
                actualModConfig.configGUI.Add(Box);
            }
        }

        public static void AddIntBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.IntBox Box = new ModConfigClasses.IntBox(fileWithConfigPath, configOptionName, showedName);
            //Box.ContextMenuStrip = GUIContextMenu;
            OpenConfigFile(fileWithConfigPath);
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
            setPosition(Box);
            actualModConfig.configGUI.Add(Box);
        }

        public static void AddIntBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach (KeyValuePair<string, string> pair in actualModConfig.configFiles.Last().Value.options) {
                ModConfigClasses.IntBox Box = new ModConfigClasses.IntBox(fileWithConfigPath, pair.Key, pair.Key);
                //Box.ContextMenuStrip = GUIContextMenu;
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
                setPosition(Box);
                actualModConfig.configGUI.Add(Box);
            }
        }

        public static void AddFloatBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.FloatBox Box = new ModConfigClasses.FloatBox(fileWithConfigPath, configOptionName, showedName);
            //Box.ContextMenuStrip = GUIContextMenu;
            OpenConfigFile(fileWithConfigPath);
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
            setPosition(Box);
            actualModConfig.configGUI.Add(Box);
        }

        public static void AddFloatBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach (KeyValuePair<string, string> pair in actualModConfig.configFiles.Last().Value.options) {
                ModConfigClasses.FloatBox Box = new ModConfigClasses.FloatBox(fileWithConfigPath, pair.Key, pair.Key);
                //Box.ContextMenuStrip = GUIContextMenu;
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
                setPosition(Box);
                actualModConfig.configGUI.Add(Box);
            }
        }

        public static void AddBoolBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.BoolBox Box = new ModConfigClasses.BoolBox(fileWithConfigPath, configOptionName, showedName);
            //Box.ContextMenuStrip = GUIContextMenu;
            OpenConfigFile(fileWithConfigPath);
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
            setPosition(Box);
            actualModConfig.configGUI.Add(Box);
        }

        public static void AddBoolBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach (KeyValuePair<string, string> pair in actualModConfig.configFiles.Last().Value.options) {
                ModConfigClasses.BoolBox Box = new ModConfigClasses.BoolBox(fileWithConfigPath, pair.Key, pair.Key);
                //Box.ContextMenuStrip = GUIContextMenu;
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
                setPosition(Box);
                actualModConfig.configGUI.Add(Box);
            }
        }

        public static void AddFileBoxFunction(string showedName, OpenFileDialog FileDialog, Action<string> howToUsePath, string toFilePath) {

            ModConfigClasses.FileBox Box = new ModConfigClasses.FileBox(showedName, FileDialog, howToUsePath, toFilePath);
            //Box.ContextMenuStrip = GUIContextMenu;
            Box.Text = toFilePath;
            setPosition(Box);
            actualModConfig.configGUI.Add(Box);
        }

        public static void AddColorBoxFunction(string fileWithConfigPath, string configOptionName, string showedName) {
            ModConfigClasses.ColorBox Box = new ModConfigClasses.ColorBox(fileWithConfigPath, configOptionName, showedName);
            //Box.ContextMenuStrip = GUIContextMenu;
            OpenConfigFile(fileWithConfigPath);
            ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
            setPosition(Box);
            actualModConfig.configGUI.Add(Box);
        }

        public static void AddColorBoxForAllFunction(string fileWithConfigPath) {
            OpenConfigFile(fileWithConfigPath);
            foreach (KeyValuePair<string, string> pair in actualModConfig.configFiles.Last().Value.options) {
                ModConfigClasses.ColorBox Box = new ModConfigClasses.ColorBox(fileWithConfigPath, pair.Key, pair.Key);
                //Box.ContextMenuStrip = GUIContextMenu;
                ((ModConfigClasses.ModConfigBox)Box).ApplyValue(actualModConfig.configFiles);
                setPosition(Box);
                actualModConfig.configGUI.Add(Box);
            }
        }

        public static void AddLinkButtonFunction(string buttonText, string buttonLink) {
            ModConfigClasses.LinkButton Box = new ModConfigClasses.LinkButton(buttonText, buttonLink, MsgBox);
            setPosition(Box);
            actualModConfig.configGUI.Add(Box);
        }

        private void DefaultButton_Click(object sender, EventArgs e) {
            UseDefaultOptions();
        }

        private void CancelConfigButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < actualModConfig.configGUI.Count; i++) {
                actualModConfig.configGUI[i].Apply(actualModConfig.configFiles);
            }
            foreach(KeyValuePair<string,ConfigFile> p in actualModConfig.configFiles) {
                p.Value.SaveChanges();
            }
            MakeSafetyCopy();
        }

        private void DiscardChangesButton_Click(object sender, EventArgs e) {
            
        }

        private void metroButton2_Click(object sender, EventArgs e) {
            UseDefaultOptions();
        }

        private void metroButton1_Click(object sender, EventArgs e) {
            for (int i = 0; i < actualModConfig.configGUI.Count; i++) {
                actualModConfig.configGUI[i].ApplyValue(actualModConfig.configFiles);
            }
        }
    }
}
