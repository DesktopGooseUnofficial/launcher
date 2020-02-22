using MetroFramework.Controls;
using MetroFramework;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ResourceHubLauncher {

    enum ModButtonStates {
        Installed,
        Disabled,
        Available
    }

    class ModButton : MetroPanel {
        public ModButton(string _modName, string modCategory, int _modSafety, ModButtonStates _modState) {
            modName = new MetroLabel();
            modSafety = new MetroLabel();
            modState = new MetroLabel();
            Size = new Size(177, 88);
            modName.Text = _modName;
            modName.Parent = this;
            modName.BackColor = Color.Transparent;
            modState.Parent = this;
            modState.BackColor = Color.Transparent;

            switch (_modState) {
                case ModButtonStates.Available:
                    modState.Text = "Available";
                    modState.ForeColor = Color.DodgerBlue;
                    break;
                case ModButtonStates.Disabled:
                    modState.Text = "Disabled";
                    modState.ForeColor = Color.Red;
                    break;
                case ModButtonStates.Installed:
                    modState.Text = "Installed";
                    modState.ForeColor = Color.Green;
                    break;
                default:
                    break;
            }

            Color[] safety = {
                Color.Gray,
                Color.Green,
                Color.Orange,
                Color.OrangeRed,
                Color.Red
            };

            switch(_modSafety) {
                case -1:
                    modSafety.Text = "Inapplicable";
                    break;
                case 0:
                    modSafety.Text = "Safe";
                    break;
                case 1:
                    modSafety.Text = "Medium";
                    break;
                case 2:
                    modSafety.Text = "Unsafe";
                    break;
                case 3:
                    modSafety.Text = "Dangerous";
                    break;
                default:
                    modSafety.Text = "N/A";
                    break;
            }
            modSafety.Parent = this;
            modSafety.BackColor = safety[_modSafety + 1];

            setLocation(new Point(100, 100));
            BringToFront();
            Controls.AddRange(new Control[] {
                modName,
                modSafety,
                modState
            });
            Config.Theme(Controls);
            Theme = MetroThemeStyle.Light;
        }

        public void setLocation(Point newLocation) {
            Location = newLocation;
            modName.Location = new Point(newLocation.X + 10, newLocation.Y + 9);
            modState.Location = new Point(newLocation.X + 10, newLocation.Y + 59);
            modSafety.Location = new Point(newLocation.X + Size.Width - modSafety.Size.Width - 10, newLocation.Y + 59);
        }

        private MetroLabel modName;
        private MetroLabel modSafety;
        private MetroLabel modState;
    }

    class ModButtonList {
        public List<ModButton> list;
        Point latestAddedPos = new Point(0, -88);
        Point Location = new Point(0, 0);
        public ModButtonList() {
            list = new List<ModButton>();
        }

        public void Add(ModButton mod) {
            mod.setLocation(new Point(Location.X, Location.Y + latestAddedPos.Y + 88));
            list.Add(mod);

        }

        public void setLocation(Point newLocation) {
            Location = newLocation;
            int actualButton = 0;
            foreach (ModButton b in list) {
                b.setLocation(new Point(newLocation.X, newLocation.Y + 88 * actualButton));
                actualButton++;
            }
        }
    }
}