using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            MsgBox(mod["name"]);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("Are you sure you want to close ResourceHub Launcher?", "Hold up!", MessageBoxButtons.YesNo) != DialogResult.Yes;
        }

    }
}
