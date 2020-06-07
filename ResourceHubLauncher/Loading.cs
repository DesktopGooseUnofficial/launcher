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
            Config.Theme(this);
        }

        private void Loading_Load(object sender, EventArgs e) {
            Icon = Icon.FromHandle(Properties.Resources.RHLTSmall.GetHicon());
        }
    }
}
