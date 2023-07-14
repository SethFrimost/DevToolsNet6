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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerador));
            toolStrip1 = new ToolStrip();
            tsbReload = new ToolStripButton();
            tsbManual = new ToolStripButton();
            tsbGenTabManual = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel3 = new ToolStripLabel();
            tscboConection = new ToolStripComboBox();
            toolStripLabel1 = new ToolStripLabel();
            tstSchema = new ToolStripTextBox();
            toolStripLabel2 = new ToolStripLabel();
            tstTable = new ToolStripTextBox();
            tsbLike = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbRun = new ToolStripButton();
            tsbRunAdd = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsbToFiles = new ToolStripButton();
            tstFileTemplate = new ToolStripTextBox();
            splitContainer1 = new SplitContainer();
            treeTemplates = new WinFormsControlLibrary.TreeViewTools();
            spcData = new SplitContainer();
            splitContainer2 = new SplitContainer();
            tvTags = new TreeView();
            imageList1 = new ImageList(components);
            lblManual = new Label();
            txtManual = new TextBox();
            lblGenerarPlantilla = new Label();
            tabResults = new TabControl();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spcData).BeginInit();
            spcData.Panel1.SuspendLayout();
            spcData.Panel2.SuspendLayout();
            spcData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbReload, tsbManual, tsbGenTabManual, toolStripSeparator1, toolStripLabel3, tscboConection, toolStripLabel1, tstSchema, toolStripLabel2, tstTable, tsbLike, toolStripSeparator2, tsbRun, tsbRunAdd, toolStripSeparator3, tsbToFiles, tstFileTemplate });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1230, 25);
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
            // tsbManual
            // 
            tsbManual.CheckOnClick = true;
            tsbManual.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbManual.Image = Properties.Resources.document_new;
            tsbManual.ImageTransparentColor = Color.Magenta;
            tsbManual.Name = "tsbManual";
            tsbManual.Size = new Size(23, 22);
            tsbManual.Text = "Mostrar plantilla manual";
            tsbManual.ToolTipText = "Manual template";
            tsbManual.CheckedChanged += tsbManual_CheckedChanged;
            // 
            // tsbGenTabManual
            // 
            tsbGenTabManual.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbGenTabManual.Image = Properties.Resources.document_refresh;
            tsbGenTabManual.ImageTransparentColor = Color.Magenta;
            tsbGenTabManual.Name = "tsbGenTabManual";
            tsbGenTabManual.Size = new Size(23, 22);
            tsbGenTabManual.Text = "Generar plantilla Manual";
            tsbGenTabManual.ToolTipText = "Generar tab Manual";
            tsbGenTabManual.Visible = false;
            tsbGenTabManual.Click += tsbGenTabManual_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(62, 22);
            toolStripLabel3.Text = "Conection";
            // 
            // tscboConection
            // 
            tscboConection.DropDownWidth = 200;
            tscboConection.Name = "tscboConection";
            tscboConection.Size = new Size(250, 25);
            tscboConection.SelectedIndexChanged += tscboConection_SelectedIndexChanged;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(49, 22);
            toolStripLabel1.Text = "Schema";
            // 
            // tstSchema
            // 
            tstSchema.Name = "tstSchema";
            tstSchema.Size = new Size(120, 25);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(34, 22);
            toolStripLabel2.Text = "Table";
            // 
            // tstTable
            // 
            tstTable.Name = "tstTable";
            tstTable.Size = new Size(200, 25);
            // 
            // tsbLike
            // 
            tsbLike.CheckOnClick = true;
            tsbLike.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbLike.Image = Properties.Resources.percent;
            tsbLike.ImageTransparentColor = Color.Magenta;
            tsbLike.Name = "tsbLike";
            tsbLike.Size = new Size(23, 22);
            tsbLike.Text = "Busqueda LIKE";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // tsbRun
            // 
            tsbRun.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRun.Image = Properties.Resources.media_play;
            tsbRun.ImageTransparentColor = Color.Magenta;
            tsbRun.Name = "tsbRun";
            tsbRun.Size = new Size(23, 22);
            tsbRun.Text = "Generar";
            tsbRun.Click += tsbRun_Click;
            // 
            // tsbRunAdd
            // 
            tsbRunAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRunAdd.Image = Properties.Resources.media_step_forward;
            tsbRunAdd.ImageTransparentColor = Color.Magenta;
            tsbRunAdd.Name = "tsbRunAdd";
            tsbRunAdd.Size = new Size(23, 22);
            tsbRunAdd.Text = "Generar y agregar";
            tsbRunAdd.Click += tsbRunAdd_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // tsbToFiles
            // 
            tsbToFiles.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbToFiles.Image = Properties.Resources.document_into;
            tsbToFiles.ImageTransparentColor = Color.Magenta;
            tsbToFiles.Name = "tsbToFiles";
            tsbToFiles.Size = new Size(23, 22);
            tsbToFiles.Text = "Generar en ficheros separados";
            tsbToFiles.Click += tsbToFiles_Click;
            // 
            // tstFileTemplate
            // 
            tstFileTemplate.Name = "tstFileTemplate";
            tstFileTemplate.Size = new Size(200, 25);
            tstFileTemplate.Text = "[t].cs";
            tstFileTemplate.ToolTipText = "File template: default \"[t].cs\"";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeTemplates);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(spcData);
            splitContainer1.Size = new Size(1230, 542);
            splitContainer1.SplitterDistance = 260;
            splitContainer1.TabIndex = 1;
            // 
            // treeTemplates
            // 
            treeTemplates.CheckBoxes = true;
            treeTemplates.Dock = DockStyle.Fill;
            treeTemplates.Location = new Point(0, 0);
            treeTemplates.Name = "treeTemplates";
            treeTemplates.ShowTools = false;
            treeTemplates.Size = new Size(260, 542);
            treeTemplates.TabIndex = 3;
            treeTemplates.AfterNodeCheck += treeTemplates_AfterNodeCheck;
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
            spcData.Panel1.Controls.Add(splitContainer2);
            // 
            // spcData.Panel2
            // 
            spcData.Panel2.Controls.Add(tabResults);
            spcData.Size = new Size(966, 542);
            spcData.SplitterDistance = 223;
            spcData.TabIndex = 1;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tvTags);
            splitContainer2.Panel1.Controls.Add(lblManual);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(txtManual);
            splitContainer2.Panel2.Controls.Add(lblGenerarPlantilla);
            splitContainer2.Size = new Size(966, 223);
            splitContainer2.SplitterDistance = 178;
            splitContainer2.TabIndex = 1;
            // 
            // tvTags
            // 
            tvTags.Dock = DockStyle.Fill;
            tvTags.ImageIndex = 3;
            tvTags.ImageList = imageList1;
            tvTags.Location = new Point(0, 15);
            tvTags.Name = "tvTags";
            tvTags.SelectedImageIndex = 3;
            tvTags.Size = new Size(178, 208);
            tvTags.TabIndex = 0;
            tvTags.NodeMouseClick += tvTags_NodeMouseClick;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "text_tree.png");
            imageList1.Images.SetKeyName(1, "text_italics.png");
            imageList1.Images.SetKeyName(2, "text.png");
            imageList1.Images.SetKeyName(3, "text_rich.png");
            // 
            // lblManual
            // 
            lblManual.AutoSize = true;
            lblManual.Dock = DockStyle.Top;
            lblManual.Location = new Point(0, 0);
            lblManual.Name = "lblManual";
            lblManual.Size = new Size(92, 15);
            lblManual.TabIndex = 3;
            lblManual.Text = "Plantilla manual";
            // 
            // txtManual
            // 
            txtManual.AcceptsReturn = true;
            txtManual.AcceptsTab = true;
            txtManual.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtManual.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtManual.Location = new Point(0, 15);
            txtManual.Multiline = true;
            txtManual.Name = "txtManual";
            txtManual.ScrollBars = ScrollBars.Both;
            txtManual.Size = new Size(784, 208);
            txtManual.TabIndex = 0;
            txtManual.Text = "<template name=\"manual\">\r\n\r\n</template>";
            txtManual.TextChanged += txtManual_TextChanged;
            // 
            // lblGenerarPlantilla
            // 
            lblGenerarPlantilla.AutoSize = true;
            lblGenerarPlantilla.Cursor = Cursors.Hand;
            lblGenerarPlantilla.Dock = DockStyle.Top;
            lblGenerarPlantilla.ForeColor = SystemColors.Highlight;
            lblGenerarPlantilla.Location = new Point(0, 0);
            lblGenerarPlantilla.Name = "lblGenerarPlantilla";
            lblGenerarPlantilla.Size = new Size(102, 15);
            lblGenerarPlantilla.TabIndex = 5;
            lblGenerarPlantilla.Text = "Generar plantilla...";
            lblGenerarPlantilla.Click += lblGenerarPlantilla_Click;
            // 
            // tabResults
            // 
            tabResults.Dock = DockStyle.Fill;
            tabResults.Location = new Point(0, 0);
            tabResults.Name = "tabResults";
            tabResults.SelectedIndex = 0;
            tabResults.Size = new Size(966, 315);
            tabResults.TabIndex = 0;
            // 
            // frmGenerador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 567);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "frmGenerador";
            Text = "Generador";
            Load += frmGenerador_Load;
            Shown += frmGenerador_Shown;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            spcData.Panel1.ResumeLayout(false);
            spcData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcData).EndInit();
            spcData.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbReload;
        private SplitContainer splitContainer1;
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
        private ToolStripButton tsbRunAdd;
        private TabControl tabResults;
        private ToolStripButton tsbToFiles;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripTextBox tstFileTemplate;
        private ToolStripButton tsbManual;
        private SplitContainer spcData;
        private TextBox txtManual;
        private ToolStripButton tsbGenTabManual;
        private SplitContainer splitContainer2;
        private ImageList imageList1;
        private TreeView tvTags;
        private Label lblManual;
        private Label lblGenerarPlantilla;
        private WinFormsControlLibrary.TreeViewTools treeTemplates;
    }
}