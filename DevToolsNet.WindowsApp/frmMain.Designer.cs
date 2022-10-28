namespace DevToolsNet.WindowsApp
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGenerador = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSqlRunner = new System.Windows.Forms.ToolStripMenuItem();
            this.windosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSQL,
            this.windosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmSQL
            // 
            this.tsmSQL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGenerador,
            this.tsmiSqlRunner});
            this.tsmSQL.Name = "tsmSQL";
            this.tsmSQL.Size = new System.Drawing.Size(35, 20);
            this.tsmSQL.Text = "Sql";
            // 
            // tsmiGenerador
            // 
            this.tsmiGenerador.Name = "tsmiGenerador";
            this.tsmiGenerador.Size = new System.Drawing.Size(136, 22);
            this.tsmiGenerador.Text = "Generador";
            this.tsmiGenerador.Click += new System.EventHandler(this.tsmiGenerador_Click);
            // 
            // tsmiSqlRunner
            // 
            this.tsmiSqlRunner.Name = "tsmiSqlRunner";
            this.tsmiSqlRunner.Size = new System.Drawing.Size(136, 22);
            this.tsmiSqlRunner.Text = "SQL Runner";
            this.tsmiSqlRunner.Click += new System.EventHandler(this.tsmiSqlRunner_Click);
            // 
            // windosToolStripMenuItem
            // 
            this.windosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.servicesToolStripMenuItem});
            this.windosToolStripMenuItem.Name = "windosToolStripMenuItem";
            this.windosToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windosToolStripMenuItem.Text = "Windows";
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.servicesToolStripMenuItem.Text = "Services";
            this.servicesToolStripMenuItem.Click += new System.EventHandler(this.servicesToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 608);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "DevTools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmSQL;
        private ToolStripMenuItem tsmiGenerador;
        private ToolStripMenuItem tsmiSqlRunner;
        private ToolStripMenuItem windosToolStripMenuItem;
        private ToolStripMenuItem servicesToolStripMenuItem;
    }
}