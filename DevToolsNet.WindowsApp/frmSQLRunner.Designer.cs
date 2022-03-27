namespace DevToolsNet.WindowsApp
{
    partial class frmSQLRunner
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
            this.textEditorControlEx1 = new ICSharpCode.TextEditor.TextEditorControlEx();
            this.SuspendLayout();
            // 
            // textEditorControlEx1
            // 
            this.textEditorControlEx1.FoldingStrategy = null;
            this.textEditorControlEx1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textEditorControlEx1.Location = new System.Drawing.Point(76, 29);
            this.textEditorControlEx1.Name = "textEditorControlEx1";
            this.textEditorControlEx1.Size = new System.Drawing.Size(598, 376);
            this.textEditorControlEx1.SyntaxHighlighting = null;
            this.textEditorControlEx1.TabIndex = 1;
            this.textEditorControlEx1.Text = "textEditorControlEx1";
            // 
            // frmSQLRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textEditorControlEx1);
            this.Name = "frmSQLRunner";
            this.Text = "frmSQLEjecutor";
            this.Load += new System.EventHandler(this.frmSQLRunner_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ICSharpCode.TextEditor.TextEditorControlEx textEditorControlEx1;
    }
}