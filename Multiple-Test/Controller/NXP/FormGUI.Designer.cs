using System.Windows.Forms;

namespace NXP_TEA_IC
{
    partial class FormTest
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
                if (notifyIcon != null)
                {
                    notifyIcon.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.label_mifVersionTitle = new System.Windows.Forms.Label();
            this.label_NowTime = new System.Windows.Forms.Label();
            this.label_Time = new System.Windows.Forms.Label();
            this.label_NowDate = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.timer_Now = new System.Windows.Forms.Timer(this.components);
            this.label_mifVersion = new System.Windows.Forms.Label();
            this.label_Target_4_VersionTitle = new System.Windows.Forms.Label();
            this.label_Target_4 = new System.Windows.Forms.Label();
            this.label_Log = new System.Windows.Forms.Label();
            this.buttonWriteDevice = new System.Windows.Forms.Button();
            this.btn_saveLogs = new System.Windows.Forms.Button();
            this.button_searchTargetIC = new System.Windows.Forms.Button();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.tabPage_1to4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.button_PowerOff = new System.Windows.Forms.Button();
            this.button_PowerOn = new System.Windows.Forms.Button();
            this.button_writeLockIC = new System.Windows.Forms.Button();
            this.button_readLockIC = new System.Windows.Forms.Button();
            this.button_eraseIC = new System.Windows.Forms.Button();
            this.groupBox_Target = new System.Windows.Forms.GroupBox();
            this.label1label_titleWrite = new System.Windows.Forms.Label();
            this.label_titleRead = new System.Windows.Forms.Label();
            this.label_Target_4_W = new System.Windows.Forms.Label();
            this.label_Target_1_W = new System.Windows.Forms.Label();
            this.label_titleProgram = new System.Windows.Forms.Label();
            this.label_Target_4_R = new System.Windows.Forms.Label();
            this.label_Target_3_W = new System.Windows.Forms.Label();
            this.label_Target_4_UnW = new System.Windows.Forms.Label();
            this.label_Target_2_W = new System.Windows.Forms.Label();
            this.label_Target_1_UnW = new System.Windows.Forms.Label();
            this.label_Target_1_R = new System.Windows.Forms.Label();
            this.label_Target_4_UnR = new System.Windows.Forms.Label();
            this.label_Target_1_UnR = new System.Windows.Forms.Label();
            this.label_Target_4_status = new System.Windows.Forms.Label();
            this.label_Target_3_UnW = new System.Windows.Forms.Label();
            this.label_Target_3_R = new System.Windows.Forms.Label();
            this.label_Target_3_status = new System.Windows.Forms.Label();
            this.label_Target_2_UnW = new System.Windows.Forms.Label();
            this.label_Target_2_status = new System.Windows.Forms.Label();
            this.label_Target_3_UnR = new System.Windows.Forms.Label();
            this.label_Target_1_status = new System.Windows.Forms.Label();
            this.label_Target_4_Red = new System.Windows.Forms.Label();
            this.label_Target_4_Green = new System.Windows.Forms.Label();
            this.label_Target_2_R = new System.Windows.Forms.Label();
            this.label_Target_4_BGreen = new System.Windows.Forms.Label();
            this.label_Target_3_Red = new System.Windows.Forms.Label();
            this.label_Target_2_UnR = new System.Windows.Forms.Label();
            this.label_Target_3_Green = new System.Windows.Forms.Label();
            this.label_Target_3_BGreen = new System.Windows.Forms.Label();
            this.label_Target_2_Red = new System.Windows.Forms.Label();
            this.label_Target_2_Green = new System.Windows.Forms.Label();
            this.label_Target_2_BGreen = new System.Windows.Forms.Label();
            this.label_Target_1_Red = new System.Windows.Forms.Label();
            this.label_Target_1_Green = new System.Windows.Forms.Label();
            this.label_Target_1_BGreen = new System.Windows.Forms.Label();
            this.label_Target_4_Version = new System.Windows.Forms.Label();
            this.label_Target_4_CRC = new System.Windows.Forms.Label();
            this.label_Target_4_CRCTitle = new System.Windows.Forms.Label();
            this.label_Target_3_VersionTitle = new System.Windows.Forms.Label();
            this.label_Target_3 = new System.Windows.Forms.Label();
            this.label_Target_3_Version = new System.Windows.Forms.Label();
            this.label_Target_3_CRC = new System.Windows.Forms.Label();
            this.label_Target_3_CRCTitle = new System.Windows.Forms.Label();
            this.label_Target_2_VersionTitle = new System.Windows.Forms.Label();
            this.label_Target_2 = new System.Windows.Forms.Label();
            this.label_Target_2_Version = new System.Windows.Forms.Label();
            this.label_Target_2_CRC = new System.Windows.Forms.Label();
            this.label_Target_2_CRCTitle = new System.Windows.Forms.Label();
            this.label_Target_1_VersionTitle = new System.Windows.Forms.Label();
            this.label_Target_1 = new System.Windows.Forms.Label();
            this.label_Target_1_Version = new System.Windows.Forms.Label();
            this.label_Target_1_CRC = new System.Windows.Forms.Label();
            this.label_Target_1_CRCTitle = new System.Windows.Forms.Label();
            this.btn_clearLogs = new System.Windows.Forms.Button();
            this.groupBox_minFile = new System.Windows.Forms.GroupBox();
            this.labOpenReadMinFile = new System.Windows.Forms.Label();
            this.label_mifCRCTitle = new System.Windows.Forms.Label();
            this.btn_OpenReadMinFile = new System.Windows.Forms.Button();
            this.label_mifCRC = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label_LogoTitle = new System.Windows.Forms.Label();
            this.USBCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.label_WPIgLogo = new System.Windows.Forms.Label();
            this.label_USBconnection = new System.Windows.Forms.Label();
            this.label_Connected = new System.Windows.Forms.Label();
            this.label_fwVerstion = new System.Windows.Forms.Label();
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
            this.lab_UserName = new Sunny.UI.UILabel();
            this.txtScanProtName = new Sunny.UI.UITextBox();
            this.uiMarkLabel6 = new Sunny.UI.UIMarkLabel();
            this.txtMCUPortName = new Sunny.UI.UITextBox();
            this.uiMarkLabel7 = new Sunny.UI.UIMarkLabel();
            this.ledSan = new Sunny.UI.UILedBulb();
            this.ledMcu = new Sunny.UI.UILedBulb();
            this.tabPage_1to4.SuspendLayout();
            this.groupBox_Target.SuspendLayout();
            this.groupBox_minFile.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_mifVersionTitle
            // 
            this.label_mifVersionTitle.AutoSize = true;
            this.label_mifVersionTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_mifVersionTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_mifVersionTitle.Location = new System.Drawing.Point(393, 75);
            this.label_mifVersionTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_mifVersionTitle.Name = "label_mifVersionTitle";
            this.label_mifVersionTitle.Size = new System.Drawing.Size(84, 25);
            this.label_mifVersionTitle.TabIndex = 19;
            this.label_mifVersionTitle.Text = "version:";
            // 
            // label_NowTime
            // 
            this.label_NowTime.BackColor = System.Drawing.SystemColors.Window;
            this.label_NowTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_NowTime.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_NowTime.Location = new System.Drawing.Point(1532, 36);
            this.label_NowTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_NowTime.Name = "label_NowTime";
            this.label_NowTime.Size = new System.Drawing.Size(162, 27);
            this.label_NowTime.TabIndex = 9;
            this.label_NowTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Time.Location = new System.Drawing.Point(1449, 38);
            this.label_Time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(77, 25);
            this.label_Time.TabIndex = 8;
            this.label_Time.Text = "Times :";
            // 
            // label_NowDate
            // 
            this.label_NowDate.BackColor = System.Drawing.SystemColors.Window;
            this.label_NowDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_NowDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_NowDate.Location = new System.Drawing.Point(1278, 36);
            this.label_NowDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_NowDate.Name = "label_NowDate";
            this.label_NowDate.Size = new System.Drawing.Size(162, 27);
            this.label_NowDate.TabIndex = 7;
            this.label_NowDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Date.Location = new System.Drawing.Point(1204, 38);
            this.label_Date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(66, 25);
            this.label_Date.TabIndex = 6;
            this.label_Date.Text = "Date :";
            // 
            // timer_Now
            // 
            this.timer_Now.Enabled = true;
            this.timer_Now.Interval = 1000;
            // 
            // label_mifVersion
            // 
            this.label_mifVersion.BackColor = System.Drawing.SystemColors.Window;
            this.label_mifVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_mifVersion.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_mifVersion.ForeColor = System.Drawing.Color.Red;
            this.label_mifVersion.Location = new System.Drawing.Point(484, 74);
            this.label_mifVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_mifVersion.Name = "label_mifVersion";
            this.label_mifVersion.Size = new System.Drawing.Size(135, 27);
            this.label_mifVersion.TabIndex = 20;
            this.label_mifVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Target_4_VersionTitle
            // 
            this.label_Target_4_VersionTitle.AutoSize = true;
            this.label_Target_4_VersionTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_4_VersionTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_4_VersionTitle.Location = new System.Drawing.Point(87, 345);
            this.label_Target_4_VersionTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_VersionTitle.Name = "label_Target_4_VersionTitle";
            this.label_Target_4_VersionTitle.Size = new System.Drawing.Size(108, 25);
            this.label_Target_4_VersionTitle.TabIndex = 41;
            this.label_Target_4_VersionTitle.Text = "IC version:";
            // 
            // label_Target_4
            // 
            this.label_Target_4.AutoSize = true;
            this.label_Target_4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_Target_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_4.Location = new System.Drawing.Point(46, 314);
            this.label_Target_4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4.Name = "label_Target_4";
            this.label_Target_4.Size = new System.Drawing.Size(92, 25);
            this.label_Target_4.TabIndex = 38;
            this.label_Target_4.Text = "Target 4";
            // 
            // label_Log
            // 
            this.label_Log.AutoSize = true;
            this.label_Log.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.label_Log.Location = new System.Drawing.Point(915, 39);
            this.label_Log.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Log.Name = "label_Log";
            this.label_Log.Size = new System.Drawing.Size(53, 23);
            this.label_Log.TabIndex = 27;
            this.label_Log.Text = "Log :";
            // 
            // buttonWriteDevice
            // 
            this.buttonWriteDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWriteDevice.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonWriteDevice.Location = new System.Drawing.Point(918, 562);
            this.buttonWriteDevice.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWriteDevice.Name = "buttonWriteDevice";
            this.buttonWriteDevice.Size = new System.Drawing.Size(246, 38);
            this.buttonWriteDevice.TabIndex = 24;
            this.buttonWriteDevice.Text = "Program / Write device";
            this.buttonWriteDevice.UseVisualStyleBackColor = true;
            this.buttonWriteDevice.Click += new System.EventHandler(this.buttonWriteDevice_Click);
            // 
            // btn_saveLogs
            // 
            this.btn_saveLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_saveLogs.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_saveLogs.Location = new System.Drawing.Point(1444, 592);
            this.btn_saveLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_saveLogs.Name = "btn_saveLogs";
            this.btn_saveLogs.Size = new System.Drawing.Size(120, 38);
            this.btn_saveLogs.TabIndex = 18;
            this.btn_saveLogs.Text = "Save logs";
            this.btn_saveLogs.UseVisualStyleBackColor = true;
            this.btn_saveLogs.Click += new System.EventHandler(this.btn_saveLogs_Click);
            // 
            // button_searchTargetIC
            // 
            this.button_searchTargetIC.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_searchTargetIC.Location = new System.Drawing.Point(918, 598);
            this.button_searchTargetIC.Margin = new System.Windows.Forms.Padding(4);
            this.button_searchTargetIC.Name = "button_searchTargetIC";
            this.button_searchTargetIC.Size = new System.Drawing.Size(176, 38);
            this.button_searchTargetIC.TabIndex = 24;
            this.button_searchTargetIC.Text = "Search Target IC";
            this.button_searchTargetIC.UseVisualStyleBackColor = true;
            this.button_searchTargetIC.Click += new System.EventHandler(this.button_searchTargetIC_Click);
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.HorizontalScrollbar = true;
            this.listBoxLogs.ItemHeight = 23;
            this.listBoxLogs.Location = new System.Drawing.Point(918, 69);
            this.listBoxLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.ScrollAlwaysVisible = true;
            this.listBoxLogs.Size = new System.Drawing.Size(774, 464);
            this.listBoxLogs.TabIndex = 22;
            // 
            // tabPage_1to4
            // 
            this.tabPage_1to4.Controls.Add(this.label2);
            this.tabPage_1to4.Controls.Add(this.txtSerialNumber);
            this.tabPage_1to4.Controls.Add(this.btnstart);
            this.tabPage_1to4.Controls.Add(this.button_PowerOff);
            this.tabPage_1to4.Controls.Add(this.button_PowerOn);
            this.tabPage_1to4.Controls.Add(this.button_writeLockIC);
            this.tabPage_1to4.Controls.Add(this.button_readLockIC);
            this.tabPage_1to4.Controls.Add(this.button_eraseIC);
            this.tabPage_1to4.Controls.Add(this.label_Log);
            this.tabPage_1to4.Controls.Add(this.buttonWriteDevice);
            this.tabPage_1to4.Controls.Add(this.btn_saveLogs);
            this.tabPage_1to4.Controls.Add(this.button_searchTargetIC);
            this.tabPage_1to4.Controls.Add(this.listBoxLogs);
            this.tabPage_1to4.Controls.Add(this.groupBox_Target);
            this.tabPage_1to4.Controls.Add(this.btn_clearLogs);
            this.tabPage_1to4.Controls.Add(this.groupBox_minFile);
            this.tabPage_1to4.Controls.Add(this.label_NowTime);
            this.tabPage_1to4.Controls.Add(this.label_Time);
            this.tabPage_1to4.Controls.Add(this.label_NowDate);
            this.tabPage_1to4.Controls.Add(this.label_Date);
            this.tabPage_1to4.Location = new System.Drawing.Point(4, 34);
            this.tabPage_1to4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_1to4.Name = "tabPage_1to4";
            this.tabPage_1to4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_1to4.Size = new System.Drawing.Size(1717, 642);
            this.tabPage_1to4.TabIndex = 1;
            this.tabPage_1to4.Text = "One by Four";
            this.tabPage_1to4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 601);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 25);
            this.label2.TabIndex = 45;
            this.label2.Text = "SN";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(500, 594);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(162, 30);
            this.txtSerialNumber.TabIndex = 44;
            // 
            // btnstart
            // 
            this.btnstart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnstart.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnstart.Location = new System.Drawing.Point(663, 591);
            this.btnstart.Margin = new System.Windows.Forms.Padding(4);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(246, 38);
            this.btnstart.TabIndex = 41;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.butnStart_Click);
            // 
            // button_PowerOff
            // 
            this.button_PowerOff.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_PowerOff.ForeColor = System.Drawing.Color.Red;
            this.button_PowerOff.Location = new System.Drawing.Point(1316, 592);
            this.button_PowerOff.Margin = new System.Windows.Forms.Padding(4);
            this.button_PowerOff.Name = "button_PowerOff";
            this.button_PowerOff.Size = new System.Drawing.Size(120, 38);
            this.button_PowerOff.TabIndex = 39;
            this.button_PowerOff.Text = "Power Off";
            this.button_PowerOff.UseVisualStyleBackColor = true;
            this.button_PowerOff.Click += new System.EventHandler(this.button_PowerOff_Click);
            // 
            // button_PowerOn
            // 
            this.button_PowerOn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_PowerOn.ForeColor = System.Drawing.Color.Red;
            this.button_PowerOn.Location = new System.Drawing.Point(1186, 592);
            this.button_PowerOn.Margin = new System.Windows.Forms.Padding(4);
            this.button_PowerOn.Name = "button_PowerOn";
            this.button_PowerOn.Size = new System.Drawing.Size(120, 38);
            this.button_PowerOn.TabIndex = 40;
            this.button_PowerOn.Text = "Power On";
            this.button_PowerOn.UseVisualStyleBackColor = true;
            this.button_PowerOn.Click += new System.EventHandler(this.button_PowerOn_Click);
            // 
            // button_writeLockIC
            // 
            this.button_writeLockIC.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_writeLockIC.ForeColor = System.Drawing.Color.Blue;
            this.button_writeLockIC.Location = new System.Drawing.Point(261, 594);
            this.button_writeLockIC.Margin = new System.Windows.Forms.Padding(4);
            this.button_writeLockIC.Name = "button_writeLockIC";
            this.button_writeLockIC.Size = new System.Drawing.Size(164, 38);
            this.button_writeLockIC.TabIndex = 38;
            this.button_writeLockIC.Text = "Write-Lock IC";
            this.button_writeLockIC.UseVisualStyleBackColor = true;
            this.button_writeLockIC.Click += new System.EventHandler(this.button_writeLockIC_Click);
            // 
            // button_readLockIC
            // 
            this.button_readLockIC.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_readLockIC.ForeColor = System.Drawing.Color.Blue;
            this.button_readLockIC.Location = new System.Drawing.Point(108, 594);
            this.button_readLockIC.Margin = new System.Windows.Forms.Padding(4);
            this.button_readLockIC.Name = "button_readLockIC";
            this.button_readLockIC.Size = new System.Drawing.Size(150, 38);
            this.button_readLockIC.TabIndex = 37;
            this.button_readLockIC.Text = "Read-Lock IC";
            this.button_readLockIC.UseVisualStyleBackColor = true;
            this.button_readLockIC.Click += new System.EventHandler(this.button_readLockIC_Click);
            // 
            // button_eraseIC
            // 
            this.button_eraseIC.BackColor = System.Drawing.Color.Red;
            this.button_eraseIC.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_eraseIC.ForeColor = System.Drawing.SystemColors.Window;
            this.button_eraseIC.Location = new System.Drawing.Point(4, 594);
            this.button_eraseIC.Margin = new System.Windows.Forms.Padding(4);
            this.button_eraseIC.Name = "button_eraseIC";
            this.button_eraseIC.Size = new System.Drawing.Size(106, 38);
            this.button_eraseIC.TabIndex = 36;
            this.button_eraseIC.Text = "Erase IC";
            this.button_eraseIC.UseVisualStyleBackColor = false;
            this.button_eraseIC.Click += new System.EventHandler(this.button_eraseIC_Click);
            // 
            // groupBox_Target
            // 
            this.groupBox_Target.Controls.Add(this.label1label_titleWrite);
            this.groupBox_Target.Controls.Add(this.label_titleRead);
            this.groupBox_Target.Controls.Add(this.label_Target_4_W);
            this.groupBox_Target.Controls.Add(this.label_Target_1_W);
            this.groupBox_Target.Controls.Add(this.label_titleProgram);
            this.groupBox_Target.Controls.Add(this.label_Target_4_R);
            this.groupBox_Target.Controls.Add(this.label_Target_3_W);
            this.groupBox_Target.Controls.Add(this.label_Target_4_UnW);
            this.groupBox_Target.Controls.Add(this.label_Target_2_W);
            this.groupBox_Target.Controls.Add(this.label_Target_1_UnW);
            this.groupBox_Target.Controls.Add(this.label_Target_1_R);
            this.groupBox_Target.Controls.Add(this.label_Target_4_UnR);
            this.groupBox_Target.Controls.Add(this.label_Target_1_UnR);
            this.groupBox_Target.Controls.Add(this.label_Target_4_status);
            this.groupBox_Target.Controls.Add(this.label_Target_3_UnW);
            this.groupBox_Target.Controls.Add(this.label_Target_3_R);
            this.groupBox_Target.Controls.Add(this.label_Target_3_status);
            this.groupBox_Target.Controls.Add(this.label_Target_2_UnW);
            this.groupBox_Target.Controls.Add(this.label_Target_2_status);
            this.groupBox_Target.Controls.Add(this.label_Target_3_UnR);
            this.groupBox_Target.Controls.Add(this.label_Target_1_status);
            this.groupBox_Target.Controls.Add(this.label_Target_4_Red);
            this.groupBox_Target.Controls.Add(this.label_Target_4_Green);
            this.groupBox_Target.Controls.Add(this.label_Target_2_R);
            this.groupBox_Target.Controls.Add(this.label_Target_4_BGreen);
            this.groupBox_Target.Controls.Add(this.label_Target_3_Red);
            this.groupBox_Target.Controls.Add(this.label_Target_2_UnR);
            this.groupBox_Target.Controls.Add(this.label_Target_3_Green);
            this.groupBox_Target.Controls.Add(this.label_Target_3_BGreen);
            this.groupBox_Target.Controls.Add(this.label_Target_2_Red);
            this.groupBox_Target.Controls.Add(this.label_Target_2_Green);
            this.groupBox_Target.Controls.Add(this.label_Target_2_BGreen);
            this.groupBox_Target.Controls.Add(this.label_Target_1_Red);
            this.groupBox_Target.Controls.Add(this.label_Target_1_Green);
            this.groupBox_Target.Controls.Add(this.label_Target_1_BGreen);
            this.groupBox_Target.Controls.Add(this.label_Target_4_VersionTitle);
            this.groupBox_Target.Controls.Add(this.label_Target_4);
            this.groupBox_Target.Controls.Add(this.label_Target_4_Version);
            this.groupBox_Target.Controls.Add(this.label_Target_4_CRC);
            this.groupBox_Target.Controls.Add(this.label_Target_4_CRCTitle);
            this.groupBox_Target.Controls.Add(this.label_Target_3_VersionTitle);
            this.groupBox_Target.Controls.Add(this.label_Target_3);
            this.groupBox_Target.Controls.Add(this.label_Target_3_Version);
            this.groupBox_Target.Controls.Add(this.label_Target_3_CRC);
            this.groupBox_Target.Controls.Add(this.label_Target_3_CRCTitle);
            this.groupBox_Target.Controls.Add(this.label_Target_2_VersionTitle);
            this.groupBox_Target.Controls.Add(this.label_Target_2);
            this.groupBox_Target.Controls.Add(this.label_Target_2_Version);
            this.groupBox_Target.Controls.Add(this.label_Target_2_CRC);
            this.groupBox_Target.Controls.Add(this.label_Target_2_CRCTitle);
            this.groupBox_Target.Controls.Add(this.label_Target_1_VersionTitle);
            this.groupBox_Target.Controls.Add(this.label_Target_1);
            this.groupBox_Target.Controls.Add(this.label_Target_1_Version);
            this.groupBox_Target.Controls.Add(this.label_Target_1_CRC);
            this.groupBox_Target.Controls.Add(this.label_Target_1_CRCTitle);
            this.groupBox_Target.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox_Target.ForeColor = System.Drawing.Color.Blue;
            this.groupBox_Target.Location = new System.Drawing.Point(16, 160);
            this.groupBox_Target.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Target.Name = "groupBox_Target";
            this.groupBox_Target.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Target.Size = new System.Drawing.Size(892, 418);
            this.groupBox_Target.TabIndex = 26;
            this.groupBox_Target.TabStop = false;
            this.groupBox_Target.Text = "Target IC Status";
            // 
            // label1label_titleWrite
            // 
            this.label1label_titleWrite.AutoSize = true;
            this.label1label_titleWrite.Font = new System.Drawing.Font("微軟正黑體", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1label_titleWrite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1label_titleWrite.Location = new System.Drawing.Point(822, 28);
            this.label1label_titleWrite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1label_titleWrite.Name = "label1label_titleWrite";
            this.label1label_titleWrite.Size = new System.Drawing.Size(58, 23);
            this.label1label_titleWrite.TabIndex = 89;
            this.label1label_titleWrite.Text = "Write";
            // 
            // label_titleRead
            // 
            this.label_titleRead.AutoSize = true;
            this.label_titleRead.Font = new System.Drawing.Font("微軟正黑體", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label_titleRead.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_titleRead.Location = new System.Drawing.Point(748, 28);
            this.label_titleRead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_titleRead.Name = "label_titleRead";
            this.label_titleRead.Size = new System.Drawing.Size(54, 23);
            this.label_titleRead.TabIndex = 88;
            this.label_titleRead.Text = "Read";
            // 
            // label_Target_4_W
            // 
            this.label_Target_4_W.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_4_W.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_4_W.Image = global::Multiple_Test.Properties.Resources.Yellow;
            this.label_Target_4_W.Location = new System.Drawing.Point(818, 327);
            this.label_Target_4_W.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_W.Name = "label_Target_4_W";
            this.label_Target_4_W.Size = new System.Drawing.Size(69, 64);
            this.label_Target_4_W.TabIndex = 84;
            this.label_Target_4_W.Visible = false;
            // 
            // label_Target_1_W
            // 
            this.label_Target_1_W.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_1_W.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_1_W.Image = global::Multiple_Test.Properties.Resources.Yellow;
            this.label_Target_1_W.Location = new System.Drawing.Point(818, 54);
            this.label_Target_1_W.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_W.Name = "label_Target_1_W";
            this.label_Target_1_W.Size = new System.Drawing.Size(69, 64);
            this.label_Target_1_W.TabIndex = 72;
            this.label_Target_1_W.Visible = false;
            // 
            // label_titleProgram
            // 
            this.label_titleProgram.AutoSize = true;
            this.label_titleProgram.Font = new System.Drawing.Font("微軟正黑體", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label_titleProgram.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_titleProgram.Location = new System.Drawing.Point(652, 28);
            this.label_titleProgram.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_titleProgram.Name = "label_titleProgram";
            this.label_titleProgram.Size = new System.Drawing.Size(86, 23);
            this.label_titleProgram.TabIndex = 85;
            this.label_titleProgram.Text = "Program";
            // 
            // label_Target_4_R
            // 
            this.label_Target_4_R.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_4_R.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_4_R.Image = global::Multiple_Test.Properties.Resources.Blue;
            this.label_Target_4_R.Location = new System.Drawing.Point(742, 327);
            this.label_Target_4_R.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_R.Name = "label_Target_4_R";
            this.label_Target_4_R.Size = new System.Drawing.Size(69, 64);
            this.label_Target_4_R.TabIndex = 83;
            this.label_Target_4_R.Visible = false;
            // 
            // label_Target_3_W
            // 
            this.label_Target_3_W.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_3_W.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_3_W.Image = global::Multiple_Test.Properties.Resources.Yellow;
            this.label_Target_3_W.Location = new System.Drawing.Point(818, 238);
            this.label_Target_3_W.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_W.Name = "label_Target_3_W";
            this.label_Target_3_W.Size = new System.Drawing.Size(69, 64);
            this.label_Target_3_W.TabIndex = 80;
            this.label_Target_3_W.Visible = false;
            // 
            // label_Target_4_UnW
            // 
            this.label_Target_4_UnW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_4_UnW.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_4_UnW.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_4_UnW.Location = new System.Drawing.Point(818, 327);
            this.label_Target_4_UnW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_UnW.Name = "label_Target_4_UnW";
            this.label_Target_4_UnW.Size = new System.Drawing.Size(69, 64);
            this.label_Target_4_UnW.TabIndex = 82;
            // 
            // label_Target_2_W
            // 
            this.label_Target_2_W.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_2_W.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_2_W.Image = global::Multiple_Test.Properties.Resources.Yellow;
            this.label_Target_2_W.Location = new System.Drawing.Point(818, 146);
            this.label_Target_2_W.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_W.Name = "label_Target_2_W";
            this.label_Target_2_W.Size = new System.Drawing.Size(69, 64);
            this.label_Target_2_W.TabIndex = 76;
            this.label_Target_2_W.Visible = false;
            // 
            // label_Target_1_UnW
            // 
            this.label_Target_1_UnW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_1_UnW.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_1_UnW.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_1_UnW.Location = new System.Drawing.Point(818, 56);
            this.label_Target_1_UnW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_UnW.Name = "label_Target_1_UnW";
            this.label_Target_1_UnW.Size = new System.Drawing.Size(69, 64);
            this.label_Target_1_UnW.TabIndex = 70;
            // 
            // label_Target_1_R
            // 
            this.label_Target_1_R.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_1_R.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_1_R.Image = global::Multiple_Test.Properties.Resources.Blue;
            this.label_Target_1_R.Location = new System.Drawing.Point(742, 54);
            this.label_Target_1_R.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_R.Name = "label_Target_1_R";
            this.label_Target_1_R.Size = new System.Drawing.Size(69, 64);
            this.label_Target_1_R.TabIndex = 71;
            this.label_Target_1_R.Visible = false;
            // 
            // label_Target_4_UnR
            // 
            this.label_Target_4_UnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_4_UnR.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_4_UnR.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_4_UnR.Location = new System.Drawing.Point(742, 327);
            this.label_Target_4_UnR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_UnR.Name = "label_Target_4_UnR";
            this.label_Target_4_UnR.Size = new System.Drawing.Size(69, 64);
            this.label_Target_4_UnR.TabIndex = 81;
            // 
            // label_Target_1_UnR
            // 
            this.label_Target_1_UnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_1_UnR.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_1_UnR.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_1_UnR.Location = new System.Drawing.Point(742, 54);
            this.label_Target_1_UnR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_UnR.Name = "label_Target_1_UnR";
            this.label_Target_1_UnR.Size = new System.Drawing.Size(69, 64);
            this.label_Target_1_UnR.TabIndex = 69;
            // 
            // label_Target_4_status
            // 
            this.label_Target_4_status.AutoSize = true;
            this.label_Target_4_status.ForeColor = System.Drawing.Color.Gray;
            this.label_Target_4_status.Location = new System.Drawing.Point(9, 315);
            this.label_Target_4_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_status.Name = "label_Target_4_status";
            this.label_Target_4_status.Size = new System.Drawing.Size(30, 23);
            this.label_Target_4_status.TabIndex = 68;
            this.label_Target_4_status.Text = "✅";
            // 
            // label_Target_3_UnW
            // 
            this.label_Target_3_UnW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_3_UnW.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_3_UnW.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_3_UnW.Location = new System.Drawing.Point(818, 237);
            this.label_Target_3_UnW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_UnW.Name = "label_Target_3_UnW";
            this.label_Target_3_UnW.Size = new System.Drawing.Size(69, 64);
            this.label_Target_3_UnW.TabIndex = 78;
            // 
            // label_Target_3_R
            // 
            this.label_Target_3_R.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_3_R.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_3_R.Image = global::Multiple_Test.Properties.Resources.Blue;
            this.label_Target_3_R.Location = new System.Drawing.Point(742, 238);
            this.label_Target_3_R.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_R.Name = "label_Target_3_R";
            this.label_Target_3_R.Size = new System.Drawing.Size(69, 64);
            this.label_Target_3_R.TabIndex = 79;
            this.label_Target_3_R.Visible = false;
            // 
            // label_Target_3_status
            // 
            this.label_Target_3_status.AutoSize = true;
            this.label_Target_3_status.ForeColor = System.Drawing.Color.Gray;
            this.label_Target_3_status.Location = new System.Drawing.Point(9, 224);
            this.label_Target_3_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_status.Name = "label_Target_3_status";
            this.label_Target_3_status.Size = new System.Drawing.Size(30, 23);
            this.label_Target_3_status.TabIndex = 67;
            this.label_Target_3_status.Text = "✅";
            // 
            // label_Target_2_UnW
            // 
            this.label_Target_2_UnW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_2_UnW.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_2_UnW.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_2_UnW.Location = new System.Drawing.Point(818, 146);
            this.label_Target_2_UnW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_UnW.Name = "label_Target_2_UnW";
            this.label_Target_2_UnW.Size = new System.Drawing.Size(69, 64);
            this.label_Target_2_UnW.TabIndex = 74;
            // 
            // label_Target_2_status
            // 
            this.label_Target_2_status.AutoSize = true;
            this.label_Target_2_status.ForeColor = System.Drawing.Color.Gray;
            this.label_Target_2_status.Location = new System.Drawing.Point(9, 132);
            this.label_Target_2_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_status.Name = "label_Target_2_status";
            this.label_Target_2_status.Size = new System.Drawing.Size(30, 23);
            this.label_Target_2_status.TabIndex = 66;
            this.label_Target_2_status.Text = "✅";
            // 
            // label_Target_3_UnR
            // 
            this.label_Target_3_UnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_3_UnR.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_3_UnR.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_3_UnR.Location = new System.Drawing.Point(742, 238);
            this.label_Target_3_UnR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_UnR.Name = "label_Target_3_UnR";
            this.label_Target_3_UnR.Size = new System.Drawing.Size(69, 64);
            this.label_Target_3_UnR.TabIndex = 77;
            // 
            // label_Target_1_status
            // 
            this.label_Target_1_status.AutoSize = true;
            this.label_Target_1_status.ForeColor = System.Drawing.Color.Gray;
            this.label_Target_1_status.Location = new System.Drawing.Point(9, 45);
            this.label_Target_1_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_status.Name = "label_Target_1_status";
            this.label_Target_1_status.Size = new System.Drawing.Size(30, 23);
            this.label_Target_1_status.TabIndex = 65;
            this.label_Target_1_status.Text = "✅";
            // 
            // label_Target_4_Red
            // 
            this.label_Target_4_Red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_4_Red.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_4_Red.Image = global::Multiple_Test.Properties.Resources.Red;
            this.label_Target_4_Red.Location = new System.Drawing.Point(663, 327);
            this.label_Target_4_Red.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_Red.Name = "label_Target_4_Red";
            this.label_Target_4_Red.Size = new System.Drawing.Size(69, 64);
            this.label_Target_4_Red.TabIndex = 64;
            this.label_Target_4_Red.Visible = false;
            // 
            // label_Target_4_Green
            // 
            this.label_Target_4_Green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_4_Green.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_4_Green.Image = global::Multiple_Test.Properties.Resources.Green;
            this.label_Target_4_Green.Location = new System.Drawing.Point(663, 327);
            this.label_Target_4_Green.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_Green.Name = "label_Target_4_Green";
            this.label_Target_4_Green.Size = new System.Drawing.Size(69, 64);
            this.label_Target_4_Green.TabIndex = 63;
            this.label_Target_4_Green.Visible = false;
            // 
            // label_Target_2_R
            // 
            this.label_Target_2_R.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_2_R.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_2_R.Image = global::Multiple_Test.Properties.Resources.Blue;
            this.label_Target_2_R.Location = new System.Drawing.Point(742, 146);
            this.label_Target_2_R.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_R.Name = "label_Target_2_R";
            this.label_Target_2_R.Size = new System.Drawing.Size(69, 64);
            this.label_Target_2_R.TabIndex = 75;
            this.label_Target_2_R.Visible = false;
            // 
            // label_Target_4_BGreen
            // 
            this.label_Target_4_BGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_4_BGreen.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_4_BGreen.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_4_BGreen.Location = new System.Drawing.Point(663, 327);
            this.label_Target_4_BGreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_BGreen.Name = "label_Target_4_BGreen";
            this.label_Target_4_BGreen.Size = new System.Drawing.Size(69, 64);
            this.label_Target_4_BGreen.TabIndex = 61;
            // 
            // label_Target_3_Red
            // 
            this.label_Target_3_Red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_3_Red.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_3_Red.Image = global::Multiple_Test.Properties.Resources.Red;
            this.label_Target_3_Red.Location = new System.Drawing.Point(663, 238);
            this.label_Target_3_Red.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_Red.Name = "label_Target_3_Red";
            this.label_Target_3_Red.Size = new System.Drawing.Size(69, 64);
            this.label_Target_3_Red.TabIndex = 60;
            this.label_Target_3_Red.Visible = false;
            // 
            // label_Target_2_UnR
            // 
            this.label_Target_2_UnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_2_UnR.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_2_UnR.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_2_UnR.Location = new System.Drawing.Point(742, 146);
            this.label_Target_2_UnR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_UnR.Name = "label_Target_2_UnR";
            this.label_Target_2_UnR.Size = new System.Drawing.Size(69, 64);
            this.label_Target_2_UnR.TabIndex = 73;
            // 
            // label_Target_3_Green
            // 
            this.label_Target_3_Green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_3_Green.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_3_Green.Image = global::Multiple_Test.Properties.Resources.Green;
            this.label_Target_3_Green.Location = new System.Drawing.Point(663, 238);
            this.label_Target_3_Green.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_Green.Name = "label_Target_3_Green";
            this.label_Target_3_Green.Size = new System.Drawing.Size(69, 64);
            this.label_Target_3_Green.TabIndex = 59;
            this.label_Target_3_Green.Visible = false;
            // 
            // label_Target_3_BGreen
            // 
            this.label_Target_3_BGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_3_BGreen.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_3_BGreen.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_3_BGreen.Location = new System.Drawing.Point(663, 238);
            this.label_Target_3_BGreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_BGreen.Name = "label_Target_3_BGreen";
            this.label_Target_3_BGreen.Size = new System.Drawing.Size(69, 64);
            this.label_Target_3_BGreen.TabIndex = 57;
            // 
            // label_Target_2_Red
            // 
            this.label_Target_2_Red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_2_Red.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_2_Red.Image = global::Multiple_Test.Properties.Resources.Red;
            this.label_Target_2_Red.Location = new System.Drawing.Point(663, 146);
            this.label_Target_2_Red.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_Red.Name = "label_Target_2_Red";
            this.label_Target_2_Red.Size = new System.Drawing.Size(69, 64);
            this.label_Target_2_Red.TabIndex = 56;
            this.label_Target_2_Red.Visible = false;
            // 
            // label_Target_2_Green
            // 
            this.label_Target_2_Green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_2_Green.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_2_Green.Image = global::Multiple_Test.Properties.Resources.Green;
            this.label_Target_2_Green.Location = new System.Drawing.Point(663, 146);
            this.label_Target_2_Green.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_Green.Name = "label_Target_2_Green";
            this.label_Target_2_Green.Size = new System.Drawing.Size(69, 64);
            this.label_Target_2_Green.TabIndex = 55;
            this.label_Target_2_Green.Visible = false;
            // 
            // label_Target_2_BGreen
            // 
            this.label_Target_2_BGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_2_BGreen.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_2_BGreen.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_2_BGreen.Location = new System.Drawing.Point(663, 146);
            this.label_Target_2_BGreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_BGreen.Name = "label_Target_2_BGreen";
            this.label_Target_2_BGreen.Size = new System.Drawing.Size(69, 64);
            this.label_Target_2_BGreen.TabIndex = 53;
            // 
            // label_Target_1_Red
            // 
            this.label_Target_1_Red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_1_Red.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_1_Red.Image = global::Multiple_Test.Properties.Resources.Red;
            this.label_Target_1_Red.Location = new System.Drawing.Point(663, 54);
            this.label_Target_1_Red.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_Red.Name = "label_Target_1_Red";
            this.label_Target_1_Red.Size = new System.Drawing.Size(69, 64);
            this.label_Target_1_Red.TabIndex = 52;
            this.label_Target_1_Red.Visible = false;
            // 
            // label_Target_1_Green
            // 
            this.label_Target_1_Green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_1_Green.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_1_Green.Image = global::Multiple_Test.Properties.Resources.Green;
            this.label_Target_1_Green.Location = new System.Drawing.Point(663, 54);
            this.label_Target_1_Green.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_Green.Name = "label_Target_1_Green";
            this.label_Target_1_Green.Size = new System.Drawing.Size(69, 64);
            this.label_Target_1_Green.TabIndex = 51;
            this.label_Target_1_Green.Visible = false;
            // 
            // label_Target_1_BGreen
            // 
            this.label_Target_1_BGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Target_1_BGreen.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Target_1_BGreen.Image = global::Multiple_Test.Properties.Resources._null;
            this.label_Target_1_BGreen.Location = new System.Drawing.Point(663, 54);
            this.label_Target_1_BGreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_BGreen.Name = "label_Target_1_BGreen";
            this.label_Target_1_BGreen.Size = new System.Drawing.Size(69, 64);
            this.label_Target_1_BGreen.TabIndex = 43;
            // 
            // label_Target_4_Version
            // 
            this.label_Target_4_Version.BackColor = System.Drawing.SystemColors.Window;
            this.label_Target_4_Version.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Target_4_Version.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_4_Version.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_4_Version.Location = new System.Drawing.Point(202, 344);
            this.label_Target_4_Version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_Version.Name = "label_Target_4_Version";
            this.label_Target_4_Version.Size = new System.Drawing.Size(135, 27);
            this.label_Target_4_Version.TabIndex = 42;
            this.label_Target_4_Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Target_4_CRC
            // 
            this.label_Target_4_CRC.BackColor = System.Drawing.SystemColors.Window;
            this.label_Target_4_CRC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Target_4_CRC.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_4_CRC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_4_CRC.Location = new System.Drawing.Point(488, 344);
            this.label_Target_4_CRC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_CRC.Name = "label_Target_4_CRC";
            this.label_Target_4_CRC.Size = new System.Drawing.Size(135, 27);
            this.label_Target_4_CRC.TabIndex = 40;
            this.label_Target_4_CRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Target_4_CRCTitle
            // 
            this.label_Target_4_CRCTitle.AutoSize = true;
            this.label_Target_4_CRCTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_4_CRCTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_4_CRCTitle.Location = new System.Drawing.Point(346, 345);
            this.label_Target_4_CRCTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_4_CRCTitle.Name = "label_Target_4_CRCTitle";
            this.label_Target_4_CRCTitle.Size = new System.Drawing.Size(137, 25);
            this.label_Target_4_CRCTitle.TabIndex = 39;
            this.label_Target_4_CRCTitle.Text = "IC CRC code :";
            // 
            // label_Target_3_VersionTitle
            // 
            this.label_Target_3_VersionTitle.AutoSize = true;
            this.label_Target_3_VersionTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_3_VersionTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_3_VersionTitle.Location = new System.Drawing.Point(87, 254);
            this.label_Target_3_VersionTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_VersionTitle.Name = "label_Target_3_VersionTitle";
            this.label_Target_3_VersionTitle.Size = new System.Drawing.Size(108, 25);
            this.label_Target_3_VersionTitle.TabIndex = 36;
            this.label_Target_3_VersionTitle.Text = "IC version:";
            // 
            // label_Target_3
            // 
            this.label_Target_3.AutoSize = true;
            this.label_Target_3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_Target_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_3.Location = new System.Drawing.Point(46, 222);
            this.label_Target_3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3.Name = "label_Target_3";
            this.label_Target_3.Size = new System.Drawing.Size(92, 25);
            this.label_Target_3.TabIndex = 33;
            this.label_Target_3.Text = "Target 3";
            // 
            // label_Target_3_Version
            // 
            this.label_Target_3_Version.BackColor = System.Drawing.SystemColors.Window;
            this.label_Target_3_Version.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Target_3_Version.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_3_Version.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_3_Version.Location = new System.Drawing.Point(202, 252);
            this.label_Target_3_Version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_Version.Name = "label_Target_3_Version";
            this.label_Target_3_Version.Size = new System.Drawing.Size(135, 27);
            this.label_Target_3_Version.TabIndex = 37;
            this.label_Target_3_Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Target_3_CRC
            // 
            this.label_Target_3_CRC.BackColor = System.Drawing.SystemColors.Window;
            this.label_Target_3_CRC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Target_3_CRC.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_3_CRC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_3_CRC.Location = new System.Drawing.Point(488, 252);
            this.label_Target_3_CRC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_CRC.Name = "label_Target_3_CRC";
            this.label_Target_3_CRC.Size = new System.Drawing.Size(135, 27);
            this.label_Target_3_CRC.TabIndex = 35;
            this.label_Target_3_CRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Target_3_CRCTitle
            // 
            this.label_Target_3_CRCTitle.AutoSize = true;
            this.label_Target_3_CRCTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_3_CRCTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_3_CRCTitle.Location = new System.Drawing.Point(346, 254);
            this.label_Target_3_CRCTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_3_CRCTitle.Name = "label_Target_3_CRCTitle";
            this.label_Target_3_CRCTitle.Size = new System.Drawing.Size(137, 25);
            this.label_Target_3_CRCTitle.TabIndex = 34;
            this.label_Target_3_CRCTitle.Text = "IC CRC code :";
            // 
            // label_Target_2_VersionTitle
            // 
            this.label_Target_2_VersionTitle.AutoSize = true;
            this.label_Target_2_VersionTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_2_VersionTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_2_VersionTitle.Location = new System.Drawing.Point(87, 162);
            this.label_Target_2_VersionTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_VersionTitle.Name = "label_Target_2_VersionTitle";
            this.label_Target_2_VersionTitle.Size = new System.Drawing.Size(108, 25);
            this.label_Target_2_VersionTitle.TabIndex = 31;
            this.label_Target_2_VersionTitle.Text = "IC version:";
            // 
            // label_Target_2
            // 
            this.label_Target_2.AutoSize = true;
            this.label_Target_2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_Target_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_2.Location = new System.Drawing.Point(46, 130);
            this.label_Target_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2.Name = "label_Target_2";
            this.label_Target_2.Size = new System.Drawing.Size(92, 25);
            this.label_Target_2.TabIndex = 28;
            this.label_Target_2.Text = "Target 2";
            // 
            // label_Target_2_Version
            // 
            this.label_Target_2_Version.BackColor = System.Drawing.SystemColors.Window;
            this.label_Target_2_Version.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Target_2_Version.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_2_Version.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_2_Version.Location = new System.Drawing.Point(202, 160);
            this.label_Target_2_Version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_Version.Name = "label_Target_2_Version";
            this.label_Target_2_Version.Size = new System.Drawing.Size(135, 27);
            this.label_Target_2_Version.TabIndex = 32;
            this.label_Target_2_Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Target_2_CRC
            // 
            this.label_Target_2_CRC.BackColor = System.Drawing.SystemColors.Window;
            this.label_Target_2_CRC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Target_2_CRC.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_2_CRC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_2_CRC.Location = new System.Drawing.Point(488, 160);
            this.label_Target_2_CRC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_CRC.Name = "label_Target_2_CRC";
            this.label_Target_2_CRC.Size = new System.Drawing.Size(135, 27);
            this.label_Target_2_CRC.TabIndex = 30;
            this.label_Target_2_CRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Target_2_CRCTitle
            // 
            this.label_Target_2_CRCTitle.AutoSize = true;
            this.label_Target_2_CRCTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_2_CRCTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_2_CRCTitle.Location = new System.Drawing.Point(346, 162);
            this.label_Target_2_CRCTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_2_CRCTitle.Name = "label_Target_2_CRCTitle";
            this.label_Target_2_CRCTitle.Size = new System.Drawing.Size(137, 25);
            this.label_Target_2_CRCTitle.TabIndex = 29;
            this.label_Target_2_CRCTitle.Text = "IC CRC code :";
            // 
            // label_Target_1_VersionTitle
            // 
            this.label_Target_1_VersionTitle.AutoSize = true;
            this.label_Target_1_VersionTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_1_VersionTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_1_VersionTitle.Location = new System.Drawing.Point(87, 75);
            this.label_Target_1_VersionTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_VersionTitle.Name = "label_Target_1_VersionTitle";
            this.label_Target_1_VersionTitle.Size = new System.Drawing.Size(108, 25);
            this.label_Target_1_VersionTitle.TabIndex = 26;
            this.label_Target_1_VersionTitle.Text = "IC version:";
            // 
            // label_Target_1
            // 
            this.label_Target_1.AutoSize = true;
            this.label_Target_1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_Target_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_1.Location = new System.Drawing.Point(46, 44);
            this.label_Target_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1.Name = "label_Target_1";
            this.label_Target_1.Size = new System.Drawing.Size(92, 25);
            this.label_Target_1.TabIndex = 0;
            this.label_Target_1.Text = "Target 1";
            // 
            // label_Target_1_Version
            // 
            this.label_Target_1_Version.BackColor = System.Drawing.SystemColors.Window;
            this.label_Target_1_Version.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Target_1_Version.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_1_Version.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_1_Version.Location = new System.Drawing.Point(202, 74);
            this.label_Target_1_Version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_Version.Name = "label_Target_1_Version";
            this.label_Target_1_Version.Size = new System.Drawing.Size(135, 27);
            this.label_Target_1_Version.TabIndex = 27;
            this.label_Target_1_Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Target_1_CRC
            // 
            this.label_Target_1_CRC.BackColor = System.Drawing.SystemColors.Window;
            this.label_Target_1_CRC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_Target_1_CRC.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_1_CRC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_1_CRC.Location = new System.Drawing.Point(488, 74);
            this.label_Target_1_CRC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_CRC.Name = "label_Target_1_CRC";
            this.label_Target_1_CRC.Size = new System.Drawing.Size(135, 27);
            this.label_Target_1_CRC.TabIndex = 25;
            this.label_Target_1_CRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Target_1_CRCTitle
            // 
            this.label_Target_1_CRCTitle.AutoSize = true;
            this.label_Target_1_CRCTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_Target_1_CRCTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Target_1_CRCTitle.Location = new System.Drawing.Point(346, 75);
            this.label_Target_1_CRCTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Target_1_CRCTitle.Name = "label_Target_1_CRCTitle";
            this.label_Target_1_CRCTitle.Size = new System.Drawing.Size(137, 25);
            this.label_Target_1_CRCTitle.TabIndex = 24;
            this.label_Target_1_CRCTitle.Text = "IC CRC code :";
            // 
            // btn_clearLogs
            // 
            this.btn_clearLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clearLogs.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_clearLogs.Location = new System.Drawing.Point(1574, 592);
            this.btn_clearLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_clearLogs.Name = "btn_clearLogs";
            this.btn_clearLogs.Size = new System.Drawing.Size(120, 38);
            this.btn_clearLogs.TabIndex = 20;
            this.btn_clearLogs.Text = "Clear logs";
            this.btn_clearLogs.UseVisualStyleBackColor = true;
            this.btn_clearLogs.Click += new System.EventHandler(this.btn_clearLogs_Click);
            // 
            // groupBox_minFile
            // 
            this.groupBox_minFile.Controls.Add(this.label_mifVersionTitle);
            this.groupBox_minFile.Controls.Add(this.label_mifVersion);
            this.groupBox_minFile.Controls.Add(this.labOpenReadMinFile);
            this.groupBox_minFile.Controls.Add(this.label_mifCRCTitle);
            this.groupBox_minFile.Controls.Add(this.btn_OpenReadMinFile);
            this.groupBox_minFile.Controls.Add(this.label_mifCRC);
            this.groupBox_minFile.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox_minFile.ForeColor = System.Drawing.Color.Blue;
            this.groupBox_minFile.Location = new System.Drawing.Point(16, 39);
            this.groupBox_minFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_minFile.Name = "groupBox_minFile";
            this.groupBox_minFile.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_minFile.Size = new System.Drawing.Size(890, 114);
            this.groupBox_minFile.TabIndex = 18;
            this.groupBox_minFile.TabStop = false;
            this.groupBox_minFile.Text = "Laod configure from .MIF";
            // 
            // labOpenReadMinFile
            // 
            this.labOpenReadMinFile.BackColor = System.Drawing.SystemColors.Control;
            this.labOpenReadMinFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labOpenReadMinFile.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.labOpenReadMinFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labOpenReadMinFile.Location = new System.Drawing.Point(141, 36);
            this.labOpenReadMinFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labOpenReadMinFile.Name = "labOpenReadMinFile";
            this.labOpenReadMinFile.Size = new System.Drawing.Size(740, 27);
            this.labOpenReadMinFile.TabIndex = 18;
            this.labOpenReadMinFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_mifCRCTitle
            // 
            this.label_mifCRCTitle.AutoSize = true;
            this.label_mifCRCTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_mifCRCTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_mifCRCTitle.Location = new System.Drawing.Point(628, 75);
            this.label_mifCRCTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_mifCRCTitle.Name = "label_mifCRCTitle";
            this.label_mifCRCTitle.Size = new System.Drawing.Size(113, 25);
            this.label_mifCRCTitle.TabIndex = 12;
            this.label_mifCRCTitle.Text = "CRC code :";
            // 
            // btn_OpenReadMinFile
            // 
            this.btn_OpenReadMinFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OpenReadMinFile.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_OpenReadMinFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_OpenReadMinFile.Location = new System.Drawing.Point(16, 30);
            this.btn_OpenReadMinFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_OpenReadMinFile.Name = "btn_OpenReadMinFile";
            this.btn_OpenReadMinFile.Size = new System.Drawing.Size(116, 36);
            this.btn_OpenReadMinFile.TabIndex = 10;
            this.btn_OpenReadMinFile.Text = "Load .MIF";
            this.btn_OpenReadMinFile.UseVisualStyleBackColor = true;
            this.btn_OpenReadMinFile.Click += new System.EventHandler(this.btn_OpenReadMinFile_Click);
            // 
            // label_mifCRC
            // 
            this.label_mifCRC.BackColor = System.Drawing.SystemColors.Window;
            this.label_mifCRC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_mifCRC.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label_mifCRC.ForeColor = System.Drawing.Color.Red;
            this.label_mifCRC.Location = new System.Drawing.Point(746, 74);
            this.label_mifCRC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_mifCRC.Name = "label_mifCRC";
            this.label_mifCRC.Size = new System.Drawing.Size(135, 27);
            this.label_mifCRC.TabIndex = 13;
            this.label_mifCRC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_1to4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tabControl1.Location = new System.Drawing.Point(9, 128);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1725, 680);
            this.tabControl1.TabIndex = 27;
            // 
            // label_LogoTitle
            // 
            this.label_LogoTitle.Font = new System.Drawing.Font("Microsoft JhengHei UI", 27.75F, System.Drawing.FontStyle.Bold);
            this.label_LogoTitle.Location = new System.Drawing.Point(9, 32);
            this.label_LogoTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LogoTitle.Name = "label_LogoTitle";
            this.label_LogoTitle.Size = new System.Drawing.Size(1328, 70);
            this.label_LogoTitle.TabIndex = 2;
            this.label_LogoTitle.Text = "光寶-長安 OP-Katakuri NXP TEA2376 4CH Programer";
            this.label_LogoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // USBCheckTimer
            // 
            this.USBCheckTimer.Enabled = true;
            this.USBCheckTimer.Interval = 1000;
            // 
            // label_WPIgLogo
            // 
            this.label_WPIgLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_WPIgLogo.ForeColor = System.Drawing.SystemColors.Window;
            this.label_WPIgLogo.Image = global::Multiple_Test.Properties.Resources.WPIg;
            this.label_WPIgLogo.Location = new System.Drawing.Point(1488, 32);
            this.label_WPIgLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_WPIgLogo.Name = "label_WPIgLogo";
            this.label_WPIgLogo.Size = new System.Drawing.Size(240, 93);
            this.label_WPIgLogo.TabIndex = 30;
            // 
            // label_USBconnection
            // 
            this.label_USBconnection.AutoSize = true;
            this.label_USBconnection.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_USBconnection.Location = new System.Drawing.Point(16, 818);
            this.label_USBconnection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_USBconnection.Name = "label_USBconnection";
            this.label_USBconnection.Size = new System.Drawing.Size(180, 25);
            this.label_USBconnection.TabIndex = 28;
            this.label_USBconnection.Text = "USB Connection :";
            // 
            // label_Connected
            // 
            this.label_Connected.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_Connected.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Connected.Location = new System.Drawing.Point(194, 818);
            this.label_Connected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Connected.Name = "label_Connected";
            this.label_Connected.Size = new System.Drawing.Size(124, 30);
            this.label_Connected.TabIndex = 29;
            this.label_Connected.Text = "-";
            // 
            // label_fwVerstion
            // 
            this.label_fwVerstion.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label_fwVerstion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_fwVerstion.Location = new System.Drawing.Point(327, 816);
            this.label_fwVerstion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_fwVerstion.Name = "label_fwVerstion";
            this.label_fwVerstion.Size = new System.Drawing.Size(594, 30);
            this.label_fwVerstion.TabIndex = 32;
            this.label_fwVerstion.Text = "FW Verstion : -";
            this.label_fwVerstion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1748, 32);
            this.menuStrip1.TabIndex = 39;
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
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
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
            this.scanConfigToolStripMenuItem.Size = new System.Drawing.Size(207, 34);
            this.scanConfigToolStripMenuItem.Text = "ScanConfig";
            this.scanConfigToolStripMenuItem.Click += new System.EventHandler(this.ScanConfigToolStripMenuItem_Click);
            // 
            // mqttServerToolStripMenuItem
            // 
            this.mqttServerToolStripMenuItem.Image = global::Multiple_Test.Properties.Resources.publish;
            this.mqttServerToolStripMenuItem.Name = "mqttServerToolStripMenuItem";
            this.mqttServerToolStripMenuItem.Size = new System.Drawing.Size(207, 34);
            this.mqttServerToolStripMenuItem.Text = "MqttServer";
            // 
            // mCUConfigToolStripMenuItem1
            // 
            this.mCUConfigToolStripMenuItem1.Image = global::Multiple_Test.Properties.Resources.PLC信息管理;
            this.mCUConfigToolStripMenuItem1.Name = "mCUConfigToolStripMenuItem1";
            this.mCUConfigToolStripMenuItem1.Size = new System.Drawing.Size(207, 34);
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
            // lab_UserName
            // 
            this.lab_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_UserName.AutoEllipsis = true;
            this.lab_UserName.AutoSize = true;
            this.lab_UserName.Font = new System.Drawing.Font("宋体", 12F);
            this.lab_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lab_UserName.Location = new System.Drawing.Point(1398, 44);
            this.lab_UserName.Name = "lab_UserName";
            this.lab_UserName.Size = new System.Drawing.Size(106, 24);
            this.lab_UserName.TabIndex = 142;
            this.lab_UserName.Text = "21103379";
            this.lab_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtScanProtName
            // 
            this.txtScanProtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtScanProtName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtScanProtName.Location = new System.Drawing.Point(533, 111);
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
            this.txtScanProtName.TabIndex = 153;
            this.txtScanProtName.Tag = "0";
            this.txtScanProtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtScanProtName.Watermark = "";
            // 
            // uiMarkLabel6
            // 
            this.uiMarkLabel6.AutoSize = true;
            this.uiMarkLabel6.Font = new System.Drawing.Font("宋体", 12F);
            this.uiMarkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiMarkLabel6.Location = new System.Drawing.Point(376, 111);
            this.uiMarkLabel6.MarkColor = System.Drawing.Color.Blue;
            this.uiMarkLabel6.Name = "uiMarkLabel6";
            this.uiMarkLabel6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel6.Size = new System.Drawing.Size(99, 24);
            this.uiMarkLabel6.TabIndex = 152;
            this.uiMarkLabel6.Text = "读码器:";
            this.uiMarkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMCUPortName
            // 
            this.txtMCUPortName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMCUPortName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtMCUPortName.Location = new System.Drawing.Point(851, 113);
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
            this.txtMCUPortName.TabIndex = 155;
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
            this.uiMarkLabel7.Location = new System.Drawing.Point(708, 113);
            this.uiMarkLabel7.MarkColor = System.Drawing.Color.Blue;
            this.uiMarkLabel7.Name = "uiMarkLabel7";
            this.uiMarkLabel7.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel7.Size = new System.Drawing.Size(99, 24);
            this.uiMarkLabel7.TabIndex = 154;
            this.uiMarkLabel7.Text = "控制器:";
            this.uiMarkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ledSan
            // 
            this.ledSan.Color = System.Drawing.Color.Red;
            this.ledSan.Location = new System.Drawing.Point(493, 113);
            this.ledSan.Name = "ledSan";
            this.ledSan.Size = new System.Drawing.Size(19, 24);
            this.ledSan.TabIndex = 160;
            this.ledSan.Text = "uiLedBulb2";
            // 
            // ledMcu
            // 
            this.ledMcu.Color = System.Drawing.Color.Red;
            this.ledMcu.Location = new System.Drawing.Point(825, 115);
            this.ledMcu.Name = "ledMcu";
            this.ledMcu.Size = new System.Drawing.Size(19, 24);
            this.ledMcu.TabIndex = 159;
            this.ledMcu.Text = "uiLedBulb1";
            // 
            // FormGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1748, 855);
            this.Controls.Add(this.ledSan);
            this.Controls.Add(this.ledMcu);
            this.Controls.Add(this.txtMCUPortName);
            this.Controls.Add(this.uiMarkLabel7);
            this.Controls.Add(this.txtScanProtName);
            this.Controls.Add(this.uiMarkLabel6);
            this.Controls.Add(this.lab_UserName);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label_fwVerstion);
            this.Controls.Add(this.label_Connected);
            this.Controls.Add(this.label_WPIgLogo);
            this.Controls.Add(this.label_USBconnection);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_LogoTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OP-Katakuri NXP TEA2376 4CH Programer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGUI_FormClosing);
            this.Load += new System.EventHandler(this.FormGUI_Load);
            this.tabPage_1to4.ResumeLayout(false);
            this.tabPage_1to4.PerformLayout();
            this.groupBox_Target.ResumeLayout(false);
            this.groupBox_Target.PerformLayout();
            this.groupBox_minFile.ResumeLayout(false);
            this.groupBox_minFile.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label_mifVersionTitle;
        public System.Windows.Forms.Label label_NowTime;
        public System.Windows.Forms.Label label_Time;
        public System.Windows.Forms.Label label_NowDate;
        public System.Windows.Forms.Label label_Date;
        public System.Windows.Forms.Label label_WPIgLogo;
        public System.Windows.Forms.Timer timer_Now;
        public System.Windows.Forms.Label label_mifVersion;
        public System.Windows.Forms.Label label_Target_4_Red;
        public System.Windows.Forms.Label label_Target_4_Green;
        public System.Windows.Forms.Label label_Target_4_BGreen;
        public System.Windows.Forms.Label label_Target_3_Red;
        public System.Windows.Forms.Label label_Target_3_Green;
        public System.Windows.Forms.Label label_Target_3_BGreen;
        public System.Windows.Forms.Label label_Target_2_Red;
        public System.Windows.Forms.Label label_Target_2_Green;
        public System.Windows.Forms.Label label_Target_2_BGreen;
        public System.Windows.Forms.Label label_Target_1_Red;
        public System.Windows.Forms.Label label_Target_1_Green;
        public System.Windows.Forms.Label label_Target_1_BGreen;
        public System.Windows.Forms.Label label_Target_4_VersionTitle;
        public System.Windows.Forms.Label label_Target_4;
        public System.Windows.Forms.Label label_Log;
        public System.Windows.Forms.Button buttonWriteDevice;
        public System.Windows.Forms.Button btn_saveLogs;
        public System.Windows.Forms.Button button_searchTargetIC;
        public System.Windows.Forms.ListBox listBoxLogs;
        public System.Windows.Forms.TabPage tabPage_1to4;
        public System.Windows.Forms.GroupBox groupBox_Target;
        public System.Windows.Forms.Label label_Target_4_Version;
        public System.Windows.Forms.Label label_Target_4_CRC;
        public System.Windows.Forms.Label label_Target_4_CRCTitle;
        public System.Windows.Forms.Label label_Target_3_VersionTitle;
        public System.Windows.Forms.Label label_Target_3;
        public System.Windows.Forms.Label label_Target_3_Version;
        public System.Windows.Forms.Label label_Target_3_CRC;
        public System.Windows.Forms.Label label_Target_3_CRCTitle;
        public System.Windows.Forms.Label label_Target_2_VersionTitle;
        public System.Windows.Forms.Label label_Target_2;
        public System.Windows.Forms.Label label_Target_2_Version;
        public System.Windows.Forms.Label label_Target_2_CRC;
        public System.Windows.Forms.Label label_Target_2_CRCTitle;
        public System.Windows.Forms.Label label_Target_1_VersionTitle;
        public System.Windows.Forms.Label label_Target_1;
        public System.Windows.Forms.Label label_Target_1_Version;
        public System.Windows.Forms.Label label_Target_1_CRC;
        public System.Windows.Forms.Label label_Target_1_CRCTitle;
        public System.Windows.Forms.Button btn_clearLogs;
        public System.Windows.Forms.GroupBox groupBox_minFile;
        public System.Windows.Forms.Label labOpenReadMinFile;
        public System.Windows.Forms.Label label_mifCRCTitle;
        public System.Windows.Forms.Button btn_OpenReadMinFile;
        public System.Windows.Forms.Label label_mifCRC;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.Label label_LogoTitle;
        public System.Windows.Forms.Timer USBCheckTimer;
        public System.Windows.Forms.Label label_Target_4_status;
        public System.Windows.Forms.Label label_Target_3_status;
        public System.Windows.Forms.Label label_Target_2_status;
        public System.Windows.Forms.Label label_Target_1_status;
        public System.Windows.Forms.Label label_Target_1_UnW;
        public System.Windows.Forms.Label label_Target_1_UnR;
        public System.Windows.Forms.Button button_eraseIC;
        public System.Windows.Forms.Button button_writeLockIC;
        public System.Windows.Forms.Button button_readLockIC;
        public System.Windows.Forms.Label label_Target_1_W;
        public System.Windows.Forms.Label label_Target_1_R;
        public System.Windows.Forms.Label label_Target_4_W;
        public System.Windows.Forms.Label label_Target_4_R;
        public System.Windows.Forms.Label label_Target_4_UnW;
        public System.Windows.Forms.Label label_Target_4_UnR;
        public System.Windows.Forms.Label label_Target_3_W;
        public System.Windows.Forms.Label label_Target_3_R;
        public System.Windows.Forms.Label label_Target_3_UnW;
        public System.Windows.Forms.Label label_Target_3_UnR;
        public System.Windows.Forms.Label label_Target_2_W;
        public System.Windows.Forms.Label label_Target_2_R;
        public System.Windows.Forms.Label label_Target_2_UnW;
        public System.Windows.Forms.Label label_Target_2_UnR;
        public System.Windows.Forms.Label label_titleProgram;
        public System.Windows.Forms.Label label1label_titleWrite;
        public System.Windows.Forms.Label label_titleRead;
        public System.Windows.Forms.Label label_USBconnection;
        public System.Windows.Forms.Label label_Connected;
        public System.Windows.Forms.Label label_fwVerstion;
        public Button button_PowerOff;
        public Button button_PowerOn;
        public Button btnstart;
        private Label label2;
        private TextBox txtSerialNumber;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem btnOpenHex;
        private ToolStripMenuItem btnOpenLog;
        private ToolStripMenuItem btnRun;
        private ToolStripMenuItem 扫码器配置ToolStripMenuItem;
        private ToolStripMenuItem scanConfigToolStripMenuItem;
        private ToolStripMenuItem mqttServerToolStripMenuItem;
        private ToolStripMenuItem mCUConfigToolStripMenuItem1;
        private ToolStripMenuItem DebuggerConfigToolStripMenuItem;
        private ToolStripMenuItem Rs232ToolStripMenuItem;
        private ToolStripMenuItem 气缸上升ToolStripMenuItem;
        private ToolStripMenuItem 气缸可下降ToolStripMenuItem;
        private ToolStripMenuItem mCU33V开ToolStripMenuItem;
        private ToolStripMenuItem mCU33V关ToolStripMenuItem;
        private ToolStripMenuItem 关闭控制器串口ToolStripMenuItem;
        private ToolStripMenuItem 关闭扫码器串口ToolStripMenuItem;
        private ToolStripMenuItem 读取条码ToolStripMenuItem;
        private ToolStripMenuItem 关闭读取条码ToolStripMenuItem;
        private Sunny.UI.UILabel lab_UserName;
        private Sunny.UI.UITextBox txtScanProtName;
        private Sunny.UI.UIMarkLabel uiMarkLabel6;
        private Sunny.UI.UITextBox txtMCUPortName;
        private Sunny.UI.UIMarkLabel uiMarkLabel7;
        private Sunny.UI.UILedBulb ledSan;
        private Sunny.UI.UILedBulb ledMcu;
    }
}
