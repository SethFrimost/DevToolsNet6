namespace DevToolsNet.WindowsApp
{
    partial class frmGenerador
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tscboConection = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstSchema = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstTable = new System.Windows.Forms.ToolStripTextBox();
            this.tsbLike = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRun = new System.Windows.Forms.ToolStripButton();
            this.tsbRunAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbToFiles = new System.Windows.Forms.ToolStripButton();
            this.tstFileTemplate = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkPlantillas = new System.Windows.Forms.CheckedListBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.tabResults = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReload,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.tscboConection,
            this.toolStripLabel1,
            this.tstSchema,
            this.toolStripLabel2,
            this.tstTable,
            this.tsbLike,
            this.toolStripSeparator2,
            this.tsbRun,
            this.tsbRunAdd,
            this.toolStripSeparator3,
            this.tsbToFiles,
            this.tstFileTemplate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1092, 25);
            this.toolStrip1.TabIndex = 0;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(62, 22);
            this.toolStripLabel3.Text = "Conection";
            // 
            // tscboConection
            // 
            this.tscboConection.DropDownWidth = 200;
            this.tscboConection.Name = "tscboConection";
            this.tscboConection.Size = new System.Drawing.Size(250, 25);
            this.tscboConection.SelectedIndexChanged += new System.EventHandler(this.tscboConection_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel1.Text = "Schema";
            // 
            // tstSchema
            // 
            this.tstSchema.Name = "tstSchema";
            this.tstSchema.Size = new System.Drawing.Size(120, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel2.Text = "Table";
            // 
            // tstTable
            // 
            this.tstTable.Name = "tstTable";
            this.tstTable.Size = new System.Drawing.Size(200, 25);
            // 
            // tsbLike
            // 
            this.tsbLike.CheckOnClick = true;
            this.tsbLike.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLike.Image = global::DevToolsNet.WindowsApp.Properties.Resources.percent;
            this.tsbLike.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLike.Name = "tsbLike";
            this.tsbLike.Size = new System.Drawing.Size(23, 22);
            this.tsbLike.Text = "toolStripButton1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // tsbRunAdd
            // 
            this.tsbRunAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRunAdd.Image = global::DevToolsNet.WindowsApp.Properties.Resources.media_step_forward;
            this.tsbRunAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunAdd.Name = "tsbRunAdd";
            this.tsbRunAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbRunAdd.Text = "toolStripButton1";
            this.tsbRunAdd.Click += new System.EventHandler(this.tsbRunAdd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbToFiles
            // 
            this.tsbToFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbToFiles.Image = global::DevToolsNet.WindowsApp.Properties.Resources.document_into;
            this.tsbToFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToFiles.Name = "tsbToFiles";
            this.tsbToFiles.Size = new System.Drawing.Size(23, 22);
            this.tsbToFiles.Text = "Generar en ficheros separados";
            this.tsbToFiles.Click += new System.EventHandler(this.tsbToFiles_Click);
            // 
            // tstFileTemplate
            // 
            this.tstFileTemplate.Name = "tstFileTemplate";
            this.tstFileTemplate.Size = new System.Drawing.Size(200, 25);
            this.tstFileTemplate.Text = "[t].cs";
            this.tstFileTemplate.ToolTipText = "File template: default \"[t].cs\"";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkPlantillas);
            this.splitContainer1.Panel1.Controls.Add(this.txtFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabResults);
            this.splitContainer1.Size = new System.Drawing.Size(1092, 542);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.TabIndex = 1;
            // 
            // chkPlantillas
            // 
            this.chkPlantillas.CheckOnClick = true;
            this.chkPlantillas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkPlantillas.FormattingEnabled = true;
            this.chkPlantillas.Location = new System.Drawing.Point(0, 23);
            this.chkPlantillas.Name = "chkPlantillas";
            this.chkPlantillas.Size = new System.Drawing.Size(231, 519);
            this.chkPlantillas.TabIndex = 2;
            this.chkPlantillas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkPlantillas_ItemCheck);
            // 
            // txtFilter
            // 
            this.txtFilter.BackColor = System.Drawing.SystemColors.Info;
            this.txtFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFilter.Location = new System.Drawing.Point(0, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(231, 23);
            this.txtFilter.TabIndex = 1;
            // 
            // tabResults
            // 
            this.tabResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResults.Location = new System.Drawing.Point(0, 0);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.Size = new System.Drawing.Size(857, 542);
            this.tabResults.TabIndex = 0;
            // 
            // frmGenerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 567);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmGenerador";
            this.Text = "Generador";
            this.Load += new System.EventHandler(this.frmGenerador_Load);
            this.Shown += new System.EventHandler(this.frmGenerador_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbReload;
        private SplitContainer splitContainer1;
        private TextBox txtFilter;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel3;
        private ToolStripComboBox tscboConection;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tstSchema;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox tstTable;
        private ToolStripButton tsbLike;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbRun;
        private CheckedListBox chkPlantillas;
        private ToolStripButton tsbRunAdd;
        private TabControl tabResults;
        private ToolStripButton tsbToFiles;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripTextBox tstFileTemplate;
    }
}