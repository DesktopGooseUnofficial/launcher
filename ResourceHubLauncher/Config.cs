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
            Options["gpath"] = "";
            Options["cpath"] = "";
            Options["devmode"] = false;
        }

        public static string getModPath() {
            if ((string)Options["gpath"] == "") {
                MetroMessageBox.Show(new MainForm(), "Please set the Goose path in the Settings.", "Error 404: Goose not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                if (File.Exists((string)Options["gpath"])) {
                    return Path.GetDirectoryName((string)Options["gpath"]);
                } else {
                    MetroMessageBox.Show(new MainForm(), "The goose path you have set seems to be outdated.\r\n" +
                           "Please set the Goose path in the Settings.", "Error 404: Goose not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return "";
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
                } else if (c is MetroProgressSpinner) {
                    ((MetroProgressSpinner)c).Theme = (MetroThemeStyle)(int)Options["theme"];
                    ((MetroProgressSpinner)c).Style = (MetroColorStyle)(int)Options["color"];
                }
                c.Refresh();
            }

            form.Refresh();
        }
    }
}
