using MetroFramework.Controls;
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
    class ModButton {
        public ModButton(string _modName, int _modSafety, ModButtonStates _modState) {
            button = new MetroButton();
            modName = new MetroLabel();
            modSafety = new MetroLabel();
            modState = new MetroLabel();
            button.Size = new Size(177, 88);
            button.Text = "";
            button.Theme = MetroFramework.MetroThemeStyle.Dark;
            modName.Theme = MetroFramework.MetroThemeStyle.Dark;
            modSafety.Theme = MetroFramework.MetroThemeStyle.Dark;
            modState.Theme = MetroFramework.MetroThemeStyle.Dark;
            modName.Text = _modName;
            modName.Parent = button;
            modName.BackColor = Color.Transparent;
            modState.Parent = button;
            modState.BackColor = Color.Transparent;

            switch (_modState) {
                case ModButtonStates.Available:
                    modState.Text = "Available";
                    break;
                case ModButtonStates.Disabled:
                    modState.Text = "Disabled";
                    break;
                case ModButtonStates.Installed:
                    modState.Text = "Installed";
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
            modSafety.Parent = button;
            modSafety.BackColor = safety[_modSafety];

            setLocation(new Point(0, 0));
        }

        public void setLocation(Point newLocation) {
            button.Location = newLocation;
            modName.Location = new Point(newLocation.X + 10, newLocation.Y + 9);
            modState.Location = new Point(newLocation.X + 10, newLocation.Y + 59);
            modSafety.Location = new Point(newLocation.X + button.Size.Width - modSafety.Size.Width - 10, newLocation.Y + 59);


        }

        private MetroButton button;
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
