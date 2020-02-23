using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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

            lightTheme.Checked = (int)Config.Options["theme"] != 2;
            allowUnsafe.Checked = (bool)Config.Options["unsfe"];

            Control.ControlCollection d = metroPanel2.Controls;

            for (int i = 0; i < colors.Count; i++) {
                Control[] a = d.Find($"colorPicker{i}", true);
                if (a.Length == 0) continue;
                Control c = a[0];
                c.BackColor = colors[i];
                int _ = i;
                c.Click += (object s, EventArgs e) => {
                    Config.Options["color"] = _;
                    Config.Options["theme"] = (int)Config.Options["theme"];
                    styleManager.Theme = (MetroThemeStyle)(int)Config.Options["theme"];
                    styleManager.Style = (MetroColorStyle)(int)Config.Options["color"];
                    Config.Save();
                    Config.Theme(this);
                };
            }

            goosePath.Text = Path.GetFileName((string)Config.Options["gpath"]);
            configPath.Text = Path.GetFileName((string)Config.Options["cpath"]);
        }

        private void Settings_Load(object sender, EventArgs e) {
            
        }

        private void lightTheme_CheckedChanged(object sender, EventArgs e) {
            Config.Save();
            Config.Load();
            Config.Options["color"] = (int)Config.Options["color"];
            Config.Options["theme"] = lightTheme.Checked ? 1 : 2;
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
            goosePath.Text = Path.GetFileName((string)Config.Options["gpath"]);
            Config.Save();
        }

        private void metroButton3_Click(object sender, EventArgs e) {
            configPathDialog.ShowDialog();
        }

        private void configPathDialog_FileOk(object sender, CancelEventArgs e) {
            Config.Options["cpath"] = configPathDialog.FileName;
            configPath.Text = Path.GetFileName((string)Config.Options["cpath"]);
            Config.Save();
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e) {

        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e) {
            Config.Options["unsfe"] = allowUnsafe.Checked;
            Config.Save();
        }
    }
}
