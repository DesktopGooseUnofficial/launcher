using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ResourceHubLauncher {
    public partial class LoadingForm : MetroFramework.Forms.MetroForm {
        public LoadingForm() {
            InitializeComponent();
            
        }

        public void LoadData(out dynamic loadedData, out List<string> enabledMods, out List<string> disabledMods)
        {
            metroLabel1.Text = "Getting data from website.\nPlease wait...";
            WebRequest request = WebRequest.Create("https://raw.githubusercontent.com/DesktopGooseUnofficial/launcher-backend/master/data.json");
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }

            dynamic array = JsonConvert.DeserializeObject(html);
            loadedData = array;
            metroLabel1.Text = "Getting enabled mods.\nPlease wait...";
            if (!Directory.Exists("Disabled Mods"))
                Directory.CreateDirectory("Disabled Mods");

            if (!Directory.Exists("Mods"))
                Directory.CreateDirectory("Mods");

            string[] enabled = Directory.GetDirectories("Mods");
            enabled = enabled.Except(new string[] { "ResourceHubUpdater" }).ToArray();
            List<string> enabledNames = new List<string>();
            foreach (string element in enabled)
            {
                enabledNames.Add(Path.GetFileName(element));
            }
            enabledMods = enabledNames;
            metroLabel1.Text = "Getting disabled mods.\nPlease wait...";
            string[] disabled = Directory.GetDirectories("Disabled Mods");
            List<string> disabledNames = new List<string>();
            foreach (string element in disabled)
            {
                disabledNames.Add(Path.GetFileName(element));
            }
            disabledMods = disabledNames;
            this.Close();
        }


        private void progressBar1_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void LoadingForm_Load(object sender, EventArgs e) {

        }
    }
}
