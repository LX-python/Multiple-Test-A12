namespace Multiple_Test.Controller.STM32
{
    partial class pageSTM32DownloadAutoScan7230
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageSTM32DownloadAutoScan7230));
            this.uiLine1 = new Sunny.UI.UILine();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenHex = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenLog = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRun = new System.Windows.Forms.ToolStripMenuItem();
            this.扫码器配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mqttServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mCUConfigToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DebuggerConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Rs232ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.气缸上升ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.气缸可下降ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mCU33V开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mCU33V关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭控制器串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭扫码器串口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取条码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭读取条码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.uiMarkLabel5 = new Sunny.UI.UIMarkLabel();
            this.txtCheckSum = new Sunny.UI.UITextBox();
            this.uiMarkLabel6 = new Sunny.UI.UIMarkLabel();
            this.txtScanProtName = new Sunny.UI.UITextBox();
            this.txtMCUPortName = new Sunny.UI.UITextBox();
            this.uiMarkLabel7 = new Sunny.UI.UIMarkLabel();
            this.uiMarkLabel8 = new Sunny.UI.UIMarkLabel();
            this.txtSerialNumber = new Sunny.UI.UITextBox();
            this.ledMcu = new Sunny.UI.UILedBulb();
            this.ledSan = new Sunny.UI.UILedBulb();
            this.txtCommandLog = new Sunny.UI.UIRichTextBox();
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
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.btnRun,
            this.扫码器配置ToolStripMenuItem,
            this.DebuggerConfigToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 36);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 32);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(80, 28);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnOpenHex
            // 
            this.btnOpenHex.Image = global::Multiple_Test.Properties.Resources.添加;
            this.btnOpenHex.Name = "btnOpenHex";
            this.btnOpenHex.Size = new System.Drawing.Size(196, 34);
            this.btnOpenHex.Text = "Open Hex";
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Image = global::Multiple_Test.Properties.Resources.network_folder;
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(196, 34);
            this.btnOpenLog.Text = "Open Log";
            // 
            // btnRun
            // 
            this.btnRun.Image = global::Multiple_Test.Properties.Resources.start;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(84, 28);
            this.btnRun.Text = "Run";
            // 
            // 扫码器配置ToolStripMenuItem
            // 
            this.扫码器配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanConfigToolStripMenuItem,
            this.mqttServerToolStripMenuItem,
            this.mCUConfigToolStripMenuItem1});
            this.扫码器配置ToolStripMenuItem.Image = global::Multiple_Test.Properties.Resources.icon_Page_configuration;
            this.扫码器配置ToolStripMenuItem.Name = "扫码器配置ToolStripMenuItem";
            this.扫码器配置ToolStripMenuItem.Size = new System.Drawing.Size(122, 28);
            this.扫码器配置ToolStripMenuItem.Text = "系统配置";
            // 
            // scanConfigToolStripMenuItem
            // 
            this.scanConfigToolStripMenuItem.Image = global::Multiple_Test.Properties.Resources.扫描1;
            this.scanConfigToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.scanConfigToolStripMenuItem.Name = "scanConfigToolStripMenuItem";
            this.scanConfigToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.scanConfigToolStripMenuItem.Text = "ScanConfig";
            // 
            // mqttServerToolStripMenuItem
            // 
            this.mqttServerToolStripMenuItem.Image = global::Multiple_Test.Properties.Resources.publish;
            this.mqttServerToolStripMenuItem.Name = "mqttServerToolStripMenuItem";
            this.mqttServerToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.mqttServerToolStripMenuItem.Text = "MqttServer";
            // 
            // mCUConfigToolStripMenuItem1
            // 
            this.mCUConfigToolStripMenuItem1.Image = global::Multiple_Test.Properties.Resources.PLC信息管理;
            this.mCUConfigToolStripMenuItem1.Name = "mCUConfigToolStripMenuItem1";
            this.mCUConfigToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.mCUConfigToolStripMenuItem1.Text = "PCI7230";
            this.mCUConfigToolStripMenuItem1.Click += new System.EventHandler(this.MCUConfigToolStripMenuItem_Click);
            // 
            // DebuggerConfigToolStripMenuItem
            // 
            this.DebuggerConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Rs232ToolStripMenuItem,
            this.气缸上升ToolStripMenuItem,
            this.气缸可下降ToolStripMenuItem,
            this.mCU33V开ToolStripMenuItem,
            this.mCU33V关ToolStripMenuItem,
            this.关闭控制器串口ToolStripMenuItem,
            this.关闭扫码器串口ToolStripMenuItem,
            this.读取条码ToolStripMenuItem,
            this.关闭读取条码ToolStripMenuItem});
            this.DebuggerConfigToolStripMenuItem.Image = global::Multiple_Test.Properties.Resources.debugger_a;
            this.DebuggerConfigToolStripMenuItem.Name = "DebuggerConfigToolStripMenuItem";
            this.DebuggerConfigToolStripMenuItem.Size = new System.Drawing.Size(138, 28);
            this.DebuggerConfigToolStripMenuItem.Text = "Debugger";
            // 
            // Rs232ToolStripMenuItem
            // 
            this.Rs232ToolStripMenuItem.Image = global::Multiple_Test.Properties.Resources.RS2321;
            this.Rs232ToolStripMenuItem.Name = "Rs232ToolStripMenuItem";
            this.Rs232ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.Rs232ToolStripMenuItem.Text = "RS232";
            // 
            // 气缸上升ToolStripMenuItem
            // 
            this.气缸上升ToolStripMenuItem.Name = "气缸上升ToolStripMenuItem";
            this.气缸上升ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.气缸上升ToolStripMenuItem.Text = "气缸上升";
            this.气缸上升ToolStripMenuItem.Click += new System.EventHandler(this.气缸上升ToolStripMenuItem_Click);
            // 
            // 气缸可下降ToolStripMenuItem
            // 
            this.气缸可下降ToolStripMenuItem.Name = "气缸可下降ToolStripMenuItem";
            this.气缸可下降ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.气缸可下降ToolStripMenuItem.Text = "气缸可下降";
            this.气缸可下降ToolStripMenuItem.Click += new System.EventHandler(this.气缸可下降ToolStripMenuItem_Click);
            // 
            // mCU33V开ToolStripMenuItem
            // 
            this.mCU33V开ToolStripMenuItem.Name = "mCU33V开ToolStripMenuItem";
            this.mCU33V开ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.mCU33V开ToolStripMenuItem.Text = "MCU 3.3V 开";
            this.mCU33V开ToolStripMenuItem.Click += new System.EventHandler(this.mCU33V开ToolStripMenuItem_Click);
            // 
            // mCU33V关ToolStripMenuItem
            // 
            this.mCU33V关ToolStripMenuItem.Name = "mCU33V关ToolStripMenuItem";
            this.mCU33V关ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.mCU33V关ToolStripMenuItem.Text = "MCU 3.3V 关";
            this.mCU33V关ToolStripMenuItem.Click += new System.EventHandler(this.mCU33V关ToolStripMenuItem_Click);
            // 
            // 关闭控制器串口ToolStripMenuItem
            // 
            this.关闭控制器串口ToolStripMenuItem.Name = "关闭控制器串口ToolStripMenuItem";
            this.关闭控制器串口ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.关闭控制器串口ToolStripMenuItem.Text = "关闭控制器串口";
            this.关闭控制器串口ToolStripMenuItem.Click += new System.EventHandler(this.关闭控制器串口ToolStripMenuItem_Click);
            // 
            // 关闭扫码器串口ToolStripMenuItem
            // 
            this.关闭扫码器串口ToolStripMenuItem.Name = "关闭扫码器串口ToolStripMenuItem";
            this.关闭扫码器串口ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.关闭扫码器串口ToolStripMenuItem.Text = "关闭扫码器串口";
            this.关闭扫码器串口ToolStripMenuItem.Click += new System.EventHandler(this.关闭扫码器串口ToolStripMenuItem_Click);
            // 
            // 读取条码ToolStripMenuItem
            // 
            this.读取条码ToolStripMenuItem.Name = "读取条码ToolStripMenuItem";
            this.读取条码ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.读取条码ToolStripMenuItem.Text = "读取条码";
            // 
            // 关闭读取条码ToolStripMenuItem
            // 
            this.关闭读取条码ToolStripMenuItem.Name = "关闭读取条码ToolStripMenuItem";
            this.关闭读取条码ToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.关闭读取条码ToolStripMenuItem.Text = "关闭读取条码";
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
            this.uiMarkLabel1.Size = new System.Drawing.Size(123, 24);
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
            this.linePath.Location = new System.Drawing.Point(8, 185);
            this.linePath.MinimumSize = new System.Drawing.Size(16, 16);
            this.linePath.Name = "linePath";
            this.linePath.Size = new System.Drawing.Size(1166, 20);
            this.linePath.TabIndex = 71;
            this.linePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiRichTextBox1.BackColor = System.Drawing.Color.Black;
            this.uiRichTextBox1.FillColor = System.Drawing.Color.Black;
            this.uiRichTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRichTextBox1.ForeColor = System.Drawing.Color.Lime;
            this.uiRichTextBox1.Location = new System.Drawing.Point(8, 464);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.ReadOnly = true;
            this.uiRichTextBox1.ShowText = false;
            this.uiRichTextBox1.Size = new System.Drawing.Size(841, 240);
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
            this.uiLine3.Location = new System.Drawing.Point(7, 436);
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
            this.lab_UserName.Size = new System.Drawing.Size(106, 24);
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
            this.PieChart.Location = new System.Drawing.Point(864, 208);
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
            this.BarChart.Location = new System.Drawing.Point(8, 208);
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
            this.uiMarkLabel3.Size = new System.Drawing.Size(147, 24);
            this.uiMarkLabel3.TabIndex = 72;
            this.uiMarkLabel3.Text = "選擇的版本:";
            this.uiMarkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSelectVersion
            // 
            this.txtSelectVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSelectVersion.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSelectVersion.Location = new System.Drawing.Point(113, 91);
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
            this.uiMarkLabel2.Size = new System.Drawing.Size(111, 24);
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
            this.uiMarkLabel4.Size = new System.Drawing.Size(75, 24);
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
            // uiMarkLabel5
            // 
            this.uiMarkLabel5.AutoSize = true;
            this.uiMarkLabel5.Font = new System.Drawing.Font("宋体", 12F);
            this.uiMarkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel5.Location = new System.Drawing.Point(4, 142);
            this.uiMarkLabel5.MarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiMarkLabel5.Name = "uiMarkLabel5";
            this.uiMarkLabel5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel5.Size = new System.Drawing.Size(159, 24);
            this.uiMarkLabel5.TabIndex = 149;
            this.uiMarkLabel5.Text = "FW CheckSum:";
            this.uiMarkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCheckSum
            // 
            this.txtCheckSum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCheckSum.Font = new System.Drawing.Font("宋体", 12F);
            this.txtCheckSum.Location = new System.Drawing.Point(113, 137);
            this.txtCheckSum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCheckSum.Maximum = 5000D;
            this.txtCheckSum.MaxLength = 50;
            this.txtCheckSum.Minimum = 50D;
            this.txtCheckSum.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCheckSum.Name = "txtCheckSum";
            this.txtCheckSum.Padding = new System.Windows.Forms.Padding(5);
            this.txtCheckSum.ReadOnly = true;
            this.txtCheckSum.ShowText = false;
            this.txtCheckSum.Size = new System.Drawing.Size(149, 26);
            this.txtCheckSum.TabIndex = 148;
            this.txtCheckSum.Tag = "0";
            this.txtCheckSum.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCheckSum.Watermark = "";
            // 
            // uiMarkLabel6
            // 
            this.uiMarkLabel6.AutoSize = true;
            this.uiMarkLabel6.Font = new System.Drawing.Font("宋体", 12F);
            this.uiMarkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel6.Location = new System.Drawing.Point(265, 143);
            this.uiMarkLabel6.MarkColor = System.Drawing.Color.Blue;
            this.uiMarkLabel6.Name = "uiMarkLabel6";
            this.uiMarkLabel6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel6.Size = new System.Drawing.Size(99, 24);
            this.uiMarkLabel6.TabIndex = 150;
            this.uiMarkLabel6.Text = "读码器:";
            this.uiMarkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtScanProtName
            // 
            this.txtScanProtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtScanProtName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtScanProtName.Location = new System.Drawing.Point(353, 137);
            this.txtScanProtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtScanProtName.Maximum = 5000D;
            this.txtScanProtName.MaxLength = 50;
            this.txtScanProtName.Minimum = 50D;
            this.txtScanProtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtScanProtName.Name = "txtScanProtName";
            this.txtScanProtName.Padding = new System.Windows.Forms.Padding(5);
            this.txtScanProtName.ReadOnly = true;
            this.txtScanProtName.ShowText = false;
            this.txtScanProtName.Size = new System.Drawing.Size(149, 26);
            this.txtScanProtName.TabIndex = 151;
            this.txtScanProtName.Tag = "0";
            this.txtScanProtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtScanProtName.Watermark = "";
            // 
            // txtMCUPortName
            // 
            this.txtMCUPortName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMCUPortName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtMCUPortName.Location = new System.Drawing.Point(599, 137);
            this.txtMCUPortName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMCUPortName.Maximum = 5000D;
            this.txtMCUPortName.MaxLength = 50;
            this.txtMCUPortName.Minimum = 50D;
            this.txtMCUPortName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMCUPortName.Name = "txtMCUPortName";
            this.txtMCUPortName.Padding = new System.Windows.Forms.Padding(5);
            this.txtMCUPortName.ReadOnly = true;
            this.txtMCUPortName.ShowText = false;
            this.txtMCUPortName.Size = new System.Drawing.Size(149, 26);
            this.txtMCUPortName.TabIndex = 153;
            this.txtMCUPortName.Tag = "0";
            this.txtMCUPortName.Text = "PCI-7230";
            this.txtMCUPortName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMCUPortName.Watermark = "";
            // 
            // uiMarkLabel7
            // 
            this.uiMarkLabel7.AutoSize = true;
            this.uiMarkLabel7.Font = new System.Drawing.Font("宋体", 12F);
            this.uiMarkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel7.Location = new System.Drawing.Point(511, 143);
            this.uiMarkLabel7.MarkColor = System.Drawing.Color.Blue;
            this.uiMarkLabel7.Name = "uiMarkLabel7";
            this.uiMarkLabel7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel7.Size = new System.Drawing.Size(99, 24);
            this.uiMarkLabel7.TabIndex = 152;
            this.uiMarkLabel7.Text = "控制器:";
            this.uiMarkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiMarkLabel8
            // 
            this.uiMarkLabel8.AutoSize = true;
            this.uiMarkLabel8.Font = new System.Drawing.Font("宋体", 12F);
            this.uiMarkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel8.Location = new System.Drawing.Point(755, 142);
            this.uiMarkLabel8.MarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiMarkLabel8.Name = "uiMarkLabel8";
            this.uiMarkLabel8.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel8.Size = new System.Drawing.Size(51, 24);
            this.uiMarkLabel8.TabIndex = 155;
            this.uiMarkLabel8.Text = "SN:";
            this.uiMarkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSerialNumber.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSerialNumber.Location = new System.Drawing.Point(814, 137);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSerialNumber.Maximum = 5000D;
            this.txtSerialNumber.MaxLength = 50;
            this.txtSerialNumber.Minimum = 50D;
            this.txtSerialNumber.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Padding = new System.Windows.Forms.Padding(5);
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.ShowText = false;
            this.txtSerialNumber.Size = new System.Drawing.Size(329, 26);
            this.txtSerialNumber.TabIndex = 154;
            this.txtSerialNumber.Tag = "0";
            this.txtSerialNumber.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSerialNumber.Watermark = "";
            // 
            // ledMcu
            // 
            this.ledMcu.Color = System.Drawing.Color.Red;
            this.ledMcu.Location = new System.Drawing.Point(575, 140);
            this.ledMcu.Name = "ledMcu";
            this.ledMcu.Size = new System.Drawing.Size(19, 24);
            this.ledMcu.TabIndex = 157;
            this.ledMcu.Text = "uiLedBulb1";
            // 
            // ledSan
            // 
            this.ledSan.Color = System.Drawing.Color.Red;
            this.ledSan.Location = new System.Drawing.Point(330, 141);
            this.ledSan.Name = "ledSan";
            this.ledSan.Size = new System.Drawing.Size(19, 24);
            this.ledSan.TabIndex = 158;
            this.ledSan.Text = "uiLedBulb2";
            // 
            // txtCommandLog
            // 
            this.txtCommandLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommandLog.BackColor = System.Drawing.Color.Black;
            this.txtCommandLog.FillColor = System.Drawing.Color.Black;
            this.txtCommandLog.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCommandLog.ForeColor = System.Drawing.Color.White;
            this.txtCommandLog.Location = new System.Drawing.Point(857, 464);
            this.txtCommandLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommandLog.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtCommandLog.Name = "txtCommandLog";
            this.txtCommandLog.Padding = new System.Windows.Forms.Padding(2);
            this.txtCommandLog.ReadOnly = true;
            this.txtCommandLog.ShowText = false;
            this.txtCommandLog.Size = new System.Drawing.Size(317, 240);
            this.txtCommandLog.TabIndex = 159;
            this.txtCommandLog.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pageSTM32DownloadAutoScan7230
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1186, 711);
            this.Controls.Add(this.txtCommandLog);
            this.Controls.Add(this.ledSan);
            this.Controls.Add(this.ledMcu);
            this.Controls.Add(this.uiMarkLabel8);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.txtMCUPortName);
            this.Controls.Add(this.uiMarkLabel7);
            this.Controls.Add(this.txtScanProtName);
            this.Controls.Add(this.uiMarkLabel6);
            this.Controls.Add(this.uiMarkLabel5);
            this.Controls.Add(this.txtCheckSum);
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
            this.Name = "pageSTM32DownloadAutoScan7230";
            this.Padding = new System.Windows.Forms.Padding(2, 36, 2, 2);
            this.Resizable = true;
            this.ShowDragStretch = true;
            this.ShowFullScreen = true;
            this.Text = "FirmWare  燒錄系统(PCI-7230+自动扫码 + 自动CheckSum Version)";
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
        private System.Windows.Forms.ToolStripMenuItem DebuggerConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Rs232ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 扫码器配置ToolStripMenuItem;
        private Sunny.UI.UIMarkLabel uiMarkLabel5;
        private Sunny.UI.UITextBox txtCheckSum;
        private Sunny.UI.UIMarkLabel uiMarkLabel6;
        private Sunny.UI.UITextBox txtScanProtName;
        private Sunny.UI.UITextBox txtMCUPortName;
        private Sunny.UI.UIMarkLabel uiMarkLabel7;
        private System.Windows.Forms.ToolStripMenuItem scanConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mqttServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mCUConfigToolStripMenuItem1;
        private Sunny.UI.UIMarkLabel uiMarkLabel8;
        private Sunny.UI.UITextBox txtSerialNumber;
        private Sunny.UI.UILedBulb ledMcu;
        private Sunny.UI.UILedBulb ledSan;
        private Sunny.UI.UIRichTextBox txtCommandLog;
        private System.Windows.Forms.ToolStripMenuItem 气缸上升ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 气缸可下降ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mCU33V开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mCU33V关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭控制器串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭扫码器串口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取条码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭读取条码ToolStripMenuItem;
    }
}