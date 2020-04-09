﻿using MetroFramework;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ResourceHubLauncher {
    static class Program {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [STAThread]
        static void Main(string[] args) {
            Config.Load();

            var handle = GetConsoleWindow();

            if (!_G.dev) ShowWindow(handle, SW_HIDE);

            Console.WriteLine("Getting latest data...");

            WebRequest request = WebRequest.Create("https://raw.githubusercontent.com/DesktopGooseUnofficial/launcher-backend/master/data.json");
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            string html = "";
            using (StreamReader sr = new StreamReader(stream))
            {
                html = sr.ReadToEnd();
            }

            JObject data = JObject.Parse(html);

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

            Console.WriteLine("Checking launcher version...");

            if (latest != md5.ToString()) {
                Console.WriteLine("Launcher is outdated. Prompting user if they want to update.");
                if (MetroMessageBox.Show(form, $"Launcher out of date.\nWould you like to update now?\n(MD5 {md5} does not match latest MD5: {latest})", "Auto-Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                    Process.Start("https://github.com/DesktopGooseUnofficial/launcher/releases");
                    Environment.Exit(0);
                }
            } else {
                Console.WriteLine("Launcher is up to date!");
            }

            if (_G.dev && MetroMessageBox.Show(form, "Copy Version MD5 to clipboard?", "Developer Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Clipboard.SetText(md5.ToString());

            if ((string)Config.Options["gpath"] == "") {
                if (MetroMessageBox.Show(form, "Do you want to select it yourself?", "We couldn't find the Goose .exe file.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                    using (OpenFileDialog oFileDialog = new OpenFileDialog()) {
                        oFileDialog.InitialDirectory = @"C:\";
                        oFileDialog.Filter = "GooseDesktop.exe|GooseDesktop.exe";
                        oFileDialog.Title = "Select GooseDesktop.exe";
                        
                        oFileDialog.FileOk += (object sender, CancelEventArgs e) => {
                            if (e.Cancel) { return; }
                            Config.Options["gpath"] = oFileDialog.FileName;
                        };
                        oFileDialog.ShowDialog();
                    }
                }
            }

            Console.WriteLine("Showing main window.");

            Application.Run(form);
        }
    }
}
