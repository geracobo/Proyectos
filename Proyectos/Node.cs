using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Proyectos
{
    public class Node
    {
        private bool _dragging;
        private Point _mouseClicked;

        private string _activityName;
        private decimal _activityTime;
        private decimal _activityFirstTimeStart;
        private decimal _activityFirstTimeEnd;
        private decimal _activityLastTimeStart;
        private decimal _activityLastTimeEnd;

        private decimal _activityFreeSlack;
        private decimal _activityTotalSlack;

        private List<Node> _dependsOn;

        public Node()
        {
            this._activityName = "";
            this.DependsOn = new List<Node>();

            this.Radius = 50;
            this.Origin = new Point(0, 0);

            this._dragging = false;
            this._mouseClicked = new Point();

            this.MouseOver = false;
        }


        public int Radius
        {
            get;
            set;
        }


        // Node center
        public Point Origin
        {
            get;
            set;
        }


        public string ActivityName
        {
            get
            {
                return this._activityName;
            }
            set
            {
                this._activityName = value;
            }
        }
        public decimal ActivityTime
        {
            get
            {
                return this._activityTime;
            }
            set
            {
                this._activityTime = value;
            }
        }
        public decimal ActivityFirstTimeStart
        {
            get
            {
                return this._activityFirstTimeStart;
            }
            set
            {
                this._activityFirstTimeStart = value;
            }
        }
        public decimal ActivityFirstTimeEnd
        {
            get
            {
                return this._activityFirstTimeEnd;
            }
            set
            {
                this._activityFirstTimeEnd = value;
            }
        }
        public decimal ActivityLastTimeStart
        {
            get
            {
                return this._activityLastTimeStart;
            }
            set
            {
                this._activityLastTimeStart = value;
            }
        }
        public decimal ActivityLastTimeEnd
        {
            get
            {
                return this._activityLastTimeEnd;
            }
            set
            {
                this._activityLastTimeEnd = value;
            }
        }

        public decimal ActivityFreeSlack
        {
            get
            {
                return this._activityFreeSlack;
            }
            set
            {
                this._activityFreeSlack = value;
            }
        }
        public decimal ActivityTotalSlack
        {
            get
            {
                return this._activityTotalSlack;
            }
            set
            {
                this._activityTotalSlack = value;
            }
        }

        public List<Node> DependsOn
        {
            get
            {
                return this._dependsOn;
            }
            set
            {
                this._dependsOn = value;
            }
        }

        public bool Critic
        {
            get;
            set;
        }

        public string DependsOnString
        {
            get
            {
                string ret = "";
                foreach (Node dep in this.DependsOn)
                {
                    ret += ",";
                    ret += dep.ActivityName;
                }
                if (ret.Length > 0)
                    ret = ret.Remove(0, 1);

                return ret;
            }
        }


        public bool MouseOver
        {
            get;
            set;
        }


        public void Paint(Graphics gfx)
        {
            int width = this.Radius * 2;
            int height = this.Radius * 2;

            int x = this.Origin.X;
            int y = this.Origin.Y;

            Point topleft = new Point(x - (width / 2), y - (height / 2));

            int space = height / 4;

            Pen blackPen = new Pen(Color.Black);
            Brush blackBrush = new SolidBrush(Color.Black);
            Brush fillBrush = new SolidBrush(Color.White);

            if (this._dragging)
            {
                fillBrush = new SolidBrush(Color.FromArgb(255, 251, 135));
            }

            gfx.FillEllipse(fillBrush, topleft.X, topleft.Y, width, height);
            gfx.DrawEllipse(blackPen, topleft.X, topleft.Y, width, height);

            gfx.DrawLine(blackPen, topleft.X, y, topleft.X + width, y);

            gfx.DrawLine(blackPen, x, topleft.Y+space, x, topleft.Y+height-space);

            double c = Math.Pow((double)width / 2d, 2d);
            double a = Math.Pow((double)space, 2d);
            int b = (int)Math.Sqrt(c - a);
            gfx.DrawLine(blackPen, x - b, topleft.Y + space, x + b, topleft.Y + space);
            gfx.DrawLine(blackPen, x - b, topleft.Y + height - space, x + b, topleft.Y + height - space);

            Font font = new System.Drawing.Font(FontFamily.GenericMonospace, 12);
            SizeF strs;

            strs = gfx.MeasureString(this.ActivityName, font);
            gfx.DrawString(this.ActivityName, font, blackBrush, (float)x - (strs.Width / 2f), (float)y - (float)space - strs.Height);

            strs = gfx.MeasureString(this.ActivityTime.ToString(), font);
            gfx.DrawString(this.ActivityTime.ToString(), font, blackBrush, (float)x - (strs.Width / 2f), (float)topleft.Y + (float)height - (float)space);

            strs = gfx.MeasureString(this.ActivityFirstTimeStart.ToString(), font);
            gfx.DrawString(this.ActivityFirstTimeStart.ToString(), font, blackBrush, (float)x - strs.Width, (float)y - strs.Height);

            strs = gfx.MeasureString(this.ActivityFirstTimeEnd.ToString(), font);
            gfx.DrawString(this.ActivityFirstTimeEnd.ToString(), font, blackBrush, (float)x, (float)y - strs.Height);

            strs = gfx.MeasureString(this.ActivityLastTimeStart.ToString(), font);
            gfx.DrawString(this.ActivityLastTimeStart.ToString(), font, blackBrush, (float)x - strs.Width, (float)y);

            strs = gfx.MeasureString(this.ActivityLastTimeEnd.ToString(), font);
            gfx.DrawString(this.ActivityLastTimeEnd.ToString(), font, blackBrush, (float)x, (float)y);

            // Draw slacks
            Font f = new Font(font.Name, 8, FontStyle.Italic);
            Brush blueBrush = new SolidBrush(Color.Blue);
            Brush whiteBrush = new SolidBrush(Color.White);
            SizeF strs1 = gfx.MeasureString("HA:"+this.ActivityTotalSlack.ToString(), f);
            SizeF strs2 = gfx.MeasureString("HL:" + this.ActivityFreeSlack.ToString(), f);

            int margin = 2;

            gfx.FillRectangle(whiteBrush, (float)topleft.X - strs1.Width - margin, (float)topleft.Y - margin, strs1.Width + (margin * 2), strs1.Height + strs2.Height + (margin * 2));
            gfx.DrawRectangle(blackPen, (float)topleft.X - strs1.Width - margin, (float)topleft.Y - margin, strs1.Width + (margin * 2), strs1.Height + strs2.Height + (margin * 2));

            gfx.DrawString("HA:" + this.ActivityTotalSlack.ToString(), f, blueBrush, (float)topleft.X - strs1.Width, (float)topleft.Y);
            gfx.DrawString("HL:" + this.ActivityFreeSlack.ToString(), f, blueBrush, (float)topleft.X - strs1.Width, (float)topleft.Y + strs1.Height);

        }

        public bool HitTest(Point point)
        {
            int width = this.Radius * 2;
            int height = this.Radius * 2;

            int x = this.Origin.X;
            int y = this.Origin.Y;

            Point topleft = new Point(x - (width / 2), y - (height / 2));

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(topleft.X, topleft.Y, width, height);
            Region reg = new Region(path);
            return reg.IsVisible(point);
        }

        public void OnMouseEnter()
        {
        }
        public void OnMouseLeave()
        {
        }

        public void OnMouseDown(Point location)
        {
            this._dragging = true;
            this._mouseClicked = location;
        }
        public void OnMouseUp(Point location)
        {
            this._dragging = false;
        }
        public void OnMouseMove(Point location)
        {
            if (this._dragging)
            {
                this.Origin = new Point(this.Origin.X + (location.X-this._mouseClicked.X), this.Origin.Y + (location.Y-this._mouseClicked.Y));
                this._mouseClicked = location;
            }
        }
        public void OnDoubleClick(List<Node> nodes)
        {
            IEnumerable<Node> nodes_search;
            ConfigNode config = new ConfigNode(this);
            DialogResult res = config.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return;

            //nodes_search = from n in nodes
            //               where (n.ActivityName == config.ActivityName.Trim()) && n.ActivityName != this.ActivityName
            //               select n;

            nodes_search = nodes.Where(n => n.ActivityName == config.ActivityName.Trim() && n.ActivityName != this.ActivityName);

            if (nodes_search.Count() > 0)
            {
                MessageBox.Show("Nombre repetido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.ActivityName = config.ActivityName.Trim();
            this.ActivityTime = config.ActivityTime;
            this.Radius = config.Radius;


            this.DependsOn.Clear();
            List<string> depstrs = new List<string>(config.DependsOnString.Split(new char[] {','}));
            foreach (string str in depstrs)
            {
                nodes_search = from n in nodes
                                                 where n.ActivityName == str.Trim()
                                                 select n;

                this.DependsOn.AddRange(nodes_search);
            }
        }
    }

}
