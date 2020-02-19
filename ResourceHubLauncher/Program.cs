using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ResourceHubLauncher
{
    static class Program
    {
        

        static void LoadData(out dynamic loadedData, out List<string> enabledMods, out List<string> disabledMods)
        {
            
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
            
            string[] disabled = Directory.GetDirectories("Disabled Mods");
            List<string> disabledNames = new List<string>();
            foreach (string element in disabled)
            {
                disabledNames.Add(Path.GetFileName(element));
            }
            disabledMods = disabledNames;
            
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dynamic loadedMods;
            List<string> enabledMods;
            List<string> disabledMods;
            

            
            LoadData(out loadedMods, out enabledMods, out disabledMods);


            Application.Run(new MainForm());
            
            
        }
    }
}
