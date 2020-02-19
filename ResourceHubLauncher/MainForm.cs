using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ResourceHubLauncher {
    public partial class MainForm : MetroForm {
        public IList<JToken> results = new List<JToken>();
        IList<JToken> mods = new List<JToken>();

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
                    otherMods.Items.Add(mod["name"]);
                }
            }
        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e) {
            JToken mod = mods[otherMods.SelectedIndex];
            MsgBox("As such, downloading mods is not yet available.", "This is an early version of ResourceHub Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void resourceHubToolStripMenuItem_Click(object sender, EventArgs e) {
            JToken mod = mods[otherMods.SelectedIndex];
            try {
                Process.Start(mod["resourcehub"].ToString());
            } catch (Exception ex) {
                MsgBox("Link for this mod is not available.", "Page opening error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if((string)Config.Options["gpath"] == "No Path Specified") {
                MsgBox("Please set the Goose path in the Settings.", "Error 404: Goose not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                if(File.Exists((string)Config.Options["gpath"])) {
                    Process.Start((string)Config.Options["gpath"]);
                } else {
                    MsgBox("The goose path you have set seems to be outdated.\r\n" +
                           "Please set the Goose path in the Settings.", "Error 404: Goose not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void otherMods_SelectedIndexChanged(object sender, EventArgs e) {
            JToken mod = mods[otherMods.SelectedIndex];

            label3.Text = (string)mod["description"];
        }

        private void metroButton2_Click(object sender, EventArgs e) {
            Process.Start("https://discord.gg/uyUMhW8");
        }

        private void metroButton3_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/DesktopGooseUnofficial/launcher");
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
    }
}
