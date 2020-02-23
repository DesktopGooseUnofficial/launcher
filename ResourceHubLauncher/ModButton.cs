using MetroFramework.Controls;
using MetroFramework;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace ResourceHubLauncher {

    enum OldModButtonStates {
        Installed,
        Disabled,
        Available
    }

    class ModButton : MetroPanel {
        public Dictionary<string, dynamic> state = new Dictionary<string, dynamic>() {
            { "modName", "" },
            { "modType", "" },
            { "modSafety", 0 },
            { "modState", ModButtonStates.Available },
        };

        Color[] safety = {
            Color.Gray,
            Color.Green,
            Color.Orange,
            Color.OrangeRed,
            Color.Red
        };

        protected Font font = new Font("Segoe UI Light", 8f);

        public ModButton(string _modName, int _modSafety, ModButtonStates _modState, Func<string, bool> clickResult) {
            Size = new Size(177, 88);
            state["modName"] = _modName;
            state["modState"] = _modState;

            state["modSafety"] = _modSafety;


            Theme = modSafety.Theme;


            clickR = clickResult;

            MouseDown += button1_Click;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            string[] safetyR = {
                "Inapplicable",
                "Safe",
                "Medium",
                "Unsafe",
                "Dangerous"
            };
            
            string safetyText = safetyR[state["modSafety"] + 1];
            Color drawColor = safety[state["modSafety"] + 1];
            g.DrawString(safetyText, font, new SolidBrush(drawColor), 5, 5);
        }

        public void setLocation(Point newLocation) {
            Location = newLocation;
            modName.Location = new Point(newLocation.X + 10, newLocation.Y + 9);
            modState.Location = new Point(newLocation.X + 10, newLocation.Y + 59);
            modSafety.Location = new Point(newLocation.X + Size.Width - modSafety.Size.Width - 11, newLocation.Y + 59);
        }

        public void refreshParent(Control p) {
            modName.Parent = p;
            modSafety.Parent = p;
            modState.Parent = p;
        }

        public bool InstalledMod {
            get { return state["modState"] == ModButtonStates.Installed; }
            set {
                state["modState"] = value ? ModButtonStates.Installed : ModButtonStates.Available;
            }
        }

        public bool EnabledMod => true;



        private void button1_Click(object sender, System.EventArgs e) {
            clickR(modName.Text);

            ContextMenuStrip.Show(Cursor.Position);

        }

        public void changeContextMenu(ContextMenuStrip cMS) {
            ContextMenuStrip = cMS;
            modName.ContextMenuStrip = cMS;
            modSafety.ContextMenuStrip = cMS;
            modState.ContextMenuStrip = cMS;

        }

        Func<string, bool> clickR;

        public MetroLabel modName;
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