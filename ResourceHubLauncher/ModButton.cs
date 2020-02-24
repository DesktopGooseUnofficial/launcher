using MetroFramework.Controls;
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

    class ModButton : MetroPanel {
        public Dictionary<string, dynamic> state = new Dictionary<string, dynamic>() {
            { "modName", "" },
            { "modType", "" },
            { "modSafety", 0 },
            { "modState", 0 },
        };

        string modName;
        string modSafety;
        Color modSafetyColor;
        string modState;
        Color modStateColor;
        protected Font font = new Font("Segoe UI Light", 10f);

        Action<string> clickR;

        public ModButton(string _modName, int _modSafety, ModButtonStates _modState, Action<string> clickResult) {
            
            Size = new Size(177, 88);
            modName = _modName;
            BorderStyle = BorderStyle.FixedSingle;
            switch (_modState) {
                case ModButtonStates.Available:
                    modState = "Available";
                    modStateColor = Color.DodgerBlue;
                    break;
                case ModButtonStates.Disabled:
                    modState = "Disabled";
                    modStateColor = Color.Red;
                    break;
                case ModButtonStates.Installed:
                    modState = "Installed";
                    modStateColor = Color.Green;
                    break;
                default:
                    break;
            }

            

            switch (_modSafety) {
                case -1:
                    modSafety = "Mod Loader";
                    modSafetyColor = Color.FromArgb(170,170,170);
                    break;
                case 0:
                    modSafety = "Safe";
                    modSafetyColor = Color.Green;
                    break;
                case 1:
                    modSafety = "Medium";
                    modSafetyColor = Color.Orange;
                    break;
                case 2:
                    modSafety = "Unsafe";
                    modSafetyColor = Color.OrangeRed;
                    break;
                case 3:
                    modSafety = "Dangerous";
                    modSafetyColor = Color.Red;
                    break;
                default:
                    modSafety = "N/A";
                    modSafetyColor = Color.FromArgb(170, 170, 170);
                    break;
            }
            


            setLocation(new Point(0, 0));
            BringToFront();






            clickR = clickResult;

            MouseDown += button1_Click;//Why the heck this does not work? (Nothing happens on mouse click)



        }

        public void setLocation(Point newLocation) {
            Location = newLocation;

        }

        override protected void OnPaint(PaintEventArgs e) {
            Graphics graph = e.Graphics;
            base.OnPaint(e);
            SolidBrush brush = new SolidBrush(Color.FromArgb(170, 170, 170));
            graph.DrawString(modName, font, brush, new Point(10, 9));
            brush = new SolidBrush(modStateColor);
            graph.DrawString(modState, font, brush, new Point(10, 59));
            brush = new SolidBrush(modSafetyColor);
            SizeF safetySize= graph.MeasureString(modSafety, font);
            graph.DrawString(modSafety, font, brush, new Point(Size.Width- ((int)safetySize.Width)-11, 59));
            GC.Collect();
        }



        public bool InstalledMod {
            get { return modState == "Installed"; }
            set {
                if (value) {
                    modState = "Installed";
                    modStateColor = Color.Green;
                } else {
                    modState = "Available";
                    modStateColor = Color.DodgerBlue;
                }
            }
        }

        public bool EnabledMod {
            get { return modState == "Installed"; }
            set {
                if (value) {
                    modState = "Installed";
                    modStateColor = Color.Green;
                } else {
                    modState = "Disabled";
                    modStateColor = Color.Red;
                }
            }
        }



        private void button1_Click(object sender, System.EventArgs e) {
            clickR(modName);

            ContextMenuStrip.Show(Cursor.Position);

        }

        public void changeContextMenu(ContextMenuStrip cMS) {
            ContextMenuStrip = cMS;
            

        }

        
        
        
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
            latestAddedPos = new Point(latestAddedPos.X, latestAddedPos.Y + 88);
            list.Add(mod);

        }

        public void Remove(string modName) {
            list.RemoveAt(list.FindIndex(mod => mod.state["modName"] == modName));
            RefreshLocation();
        }

        public ModButton Find(string modName) {
            return list.Find(mod => mod.state["modName"] == modName);
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