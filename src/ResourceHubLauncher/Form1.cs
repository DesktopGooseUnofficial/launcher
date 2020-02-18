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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            //Add dialog box "Are you sure you want to open the ResourceHub page?"
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close ResourceHub Launcher?", "Resource Hub Launcher", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel=true;
            }
        }
    }
}
