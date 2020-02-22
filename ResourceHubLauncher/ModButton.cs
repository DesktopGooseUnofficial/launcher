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
    enum ModSafety {
        Inapplicable = -1,
        Safe = 0,
        Moderate = 1,
        Unsafe = 2,
        Dangerous = 3
    }
    class ModButton : Control {
        public ModButton(string _modName, string modCategory, int _modSafety, ModButtonStates _modState) {
            container = new MetroPanel();
            modName = new MetroLabel();
            modSafety = new MetroLabel();
            modState = new MetroLabel();
            container.Size = new Size(177, 88);
            modName.Text = _modName;
            modName.Parent = container;
            modName.BackColor = Color.Transparent;
            modState.Parent = container;
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
                Color.Red
            };

            modSafety.Text = ((ModSafety)_modSafety).ToString();
            modSafety.Parent = container;
            modSafety.BackColor = safety[_modSafety];

            setLocation(new Point(0, 0));
            Controls.AddRange(new Control[] {
                container,
                modName,
                modSafety,
                modState
            });
            Config.Theme(Controls);
        }

        public void setLocation(Point newLocation) {
            container.Location = newLocation;
            modName.Location = new Point(newLocation.X + 10, newLocation.Y + 9);
            modState.Location = new Point(newLocation.X + 10, newLocation.Y + 59);
            modSafety.Location = new Point(newLocation.X + container.Size.Width - modSafety.Size.Width - 10, newLocation.Y + 59);
        }

        private MetroPanel container;
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