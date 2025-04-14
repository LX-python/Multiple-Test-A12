using System.Windows.Forms;
using System.Drawing;
namespace NXP_TEA_IC
{
    partial class FormGUI
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGUI));
            label_mifVersionTitle = new Label();
            label_NowTime = new Label();
            label_Time = new Label();
            label_NowDate = new Label();
            label_Date = new Label();
            timer_Now = new System.Windows.Forms.Timer(components);
            label_mifVersion = new Label();
            label_Target_4_VersionTitle = new Label();
            label_Target_4 = new Label();
            label_Log = new Label();
            buttonWriteDevice = new Button();
            btn_saveLogs = new Button();
            button_searchTargetIC = new Button();
            listBoxLogs = new ListBox();
            tabPage_1to4 = new TabPage();
            button_PowerOff = new Button();
            button_PowerOn = new Button();
            button_writeLockIC = new Button();
            button_readLockIC = new Button();
            button_eraseIC = new Button();
            groupBox_Target = new GroupBox();
            label1label_titleWrite = new Label();
            label_titleRead = new Label();
            label_Target_4_W = new Label();
            label_Target_1_W = new Label();
            label_titleProgram = new Label();
            label_Target_4_R = new Label();
            label_Target_3_W = new Label();
            label_Target_4_UnW = new Label();
            label_Target_2_W = new Label();
            label_Target_1_UnW = new Label();
            label_Target_1_R = new Label();
            label_Target_4_UnR = new Label();
            label_Target_1_UnR = new Label();
            label_Target_4_status = new Label();
            label_Target_3_UnW = new Label();
            label_Target_3_R = new Label();
            label_Target_3_status = new Label();
            label_Target_2_UnW = new Label();
            label_Target_2_status = new Label();
            label_Target_3_UnR = new Label();
            label_Target_1_status = new Label();
            label_Target_4_Red = new Label();
            label_Target_4_Green = new Label();
            label_Target_2_R = new Label();
            label_Target_4_BGreen = new Label();
            label_Target_3_Red = new Label();
            label_Target_2_UnR = new Label();
            label_Target_3_Green = new Label();
            label_Target_3_BGreen = new Label();
            label_Target_2_Red = new Label();
            label_Target_2_Green = new Label();
            label_Target_2_BGreen = new Label();
            label_Target_1_Red = new Label();
            label_Target_1_Green = new Label();
            label_Target_1_BGreen = new Label();
            label_Target_4_Version = new Label();
            label_Target_4_CRC = new Label();
            label_Target_4_CRCTitle = new Label();
            label_Target_3_VersionTitle = new Label();
            label_Target_3 = new Label();
            label_Target_3_Version = new Label();
            label_Target_3_CRC = new Label();
            label_Target_3_CRCTitle = new Label();
            label_Target_2_VersionTitle = new Label();
            label_Target_2 = new Label();
            label_Target_2_Version = new Label();
            label_Target_2_CRC = new Label();
            label_Target_2_CRCTitle = new Label();
            label_Target_1_VersionTitle = new Label();
            label_Target_1 = new Label();
            label_Target_1_Version = new Label();
            label_Target_1_CRC = new Label();
            label_Target_1_CRCTitle = new Label();
            btn_clearLogs = new Button();
            groupBox_minFile = new GroupBox();
            labOpenReadMinFile = new Label();
            label_mifCRCTitle = new Label();
            btn_OpenReadMinFile = new Button();
            label_mifCRC = new Label();
            tabControl1 = new TabControl();
            label_LogoTitle = new Label();
            USBCheckTimer = new System.Windows.Forms.Timer(components);
            label_WPIgLogo = new Label();
            label_USBconnection = new Label();
            label_Connected = new Label();
            label_fwVerstion = new Label();
            tabPage_1to4.SuspendLayout();
            groupBox_Target.SuspendLayout();
            groupBox_minFile.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // label_mifVersionTitle
            // 
            label_mifVersionTitle.AutoSize = true;
            label_mifVersionTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_mifVersionTitle.ForeColor = SystemColors.ControlText;
            label_mifVersionTitle.Location = new Point(262, 50);
            label_mifVersionTitle.Name = "label_mifVersionTitle";
            label_mifVersionTitle.Size = new Size(84, 25);
            label_mifVersionTitle.TabIndex = 19;
            label_mifVersionTitle.Text = "version:";
            // 
            // label_NowTime
            // 
            label_NowTime.BackColor = SystemColors.Window;
            label_NowTime.BorderStyle = BorderStyle.Fixed3D;
            label_NowTime.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_NowTime.Location = new Point(1021, 24);
            label_NowTime.Name = "label_NowTime";
            label_NowTime.Size = new Size(108, 18);
            label_NowTime.TabIndex = 9;
            label_NowTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Time
            // 
            label_Time.AutoSize = true;
            label_Time.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Time.Location = new Point(966, 25);
            label_Time.Name = "label_Time";
            label_Time.Size = new Size(77, 25);
            label_Time.TabIndex = 8;
            label_Time.Text = "Times :";
            // 
            // label_NowDate
            // 
            label_NowDate.BackColor = SystemColors.Window;
            label_NowDate.BorderStyle = BorderStyle.Fixed3D;
            label_NowDate.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_NowDate.Location = new Point(852, 24);
            label_NowDate.Name = "label_NowDate";
            label_NowDate.Size = new Size(108, 18);
            label_NowDate.TabIndex = 7;
            label_NowDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_Date
            // 
            label_Date.AutoSize = true;
            label_Date.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Date.Location = new Point(803, 25);
            label_Date.Name = "label_Date";
            label_Date.Size = new Size(66, 25);
            label_Date.TabIndex = 6;
            label_Date.Text = "Date :";
            // 
            // timer_Now
            // 
            timer_Now.Enabled = true;
            timer_Now.Interval = 1000;
            timer_Now.Tick += timer_Now_Tick;
            // 
            // label_mifVersion
            // 
            label_mifVersion.BackColor = SystemColors.Window;
            label_mifVersion.BorderStyle = BorderStyle.Fixed3D;
            label_mifVersion.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_mifVersion.ForeColor = Color.Red;
            label_mifVersion.Location = new Point(323, 49);
            label_mifVersion.Name = "label_mifVersion";
            label_mifVersion.Size = new Size(90, 18);
            label_mifVersion.TabIndex = 20;
            label_mifVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Target_4_VersionTitle
            // 
            label_Target_4_VersionTitle.AutoSize = true;
            label_Target_4_VersionTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_4_VersionTitle.ForeColor = SystemColors.ControlText;
            label_Target_4_VersionTitle.Location = new Point(58, 230);
            label_Target_4_VersionTitle.Name = "label_Target_4_VersionTitle";
            label_Target_4_VersionTitle.Size = new Size(108, 25);
            label_Target_4_VersionTitle.TabIndex = 41;
            label_Target_4_VersionTitle.Text = "IC version:";
            // 
            // label_Target_4
            // 
            label_Target_4.AutoSize = true;
            label_Target_4.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Target_4.ForeColor = SystemColors.ControlText;
            label_Target_4.Location = new Point(31, 209);
            label_Target_4.Name = "label_Target_4";
            label_Target_4.Size = new Size(92, 25);
            label_Target_4.TabIndex = 38;
            label_Target_4.Text = "Target 4";
            // 
            // label_Log
            // 
            label_Log.AutoSize = true;
            label_Log.Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_Log.Location = new Point(610, 26);
            label_Log.Name = "label_Log";
            label_Log.Size = new Size(53, 23);
            label_Log.TabIndex = 27;
            label_Log.Text = "Log :";
            // 
            // buttonWriteDevice
            // 
            buttonWriteDevice.Cursor = Cursors.Hand;
            buttonWriteDevice.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonWriteDevice.Location = new Point(442, 395);
            buttonWriteDevice.Name = "buttonWriteDevice";
            buttonWriteDevice.Size = new Size(164, 25);
            buttonWriteDevice.TabIndex = 24;
            buttonWriteDevice.Text = "Program / Write device";
            buttonWriteDevice.UseVisualStyleBackColor = true;
            buttonWriteDevice.Click += buttonWriteDevice_Click;
            // 
            // btn_saveLogs
            // 
            btn_saveLogs.Cursor = Cursors.Hand;
            btn_saveLogs.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_saveLogs.Location = new Point(963, 395);
            btn_saveLogs.Margin = new Padding(3, 2, 3, 2);
            btn_saveLogs.Name = "btn_saveLogs";
            btn_saveLogs.Size = new Size(80, 25);
            btn_saveLogs.TabIndex = 18;
            btn_saveLogs.Text = "Save logs";
            btn_saveLogs.UseVisualStyleBackColor = true;
            btn_saveLogs.Click += btn_saveLogs_Click;
            // 
            // button_searchTargetIC
            // 
            button_searchTargetIC.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button_searchTargetIC.Location = new Point(319, 395);
            button_searchTargetIC.Name = "button_searchTargetIC";
            button_searchTargetIC.Size = new Size(117, 25);
            button_searchTargetIC.TabIndex = 24;
            button_searchTargetIC.Text = "Search Target IC";
            button_searchTargetIC.UseVisualStyleBackColor = true;
            button_searchTargetIC.Click += button_searchTargetIC_Click;
            // 
            // listBoxLogs
            // 
            listBoxLogs.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxLogs.FormattingEnabled = true;
            listBoxLogs.HorizontalScrollbar = true;
            listBoxLogs.ItemHeight = 23;
            listBoxLogs.Location = new Point(612, 46);
            listBoxLogs.Margin = new Padding(3, 2, 3, 2);
            listBoxLogs.Name = "listBoxLogs";
            listBoxLogs.ScrollAlwaysVisible = true;
            listBoxLogs.Size = new Size(517, 326);
            listBoxLogs.TabIndex = 22;
            // 
            // tabPage_1to4
            // 
            tabPage_1to4.Controls.Add(button_PowerOff);
            tabPage_1to4.Controls.Add(button_PowerOn);
            tabPage_1to4.Controls.Add(button_writeLockIC);
            tabPage_1to4.Controls.Add(button_readLockIC);
            tabPage_1to4.Controls.Add(button_eraseIC);
            tabPage_1to4.Controls.Add(label_Log);
            tabPage_1to4.Controls.Add(buttonWriteDevice);
            tabPage_1to4.Controls.Add(btn_saveLogs);
            tabPage_1to4.Controls.Add(button_searchTargetIC);
            tabPage_1to4.Controls.Add(listBoxLogs);
            tabPage_1to4.Controls.Add(groupBox_Target);
            tabPage_1to4.Controls.Add(btn_clearLogs);
            tabPage_1to4.Controls.Add(groupBox_minFile);
            tabPage_1to4.Controls.Add(label_NowTime);
            tabPage_1to4.Controls.Add(label_Time);
            tabPage_1to4.Controls.Add(label_NowDate);
            tabPage_1to4.Controls.Add(label_Date);
            tabPage_1to4.Location = new Point(4, 34);
            tabPage_1to4.Margin = new Padding(3, 2, 3, 2);
            tabPage_1to4.Name = "tabPage_1to4";
            tabPage_1to4.Padding = new Padding(3, 2, 3, 2);
            tabPage_1to4.Size = new Size(1142, 415);
            tabPage_1to4.TabIndex = 1;
            tabPage_1to4.Text = "One by Four";
            tabPage_1to4.UseVisualStyleBackColor = true;
            // 
            // button_PowerOff
            // 
            button_PowerOff.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button_PowerOff.ForeColor = Color.Red;
            button_PowerOff.Location = new Point(877, 395);
            button_PowerOff.Name = "button_PowerOff";
            button_PowerOff.Size = new Size(80, 25);
            button_PowerOff.TabIndex = 39;
            button_PowerOff.Text = "Power Off";
            button_PowerOff.UseVisualStyleBackColor = true;
            button_PowerOff.Click += button_PowerOff_Click;
            // 
            // button_PowerOn
            // 
            button_PowerOn.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button_PowerOn.ForeColor = Color.Red;
            button_PowerOn.Location = new Point(791, 395);
            button_PowerOn.Name = "button_PowerOn";
            button_PowerOn.Size = new Size(80, 25);
            button_PowerOn.TabIndex = 40;
            button_PowerOn.Text = "Power On";
            button_PowerOn.UseVisualStyleBackColor = true;
            button_PowerOn.Click += button_PowerOn_Click;
            // 
            // button_writeLockIC
            // 
            button_writeLockIC.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button_writeLockIC.ForeColor = Color.Blue;
            button_writeLockIC.Location = new Point(194, 395);
            button_writeLockIC.Name = "button_writeLockIC";
            button_writeLockIC.Size = new Size(109, 25);
            button_writeLockIC.TabIndex = 38;
            button_writeLockIC.Text = "Write-Lock IC";
            button_writeLockIC.UseVisualStyleBackColor = true;
            button_writeLockIC.Click += button_writeLockIC_Click;
            // 
            // button_readLockIC
            // 
            button_readLockIC.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button_readLockIC.ForeColor = Color.Blue;
            button_readLockIC.Location = new Point(88, 395);
            button_readLockIC.Name = "button_readLockIC";
            button_readLockIC.Size = new Size(100, 25);
            button_readLockIC.TabIndex = 37;
            button_readLockIC.Text = "Read-Lock IC";
            button_readLockIC.UseVisualStyleBackColor = true;
            button_readLockIC.Click += button_readLockIC_Click;
            // 
            // button_eraseIC
            // 
            button_eraseIC.BackColor = Color.Red;
            button_eraseIC.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button_eraseIC.ForeColor = SystemColors.Window;
            button_eraseIC.Location = new Point(11, 395);
            button_eraseIC.Name = "button_eraseIC";
            button_eraseIC.Size = new Size(71, 25);
            button_eraseIC.TabIndex = 36;
            button_eraseIC.Text = "Erase IC";
            button_eraseIC.UseVisualStyleBackColor = false;
            button_eraseIC.Click += button_eraseIC_Click;
            // 
            // groupBox_Target
            // 
            groupBox_Target.Controls.Add(label1label_titleWrite);
            groupBox_Target.Controls.Add(label_titleRead);
            groupBox_Target.Controls.Add(label_Target_4_W);
            groupBox_Target.Controls.Add(label_Target_1_W);
            groupBox_Target.Controls.Add(label_titleProgram);
            groupBox_Target.Controls.Add(label_Target_4_R);
            groupBox_Target.Controls.Add(label_Target_3_W);
            groupBox_Target.Controls.Add(label_Target_4_UnW);
            groupBox_Target.Controls.Add(label_Target_2_W);
            groupBox_Target.Controls.Add(label_Target_1_UnW);
            groupBox_Target.Controls.Add(label_Target_1_R);
            groupBox_Target.Controls.Add(label_Target_4_UnR);
            groupBox_Target.Controls.Add(label_Target_1_UnR);
            groupBox_Target.Controls.Add(label_Target_4_status);
            groupBox_Target.Controls.Add(label_Target_3_UnW);
            groupBox_Target.Controls.Add(label_Target_3_R);
            groupBox_Target.Controls.Add(label_Target_3_status);
            groupBox_Target.Controls.Add(label_Target_2_UnW);
            groupBox_Target.Controls.Add(label_Target_2_status);
            groupBox_Target.Controls.Add(label_Target_3_UnR);
            groupBox_Target.Controls.Add(label_Target_1_status);
            groupBox_Target.Controls.Add(label_Target_4_Red);
            groupBox_Target.Controls.Add(label_Target_4_Green);
            groupBox_Target.Controls.Add(label_Target_2_R);
            groupBox_Target.Controls.Add(label_Target_4_BGreen);
            groupBox_Target.Controls.Add(label_Target_3_Red);
            groupBox_Target.Controls.Add(label_Target_2_UnR);
            groupBox_Target.Controls.Add(label_Target_3_Green);
            groupBox_Target.Controls.Add(label_Target_3_BGreen);
            groupBox_Target.Controls.Add(label_Target_2_Red);
            groupBox_Target.Controls.Add(label_Target_2_Green);
            groupBox_Target.Controls.Add(label_Target_2_BGreen);
            groupBox_Target.Controls.Add(label_Target_1_Red);
            groupBox_Target.Controls.Add(label_Target_1_Green);
            groupBox_Target.Controls.Add(label_Target_1_BGreen);
            groupBox_Target.Controls.Add(label_Target_4_VersionTitle);
            groupBox_Target.Controls.Add(label_Target_4);
            groupBox_Target.Controls.Add(label_Target_4_Version);
            groupBox_Target.Controls.Add(label_Target_4_CRC);
            groupBox_Target.Controls.Add(label_Target_4_CRCTitle);
            groupBox_Target.Controls.Add(label_Target_3_VersionTitle);
            groupBox_Target.Controls.Add(label_Target_3);
            groupBox_Target.Controls.Add(label_Target_3_Version);
            groupBox_Target.Controls.Add(label_Target_3_CRC);
            groupBox_Target.Controls.Add(label_Target_3_CRCTitle);
            groupBox_Target.Controls.Add(label_Target_2_VersionTitle);
            groupBox_Target.Controls.Add(label_Target_2);
            groupBox_Target.Controls.Add(label_Target_2_Version);
            groupBox_Target.Controls.Add(label_Target_2_CRC);
            groupBox_Target.Controls.Add(label_Target_2_CRCTitle);
            groupBox_Target.Controls.Add(label_Target_1_VersionTitle);
            groupBox_Target.Controls.Add(label_Target_1);
            groupBox_Target.Controls.Add(label_Target_1_Version);
            groupBox_Target.Controls.Add(label_Target_1_CRC);
            groupBox_Target.Controls.Add(label_Target_1_CRCTitle);
            groupBox_Target.Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox_Target.ForeColor = Color.Blue;
            groupBox_Target.Location = new Point(11, 107);
            groupBox_Target.Name = "groupBox_Target";
            groupBox_Target.Size = new Size(595, 279);
            groupBox_Target.TabIndex = 26;
            groupBox_Target.TabStop = false;
            groupBox_Target.Text = "Target IC Status";
            // 
            // label1label_titleWrite
            // 
            label1label_titleWrite.AutoSize = true;
            label1label_titleWrite.Font = new Font("微軟正黑體", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1label_titleWrite.ForeColor = SystemColors.ControlText;
            label1label_titleWrite.Location = new Point(548, 19);
            label1label_titleWrite.Name = "label1label_titleWrite";
            label1label_titleWrite.Size = new Size(58, 23);
            label1label_titleWrite.TabIndex = 89;
            label1label_titleWrite.Text = "Write";
            // 
            // label_titleRead
            // 
            label_titleRead.AutoSize = true;
            label_titleRead.Font = new Font("微軟正黑體", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label_titleRead.ForeColor = SystemColors.ControlText;
            label_titleRead.Location = new Point(499, 19);
            label_titleRead.Name = "label_titleRead";
            label_titleRead.Size = new Size(54, 23);
            label_titleRead.TabIndex = 88;
            label_titleRead.Text = "Read";
            // 
            // label_Target_4_W
            // 
            label_Target_4_W.FlatStyle = FlatStyle.Flat;
            label_Target_4_W.ForeColor = SystemColors.Window;
            label_Target_4_W.Image = global::Multiple_Test.Properties.Resources.Yellow;
            label_Target_4_W.Location = new Point(545, 218);
            label_Target_4_W.Name = "label_Target_4_W";
            label_Target_4_W.Size = new Size(46, 43);
            label_Target_4_W.TabIndex = 84;
            label_Target_4_W.Visible = false;
            // 
            // label_Target_1_W
            // 
            label_Target_1_W.FlatStyle = FlatStyle.Flat;
            label_Target_1_W.ForeColor = SystemColors.Window;
            label_Target_1_W.Image = global::Multiple_Test.Properties.Resources.Yellow;
            label_Target_1_W.Location = new Point(545, 36);
            label_Target_1_W.Name = "label_Target_1_W";
            label_Target_1_W.Size = new Size(46, 43);
            label_Target_1_W.TabIndex = 72;
            label_Target_1_W.Visible = false;
            // 
            // label_titleProgram
            // 
            label_titleProgram.AutoSize = true;
            label_titleProgram.Font = new Font("微軟正黑體", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label_titleProgram.ForeColor = SystemColors.ControlText;
            label_titleProgram.Location = new Point(435, 19);
            label_titleProgram.Name = "label_titleProgram";
            label_titleProgram.Size = new Size(86, 23);
            label_titleProgram.TabIndex = 85;
            label_titleProgram.Text = "Program";
            // 
            // label_Target_4_R
            // 
            label_Target_4_R.FlatStyle = FlatStyle.Flat;
            label_Target_4_R.ForeColor = SystemColors.Window;
            label_Target_4_R.Image = global::Multiple_Test.Properties.Resources.Blue;
            label_Target_4_R.Location = new Point(495, 218);
            label_Target_4_R.Name = "label_Target_4_R";
            label_Target_4_R.Size = new Size(46, 43);
            label_Target_4_R.TabIndex = 83;
            label_Target_4_R.Visible = false;
            // 
            // label_Target_3_W
            // 
            label_Target_3_W.FlatStyle = FlatStyle.Flat;
            label_Target_3_W.ForeColor = SystemColors.Window;
            label_Target_3_W.Image = global::Multiple_Test.Properties.Resources.Yellow;
            label_Target_3_W.Location = new Point(545, 159);
            label_Target_3_W.Name = "label_Target_3_W";
            label_Target_3_W.Size = new Size(46, 43);
            label_Target_3_W.TabIndex = 80;
            label_Target_3_W.Visible = false;
            // 
            // label_Target_4_UnW
            // 
            label_Target_4_UnW.FlatStyle = FlatStyle.Flat;
            label_Target_4_UnW.ForeColor = SystemColors.Window;
            label_Target_4_UnW.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_4_UnW.Location = new Point(545, 218);
            label_Target_4_UnW.Name = "label_Target_4_UnW";
            label_Target_4_UnW.Size = new Size(46, 43);
            label_Target_4_UnW.TabIndex = 82;
            // 
            // label_Target_2_W
            // 
            label_Target_2_W.FlatStyle = FlatStyle.Flat;
            label_Target_2_W.ForeColor = SystemColors.Window;
            label_Target_2_W.Image = global::Multiple_Test.Properties.Resources.Yellow;
            label_Target_2_W.Location = new Point(545, 97);
            label_Target_2_W.Name = "label_Target_2_W";
            label_Target_2_W.Size = new Size(46, 43);
            label_Target_2_W.TabIndex = 76;
            label_Target_2_W.Visible = false;
            // 
            // label_Target_1_UnW
            // 
            label_Target_1_UnW.FlatStyle = FlatStyle.Flat;
            label_Target_1_UnW.ForeColor = SystemColors.Window;
            label_Target_1_UnW.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_1_UnW.Location = new Point(545, 37);
            label_Target_1_UnW.Name = "label_Target_1_UnW";
            label_Target_1_UnW.Size = new Size(46, 43);
            label_Target_1_UnW.TabIndex = 70;
            // 
            // label_Target_1_R
            // 
            label_Target_1_R.FlatStyle = FlatStyle.Flat;
            label_Target_1_R.ForeColor = SystemColors.Window;
            label_Target_1_R.Image = global::Multiple_Test.Properties.Resources.Blue;
            label_Target_1_R.Location = new Point(495, 36);
            label_Target_1_R.Name = "label_Target_1_R";
            label_Target_1_R.Size = new Size(46, 43);
            label_Target_1_R.TabIndex = 71;
            label_Target_1_R.Visible = false;
            // 
            // label_Target_4_UnR
            // 
            label_Target_4_UnR.FlatStyle = FlatStyle.Flat;
            label_Target_4_UnR.ForeColor = SystemColors.Window;
            label_Target_4_UnR.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_4_UnR.Location = new Point(495, 218);
            label_Target_4_UnR.Name = "label_Target_4_UnR";
            label_Target_4_UnR.Size = new Size(46, 43);
            label_Target_4_UnR.TabIndex = 81;
            // 
            // label_Target_1_UnR
            // 
            label_Target_1_UnR.FlatStyle = FlatStyle.Flat;
            label_Target_1_UnR.ForeColor = SystemColors.Window;
            label_Target_1_UnR.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_1_UnR.Location = new Point(495, 36);
            label_Target_1_UnR.Name = "label_Target_1_UnR";
            label_Target_1_UnR.Size = new Size(46, 43);
            label_Target_1_UnR.TabIndex = 69;
            // 
            // label_Target_4_status
            // 
            label_Target_4_status.AutoSize = true;
            label_Target_4_status.ForeColor = Color.Gray;
            label_Target_4_status.Location = new Point(6, 210);
            label_Target_4_status.Name = "label_Target_4_status";
            label_Target_4_status.Size = new Size(30, 23);
            label_Target_4_status.TabIndex = 68;
            label_Target_4_status.Text = "✅";
            // 
            // label_Target_3_UnW
            // 
            label_Target_3_UnW.FlatStyle = FlatStyle.Flat;
            label_Target_3_UnW.ForeColor = SystemColors.Window;
            label_Target_3_UnW.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_3_UnW.Location = new Point(545, 158);
            label_Target_3_UnW.Name = "label_Target_3_UnW";
            label_Target_3_UnW.Size = new Size(46, 43);
            label_Target_3_UnW.TabIndex = 78;
            // 
            // label_Target_3_R
            // 
            label_Target_3_R.FlatStyle = FlatStyle.Flat;
            label_Target_3_R.ForeColor = SystemColors.Window;
            label_Target_3_R.Image = global::Multiple_Test.Properties.Resources.Blue;
            label_Target_3_R.Location = new Point(495, 159);
            label_Target_3_R.Name = "label_Target_3_R";
            label_Target_3_R.Size = new Size(46, 43);
            label_Target_3_R.TabIndex = 79;
            label_Target_3_R.Visible = false;
            // 
            // label_Target_3_status
            // 
            label_Target_3_status.AutoSize = true;
            label_Target_3_status.ForeColor = Color.Gray;
            label_Target_3_status.Location = new Point(6, 149);
            label_Target_3_status.Name = "label_Target_3_status";
            label_Target_3_status.Size = new Size(30, 23);
            label_Target_3_status.TabIndex = 67;
            label_Target_3_status.Text = "✅";
            // 
            // label_Target_2_UnW
            // 
            label_Target_2_UnW.FlatStyle = FlatStyle.Flat;
            label_Target_2_UnW.ForeColor = SystemColors.Window;
            label_Target_2_UnW.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_2_UnW.Location = new Point(545, 97);
            label_Target_2_UnW.Name = "label_Target_2_UnW";
            label_Target_2_UnW.Size = new Size(46, 43);
            label_Target_2_UnW.TabIndex = 74;
            // 
            // label_Target_2_status
            // 
            label_Target_2_status.AutoSize = true;
            label_Target_2_status.ForeColor = Color.Gray;
            label_Target_2_status.Location = new Point(6, 88);
            label_Target_2_status.Name = "label_Target_2_status";
            label_Target_2_status.Size = new Size(30, 23);
            label_Target_2_status.TabIndex = 66;
            label_Target_2_status.Text = "✅";
            // 
            // label_Target_3_UnR
            // 
            label_Target_3_UnR.FlatStyle = FlatStyle.Flat;
            label_Target_3_UnR.ForeColor = SystemColors.Window;
            label_Target_3_UnR.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_3_UnR.Location = new Point(495, 159);
            label_Target_3_UnR.Name = "label_Target_3_UnR";
            label_Target_3_UnR.Size = new Size(46, 43);
            label_Target_3_UnR.TabIndex = 77;
            // 
            // label_Target_1_status
            // 
            label_Target_1_status.AutoSize = true;
            label_Target_1_status.ForeColor = Color.Gray;
            label_Target_1_status.Location = new Point(6, 30);
            label_Target_1_status.Name = "label_Target_1_status";
            label_Target_1_status.Size = new Size(30, 23);
            label_Target_1_status.TabIndex = 65;
            label_Target_1_status.Text = "✅";
            // 
            // label_Target_4_Red
            // 
            label_Target_4_Red.FlatStyle = FlatStyle.Flat;
            label_Target_4_Red.ForeColor = SystemColors.Window;
            label_Target_4_Red.Image = global::Multiple_Test.Properties.Resources.Red;
            label_Target_4_Red.Location = new Point(442, 218);
            label_Target_4_Red.Name = "label_Target_4_Red";
            label_Target_4_Red.Size = new Size(46, 43);
            label_Target_4_Red.TabIndex = 64;
            label_Target_4_Red.Visible = false;
            // 
            // label_Target_4_Green
            // 
            label_Target_4_Green.FlatStyle = FlatStyle.Flat;
            label_Target_4_Green.ForeColor = SystemColors.Window;
            label_Target_4_Green.Image = global::Multiple_Test.Properties.Resources.Green;
            label_Target_4_Green.Location = new Point(442, 218);
            label_Target_4_Green.Name = "label_Target_4_Green";
            label_Target_4_Green.Size = new Size(46, 43);
            label_Target_4_Green.TabIndex = 63;
            label_Target_4_Green.Visible = false;
            // 
            // label_Target_2_R
            // 
            label_Target_2_R.FlatStyle = FlatStyle.Flat;
            label_Target_2_R.ForeColor = SystemColors.Window;
            label_Target_2_R.Image = global::Multiple_Test.Properties.Resources.Blue;
            label_Target_2_R.Location = new Point(495, 97);
            label_Target_2_R.Name = "label_Target_2_R";
            label_Target_2_R.Size = new Size(46, 43);
            label_Target_2_R.TabIndex = 75;
            label_Target_2_R.Visible = false;
            // 
            // label_Target_4_BGreen
            // 
            label_Target_4_BGreen.FlatStyle = FlatStyle.Flat;
            label_Target_4_BGreen.ForeColor = SystemColors.Window;
            label_Target_4_BGreen.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_4_BGreen.Location = new Point(442, 218);
            label_Target_4_BGreen.Name = "label_Target_4_BGreen";
            label_Target_4_BGreen.Size = new Size(46, 43);
            label_Target_4_BGreen.TabIndex = 61;
            // 
            // label_Target_3_Red
            // 
            label_Target_3_Red.FlatStyle = FlatStyle.Flat;
            label_Target_3_Red.ForeColor = SystemColors.Window;
            label_Target_3_Red.Image = global::Multiple_Test.Properties.Resources.Red;
            label_Target_3_Red.Location = new Point(442, 159);
            label_Target_3_Red.Name = "label_Target_3_Red";
            label_Target_3_Red.Size = new Size(46, 43);
            label_Target_3_Red.TabIndex = 60;
            label_Target_3_Red.Visible = false;
            // 
            // label_Target_2_UnR
            // 
            label_Target_2_UnR.FlatStyle = FlatStyle.Flat;
            label_Target_2_UnR.ForeColor = SystemColors.Window;
            label_Target_2_UnR.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_2_UnR.Location = new Point(495, 97);
            label_Target_2_UnR.Name = "label_Target_2_UnR";
            label_Target_2_UnR.Size = new Size(46, 43);
            label_Target_2_UnR.TabIndex = 73;
            // 
            // label_Target_3_Green
            // 
            label_Target_3_Green.FlatStyle = FlatStyle.Flat;
            label_Target_3_Green.ForeColor = SystemColors.Window;
            label_Target_3_Green.Image = global::Multiple_Test.Properties.Resources.Green;
            label_Target_3_Green.Location = new Point(442, 159);
            label_Target_3_Green.Name = "label_Target_3_Green";
            label_Target_3_Green.Size = new Size(46, 43);
            label_Target_3_Green.TabIndex = 59;
            label_Target_3_Green.Visible = false;
            // 
            // label_Target_3_BGreen
            // 
            label_Target_3_BGreen.FlatStyle = FlatStyle.Flat;
            label_Target_3_BGreen.ForeColor = SystemColors.Window;
            label_Target_3_BGreen.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_3_BGreen.Location = new Point(442, 159);
            label_Target_3_BGreen.Name = "label_Target_3_BGreen";
            label_Target_3_BGreen.Size = new Size(46, 43);
            label_Target_3_BGreen.TabIndex = 57;
            // 
            // label_Target_2_Red
            // 
            label_Target_2_Red.FlatStyle = FlatStyle.Flat;
            label_Target_2_Red.ForeColor = SystemColors.Window;
            label_Target_2_Red.Image = global::Multiple_Test.Properties.Resources.Red;
            label_Target_2_Red.Location = new Point(442, 97);
            label_Target_2_Red.Name = "label_Target_2_Red";
            label_Target_2_Red.Size = new Size(46, 43);
            label_Target_2_Red.TabIndex = 56;
            label_Target_2_Red.Visible = false;
            // 
            // label_Target_2_Green
            // 
            label_Target_2_Green.FlatStyle = FlatStyle.Flat;
            label_Target_2_Green.ForeColor = SystemColors.Window;
            label_Target_2_Green.Image = global::Multiple_Test.Properties.Resources.Green;
            label_Target_2_Green.Location = new Point(442, 97);
            label_Target_2_Green.Name = "label_Target_2_Green";
            label_Target_2_Green.Size = new Size(46, 43);
            label_Target_2_Green.TabIndex = 55;
            label_Target_2_Green.Visible = false;
            // 
            // label_Target_2_BGreen
            // 
            label_Target_2_BGreen.FlatStyle = FlatStyle.Flat;
            label_Target_2_BGreen.ForeColor = SystemColors.Window;
            label_Target_2_BGreen.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_2_BGreen.Location = new Point(442, 97);
            label_Target_2_BGreen.Name = "label_Target_2_BGreen";
            label_Target_2_BGreen.Size = new Size(46, 43);
            label_Target_2_BGreen.TabIndex = 53;
            // 
            // label_Target_1_Red
            // 
            label_Target_1_Red.FlatStyle = FlatStyle.Flat;
            label_Target_1_Red.ForeColor = SystemColors.Window;
            label_Target_1_Red.Image = global::Multiple_Test.Properties.Resources.Red;
            label_Target_1_Red.Location = new Point(442, 36);
            label_Target_1_Red.Name = "label_Target_1_Red";
            label_Target_1_Red.Size = new Size(46, 43);
            label_Target_1_Red.TabIndex = 52;
            label_Target_1_Red.Visible = false;
            // 
            // label_Target_1_Green
            // 
            label_Target_1_Green.FlatStyle = FlatStyle.Flat;
            label_Target_1_Green.ForeColor = SystemColors.Window;
            label_Target_1_Green.Image = global::Multiple_Test.Properties.Resources.Green;
            label_Target_1_Green.Location = new Point(442, 36);
            label_Target_1_Green.Name = "label_Target_1_Green";
            label_Target_1_Green.Size = new Size(46, 43);
            label_Target_1_Green.TabIndex = 51;
            label_Target_1_Green.Visible = false;
            // 
            // label_Target_1_BGreen
            // 
            label_Target_1_BGreen.FlatStyle = FlatStyle.Flat;
            label_Target_1_BGreen.ForeColor = SystemColors.Window;
            label_Target_1_BGreen.Image = global::Multiple_Test.Properties.Resources._null;
            label_Target_1_BGreen.Location = new Point(442, 36);
            label_Target_1_BGreen.Name = "label_Target_1_BGreen";
            label_Target_1_BGreen.Size = new Size(46, 43);
            label_Target_1_BGreen.TabIndex = 43;
            // 
            // label_Target_4_Version
            // 
            label_Target_4_Version.BackColor = SystemColors.Window;
            label_Target_4_Version.BorderStyle = BorderStyle.Fixed3D;
            label_Target_4_Version.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_4_Version.ForeColor = SystemColors.ControlText;
            label_Target_4_Version.Location = new Point(135, 229);
            label_Target_4_Version.Name = "label_Target_4_Version";
            label_Target_4_Version.Size = new Size(90, 18);
            label_Target_4_Version.TabIndex = 42;
            label_Target_4_Version.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Target_4_CRC
            // 
            label_Target_4_CRC.BackColor = SystemColors.Window;
            label_Target_4_CRC.BorderStyle = BorderStyle.Fixed3D;
            label_Target_4_CRC.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_4_CRC.ForeColor = SystemColors.ControlText;
            label_Target_4_CRC.Location = new Point(325, 229);
            label_Target_4_CRC.Name = "label_Target_4_CRC";
            label_Target_4_CRC.Size = new Size(90, 18);
            label_Target_4_CRC.TabIndex = 40;
            label_Target_4_CRC.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Target_4_CRCTitle
            // 
            label_Target_4_CRCTitle.AutoSize = true;
            label_Target_4_CRCTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_4_CRCTitle.ForeColor = SystemColors.ControlText;
            label_Target_4_CRCTitle.Location = new Point(231, 230);
            label_Target_4_CRCTitle.Name = "label_Target_4_CRCTitle";
            label_Target_4_CRCTitle.Size = new Size(137, 25);
            label_Target_4_CRCTitle.TabIndex = 39;
            label_Target_4_CRCTitle.Text = "IC CRC code :";
            // 
            // label_Target_3_VersionTitle
            // 
            label_Target_3_VersionTitle.AutoSize = true;
            label_Target_3_VersionTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_3_VersionTitle.ForeColor = SystemColors.ControlText;
            label_Target_3_VersionTitle.Location = new Point(58, 169);
            label_Target_3_VersionTitle.Name = "label_Target_3_VersionTitle";
            label_Target_3_VersionTitle.Size = new Size(108, 25);
            label_Target_3_VersionTitle.TabIndex = 36;
            label_Target_3_VersionTitle.Text = "IC version:";
            // 
            // label_Target_3
            // 
            label_Target_3.AutoSize = true;
            label_Target_3.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Target_3.ForeColor = SystemColors.ControlText;
            label_Target_3.Location = new Point(31, 148);
            label_Target_3.Name = "label_Target_3";
            label_Target_3.Size = new Size(92, 25);
            label_Target_3.TabIndex = 33;
            label_Target_3.Text = "Target 3";
            // 
            // label_Target_3_Version
            // 
            label_Target_3_Version.BackColor = SystemColors.Window;
            label_Target_3_Version.BorderStyle = BorderStyle.Fixed3D;
            label_Target_3_Version.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_3_Version.ForeColor = SystemColors.ControlText;
            label_Target_3_Version.Location = new Point(135, 168);
            label_Target_3_Version.Name = "label_Target_3_Version";
            label_Target_3_Version.Size = new Size(90, 18);
            label_Target_3_Version.TabIndex = 37;
            label_Target_3_Version.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Target_3_CRC
            // 
            label_Target_3_CRC.BackColor = SystemColors.Window;
            label_Target_3_CRC.BorderStyle = BorderStyle.Fixed3D;
            label_Target_3_CRC.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_3_CRC.ForeColor = SystemColors.ControlText;
            label_Target_3_CRC.Location = new Point(325, 168);
            label_Target_3_CRC.Name = "label_Target_3_CRC";
            label_Target_3_CRC.Size = new Size(90, 18);
            label_Target_3_CRC.TabIndex = 35;
            label_Target_3_CRC.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Target_3_CRCTitle
            // 
            label_Target_3_CRCTitle.AutoSize = true;
            label_Target_3_CRCTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_3_CRCTitle.ForeColor = SystemColors.ControlText;
            label_Target_3_CRCTitle.Location = new Point(231, 169);
            label_Target_3_CRCTitle.Name = "label_Target_3_CRCTitle";
            label_Target_3_CRCTitle.Size = new Size(137, 25);
            label_Target_3_CRCTitle.TabIndex = 34;
            label_Target_3_CRCTitle.Text = "IC CRC code :";
            // 
            // label_Target_2_VersionTitle
            // 
            label_Target_2_VersionTitle.AutoSize = true;
            label_Target_2_VersionTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_2_VersionTitle.ForeColor = SystemColors.ControlText;
            label_Target_2_VersionTitle.Location = new Point(58, 108);
            label_Target_2_VersionTitle.Name = "label_Target_2_VersionTitle";
            label_Target_2_VersionTitle.Size = new Size(108, 25);
            label_Target_2_VersionTitle.TabIndex = 31;
            label_Target_2_VersionTitle.Text = "IC version:";
            // 
            // label_Target_2
            // 
            label_Target_2.AutoSize = true;
            label_Target_2.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Target_2.ForeColor = SystemColors.ControlText;
            label_Target_2.Location = new Point(31, 87);
            label_Target_2.Name = "label_Target_2";
            label_Target_2.Size = new Size(92, 25);
            label_Target_2.TabIndex = 28;
            label_Target_2.Text = "Target 2";
            // 
            // label_Target_2_Version
            // 
            label_Target_2_Version.BackColor = SystemColors.Window;
            label_Target_2_Version.BorderStyle = BorderStyle.Fixed3D;
            label_Target_2_Version.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_2_Version.ForeColor = SystemColors.ControlText;
            label_Target_2_Version.Location = new Point(135, 107);
            label_Target_2_Version.Name = "label_Target_2_Version";
            label_Target_2_Version.Size = new Size(90, 18);
            label_Target_2_Version.TabIndex = 32;
            label_Target_2_Version.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Target_2_CRC
            // 
            label_Target_2_CRC.BackColor = SystemColors.Window;
            label_Target_2_CRC.BorderStyle = BorderStyle.Fixed3D;
            label_Target_2_CRC.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_2_CRC.ForeColor = SystemColors.ControlText;
            label_Target_2_CRC.Location = new Point(325, 107);
            label_Target_2_CRC.Name = "label_Target_2_CRC";
            label_Target_2_CRC.Size = new Size(90, 18);
            label_Target_2_CRC.TabIndex = 30;
            label_Target_2_CRC.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Target_2_CRCTitle
            // 
            label_Target_2_CRCTitle.AutoSize = true;
            label_Target_2_CRCTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_2_CRCTitle.ForeColor = SystemColors.ControlText;
            label_Target_2_CRCTitle.Location = new Point(231, 108);
            label_Target_2_CRCTitle.Name = "label_Target_2_CRCTitle";
            label_Target_2_CRCTitle.Size = new Size(137, 25);
            label_Target_2_CRCTitle.TabIndex = 29;
            label_Target_2_CRCTitle.Text = "IC CRC code :";
            // 
            // label_Target_1_VersionTitle
            // 
            label_Target_1_VersionTitle.AutoSize = true;
            label_Target_1_VersionTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_1_VersionTitle.ForeColor = SystemColors.ControlText;
            label_Target_1_VersionTitle.Location = new Point(58, 50);
            label_Target_1_VersionTitle.Name = "label_Target_1_VersionTitle";
            label_Target_1_VersionTitle.Size = new Size(108, 25);
            label_Target_1_VersionTitle.TabIndex = 26;
            label_Target_1_VersionTitle.Text = "IC version:";
            // 
            // label_Target_1
            // 
            label_Target_1.AutoSize = true;
            label_Target_1.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Target_1.ForeColor = SystemColors.ControlText;
            label_Target_1.Location = new Point(31, 29);
            label_Target_1.Name = "label_Target_1";
            label_Target_1.Size = new Size(92, 25);
            label_Target_1.TabIndex = 0;
            label_Target_1.Text = "Target 1";
            // 
            // label_Target_1_Version
            // 
            label_Target_1_Version.BackColor = SystemColors.Window;
            label_Target_1_Version.BorderStyle = BorderStyle.Fixed3D;
            label_Target_1_Version.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_1_Version.ForeColor = SystemColors.ControlText;
            label_Target_1_Version.Location = new Point(135, 49);
            label_Target_1_Version.Name = "label_Target_1_Version";
            label_Target_1_Version.Size = new Size(90, 18);
            label_Target_1_Version.TabIndex = 27;
            label_Target_1_Version.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Target_1_CRC
            // 
            label_Target_1_CRC.BackColor = SystemColors.Window;
            label_Target_1_CRC.BorderStyle = BorderStyle.Fixed3D;
            label_Target_1_CRC.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_1_CRC.ForeColor = SystemColors.ControlText;
            label_Target_1_CRC.Location = new Point(325, 49);
            label_Target_1_CRC.Name = "label_Target_1_CRC";
            label_Target_1_CRC.Size = new Size(90, 18);
            label_Target_1_CRC.TabIndex = 25;
            label_Target_1_CRC.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Target_1_CRCTitle
            // 
            label_Target_1_CRCTitle.AutoSize = true;
            label_Target_1_CRCTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Target_1_CRCTitle.ForeColor = SystemColors.ControlText;
            label_Target_1_CRCTitle.Location = new Point(231, 50);
            label_Target_1_CRCTitle.Name = "label_Target_1_CRCTitle";
            label_Target_1_CRCTitle.Size = new Size(137, 25);
            label_Target_1_CRCTitle.TabIndex = 24;
            label_Target_1_CRCTitle.Text = "IC CRC code :";
            // 
            // btn_clearLogs
            // 
            btn_clearLogs.Cursor = Cursors.Hand;
            btn_clearLogs.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_clearLogs.Location = new Point(1049, 395);
            btn_clearLogs.Margin = new Padding(3, 2, 3, 2);
            btn_clearLogs.Name = "btn_clearLogs";
            btn_clearLogs.Size = new Size(80, 25);
            btn_clearLogs.TabIndex = 20;
            btn_clearLogs.Text = "Clear logs";
            btn_clearLogs.UseVisualStyleBackColor = true;
            btn_clearLogs.Click += btn_clearLogs_Click;
            // 
            // groupBox_minFile
            // 
            groupBox_minFile.Controls.Add(label_mifVersionTitle);
            groupBox_minFile.Controls.Add(label_mifVersion);
            groupBox_minFile.Controls.Add(labOpenReadMinFile);
            groupBox_minFile.Controls.Add(label_mifCRCTitle);
            groupBox_minFile.Controls.Add(btn_OpenReadMinFile);
            groupBox_minFile.Controls.Add(label_mifCRC);
            groupBox_minFile.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox_minFile.ForeColor = Color.Blue;
            groupBox_minFile.Location = new Point(11, 26);
            groupBox_minFile.Margin = new Padding(3, 2, 3, 2);
            groupBox_minFile.Name = "groupBox_minFile";
            groupBox_minFile.Padding = new Padding(3, 2, 3, 2);
            groupBox_minFile.Size = new Size(593, 76);
            groupBox_minFile.TabIndex = 18;
            groupBox_minFile.TabStop = false;
            groupBox_minFile.Text = "Laod configure from .MIF";
            // 
            // labOpenReadMinFile
            // 
            labOpenReadMinFile.BackColor = SystemColors.Control;
            labOpenReadMinFile.BorderStyle = BorderStyle.Fixed3D;
            labOpenReadMinFile.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labOpenReadMinFile.ForeColor = SystemColors.ControlText;
            labOpenReadMinFile.Location = new Point(94, 24);
            labOpenReadMinFile.Name = "labOpenReadMinFile";
            labOpenReadMinFile.Size = new Size(493, 18);
            labOpenReadMinFile.TabIndex = 18;
            labOpenReadMinFile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_mifCRCTitle
            // 
            label_mifCRCTitle.AutoSize = true;
            label_mifCRCTitle.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_mifCRCTitle.ForeColor = SystemColors.ControlText;
            label_mifCRCTitle.Location = new Point(419, 50);
            label_mifCRCTitle.Name = "label_mifCRCTitle";
            label_mifCRCTitle.Size = new Size(113, 25);
            label_mifCRCTitle.TabIndex = 12;
            label_mifCRCTitle.Text = "CRC code :";
            // 
            // btn_OpenReadMinFile
            // 
            btn_OpenReadMinFile.Cursor = Cursors.Hand;
            btn_OpenReadMinFile.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_OpenReadMinFile.ForeColor = SystemColors.ControlText;
            btn_OpenReadMinFile.Location = new Point(11, 20);
            btn_OpenReadMinFile.Margin = new Padding(3, 2, 3, 2);
            btn_OpenReadMinFile.Name = "btn_OpenReadMinFile";
            btn_OpenReadMinFile.Size = new Size(77, 24);
            btn_OpenReadMinFile.TabIndex = 10;
            btn_OpenReadMinFile.Text = "Load .MIF";
            btn_OpenReadMinFile.UseVisualStyleBackColor = true;
            btn_OpenReadMinFile.Click += btn_OpenReadMinFile_Click;
            // 
            // label_mifCRC
            // 
            label_mifCRC.BackColor = SystemColors.Window;
            label_mifCRC.BorderStyle = BorderStyle.Fixed3D;
            label_mifCRC.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_mifCRC.ForeColor = Color.Red;
            label_mifCRC.Location = new Point(497, 49);
            label_mifCRC.Name = "label_mifCRC";
            label_mifCRC.Size = new Size(90, 18);
            label_mifCRC.TabIndex = 13;
            label_mifCRC.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage_1to4);
            tabControl1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.Location = new Point(6, 85);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1150, 453);
            tabControl1.TabIndex = 27;
            // 
            // label_LogoTitle
            // 
            label_LogoTitle.Font = new Font("Microsoft JhengHei UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_LogoTitle.Location = new Point(0, 2);
            label_LogoTitle.Name = "label_LogoTitle";
            label_LogoTitle.Size = new Size(986, 81);
            label_LogoTitle.TabIndex = 2;
            label_LogoTitle.Text = "光寶-長安 OP-Katakuri NXP TEA2376 4CH Programer";
            label_LogoTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // USBCheckTimer
            // 
            USBCheckTimer.Enabled = true;
            USBCheckTimer.Interval = 1000;
            USBCheckTimer.Tick += USBCheckTimer_Tick;
            // 
            // label_WPIgLogo
            // 
            label_WPIgLogo.FlatStyle = FlatStyle.Flat;
            label_WPIgLogo.ForeColor = SystemColors.Window;
            label_WPIgLogo.Image = global::Multiple_Test.Properties.Resources.WPIg;
            label_WPIgLogo.Location = new Point(992, 21);
            label_WPIgLogo.Name = "label_WPIgLogo";
            label_WPIgLogo.Size = new Size(160, 62);
            label_WPIgLogo.TabIndex = 30;
            // 
            // label_USBconnection
            // 
            label_USBconnection.AutoSize = true;
            label_USBconnection.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_USBconnection.Location = new Point(11, 545);
            label_USBconnection.Name = "label_USBconnection";
            label_USBconnection.Size = new Size(180, 25);
            label_USBconnection.TabIndex = 28;
            label_USBconnection.Text = "USB Connection :";
            // 
            // label_Connected
            // 
            label_Connected.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Connected.ForeColor = SystemColors.ControlText;
            label_Connected.Location = new Point(129, 545);
            label_Connected.Name = "label_Connected";
            label_Connected.Size = new Size(83, 20);
            label_Connected.TabIndex = 29;
            label_Connected.Text = "-";
            // 
            // label_fwVerstion
            // 
            label_fwVerstion.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_fwVerstion.ForeColor = SystemColors.ControlText;
            label_fwVerstion.Location = new Point(218, 544);
            label_fwVerstion.Name = "label_fwVerstion";
            label_fwVerstion.Size = new Size(396, 20);
            label_fwVerstion.TabIndex = 32;
            label_fwVerstion.Text = "FW Verstion : -";
            label_fwVerstion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormGUI
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1165, 570);
            Controls.Add(label_fwVerstion);
            Controls.Add(label_Connected);
            Controls.Add(label_WPIgLogo);
            Controls.Add(label_USBconnection);
            Controls.Add(tabControl1);
            Controls.Add(label_LogoTitle);
            Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OP-Katakuri NXP TEA2376 4CH Programer";
            Load += FormGUI_Load;
            tabPage_1to4.ResumeLayout(false);
            tabPage_1to4.PerformLayout();
            groupBox_Target.ResumeLayout(false);
            groupBox_Target.PerformLayout();
            groupBox_minFile.ResumeLayout(false);
            groupBox_minFile.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
    }
}
