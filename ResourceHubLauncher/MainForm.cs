using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ResourceHubLauncher {
    public partial class MainForm : MetroForm {
        public IList<JToken> results = new List<JToken>();
        IList<JToken> mods = new List<JToken>();
        JObject data = new JObject();

        public MainForm() {
            InitializeComponent();
        }

        private DialogResult MsgBox(object text, string title = "ResourceHub Launcher", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1) {
            return MetroMessageBox.Show(this, text.ToString(), title, buttons, icon, defaultButton, 16 * text.ToString().Split('\r', '\n').Count());
        }

        private void MainForm_Load(object sender, EventArgs e) {
            foreach (JToken ok in results) {
                foreach(JToken mod in ok) {
                    mods.Add(mod);
                    otherMods.Items.Add(mod["name"]);
                }
            }
        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e) {
            JToken mod = mods[otherMods.SelectedIndex];
            MetroMessageBox.Show(this, "As such, downloading mods is not yet available.", "This is an early version of ResourceHub Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void resourceHubToolStripMenuItem_Click(object sender, EventArgs e) {
            JToken mod = mods[otherMods.SelectedIndex];
            Process.Start(mod["resourcehub"].ToString());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MetroMessageBox.Show(this, "Are you sure you want to close ResourceHub Launcher?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes;
        }

        private void ResourceHubPage_Click(object sender, EventArgs e)
        {
            if(MetroMessageBox.Show(this, "Are you sure you want to open the ResourceHub website?", "Hold up!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://desktopgooseunofficial.github.io/ResourceHub/");
            }
        }
    }
}
