using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Drawing;

namespace ResourceHubLauncher
{

    enum ModButtonStates
    {
        Installed,
        Disabled,
        Available
    }
    class ModButton
    {
        public ModButton(string modName_, string modSafetyName, int modSafetyLevel, ModButtonStates modState_, Image backgroundImage) {
            button.Text = "";
            modName.Text = modName_;
            modName.Parent = button;
            modName.BackColor = Color.Transparent;
            modSafety.Text = modSafetyName;
            modSafety.Parent = button;
            modSafety.BackColor = Color.Transparent;
            modState.Parent = button;
            modState.BackColor = Color.Transparent;
            button.BackgroundImage = backgroundImage;

            switch(modState_) {
                case ModButtonStates.Available:
                    modState.Text = "Available";
                    break;
                case ModButtonStates.Disabled:
                    modState.Text = "Disabled";
                    break;
                case ModButtonStates.Installed:
                    modState.Text = "Installed";
                    break;
            }
        }

        public void setLocation(Point newLocation) {
            button.Location = newLocation;
        }
        //Change to metro things later
        private  Button button;
        
        private Label modName;
        private Label modSafety;
        private Label modState;
    }
}
