using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceHubLauncher {
    public partial class Settings : MetroForm {
        List<Color> colors = new List<Color>() {
            Color.FromArgb(0, 0, 0, 0),
            MetroColors.Black,
            MetroColors.White,
            MetroColors.Silver,
            MetroColors.Blue,
            MetroColors.Green,
            MetroColors.Lime,
            MetroColors.Teal,
            MetroColors.Orange,
            MetroColors.Brown,
            MetroColors.Pink,
            MetroColors.Magenta,
            MetroColors.Purple,
            MetroColors.Red,
            MetroColors.Yellow
        };

        public Settings() {
            InitializeComponent();

            Config.Theme(this);

            styleManager.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleManager.Style = (MetroColorStyle)(int)Config.Options["color"];

            metroCheckBox1.Checked = (int)Config.Options["theme"] != 2;

            for(int i = 0; i < colors.Count; i++) {
                Control c = Controls[(Controls.Count - 1) - i];
                c.BackColor = colors[i];
                int _ = i;
                c.Click += (object s, EventArgs e) => {
                    Config.Save();
                    Config.Load();
                    Config.Options["color"] = _;
                    Config.Options["theme"] = (int)Config.Options["theme"];
                    styleManager.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
                    styleManager.Style = (MetroColorStyle)(int)Config.Options["color"];
                    Config.Save();
                    Config.Theme(this);
                };
            }

            metroTextBox1.Text = (string)Config.Options["gpath"];
            metroTextBox2.Text = (string)Config.Options["cpath"];
        }

        private void Settings_Load(object sender, EventArgs e) {
            
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e) {
            Config.Save();
            Config.Load();
            Config.Options["color"] = (int)Config.Options["color"];
            Config.Options["theme"] = metroCheckBox1.Checked ? 1 : 2;
            styleManager.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            styleManager.Style = (MetroColorStyle)(int)Config.Options["color"];
            Config.Save();
            Config.Theme(this);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e) {
            Config.Save();
        }

        private void metroButton1_Click(object sender, EventArgs e) {
            goosePathDialog.ShowDialog();
        }

        private void goosePathDialog_FileOk(object sender, CancelEventArgs e) {
            Config.Options["gpath"] = goosePathDialog.FileName;
            metroTextBox1.Text = (string)Config.Options["gpath"];
            Config.Save();
        }

        private void metroButton3_Click(object sender, EventArgs e) {
            configPathDialog.ShowDialog();
        }

        private void configPathDialog_FileOk(object sender, CancelEventArgs e) {
            Config.Options["cpath"] = configPathDialog.FileName;
            metroTextBox2.Text = (string)Config.Options["cpath"];
            Config.Save();
        }
    }
}
