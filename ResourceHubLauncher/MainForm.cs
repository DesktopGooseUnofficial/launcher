using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceHubLauncher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void NonInstalled_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Installed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Disabled_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Uninstall_Click(object sender, EventArgs e)
        {

        }

        private void Enable_Click(object sender, EventArgs e)
        {

        }

        private void Disable_Click(object sender, EventArgs e)
        {

        }

        private void ResourceHubPage_Click(object sender, EventArgs e)
        {
            //TODO Add dialog box "Are you sure you want to open the ResourceHub page?" If yes, open page in user's web browser 

        }

        // stop user from exiting the launcher if they did not mean to

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close ResourceHub Launcher?", "Hold up!", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel=true;
            }
        }
    }
}
