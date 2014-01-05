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

            this.MainCanvas.OnRemove += delegate(object sender, EventArgs e)
            {
                UpdateTable();
            };
            this.MainCanvas.OnModify += delegate(object sender, EventArgs e)
            {
                UpdateTable();
            };
        }

        private void UpdateTable()
        {
            NodesTable.Rows.Clear();
            foreach (Node node in this.MainCanvas.Nodes)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell act = new DataGridViewTextBoxCell();
                act.Value = node.ActivityName;

                DataGridViewTextBoxCell dur = new DataGridViewTextBoxCell();
                dur.Value = node.ActivityTime;

                DataGridViewTextBoxCell dep = new DataGridViewTextBoxCell();
                dep.Value = node.DependsOnString;

                row.Cells.Add(act);
                row.Cells.Add(dur);
                row.Cells.Add(dep);

                this.NodesTable.Rows.Add(row);
            }
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

            this.UpdateTable();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            this.Status("");
            this.MainCanvas.CalculateGraph();
            
            this.UpdateTable();
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

        private void NodesTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Node node = new Node();
            node.Origin = new Point(100, 100);
            this.MainCanvas.Nodes.Add(node);
        }

        private void NodesTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            this.MainCanvas.Nodes.RemoveAt(this.NodesTable.Rows.IndexOf(e.Row));
        }

        private void NodesTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Node node = this.MainCanvas.Nodes[e.RowIndex];

            DataGridViewRow row = this.NodesTable.Rows[e.RowIndex];

            decimal time = 0;
            string dependsOnString = "";

            if (row.Cells[0].Value != null)
                node.ActivityName = (string)row.Cells[0].Value.ToString().ToUpper();
            if (row.Cells[1].Value != null)
            {
                if (row.Cells[1].Value.GetType() == typeof(string))
                {
                    decimal.TryParse(row.Cells[1].Value.ToString(), out time);
                }
                else if (row.Cells[1].Value.GetType() == typeof(decimal))
                {
                    node.ActivityTime = (decimal)row.Cells[1].Value;
                }
            }
            if (row.Cells[2].Value != null)
                dependsOnString = (string)row.Cells[2].Value.ToString().ToUpper();

            node.ActivityTime = time;

            IEnumerable<Node> nodes_search;
            node.DependsOn.Clear();
            List<string> depstrs = new List<string>(dependsOnString.Split(new char[] { ',' }));
            foreach (string str in depstrs)
            {
                if (str == "")
                    continue;
                nodes_search = from n in this.MainCanvas.Nodes
                               where n.ActivityName == str.Trim()
                               select n;

                node.DependsOn.AddRange(nodes_search);
            }
        }

        private void MainCanvas_Click(object sender, EventArgs e)
        {

        }

    }
}
