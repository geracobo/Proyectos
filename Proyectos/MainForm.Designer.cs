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
            this.ExportButton = new System.Windows.Forms.ToolStripButton();
            this.CalculateButton = new System.Windows.Forms.ToolStripButton();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.GraficaTab = new System.Windows.Forms.TabPage();
            this.MainCanvas = new Proyectos.NodeCanvas();
            this.TablaTab = new System.Windows.Forms.TabPage();
            this.NodesTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolbar.SuspendLayout();
            this.MainStatus.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.GraficaTab.SuspendLayout();
            this.TablaTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodesTable)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainToolbar
            // 
            this.MainToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddActivityButton,
            this.ExportButton,
            this.CalculateButton});
            this.MainToolbar.Location = new System.Drawing.Point(3, 3);
            this.MainToolbar.Name = "MainToolbar";
            this.MainToolbar.Size = new System.Drawing.Size(697, 25);
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
            // MainStatus
            // 
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.MainStatus.Location = new System.Drawing.Point(0, 458);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(711, 22);
            this.MainStatus.TabIndex = 2;
            this.MainStatus.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.GraficaTab);
            this.Tabs.Controls.Add(this.TablaTab);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 24);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(711, 434);
            this.Tabs.TabIndex = 3;
            // 
            // GraficaTab
            // 
            this.GraficaTab.Controls.Add(this.MainCanvas);
            this.GraficaTab.Controls.Add(this.MainToolbar);
            this.GraficaTab.Location = new System.Drawing.Point(4, 22);
            this.GraficaTab.Name = "GraficaTab";
            this.GraficaTab.Padding = new System.Windows.Forms.Padding(3);
            this.GraficaTab.Size = new System.Drawing.Size(703, 408);
            this.GraficaTab.TabIndex = 0;
            this.GraficaTab.Text = "Gráfica";
            this.GraficaTab.UseVisualStyleBackColor = true;
            // 
            // MainCanvas
            // 
            this.MainCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainCanvas.Location = new System.Drawing.Point(3, 28);
            this.MainCanvas.Name = "MainCanvas";
            this.MainCanvas.Size = new System.Drawing.Size(697, 377);
            this.MainCanvas.TabIndex = 1;
            this.MainCanvas.Text = "nodeCanvas1";
            // 
            // TablaTab
            // 
            this.TablaTab.Controls.Add(this.NodesTable);
            this.TablaTab.Location = new System.Drawing.Point(4, 22);
            this.TablaTab.Name = "TablaTab";
            this.TablaTab.Padding = new System.Windows.Forms.Padding(3);
            this.TablaTab.Size = new System.Drawing.Size(703, 408);
            this.TablaTab.TabIndex = 1;
            this.TablaTab.Text = "Tabla";
            this.TablaTab.UseVisualStyleBackColor = true;
            // 
            // NodesTable
            // 
            this.NodesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NodesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.NodesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodesTable.Location = new System.Drawing.Point(3, 3);
            this.NodesTable.Name = "NodesTable";
            this.NodesTable.Size = new System.Drawing.Size(697, 402);
            this.NodesTable.TabIndex = 0;
            this.NodesTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.NodesTable_CellValueChanged);
            this.NodesTable.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.NodesTable_UserAddedRow);
            this.NodesTable.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.NodesTable_UserDeletingRow);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Actividad";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Duración";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Dependencia";
            this.Column3.Name = "Column3";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(711, 24);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNew,
            this.MenuOpen,
            this.toolStripSeparator1,
            this.MenuSave,
            this.toolStripSeparator2,
            this.MenuExit});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // MenuNew
            // 
            this.MenuNew.Name = "MenuNew";
            this.MenuNew.Size = new System.Drawing.Size(166, 22);
            this.MenuNew.Text = "Nuevo Proyecto";
            this.MenuNew.Click += new System.EventHandler(this.MenuNew_Click);
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(166, 22);
            this.MenuOpen.Text = "Abrir Proyecto";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(166, 22);
            this.MenuSave.Text = "Guardar Proyecto";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(166, 22);
            this.MenuExit.Text = "Salir";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(711, 480);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Proyectos";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainToolbar.ResumeLayout(false);
            this.MainToolbar.PerformLayout();
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.GraficaTab.ResumeLayout(false);
            this.GraficaTab.PerformLayout();
            this.TablaTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NodesTable)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
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
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage GraficaTab;
        private System.Windows.Forms.TabPage TablaTab;
        private System.Windows.Forms.DataGridView NodesTable;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuNew;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;






    }
}

