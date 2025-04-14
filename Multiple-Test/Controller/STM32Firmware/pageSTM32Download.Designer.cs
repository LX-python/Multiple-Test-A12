namespace Multiple_Test.Controller.STM32
{
    partial class pageSTM32Download
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageSTM32Download));
            this.uiLine1 = new Sunny.UI.UILine();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenHex = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenLog = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mCUConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            this.txtVersion = new Sunny.UI.UITextBox();
            this.linePath = new Sunny.UI.UILine();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.uiLine3 = new Sunny.UI.UILine();
            this.lab_UserName = new Sunny.UI.UILabel();
            this.uiAvatar1 = new Sunny.UI.UIAvatar();
            this.PieChart = new Sunny.UI.UIPieChart();
            this.BarChart = new Sunny.UI.UIBarChart();
            this.uiMarkLabel3 = new Sunny.UI.UIMarkLabel();
            this.txtSelectVersion = new Sunny.UI.UITextBox();
            this.uiMarkLabel2 = new Sunny.UI.UIMarkLabel();
            this.txtAddress = new Sunny.UI.UITextBox();
            this.uiMarkLabel4 = new Sunny.UI.UIMarkLabel();
            this.txtSize = new Sunny.UI.UITextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLine1
            // 
            this.uiLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.Location = new System.Drawing.Point(29, 71);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(1096, 20);
            this.uiLine1.TabIndex = 37;
            this.uiLine1.Text = "版本配置";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLine1.Click += new System.EventHandler(this.uiLine1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.btnRun,
            this.mCUConfigToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 36);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 25);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenHex,
            this.btnOpenLog});
            this.fileToolStripMenuItem.Image = global::Multiple_Test.Properties.Resources.network_folder;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnOpenHex
            // 
            this.btnOpenHex.Image = global::Multiple_Test.Properties.Resources.添加;
            this.btnOpenHex.Name = "btnOpenHex";
            this.btnOpenHex.Size = new System.Drawing.Size(134, 22);
            this.btnOpenHex.Text = "Open Hex";
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Image = global::Multiple_Test.Properties.Resources.network_folder;
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(134, 22);
            this.btnOpenLog.Text = "Open Log";
            // 
            // btnRun
            // 
            this.btnRun.Image = global::Multiple_Test.Properties.Resources.start;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(58, 21);
            this.btnRun.Text = "Run";
            // 
            // mCUConfigToolStripMenuItem
            // 
            this.mCUConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initToolStripMenuItem});
            this.mCUConfigToolStripMenuItem.Image = global::Multiple_Test.Properties.Resources._619b996fd2734df1b83bfb5a0964f8cc_0;
            this.mCUConfigToolStripMenuItem.Name = "mCUConfigToolStripMenuItem";
            this.mCUConfigToolStripMenuItem.Size = new System.Drawing.Size(108, 21);
            this.mCUConfigToolStripMenuItem.Text = "MCU-Config";
            // 
            // initToolStripMenuItem
            // 
            this.initToolStripMenuItem.Name = "initToolStripMenuItem";
            this.initToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.initToolStripMenuItem.Text = "Init";
            this.initToolStripMenuItem.Click += new System.EventHandler(this.initToolStripMenuItem_Click);
            // 
            // uiMarkLabel1
            // 
            this.uiMarkLabel1.AutoSize = true;
            this.uiMarkLabel1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiMarkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel1.Location = new System.Drawing.Point(265, 96);
            this.uiMarkLabel1.MarkColor = System.Drawing.Color.Red;
            this.uiMarkLabel1.Name = "uiMarkLabel1";
            this.uiMarkLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel1.Size = new System.Drawing.Size(84, 16);
            this.uiMarkLabel1.TabIndex = 70;
            this.uiMarkLabel1.Text = "預設版本:";
            this.uiMarkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVersion
            // 
            this.txtVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVersion.Font = new System.Drawing.Font("宋体", 12F);
            this.txtVersion.Location = new System.Drawing.Point(353, 91);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVersion.Maximum = 5000D;
            this.txtVersion.MaxLength = 50;
            this.txtVersion.Minimum = 50D;
            this.txtVersion.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Padding = new System.Windows.Forms.Padding(5);
            this.txtVersion.ShowText = false;
            this.txtVersion.Size = new System.Drawing.Size(150, 26);
            this.txtVersion.TabIndex = 69;
            this.txtVersion.Tag = "0";
            this.txtVersion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtVersion.Watermark = "";
            // 
            // linePath
            // 
            this.linePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linePath.BackColor = System.Drawing.Color.Transparent;
            this.linePath.Font = new System.Drawing.Font("宋体", 12F);
            this.linePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.linePath.Location = new System.Drawing.Point(8, 122);
            this.linePath.MinimumSize = new System.Drawing.Size(16, 16);
            this.linePath.Name = "linePath";
            this.linePath.Size = new System.Drawing.Size(1092, 20);
            this.linePath.TabIndex = 71;
            this.linePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiRichTextBox1.FillColor = System.Drawing.Color.White;
            this.uiRichTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRichTextBox1.Location = new System.Drawing.Point(8, 400);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.ReadOnly = true;
            this.uiRichTextBox1.ScrollBarStyleInherited = false;
            this.uiRichTextBox1.ShowText = false;
            this.uiRichTextBox1.Size = new System.Drawing.Size(1172, 226);
            this.uiRichTextBox1.TabIndex = 138;
            this.uiRichTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLine3
            // 
            this.uiLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine3.BackColor = System.Drawing.Color.Transparent;
            this.uiLine3.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine3.Location = new System.Drawing.Point(8, 372);
            this.uiLine3.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(1172, 20);
            this.uiLine3.TabIndex = 139;
            this.uiLine3.Text = "Logs:";
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_UserName
            // 
            this.lab_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_UserName.AutoEllipsis = true;
            this.lab_UserName.AutoSize = true;
            this.lab_UserName.Font = new System.Drawing.Font("宋体", 12F);
            this.lab_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lab_UserName.Location = new System.Drawing.Point(1037, 94);
            this.lab_UserName.Name = "lab_UserName";
            this.lab_UserName.Size = new System.Drawing.Size(71, 16);
            this.lab_UserName.TabIndex = 141;
            this.lab_UserName.Text = "21103379";
            this.lab_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiAvatar1
            // 
            this.uiAvatar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAvatar1.AvatarSize = 55;
            this.uiAvatar1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiAvatar1.Location = new System.Drawing.Point(1114, 66);
            this.uiAvatar1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar1.Name = "uiAvatar1";
            this.uiAvatar1.Size = new System.Drawing.Size(60, 73);
            this.uiAvatar1.SymbolSize = 48;
            this.uiAvatar1.TabIndex = 140;
            this.uiAvatar1.Text = "uiAvatar1";
            // 
            // PieChart
            // 
            this.PieChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PieChart.Font = new System.Drawing.Font("宋体", 12F);
            this.PieChart.LegendFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PieChart.Location = new System.Drawing.Point(864, 145);
            this.PieChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.PieChart.Name = "PieChart";
            this.PieChart.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.PieChart.Size = new System.Drawing.Size(310, 222);
            this.PieChart.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PieChart.TabIndex = 142;
            this.PieChart.Text = "uiPieChart1";
            // 
            // BarChart
            // 
            this.BarChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarChart.Font = new System.Drawing.Font("宋体", 12F);
            this.BarChart.LegendFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BarChart.Location = new System.Drawing.Point(8, 145);
            this.BarChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.BarChart.Name = "BarChart";
            this.BarChart.Size = new System.Drawing.Size(850, 222);
            this.BarChart.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BarChart.TabIndex = 143;
            this.BarChart.Text = "uiBarChart1";
            // 
            // uiMarkLabel3
            // 
            this.uiMarkLabel3.AutoSize = true;
            this.uiMarkLabel3.Font = new System.Drawing.Font("宋体", 12F);
            this.uiMarkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel3.Location = new System.Drawing.Point(4, 96);
            this.uiMarkLabel3.MarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiMarkLabel3.Name = "uiMarkLabel3";
            this.uiMarkLabel3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel3.Size = new System.Drawing.Size(100, 16);
            this.uiMarkLabel3.TabIndex = 72;
            this.uiMarkLabel3.Text = "選擇的版本:";
            this.uiMarkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSelectVersion
            // 
            this.txtSelectVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSelectVersion.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSelectVersion.Location = new System.Drawing.Point(105, 91);
            this.txtSelectVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSelectVersion.Maximum = 5000D;
            this.txtSelectVersion.MaxLength = 50;
            this.txtSelectVersion.Minimum = 50D;
            this.txtSelectVersion.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSelectVersion.Name = "txtSelectVersion";
            this.txtSelectVersion.Padding = new System.Windows.Forms.Padding(5);
            this.txtSelectVersion.ReadOnly = true;
            this.txtSelectVersion.ShowText = false;
            this.txtSelectVersion.Size = new System.Drawing.Size(149, 26);
            this.txtSelectVersion.TabIndex = 71;
            this.txtSelectVersion.Tag = "0";
            this.txtSelectVersion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSelectVersion.Watermark = "";
            // 
            // uiMarkLabel2
            // 
            this.uiMarkLabel2.AutoSize = true;
            this.uiMarkLabel2.Font = new System.Drawing.Font("宋体", 12F);
            this.uiMarkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel2.Location = new System.Drawing.Point(512, 96);
            this.uiMarkLabel2.MarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiMarkLabel2.Name = "uiMarkLabel2";
            this.uiMarkLabel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel2.Size = new System.Drawing.Size(76, 16);
            this.uiMarkLabel2.TabIndex = 145;
            this.uiMarkLabel2.Text = "Address:";
            this.uiMarkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.Font = new System.Drawing.Font("宋体", 12F);
            this.txtAddress.Location = new System.Drawing.Point(599, 91);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Maximum = 5000D;
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Minimum = 50D;
            this.txtAddress.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new System.Windows.Forms.Padding(5);
            this.txtAddress.ReadOnly = true;
            this.txtAddress.ShowText = false;
            this.txtAddress.Size = new System.Drawing.Size(149, 26);
            this.txtAddress.TabIndex = 144;
            this.txtAddress.Tag = "0";
            this.txtAddress.Text = "0x08000000";
            this.txtAddress.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAddress.Watermark = "";
            // 
            // uiMarkLabel4
            // 
            this.uiMarkLabel4.AutoSize = true;
            this.uiMarkLabel4.Font = new System.Drawing.Font("宋体", 12F);
            this.uiMarkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel4.Location = new System.Drawing.Point(755, 96);
            this.uiMarkLabel4.MarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiMarkLabel4.Name = "uiMarkLabel4";
            this.uiMarkLabel4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel4.Size = new System.Drawing.Size(52, 16);
            this.uiMarkLabel4.TabIndex = 147;
            this.uiMarkLabel4.Text = "Size:";
            this.uiMarkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSize
            // 
            this.txtSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSize.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSize.Location = new System.Drawing.Point(814, 91);
            this.txtSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSize.Maximum = 5000D;
            this.txtSize.MaxLength = 50;
            this.txtSize.Minimum = 50D;
            this.txtSize.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSize.Name = "txtSize";
            this.txtSize.Padding = new System.Windows.Forms.Padding(5);
            this.txtSize.ReadOnly = true;
            this.txtSize.ShowText = false;
            this.txtSize.Size = new System.Drawing.Size(149, 26);
            this.txtSize.TabIndex = 146;
            this.txtSize.Tag = "0";
            this.txtSize.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSize.Watermark = "";
            // 
            // pageSTM32Download
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1186, 633);
            this.Controls.Add(this.uiMarkLabel4);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.uiMarkLabel2);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.uiMarkLabel3);
            this.Controls.Add(this.txtSelectVersion);
            this.Controls.Add(this.BarChart);
            this.Controls.Add(this.PieChart);
            this.Controls.Add(this.lab_UserName);
            this.Controls.Add(this.uiAvatar1);
            this.Controls.Add(this.uiLine3);
            this.Controls.Add(this.uiRichTextBox1);
            this.Controls.Add(this.linePath);
            this.Controls.Add(this.uiMarkLabel1);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "pageSTM32Download";
            this.Padding = new System.Windows.Forms.Padding(2, 36, 2, 2);
            this.ShowDragStretch = true;
            this.ShowFullScreen = true;
            this.Text = "FirmWare  燒錄系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnOpenHex;
        private System.Windows.Forms.ToolStripMenuItem btnOpenLog;
        private Sunny.UI.UIMarkLabel uiMarkLabel1;
        private Sunny.UI.UITextBox txtVersion;
        private System.Windows.Forms.ToolStripMenuItem btnRun;
        private Sunny.UI.UILine linePath;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private Sunny.UI.UILine uiLine3;
        private Sunny.UI.UILabel lab_UserName;
        private Sunny.UI.UIAvatar uiAvatar1;
        private Sunny.UI.UIPieChart PieChart;
        private Sunny.UI.UIBarChart BarChart;
        private Sunny.UI.UIMarkLabel uiMarkLabel3;
        private Sunny.UI.UITextBox txtSelectVersion;
        private Sunny.UI.UIMarkLabel uiMarkLabel2;
        private Sunny.UI.UITextBox txtAddress;
        private Sunny.UI.UIMarkLabel uiMarkLabel4;
        private Sunny.UI.UITextBox txtSize;
        private System.Windows.Forms.ToolStripMenuItem mCUConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initToolStripMenuItem;
    }
}