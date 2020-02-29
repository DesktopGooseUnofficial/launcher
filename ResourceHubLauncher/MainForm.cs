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


namespace ResourceHubLauncher {
    public partial class MainForm : MetroForm {
        public IList<JToken> results = new List<JToken>();
        IList<JToken> mods = new List<JToken>();
        bool download = false;
        string modPath = "";
        JToken mod;
        ModButton actualModButton;
        ModButtonList modsButtons= new ModButtonList();
        bool closedSpecially = false;
        Action<MainForm> restartForm;
        RichTextHtml htmlTags= new RichTextHtml();

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

            resizingPanel.BringToFront();
            resizingPanel.Hide();

            modPath = Path.Combine(Config.getModPath(), "Assets", "Mods");

            Icon = Icon.FromHandle(Properties.Resources.RHLTSmall.GetHicon());

            foreach (JToken ok in results) {
                foreach (JToken mod in ok) {
                    mods.Add(mod);
                    ModButton modB = new ModButton((string)mod["name"], (int)mod["level"], ModButtonStates.Available, ModClick,ModHover);
                    
                    Controls.Add(modB);
                    modB.Visible = false;
                    modsButtons.Add(modB);
                    
                    modB.Parent = metroPanel2;
                    modB.changeContextMenu(modListContextMenu);
                    

                    modB.Visible = true;
                }
            }

            foreach (string pMod in Directory.GetDirectories(modPath)) {
                string modName = pMod.Substring(modPath.Length + 1);
                string datPath = Path.Combine(modPath, "RHLInfo.json");
                JToken mod = mods.ToList().Find(m => (string)m["name"] == modName);
                if (File.Exists(datPath)) {
                    JObject data = JObject.Parse(File.ReadAllText(datPath));
                    if ((string)data["mod-version"] != (string)mod["mod-version"]) {
                        if (MsgBox($"{data["name"]} is outdated.\r\nWould you like to update?", "Mod Auto-Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                            installToolStripMenuItem_Click(sender, e);
                        }
                        continue;
                    }
                }
                ModButton foundObj = modsButtons.Find(modName);
                if(foundObj != null) {
                    Console.WriteLine($"The mod \"{modName}\" was successfully found in the list!");
                    if(File.Exists(Path.Combine( pMod, modName+".dll.RHLdisabled"))) {
                        foundObj.EnabledMod = false;
                        foundObj.changeContextMenu(disabledModsContextMenu);
                    } else {
                        foundObj.InstalledMod = true;
                        foundObj.changeContextMenu(installedModsContextMenu);
                    }
                    
                    
                } else {
                    ModButtonStates statee = File.Exists(Path.Combine(pMod, modName + ".dll.RHLdisabled")) ? ModButtonStates.Disabled : ModButtonStates.Installed;
                    ModButton newMod = new ModButton(modName, 0, statee, ModClick, ModHover);
                    metroPanel2.Controls.Add(newMod);
                    modsButtons.Add(newMod);
                    newMod.Parent = metroPanel2;
                    if(statee== ModButtonStates.Installed) {
                        newMod.changeContextMenu(installedModsContextMenu);
                    } else {
                        foundObj.changeContextMenu(disabledModsContextMenu);
                    }
                }
                
                
            }
            Config.Theme(this);
            modsButtons.ThemeChanged((int)Config.Options["theme"] == 1);

            pictureBox2.Image = Properties.Resources.RHLTSmall;

            if(Process.GetProcessesByName("GooseDesktop").Count()>0) {
                gooseToolStripMenuItem.Text = "Geese";
            }

            htmlTags.Add("b",  "Microsoft Sans Serif", 0, FontStyle.Bold);
            htmlTags.Add("i",  "Microsoft Sans Serif", 0, FontStyle.Italic);
            htmlTags.Add("u",  "Microsoft Sans Serif", 0, FontStyle.Underline);
            htmlTags.Add("s",  "Microsoft Sans Serif", 0, FontStyle.Strikeout);
            htmlTags.Add("m",  "Microsoft Sans Serif", 12f);
            htmlTags.Add("big", "Microsoft Sans Serif", 15f);


        }

        

        


        private void changeModDescription() {
            try {
                
                label3.Text = (string)mod["description"];
                htmlTags.Apply(ref label3);
                //label3.Select()

            } catch (Exception ex) {
                label3.Text = "Mod description cannot be found";
            }
        }

        
        private void ModClick(string actualMod) {
            mod = mods.ToList().Find(modd => (string)modd["name"] == actualMod);
            
            actualModButton = modsButtons.Find(actualMod);
            changeModDescription();
            
            
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
            metroLabel1.Location= new Point(((DownloadPanel.Size.Width - metroLabel1.Size.Width) / 2), metroLabel1.Location.Y);
        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e) {
             
            string url = (string)mod["url"];

            Console.WriteLine($"Downloading {(string)mod["name"]} from {url}");

            using (WebClient wc = new WebClient()) {
                try {
                    Uri uri = new Uri(url);

                    int l = (int)mod["level"];

                    if (l > 0) {
                        if (!(bool)Config.Options["unsfe"] && Log($"Mod is rated {r2s(l)}. Awaiting user confirmation.")) {
                            MsgBox($"This mod is rated as {r2s(l)} and will not be installed for your safety.\r\nIf you want to ignore this go into Settings and enable \"Allow Unsafe Mods\".", "Uh oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        } else if (Log($"Mod is rated {r2s(l)}. Awaiting user confirmation.") && MsgBox($"This mod is rated as {r2s(l)}.\r\nAre you sure you want to install it? Installing it may cause problems.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) {
                            return;
                        }
                    }
                    string n = Path.GetFileName(url);
                    string t = n.Substring(Path.GetFileNameWithoutExtension(n).Length + 1);
                    string m = (string)mod["name"];

                    bool d = t == "dll";

                    string filePath = modPath;
                    if (d) filePath = Path.Combine(filePath, (string)mod["name"]);

                    string f = Path.Combine(filePath, Path.GetFileName(url));
                    if (!Directory.Exists(Path.GetDirectoryName(f))) Directory.CreateDirectory(Path.GetDirectoryName(f));

                    if (!download) {
                        string format = "Installing {0} ({1}/{2})";

                        metroLabel1.Text = $"Preparing to install {(string)mod["name"]}";
                        CenterDownloadText();
                        DownloadPanel.Show();

                        metroProgressBar1.Value = 0;

                        if (actualModButton.InstalledMod && Log("Mod seems to already be installed; Prompting user if they still want to download.") && MsgBox($"This mod seems to already be installed.\r\nAre you sure you want to continue and download?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) {
                            DownloadPanel.Hide();
                            Console.WriteLine("Download cancelled by user.");
                            return;
                        }
                        download = true;
                        wc.DownloadFileAsync(uri, f);

                        wc.DownloadProgressChanged += (object _sender, DownloadProgressChangedEventArgs args) => {
                            
                            metroProgressBar1.Value = args.ProgressPercentage;
                            metroLabel1.Text = string.Format(format, m, ReadableBytes(args.BytesReceived), ReadableBytes(args.TotalBytesToReceive));
                            int v = metroLabel1.Text.Length;
                            Console.WriteLine(metroLabel1.Text.Substring(0, v - 1) + $" {args.ProgressPercentage}%)");
                            CenterDownloadText();
                        };

                        wc.DownloadFileCompleted += (object _sender, AsyncCompletedEventArgs args) => {
                            DownloadPanel.Hide();
                            if (!actualModButton.InstalledMod && Directory.Exists(filePath)) actualModButton.InstalledMod=true;

                            string dataPath = filePath;
                            actualModButton.InstalledMod=true;
                            actualModButton.changeContextMenu(installedModsContextMenu);
                            actualModButton.Refresh();
                            if (!d) {
                                dataPath = Path.Combine(filePath, (string)mod["name"]);
                                // TODO Add support for extracting ZIP files
                                MsgBox($"This mod is not a DLL and therefore cannot be automatically installed.\r\nPlease manually install {m}.", "Unable to automatically install.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (MsgBox("Should we open Explorer for you? (where we put the file, of course)", "One thing...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                                    Process.Start("explorer.exe", "/select, " + f);
                                }
                            }
                            dataPath = Path.Combine(dataPath, "RHLInfo.json");

                            try {
                                if (!Directory.Exists(Path.GetDirectoryName(dataPath))) Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
                                if (!File.Exists(dataPath)) File.Create(dataPath).Close();
                                File.WriteAllText(dataPath, mod.ToString());
                            }
                            catch(IOException ex) {
                                MsgBox($"Failed to write to RHLInfo.json\r\nError: {ex.Message}", "RHLInfo.json error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                            download = false;
                        };

                    } else {
                        MsgBox("You already have a download in progress. Please wait for it to finish.", "Download error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DownloadPanel.Hide();
                        return;
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Could not download {(string)mod["name"]}: {ex.Message}");
                    download = false;
                    MsgBox("The download for this mod is not available or invalid.", "Download error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DownloadPanel.Hide();
                    return;
                }
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
            if(!closedSpecially) {
                e.Cancel = MsgBox("Are you sure you want to close ResourceHub Launcher?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes;
            }
            
        }

        private void ResourceHubPage_Click(object sender, EventArgs e) {
            if (MsgBox("Are you sure you want to open the ResourceHub website?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://desktopgooseunofficial.github.io/ResourceHub/");
            }
        }

        private void RunGoose_Click(object sender, EventArgs e) {
            //TODO Change label to Start Geese on click (or if goosedesktop.exe is found running), change back to Start Goose on Stop Goose click
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
            if (MsgBox($"Are you sure you want to uninstall {modd}? This will erase all data in the Mods folder for {modd}!", "Uninstaller", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                int geese = Process.GetProcessesByName("GooseDesktop").Count();
                toolStripMenuItem3_Click(sender, e);
                metroButton4_Click(sender, e);
                try {
                    if (Directory.Exists(path)) Directory.Delete(path, true);
                    actualModButton.InstalledMod=false;
                    actualModButton.changeContextMenu(modListContextMenu);
                    actualModButton.Refresh();
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
            if(MsgBox($"Are you sure you want to enable {modd}? This will restart goose if disabled!", "Enabler", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                int geese = Process.GetProcessesByName("GooseDesktop").Count();
                toolStripMenuItem3_Click(sender, e);
                metroButton4_Click(sender, e);
                try {
                    if (File.Exists(path)) File.Move(path, newPath);
                    actualModButton.EnabledMod = true;
                    actualModButton.changeContextMenu(installedModsContextMenu);
                    actualModButton.Refresh();
                } catch(Exception ex) {
                    MsgBox($"Error while enabling {modd}.\r\nError: {ex.Message}", "Enable error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                for(int i = 0; i < geese; i++) {
                    RunGoose_Click(sender, e);
                }
            }
        }

        private void openInModsToolStripMenuItem_Click(object sender, EventArgs e) {
            string modd = actualModButton.modName;
            string path = Path.Combine(modPath, modd);

            path = Path.Combine(path, modd+".dll");
            string newPath = path + ".RHLdisabled";
            Console.WriteLine($"Now disabling {modd}, new path will be {newPath}");
            if (MsgBox($"Are you sure you want to disable {modd}? This will restart goose if enabled!", "Disabler", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                int geese = Process.GetProcessesByName("GooseDesktop").Count();
                toolStripMenuItem3_Click(sender, e);
                metroButton4_Click(sender, e);
                try {
                    if (File.Exists(path)) File.Move(path, newPath);
                    actualModButton.EnabledMod = false;
                    actualModButton.changeContextMenu(disabledModsContextMenu);
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

        private void metroLabel3_Click(object sender, EventArgs e) {

        }

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
            if (MsgBox("This will open a github.com link to our GitHub repo. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher");
            }
        }
        private void twitterToolStripMenuItem_Click(object sender, EventArgs e) {
            if(MsgBox("This will open a twitter.com link to our Twitter account. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
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
            if (MsgBox("This will open a GitHub link to our Upcoming Features. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher/milestones");
            }
        }

        private void giveUsFeedbackToolStripMenuItem_Click(object sender, EventArgs e) {
            if(MsgBox("This will open a GitHub link where you can send us feedback. A GitHub account is required. Do you want to proceed?", "Before you send feedback...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher/issues/new/choose");
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            if(MsgBox("This will open a GitHub link where you will be taken to a README. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher#readme");
            }
        }
    }
}
