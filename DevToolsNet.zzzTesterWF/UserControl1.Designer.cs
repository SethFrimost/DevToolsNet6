namespace DevToolsNet.zzzTesterWF
{
    partial class UserControl1
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
            p1r = new Panel();
            p1b = new Panel();
            p1a = new Panel();
            button1 = new Button();
            tbMix = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)tbMix).BeginInit();
            SuspendLayout();
            // 
            // p1r
            // 
            p1r.Location = new Point(173, 3);
            p1r.Name = "p1r";
            p1r.Size = new Size(37, 23);
            p1r.TabIndex = 17;
            // 
            // p1b
            // 
            p1b.Location = new Point(130, 3);
            p1b.Name = "p1b";
            p1b.Size = new Size(37, 23);
            p1b.TabIndex = 16;
            // 
            // p1a
            // 
            p1a.Location = new Point(94, 3);
            p1a.Name = "p1a";
            p1a.Size = new Size(37, 23);
            p1a.TabIndex = 15;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 14;
            button1.Text = "select";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbMix
            // 
            tbMix.Location = new Point(216, 3);
            tbMix.Maximum = 100;
            tbMix.Name = "tbMix";
            tbMix.Size = new Size(137, 45);
            tbMix.TabIndex = 18;
            tbMix.TickStyle = TickStyle.None;
            tbMix.Value = 50;
            tbMix.ValueChanged += tbMix_ValueChanged;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbMix);
            Controls.Add(p1r);
            Controls.Add(p1b);
            Controls.Add(p1a);
            Controls.Add(button1);
            Name = "UserControl1";
            Size = new Size(356, 29);
            ((System.ComponentModel.ISupportInitialize)tbMix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel p1r;
        private Panel p1b;
        private Panel p1a;
        private Button button1;
        private TrackBar tbMix;
    }
}
