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
            if (splitContainer.Panel1Collapsed){ return; }
            splitContainer.Panel1Collapsed = true;
        }

        private void navigatorToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!splitContainer.Panel1Collapsed) { return; }
            splitContainer.Panel1Collapsed = false;
        }
    }
}
