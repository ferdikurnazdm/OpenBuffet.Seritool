using Seritool.Application.Engine;
using Seritool.Desktop.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Seritool.Domain.Entities;

namespace Seritool.Desktop {
    public partial class MainForm : Form {
        #region PRIVATE_FIELDS
        private readonly SeritoolEngine _seritoolEngine;
        #endregion

        #region CONSTURCTOR
        public MainForm(SeritoolEngine seritoolEngine) {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            _seritoolEngine = seritoolEngine;
        }
        #endregion

        #region PROPERTIES
        public string AssemblyTitle {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0) {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "") {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        #endregion

        #region FORM_EVENTS
        private void MainForm_Load(object sender, EventArgs e) {
            Exception exception = null;
            string[] ports;
            if (!_seritoolEngine.SeriportManager.TryGetSeriports(out ports, out exception)) {
                MessageBox.Show(
                    text: exception.Message,
                    caption: AssemblyTitle,
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error,
                    defaultButton: MessageBoxDefaultButton.Button2,
                    options: 0,
                    helpFilePath: $"https://www.google.com/"
                    );
            }
            RefreshTreeview(ports);
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
        private void MainForm_ResizeBegin(object sender, EventArgs e) {
            this.SuspendLayout();
        }
        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            this.ResumeLayout(true);
        }
        private void treeView_navigator_AfterSelect(object sender, TreeViewEventArgs e) {
            treeView_navigator.BeginUpdate();
            TreeNode selectedNode = e.Node;
            TreeNode mainNode = treeView_navigator.Nodes[0];
            int nodeCount = mainNode.Nodes.Count;
            for (int i = 0; i < nodeCount; i++) {
                if (mainNode.Nodes[i] == selectedNode) {
                    if (!mainNode.Nodes[i].Text.EndsWith("(selected)")) {
                        mainNode.Nodes[i].Text = $"{selectedNode.Tag}(selected)";
                        mainNode.Nodes[i].ForeColor = Color.Green;
                        int portnameLength = selectedNode.Tag.ToString().Length;
                        string portNumberAsString = selectedNode
                            .Tag
                            .ToString()
                            .Substring(3, (portnameLength - 3));
                        int portNumber = int.Parse(portNumberAsString);
                        PortConfig portConfig;
                        Exception exception;
                        if (!_seritoolEngine.PortConfigManager.TryGetPortConfig(portNumber, out portConfig, out exception)) {
                            MessageBox.Show(
                                text: exception.Message,
                                caption: AssemblyTitle,
                                buttons: MessageBoxButtons.OK,
                                icon: MessageBoxIcon.Error,
                                defaultButton: MessageBoxDefaultButton.Button2,
                                options: 0,
                                helpFilePath: $"https://www.google.com/"
                                );
                            return;
                        }
                        propertyGrid.SelectedObject = portConfig;
                    }
                }
                else {
                    mainNode.Nodes[i].Text = mainNode.Nodes[i].Tag.ToString();
                    mainNode.Nodes[i].ForeColor = Color.Black;
                }
            }
            treeView_navigator.SelectedNode = null;
            treeView_navigator.EndUpdate();
        }
        private void Btn_ports_refresh_Click(object sender, EventArgs e) {
            Exception exception = null;
            string[] ports;
            if (!_seritoolEngine.SeriportManager.TryGetSeriports(out ports, out exception)) {
                MessageBox.Show(
                    text: exception.Message,
                    caption: AssemblyTitle,
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Error,
                    defaultButton: MessageBoxDefaultButton.Button2,
                    options: 0,
                    helpFilePath: $"https://www.google.com/"
                    );
            }
            RefreshTreeview(ports);
            _seritoolEngine.PortConfigManager.RefreshConfigs();
            propertyGrid.SelectedObject = null;
        }
        private void Btn_receive_clear_Click(object sender, EventArgs e) {
            richTextBox_receive.Clear();
        }
        private void Btn_transfer_clear_Click(object sender, EventArgs e) {
            richTextBox_transfer.Clear();
        }
        #endregion

        #region PRIVATE_METHODS
        private void RefreshTreeview(string[] ports) {
            treeView_navigator.Nodes.Clear();
            TreeNode mainNode = new TreeNode("Ports");
            mainNode.Tag = "Ports";
            Array.Sort(ports);
            int portsLength = ports.Length;
            for (int i = 0; i < portsLength; i++) {
                TreeNode portNode = new TreeNode(ports[i]);
                portNode.Tag = ports[i];
                mainNode.Nodes.Add(portNode);
            }
            treeView_navigator.Nodes.Add(mainNode);
            treeView_navigator.ExpandAll();
        }
        #endregion

    }
}
