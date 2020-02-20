using MetroFramework;
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
using System.Threading;
using System.Windows.Forms;

namespace ResourceHubLauncher {
    static class Program {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        [STAThread]
        static void Main(string[] args) {
            Config.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Loading loading = new Loading();

            var handle = GetConsoleWindow();

            if (!_G.dev) ShowWindow(handle, SW_HIDE);

            Console.Title = "ResourceHub Launcher // Developer Console";

            Console.WriteLine("Getting latest data...");

            Uri dat = new Uri("http://rhl.my.to/data");

            using (WebClient wc = new WebClient()) {
                wc.DownloadStringAsync(dat);
                wc.DownloadStringCompleted += (object s, DownloadStringCompletedEventArgs r) => {
                    JObject data = JObject.Parse(r.Result);

                    string latest = data["app"]["md5"].ToString();

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

                    loading.Close();

                    form.ShowDialog();
                };
            };

            loading.ShowDialog();
        }
    }
}
