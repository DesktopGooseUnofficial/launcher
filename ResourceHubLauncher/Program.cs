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

        public static bool CheckForInternetConnection() {
            try {
                new WebClient().OpenRead("http://rhl.my.to/");
                return true;
            } catch {
                return false;
            }
        }

        public static void RestartForm(MainForm form) {
            form.Hide();
            form.Dispose();
            form.Close();
            Application.Restart();

        }
            
        public static void Start(Loading loading) {
            Uri dat = new Uri("http://rhl.my.to/data");
            using (WebClient wc = new WebClient()) {

                wc.DownloadStringAsync(dat);
                wc.DownloadProgressChanged += (object s, DownloadProgressChangedEventArgs r) => {
                    loading.progress.Value = r.ProgressPercentage;
                };


                wc.DownloadStringCompleted += (object s, DownloadStringCompletedEventArgs r) => {
                    JObject data = JObject.Parse(r.Result);

                    string latest = data["app"]["md5"].ToString();

                    MainForm form = new MainForm(RestartForm);

                    





                    form.results = data["mods"].Children().ToList();

                    byte[] hash = MD5.Create().ComputeHash(File.ReadAllBytes(Application.ExecutablePath));

                    StringBuilder md5 = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++) {
                        md5.Append(hash[i].ToString("X2"));
                    }

                    Console.WriteLine("Checking launcher version...");

                    loading.Hide();
                    loading.Visible = false;
                    loading.Close();

                    if (latest != md5.ToString()) {
                        Console.WriteLine("Launcher is outdated. Prompting user if they want to update.");
                        if (MetroMessageBox.Show(form, $"This Launcher is out of date.\nWould you like to update it now?\n(For advanced users: MD5 {md5} does not match latest MD5: {latest})", "Auto-Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                            Process.Start("https://github.com/DesktopGooseUnofficial/launcher/releases/latest");
                            Environment.Exit(0);
                        }
                    } else {
                        Console.WriteLine("Launcher is up to date!");
                    }

                    if (_G.dev && MetroMessageBox.Show(form, "Copy Version MD5 to clipboard?", "Developer Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Clipboard.SetText(md5.ToString());

                    if ((string)Config.Options["gpath"] == "") {
                        if (MetroMessageBox.Show(form, "Select it!", "We couldn't find the Goose .exe file.", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
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
                            form.Focus();
                        }
                    }

                    Console.WriteLine("Showing main window.");

                    form.ShowDialog();
                };
            };

            loading.ShowDialog();
        }

        [STAThread]
        static void Main(string[] args) {
            Config.Load();

            var handle = GetConsoleWindow();

            if (!_G.dev) ShowWindow(handle, SW_HIDE);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Loading loading = new Loading();

            Console.Title = "ResourceHub Launcher // Developer Console";
            Console.WriteLine("Checking internet connection...");
            if (!CheckForInternetConnection()) {
                if (MessageBox.Show("Hmm... It doesn't look like you have any internet connection.\nThe ResourceHub Launcher cannot function properly without any internet connection.", "ResourceHub Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) {
                    return;
                }
            }

            Console.WriteLine("Getting latest data...");
            Start(loading);
        }
    }
}
