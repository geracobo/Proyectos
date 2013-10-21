using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace Proyectos
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            this.MainCanvas.Status += delegate(string status)
            {
                this.Status(status);
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.MainToolbar.Refresh();
        }

        private void AddActivityButton_Click(object sender, EventArgs e)
        {
            Node node = new Node();
            node.Origin = new Point(100, 100);
            this.MainCanvas.Nodes.Add(node);
            this.MainCanvas.Invalidate();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            this.Status("");
            this.MainCanvas.CalculateGraph();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            Image img = new Bitmap(this.MainCanvas.Width, this.MainCanvas.Height);
            Graphics gfx = Graphics.FromImage(img);
            this.MainCanvas.PaintCanvas(gfx);

            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult res = sfd.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return;

            img.Save(sfd.FileName);
        }



        private void Status(string status)
        {
            this.StatusLabel.Text = status;
        }

    }
}
