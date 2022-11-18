namespace DevToolsNet.WindowsApp
{
    partial class frmSQLRunner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSQLRunner));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbReload = new System.Windows.Forms.ToolStripButton();
            this.tsbVerGrids = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRun = new System.Windows.Forms.ToolStripButton();
            this.tsbRunMeger = new System.Windows.Forms.ToolStripButton();
            this.tsbRunNonQ = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelectReplace = new System.Windows.Forms.ToolStripButton();
            this.tsbDoReplace = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splcCode = new System.Windows.Forms.SplitContainer();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.lblReplace = new System.Windows.Forms.Label();
            this.tabResults = new System.Windows.Forms.TabControl();
            this.imglConn = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeServers = new DevToolsNet.WindowsApp.ServerTrees.TreeServerConnections();
            this.treeConnections = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcCode)).BeginInit();
            this.splcCode.Panel1.SuspendLayout();
            this.splcCode.Panel2.SuspendLayout();
            this.splcCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReload,
            this.tsbVerGrids,
            this.toolStripSeparator1,
            this.tsbRun,
            this.tsbRunMeger,
            this.tsbRunNonQ,
            this.toolStripSeparator2,
            this.tsbSelectReplace,
            this.tsbDoReplace});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(943, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbReload
            // 
            this.tsbReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReload.Image = global::DevToolsNet.WindowsApp.Properties.Resources.refresh;
            this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReload.Name = "tsbReload";
            this.tsbReload.Size = new System.Drawing.Size(23, 22);
            this.tsbReload.Text = "Reload";
            this.tsbReload.Click += new System.EventHandler(this.tsbReload_Click);
            // 
            // tsbVerGrids
            // 
            this.tsbVerGrids.Checked = true;
            this.tsbVerGrids.CheckOnClick = true;
            this.tsbVerGrids.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbVerGrids.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbVerGrids.Image = global::DevToolsNet.WindowsApp.Properties.Resources.table_sql;
            this.tsbVerGrids.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVerGrids.Name = "tsbVerGrids";
            this.tsbVerGrids.Size = new System.Drawing.Size(23, 22);
            this.tsbVerGrids.Text = "Ver las tablas de resultados";
            this.tsbVerGrids.CheckedChanged += new System.EventHandler(this.tsbVerGrids_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRun
            // 
            this.tsbRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRun.Image = global::DevToolsNet.WindowsApp.Properties.Resources.media_play;
            this.tsbRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRun.Name = "tsbRun";
            this.tsbRun.Size = new System.Drawing.Size(23, 22);
            this.tsbRun.Text = "toolStripButton2";
            this.tsbRun.Click += new System.EventHandler(this.tsbRun_Click);
            // 
            // tsbRunMeger
            // 
            this.tsbRunMeger.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRunMeger.Image = global::DevToolsNet.WindowsApp.Properties.Resources.media_step_forward;
            this.tsbRunMeger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunMeger.Name = "tsbRunMeger";
            this.tsbRunMeger.Size = new System.Drawing.Size(23, 22);
            this.tsbRunMeger.Text = "Run Merge";
            this.tsbRunMeger.Click += new System.EventHandler(this.tsbRunMeger_Click);
            // 
            // tsbRunNonQ
            // 
            this.tsbRunNonQ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRunNonQ.Image = global::DevToolsNet.WindowsApp.Properties.Resources.media_play_green;
            this.tsbRunNonQ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunNonQ.Name = "tsbRunNonQ";
            this.tsbRunNonQ.Size = new System.Drawing.Size(23, 22);
            this.tsbRunNonQ.Text = "Run NonQuery";
            this.tsbRunNonQ.Click += new System.EventHandler(this.tsbRunNonQ_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSelectReplace
            // 
            this.tsbSelectReplace.CheckOnClick = true;
            this.tsbSelectReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelectReplace.Image = global::DevToolsNet.WindowsApp.Properties.Resources.document_into;
            this.tsbSelectReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectReplace.Name = "tsbSelectReplace";
            this.tsbSelectReplace.Size = new System.Drawing.Size(23, 22);
            this.tsbSelectReplace.Text = "Replace";
            this.tsbSelectReplace.CheckedChanged += new System.EventHandler(this.tsbSelectReplace_CheckedChanged);
            // 
            // tsbDoReplace
            // 
            this.tsbDoReplace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDoReplace.Image = global::DevToolsNet.WindowsApp.Properties.Resources.document_refresh;
            this.tsbDoReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDoReplace.Name = "tsbDoReplace";
            this.tsbDoReplace.Size = new System.Drawing.Size(23, 22);
            this.tsbDoReplace.Text = "Do replace";
            this.tsbDoReplace.Click += new System.EventHandler(this.tsbDoReplace_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splcCode);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabResults);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Size = new System.Drawing.Size(725, 509);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 2;
            // 
            // splcCode
            // 
            this.splcCode.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splcCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcCode.Location = new System.Drawing.Point(0, 0);
            this.splcCode.Name = "splcCode";
            this.splcCode.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splcCode.Panel1
            // 
            this.splcCode.Panel1.Controls.Add(this.txtCode);
            this.splcCode.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splcCode.Panel2
            // 
            this.splcCode.Panel2.Controls.Add(this.txtReplace);
            this.splcCode.Panel2.Controls.Add(this.lblReplace);
            this.splcCode.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splcCode.Size = new System.Drawing.Size(725, 291);
            this.splcCode.SplitterDistance = 124;
            this.splcCode.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.AcceptsReturn = true;
            this.txtCode.AcceptsTab = true;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.MaxLength = 999999;
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(725, 124);
            this.txtCode.TabIndex = 2;
            // 
            // txtReplace
            // 
            this.txtReplace.AcceptsReturn = true;
            this.txtReplace.AcceptsTab = true;
            this.txtReplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplace.Location = new System.Drawing.Point(0, 15);
            this.txtReplace.MaxLength = 999999;
            this.txtReplace.Multiline = true;
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReplace.Size = new System.Drawing.Size(725, 148);
            this.txtReplace.TabIndex = 1;
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReplace.Location = new System.Drawing.Point(0, 0);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(71, 15);
            this.lblReplace.TabIndex = 0;
            this.lblReplace.Text = "Replace text";
            // 
            // tabResults
            // 
            this.tabResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResults.ImageList = this.imglConn;
            this.tabResults.Location = new System.Drawing.Point(0, 0);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.Size = new System.Drawing.Size(725, 214);
            this.tabResults.TabIndex = 1;
            // 
            // imglConn
            // 
            this.imglConn.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglConn.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglConn.ImageStream")));
            this.imglConn.TransparentColor = System.Drawing.Color.Transparent;
            this.imglConn.Images.SetKeyName(0, "folder.png");
            this.imglConn.Images.SetKeyName(1, "server.png");
            this.imglConn.Images.SetKeyName(2, "media_play_green.png");
            this.imglConn.Images.SetKeyName(3, "error.png");
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 25);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeServers);
            this.splitContainer2.Panel1.Controls.Add(this.treeConnections);
            this.splitContainer2.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(943, 509);
            this.splitContainer2.SplitterDistance = 214;
            this.splitContainer2.TabIndex = 3;
            // 
            // treeServers
            // 
            this.treeServers.CheckBoxes = true;
            this.treeServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeServers.Location = new System.Drawing.Point(0, 0);
            this.treeServers.Name = "treeServers";
            this.treeServers.ShowTools = true;
            this.treeServers.Size = new System.Drawing.Size(214, 386);
            this.treeServers.TabIndex = 1;
            this.treeServers.AfterNodeCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeServers_AfterNodeCheck);
            // 
            // treeConnections
            // 
            this.treeConnections.CheckBoxes = true;
            this.treeConnections.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeConnections.ImageIndex = 0;
            this.treeConnections.ImageList = this.imglConn;
            this.treeConnections.Location = new System.Drawing.Point(0, 386);
            this.treeConnections.Name = "treeConnections";
            this.treeConnections.SelectedImageIndex = 0;
            this.treeConnections.Size = new System.Drawing.Size(214, 123);
            this.treeConnections.TabIndex = 0;
            this.treeConnections.Visible = false;
            this.treeConnections.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeConnections_AfterCheck);
            // 
            // frmSQLRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 534);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSQLRunner";
            this.Text = "SQL Ejecutor";
            this.Shown += new System.EventHandler(this.frmSQLRunner_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splcCode.Panel1.ResumeLayout(false);
            this.splcCode.Panel1.PerformLayout();
            this.splcCode.Panel2.ResumeLayout(false);
            this.splcCode.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcCode)).EndInit();
            this.splcCode.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbReload;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbRun;
        private ToolStripButton tsbRunMeger;
        private ToolStripButton tsbRunNonQ;
        private ToolStripButton tsbSelectReplace;
        private SplitContainer splitContainer1;
        private Label lblReplace;
        private TextBox txtReplace;
        private SplitContainer splitContainer2;
        private TabControl tabResults;
        private TreeView treeConnections;
        private ImageList imglConn;
        private SplitContainer splcCode;
        private TextBox txtCode;
        private ToolStripButton tsbVerGrids;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbDoReplace;
        private ServerTrees.TreeServerConnections treeServers;
    }
}