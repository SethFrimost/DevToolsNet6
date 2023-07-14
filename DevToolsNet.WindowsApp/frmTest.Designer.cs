using DevToolsNet.WindowsApp.ServerTreeManager;

namespace DevToolsNet.WindowsApp
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            splitContainer1 = new SplitContainer();
            toolStrip1 = new ToolStrip();
            toolStripTextHosted1 = new WinFormsControlLibrary.ToolStripTextHosted();
            dicEdit = new WinFormsControlLibrary.DictionaryEditor();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dicEdit);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 409;
            splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripTextHosted1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(409, 26);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextHosted1
            // 
            toolStripTextHosted1.Name = "toolStripTextHosted1";
            toolStripTextHosted1.Size = new Size(121, 23);
            toolStripTextHosted1.Text = "toolStripTextHosted1";
            // 
            // toolStripTextHosted1
            // 
            toolStripTextHosted1.TextBox.AccessibleName = "toolStripTextHosted1";
            toolStripTextHosted1.TextBox.Location = new Point(9, 1);
            toolStripTextHosted1.TextBox.Name = "toolStripTextHosted1";
            toolStripTextHosted1.TextBox.Size = new Size(121, 23);
            toolStripTextHosted1.TextBox.TabIndex = 1;
            toolStripTextHosted1.TextBox.Text = "toolStripTextHosted1";
            // 
            // dicEdit
            // 
            dicEdit.AllowAdd = true;
            dicEdit.AllowEditKey = true;
            dicEdit.AllowEditValues = true;
            dicEdit.BackColor = SystemColors.ControlLightLight;
            dicEdit.Dictionary = (Dictionary<string, string>)resources.GetObject("dicEdit.Dictionary");
            dicEdit.Dock = DockStyle.Top;
            dicEdit.Gap = 3;
            dicEdit.Location = new Point(0, 0);
            dicEdit.Name = "dicEdit";
            dicEdit.Size = new Size(387, 107);
            dicEdit.TabIndex = 0;
            // 
            // frmTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "frmTest";
            Text = "frmTest";
            Load += frmTest_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ToolStrip toolStrip1;
        private WinFormsControlLibrary.ToolStripTextHosted toolStripTextHosted1;
        private WinFormsControlLibrary.DictionaryEditor dicEdit;
    }
}