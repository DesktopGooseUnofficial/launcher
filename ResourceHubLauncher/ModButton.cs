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
        Action<string, bool> hover;
        Action<string> click;

        public Dictionary<string, dynamic> state = new Dictionary<string, dynamic>() {
            { "modName", "" },
            { "modType", "" },
            { "modSafety", 0 },
            { "modState", ModButtonStates.Available },
            { "mouseOver", false },
            { "btnHover", false },
        };

        Color[] safety = {
            Color.Gray,
            Color.Green,
            Color.Orange,
            Color.OrangeRed,
            Color.Red
        };

        protected Font font = new Font("Segoe UI Light", 8f);

        public ModButton(string _modName, int _modSafety, ModButtonStates _modState, Action<string> click, Action<string, bool> hover) {
            Size = new Size(177, 88);
            Config.Theme(this);
            state["modName"] = _modName;
            state["modState"] = _modState;
            state["modSafety"] = _modSafety;

            this.click = click;
            this.hover = hover;

            Click += (object sender, EventArgs e) => {
                if(state["btnHover"]) {
                    click(state["modName"]);
                    ContextMenuStrip.Show(Cursor.Position);
                }
            };

            MouseEnter += (object sender, EventArgs e) => {
                this.hover(state["modName"], true);
                state["mouseOver"] = true;
            };

            MouseLeave += (object sender, EventArgs e) => {
                this.hover(state["modName"], false);
                state["mouseOver"] = false;
            };

            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (object sender, EventArgs e) => {
                Draw(CreateGraphics());
            };
            timer.Start();
        }

        public void Draw(Graphics g) {
            g.Clear(BackColor);

            string[] safetyR = {
                "Inapplicable",
                "Safe",
                "Medium",
                "Unsafe",
                "Dangerous"
            };

            Color[] states = {
                Color.Green,
                Color.Red,
                Color.DodgerBlue
            };

            if (state["mouseOver"] == true) {
                g.FillRectangle(new SolidBrush(Color.FromArgb(20, 255, 255, 255)), new Rectangle(new Point(0, 0), Size));
            }

            Color color = Color.FromArgb(200, 200, 200);
            Brush brush = new SolidBrush(color);
            Pen pen = new Pen(brush);
            Point curPos = PointToClient(Cursor.Position);

            g.DrawString(state["modName"], font, brush, 5, 5);

            float h1 = Size.Height;
            float w1 = Size.Width;

            g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(100, 255, 255, 255))), 0, h1 - 1, w1, h1 - 1);

            {
                string safetyText = safetyR[state["modSafety"] + 1];
                Color drawColor = safety[state["modSafety"] + 1];
                SizeF size = g.MeasureString(safetyText, font);

                g.DrawString(safetyText, font, new SolidBrush(drawColor), 5, h1 - size.Height - 5);
            }

            {
                string stateText = ((object)state["modState"]).ToString();
                SizeF size = g.MeasureString(stateText, font);

                float h2 = size.Height;
                float w2 = size.Width;

                g.DrawString(stateText, font, new SolidBrush(states[(int)state["modState"]]), w1 - w2 - 5, h1 - h2 - 21);
            }

            {
                string stateText = "";
                switch ((ModButtonStates)state["modState"]) {
                    case ModButtonStates.Installed:
                        stateText = "Uninstall";
                        break;
                    case ModButtonStates.Disabled:
                        stateText = "Enable";
                        break;
                    case ModButtonStates.Available:
                        stateText = "Install"; 
                        break;
                    default:
                        break;
                };
                SizeF size = g.MeasureString(stateText, font);

                float h2 = size.Height;
                float w2 = size.Width;

                Point pos = new Point((int)Math.Floor(w1 - w2 - 10), (int)Math.Floor(h1 - h2 - 5));
                size = new SizeF(w2 + 7, h2);
                Brush b = new SolidBrush(Color.FromArgb(20, 255, 255, 255));
                if (curPos.X > pos.X && curPos.Y > pos.Y && curPos.X - pos.X < size.Width && curPos.Y - pos.Y < size.Height) {
                    b = new SolidBrush(Color.FromArgb(60, 255, 255, 255));
                    state["btnHover"] = true;
                } else {
                    state["btnHover"] = false;
                }

                g.FillRectangle(b, new Rectangle(pos, size.ToSize()));
                g.DrawRectangle(pen, new Rectangle(pos, size.ToSize()));
                g.DrawString(stateText, font, brush, w1 - w2 - 6, h1 - h2 - 5);
            }

            GC.Collect();
        }

        public void setLocation(Point newLocation) {
            Location = newLocation;
        }

        public bool InstalledMod {
            get { return state["modState"] == ModButtonStates.Installed; }
            set {
                state["modState"] = value ? ModButtonStates.Installed : ModButtonStates.Available;
            }
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