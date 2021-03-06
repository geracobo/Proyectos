﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyectos
{
    public partial class ConfigNode : Form
    {
        public ConfigNode(Node node)
        {
            InitializeComponent();
            this.NameBox.Text = node.ActivityName ?? "";
            this.TimeBox.Text = node.ActivityTime.ToString();
            this.RadiusBox.Value = node.Radius;

            this.DependsOnBox.Text = "";
            foreach (Node dep in node.DependsOn)
            {
                this.DependsOnBox.Text += ",";
                this.DependsOnBox.Text += dep.ActivityName;
            }
            if (this.DependsOnBox.Text.Length > 0)
                this.DependsOnBox.Text = this.DependsOnBox.Text.Remove(0, 1);
        }


        public string ActivityName
        {
            get;
            set;
        }
        public decimal ActivityTime
        {
            get;
            set;
        }
        public string DependsOnString
        {
            get;
            set;
        }
        public int Radius
        {
            get;
            set;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            decimal time = 0;

            if (!decimal.TryParse(this.TimeBox.Text, out time))
            {
                MessageBox.Show("La duracion de la actividad no es numerica.");
                return;
            }

            this.ActivityName = this.NameBox.Text;
            this.ActivityTime = time;
            this.DependsOnString = this.DependsOnBox.Text;
            this.Radius = (int)this.RadiusBox.Value;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void NameBox_Enter(object sender, EventArgs e)
        {
            this.NameBox.Select(0, this.NameBox.Text.Length);
        }

        private void TimeBox_Enter(object sender, EventArgs e)
        {
            this.TimeBox.Select(0, this.TimeBox.Text.Length);
        }

        private void DependsOnBox_Enter(object sender, EventArgs e)
        {
            this.DependsOnBox.Select(0, this.DependsOnBox.Text.Length);
        }

        private void ConfigNode_Load(object sender, EventArgs e)
        {

        }
    }
}
