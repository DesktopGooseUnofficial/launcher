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

namespace ResourceHubLauncher {
    public partial class Loading : MetroForm {
        public Loading() {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e) {
            Config.Theme(this);
        }

        private void metroLabel1_Click_1(object sender, EventArgs e) {

        }

        private void metroProgressSpinner1_Click(object sender, EventArgs e) {

        }
    }
}
