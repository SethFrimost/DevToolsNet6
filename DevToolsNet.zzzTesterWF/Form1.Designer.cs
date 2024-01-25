namespace DevToolsNet.zzzTesterWF
{
    partial class Form1
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
            colorDialog1 = new ColorDialog();
            userControl11 = new UserControl1();
            userControl12 = new UserControl1();
            userControl13 = new UserControl1();
            userControl14 = new UserControl1();
            userControl15 = new UserControl1();
            SuspendLayout();
            // 
            // userControl11
            // 
            userControl11.Location = new Point(12, 12);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(356, 29);
            userControl11.TabIndex = 0;
            // 
            // userControl12
            // 
            userControl12.Location = new Point(12, 47);
            userControl12.Name = "userControl12";
            userControl12.Size = new Size(356, 29);
            userControl12.TabIndex = 1;
            // 
            // userControl13
            // 
            userControl13.Location = new Point(12, 82);
            userControl13.Name = "userControl13";
            userControl13.Size = new Size(356, 29);
            userControl13.TabIndex = 2;
            // 
            // userControl14
            // 
            userControl14.Location = new Point(12, 117);
            userControl14.Name = "userControl14";
            userControl14.Size = new Size(356, 29);
            userControl14.TabIndex = 3;
            // 
            // userControl15
            // 
            userControl15.Location = new Point(12, 152);
            userControl15.Name = "userControl15";
            userControl15.Size = new Size(356, 29);
            userControl15.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(userControl15);
            Controls.Add(userControl14);
            Controls.Add(userControl13);
            Controls.Add(userControl12);
            Controls.Add(userControl11);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ColorDialog colorDialog1;
        private UserControl1 userControl11;
        private UserControl1 userControl12;
        private UserControl1 userControl13;
        private UserControl1 userControl14;
        private UserControl1 userControl15;
    }
}