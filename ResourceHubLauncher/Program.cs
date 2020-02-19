using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;


namespace ResourceHubLauncher {
    static class Program {
        [STAThread]
        static void Main() {

            WebRequest request = WebRequest.Create("https://raw.githubusercontent.com/DesktopGooseUnofficial/launcher-backend/master/data.json");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            string html = "";
            using (StreamReader sr = new StreamReader(stream)) {
                html = sr.ReadToEnd();
            }

            JObject data = JObject.Parse(html);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm form = new MainForm();
            form.results = data["mods"].Children().ToList();
            Application.Run(form);
        }
    }
}
