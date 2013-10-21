namespace Proyectos
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainToolbar = new System.Windows.Forms.ToolStrip();
            this.AddActivityButton = new System.Windows.Forms.ToolStripButton();
            this.CalculateButton = new System.Windows.Forms.ToolStripButton();
            this.ExportButton = new System.Windows.Forms.ToolStripButton();
            this.MainCanvas = new Proyectos.NodeCanvas();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainToolbar.SuspendLayout();
            this.MainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainToolbar
            // 
            this.MainToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddActivityButton,
            this.ExportButton,
            this.CalculateButton});
            this.MainToolbar.Location = new System.Drawing.Point(0, 0);
            this.MainToolbar.Name = "MainToolbar";
            this.MainToolbar.Size = new System.Drawing.Size(765, 25);
            this.MainToolbar.TabIndex = 0;
            this.MainToolbar.Text = "toolStrip1";
            // 
            // AddActivityButton
            // 
            this.AddActivityButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddActivityButton.Image = ((System.Drawing.Image)(resources.GetObject("AddActivityButton.Image")));
            this.AddActivityButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddActivityButton.Name = "AddActivityButton";
            this.AddActivityButton.Size = new System.Drawing.Size(106, 22);
            this.AddActivityButton.Text = "Agregar Actividad";
            this.AddActivityButton.Click += new System.EventHandler(this.AddActivityButton_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CalculateButton.Image = ((System.Drawing.Image)(resources.GetObject("CalculateButton.Image")));
            this.CalculateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(54, 22);
            this.CalculateButton.Text = "Calcular";
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExportButton.Image = ((System.Drawing.Image)(resources.GetObject("ExportButton.Image")));
            this.ExportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(97, 22);
            this.ExportButton.Text = "Exportar Imagen";
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // MainCanvas
            // 
            this.MainCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainCanvas.Location = new System.Drawing.Point(0, 25);
            this.MainCanvas.Name = "MainCanvas";
            this.MainCanvas.Size = new System.Drawing.Size(765, 333);
            this.MainCanvas.TabIndex = 1;
            this.MainCanvas.Text = "nodeCanvas1";
            // 
            // MainStatus
            // 
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.MainStatus.Location = new System.Drawing.Point(0, 358);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(765, 22);
            this.MainStatus.TabIndex = 2;
            this.MainStatus.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(765, 380);
            this.Controls.Add(this.MainCanvas);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.MainToolbar);
            this.Name = "MainForm";
            this.Text = "Proyectos";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainToolbar.ResumeLayout(false);
            this.MainToolbar.PerformLayout();
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MainToolbar;
        private System.Windows.Forms.ToolStripButton AddActivityButton;
        private System.Windows.Forms.ToolStripButton CalculateButton;
        private NodeCanvas MainCanvas;
        private System.Windows.Forms.ToolStripButton ExportButton;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;






    }
}

