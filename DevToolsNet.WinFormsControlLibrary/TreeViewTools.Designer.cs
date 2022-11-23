namespace DevToolsNet.WinFormsControlLibrary
{
    partial class TreeViewTools
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ilTree = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tstFilter = new System.Windows.Forms.ToolStripTextBox();
            this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelectAll = new System.Windows.Forms.ToolStripButton();
            this.tsbUnselectAll = new System.Windows.Forms.ToolStripButton();
            this.tree = new System.Windows.Forms.TreeView();
            this.chkExact = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilTree
            // 
            this.ilTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilTree.ImageSize = new System.Drawing.Size(16, 16);
            this.ilTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstFilter,
            this.tsSep1,
            this.tsbSelectAll,
            this.tsbUnselectAll});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(300, 42);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tstFilter
            // 
            this.tstFilter.AutoSize = false;
            this.tstFilter.BackColor = System.Drawing.SystemColors.Info;
            this.tstFilter.Name = "tstFilter";
            this.tstFilter.Size = new System.Drawing.Size(245, 23);
            this.tstFilter.ToolTipText = "Filter";
            this.tstFilter.TextChanged += new System.EventHandler(this.tstFilter_TextChanged);
            // 
            // tsSep1
            // 
            this.tsSep1.Name = "tsSep1";
            this.tsSep1.Size = new System.Drawing.Size(6, 23);
            // 
            // tsbSelectAll
            // 
            this.tsbSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelectAll.Image = global::DevToolsNet.WinFormsControlLibrary.Properties.Resources.check2;
            this.tsbSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectAll.Name = "tsbSelectAll";
            this.tsbSelectAll.Size = new System.Drawing.Size(23, 20);
            this.tsbSelectAll.Text = "Select All";
            this.tsbSelectAll.Click += new System.EventHandler(this.tsbSelectAll_Click);
            // 
            // tsbUnselectAll
            // 
            this.tsbUnselectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnselectAll.Image = global::DevToolsNet.WinFormsControlLibrary.Properties.Resources.delete2;
            this.tsbUnselectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnselectAll.Name = "tsbUnselectAll";
            this.tsbUnselectAll.Size = new System.Drawing.Size(23, 20);
            this.tsbUnselectAll.Text = "Unselect All";
            this.tsbUnselectAll.Click += new System.EventHandler(this.tsbUnselectAll_Click);
            // 
            // tree
            // 
            this.tree.CheckBoxes = true;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.ilTree;
            this.tree.Location = new System.Drawing.Point(0, 42);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.Size = new System.Drawing.Size(300, 427);
            this.tree.TabIndex = 2;
            this.tree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterCheck);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // chkExact
            // 
            this.chkExact.AutoSize = true;
            this.chkExact.BackColor = System.Drawing.SystemColors.Info;
            this.chkExact.Location = new System.Drawing.Point(230, 5);
            this.chkExact.Name = "chkExact";
            this.chkExact.Size = new System.Drawing.Size(15, 14);
            this.chkExact.TabIndex = 3;
            this.toolTip1.SetToolTip(this.chkExact, "Búsqueda extricta");
            this.chkExact.UseVisualStyleBackColor = false;
            this.chkExact.CheckedChanged += new System.EventHandler(this.chkExact_CheckedChanged);
            // 
            // TreeViewTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkExact);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.toolStrip);
            this.Name = "TreeViewTools";
            this.Size = new System.Drawing.Size(300, 469);
            this.Resize += new System.EventHandler(this.TreeViewTools_Resize);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ImageList ilTree;
        protected ToolStrip toolStrip;
        protected ToolStripTextBox tstFilter;
        protected ToolStripSeparator tsSep1;
        protected ToolStripButton tsbSelectAll;
        protected ToolStripButton tsbUnselectAll;
        protected System.Windows.Forms.TreeView tree;
        protected CheckBox chkExact;
        private ToolTip toolTip1;
    }
}
