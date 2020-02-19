using MetroFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ResourceHubLauncher {
    static class Program {
        [STAThread]
        static void Main() {
            Config.Load();

            WebRequest request = WebRequest.Create("https://raw.githubusercontent.com/DesktopGooseUnofficial/launcher-backend/master/data.json");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            string html = "";
            using (StreamReader sr = new StreamReader(stream))
            {
                html = sr.ReadToEnd();
            }

            JObject data = JObject.Parse(html);
            
            if (!Directory.Exists("Disabled Mods"))
                Directory.CreateDirectory("Disabled Mods");

            if (!Directory.Exists("Mods"))
                Directory.CreateDirectory("Mods");

            string latest = data["app"]["md5"].ToString();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm form = new MainForm();
            form.results = data["mods"].Children().ToList();

            byte[] hash = MD5.Create().ComputeHash(File.ReadAllBytes(Application.ExecutablePath));

            StringBuilder md5 = new StringBuilder();
            for (int i = 0; i < hash.Length; i++) {
                md5.Append(hash[i].ToString("X2"));
            }

            if (latest != md5.ToString()) {
                bool update = MetroMessageBox.Show(form, $"App out of date.\nWould you like to update now?\n({md5} != {latest})", "Auto-Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes;
                if (update) {
                    Process.Start("https://github.com/DesktopGooseUnofficial/launcher/releases");
                    Application.Exit();
                }
            }

            Application.Run(form);
        }
    }
}
