using Seritool.Desktop.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seritool.Desktop {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            using (AboutBox aboutBox = new AboutBox()) {
                aboutBox.ShowDialog();
            }
        }

        private void toolStripLbl_navigator_close_Click(object sender, EventArgs e) {
            if (splitContainer_nav_prop.Panel2Collapsed) {
                splitContainer.Panel1Collapsed = true;
                return;
            }
            splitContainer_nav_prop.Panel1Collapsed = true;
        }
        private void toolStripLbl_prop_close_Click(object sender, EventArgs e) {
            if (splitContainer_nav_prop.Panel1Collapsed) {
                splitContainer.Panel1Collapsed = true;
                return;
            }
            splitContainer_nav_prop.Panel2Collapsed = true;
        }
        private void navigatorToolStripMenuItem_Click(object sender, EventArgs e) {
            if (splitContainer.Panel1Collapsed) {
                splitContainer.Panel1Collapsed = false;
                splitContainer_nav_prop.Panel2Collapsed = true;
            }
            splitContainer_nav_prop.Panel1Collapsed = false;
        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e) {
            if (splitContainer.Panel1Collapsed) {
                splitContainer.Panel1Collapsed = false;
                splitContainer_nav_prop.Panel1Collapsed = true;
            }
            splitContainer_nav_prop.Panel2Collapsed = false;
        }
    }
}
