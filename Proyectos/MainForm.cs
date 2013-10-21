using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

using System.IO;
using System.Xml.Linq;

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
            sfd.Filter = "Bitmap (*.bmp)|*.bmp|All files (*.*)|*.*";
            sfd.DefaultExt = "bmp";
            sfd.AddExtension = true;
            DialogResult res = sfd.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return;

            img.Save(sfd.FileName);
        }

        private void Status(string status)
        {
            this.StatusLabel.Text = status;
        }

        private void MenuNew_Click(object sender, EventArgs e)
        {
            this.MainCanvas.Nodes.Clear();
            this.MainCanvas.Invalidate();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.Filter = "Proyecto (*.proyect)|*.proyect|All files (*.*)|*.*";
            ofd.DefaultExt = "proyect";
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;

            DialogResult res = ofd.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return;

            this.MainCanvas.Nodes.Clear();

            XElement xml = XElement.Load(new StreamReader(ofd.FileName));
            foreach (XElement act in xml.Elements())
            {
                Node n = new Node();
                n.ActivityName = act.Attribute("Name").Value;
                n.ActivityTime = decimal.Parse(act.Attribute("Time").Value);

                int X = int.Parse(act.Attribute("X").Value);
                int Y = int.Parse(act.Attribute("Y").Value);
                n.Origin = new Point(X, Y);
                n.Radius = int.Parse(act.Attribute("Radius").Value);

                this.MainCanvas.Nodes.Add(n);
            }

            IEnumerable<Node> nodes_search;

            foreach (XElement act in xml.Elements())
            {
                Node node = (from n in this.MainCanvas.Nodes
                             where n.ActivityName == act.Attribute("Name").Value
                             select n).First();

                node.DependsOn.Clear();
                List<string> depstrs = new List<string>(act.Attribute("Dependencies").Value.Split(new char[] { ',' }));
                foreach (string str in depstrs)
                {
                    nodes_search = from n in this.MainCanvas.Nodes
                                   where n.ActivityName == str.Trim()
                                   select n;

                    node.DependsOn.AddRange(nodes_search);
                }
            }
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            XElement xml = new XElement("Proyect");

            foreach (Node n in this.MainCanvas.Nodes)
            {
                XElement nodexml = new XElement("Activity",
                    new XAttribute("Name", n.ActivityName),
                    new XAttribute("Time", n.ActivityTime),
                    new XAttribute("Dependencies", n.DependsOnString),
                    new XAttribute("X", n.Origin.X),
                    new XAttribute("Y", n.Origin.Y),
                    new XAttribute("Radius", n.Radius));

                xml.Add(nodexml);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Proyecto (*.proyect)|*.proyect|All files (*.*)|*.*";
            sfd.DefaultExt = "proyect";
            sfd.AddExtension = true;
            DialogResult res = sfd.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return;

            xml.Save(sfd.FileName);
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
