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
            menuStrip1 = new MenuStrip();
            tsmSQL = new ToolStripMenuItem();
            tsmiGenerador = new ToolStripMenuItem();
            tsmiSqlRunner = new ToolStripMenuItem();
            windosToolStripMenuItem = new ToolStripMenuItem();
            servicesToolStripMenuItem = new ToolStripMenuItem();
            powerShellToolStripMenuItem = new ToolStripMenuItem();
            tsmiPSGallery = new ToolStripMenuItem();
            tCPToolStripMenuItem = new ToolStripMenuItem();
            tcpServerToolStripMenuItem = new ToolStripMenuItem();
            tcpClientToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmSQL, windosToolStripMenuItem, tCPToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1013, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmSQL
            // 
            tsmSQL.DropDownItems.AddRange(new ToolStripItem[] { tsmiGenerador, tsmiSqlRunner });
            tsmSQL.Name = "tsmSQL";
            tsmSQL.Size = new Size(35, 20);
            tsmSQL.Text = "Sql";
            // 
            // tsmiGenerador
            // 
            tsmiGenerador.Name = "tsmiGenerador";
            tsmiGenerador.Size = new Size(136, 22);
            tsmiGenerador.Text = "Generador";
            tsmiGenerador.Click += tsmiGenerador_Click;
            // 
            // tsmiSqlRunner
            // 
            tsmiSqlRunner.Name = "tsmiSqlRunner";
            tsmiSqlRunner.Size = new Size(136, 22);
            tsmiSqlRunner.Text = "SQL Runner";
            tsmiSqlRunner.Click += tsmiSqlRunner_Click;
            // 
            // windosToolStripMenuItem
            // 
            windosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { servicesToolStripMenuItem, powerShellToolStripMenuItem, tsmiPSGallery });
            windosToolStripMenuItem.Name = "windosToolStripMenuItem";
            windosToolStripMenuItem.Size = new Size(68, 20);
            windosToolStripMenuItem.Text = "Windows";
            // 
            // servicesToolStripMenuItem
            // 
            servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            servicesToolStripMenuItem.Size = new Size(135, 22);
            servicesToolStripMenuItem.Text = "Services";
            servicesToolStripMenuItem.Click += servicesToolStripMenuItem_Click;
            // 
            // powerShellToolStripMenuItem
            // 
            powerShellToolStripMenuItem.Name = "powerShellToolStripMenuItem";
            powerShellToolStripMenuItem.Size = new Size(135, 22);
            powerShellToolStripMenuItem.Text = "Power Shell";
            powerShellToolStripMenuItem.Click += powerShellToolStripMenuItem_Click;
            // 
            // tsmiPSGallery
            // 
            tsmiPSGallery.Name = "tsmiPSGallery";
            tsmiPSGallery.Size = new Size(135, 22);
            tsmiPSGallery.Text = "PS Gallery";
            tsmiPSGallery.Click += tsmiPSGallery_Click;
            // 
            // tCPToolStripMenuItem
            // 
            tCPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tcpServerToolStripMenuItem, tcpClientToolStripMenuItem });
            tCPToolStripMenuItem.Name = "tCPToolStripMenuItem";
            tCPToolStripMenuItem.Size = new Size(39, 20);
            tCPToolStripMenuItem.Text = "TCP";
            // 
            // tcpServerToolStripMenuItem
            // 
            tcpServerToolStripMenuItem.Name = "tcpServerToolStripMenuItem";
            tcpServerToolStripMenuItem.Size = new Size(106, 22);
            tcpServerToolStripMenuItem.Text = "Server";
            tcpServerToolStripMenuItem.Click += tcpServerToolStripMenuItem_Click;
            // 
            // tcpClientToolStripMenuItem
            // 
            tcpClientToolStripMenuItem.Name = "tcpClientToolStripMenuItem";
            tcpClientToolStripMenuItem.Size = new Size(106, 22);
            tcpClientToolStripMenuItem.Text = "Client";
            tcpClientToolStripMenuItem.Click += tcpClientToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 608);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            Text = "Dev tools";
            WindowState = FormWindowState.Maximized;
            Shown += frmMain_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmSQL;
        private ToolStripMenuItem tsmiGenerador;
        private ToolStripMenuItem tsmiSqlRunner;
        private ToolStripMenuItem windosToolStripMenuItem;
        private ToolStripMenuItem servicesToolStripMenuItem;
        private ToolStripMenuItem powerShellToolStripMenuItem;
        private ToolStripMenuItem tCPToolStripMenuItem;
        private ToolStripMenuItem tcpServerToolStripMenuItem;
        private ToolStripMenuItem tcpClientToolStripMenuItem;
        private ToolStripMenuItem tsmiPSGallery;
    }
}