 using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Reflection;
using RHL_Mod_Installer_API;
//using System.IO.Compression;
using RHL_Mod_Configurator_API;
using Ionic.Zip;

namespace ResourceHubLauncher
{
    public partial class MainForm : MetroForm
    {

        public IList<JToken> results = new List<JToken>();
        IList<JToken> mods = new List<JToken>();
        bool download = false;
        string modPath = "";
        JToken mod;
        ModButton actualModButton;
        ModButtonList modsButtons = new ModButtonList();
        bool closedSpecially = false;
        Action<MainForm> restartForm;

        RichTextHtml htmlTags = new RichTextHtml();
        public StringBuilder md5;

        public MainForm() {
            InitializeComponent();
            styleExtender.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleExtender.Style = (MetroColorStyle)(int)Config.Options["color"];

        }

        public MainForm(Action<MainForm> restartForm_) {
            InitializeComponent();
            styleExtender.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleExtender.Style = (MetroColorStyle)(int)Config.Options["color"];
            restartForm = restartForm_;
        }

        private DialogResult MsgBox(object text, string title = "ResourceHub Launcher", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1) {
            return MetroMessageBox.Show(this, text.ToString(), title, buttons, icon, defaultButton);
        }


        private void MainForm_Load(object sender, EventArgs e) {

            InitializeInstallerAPI();
            InitializeConfiguratorAPI();

            loadingPanel.Location = new Point(0, 0);
            htmlTags.Add("b", "Segoe UI Light", 0, FontStyle.Bold);
            htmlTags.Add("i", "Segoe UI Light", 0, FontStyle.Italic);
            htmlTags.Add("u", "Segoe UI Light", 0, FontStyle.Underline);
            htmlTags.Add("s", "Segoe UI Light", 0, FontStyle.Strikeout);
            htmlTags.Add("m", "Segoe UI Light", 15f);
            htmlTags.Add("big", "Segoe UI Light", 18f);

            if ((string)Config.Options["latestU"] != md5.ToString()) {
                Console.WriteLine($"User appears to have updated.\nDisplaying changelog...");
                htmlTags.Apply(ref changelogRichTextBox);
                changelogPanel.Location = new Point(0, 5);
                changelogPanel.Show();
                Config.Options["latestU"] = md5.ToString();
                Config.Save();
            }

            resizingPanel.BringToFront();
            resizingPanel.Hide();

            modPath = Path.Combine(Config.getModPath(), "Assets", "Mods");

            Icon = Icon.FromHandle(Properties.Resources.RHLTSmall.GetHicon());

            foreach (JToken ok in results) {
                foreach (JToken mod in ok) {
                    mods.Add(mod);
                    ModButton modB = new ModButton((string)mod["name"], (int)mod["level"], ModButtonStates.Available, ModClick, ModHover);

                    Controls.Add(modB);
                    modB.Visible = false;
                    modsButtons.Add(modB);

                    modB.Parent = metroPanel2;
                    modB.changeContextMenu(modListContextMenu);


                    modB.Visible = true;
                }
            }

            Console.WriteLine($"Now checking mods...");

            foreach (string pMod in Directory.GetDirectories(modPath)) {
                string modName = pMod.Substring(modPath.Length + 1);
                string datPath = Path.Combine(modPath, modName, "RHLInfo.json");
                mod = mods.ToList().Find(m => (string)m["name"] == modName);
                actualModButton = modsButtons.Find((string)mod["name"]);
                if (File.Exists(datPath)) {
                    JObject data = JObject.Parse(File.ReadAllText(datPath));
                    if ((string)data["mod-version"] != (string)mod["mod-version"]) {
                        if (MsgBox($"{data["name"]} is outdated.\r\nWould you like to update?", "Mod Auto-Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                            
                            AddToInstallQueue(mod);
                        }
                        continue;
                    }
                }
                ModButton foundObj = modsButtons.Find(modName);
                if (foundObj != null) {
                    Console.WriteLine($"The mod \"{modName}\" was successfully found in the list!");
                    if (File.Exists(Path.Combine(pMod, modName + ".dll.RHLdisabled"))) {
                        foundObj.DisabledMod = true;
                        disableToolStripMenuItem1.Text = "Enable";
                    } else {
                        foundObj.InstalledMod = true;
                        disableToolStripMenuItem1.Text = "Disable";
                    }
                    if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"], "Configurator.dll"))) {
                        foundObj.hasConfigurator = true;
                    }

                } 
                else {
                    ModButtonStates statee = File.Exists(Path.Combine(pMod, modName + ".dll.RHLdisabled")) ? ModButtonStates.Disabled : ModButtonStates.Installed;
                    ModButton newMod = new ModButton(modName, 0, statee, ModClick, ModHover);
                    metroPanel2.Controls.Add(newMod);
                    modsButtons.Add(newMod);
                    newMod.Parent = metroPanel2;
                    if (statee == ModButtonStates.Installed) {
                        disableToolStripMenuItem1.Enabled = true;
                    } else {
                        disableToolStripMenuItem1.Enabled = false;
                    }
                    newMod.fromOutside = true;
                    if (File.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"], "Configurator.dll"))) {
                        newMod.hasConfigurator = true;
                    }
                }

                


            }
            Config.Theme(this);
            modsButtons.ThemeChanged((int)Config.Options["theme"] == 1);

            pictureBox2.Image = Properties.Resources.RHLTSmall;


            if (Process.GetProcessesByName("GooseDesktop").Count() > 0) {
                gooseToolStripMenuItem.Text = "Geese";
            }




            htmlTags.Apply(ref label3);
            




            loadingPanel.Hide();
        }






        private void changeModDescription() {
            try {
                string description = (string)mod["description"];
                if(mod["description-debug"]!=null) {
                    description = (string)mod["description-debug"];
                }
                label3.Text = "<big>"+(string)mod["name"]+ "</big>  Version: "+(string)mod["mod-version"] +"\r\nAuthor: "+(string)mod["author"] + "\r\n\r\n" + description;
                htmlTags.Apply(ref label3);

            } catch (Exception) {
                label3.Text = "Mod description cannot be found";
            }
        }


        private void ModClick(string actualMod) {
            mod = mods.ToList().Find(modd => (string)modd["name"] == actualMod);

            actualModButton = modsButtons.Find(actualMod);
            changeModDescription();
            AfterInstallUpdate();



        }

        private void AfterInstallUpdate() {
            if (actualModButton.InQueue) {
                installToolStripMenuItem.Enabled = false;
            } else {
                installToolStripMenuItem.Enabled = true;
            }
            if((string)mod["resourcehub"] != null) {
                resourceHubToolStripMenuItem.Enabled = true;
            } else {
                resourceHubToolStripMenuItem.Enabled = false;
            }
            if (actualModButton.InstalledMod || actualModButton.DisabledMod) {
                installToolStripMenuItem.Text = "Uninstall";
                disableToolStripMenuItem1.Enabled = true;
                openInModsToolStripMenuItem1.Enabled = true;
                if (!actualModButton.DisabledMod) {
                    disableToolStripMenuItem1.Text = "Disable";
                } else {
                    disableToolStripMenuItem1.Text = "Enable";
                }

                if (actualModButton.fromOutside) {
                    resourceHubToolStripMenuItem.Enabled = false;
                } else {
                    resourceHubToolStripMenuItem.Enabled = true;
                }
                if (actualModButton.hasConfigurator) {
                    configureModToolStripMenuItem.Enabled = true;
                } else {
                    configureModToolStripMenuItem.Enabled = false;
                }

            } else {
                installToolStripMenuItem.Text = "Install";
                disableToolStripMenuItem1.Enabled = false;
                openInModsToolStripMenuItem1.Enabled = false;
                configureModToolStripMenuItem.Enabled = false;
                resourceHubToolStripMenuItem.Enabled = true;
            }
        }

        private void ModHover(string actualMod) {
            mod = mods.ToList().Find(modd => (string)modd["name"] == actualMod);
            //actualModButton = modsButtons.Find(actualMod);
            changeModDescription();
        }

        private void metroButton6_Click(object sender, EventArgs e) {
            Console.WriteLine("Restarting Form...");
            closedSpecially = true;
            restartForm(this);
        }

        private string ReadableBytes(double len) {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1) {
                order++;
                len /= 1024;
            }

            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }

        private bool Log(string str) {
            Console.WriteLine(str);
            return true;
        }

        private void CenterDownloadText() {
            metroLabel1.Location = new Point(((DownloadPanel.Size.Width - metroLabel1.Size.Width) / 2), metroLabel1.Location.Y);
        }

        public static string actualModPath = "";
        public static string actualZipFilePath = "";
        public static string modName = "";

        public static string GetGooseFolder() {
            return (string)Config.Options["gpath"];
        }

        public static string GetModFolder() {
            return actualModPath;
        }

        public static void UnpackZip(string where) {
            if(where ==Path.GetDirectoryName(actualModPath)) {
                if(Directory.Exists(actualModPath)) {
                    Directory.Delete(actualModPath, true);
                }
            } else {
                if (Directory.Exists(where)) {
                    Directory.Delete(where, true);
                }
            }

            using (ZipFile zip1 = ZipFile.Read(actualZipFilePath)) {
                // here, we extract every entry, but we could extract conditionally
                // based on entry name, size, date, checkbox status, etc.  
                foreach (ZipEntry e in zip1) {
                    e.Extract(where, ExtractExistingFileAction.OverwriteSilently);
                }
            }

        }

        private void InitializeInstallerAPI() {
            InstallerAPI.Functions functions = new InstallerAPI.Functions();
            functions.getGooseFolder = new InstallerAPI.Functions.GetGooseFolderFunction(GetGooseFolder);
            functions.getModFolder = new InstallerAPI.Functions.GetModFolderFunction(GetModFolder);
            functions.unpackZip = new InstallerAPI.Functions.UnpackZipFunction(UnpackZip);
            InstallerAPI.functions = functions;
        }

        private void InitializeConfiguratorAPI() {
            ConfiguratorAPI.Functions functions = new ConfiguratorAPI.Functions();
            functions.getGooseFolder= new ConfiguratorAPI.Functions.GetGooseFolderFunction(GetGooseFolder);
            functions.getModFolder = new ConfiguratorAPI.Functions.GetModFolderFunction(GetModFolder);
            ConfiguratorAPI.functions = functions;

            ConfiguratorAPI.GUIFunctions GUI = new ConfiguratorAPI.GUIFunctions();
            GUI.addComment = new ConfiguratorAPI.GUIFunctions.AddCommentFunction(ModConfigForm.AddCommentFunction);
            GUI.addBoolBox = new ConfiguratorAPI.GUIFunctions.AddBoolBoxFunction(ModConfigForm.AddBoolBoxFunction);
            GUI.addBoolBoxForAll = new ConfiguratorAPI.GUIFunctions.AddBoolBoxForAllFunction(ModConfigForm.AddBoolBoxForAllFunction);
            GUI.addColorBox = new ConfiguratorAPI.GUIFunctions.AddColorBoxFunction(ModConfigForm.AddColorBoxFunction);
            GUI.addColorBoxForAll = new ConfiguratorAPI.GUIFunctions.AddColorBoxForAllFunction(ModConfigForm.AddColorBoxForAllFunction);
            GUI.addFileBox = new ConfiguratorAPI.GUIFunctions.AddFileBoxFunction(ModConfigForm.AddFileBoxFunction);
            GUI.addFloatBox = new ConfiguratorAPI.GUIFunctions.AddFloatBoxFunction(ModConfigForm.AddFloatBoxFunction);
            GUI.addFloatBoxForAll = new ConfiguratorAPI.GUIFunctions.AddFloatBoxForAllFunction(ModConfigForm.AddFloatBoxForAllFunction);
            GUI.addIntBox = new ConfiguratorAPI.GUIFunctions.AddIntBoxFunction(ModConfigForm.AddIntBoxFunction);
            GUI.addIntBoxForAll = new ConfiguratorAPI.GUIFunctions.AddIntBoxForAllFunction(ModConfigForm.AddIntBoxForAllFunction);
            GUI.addLinkButton = new ConfiguratorAPI.GUIFunctions.AddLinkButtonFunction(ModConfigForm.AddLinkButtonFunction);
            GUI.addStringBox = new ConfiguratorAPI.GUIFunctions.AddStringBoxFunction(ModConfigForm.AddStringBoxFunction);
            GUI.addStringBoxForAll = new ConfiguratorAPI.GUIFunctions.AddStringBoxForAllFunction(ModConfigForm.AddStringBoxForAllFunction);
            ConfiguratorAPI.GUI = GUI;
        }

        List<JToken> queue=new List<JToken>();
        ModButton installModButton;//actualModButton = modsButtons.Find((string)mod["name"]);
        bool installing = false;

        void downloadFile(string url, string folderPath, string filePath, string modName, AsyncCompletedEventHandler afterDownload) {
            using (WebClient wc = new WebClient()) {
                try {
                    Uri uri = new Uri(url);
                    string format = "Installing {0} ({1}/{2})";

                    metroLabel1.Text = $"Preparing to install {(string)mod["name"]}";
                    CenterDownloadText();
                    DownloadPanel.Show();

                    metroProgressBar1.Value = 0;


                    wc.DownloadFileAsync(uri, filePath);

                    wc.DownloadProgressChanged += (object _sender, DownloadProgressChangedEventArgs args) => {

                        metroProgressBar1.Value = args.ProgressPercentage;
                        metroLabel1.Text = string.Format(format, modName, ReadableBytes(args.BytesReceived), ReadableBytes(args.TotalBytesToReceive));
                        int v = metroLabel1.Text.Length;
                        Console.WriteLine(metroLabel1.Text.Substring(0, v - 1) + $" {args.ProgressPercentage}%)");
                        CenterDownloadText();
                    };
                    wc.DownloadFileCompleted += afterDownload;

                } catch (Exception ex) {
                    Console.WriteLine($"Could not download {(string)mod["name"]}: {ex.Message}");
                    download = false;
                    MsgBox("The download for this mod is not available or invalid.", "Download error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DownloadPanel.Hide();
                    return;
                }
            }
        }

        void DllDownloadEnd(object _sender, AsyncCompletedEventArgs args, JToken mod, ModButton actualModButton) {
            if ((string)mod["config-url"] != null) {
                string urlC = (string)mod["config-url"];
                string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"]);
                string f = Path.Combine(filePath, "Configurator.dll");
                downloadFile(urlC, modPath, f, (string)mod["name"], (object _sender3, AsyncCompletedEventArgs args3) => {
                    DownloadPanel.Hide();
                    if (!actualModButton.InstalledMod && Directory.Exists(modPath)) actualModButton.InstalledMod = true;

                    string launcherModPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"]);
                    if (Directory.Exists(Path.Combine(launcherModPath, "Default"))) {
                        Directory.Delete(Path.Combine(launcherModPath, "Default"), true);
                    }
                    if (Directory.Exists(Path.Combine(launcherModPath, "Used Before"))) {
                        Assembly configurator = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"], "Configurator.dll"));
                        ConfiguratorBasic configuratorIns;
                        foreach (Type type in configurator.GetTypes()) {
                            if (type.GetInterface("ConfiguratorBasic") != null) {
                                configuratorIns = (ConfiguratorBasic)Activator.CreateInstance(type);
                                ModConfigForm.OpenMod((string)mod["name"], configuratorIns);


                                ModConfigForm.UseSafetyCopy((string)mod["name"]);
                            }
                        }

                    }

                    string dataPath = Path.Combine( modPath, (string)mod["name"]);
                    actualModButton.InstalledMod = true;
                    actualModButton.hasConfigurator = true;
                    AfterInstallUpdate();
                    actualModButton.Refresh();
                    
                    
                    dataPath = Path.Combine(dataPath, "RHLInfo.json");

                    try {
                        if (!Directory.Exists(Path.GetDirectoryName(dataPath))) Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
                        if (!File.Exists(dataPath)) File.Create(dataPath).Close();
                        File.WriteAllText(dataPath, mod.ToString());
                    } catch (IOException ex) {
                        MsgBox($"Failed to write to RHLInfo.json\r\nError: {ex.Message}", "RHLInfo.json error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    download = false;
                    installing = false;
                    ContinueInstalling();
                });
            } 
            else {
                DownloadPanel.Hide();
                if (!actualModButton.InstalledMod && Directory.Exists(modPath)) actualModButton.InstalledMod = true;


                string dataPath = Path.Combine(modPath, (string)mod["name"]);
                actualModButton.InstalledMod = true;
                AfterInstallUpdate();
                actualModButton.Refresh();

                dataPath = Path.Combine(dataPath, "RHLInfo.json");

                try {
                    if (!Directory.Exists(Path.GetDirectoryName(dataPath))) Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
                    if (!File.Exists(dataPath)) File.Create(dataPath).Close();
                    File.WriteAllText(dataPath, mod.ToString());
                } catch (IOException ex) {
                    MsgBox($"Failed to write to RHLInfo.json\r\nError: {ex.Message}", "RHLInfo.json error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                download = false;
                installing = false;
                ContinueInstalling();
            }
        }

        void NoDllDownloadEnd(object _sender, AsyncCompletedEventArgs args, JToken mod, ModButton actualModButton) {

            string urlI = (string)mod["install-url"];
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"]);
            string f = Path.Combine(filePath, "Installer.dll");
            downloadFile(urlI, modPath, f, (string)mod["name"], (object _sender2, AsyncCompletedEventArgs args2) => {
                if ((string)mod["config-url"] != null) {
                    string urlC = (string)mod["config-url"];

                    f = Path.Combine(filePath, "Configurator.dll");
                    downloadFile(urlC, modPath, f, (string)mod["name"], (object _sender3, AsyncCompletedEventArgs args3) => {
                        DownloadPanel.Hide();
                        if (!actualModButton.InstalledMod && Directory.Exists(modPath)) actualModButton.InstalledMod = true;

                        string dataPath = Path.Combine(modPath, (string)mod["name"]);
                        string launcherModPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"]);
                        if (Directory.Exists(Path.Combine(launcherModPath, "Default"))) {
                            Directory.Delete(Path.Combine(launcherModPath, "Default"), true);
                        }
                        if (Directory.Exists(Path.Combine(launcherModPath, "Used Before"))) {
                            Assembly configurator = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"], "Configurator.dll"));
                            ConfiguratorBasic configuratorIns;
                            foreach (Type type in configurator.GetTypes()) {
                                if (type.GetInterface("ConfiguratorBasic") != null) {
                                    configuratorIns = (ConfiguratorBasic)Activator.CreateInstance(type);
                                    ModConfigForm.OpenMod((string)mod["name"], configuratorIns);


                                    ModConfigForm.UseSafetyCopy((string)mod["name"]);
                                }
                            }
                            
                        }
                        dataPath = Path.Combine(dataPath, "RHLInfo.json");
                        actualModButton.InstalledMod = true;
                        actualModButton.hasConfigurator = true;
                        AfterInstallUpdate();
                        actualModButton.Refresh();
                        
                        try {
                            if (!Directory.Exists(Path.GetDirectoryName(dataPath))) Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
                            if (!File.Exists(dataPath)) File.Create(dataPath).Close();
                            File.WriteAllText(dataPath, mod.ToString());
                        } catch (IOException ex) {
                            MsgBox($"Failed to write to RHLInfo.json\r\nError: {ex.Message}", "RHLInfo.json error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        download = false;
                        installing = false;
                        ContinueInstalling();
                    });
                } 
                else {

                    Assembly installer = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"], "Installer.dll"));

                    actualModPath = Path.Combine(modPath, actualModButton.modName);



                    foreach (Type type in installer.GetTypes()) {
                        if (type.GetInterface("InstallerBasic") != null) {
                            InstallerBasic installerIns = (InstallerBasic)Activator.CreateInstance(type);
                            
                            installerIns.Install();


                        }
                    }

                    DownloadPanel.Hide();
                    if (!actualModButton.InstalledMod && Directory.Exists(modPath)) actualModButton.InstalledMod = true;

                    string dataPath = Path.Combine(modPath, (string)mod["name"]);
                    actualModButton.InstalledMod = true;
                    AfterInstallUpdate();
                    actualModButton.Refresh();

                    dataPath = Path.Combine(dataPath, "RHLInfo.json");

                    try {
                        if (!Directory.Exists(Path.GetDirectoryName(dataPath))) Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
                        if (!File.Exists(dataPath)) File.Create(dataPath).Close();
                        File.WriteAllText(dataPath, mod.ToString());
                    } catch (IOException ex) {
                        MsgBox($"Failed to write to RHLInfo.json\r\nError: {ex.Message}", "RHLInfo.json error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    

                    download = false;
                    installing = false;
                    ContinueInstalling();
                }
            });
        }



        void AddToInstallQueue(JToken mod) {
            queue.Add(mod.DeepClone());
            modsButtons.Find((string)queue.First()["name"]).InQueue = true;
            actualModButton.Refresh();
            if (!installing) {
                installing = true;
                JToken t = queue.First().DeepClone();
                queue.RemoveAt(0);
                installModButton = modsButtons.Find((string)t["name"]);
                
                install(t, installModButton);
            }
            
        }

        void ContinueInstalling() {
            if(queue.Count>0) {
                JToken t = queue.First().DeepClone();
                queue.RemoveAt(0);
                installModButton = modsButtons.Find((string)t["name"]);
                install(t, installModButton);
                installing = true;
            }
        }

        private void install(JToken mod, ModButton actualModButton) {
            string url = (string)mod["url"];

            Console.WriteLine($"Downloading {(string)mod["name"]} from {url}");

            int l = (int)mod["level"];
            actualModPath = Path.Combine(modPath, actualModButton.modName);
            if (l > 0) {
                if (!(bool)Config.Options["unsfe"] && Log($"Mod is rated {r2s(l)}. Awaiting user confirmation.")) {
                    MsgBox($"This mod is rated as {r2s(l)} and will not be installed for your safety.\r\nIf you want to ignore this go into Settings and enable \"Allow Unsafe Mods\".", "Uh oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else if (Log($"Mod is rated {r2s(l)}. Awaiting user confirmation.") && MsgBox($"This mod is rated as {r2s(l)}.\r\nAre you sure you want to install it? Installing it may cause problems.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) {
                    actualModButton.InstalledMod = false;
                    ContinueInstalling();
                    return;
                }
            }

            string n = Path.GetFileName(url);
            string t = n.Substring(Path.GetFileNameWithoutExtension(n).Length + 1);
            string m = (string)mod["name"];

            bool d = n.Substring(Path.GetFileNameWithoutExtension(n).Length + 1) == "dll";

            string filePath = modPath;

            string f;
            if (d) {
                filePath = Path.Combine(filePath, (string)mod["name"]);
                f = Path.Combine(filePath, Path.GetFileName(url));
            } else {
                f = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"], Path.GetFileName(url));
                actualZipFilePath = f;
            }
            if (!Directory.Exists(Path.GetDirectoryName(f))) Directory.CreateDirectory(Path.GetDirectoryName(f));

            /*if (actualModButton.InstalledMod && Log("Mod seems to already be installed; Prompting user if they still want to download.") && MsgBox($"This mod seems to already be installed.\r\nAre you sure you want to continue and download?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) {
                DownloadPanel.Hide();
                Console.WriteLine("Download cancelled by user.");
                return;
            }*/

            if (!download) {
                download = true;
                downloadFile(url, modPath, f, m, (object _sender, AsyncCompletedEventArgs args) => {
                    if (!d) {
                        NoDllDownloadEnd(_sender, args,mod,actualModButton);

                    } else {
                        DllDownloadEnd(_sender, args, mod, actualModButton);
                    }




                });

            } else {
                MsgBox("You already have a download in progress. Please wait for it to finish.", "Download error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DownloadPanel.Hide();
                return;
            }
        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e) {

           if( actualModButton.InstalledMod || actualModButton.DisabledMod) {
                toolStripMenuItem1_Click(sender, e);
            } else {
                AddToInstallQueue(mod);
            }
            

            


        }

        private void resourceHubToolStripMenuItem_Click(object sender, EventArgs e) {

            try {
                Process.Start(mod["resourcehub"].ToString());
            } catch (Exception) {
                MsgBox("The link for this mod is not available or invalid.", "Page opening error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (!closedSpecially) {
                e.Cancel = MsgBox("Are you sure you want to close the Launcher?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes;
            }

        }

        private void ResourceHubPage_Click(object sender, EventArgs e) {
            if (MsgBox("Are you sure you want to open the ResourceHub website?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://desktopgooseunofficial.github.io/ResourceHub/");
            }
        }

        private void RunGoose_Click(object sender, EventArgs e) {
            toolStripMenuItem2_Click(sender, e);
        }

        private string r2s(int level) {
            switch (level) {
                case -1:
                    return "Inapplicable";
                case 0:
                    return "Safe";
                case 1:
                    return "Moderate";
                case 2:
                    return "Malicious";
                case 3:
                    return "Destructive";
                default:
                    return $"Unknown ({level})";
            }
        }

        private void otherMods_SelectedIndexChanged(object sender, EventArgs e) {




            label3.Text = (string)mod["description"];


        }

        private void modListContextMenu_Opening(object sender, CancelEventArgs e) {
            //if (otherMods.SelectedIndex == -1) e.Cancel = true;
        }

        private void metroButton4_Click(object sender, EventArgs e) {
            foreach (Process p in Process.GetProcessesByName("GooseDesktop")) p.Kill();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            string modd = actualModButton.modName;
            string path = Path.Combine(modPath, modd);
            if (MsgBox($"Are you sure you want to uninstall {modd}? This will delete the {modd} folder!", "Uninstaller", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                int geese = Process.GetProcessesByName("GooseDesktop").Count();
                toolStripMenuItem3_Click(sender, e);
                try {
                    if (Directory.Exists(path)) Directory.Delete(path, true);
                    if(actualModButton.fromOutside) {
                        modsButtons.Remove(actualModButton.modName);
                    } else {
                        actualModButton.InstalledMod = false;
                        installToolStripMenuItem.Text = "Install";
                        actualModButton.Refresh();
                    }
                    
                } catch (Exception ex) {
                    MsgBox($"Error while uninstalling {modd}.\r\nPlease make sure you have Desktop Goose closed.\r\nError: {ex.Message}", "Uninstall error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                for (int i = 0; i < geese; i++) {
                    RunGoose_Click(sender, e);
                }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) {
            string modd = actualModButton.modName;
            string path = Path.Combine(modPath, modd);
            path = Path.Combine(path, modd + ".dll.RHLdisabled");
            string newPath = path.Substring(0, path.Length - 12);
            Console.WriteLine($"Now enabling {modd}, new path will be {newPath}");
            if (MsgBox($"Are you sure you want to enable {modd}? This will restart goose if disabled!", "Enabler", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                int geese = Process.GetProcessesByName("GooseDesktop").Count();
                toolStripMenuItem3_Click(sender, e);
                try {
                    if (File.Exists(path)) File.Move(path, newPath);
                    actualModButton.InstalledMod = true;
                    disableToolStripMenuItem1.Text = "Disable";
                    actualModButton.Refresh();
                } catch (Exception ex) {
                    MsgBox($"Error while enabling {modd}.\r\nError: {ex.Message}", "Error while enabling mod.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                for (int i = 0; i < geese; i++) {
                    RunGoose_Click(sender, e);
                }
            }
        }

        private void openInModsToolStripMenuItem_Click(object sender, EventArgs e) {
            string modd = actualModButton.modName;
            string path = Path.Combine(modPath, modd);

            path = Path.Combine(path, modd + ".dll");
            string newPath = path + ".RHLdisabled";
            Console.WriteLine($"Now disabling {modd}, new path will be {newPath}");
            if (MsgBox($"Are you sure you want to disable {modd}? This will restart the goose if it is running!", "Disabler", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                int geese = Process.GetProcessesByName("GooseDesktop").Count();
                toolStripMenuItem3_Click(sender, e);
                metroButton4_Click(sender, e);
                try {
                    if (File.Exists(path)) File.Move(path, newPath);
                    actualModButton.DisabledMod = true;
                    disableToolStripMenuItem1.Text = "Enable";
                    actualModButton.Refresh();
                } catch (Exception ex) {
                    MsgBox($"Error while disabling {modd}.\r\nError: {ex.Message}", "Disable error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                for (int i = 0; i < geese; i++) {
                    RunGoose_Click(sender, e);
                }
            }

        }

        private void installedModsContextMenu_Opening(object sender, CancelEventArgs e) {
            //if (enabledMods.SelectedIndex == -1) e.Cancel = true;
        }
        //to remove
        private void metroLabel3_Click(object sender, EventArgs e) {

        }
        //to remove
        private void metroButton1_Click_1(object sender, EventArgs e) {

        }

        private void metroButton2_Click_1(object sender, EventArgs e) {
            linksContextMenu.Show(Cursor.Position);

        }

        private void discordToolStripMenuItem_Click_1(object sender, EventArgs e) {
            if (MsgBox("This will open a link to the ResourceHub Discord server. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://discock.gg/rhl");
            }
        }

        private void githubToolStripMenuItem_Click_1(object sender, EventArgs e) {
            if (MsgBox("This will open a link to our GitHub repo. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher");
            }
        }
        private void twitterToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MsgBox("This will open a link to our Twitter account. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://twitter.com/dg_resource");
            }
        }

        //to remove
        private void MainForm_Resize(object sender, EventArgs e) {


        }
        //to remove
        private void metroPanel2_SizeChanged(object sender, EventArgs e) {

        }
        //to remove
        private void MainForm_SizeChanged(object sender, EventArgs e) {

        }
        //to remove
        private void listBox1_MouseUp(object sender, MouseEventArgs e) {

        }
        //to remove
        private void MainForm_MouseUp(object sender, MouseEventArgs e) {


        }
        //to remove
        private void MainForm_DragDrop(object sender, DragEventArgs e) {

        }

        private void MainForm_ResizeBegin(object sender, EventArgs e) {
            resizingPanel.Show();

        }

        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            resizingPanel.Hide();

        }

        private void metroButton3_Click(object sender, EventArgs e) {
            UtilitiesContextMenu.Show(Cursor.Position);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) {
            gooseToolStripMenuItem.Text = "Geese";
            Process.Start(Path.Combine(Config.getModPath(), Path.GetFileName((string)Config.Options["gpath"])));
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) {
            foreach (Process p in Process.GetProcessesByName("GooseDesktop")) {
                p.Kill();
                p.WaitForExit();
            }

            gooseToolStripMenuItem.Text = "Goose";
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e) {
            string modd = (string)mod["name"];
            string path = Path.Combine(modPath, modd);
            Process.Start("explorer.exe", path);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) {
            toolStripMenuItem1_Click(sender, e);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e) {
            disableToolStripMenuItem_Click(sender, e);
        }

        private void OptionsButton_Click(object sender, EventArgs e) {
            OptionsContextMenu.Show(Cursor.Position);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e) {
            Hide();

            new Settings().ShowDialog();

            Config.Theme(this);

            styleExtender.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleExtender.Style = (MetroColorStyle)(int)Config.Options["color"];
            modsButtons.ThemeChanged((int)Config.Options["theme"] == 1);
            Console.WriteLine((int)Config.Options["theme"] == 1);
            Show();
        }

        private void futureOfTheLauncherToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MsgBox("This will open a link to the list of upcoming features. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher/milestones");
            }
        }

        private void giveUsFeedbackToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MsgBox("This will open a link where you can send us feedback. A GitHub account is required. Do you want to proceed?", "Before you send feedback...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher/issues/new/choose");
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MsgBox("This will open a link where you will be taken to a README for the Launcher. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher#readme");
            }
        }

        private void changelogPanel_MouseDown(object sender, MouseEventArgs e) {
            changelogPanel.Hide();
        }

        private void label3_TextChanged(object sender, EventArgs e) {

        }

        

        private void debugButton_Click(object sender, EventArgs e) {
            Hide();

            
            new ModConfigForm().ShowDialog();
            Show();
        }

        private void disableToolStripMenuItem1_Click(object sender, EventArgs e) {
            if(actualModButton.InstalledMod) {
                openInModsToolStripMenuItem_Click(sender, e);
            } else {
                toolStripMenuItem5_Click(sender, e);
            }
        }

        private void openInModsToolStripMenuItem1_Click(object sender, EventArgs e) {
            disableToolStripMenuItem_Click(sender, e);
        }

        private void configureModToolStripMenuItem_Click(object sender, EventArgs e) {
            Assembly configurator = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"], "Configurator.dll"));
            
            foreach (Type type in configurator.GetTypes()) {
                if (type.GetInterface("ConfiguratorBasic") != null) {
                    ConfiguratorBasic configuratorIns = (ConfiguratorBasic)Activator.CreateInstance(type);
                    modName = (string)mod["name"];
                    actualModPath = Path.Combine(modPath, actualModButton.modName);
                    Hide();
                    new ModConfigForm(configuratorIns).ShowDialog();
                    Show();

                }
            }
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e) {
            metroPanel2.VerticalScroll.Value = 0;
            if (installedToolStripMenuItem.Checked) {
                installedToolStripMenuItem.ForeColor = Color.FromArgb(0, 170, 0);
                modsButtons.ShowOnly((B) => { return (B.InstalledMod&& installedToolStripMenuItem.Checked) || (B.DisabledMod&& disabledToolStripMenuItem.Checked) ||(B.AvailableMod && availableToolStripMenuItem.Checked); });
            } 
            else {
                installedToolStripMenuItem.ForeColor = Color.FromArgb(170, 0, 0);
                modsButtons.ShowOnly((B) => { return (B.InstalledMod && installedToolStripMenuItem.Checked) || (B.DisabledMod && disabledToolStripMenuItem.Checked) || (B.AvailableMod && availableToolStripMenuItem.Checked); });
            }
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e) {
            metroPanel2.VerticalScroll.Value = 0;
            if (disabledToolStripMenuItem.Checked) {
                disabledToolStripMenuItem.ForeColor = Color.FromArgb(0, 170, 0);
                modsButtons.ShowOnly((B) => { return (B.InstalledMod && installedToolStripMenuItem.Checked) || (B.DisabledMod && disabledToolStripMenuItem.Checked) || (B.AvailableMod && availableToolStripMenuItem.Checked); });
            } else {
                disabledToolStripMenuItem.ForeColor = Color.FromArgb(170, 0, 0);
                modsButtons.ShowOnly((B) => { return (B.InstalledMod && installedToolStripMenuItem.Checked) || (B.DisabledMod && disabledToolStripMenuItem.Checked) || (B.AvailableMod && availableToolStripMenuItem.Checked); });
            }
        }

        private void availableToolStripMenuItem_Click(object sender, EventArgs e) {
            metroPanel2.VerticalScroll.Value = 0;
            if (availableToolStripMenuItem.Checked) {
                availableToolStripMenuItem.ForeColor = Color.FromArgb(0, 170, 0);
                modsButtons.ShowOnly((B) => { return (B.InstalledMod && installedToolStripMenuItem.Checked) || (B.DisabledMod && disabledToolStripMenuItem.Checked) || (B.AvailableMod && availableToolStripMenuItem.Checked); });
            } else {
                availableToolStripMenuItem.ForeColor = Color.FromArgb(170, 0, 0);
                modsButtons.ShowOnly((B) => { return (B.InstalledMod && installedToolStripMenuItem.Checked) || (B.DisabledMod && disabledToolStripMenuItem.Checked) || (B.AvailableMod && availableToolStripMenuItem.Checked); });
            }
        }

        private void ShowedModsMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }
    }
}