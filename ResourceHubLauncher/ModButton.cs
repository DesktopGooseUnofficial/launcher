using MetroFramework.Controls;
using System.Drawing;

namespace ResourceHubLauncher {

    enum ModButtonStates {
        Installed,
        Disabled,
        Available
    }
    class ModButton {
        public ModButton(string modName_, string modSafetyName, int modSafetyLevel, ModButtonStates modState_) {
            button.Text = "";
            modName.Text = modName_;
            modName.Parent = button;
            modName.BackColor = Color.Transparent;
            modSafety.Text = modSafetyName;
            modSafety.Parent = button;
            modSafety.BackColor = Color.Transparent;
            modState.Parent = button;
            modState.BackColor = Color.Transparent;

            switch (modState_) {
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
        }

        public void setLocation(Point newLocation) {
            button.Location = newLocation;
        }
        //Change to metro things later
        private MetroButton button;

        private MetroLabel modName;
        private MetroLabel modSafety;
        private MetroLabel modState;
    }
}
