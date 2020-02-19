using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ResourceHubLauncher {
    public partial class LoadingForm : MetroFramework.Forms.MetroForm {
        public LoadingForm(out dynamic loadedData, out List<string> enabledMods) {
            InitializeComponent();

            WebRequest request = WebRequest.Create("https://raw.githubusercontent.com/DesktopGooseUnofficial/launcher-backend/master/mods-test.json");
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data)) {
                html = sr.ReadToEnd();
            }

            dynamic array = JsonConvert.DeserializeObject(html);
            loadedData = array;

            if (!Directory.Exists("Disabled Mods"))
                Directory.CreateDirectory("Disabled Mods");

            if (!Directory.Exists("Mods"))
                Directory.CreateDirectory("Mods");

            string[] enabled = Directory.GetDirectories("Mods");
            enabled = enabled.Except(new string[] { "ResourceHubUpdater" }).ToArray();
            List<string> enabledNames = new List<string>();
            foreach (string element in enabled) {
                enabledNames.Add(Path.GetFileName(element));
            }
            enabledMods = enabledNames;
        }

        public LoadingForm() {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void LoadingForm_Load(object sender, EventArgs e) {

        }
    }
}
