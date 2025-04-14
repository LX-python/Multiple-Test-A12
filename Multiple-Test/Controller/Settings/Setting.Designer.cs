namespace Multiple_Test.Controller.Settings
{
    partial class Setting
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
            this.comCustomer = new Sunny.UI.UIComboBox();
            this.uiLine3 = new Sunny.UI.UILine();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiRadioButton4 = new Sunny.UI.UIRadioButton();
            this.uiRadioButton1 = new Sunny.UI.UIRadioButton();
            this.SuspendLayout();
            // 
            // comCustomer
            // 
            this.comCustomer.DataSource = null;
            this.comCustomer.FillColor = System.Drawing.Color.White;
            this.comCustomer.Font = new System.Drawing.Font("宋体", 12F);
            this.comCustomer.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.comCustomer.Items.AddRange(new object[] {
            "CA",
            "CZ",
            "GZ_CASE",
            "GZ_AEA",
            "GZ_QX",
            "SJ"});
            this.comCustomer.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comCustomer.Location = new System.Drawing.Point(110, 76);
            this.comCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comCustomer.MinimumSize = new System.Drawing.Size(63, 0);
            this.comCustomer.Name = "comCustomer";
            this.comCustomer.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comCustomer.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.comCustomer.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.comCustomer.Size = new System.Drawing.Size(221, 26);
            this.comCustomer.TabIndex = 137;
            this.comCustomer.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comCustomer.Watermark = "请选择语言";
            // 
            // uiLine3
            // 
            this.uiLine3.BackColor = System.Drawing.Color.Transparent;
            this.uiLine3.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine3.Location = new System.Drawing.Point(24, 77);
            this.uiLine3.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(80, 20);
            this.uiLine3.TabIndex = 136;
            this.uiLine3.Text = "语言:";
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.Location = new System.Drawing.Point(24, 128);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(80, 20);
            this.uiLine1.TabIndex = 138;
            this.uiLine1.Text = "Model:";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRadioButton4
            // 
            this.uiRadioButton4.Checked = true;
            this.uiRadioButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton4.Font = new System.Drawing.Font("宋体", 12F);
            this.uiRadioButton4.GroupIndex = 1;
            this.uiRadioButton4.Location = new System.Drawing.Point(111, 128);
            this.uiRadioButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton4.Name = "uiRadioButton4";
            this.uiRadioButton4.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton4.Size = new System.Drawing.Size(102, 23);
            this.uiRadioButton4.TabIndex = 139;
            this.uiRadioButton4.Text = "OnLine";
            // 
            // uiRadioButton1
            // 
            this.uiRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiRadioButton1.GroupIndex = 1;
            this.uiRadioButton1.Location = new System.Drawing.Point(223, 128);
            this.uiRadioButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton1.Name = "uiRadioButton1";
            this.uiRadioButton1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton1.Size = new System.Drawing.Size(102, 23);
            this.uiRadioButton1.TabIndex = 140;
            this.uiRadioButton1.Text = "OffLine";
            // 
            // Setting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(614, 252);
            this.Controls.Add(this.uiRadioButton1);
            this.Controls.Add(this.uiRadioButton4);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.comCustomer);
            this.Controls.Add(this.uiLine3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.Text = "Setting";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIComboBox comCustomer;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UIRadioButton uiRadioButton4;
        private Sunny.UI.UIRadioButton uiRadioButton1;
    }
}