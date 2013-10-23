using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyectos
{
    public partial class NodeCanvas : Control
    {
        private NodeCollection _nodes;

        private int analizeDepth;

        private const int MaxDepth = 100;

        private Node _selectedNode;


        public event StatusEventHandler Status;

        public event EventHandler OnInsert;
        public event EventHandler OnRemove;
        public event EventHandler OnSet;
        public event EventHandler OnModify;
        public event EventHandler OnClear;

        public NodeCanvas()
        {
            InitializeComponent();


            this._nodes = new NodeCollection();
            this._nodes.OnInsert += delegate(object sender, EventArgs e)
            {
                this.Status("Actividad Agregada.");

                if (OnInsert != null)
                    OnInsert(this, new EventArgs());
            };
            this._nodes.OnRemove += delegate(object sender, EventArgs e)
            {
                this.Status("Actividad Eliminada.");

                if (OnRemove != null)
                    OnRemove(this, new EventArgs());
            };
            this._nodes.OnSet += delegate(object sender, EventArgs e)
            {
                this.Status("Actividad Modificada.");

                if (OnSet != null)
                    OnSet(this, new EventArgs());
            };
            this._nodes.OnClear += delegate(object sender, EventArgs e)
            {
                this.Status("Actividades Eliminadas.");

                if (OnClear != null)
                    OnClear(this, new EventArgs());
            };


            this.ModificarButton.Click += delegate(object sender, EventArgs e)
            {
                if (_selectedNode == null)
                    return;

                this._selectedNode.OnDoubleClick(this.Nodes);
                this.OnModify(this, new EventArgs());
            };
            this.EliminarButton.Click += delegate(object sender, EventArgs e)
            {
                if (_selectedNode == null)
                    return;

                this.Nodes.Remove(this._selectedNode);
                this.OnRemove(this, new EventArgs());
            };


            this.BackColor = Color.White;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NodeCollection Nodes
        {
            get
            {
                return this._nodes;
            }
            set
            {
                this._nodes = value;
                this.Refresh();
            }
        }



        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.DesignMode)
                return;

            this.PaintCanvas(pe.Graphics);

            //this.Invalidate();
        }

        public void PaintCanvas(Graphics gfx)
        {
            //gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            gfx.Clear(this.BackColor);

            Pen arrowPen = new Pen(Color.Black, 2);
            arrowPen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);

            Point orig = new Point();
            Point dest = new Point();

            foreach (Node node in this.Nodes)
            {
                node.Paint(gfx);
                foreach (Node dependency in node.DependsOn)
                {
                    orig = dependency.Origin;
                    dest = node.Origin;

                    if (node.Critic && dependency.Critic)
                        arrowPen.Color = Color.Red;
                    else
                        arrowPen.Color = Color.Black;

                    double r = node.Radius;

                    double a = orig.Y - dest.Y;
                    double b = orig.X - dest.X;
                    double theta = Math.Atan2(a, b);

                    double offx = Math.Cos(theta) * r;
                    double offy = Math.Sin(theta) * r;

                    orig.Offset((int)-offx, (int)-offy);
                    dest.Offset((int)offx, (int)offy);

                    gfx.DrawLine(arrowPen, orig, dest);
                }
            }
        }

        public void CalculateGraph()
        {
            IEnumerable<Node> node_search;
            Node ini;
            Node fin;

            foreach (Node n in this.Nodes)
            {
                n.ActivityFirstTimeEnd = 0;
                n.ActivityFirstTimeStart = 0;
                n.ActivityFreeSlack = 0;
                n.ActivityLastTimeEnd = 0;
                n.ActivityLastTimeStart = 0;
                n.ActivityTotalSlack = 0;
                n.Critic = false;
            }

            node_search = from n in this.Nodes
                          where n.ActivityName == "INI"
                          select n;
            if (node_search.Count() < 1)
            {
                this.Status("El nodo de inicio no esta definido.");
                return;
            }
            ini = node_search.First();

            node_search = from n in this.Nodes
                          where n.ActivityName == "FIN"
                          select n;
            if (node_search.Count() < 1)
            {
                this.Status("El nodo final no esta definido.");
                return;
            }
            fin = node_search.First();

            // Forward...
            this.analizeDepth = 0;
            AnalizeForward(ini);

            if (this.analizeDepth > MaxDepth)
                return;

            // Backwards
            this.analizeDepth = 0;
            foreach(Node node in this.Nodes)
            {
                node.ActivityLastTimeEnd = fin.ActivityFirstTimeEnd;
                node.ActivityLastTimeStart = fin.ActivityFirstTimeStart;
            }
            AnalizeBackward(fin);

            // Slacks
            AnalizeSlacks();

            this.Invalidate();
        }

        private void AnalizeSlacks()
        {
            foreach(Node node in this.Nodes)
            {
                IEnumerable<Node> node_search;

                node_search = from n in this.Nodes
                              where n.DependsOn.Contains(node)
                              select n;

                // No succesors
                if (node_search.Count() < 1)
                    return;

                decimal min = node_search.ElementAt(0).ActivityFirstTimeStart;
                foreach (Node n in node_search)
                {
                    if (n.ActivityFirstTimeStart < min)
                        min = n.ActivityFirstTimeStart;
                }
                node.ActivityFreeSlack = min - node.ActivityFirstTimeEnd;
            }
        }

        private void AnalizeForward(Node node)
        {
            this.analizeDepth++;
            if (this.analizeDepth > MaxDepth)
            {
                this.Status("Error ciclico.");
                return;
            }

            IEnumerable<Node> node_search;

            node_search = from n in this.Nodes
                          where n.DependsOn.Contains(node)
                          select n;

            // No succesors
            if (node_search.Count() < 1)
                return;

            node.ActivityFreeSlack = 999999999;

            foreach (Node succesor in node_search)
            {
                // Check if we are not trying to overwrite a node.
                if (succesor.ActivityFirstTimeStart > node.ActivityFirstTimeEnd)
                {
                    // We are, we should stop going forward here since there is really no point.
                    continue;
                }

                succesor.ActivityFirstTimeStart = node.ActivityFirstTimeEnd;
                succesor.ActivityFirstTimeEnd = succesor.ActivityFirstTimeStart + succesor.ActivityTime;

                if ((succesor.ActivityFirstTimeStart - node.ActivityFirstTimeEnd) < node.ActivityFreeSlack)
                {
                    node.ActivityFreeSlack = succesor.ActivityFirstTimeStart - node.ActivityFirstTimeEnd;
                }

                AnalizeForward(succesor);
            }
        }
        private void AnalizeBackward(Node node)
        {
            this.analizeDepth++;
            if (this.analizeDepth > MaxDepth)
            {
                this.Status("Error ciclico.");
                return;
            }

            foreach (Node dependency in node.DependsOn)
            {
                if (dependency.ActivityLastTimeEnd < node.ActivityLastTimeStart)
                    continue;

                dependency.ActivityLastTimeEnd = node.ActivityLastTimeStart;
                dependency.ActivityLastTimeStart = dependency.ActivityLastTimeEnd - dependency.ActivityTime;
                AnalizeBackward(dependency);
            }

            node.ActivityTotalSlack = node.ActivityLastTimeStart - node.ActivityFirstTimeStart;
            if (node.ActivityTotalSlack == 0)
                node.Critic = true;
            else
                node.Critic = false;
        }

        private void NodeCanvas_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void NodeCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.Invalidate();

            foreach (Node node in this.Nodes.Reverse<Node>())
            {
                if (node.HitTest(e.Location))
                {
                    this._selectedNode = node;
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        node.OnMouseDown(e.Location);
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        NodeMenu.Show(this, e.Location);
                    }
                    return;
                }
            }

            this.Invalidate();
        }

        private void NodeCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Node node in this.Nodes)
            {
                node.OnMouseUp(e.Location);
            }
            this.Invalidate();
        }

        private void NodeCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Node node in this.Nodes)
            {
                node.OnMouseMove(e.Location);

                if (node.HitTest(e.Location))
                {
                    if (!node.MouseOver)
                    {
                        node.OnMouseEnter();
                    }
                    node.MouseOver = true;
                }
                else
                {
                    if (node.MouseOver)
                    {
                        node.OnMouseLeave();
                    }
                    node.MouseOver = false;
                }
            }
            this.Invalidate();
        }

        private void NodeCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Invalidate();
            foreach (Node node in this.Nodes)
            {
                if (node.HitTest(e.Location))
                {
                    node.OnDoubleClick(this.Nodes);
                    this.OnModify(this, new EventArgs());
                }
            }
            this.Invalidate();
        }
    }




    public delegate void StatusEventHandler(string status);

}
