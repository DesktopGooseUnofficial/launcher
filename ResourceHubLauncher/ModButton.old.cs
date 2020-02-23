using MetroFramework.Controls;
using MetroFramework;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace ResourceHubLauncher {

    enum ModButtonStates {
        Installed,
        Disabled,
        Available
    }




    class OldModButton : MetroPanel {
        public Dictionary<string, dynamic> state = new Dictionary<string, dynamic>() {
            { "modName", "" },
            { "modType", "" },
            { "modSafety", 0 },
            { "modState", 0 },
        };

        public OldModButton(string _modName, int _modSafety, ModButtonStates _modState, Func<string,bool> clickResult) {
            modName = new MetroLabel();
            modSafety = new MetroLabel();
            modState = new MetroLabel();
            Size = new Size(177, 88);
            modName.Text = _modName;
            modName.Parent = this;
            //modName.BackColor = Color.Transparent;
            modState.Parent = this;
            //modState.BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            modState.UseCustomForeColor = true;
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
                    modSafety.Text = "Mod Loader";
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
            modSafety.UseCustomForeColor = true;
            modSafety.ForeColor = safety[_modSafety + 1];
            modName.AutoSize = true;
            modState.AutoSize = true;
            modSafety.AutoSize = true;
            setLocation(new Point(0, 0));
            BringToFront();
            Controls.AddRange(new Control[] {
                modName,
                modSafety,
                modState
            });
            modName.BringToFront();
            modState.BringToFront();
            modSafety.BringToFront();
            Config.Theme(Controls);

            Theme = modSafety.Theme;
            

            clickR = clickResult;

            MouseDown += button1_Click;//Why the heck this does not work? (Nothing happens on mouse click)
            modName.MouseDown += button1_Click;
            modSafety.MouseDown += button1_Click;
            modState.MouseDown += button1_Click;

            
        }

        public void setLocation(Point newLocation) {
            Location = newLocation;
            modName.Location = new Point(newLocation.X + 10, newLocation.Y + 9);
            modState.Location = new Point(newLocation.X + 10, newLocation.Y + 59);
            modSafety.Location = new Point(newLocation.X + Size.Width - modSafety.Size.Width-11, newLocation.Y + 59);
        }

        public void refreshParent(Control p) {
            modName.Parent = p;
            modSafety.Parent = p;
            modState.Parent = p;
        }

        public void ToFront() {
            modName.BringToFront();
            modSafety.BringToFront();
            modState.BringToFront();
        }
        
        

        public bool InstalledMod { get { return modState.Text == "Installed"; }
            set { if (value) {
                    modState.Text = "Installed";
                    modState.ForeColor = Color.Green;
                } else {
                    modState.Text = "Available";
                    modState.ForeColor = Color.DodgerBlue;
                } 
            } 
        }

        public bool EnabledMod {
            get { return modState.Text == "Installed"; }
            set {
                if (value) {
                    modState.Text = "Installed";
                    modState.ForeColor = Color.Green;
                } else {
                    modState.Text = "Disabled";
                    modState.ForeColor = Color.Red;
                }
            }
        }

        

        private void button1_Click(object sender, System.EventArgs e) {
            clickR(modName.Text);
            
            ContextMenuStrip.Show(Cursor.Position);
            
        }

        public void changeContextMenu(ContextMenuStrip cMS) {
            ContextMenuStrip = cMS;
            modName.ContextMenuStrip= cMS;
            modSafety.ContextMenuStrip = cMS;
            modState.ContextMenuStrip = cMS;

        }

        Func<string,bool> clickR;
        
        public MetroLabel modName;
        private MetroLabel modSafety;
        private MetroLabel modState;
    }

    class OldModButtonList {
        public List<ModButton> list;
        Point latestAddedPos = new Point(0, -88);
        Point Location = new Point(0, 0);
        public OldModButtonList() {
            list = new List<ModButton>();
        }

        public void Add(ModButton mod) {
            mod.setLocation(new Point(Location.X, Location.Y + latestAddedPos.Y + 88));
            latestAddedPos = new Point(latestAddedPos.X, latestAddedPos.Y + 88);
            list.Add(mod);
            
        }

        public void Remove(string modName) {
            list.RemoveAt(list.FindIndex(mod => mod.modName.Text == modName));
            RefreshLocation();
        }

        public ModButton Find(string modName) {
            return list.Find(mod => mod.modName.Text == modName);
        }
        public void setLocation(Point newLocation) {
            Location = newLocation;
            int actualButton = 0;
            foreach (ModButton b in list) {
                b.setLocation(new Point(newLocation.X, newLocation.Y + 88 * actualButton));
                actualButton++;
            }
        }

        public void RefreshLocation() {
            int actualButton = 0;
            foreach (ModButton b in list) {
                b.setLocation(new Point(Location.X, Location.Y + 88 * actualButton));
                actualButton++;
            }
        }
    }
}