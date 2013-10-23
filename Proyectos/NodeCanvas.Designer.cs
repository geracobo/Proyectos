namespace Proyectos
{
    partial class NodeCanvas
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.NodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModificarButton = new System.Windows.Forms.ToolStripMenuItem();
            this.EliminarButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NodeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NodeMenu
            // 
            this.NodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModificarButton,
            this.toolStripSeparator1,
            this.EliminarButton});
            this.NodeMenu.Name = "NodeMenu";
            this.NodeMenu.Size = new System.Drawing.Size(126, 54);
            // 
            // ModificarButton
            // 
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(125, 22);
            this.ModificarButton.Text = "Modificar";
            // 
            // EliminarButton
            // 
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(125, 22);
            this.EliminarButton.Text = "Eliminar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // NodeCanvas
            // 
            this.Click += new System.EventHandler(this.NodeCanvas_Click);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NodeCanvas_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NodeCanvas_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NodeCanvas_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NodeCanvas_MouseUp);
            this.NodeMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip NodeMenu;
        private System.Windows.Forms.ToolStripMenuItem ModificarButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem EliminarButton;
    }
}
