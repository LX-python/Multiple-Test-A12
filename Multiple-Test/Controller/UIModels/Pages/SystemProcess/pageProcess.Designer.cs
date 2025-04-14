namespace Multiple_Test.Controller.UIModels.Pages.SystemProcess
{
    partial class pageProcess
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
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiWaitingBar1 = new Sunny.UI.UIWaitingBar();
            this.SuspendLayout();
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.Location = new System.Drawing.Point(17, 87);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(753, 20);
            this.uiLine1.TabIndex = 91;
            this.uiLine1.Text = "Waiting Testing";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiWaitingBar1
            // 
            this.uiWaitingBar1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiWaitingBar1.Location = new System.Drawing.Point(17, 121);
            this.uiWaitingBar1.MinimumSize = new System.Drawing.Size(70, 23);
            this.uiWaitingBar1.Name = "uiWaitingBar1";
            this.uiWaitingBar1.Size = new System.Drawing.Size(760, 29);
            this.uiWaitingBar1.TabIndex = 90;
            this.uiWaitingBar1.Text = "uiWaitingBar1";
            // 
            // pageProcess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 217);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.uiWaitingBar1);
            this.MaximizeBox = false;
            this.Name = "pageProcess";
            this.ShowInTaskbar = false;
            this.Text = "Testing";
            this.TopMost = true;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UIWaitingBar uiWaitingBar1;
    }
}