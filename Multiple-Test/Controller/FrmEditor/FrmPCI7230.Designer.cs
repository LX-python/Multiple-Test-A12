namespace Multiple_Test.Controller.FrmEditor
{
    partial class FrmPCI7230
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.cb33v = new Sunny.UI.UIComboBox();
            this.cbCyclinder_Up = new Sunny.UI.UIComboBox();
            this.cbCyclinder_Down = new Sunny.UI.UIComboBox();
            this.pnlBtm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Size = new System.Drawing.Size(360, 55);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(117, 12);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(72, 102);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(79, 16);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "3.3V (DO)";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(48, 138);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(103, 16);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "气缸上升(DO)";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(48, 180);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(103, 16);
            this.linkLabel3.TabIndex = 4;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "气缸到位(DI)";
            // 
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // cb33v
            // 
            this.cb33v.DataSource = null;
            this.cb33v.FillColor = System.Drawing.Color.White;
            this.cb33v.Font = new System.Drawing.Font("SimSun", 12F);
            this.cb33v.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cb33v.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cb33v.Location = new System.Drawing.Point(158, 92);
            this.cb33v.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb33v.MinimumSize = new System.Drawing.Size(63, 0);
            this.cb33v.Name = "cb33v";
            this.cb33v.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cb33v.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cb33v.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.cb33v.Size = new System.Drawing.Size(141, 26);
            this.cb33v.TabIndex = 137;
            this.cb33v.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb33v.Watermark = "请选择脚位";
            // 
            // cbCyclinder_Up
            // 
            this.cbCyclinder_Up.DataSource = null;
            this.cbCyclinder_Up.FillColor = System.Drawing.Color.White;
            this.cbCyclinder_Up.Font = new System.Drawing.Font("SimSun", 12F);
            this.cbCyclinder_Up.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbCyclinder_Up.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbCyclinder_Up.Location = new System.Drawing.Point(158, 138);
            this.cbCyclinder_Up.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCyclinder_Up.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbCyclinder_Up.Name = "cbCyclinder_Up";
            this.cbCyclinder_Up.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbCyclinder_Up.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbCyclinder_Up.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.cbCyclinder_Up.Size = new System.Drawing.Size(141, 26);
            this.cbCyclinder_Up.TabIndex = 138;
            this.cbCyclinder_Up.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbCyclinder_Up.Watermark = "请选择脚位";
            // 
            // cbCyclinder_Down
            // 
            this.cbCyclinder_Down.DataSource = null;
            this.cbCyclinder_Down.FillColor = System.Drawing.Color.White;
            this.cbCyclinder_Down.Font = new System.Drawing.Font("SimSun", 12F);
            this.cbCyclinder_Down.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbCyclinder_Down.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbCyclinder_Down.Location = new System.Drawing.Point(158, 180);
            this.cbCyclinder_Down.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCyclinder_Down.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbCyclinder_Down.Name = "cbCyclinder_Down";
            this.cbCyclinder_Down.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbCyclinder_Down.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.cbCyclinder_Down.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.cbCyclinder_Down.Size = new System.Drawing.Size(141, 26);
            this.cbCyclinder_Down.TabIndex = 139;
            this.cbCyclinder_Down.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbCyclinder_Down.Watermark = "请选择脚位";
            // 
            // FrmPCI7230
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(362, 450);
            this.Controls.Add(this.cbCyclinder_Down);
            this.Controls.Add(this.cbCyclinder_Up);
            this.Controls.Add(this.cb33v);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Name = "FrmPCI7230";
            this.Text = "PCI7230 配置";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.linkLabel2, 0);
            this.Controls.SetChildIndex(this.linkLabel3, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.cb33v, 0);
            this.Controls.SetChildIndex(this.cbCyclinder_Up, 0);
            this.Controls.SetChildIndex(this.cbCyclinder_Down, 0);
            this.pnlBtm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private Sunny.UI.UIComboBox cb33v;
        private Sunny.UI.UIComboBox cbCyclinder_Up;
        private Sunny.UI.UIComboBox cbCyclinder_Down;
    }
}