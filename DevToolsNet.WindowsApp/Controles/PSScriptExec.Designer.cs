namespace DevToolsNet.WindowsApp.Controles
{
    partial class PSScriptExec
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
            txtRes = new TextBox();
            psScriptEdit = new WinFormsControlLibrary.PSScriptEdit();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // txtRes
            // 
            txtRes.AcceptsReturn = true;
            txtRes.AcceptsTab = true;
            txtRes.BackColor = SystemColors.InactiveCaption;
            txtRes.Dock = DockStyle.Fill;
            txtRes.Location = new Point(0, 0);
            txtRes.Multiline = true;
            txtRes.Name = "txtRes";
            txtRes.Size = new Size(566, 83);
            txtRes.TabIndex = 1;
            // 
            // psScriptEdit
            // 
            psScriptEdit.Code = "";
            psScriptEdit.Dictionary = null;
            psScriptEdit.Dock = DockStyle.Fill;
            psScriptEdit.Location = new Point(0, 0);
            psScriptEdit.Name = "psScriptEdit";
            psScriptEdit.Size = new Size(566, 300);
            psScriptEdit.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(psScriptEdit);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtRes);
            splitContainer1.Size = new Size(566, 387);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 4;
            // 
            // PSScriptExec
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "PSScriptExec";
            Size = new Size(566, 387);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public TextBox txtRes;
        public WinFormsControlLibrary.PSScriptEdit psScriptEdit;
        private SplitContainer splitContainer1;
    }
}
