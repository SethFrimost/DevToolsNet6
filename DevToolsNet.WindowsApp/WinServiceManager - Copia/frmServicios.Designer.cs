namespace Servicios
{
    partial class frmServicios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServicios));
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imlTree = new System.Windows.Forms.ImageList(this.components);
            this.tree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb = new System.Windows.Forms.ToolStripButton();
            this.tsbRefrescarEstado = new System.Windows.Forms.ToolStripButton();
            this.tsbPlay = new System.Windows.Forms.ToolStripButton();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb,
            this.tsbSelectAll,
            this.toolStripSeparator1,
            this.tsbRefrescarEstado,
            this.tsbPlay,
            this.tsbReset,
            this.tsbStop,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(399, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // imlTree
            // 
            this.imlTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTree.ImageStream")));
            this.imlTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTree.Images.SetKeyName(0, "server.png");
            this.imlTree.Images.SetKeyName(1, "gear_warning.png");
            this.imlTree.Images.SetKeyName(2, "gear_replace.png");
            this.imlTree.Images.SetKeyName(3, "gear_run.png");
            this.imlTree.Images.SetKeyName(4, "gear_stop.png");
            this.imlTree.Images.SetKeyName(5, "gear_pause.png");
            this.imlTree.Images.SetKeyName(6, "arrow_right_blue.png");
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.ImageList = this.imlTree;
            this.tree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tree.Location = new System.Drawing.Point(0, 25);
            this.tree.Name = "tree";
            this.tree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Extended;
            this.tree.Override = _override1;
            this.tree.Size = new System.Drawing.Size(399, 433);
            this.tree.TabIndex = 1;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb
            // 
            this.tsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb.Image = global::Servicios.Properties.Resources.refresh;
            this.tsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb.Name = "tsb";
            this.tsb.Size = new System.Drawing.Size(23, 22);
            this.tsb.Text = "Refrescar Servicios";
            this.tsb.Click += new System.EventHandler(this.tsb_Click);
            // 
            // tsbRefrescarEstado
            // 
            this.tsbRefrescarEstado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefrescarEstado.Image = global::Servicios.Properties.Resources.replace2;
            this.tsbRefrescarEstado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefrescarEstado.Name = "tsbRefrescarEstado";
            this.tsbRefrescarEstado.Size = new System.Drawing.Size(23, 22);
            this.tsbRefrescarEstado.Text = "Refrescar estado";
            this.tsbRefrescarEstado.Click += new System.EventHandler(this.tsbRefrescarEstado_Click);
            // 
            // tsbPlay
            // 
            this.tsbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPlay.Image = global::Servicios.Properties.Resources.media_play_green;
            this.tsbPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlay.Name = "tsbPlay";
            this.tsbPlay.Size = new System.Drawing.Size(23, 22);
            this.tsbPlay.Text = "Start";
            this.tsbPlay.Click += new System.EventHandler(this.tsbPlay_Click);
            // 
            // tsbReset
            // 
            this.tsbReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReset.Image = global::Servicios.Properties.Resources.media_step_forward;
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.Size = new System.Drawing.Size(23, 22);
            this.tsbReset.Text = "Restart";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Image = global::Servicios.Properties.Resources.media_stop_red;
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Text = "Stop";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbSelectAll
            // 
            this.tsbSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelectAll.Image = global::Servicios.Properties.Resources.checks;
            this.tsbSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectAll.Name = "tsbSelectAll";
            this.tsbSelectAll.Size = new System.Drawing.Size(23, 22);
            this.tsbSelectAll.Text = "Seleccionar todos";
            this.tsbSelectAll.Click += new System.EventHandler(this.tsbSelectAll_Click);
            // 
            // frmServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 458);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServicios";
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.frmServicios_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbPlay;
        private System.Windows.Forms.ToolStripButton tsbReset;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripButton tsb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRefrescarEstado;
        private System.Windows.Forms.ImageList imlTree;
        private Infragistics.Win.UltraWinTree.UltraTree tree;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSelectAll;
    }
}