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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeServerConnections1 = new DevToolsNet.WindowsApp.ServerTrees.TreeServerConnections();
            this.treeServerConnections2 = new DevToolsNet.WindowsApp.ServerTrees.TreeServerConnections();
            this.treeServerServices1 = new DevToolsNet.WindowsApp.ServerTrees.TreeServerServices();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeServerConnections1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeServerServices1);
            this.splitContainer1.Panel2.Controls.Add(this.treeServerConnections2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 409;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeServerConnections1
            // 
            this.treeServerConnections1.CheckBoxes = true;
            this.treeServerConnections1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeServerConnections1.Location = new System.Drawing.Point(0, 0);
            this.treeServerConnections1.Name = "treeServerConnections1";
            this.treeServerConnections1.ShowTools = true;
            this.treeServerConnections1.Size = new System.Drawing.Size(409, 450);
            this.treeServerConnections1.TabIndex = 0;
            // 
            // treeServerConnections2
            // 
            this.treeServerConnections2.CheckBoxes = true;
            this.treeServerConnections2.Location = new System.Drawing.Point(49, 95);
            this.treeServerConnections2.Name = "treeServerConnections2";
            this.treeServerConnections2.ShowTools = true;
            this.treeServerConnections2.Size = new System.Drawing.Size(183, 212);
            this.treeServerConnections2.TabIndex = 0;
            // 
            // treeServerServices1
            // 
            this.treeServerServices1.CheckBoxes = true;
            this.treeServerServices1.Location = new System.Drawing.Point(100, 33);
            this.treeServerServices1.Name = "treeServerServices1";
            this.treeServerServices1.ShowTools = true;
            this.treeServerServices1.Size = new System.Drawing.Size(210, 356);
            this.treeServerServices1.TabIndex = 1;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private ServerTrees.TreeServerConnections treeServerConnections1;
        private ServerTrees.TreeServerServices treeServerServices1;
        private ServerTrees.TreeServerConnections treeServerConnections2;
    }
}