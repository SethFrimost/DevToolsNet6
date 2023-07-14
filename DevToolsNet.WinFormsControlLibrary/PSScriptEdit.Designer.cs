namespace DevToolsNet.WinFormsControlLibrary
{
    partial class PSScriptEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSScriptEdit));
            spcMain = new SplitContainer();
            dicEdit = new DictionaryEditor();
            txtCode = new TextBox();
            ((System.ComponentModel.ISupportInitialize)spcMain).BeginInit();
            spcMain.Panel1.SuspendLayout();
            spcMain.Panel2.SuspendLayout();
            spcMain.SuspendLayout();
            SuspendLayout();
            // 
            // spcMain
            // 
            spcMain.Dock = DockStyle.Fill;
            spcMain.Location = new Point(0, 0);
            spcMain.Name = "spcMain";
            spcMain.Orientation = Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            spcMain.Panel1.Controls.Add(dicEdit);
            // 
            // spcMain.Panel2
            // 
            spcMain.Panel2.Controls.Add(txtCode);
            spcMain.Size = new Size(447, 210);
            spcMain.SplitterDistance = 48;
            spcMain.TabIndex = 3;
            // 
            // dicEdit
            // 
            dicEdit.AllowAdd = true;
            dicEdit.AllowEditKey = true;
            dicEdit.AllowEditValues = true;
            dicEdit.BackColor = SystemColors.ControlLightLight;
            dicEdit.Dictionary = (Dictionary<string, string>)resources.GetObject("dicEdit.Dictionary");
            dicEdit.Dock = DockStyle.Fill;
            dicEdit.Gap = 3;
            dicEdit.Location = new Point(0, 0);
            dicEdit.Name = "dicEdit";
            dicEdit.Size = new Size(447, 48);
            dicEdit.TabIndex = 1;
            // 
            // txtCode
            // 
            txtCode.AcceptsReturn = true;
            txtCode.AcceptsTab = true;
            txtCode.Dock = DockStyle.Fill;
            txtCode.Location = new Point(0, 0);
            txtCode.Multiline = true;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(447, 158);
            txtCode.TabIndex = 0;
            // 
            // PSScriptEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(spcMain);
            Name = "PSScriptEdit";
            Size = new Size(447, 210);
            spcMain.Panel1.ResumeLayout(false);
            spcMain.Panel2.ResumeLayout(false);
            spcMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)spcMain).EndInit();
            spcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer spcMain;
        public TextBox txtCode;
        public DictionaryEditor dicEdit;
    }
}
