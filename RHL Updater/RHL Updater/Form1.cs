using MetroFramework;
using MetroFramework.Forms;
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
using System.Diagnostics;

namespace RHL_Updater {
    public partial class Form1 : MetroForm {


        bool download = false;

        public Form1() {
            InitializeComponent();
            Config.Load();
            Theme = (MetroThemeStyle)(int)Config.Options["theme"];
            Style = (MetroColorStyle)(int)Config.Options["color"];

        }

        private void Form1_Load(object sender, EventArgs e) {
            Config.Theme(this);
            if((bool)Config.Options["Beta"]) {
                Download(@"https://github.com/desktopgooseunofficial/launcher-nightly/releases/latest/download/ResourceHubLauncher.exe");
            } else {
                Download(@"https://github.com/desktopgooseunofficial/launcher/releases/latest/download/ResourceHubLauncher.exe");
            }
            
        }

        private string ReadableBytes(double len) {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1) {
                order++;
                len /= 1024;
            }

            return string.Format("{0:0.##} {1}", len, sizes[order]);
        }
        public void Download(string url) {
            


            using (WebClient wc = new WebClient()) {
                try {
                    Uri uri = new Uri(url);

                    string filePath = "ResourceHubLauncher.exe";

                    if (!download) {
                        string format = "{0} ({1}/{2})";

                        metroLabel1.Text = $"Preparing Launcher update";


                        metroProgressBar1.Value = 0;


                        download = true;
                        wc.DownloadFileAsync(uri, filePath);

                        wc.DownloadProgressChanged += (object _sender, DownloadProgressChangedEventArgs args) => {

                            metroProgressBar1.Value = args.ProgressPercentage;
                            metroLabel1.Text = string.Format(format, "Downloading...", ReadableBytes(args.BytesReceived), ReadableBytes(args.TotalBytesToReceive));
                            int v = metroLabel1.Text.Length;
                            Console.WriteLine(metroLabel1.Text.Substring(0, v - 1) + $" {args.ProgressPercentage}%)");

                        };

                        wc.DownloadFileCompleted += (object _sender, AsyncCompletedEventArgs args) => {
                            Process.Start("ResourceHubLauncher.exe");
                            Environment.Exit(0);
                        };

                    } else {
                        return;
                    }
                } catch (Exception ex) {
                    Environment.Exit(0);
                    return;
                }
            }
        }
    }
}
