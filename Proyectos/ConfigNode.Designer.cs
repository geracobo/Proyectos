namespace Proyectos
{
    partial class ConfigNode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeBox = new System.Windows.Forms.NumericUpDown();
            this.dependeLabel = new System.Windows.Forms.Label();
            this.DependsOnBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RadiusBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(198, 97);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "Aceptar";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(117, 97);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre:";
            // 
            // NameBox
            // 
            this.NameBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NameBox.Location = new System.Drawing.Point(97, 6);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(57, 20);
            this.NameBox.TabIndex = 0;
            this.NameBox.Enter += new System.EventHandler(this.NameBox_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Duración:";
            // 
            // TimeBox
            // 
            this.TimeBox.Location = new System.Drawing.Point(97, 32);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(57, 20);
            this.TimeBox.TabIndex = 1;
            this.TimeBox.Enter += new System.EventHandler(this.TimeBox_Enter);
            // 
            // dependeLabel
            // 
            this.dependeLabel.AutoSize = true;
            this.dependeLabel.Location = new System.Drawing.Point(12, 61);
            this.dependeLabel.Name = "dependeLabel";
            this.dependeLabel.Size = new System.Drawing.Size(79, 13);
            this.dependeLabel.TabIndex = 12;
            this.dependeLabel.Text = "Dependencias:";
            // 
            // DependsOnBox
            // 
            this.DependsOnBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DependsOnBox.Location = new System.Drawing.Point(97, 58);
            this.DependsOnBox.Name = "DependsOnBox";
            this.DependsOnBox.Size = new System.Drawing.Size(57, 20);
            this.DependsOnBox.TabIndex = 2;
            this.DependsOnBox.Enter += new System.EventHandler(this.DependsOnBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Radio:";
            // 
            // RadiusBox
            // 
            this.RadiusBox.Location = new System.Drawing.Point(216, 6);
            this.RadiusBox.Name = "RadiusBox";
            this.RadiusBox.Size = new System.Drawing.Size(57, 20);
            this.RadiusBox.TabIndex = 14;
            // 
            // ConfigNode
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 132);
            this.Controls.Add(this.RadiusBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DependsOnBox);
            this.Controls.Add(this.dependeLabel);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Name = "ConfigNode";
            this.Text = "Configurar Actividad";
            this.Load += new System.EventHandler(this.ConfigNode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadiusBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TimeBox;
        private System.Windows.Forms.Label dependeLabel;
        private System.Windows.Forms.TextBox DependsOnBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RadiusBox;
    }
}