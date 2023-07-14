namespace DevToolsNet.WindowsApp
{
    partial class frmPSGallery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPSGallery));
            toolStrip1 = new ToolStrip();
            tsbReload = new ToolStripButton();
            tsbSave = new ToolStripButton();
            tsbAddGallery = new ToolStripButton();
            tsbAddScript = new ToolStripButton();
            tsbRemGallery = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbRemoveScript = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbExecute = new ToolStripButton();
            tsbClear = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            treeGaleries = new WinFormsControlLibrary.TreeViewTools();
            spcData = new SplitContainer();
            dicEdGlobal = new WinFormsControlLibrary.DictionaryEditor();
            lblGlobalKeys = new Label();
            tabData = new TabControl();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spcData).BeginInit();
            spcData.Panel1.SuspendLayout();
            spcData.Panel2.SuspendLayout();
            spcData.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbReload, tsbSave, tsbAddGallery, tsbAddScript, tsbRemGallery, toolStripSeparator1, tsbRemoveScript, toolStripSeparator2, tsbExecute, tsbClear });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbReload
            // 
            tsbReload.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbReload.Image = Properties.Resources.refresh;
            tsbReload.ImageTransparentColor = Color.Magenta;
            tsbReload.Name = "tsbReload";
            tsbReload.Size = new Size(23, 22);
            tsbReload.Text = "Reload";
            tsbReload.Click += tsbReload_Click;
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSave.Image = Properties.Resources.disk_blue;
            tsbSave.ImageTransparentColor = Color.Magenta;
            tsbSave.Name = "tsbSave";
            tsbSave.Size = new Size(23, 22);
            tsbSave.Text = "Save";
            tsbSave.Click += tsbSave_Click;
            // 
            // tsbAddGallery
            // 
            tsbAddGallery.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddGallery.Image = Properties.Resources.add2;
            tsbAddGallery.ImageTransparentColor = Color.Magenta;
            tsbAddGallery.Name = "tsbAddGallery";
            tsbAddGallery.Size = new Size(23, 22);
            tsbAddGallery.Text = "Add gallery";
            tsbAddGallery.Click += tsbAddGallery_Click;
            // 
            // tsbAddScript
            // 
            tsbAddScript.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddScript.Image = Properties.Resources.document_add;
            tsbAddScript.ImageTransparentColor = Color.Magenta;
            tsbAddScript.Name = "tsbAddScript";
            tsbAddScript.Size = new Size(23, 22);
            tsbAddScript.Text = "Add script";
            tsbAddScript.Click += tsbAddScript_Click;
            // 
            // tsbRemGallery
            // 
            tsbRemGallery.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRemGallery.Image = Properties.Resources.delete2;
            tsbRemGallery.ImageTransparentColor = Color.Magenta;
            tsbRemGallery.Name = "tsbRemGallery";
            tsbRemGallery.Size = new Size(23, 22);
            tsbRemGallery.Text = "Remove selection";
            tsbRemGallery.Click += tsbRemGallery_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            toolStripSeparator1.Visible = false;
            // 
            // tsbRemoveScript
            // 
            tsbRemoveScript.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRemoveScript.Image = Properties.Resources.document_delete;
            tsbRemoveScript.ImageTransparentColor = Color.Magenta;
            tsbRemoveScript.Name = "tsbRemoveScript";
            tsbRemoveScript.Size = new Size(23, 22);
            tsbRemoveScript.Text = "toolStripButton2";
            tsbRemoveScript.Visible = false;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // tsbExecute
            // 
            tsbExecute.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbExecute.Image = Properties.Resources.media_play;
            tsbExecute.ImageTransparentColor = Color.Magenta;
            tsbExecute.Name = "tsbExecute";
            tsbExecute.Size = new Size(23, 22);
            tsbExecute.Text = "Run";
            tsbExecute.Click += tsbExecute_Click;
            // 
            // tsbClear
            // 
            tsbClear.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbClear.Image = Properties.Resources.document_new;
            tsbClear.ImageTransparentColor = Color.Magenta;
            tsbClear.Name = "tsbClear";
            tsbClear.Size = new Size(23, 22);
            tsbClear.Text = "Clear";
            tsbClear.Visible = false;
            tsbClear.Click += tsbClear_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeGaleries);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(spcData);
            splitContainer1.Size = new Size(800, 425);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 1;
            // 
            // treeGaleries
            // 
            treeGaleries.CheckBoxes = true;
            treeGaleries.Dock = DockStyle.Fill;
            treeGaleries.Location = new Point(0, 0);
            treeGaleries.Name = "treeGaleries";
            treeGaleries.ShowTools = true;
            treeGaleries.Size = new Size(266, 425);
            treeGaleries.TabIndex = 0;
            treeGaleries.AfterNodeCheck += treeServers_AfterNodeCheck;
            treeGaleries.AfterNodeSelect += treeGaleries_AfterNodeSelect;
            // 
            // spcData
            // 
            spcData.Dock = DockStyle.Fill;
            spcData.Location = new Point(0, 0);
            spcData.Name = "spcData";
            spcData.Orientation = Orientation.Horizontal;
            // 
            // spcData.Panel1
            // 
            spcData.Panel1.Controls.Add(dicEdGlobal);
            spcData.Panel1.Controls.Add(lblGlobalKeys);
            // 
            // spcData.Panel2
            // 
            spcData.Panel2.Controls.Add(tabData);
            spcData.Size = new Size(530, 425);
            spcData.SplitterDistance = 96;
            spcData.TabIndex = 3;
            // 
            // dicEdGlobal
            // 
            dicEdGlobal.AllowAdd = true;
            dicEdGlobal.AllowDrop = true;
            dicEdGlobal.AllowEditKey = true;
            dicEdGlobal.AllowEditValues = true;
            dicEdGlobal.Dictionary = (Dictionary<string, string>)resources.GetObject("dicEdGlobal.Dictionary");
            dicEdGlobal.Dock = DockStyle.Fill;
            dicEdGlobal.Gap = 3;
            dicEdGlobal.Location = new Point(0, 15);
            dicEdGlobal.Name = "dicEdGlobal";
            dicEdGlobal.Size = new Size(530, 81);
            dicEdGlobal.TabIndex = 0;
            // 
            // lblGlobalKeys
            // 
            lblGlobalKeys.AutoSize = true;
            lblGlobalKeys.Dock = DockStyle.Top;
            lblGlobalKeys.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblGlobalKeys.Location = new Point(0, 0);
            lblGlobalKeys.Name = "lblGlobalKeys";
            lblGlobalKeys.Size = new Size(72, 15);
            lblGlobalKeys.TabIndex = 1;
            lblGlobalKeys.Text = "Gallery vars";
            // 
            // tabData
            // 
            tabData.Dock = DockStyle.Fill;
            tabData.Location = new Point(0, 0);
            tabData.Name = "tabData";
            tabData.SelectedIndex = 0;
            tabData.Size = new Size(530, 325);
            tabData.TabIndex = 2;
            // 
            // frmPSGallery
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "frmPSGallery";
            Text = "Power Shell";
            Load += frmPSGallery_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            spcData.Panel1.ResumeLayout(false);
            spcData.Panel1.PerformLayout();
            spcData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcData).EndInit();
            spcData.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
        private ToolStripButton tsbExecute;
        private WinFormsControlLibrary.TreeViewTools treeGaleries;
        private ToolStripButton tsbClear;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbAddGallery;
        private ToolStripButton tsbRemGallery;
        private TabControl tabData;
        private ToolStripButton tsbReload;
        private ToolStripButton tsbSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbAddScript;
        private ToolStripButton tsbRemoveScript;
        private SplitContainer spcData;
        private WinFormsControlLibrary.DictionaryEditor dicEdGlobal;
        private Label lblGlobalKeys;
    }
}