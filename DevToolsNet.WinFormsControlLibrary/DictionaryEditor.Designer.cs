namespace DevToolsNet.WinFormsControlLibrary
{
    partial class DictionaryEditor
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
            spc = new SplitContainer();
            pKeys = new Panel();
            lblKey = new Label();
            pValues = new Panel();
            lblValue = new Label();
            ((System.ComponentModel.ISupportInitialize)spc).BeginInit();
            spc.Panel1.SuspendLayout();
            spc.Panel2.SuspendLayout();
            spc.SuspendLayout();
            SuspendLayout();
            // 
            // spc
            // 
            spc.Dock = DockStyle.Fill;
            spc.Location = new Point(0, 0);
            spc.Name = "spc";
            // 
            // spc.Panel1
            // 
            spc.Panel1.Controls.Add(pKeys);
            spc.Panel1.Controls.Add(lblKey);
            // 
            // spc.Panel2
            // 
            spc.Panel2.AutoScroll = true;
            spc.Panel2.Controls.Add(pValues);
            spc.Panel2.Controls.Add(lblValue);
            spc.Size = new Size(744, 150);
            spc.SplitterDistance = 248;
            spc.TabIndex = 0;
            spc.TabStop = false;
            // 
            // pKeys
            // 
            pKeys.Dock = DockStyle.Fill;
            pKeys.Location = new Point(0, 15);
            pKeys.Name = "pKeys";
            pKeys.Size = new Size(248, 135);
            pKeys.TabIndex = 1;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Dock = DockStyle.Top;
            lblKey.Location = new Point(0, 0);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(26, 15);
            lblKey.TabIndex = 0;
            lblKey.Text = "Key";
            // 
            // pValues
            // 
            pValues.AutoScroll = true;
            pValues.Dock = DockStyle.Fill;
            pValues.Location = new Point(0, 15);
            pValues.Name = "pValues";
            pValues.Size = new Size(492, 135);
            pValues.TabIndex = 2;
            pValues.Scroll += pValues_Scroll;
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Dock = DockStyle.Top;
            lblValue.Location = new Point(0, 0);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(35, 15);
            lblValue.TabIndex = 1;
            lblValue.Text = "Value";
            // 
            // DictionaryEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(spc);
            Name = "DictionaryEditor";
            Size = new Size(744, 150);
            spc.Panel1.ResumeLayout(false);
            spc.Panel1.PerformLayout();
            spc.Panel2.ResumeLayout(false);
            spc.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)spc).EndInit();
            spc.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer spc;
        private Label lblKey;
        private Label lblValue;
        private Panel pKeys;
        private Panel pValues;
    }
}
