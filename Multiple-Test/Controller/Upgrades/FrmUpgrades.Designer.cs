namespace ASI_Multiple_Test.Controller.Upgrades
{
    partial class FrmUpgrades
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
            this.uiProcessBar1 = new Sunny.UI.UIProcessBar();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // uiProcessBar1
            // 
            this.uiProcessBar1.DecimalPlaces = 3;
            this.uiProcessBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.uiProcessBar1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiProcessBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiProcessBar1.Location = new System.Drawing.Point(3, 78);
            this.uiProcessBar1.MinimumSize = new System.Drawing.Size(3, 3);
            this.uiProcessBar1.Name = "uiProcessBar1";
            this.uiProcessBar1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.uiProcessBar1.ShowFocusColor = true;
            this.uiProcessBar1.Size = new System.Drawing.Size(842, 42);
            this.uiProcessBar1.Style = Sunny.UI.UIStyle.Custom;
            this.uiProcessBar1.TabIndex = 0;
            this.uiProcessBar1.UseWaitCursor = true;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 52);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(842, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "Processing....";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmUpgrades
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(848, 128);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiProcessBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpgrades";
            this.ShowIcon = false;
            this.Text = "Version update in progress....";
            this.TopMost = true;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIProcessBar uiProcessBar1;
        private Sunny.UI.UILabel uiLabel1;
    }
}