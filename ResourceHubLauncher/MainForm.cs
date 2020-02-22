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
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace ResourceHubLauncher {
    public partial class MainForm : MetroForm {
        public IList<JToken> results = new List<JToken>();
        IList<JToken> mods = new List<JToken>();
        bool download = false;
        string modPath = "";

        ModButton test = new ModButton("mod mod", "Mod Loader", 3, ModButtonStates.Available);

        public MainForm() {
            InitializeComponent();

            Config.Theme(this);

            styleExtender.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleExtender.Style = (MetroColorStyle)(int)Config.Options["color"];
        }

        private DialogResult MsgBox(object text, string title = "ResourceHub Launcher", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1) {
            return MetroMessageBox.Show(this, text.ToString(), title, buttons, icon, defaultButton);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            modPath = Path.Combine(Config.getModPath(), "Assets", "Mods");

            Icon = Icon.FromHandle(Properties.Resources.RHLTSmall.GetHicon());

            foreach (JToken ok in results) {
                foreach (JToken mod in ok) {
                    mods.Add(mod);
                    otherMods.Items.Add(mod["name"]);
                }
            }

            foreach (string pMod in Directory.GetDirectories(modPath)) {
                string modName = pMod.Substring(modPath.Length + 1);
                string datPath = Path.Combine(modPath, "RHLInfo.json");
                JToken mod = mods.ToList().Find(m => (string)m["name"] == modName);
                if (File.Exists(datPath)) {
                    JObject data = JObject.Parse(File.ReadAllText(datPath));
                    if ((string)data["mod-version"] != (string)mod["mod-version"]) {
                        if (MsgBox($"{data["name"]} is outdated.\r\nWould you like to download the new version?", "Mod Auto-Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                            otherMods.SelectedItem = mod["name"];
                            installToolStripMenuItem_Click(sender, e);
                        }
                        continue;
                    }
                }
                enabledMods.Items.Add(modName);
            }
        }

        private void metroButton6_Click(object sender, EventArgs e) {
            metroButton6.Enabled = false;
            WebRequest request = WebRequest.Create("http://rhl.my.to/data");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            string html = "";
            using (StreamReader sr = new StreamReader(stream)) {
                html = sr.ReadToEnd();
            }

            JObject data = JObject.Parse(html);

            results = data["mods"].Children().ToList();

            mods.Clear();
            otherMods.Items.Clear();
            foreach (JToken ok in results) {
                foreach (JToken mod in ok) {
                    mods.Add(mod);
                    otherMods.Items.Add(mod["name"]);
                }
            }

            enabledMods.Items.Clear();
            foreach (string mod in Directory.GetDirectories(modPath)) {
                enabledMods.Items.Add(mod.Substring(modPath.Length + 1));
            }
            metroButton6.Enabled = true;
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

        private void installToolStripMenuItem_Click(object sender, EventArgs e) {
            JToken mod = mods[otherMods.SelectedIndex];
            string url = (string)mod["url"];

            Console.WriteLine($"Downloading {(string)mod["name"]} from {url}");

            using (WebClient wc = new WebClient()) {
                try {
                    Uri uri = new Uri(url);

                    int l = (int)mod["level"];

                    if (l > 0) {
                        if (!(bool)Config.Options["unsfe"] && Log($"Mod is rated {r2s(l)}. Awaiting user confirmation.")) {
                            MsgBox($"This mod is rated as {r2s(l)} and will not be installed.\r\nIf you want to ignore this go into Settigns and enable \"Allow Unsafe Mods\".", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        } else if (Log($"Mod is rated {r2s(l)}. Awaiting user confirmation.") && MsgBox($"This mod is rated as {r2s(l)}.\r\nAre you sure you want to install it?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) {
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
                        metroLabel1.Show();

                        metroProgressBar1.Value = 0;
                        if (enabledMods.Items.Contains(m) && Log("Mod seems to already be installed; Prompting user if they still want to download.") && MsgBox($"This mod seems to already be installed.\r\nAre you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) {
                            metroLabel1.Hide();
                            Console.WriteLine("Download cancelled by user.");
                            return;
                        }
                        modInfo.Size -= new Size(0, 16);
                        enabledMods.Size -= new Size(0, 16);
                        metroPanel1.Location = new Point(metroPanel1.Location.X, metroPanel1.Location.Y - 16);
                        download = true;
                        wc.DownloadFileAsync(uri, f);
                        wc.DownloadProgressChanged += (object _sender, DownloadProgressChangedEventArgs args) => {
                            metroProgressBar1.Show();
                            metroProgressBar1.Value = args.ProgressPercentage;
                            metroLabel1.Text = string.Format(format, m, ReadableBytes(args.BytesReceived), ReadableBytes(args.TotalBytesToReceive));
                            int v = metroLabel1.Text.Length;
                            Console.WriteLine(metroLabel1.Text.Substring(0, v - 1) + $" {args.ProgressPercentage}%)");
                        };
                        wc.DownloadFileCompleted += (object _sender, AsyncCompletedEventArgs args) => {
                            metroLabel1.Hide();
                            metroProgressBar1.Hide();

                            modInfo.Size += new Size(0, 16);
                            enabledMods.Size += new Size(0, 16);
                            metroPanel1.Location = new Point(metroPanel1.Location.X, metroPanel1.Location.Y + 16);

                            if (!enabledMods.Items.Contains(m) && Directory.Exists(filePath)) enabledMods.Items.Add(m);

                            string dataPath = filePath;
                            if (!d) {
                                dataPath = Path.Combine(filePath, (string)mod["name"]);
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
                        MsgBox("You already have a download in progress.", "Download error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        metroLabel1.Hide();
                        metroProgressBar1.Hide();
                        modInfo.Size += new Size(0, 16);
                        enabledMods.Size += new Size(0, 16);
                        metroPanel1.Location = new Point(metroPanel1.Location.X, metroPanel1.Location.Y + 16);
                        return;
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Could not download {(string)mod["name"]}: {ex.Message}");
                    download = false;
                    MsgBox("The download for this mod is not available or invalid.", "Download error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroLabel1.Hide();
                    metroProgressBar1.Hide();
                    modInfo.Size += new Size(0, 16);
                    enabledMods.Size += new Size(0, 16);
                    metroPanel1.Location = new Point(metroPanel1.Location.X, metroPanel1.Location.Y + 16);
                    return;
                }
            }
        }

        private void resourceHubToolStripMenuItem_Click(object sender, EventArgs e) {
            JToken mod = mods[otherMods.SelectedIndex];
            try {
                Process.Start(mod["resourcehub"].ToString());
            } catch (Exception) {
                MsgBox("The link for this mod is not available or invalid.", "Page opening error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = MsgBox("Are you sure you want to close ResourceHub Launcher?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes;
        }

        private void ResourceHubPage_Click(object sender, EventArgs e) {
            if (MsgBox("Are you sure you want to open the ResourceHub website?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://desktopgooseunofficial.github.io/ResourceHub/");
            }
        }

        private void RunGoose_Click(object sender, EventArgs e) {
            
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
            if (otherMods.SelectedIndex == -1) return;

            JToken mod = mods[otherMods.SelectedIndex];

            label3.Text = (string)mod["description"];

            modInfo.Items.Clear();
            modInfo.Items.Add("Category: " + mod["category"]);
            modInfo.Items.Add("Rating: " + r2s((int)mod["level"]));
        }

        private void metroButton2_Click(object sender, EventArgs e) {
            
        }

        private void metroButton3_Click(object sender, EventArgs e) {
            
        }

        private void metroButton1_Click(object sender, EventArgs e) {
            
        }

        private void modListContextMenu_Opening(object sender, CancelEventArgs e) {
            if (otherMods.SelectedIndex == -1) e.Cancel = true;
        }

        private void metroButton4_Click(object sender, EventArgs e) {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            string mod = enabledMods.SelectedItem.ToString();
            string path = Path.Combine(modPath, mod);
            if (MsgBox($"Are you sure you want to uninstall {mod}? This will erase all data in the Mods folder for {mod}!", "Uninstaller", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                int geese = Process.GetProcessesByName("GooseDesktop").Count();
                metroButton4_Click(sender, e);
                try {
                    if (Directory.Exists(path)) Directory.Delete(path, true);
                    enabledMods.Items.Remove(mod);
                    
                } catch (Exception ex) {
                    MsgBox($"Error while uninstalling {mod}.\r\nPlease make sure you have Desktop Goose closed.\r\nError: {ex.Message}", "Uninstall error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                for (int i = 0; i < geese; i++) {
                    RunGoose_Click(sender, e);
                }
            }
        }

        private void openInModsToolStripMenuItem_Click(object sender, EventArgs e) {
            string mod = enabledMods.SelectedItem.ToString();
            string path = Path.Combine(modPath, mod);
            Process.Start("explorer.exe", path);
        }

        private void installedModsContextMenu_Opening(object sender, CancelEventArgs e) {
            if (enabledMods.SelectedIndex == -1) e.Cancel = true;
        }

        private void metroLabel3_Click(object sender, EventArgs e) {

        }

        private void metroButton1_Click_1(object sender, EventArgs e) {
            Hide();
            new Settings().ShowDialog();
            Config.Theme(this);
            styleExtender.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleExtender.Style = (MetroColorStyle)(int)Config.Options["color"];
            Show();
        }

        private void metroButton2_Click_1(object sender, EventArgs e) {
            linksContextMenu.Show();
        }

        private void discordToolStripMenuItem_Click_1(object sender, EventArgs e) {
            if (MsgBox("This will open a discord.gg link to our Discord server. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://discock.gg/rhl");
            }
        }

        private void githubToolStripMenuItem_Click_1(object sender, EventArgs e) {
            if (MsgBox("This will open a github.com link to our GitHub repo. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher");
            }
        }
    }
}
