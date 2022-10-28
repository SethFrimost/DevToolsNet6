namespace DevToolsNet.WindowsApp
{
    partial class frmWinServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWinServices));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbStart = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbRestart = new System.Windows.Forms.ToolStripButton();
            this.treeServ = new System.Windows.Forms.TreeView();
            this.imlTree = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReload,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.tsbStart,
            this.tsbStop,
            this.tsbRestart});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(346, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbReload
            // 
            this.tsbReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReload.Image = global::DevToolsNet.WindowsApp.Properties.Resources.folder_refresh;
            this.tsbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReload.Name = "tsbReload";
            this.tsbReload.Size = new System.Drawing.Size(23, 22);
            this.tsbReload.Text = "Reload";
            this.tsbReload.Click += new System.EventHandler(this.tsbReload_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::DevToolsNet.WindowsApp.Properties.Resources.refresh;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbStart
            // 
            this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStart.Image = global::DevToolsNet.WindowsApp.Properties.Resources.media_play_green;
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(23, 22);
            this.tsbStart.Text = "Start";
            this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Image = global::DevToolsNet.WindowsApp.Properties.Resources.media_stop_red;
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Text = "Stop";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbRestart
            // 
            this.tsbRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRestart.Image = global::DevToolsNet.WindowsApp.Properties.Resources.media_step_forward;
            this.tsbRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRestart.Name = "tsbRestart";
            this.tsbRestart.Size = new System.Drawing.Size(23, 22);
            this.tsbRestart.Text = "Restart";
            this.tsbRestart.Click += new System.EventHandler(this.tsbRestart_Click);
            // 
            // treeServ
            // 
            this.treeServ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeServ.ImageIndex = 0;
            this.treeServ.ImageList = this.imlTree;
            this.treeServ.Location = new System.Drawing.Point(0, 0);
            this.treeServ.Name = "treeServ";
            this.treeServ.SelectedImageIndex = 0;
            this.treeServ.Size = new System.Drawing.Size(346, 347);
            this.treeServ.TabIndex = 1;
            this.treeServ.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeServ_AfterSelect);
            // 
            // imlTree
            // 
            this.imlTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imlTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTree.ImageStream")));
            this.imlTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTree.Images.SetKeyName(0, "server.png");
            this.imlTree.Images.SetKeyName(1, "help2.png");
            this.imlTree.Images.SetKeyName(2, "nav_plain_green.png");
            this.imlTree.Images.SetKeyName(3, "nav_plain_red.png");
            this.imlTree.Images.SetKeyName(4, "error.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // spltMain
            // 
            this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMain.Location = new System.Drawing.Point(0, 25);
            this.spltMain.Name = "spltMain";
            this.spltMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.Controls.Add(this.treeServ);
            this.spltMain.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.txtMsg);
            this.spltMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spltMain.Size = new System.Drawing.Size(346, 444);
            this.spltMain.SplitterDistance = 347;
            this.spltMain.TabIndex = 2;
            this.spltMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // txtMsg
            // 
            this.txtMsg.AcceptsReturn = true;
            this.txtMsg.AcceptsTab = true;
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(0, 0);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(346, 93);
            this.txtMsg.TabIndex = 0;
            // 
            // frmWinServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 469);
            this.Controls.Add(this.spltMain);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmWinServices";
            this.Text = "Windows Services";
            this.Shown += new System.EventHandler(this.frmWinServices_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            this.spltMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
            this.spltMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private TreeView treeServ;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripButton tsbReload;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbStart;
        private ToolStripButton tsbStop;
        private ToolStripButton tsbRestart;
        private ToolStripButton tsbRefresh;
        private ImageList imlTree;
        private SplitContainer spltMain;
        private TextBox txtMsg;
    }
}