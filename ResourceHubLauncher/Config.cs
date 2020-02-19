using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ResourceHubLauncher {
    class Config {
        public static JObject Options = new JObject();
        private static string configPath = Path.Combine(Path.GetTempPath(), "..", "ResourceHub Launcher");
        public static string configFile = Path.Combine(configPath, "config.json");

        public static void Defaults() {
            Options["theme"] = 2;
            Options["color"] = 0;
            Options["gpath"] = "No Path Specified";
            Options["cpath"] = "No Path Specified";
            Options["devmode"] = false;
        }

        public static void Check() {
            if (!Directory.Exists(configPath)) Directory.CreateDirectory(configPath);
            if (!File.Exists(configFile)) Save(true);
        }

        public static void Load() {
            Check();
            Defaults();
            string data = File.ReadAllText(configFile);
            foreach(KeyValuePair<string, JToken> option in JObject.Parse(data)) {
                Options[option.Key] = option.Value;
            }
        }

        public static void Save(bool defaults = false) {
            if (!defaults) Check();
            if (defaults) Defaults();
            File.WriteAllText(configFile, Options.ToString());
        }

        public static void Theme(MetroForm form) {
            form.Theme = (MetroThemeStyle)(int)Options["theme"];
            form.Style = (MetroColorStyle)(int)Options["color"];

            foreach (Control c in form.Controls) {
                if (c is MetroButton) {
                    ((MetroButton)c).Theme = (MetroThemeStyle)(int)Options["theme"];
                    ((MetroButton)c).Style = (MetroColorStyle)(int)Options["color"];
                } else if (c is MetroLabel) {
                    ((MetroLabel)c).Theme = (MetroThemeStyle)(int)Options["theme"];
                    ((MetroLabel)c).Style = (MetroColorStyle)(int)Options["color"];
                } else if (c is MetroCheckBox) {
                    ((MetroCheckBox)c).Theme = (MetroThemeStyle)(int)Options["theme"];
                    ((MetroCheckBox)c).Style = (MetroColorStyle)(int)Options["color"];
                } else if (c is MetroTextBox) {
                    ((MetroTextBox)c).Theme = (MetroThemeStyle)(int)Options["theme"];
                    ((MetroTextBox)c).Style = (MetroColorStyle)(int)Options["color"];
                }
                c.Refresh();
            }

            form.Refresh();
        }
    }
}
