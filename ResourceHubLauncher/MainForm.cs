using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;

namespace ResourceHubLauncher {
    public partial class MainForm : MetroForm {
        public IList<JToken> results = new List<JToken>();
        IList<JToken> mods = new List<JToken>();
        bool download = false;

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
            foreach (JToken ok in results) {
                foreach (JToken mod in ok) {
                    mods.Add(mod);
                    otherMods.Items.Add(mod["name"] + " v" + mod["mod-version"]);
                }
            }
        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e) {
            JToken mod = mods[otherMods.SelectedIndex];
            string url = (string) mod["url"];
            using (WebClient wc = new WebClient()) {
                string f = Path.GetFileName((string)mod["url"]);
                try {
                    if(!download) {
                        download = true;
                        metroLabel1.Text = $"Installing {f}";
                        wc.DownloadFileAsync(new Uri(url), f);
                        wc.DownloadProgressChanged += (object _sender, DownloadProgressChangedEventArgs args) => {
                            metroProgressBar1.Value = args.ProgressPercentage;
                        };
                        wc.DownloadDataCompleted += (object _sender, DownloadDataCompletedEventArgs args) => {
                            metroLabel1.Hide();
                            metroProgressBar1.Hide();
                            download = false;
                        };
                    } else {
                        MsgBox("You already have a download in progress.", "Download error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch (Exception) {
                    download = false;
                    MsgBox("The download for this mod is not available or invalid.", "Download error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                enabledMods.Items.Add(Path.GetFileNameWithoutExtension(f));
                string ext = f.Substring(Path.GetFileNameWithoutExtension(f).Length + 1);
                string nme = f.Substring(f.Length - (ext.Length + 1));
                if (ext != "dll") {
                    MsgBox("This mod is not a DLL and therefore cannot be automatically installed.\r\n" + 
                           "Please manually install " + nme + ".", "Uh oh!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string dest = Path.Combine(Config.getModPath(), "Assets", "Mods", f);
                    File.Move(f, dest);
                    Process.Start("explorer.exe", "/select, " + Path.Combine(Config.getModPath(), "Assets", "Mods", f));
                } else {
                    string path = Path.Combine(Config.getModPath(), "Assets", "Mods", (string)mod["name"]);
                    if(!Directory.Exists(path)) Directory.CreateDirectory(path);
                    File.Move(f, Path.Combine(path, f));
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
            Process.Start(Path.Combine(Config.getModPath(), Path.GetFileName((string)Config.Options["gpath"])));
        }

        private void otherMods_SelectedIndexChanged(object sender, EventArgs e) {
            JToken mod = mods[otherMods.SelectedIndex];

            label3.Text = (string)mod["description"];
        }

        private void metroButton2_Click(object sender, EventArgs e) {
            if(MsgBox("This will open a discord.gg link to our Discord server. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://discord.gg/uyUMhW8");
            }
        }

        private void metroButton3_Click(object sender, EventArgs e) {
            if(MsgBox("This will open a github.com link to our GitHub repo. Do you want to proceed?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                Process.Start("https://github.com/DesktopGooseUnofficial/launcher");
            }
        }

        private void metroButton1_Click(object sender, EventArgs e) {
            Hide();
            new Settings().ShowDialog();
            Config.Theme(this);
            styleExtender.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleExtender.Style = (MetroColorStyle)(int)Config.Options["color"];
            Show();
        }

        private void modListContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            if (otherMods.SelectedIndex == -1) modListContextMenu.Close();
        }

        private void metroButton4_Click(object sender, EventArgs e) {
            foreach(Process p in Process.GetProcessesByName("GooseDesktop")) {
                p.Kill();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            string mod = enabledMods.SelectedItem.ToString();
            string path = Path.Combine(Config.getModPath(), "Assets", "Mods", mod);
            if (Directory.Exists(path)) Directory.Delete(path, true);
            enabledMods.Items.Remove(mod);
        }

        private void installedModsContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            if (enabledMods.SelectedIndex == -1) installedModsContextMenu.Close();
        }
    }
}
