namespace Multiple_Test.Controller.UIModels.LoginInfo
{
    partial class LoginInfo
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
            this.lab_UserName = new Sunny.UI.UILabel();
            this.uiAvatar1 = new Sunny.UI.UIAvatar();
            this.SuspendLayout();
            // 
            // lab_UserName
            // 
            this.lab_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_UserName.AutoEllipsis = true;
            this.lab_UserName.AutoSize = true;
            this.lab_UserName.Font = new System.Drawing.Font("宋体", 12F);
            this.lab_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lab_UserName.Location = new System.Drawing.Point(1009, 40);
            this.lab_UserName.Name = "lab_UserName";
            this.lab_UserName.Size = new System.Drawing.Size(71, 16);
            this.lab_UserName.TabIndex = 136;
            this.lab_UserName.Text = "21103379";
            this.lab_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiAvatar1
            // 
            this.uiAvatar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAvatar1.AvatarSize = 55;
            this.uiAvatar1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiAvatar1.Location = new System.Drawing.Point(1086, 12);
            this.uiAvatar1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar1.Name = "uiAvatar1";
            this.uiAvatar1.Size = new System.Drawing.Size(60, 73);
            this.uiAvatar1.SymbolSize = 48;
            this.uiAvatar1.TabIndex = 135;
            this.uiAvatar1.Text = "uiAvatar1";
            // 
            // LoginInfo
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1158, 91);
            this.Controls.Add(this.lab_UserName);
            this.Controls.Add(this.uiAvatar1);
            this.Name = "LoginInfo";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Text = "LoginInfo";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILabel lab_UserName;
        private Sunny.UI.UIAvatar uiAvatar1;
    }
}