using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Microsoft.CSharp;

namespace ResourceHubLauncher
{
    public partial class LoadingForm : Form
    {
        public LoadingForm(out dynamic loadedData, out List<string> enabledMods, out List<string> disabledMods)
        {
            InitializeComponent();

            WebRequest request = WebRequest.Create("https://raw.githubusercontent.com/DesktopGooseUnofficial/launcher-backend/master/mods-test.json");
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }

            dynamic array = JsonConvert.DeserializeObject(html);
            loadedData = array;
            Directory.CreateDirectory("\\Disabled Mods");
            string[] enabled= Directory.GetDirectories("\\Mods");
            enabled=enabled.Except(new string[]{ "ResourceHubUpdater" }).ToArray();
            List<string> enabledNames = new List<string>() ;
            foreach(string element in enabled)
            {
                if()
                enabledNames.Add( Path.GetFileName(element));
            }
            enabledMods = enabledNames;



        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
