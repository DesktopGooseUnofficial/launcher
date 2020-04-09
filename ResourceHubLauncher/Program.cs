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

namespace ResourceHubLauncher
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        public static bool CheckForInternetConnection() {
            try {
                new WebClient().OpenRead("https://example.com");
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

        public static void Start(Loading loading, string[] args) {
            Uri dat = new Uri("https://raw.githubusercontent.com/DesktopGooseUnofficial/launcher-backend/master/data.json");
            using (WebClient wc = new WebClient()) {

                wc.DownloadStringAsync(dat);
                wc.DownloadProgressChanged += (object s, DownloadProgressChangedEventArgs r) => {
                    loading.progress.Value = r.ProgressPercentage;
                };


                wc.DownloadStringCompleted += (object s, DownloadStringCompletedEventArgs r) => {
                    JObject data = JObject.Parse(r.Result);

                    string latest;
                    if (_G.beta) {
                        latest = data["app"]["md5Beta"].ToString();
                    } else {
                        latest = data["app"]["md5"].ToString();
                    }



                    MainForm form = new MainForm(RestartForm);

                    





                    form.results = data["mods"].Children().ToList();
                    /*
                    if (!_G.beta && !File.Exists("Updater.exe")) {
                        if (MetroMessageBox.Show(form, "This is an unstable build.\nAre you sure you want to proceed?\nLink for the latest stable build: https://github.com/DesktopGooseUnofficial/launcher/releases/latest \n When you will click "+'"'+"No"+'"'+ " File "+'"'+ "Latest Stable Build" + '"'+" will be created with that link easy to copy.", "Warming", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                            StreamWriter wr = new StreamWriter("Latest Stable Build.txt");
                            wr.WriteLine("https://github.com/DesktopGooseUnofficial/launcher/releases/latest");
                            wr.Close();
                            Environment.Exit(0);
                        }
                    }
                    */
                    byte[] hash = MD5.Create().ComputeHash(File.ReadAllBytes(Application.ExecutablePath));

                    StringBuilder md5 = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++) {
                        md5.Append(hash[i].ToString("X2"));
                    }

                    Console.WriteLine("Checking launcher version...");

                    loading.Hide();
                    loading.Visible = false;
                    loading.Close();
                    form.md5 = md5;
                    /*
                    if (latest != md5.ToString() && !_G.dev && _G.update) {
                        try {
                            Process.Start("Updater.exe");
                            Environment.Exit(0);
                        } catch (Exception) { 
                           if (MetroMessageBox.Show(form, "Oh no! The ResourceHub Launcher couldn't find Updater.exe\n\nTry reinstalling the Launcher.\nLink for the installer: *Insert link there*", "Auto-Updater", MessageBoxButtons.OK, MessageBoxIcon.Error)==DialogResult.OK) {
                                Environment.Exit(0);
                           }
                        }
                            
                    } else {
                        if(_G.dev || !_G.update) {
                            Console.WriteLine("Looks like the user doesn't want updates.");
                        } else {
                            Console.WriteLine("Launcher is up to date!");
                        }
                    }
                    */
                    if (_G.dev && MetroMessageBox.Show(form, "Copy Version MD5 to clipboard?", "Developer Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Clipboard.SetText(md5.ToString());

                    if ((string)Config.Options["gpath"] == "" || !File.Exists((string)Config.Options["gpath"])) {
                        if (MetroMessageBox.Show(form, "To start using the Launcher, you need to select the GooseDesktop.exe file. Press OK to do so now.", "Is it your first time using the Launcher?", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
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
                    string[] parts;
                    bool newConfigIni = false;
                    string configPath = Path.Combine(Path.GetDirectoryName((string)Config.Options["gpath"]), "config.ini");
                    using (StreamReader rrrr = new StreamReader(configPath)) {
                        parts = rrrr.ReadToEnd().Split('\n');
                        int partIndex = parts.ToList().FindIndex((line) => { return line.StartsWith("EnableMods"); });
                        if (parts[partIndex].Substring(11).ToLower() == "false") {
                            Console.WriteLine($"User has mods disabled. Asking if they want to enable...");
                            if (MetroMessageBox.Show(form, "Do you want to enable them?", "Your config.ini file says that mods should be disabled.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                                parts[partIndex] = parts[partIndex].Replace("False", "True");
                                newConfigIni = true;
                                form.Focus();
                            }
                        }
                    }
                    if (newConfigIni) {
                        using (StreamWriter wwww = new StreamWriter(configPath)) {
                            wwww.Flush();
                            string all = "";
                            foreach (string sss in parts) {
                                all += sss + '\n';
                            }
                            wwww.Write(all);
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

            Console.WriteLine("RESOURCEHUB LAUNCHER\nStarted!\n\n");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Loading loading = new Loading();

            Console.Title = "ResourceHub Launcher // Developer Console";
            Console.WriteLine("Checking internet connection...");
            if (!CheckForInternetConnection()) {
                Console.WriteLine("Didn't find any internet connection.");
                if (MessageBox.Show("Hmm... It doesn't look like you have any internet connection.\nThe ResourceHub Launcher cannot function properly without any internet connection.\nPlease try again when you do get an internet connection though!", "(☓‿‿☓)", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK) {
                    return;
                }
            }

            Console.WriteLine("Getting latest data...");
            Start(loading, args);
        }
    }
}