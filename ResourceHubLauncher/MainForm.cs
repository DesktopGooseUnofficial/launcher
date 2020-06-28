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
using System.Reflection;
using RHL_Mod_Installer_API;
using Ionic.Zip;

namespace ResourceHubLauncher {
    public partial class MainForm : MetroForm {
        enum HtmlTagsToAdd {
            none = 0,
            b = 1,
            i = 2,
            u = 4,
            s = 8,
            m = 16,
            big = 32,
        }

        public IList<JToken> results = new List<JToken>();
        IList<JToken> mods = new List<JToken>();
        bool download = false;
        public static string modPath = "";
        JToken mod;
        ModButton actualModButton;
        ModButtonList modsButtons = new ModButtonList();
        bool closedSpecially = false;

        Action<MainForm> restartForm;

        RichTextHtml htmlTags = new RichTextHtml();
        public StringBuilder md5;

        public static MainForm thisForm;

        List<HtmlTagsToAdd> actualDescTags = new List<HtmlTagsToAdd>();

        bool descriptionMaking = false;

        public MainForm() {
            InitializeComponent();
            styleExtender.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleExtender.Style = (MetroColorStyle)(int)Config.Options["color"];
            thisForm = this;
        }

        public MainForm(Action<MainForm> restartForm_) {
            InitializeComponent();
            styleExtender.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleExtender.Style = (MetroColorStyle)(int)Config.Options["color"];
            restartForm = restartForm_;
            thisForm = this;
        }

        private DialogResult MsgBox(object text, string title = "ResourceHub Launcher", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1) {
            return MetroMessageBox.Show(this, text.ToString(), title, buttons, icon, defaultButton);
        }

        private void MainForm_Load(object sender, EventArgs e) {

            Console.WriteLine($"Loading MainForm");
            InitializeInstallerAPI();
            Console.WriteLine($"Installer API loaded");
            Console.WriteLine($"All APIs loaded");

            //loadingPanel.Location = new Point(0, 0);
            htmlTags.Add("b", "Segoe UI Light", 0, FontStyle.Bold);
            htmlTags.Add("i", "Segoe UI Light", 0, FontStyle.Italic);
            htmlTags.Add("u", "Segoe UI Light", 0, FontStyle.Underline);
            htmlTags.Add("s", "Segoe UI Light", 0, FontStyle.Strikeout);
            htmlTags.Add("m", "Segoe UI Light", 15f);
            htmlTags.Add("big", "Segoe UI Light", 18f);

            Console.WriteLine($"Html tags Loaded");

            if ((string)Config.Options["latestU"] != md5.ToString()) {
                Console.WriteLine($"User appears to have updated.\nDisplaying changelog...");
                htmlTags.Apply(ref changelogRichTextBox);
                changelogPanel.Location = new Point(0, 5);
                changelogPanel.Show();
                Config.Options["latestU"] = md5.ToString();
                Config.Save();
            }

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

                    modB.ThemeChanged((int)Config.Options["theme"] == 1);

                    modB.Visible = true;
                }
            }

            Console.WriteLine($"Now checking mods...");

            foreach (string pMod in Directory.GetDirectories(modPath)) {
                string modName = pMod.Substring(modPath.Length + 1);
                string datPath = Path.Combine(modPath, modName, "RHLInfo.json");
                int index = mods.ToList().FindIndex(m => (string)m["name"] == modName);
                if (index != -1) {
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

                } else {
                    ModButtonStates statee = File.Exists(Path.Combine(pMod, modName + ".dll.RHLdisabled")) ? ModButtonStates.Disabled : ModButtonStates.Installed;
                    ModButton newMod = new ModButton(modName, 0, statee, ModClick, ModHover);
                    metroPanel2.Controls.Add(newMod);
                    modsButtons.Add(newMod);
                    newMod.Parent = metroPanel2;
                    newMod.changeContextMenu(modListContextMenu);
                    if (statee == ModButtonStates.Installed) {
                        disableToolStripMenuItem1.Enabled = true;
                    } else {
                        disableToolStripMenuItem1.Enabled = false;
                    }
                    newMod.fromOutside = true;
                }
            }
            Config.Theme(this);
            modsButtons.ThemeChanged((int)Config.Options["theme"] == 1);
            UpdateTheme((int)Config.Options["theme"] == 1);

            if (Process.GetProcessesByName("GooseDesktop").Count() > 0) {
                gooseToolStripMenuItem.Text = "Geese";
            }

            htmlTags.Apply(ref label3);
        }

        private void UpdateTheme(bool lightTheme) {

            if (lightTheme) {
                toolStripMenuItem2.BackColor = Color.FromArgb(255, 255, 255);
                toolStripMenuItem2.ForeColor = Color.FromArgb(17, 17, 17);

                toolStripMenuItem3.BackColor = Color.FromArgb(255, 255, 255);
                toolStripMenuItem3.ForeColor = Color.FromArgb(17, 17, 17);

                toolStripMenuItem7.BackColor = Color.FromArgb(255, 255, 255);
                toolStripMenuItem7.ForeColor = Color.FromArgb(17, 17, 17);

                toolStripMenuItem8.BackColor = Color.FromArgb(255, 255, 255);
                toolStripMenuItem8.ForeColor = Color.FromArgb(17, 17, 17);

                githubToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
                githubToolStripMenuItem.ForeColor = Color.FromArgb(17, 17, 17);

                discordToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
                discordToolStripMenuItem.ForeColor = Color.FromArgb(17, 17, 17);

                installedToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
                disabledToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
                availableToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            } else {
                toolStripMenuItem2.BackColor = Color.FromArgb(17, 17, 17);
                toolStripMenuItem2.ForeColor = Color.FromArgb(170, 170, 170);

                toolStripMenuItem3.BackColor = Color.FromArgb(17, 17, 17);
                toolStripMenuItem3.ForeColor = Color.FromArgb(170, 170, 170);

                toolStripMenuItem7.BackColor = Color.FromArgb(17, 17, 17);
                toolStripMenuItem7.ForeColor = Color.FromArgb(170, 170, 170);

                toolStripMenuItem8.BackColor = Color.FromArgb(17, 17, 17);
                toolStripMenuItem8.ForeColor = Color.FromArgb(170, 170, 170);

                githubToolStripMenuItem.BackColor = Color.FromArgb(17, 17, 17);
                githubToolStripMenuItem.ForeColor = Color.FromArgb(170, 170, 170);

                discordToolStripMenuItem.BackColor = Color.FromArgb(17, 17, 17);
                discordToolStripMenuItem.ForeColor = Color.FromArgb(170, 170, 170);

                installedToolStripMenuItem.BackColor = Color.FromArgb(17, 17, 17);
                disabledToolStripMenuItem.BackColor = Color.FromArgb(17, 17, 17);
                availableToolStripMenuItem.BackColor = Color.FromArgb(17, 17, 17);
            }
            //toolStripMenuItem2;
            //toolStripMenuItem3;
            //toolStripMenuItem7;
            //toolStripMenuItem8;
            //githubToolStripMenuItem;
            //discordToolStripMenuItem;

            //installedToolStripMenuItem;
            //disabledToolStripMenuItem;
            //availableToolStripMenuItem;
        }

        private void UpdateDescTagList() {
            if (actualDescTags.Count < label3.Text.Length) {
                int howMuch = label3.Text.Length - actualDescTags.Count;
                for (int i = 0; i < howMuch; i++) {
                    actualDescTags.Add(HtmlTagsToAdd.none);
                }
            }
        }

        private void ApplyTagToDesc(HtmlTagsToAdd tagg, int start, int end) {
            for (int i = start; i < end; i++) {
                actualDescTags[i] = actualDescTags[i] | tagg;
            }
        }

        private void RemoveTagToDesc(HtmlTagsToAdd tagg, int start, int end) {
            for (int i = start; i < end; i++) {
                actualDescTags[i] = actualDescTags[i] & ~tagg;
            }
        }

        public static void OpenDescriptionPreview() {
            thisForm.OptionsButton.Hide();
            thisForm.descriptionButton.Show();
            thisForm.toolStrip1.Show();
            thisForm.label3.ReadOnly = false;
            thisForm.label3.Text = $"<big>{ModCreatorForm.thisForm.NameTextBox.Text}</big> 1.0 \nCreated by You\n\n";
            thisForm.htmlTags.Apply(ref thisForm.label3);
            thisForm.label3.SelectAll();
            thisForm.label3.SelectionProtected = true;
            thisForm.label3.Select(0, 0);
            thisForm.descriptionMaking = true;
        }

        void CloseDescriptionPreview() {
            OptionsButton.Show();
            descriptionButton.Hide();
            toolStrip1.Hide();
            label3.ReadOnly = true;
            label3.SelectAll();
            label3.SelectionProtected = false;
            label3.Select(0, 0);
            label3.Text = "<m>Hover or click on the mod buttons (in list on the left) to see mod descriptions.</m>\n\n<m>Click (on mod button) to see options! </m>";
            htmlTags.Apply(ref label3);
            descriptionMaking = false;
        }

        private void changeModDescription() {
            try {
                string description = (string)mod["description"];
                if (mod["description-debug"] != null) {
                    description = (string)mod["description-debug"];
                }
                label3.Text = $"<big>{(string)mod["name"]}</big> {(string)mod["mod-version"]} (Goose {(string)mod["goose-version"]}) \r\nCreated by {(string)mod["author"]} \r\n\r\n{description}";
                htmlTags.Apply(ref label3);

            } catch (Exception ex) {
                label3.Text = "Mod description cannot be found";
                Console.WriteLine($"Mod description cannot be found: {ex.Message}");
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
            if (mod != null) {
                if ((string)mod["resourcehub"] != null) {
                    resourceHubToolStripMenuItem.Enabled = true;
                } else {
                    resourceHubToolStripMenuItem.Enabled = false;
                }
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

            } else {
                installToolStripMenuItem.Text = "Install";
                disableToolStripMenuItem1.Enabled = false;
                openInModsToolStripMenuItem1.Enabled = false;
                resourceHubToolStripMenuItem.Enabled = true;
            }
        }

        private void ModHover(string actualMod) {
            mod = mods.ToList().Find(modd => (string)modd["name"] == actualMod);
            //actualModButton = modsButtons.Find(actualMod);
            changeModDescription();
        }

        private void metroButton6_Click(object sender, EventArgs e) {
            Console.WriteLine("Restarting form...");
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
            return Path.GetDirectoryName((string)Config.Options["gpath"]);
        }

        public static string GetModFolder() {
            return actualModPath;
        }

        public static void UnpackZip(string where) {
            if (where == Path.GetDirectoryName(actualModPath)) {
                if (Directory.Exists(actualModPath)) {
                    Directory.Delete(actualModPath, true);
                }
            } else {
                if (Directory.Exists(where)) {
                    Directory.Delete(where, true);
                }
            }

            try {
                using (ZipFile zip1 = ZipFile.Read(actualZipFilePath)) {
                    // here, we extract every entry, but we could extract conditionally
                    // based on entry name, size, date, checkbox status, etc.  
                    foreach (ZipEntry e in zip1) {
                        e.Extract(where, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Eror unpacking \"" + Path.GetFileName(where) + "\":\n" + ex.Message);
            }

        }

        private void InitializeInstallerAPI() {
            InstallerAPI.Functions functions = new InstallerAPI.Functions();
            functions.getGooseFolder = new InstallerAPI.Functions.GetGooseFolderFunction(GetGooseFolder);
            functions.getModFolder = new InstallerAPI.Functions.GetModFolderFunction(GetModFolder);
            functions.unpackZip = new InstallerAPI.Functions.UnpackZipFunction(UnpackZip);
            InstallerAPI.functions = functions;
        }

        List<JToken> queue = new List<JToken>();
        ModButton installModButton;//actualModButton = modsButtons.Find((string)mod["name"]);
        bool installing = false;

        enum downloadWhat {
            modFile,
            modInstaller,
            modConfigurator
        }

        void downloadFile(string url, downloadWhat what, string filePath, string modName, AsyncCompletedEventHandler afterDownload) {
            using (WebClient wc = new WebClient()) {

                string downloadingWhat = "";
                switch (what) {
                    case downloadWhat.modConfigurator:
                        downloadingWhat = "Configurator for ";
                        break;
                    case downloadWhat.modInstaller:
                        downloadingWhat = "Installer for ";
                        break;
                    case downloadWhat.modFile:
                        downloadingWhat = "main files for ";
                        break;
                }

                try {
                    Uri uri = new Uri(url);

                    string format = "Downloading " + downloadingWhat + "{0} ({1}/{2})";

                    metroLabel1.Text = $"Preparing to download {downloadingWhat} {(string)mod["name"]}";
                    CenterDownloadText();
                    DownloadPanel.Show();
                    metroProgressBar1.Value = 0;

                    wc.DownloadFileAsync(uri, filePath);
                    Console.WriteLine(filePath);

                    wc.DownloadProgressChanged += (object _sender, DownloadProgressChangedEventArgs args) => {

                        metroProgressBar1.Value = args.ProgressPercentage;
                        metroLabel1.Text = string.Format(format, modName, ReadableBytes(args.BytesReceived), ReadableBytes(args.TotalBytesToReceive));
                        int v = metroLabel1.Text.Length;
                        Console.WriteLine(metroLabel1.Text.Substring(0, v - 1) + $" {args.ProgressPercentage}%)");
                        CenterDownloadText();
                    };
                    wc.DownloadFileCompleted += afterDownload;

                } catch (Exception ex) {
                    Console.WriteLine($"Could not download {downloadingWhat} {(string)mod["name"]}: {ex.Message}");
                    download = false;
                    MsgBox("The download for this mod is not available or invalid.", "Download error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DownloadPanel.Hide();
                    return;
                }
            }
        }

        void DllDownloadEnd(object _sender, AsyncCompletedEventArgs args, JToken mod, ModButton actualModButton) {

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
                Console.WriteLine($"Failed to write to RHLInfo.json because of {ex.Message}");
                MsgBox($"Failed to write to RHLInfo.json", "RHLInfo.json error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            download = false;
            installing = false;
            UpdateButtons();
            ContinueInstalling();
        }

        void NoDllDownloadEnd(object _sender, AsyncCompletedEventArgs args, JToken mod, ModButton actualModButton) {

            string urlI = (string)mod["install-url"];
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"]);
            string f = Path.Combine(filePath, "Installer.dll");
            downloadFile(urlI, downloadWhat.modInstaller, f, (string)mod["name"], (object _sender2, AsyncCompletedEventArgs args2) => {
                if (!File.Exists(f)) {
                    Console.WriteLine("Installer doesn't exist.");
                    MsgBox($"Installer for mod cannot be opened, try installing mod again", "Installation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    download = false;
                    installing = false;
                    ContinueInstalling();
                    return;
                }
                if ((string)mod["config-url"] != null) {
                    string urlC = (string)mod["config-url"];

                    f = Path.Combine(filePath, "Configurator.dll");
                    downloadFile(urlC, downloadWhat.modConfigurator, f, (string)mod["name"], (object _sender3, AsyncCompletedEventArgs args3) => {
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

                        if (File.Exists(f)) {
                            string launcherModPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ModsFiles", (string)mod["name"]);
                            if (Directory.Exists(Path.Combine(launcherModPath, "Default"))) {
                                Directory.Delete(Path.Combine(launcherModPath, "Default"), true);
                            }

                        }

                        string dataPath = Path.Combine(modPath, (string)mod["name"]);

                        dataPath = Path.Combine(dataPath, "RHLInfo.json");
                        actualModButton.InstalledMod = true;

                        AfterInstallUpdate();
                        actualModButton.Refresh();

                        try {
                            if (!Directory.Exists(Path.GetDirectoryName(dataPath))) Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
                            if (!File.Exists(dataPath)) File.Create(dataPath).Close();
                            File.WriteAllText(dataPath, mod.ToString());
                        } catch (IOException ex) {
                            Console.WriteLine($"Couldn't write to RHLInfo.json because of {ex.Message}");
                            MsgBox($"Failed to write to RHLInfo.json", "RHLInfo.json error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        download = false;
                        installing = false;
                        UpdateButtons();
                        ContinueInstalling();
                    });
                } else {
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
                        Console.WriteLine($"Couldn't write to RHLInfo.json because of {ex.Message}");
                        MsgBox($"Failed to write to RHLInfo.json", "RHLInfo.json error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    download = false;
                    installing = false;
                    UpdateButtons();
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
            if (queue.Count > 0) {
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
                    Console.WriteLine("User has \"Allow Unsafe Mods\" disabled. Will not install.");
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
                downloadFile(url, downloadWhat.modFile, f, m, (object _sender, AsyncCompletedEventArgs args) => {
                    if (!d) {
                        NoDllDownloadEnd(_sender, args, mod, actualModButton);

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
            if (actualModButton.InstalledMod || actualModButton.DisabledMod) {
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
                    if (actualModButton.fromOutside) {
                        modsButtons.Remove(actualModButton.modName);
                    } else {
                        actualModButton.InstalledMod = false;
                        installToolStripMenuItem.Text = "Install";
                        actualModButton.Refresh();
                    }
                    UpdateButtons();
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
            if (MsgBox($"Are you sure you want to enable {modd}? This will restart goose if disabled!", "Enabler", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Console.WriteLine($"Now enabling {modd}, new path will be {newPath}");
                int geese = Process.GetProcessesByName("GooseDesktop").Count();
                toolStripMenuItem3_Click(sender, e);
                try {
                    if (File.Exists(path)) File.Move(path, newPath);
                    actualModButton.InstalledMod = true;
                    disableToolStripMenuItem1.Text = "Disable";
                    actualModButton.Refresh();
                    UpdateButtons();
                } catch (Exception ex) {
                    Console.WriteLine($"Failed to enable mod: {ex.Message}");
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
            if (MsgBox($"Are you sure you want to disable {modd}? This will restart the goose if it is running!", "Disabler", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Console.WriteLine($"Now disabling {modd}, new path will be {newPath}");
                int geese = Process.GetProcessesByName("GooseDesktop").Count();
                toolStripMenuItem3_Click(sender, e);
                metroButton4_Click(sender, e);
                try {
                    if (File.Exists(path)) File.Move(path, newPath);
                    actualModButton.DisabledMod = true;
                    disableToolStripMenuItem1.Text = "Enable";
                    actualModButton.Refresh();
                    UpdateButtons();
                } catch (Exception ex) {
                    Console.WriteLine($"Failed to disable mod: {ex.Message}");
                    MsgBox($"Error while disabling {modd}.", "Disable error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                for (int i = 0; i < geese; i++) {
                    RunGoose_Click(sender, e);
                }
            }

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
            string modd = actualModButton.modName;
            string path = Path.Combine(modPath, modd);
            Process.Start("explorer.exe", path);
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
            UpdateTheme((int)Config.Options["theme"] == 1);
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
            if (MsgBox("This will open a link where you will be taken to the README for the Launcher. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher#readme");
            }
        }

        private void changelogPanel_MouseDown(object sender, MouseEventArgs e) {
            changelogPanel.Hide();
        }

        private void disableToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (actualModButton.InstalledMod) {
                openInModsToolStripMenuItem_Click(sender, e);
            } else {
                toolStripMenuItem5_Click(sender, e);
            }
        }

        private void openInModsToolStripMenuItem1_Click(object sender, EventArgs e) {
            disableToolStripMenuItem_Click(sender, e);
        }

        private void UpdateButtonsChanged() {
            metroPanel2.VerticalScroll.Value = 0;
            modsButtons.ShowOnly((B) => { return (B.InstalledMod && installedToolStripMenuItem.Checked) || (B.DisabledMod && disabledToolStripMenuItem.Checked) || (B.AvailableMod && availableToolStripMenuItem.Checked); });
        }

        private void UpdateButtons() {
            UpdateButtonsChanged();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e) {

            if (installedToolStripMenuItem.Checked) {
                installedToolStripMenuItem.ForeColor = Color.FromArgb(0, 170, 0);
            } else {
                installedToolStripMenuItem.ForeColor = Color.FromArgb(170, 0, 0);
            }
            UpdateButtonsChanged();
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e) {
            if (disabledToolStripMenuItem.Checked) {
                disabledToolStripMenuItem.ForeColor = Color.FromArgb(0, 170, 0);
            } else {
                disabledToolStripMenuItem.ForeColor = Color.FromArgb(170, 0, 0);
            }
            UpdateButtonsChanged();
        }

        private void availableToolStripMenuItem_Click(object sender, EventArgs e) {
            if (availableToolStripMenuItem.Checked) {
                availableToolStripMenuItem.ForeColor = Color.FromArgb(0, 170, 0);
            } else {
                availableToolStripMenuItem.ForeColor = Color.FromArgb(170, 0, 0);
            }
            UpdateButtonsChanged();
        }

        private void ShowedModsMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }

        private void forModCreatorsToolStripMenuItem_Click(object sender, EventArgs e) {
            Hide();
            new ModCreatorForm().ShowDialog();
            Show();
        }

        private void AddToFontStyleDesc(FontStyle styleToAdd, int start, int end) {
            List<int> starts = new List<int>();
            List<int> ends = new List<int>();

            HtmlTagsToAdd latest = actualDescTags.First();
            starts.Add(start);
            for (int i = start + 1; i < end; i++) {
                if (actualDescTags[i] != latest) {
                    ends.Add(i - starts.Last());
                    starts.Add(i);

                }
                latest = actualDescTags[i];
            }
            ends.Add(end - starts.Last());
            for (int i = 0; i < starts.Count; i++) {
                label3.Select(starts[i], ends[i]);
                label3.SelectionFont = new Font(label3.SelectionFont.FontFamily, label3.SelectionFont.Size, styleToAdd | label3.SelectionFont.Style);
            }
            label3.Select(start, end - start);
        }

        private void RemoveFontStyleDesc(FontStyle styleToAdd, int start, int end) {
            List<int> starts = new List<int>();
            List<int> ends = new List<int>();

            HtmlTagsToAdd latest = actualDescTags.First();
            starts.Add(start);
            for (int i = start + 1; i < end; i++) {
                if (actualDescTags[i] != latest) {
                    ends.Add(i - starts.Last());
                    starts.Add(i);

                }
                latest = actualDescTags[i];
            }
            ends.Add(end - starts.Last());
            for (int i = 0; i < starts.Count; i++) {
                label3.Select(starts[i], ends[i]);
                label3.SelectionFont = new Font(label3.SelectionFont.FontFamily, label3.SelectionFont.Size, ~styleToAdd & label3.SelectionFont.Style);
            }
            label3.Select(start, end - start);
        }

        private void BoldToolButton_Click(object sender, EventArgs e) {
            UpdateDescTagList();
            if (label3.SelectionLength > 0) {
                if (BoldToolButton.Checked) {
                    ApplyTagToDesc(HtmlTagsToAdd.b, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                    AddToFontStyleDesc(FontStyle.Bold, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                } else {
                    RemoveFontStyleDesc(FontStyle.Bold, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                    RemoveTagToDesc(HtmlTagsToAdd.b, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                }
            }

        }

        private void ItalicToolButton_Click(object sender, EventArgs e) {

            UpdateDescTagList();
            if (label3.SelectionLength > 0) {
                if (ItalicToolButton.Checked) {
                    ApplyTagToDesc(HtmlTagsToAdd.i, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                    AddToFontStyleDesc(FontStyle.Italic, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                } else {
                    RemoveTagToDesc(HtmlTagsToAdd.i, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                    RemoveFontStyleDesc(FontStyle.Italic, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                }
            }

        }

        private void UnderlineToolButton_Click(object sender, EventArgs e) {
            UpdateDescTagList();
            if (label3.SelectionLength > 0) {
                if (UnderlineToolButton.Checked) {
                    ApplyTagToDesc(HtmlTagsToAdd.u, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                    AddToFontStyleDesc(FontStyle.Underline, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                } else {
                    RemoveTagToDesc(HtmlTagsToAdd.u, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                    RemoveFontStyleDesc(FontStyle.Underline, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                }
            }
        }

        private void StrikeoutToolButton_Click(object sender, EventArgs e) {
            UpdateDescTagList();
            if (label3.SelectionLength > 0) {
                if (StrikeoutToolButton.Checked) {
                    ApplyTagToDesc(HtmlTagsToAdd.s, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                    AddToFontStyleDesc(FontStyle.Strikeout, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                } else {
                    RemoveTagToDesc(HtmlTagsToAdd.s, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                    RemoveFontStyleDesc(FontStyle.Strikeout, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                }
            }
        }

        private string getHtmlStart(HtmlTagsToAdd tagsToAdd) {
            string toR = "";
            if ((~HtmlTagsToAdd.b & tagsToAdd) != tagsToAdd) {
                toR += "<b>";
            }
            if ((~HtmlTagsToAdd.i & tagsToAdd) != tagsToAdd) {
                toR += "<i>";
            }
            if ((~HtmlTagsToAdd.u & tagsToAdd) != tagsToAdd) {
                toR += "<u>";
            }
            if ((~HtmlTagsToAdd.s & tagsToAdd) != tagsToAdd) {
                toR += "<s>";
            }
            if ((~HtmlTagsToAdd.m & tagsToAdd) != tagsToAdd) {
                toR += "<m>";
            }
            if ((~HtmlTagsToAdd.big & tagsToAdd) != tagsToAdd) {
                toR += "<big>";
            }
            return toR;
        }

        private string getHtmlEnd(HtmlTagsToAdd tagsToAdd) {
            string toR = "";
            if ((~HtmlTagsToAdd.b & tagsToAdd) != tagsToAdd) {
                toR += "</b>";
            }
            if ((~HtmlTagsToAdd.i & tagsToAdd) != tagsToAdd) {
                toR += "</i>";
            }
            if ((~HtmlTagsToAdd.u & tagsToAdd) != tagsToAdd) {
                toR += "</u>";
            }
            if ((~HtmlTagsToAdd.s & tagsToAdd) != tagsToAdd) {
                toR += "</s>";
            }
            if ((~HtmlTagsToAdd.m & tagsToAdd) != tagsToAdd) {
                toR += "</m>";
            }
            if ((~HtmlTagsToAdd.big & tagsToAdd) != tagsToAdd) {
                toR += "</big>";
            }
            return toR;
        }

        private void toolStripMenuItem1_Click_2(object sender, EventArgs e) {
            UpdateDescTagList();

            int emptySize = $"{ModCreatorForm.thisForm.NameTextBox.Text} 1.0 \nCreated by You\n\n".Length;

            actualDescTags.Clear();
            for (int i = 0; i < emptySize; i++) {
                actualDescTags.Add(HtmlTagsToAdd.none);
            }

            for (int i = emptySize; i < thisForm.label3.Text.Length; i++) {
                thisForm.label3.Select(i, 1);

                HtmlTagsToAdd b = HtmlTagsToAdd.none;
                HtmlTagsToAdd ii = HtmlTagsToAdd.none;
                HtmlTagsToAdd u = HtmlTagsToAdd.none;
                HtmlTagsToAdd s = HtmlTagsToAdd.none;
                HtmlTagsToAdd m = HtmlTagsToAdd.none;
                HtmlTagsToAdd big = HtmlTagsToAdd.none;

                if (thisForm.label3.SelectionFont.Bold) {
                    b = HtmlTagsToAdd.b;
                }
                if (thisForm.label3.SelectionFont.Italic) {
                    ii = HtmlTagsToAdd.i;
                }
                if (thisForm.label3.SelectionFont.Underline) {
                    u = HtmlTagsToAdd.u;
                }
                if (thisForm.label3.SelectionFont.Strikeout) {
                    s = HtmlTagsToAdd.s;
                }

                switch (thisForm.label3.SelectionFont.Size) {
                    case 15:
                        m = HtmlTagsToAdd.m;
                        break;
                    case 18:
                        big = HtmlTagsToAdd.big;
                        break;
                }

                actualDescTags.Add(b | ii | u | s | m | big);
            }

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                if ((myStream = saveFileDialog1.OpenFile()) != null) {
                    myStream.Position = 0;
                    string beforeDesc = $"{ModCreatorForm.thisForm.NameTextBox.Text} 1.0\nCreated by You\n\n";
                    string description = label3.Text;
                    int addedSize = 0;

                    string toAdd = "";
                    toAdd = getHtmlStart(actualDescTags.First());
                    addedSize += toAdd.Length;
                    description = description.Insert(0, toAdd);
                    HtmlTagsToAdd latest = actualDescTags.First();
                    for (int i = 1; i < actualDescTags.Count - 1; i++) {
                        if (actualDescTags[i] != latest) {
                            toAdd = getHtmlEnd(latest);
                            toAdd += getHtmlStart(actualDescTags[i]);
                        }
                        description = description.Insert(i + addedSize, toAdd);
                        addedSize += toAdd.Length;
                        latest = actualDescTags[i];
                        toAdd = "";
                    }
                    toAdd = getHtmlEnd(actualDescTags.Last());
                    description += toAdd;

                    byte[] bytes = Encoding.ASCII.GetBytes(description.Substring(beforeDesc.Length + 1).Replace("\n", "\\" + "n"));
                    myStream.Write(bytes, 0, bytes.Length);
                    myStream.Close();
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e) {
            DescriptionContextMenu.Show(Cursor.Position);
        }

        private void label3_SelectionChanged(object sender, EventArgs e) {
            BoldToolButton.Checked = label3.SelectionFont.Bold;
            ItalicToolButton.Checked = label3.SelectionFont.Italic;
            UnderlineToolButton.Checked = label3.SelectionFont.Underline;
            StrikeoutToolButton.Checked = label3.SelectionFont.Strikeout;
            switch (label3.SelectionFont.Size) {

                case 15:
                    ActualTextSizeButton.Text = "Medium Size";
                    break;
                case 18:
                    ActualTextSizeButton.Text = "Big Size";
                    break;
                default:
                    ActualTextSizeButton.Text = "Normal Size";
                    break;
            }
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e) {
            Hide();
            CloseDescriptionPreview();
            new ModCreatorForm().ShowDialog();
            Show();
        }

        private void SetFontSizeDesc(float size, int start, int end) {
            List<int> starts = new List<int>();
            List<int> ends = new List<int>();

            HtmlTagsToAdd latest = actualDescTags.First();
            starts.Add(start);
            for (int i = start + 1; i < end; i++) {
                if (actualDescTags[i] != latest) {
                    ends.Add(i - starts.Last());
                    starts.Add(i);

                }
                latest = actualDescTags[i];
            }
            ends.Add(end - starts.Last());
            for (int i = 0; i < starts.Count; i++) {
                label3.Select(starts[i], ends[i]);
                label3.SelectionFont = new Font(label3.SelectionFont.FontFamily, size, label3.SelectionFont.Style);
            }
            label3.Select(start, end - start);
        }

        private void NormalSizeStripMenuItem_Click(object sender, EventArgs e) {
            UpdateDescTagList();
            if (label3.SelectionLength > 0) {
                ActualTextSizeButton.Text = "Normal Size";
                SetFontSizeDesc(11, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                RemoveTagToDesc(HtmlTagsToAdd.m, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                RemoveTagToDesc(HtmlTagsToAdd.big, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
            }
        }

        private void MediumSizeStripMenuItem_Click(object sender, EventArgs e) {
            UpdateDescTagList();
            if (label3.SelectionLength > 0) {
                ActualTextSizeButton.Text = "Medium Size";
                SetFontSizeDesc(15, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                ApplyTagToDesc(HtmlTagsToAdd.m, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                RemoveTagToDesc(HtmlTagsToAdd.big, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
            }
        }

        private void bigSizeToolStripMenuItem_Click(object sender, EventArgs e) {
            UpdateDescTagList();
            if (label3.SelectionLength > 0) {
                ActualTextSizeButton.Text = "Big Size";
                SetFontSizeDesc(18, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                ApplyTagToDesc(HtmlTagsToAdd.big, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
                RemoveTagToDesc(HtmlTagsToAdd.m, label3.SelectionStart, label3.SelectionStart + label3.SelectionLength);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                string fileData = File.ReadAllText(saveFileDialog1.FileName);
                thisForm.label3.SelectAll();
                thisForm.label3.SelectionProtected = false;
                thisForm.label3.Select(0, 0);
                thisForm.label3.Text = $"<big>{ModCreatorForm.thisForm.NameTextBox.Text}</big> 1.0 \nCreated by You\n\n{fileData.Replace("\\" + "n", "\n")}";
                thisForm.htmlTags.Apply(ref label3);

                int emptySize = $"{ModCreatorForm.thisForm.NameTextBox.Text} 1.0 \nCreated by You\n\n".Length;
                actualDescTags.Clear();
                for (int i = 0; i < emptySize; i++) {
                    actualDescTags.Add(HtmlTagsToAdd.none);
                }
                thisForm.label3.Select(0, emptySize);
                thisForm.label3.SelectionProtected = true;

                for (int i = emptySize; i < thisForm.label3.Text.Length; i++) {
                    thisForm.label3.Select(i, 1);

                    HtmlTagsToAdd b = HtmlTagsToAdd.none;
                    HtmlTagsToAdd ii = HtmlTagsToAdd.none;
                    HtmlTagsToAdd u = HtmlTagsToAdd.none;
                    HtmlTagsToAdd s = HtmlTagsToAdd.none;
                    HtmlTagsToAdd m = HtmlTagsToAdd.none;
                    HtmlTagsToAdd big = HtmlTagsToAdd.none;

                    if (thisForm.label3.SelectionFont.Bold) {
                        b = HtmlTagsToAdd.b;
                    }
                    if (thisForm.label3.SelectionFont.Italic) {
                        ii = HtmlTagsToAdd.i;
                    }
                    if (thisForm.label3.SelectionFont.Underline) {
                        u = HtmlTagsToAdd.u;
                    }
                    if (thisForm.label3.SelectionFont.Strikeout) {
                        s = HtmlTagsToAdd.s;
                    }

                    switch (thisForm.label3.SelectionFont.Size) {
                        case 15:
                            m = HtmlTagsToAdd.m;
                            break;
                        case 18:
                            big = HtmlTagsToAdd.big;
                            break;
                    }

                    actualDescTags.Add(b | ii | u | s | m | big);
                }
            }
        }

    }
}