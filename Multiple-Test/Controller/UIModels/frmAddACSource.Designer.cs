using Multiple_Test.Models.Command;
using Multiple_Test.Service.ACSource;
using Multiple_Test.Service.GPIB;
using Sunny.UI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Multiple_Test.Controller.UIModels
{
    partial class frmAddACSource
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码
        private readonly AC_Source_Service cmd = new AC_Source_Service();
        public List<entityChildNodeCommand> result_Entity = new List<entityChildNodeCommand>();

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.btnDebugger = new Sunny.UI.UISymbolButton();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.labTryCount = new System.Windows.Forms.Label();
            this.txtTryCount = new Sunny.UI.UIIntegerUpDown();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLine8 = new Sunny.UI.UILine();
            this.btnOff = new Sunny.UI.UIRadioButton();
            this.btnON = new Sunny.UI.UIRadioButton();
            this.txtFreqVlaue = new Sunny.UI.UITextBox();
            this.txtVoltValue = new Sunny.UI.UITextBox();
            this.btnselectFrequency = new Sunny.UI.UICheckBox();
            this.btnselectVoltage = new Sunny.UI.UICheckBox();
            this.btnRefresh = new Sunny.UI.UISymbolButton();
            this.txtAddress = new Sunny.UI.UITextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGPIBName = new Sunny.UI.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.LogLine = new Sunny.UI.UILine();
            this.btnAdd = new Sunny.UI.UISymbolButton();
            this.btnCancel = new Sunny.UI.UISymbolButton();
            this.uiTreeView1 = new Sunny.UI.UITreeView();
            this.uiPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Controls.Add(this.btnDebugger);
            this.uiPanel1.Controls.Add(this.uiGroupBox1);
            this.uiPanel1.Controls.Add(this.btnRefresh);
            this.uiPanel1.Controls.Add(this.txtAddress);
            this.uiPanel1.Controls.Add(this.label2);
            this.uiPanel1.Controls.Add(this.txtGPIBName);
            this.uiPanel1.Controls.Add(this.label1);
            this.uiPanel1.Controls.Add(this.pictureBox1);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(278, 40);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(780, 548);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 1;
            this.uiPanel1.Text = null;
            // 
            // btnDebugger
            // 
            this.btnDebugger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDebugger.Font = new System.Drawing.Font("宋体", 12F);
            this.btnDebugger.Location = new System.Drawing.Point(55, 3);
            this.btnDebugger.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDebugger.Name = "btnDebugger";
            this.btnDebugger.RadiusSides = ((Sunny.UI.UICornerRadiusSides)((Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom)));
            this.btnDebugger.Size = new System.Drawing.Size(46, 35);
            this.btnDebugger.Style = Sunny.UI.UIStyle.Custom;
            this.btnDebugger.Symbol = 61515;
            this.btnDebugger.TabIndex = 107;
            this.btnDebugger.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDebugger.Click += new System.EventHandler(this.btnDebugger_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.labTryCount);
            this.uiGroupBox1.Controls.Add(this.txtTryCount);
            this.uiGroupBox1.Controls.Add(this.uiLine2);
            this.uiGroupBox1.Controls.Add(this.uiLine1);
            this.uiGroupBox1.Controls.Add(this.uiLine8);
            this.uiGroupBox1.Controls.Add(this.btnOff);
            this.uiGroupBox1.Controls.Add(this.btnON);
            this.uiGroupBox1.Controls.Add(this.txtFreqVlaue);
            this.uiGroupBox1.Controls.Add(this.txtVoltValue);
            this.uiGroupBox1.Controls.Add(this.btnselectFrequency);
            this.uiGroupBox1.Controls.Add(this.btnselectVoltage);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(9, 149);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(757, 394);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 105;
            this.uiGroupBox1.Text = "Select Function";
            // 
            // labTryCount
            // 
            this.labTryCount.AutoSize = true;
            this.labTryCount.Location = new System.Drawing.Point(7, 228);
            this.labTryCount.Name = "labTryCount";
            this.labTryCount.Size = new System.Drawing.Size(84, 21);
            this.labTryCount.TabIndex = 68;
            this.labTryCount.Text = "TryCount:";
            // 
            // txtTryCount
            // 
            this.txtTryCount.Font = new System.Drawing.Font("宋体", 12F);
            this.txtTryCount.Location = new System.Drawing.Point(96, 223);
            this.txtTryCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTryCount.Maximum = 10;
            this.txtTryCount.Minimum = 1;
            this.txtTryCount.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtTryCount.Name = "txtTryCount";
            this.txtTryCount.Size = new System.Drawing.Size(150, 29);
            this.txtTryCount.Style = Sunny.UI.UIStyle.Custom;
            this.txtTryCount.TabIndex = 67;
            this.txtTryCount.Text = "_uiIntegerUpDown1";
            this.txtTryCount.Value = 1;
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine2.Location = new System.Drawing.Point(11, 194);
            this.uiLine2.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(741, 20);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.TabIndex = 65;
            this.uiLine2.Text = "Setting Try Count";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine1.Location = new System.Drawing.Point(13, 136);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(741, 20);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 64;
            this.uiLine1.Text = "Set Equipment Open Status?";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine8
            // 
            this.uiLine8.BackColor = System.Drawing.Color.Transparent;
            this.uiLine8.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine8.Location = new System.Drawing.Point(11, 26);
            this.uiLine8.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine8.Name = "uiLine8";
            this.uiLine8.Size = new System.Drawing.Size(743, 20);
            this.uiLine8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine8.TabIndex = 63;
            this.uiLine8.Text = "Set Voltage and Frequency";
            this.uiLine8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOff
            // 
            this.btnOff.Checked = true;
            this.btnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOff.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOff.Location = new System.Drawing.Point(169, 159);
            this.btnOff.Name = "btnOff";
            this.btnOff.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnOff.Size = new System.Drawing.Size(150, 29);
            this.btnOff.Style = Sunny.UI.UIStyle.Custom;
            this.btnOff.TabIndex = 8;
            this.btnOff.Text = "Output OFF";
            // 
            // btnON
            // 
            this.btnON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnON.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnON.Location = new System.Drawing.Point(13, 159);
            this.btnON.Name = "btnON";
            this.btnON.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnON.Size = new System.Drawing.Size(150, 29);
            this.btnON.Style = Sunny.UI.UIStyle.Custom;
            this.btnON.TabIndex = 7;
            this.btnON.Text = "Output ON";
            // 
            // txtFreqVlaue
            // 
            this.txtFreqVlaue.CanEmpty = true;
            this.txtFreqVlaue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFreqVlaue.DoubleValue = 60D;
            this.txtFreqVlaue.FillColor = System.Drawing.Color.White;
            this.txtFreqVlaue.Font = new System.Drawing.Font("宋体", 12F);
            this.txtFreqVlaue.Location = new System.Drawing.Point(128, 101);
            this.txtFreqVlaue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFreqVlaue.Maximum = 2147483647D;
            this.txtFreqVlaue.Minimum = -2147483648D;
            this.txtFreqVlaue.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtFreqVlaue.Name = "txtFreqVlaue";
            this.txtFreqVlaue.Padding = new System.Windows.Forms.Padding(5);
            this.txtFreqVlaue.Size = new System.Drawing.Size(221, 26);
            this.txtFreqVlaue.Style = Sunny.UI.UIStyle.Custom;
            this.txtFreqVlaue.TabIndex = 6;
            this.txtFreqVlaue.Text = "60.00";
            this.txtFreqVlaue.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtFreqVlaue.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtFreqVlaue.Watermark = "Please input value";
            // 
            // txtVoltValue
            // 
            this.txtVoltValue.CanEmpty = true;
            this.txtVoltValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVoltValue.DoubleValue = 110D;
            this.txtVoltValue.FillColor = System.Drawing.Color.White;
            this.txtVoltValue.Font = new System.Drawing.Font("宋体", 12F);
            this.txtVoltValue.Location = new System.Drawing.Point(128, 54);
            this.txtVoltValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVoltValue.Maximum = 2147483647D;
            this.txtVoltValue.Minimum = -2147483648D;
            this.txtVoltValue.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtVoltValue.Name = "txtVoltValue";
            this.txtVoltValue.Padding = new System.Windows.Forms.Padding(5);
            this.txtVoltValue.Size = new System.Drawing.Size(221, 26);
            this.txtVoltValue.Style = Sunny.UI.UIStyle.Custom;
            this.txtVoltValue.TabIndex = 5;
            this.txtVoltValue.Text = "110.00";
            this.txtVoltValue.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtVoltValue.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.txtVoltValue.Watermark = "Please input value";
            // 
            // btnselectFrequency
            // 
            this.btnselectFrequency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnselectFrequency.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnselectFrequency.Location = new System.Drawing.Point(13, 101);
            this.btnselectFrequency.Name = "btnselectFrequency";
            this.btnselectFrequency.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnselectFrequency.Size = new System.Drawing.Size(150, 29);
            this.btnselectFrequency.Style = Sunny.UI.UIStyle.Custom;
            this.btnselectFrequency.TabIndex = 1;
            this.btnselectFrequency.Text = "Frequency";
            // 
            // btnselectVoltage
            // 
            this.btnselectVoltage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnselectVoltage.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnselectVoltage.Location = new System.Drawing.Point(13, 51);
            this.btnselectVoltage.Name = "btnselectVoltage";
            this.btnselectVoltage.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnselectVoltage.Size = new System.Drawing.Size(150, 29);
            this.btnselectVoltage.Style = Sunny.UI.UIStyle.Custom;
            this.btnselectVoltage.TabIndex = 0;
            this.btnselectVoltage.Text = "Voltage";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 12F);
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RadiusSides = ((Sunny.UI.UICornerRadiusSides)((Sunny.UI.UICornerRadiusSides.RightTop | Sunny.UI.UICornerRadiusSides.RightBottom)));
            this.btnRefresh.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.btnRefresh.Size = new System.Drawing.Size(46, 35);
            this.btnRefresh.Style = Sunny.UI.UIStyle.Custom;
            this.btnRefresh.Symbol = 61473;
            this.btnRefresh.TabIndex = 104;
            this.btnRefresh.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.FillColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.Location = new System.Drawing.Point(93, 78);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Maximum = 2147483647D;
            this.txtAddress.Minimum = -2147483648D;
            this.txtAddress.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new System.Windows.Forms.Padding(5);
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(221, 26);
            this.txtAddress.Style = Sunny.UI.UIStyle.Custom;
            this.txtAddress.TabIndex = 5;
            this.txtAddress.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAddress.Watermark = "address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address:";
            // 
            // txtGPIBName
            // 
            this.txtGPIBName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGPIBName.FillColor = System.Drawing.Color.White;
            this.txtGPIBName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGPIBName.Location = new System.Drawing.Point(93, 42);
            this.txtGPIBName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGPIBName.Maximum = 2147483647D;
            this.txtGPIBName.Minimum = -2147483648D;
            this.txtGPIBName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtGPIBName.Name = "txtGPIBName";
            this.txtGPIBName.Padding = new System.Windows.Forms.Padding(5);
            this.txtGPIBName.ReadOnly = true;
            this.txtGPIBName.Size = new System.Drawing.Size(221, 26);
            this.txtGPIBName.Style = Sunny.UI.UIStyle.Custom;
            this.txtGPIBName.TabIndex = 3;
            this.txtGPIBName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtGPIBName.Watermark = "GPIB名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Multiple_Test.Properties.Resources._4eea394a63b627b39d2141059ebc38b;
            this.pictureBox1.Location = new System.Drawing.Point(568, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.LogLine);
            this.uiPanel2.Controls.Add(this.btnAdd);
            this.uiPanel2.Controls.Add(this.btnCancel);
            this.uiPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiPanel2.Location = new System.Drawing.Point(0, 598);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(1062, 62);
            this.uiPanel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel2.TabIndex = 2;
            this.uiPanel2.Text = null;
            // 
            // LogLine
            // 
            this.LogLine.BackColor = System.Drawing.Color.Transparent;
            this.LogLine.Font = new System.Drawing.Font("宋体", 12F);
            this.LogLine.Location = new System.Drawing.Point(3, 20);
            this.LogLine.MinimumSize = new System.Drawing.Size(16, 16);
            this.LogLine.Name = "LogLine";
            this.LogLine.Size = new System.Drawing.Size(822, 20);
            this.LogLine.Style = Sunny.UI.UIStyle.Custom;
            this.LogLine.TabIndex = 109;
            this.LogLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("宋体", 12F);
            this.btnAdd.Location = new System.Drawing.Point(955, 14);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.Style = Sunny.UI.UIStyle.Custom;
            this.btnAdd.StyleCustomMode = true;
            this.btnAdd.TabIndex = 108;
            this.btnAdd.Text = "OK";
            this.btnAdd.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnCancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F);
            this.btnCancel.Location = new System.Drawing.Point(831, 14);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnCancel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Style = Sunny.UI.UIStyle.Custom;
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.Symbol = 61453;
            this.btnCancel.TabIndex = 107;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Click += new System.EventHandler(this.uiSymbolButton2_Click);
            // 
            // uiTreeView1
            // 
            this.uiTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiTreeView1.FillColor = System.Drawing.Color.White;
            this.uiTreeView1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTreeView1.Location = new System.Drawing.Point(0, 35);
            this.uiTreeView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTreeView1.Name = "uiTreeView1";
            this.uiTreeView1.SelectedNode = null;
            this.uiTreeView1.Size = new System.Drawing.Size(270, 563);
            this.uiTreeView1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTreeView1.TabIndex = 3;
            this.uiTreeView1.Text = "uiTreeView1";
            // 
            // frmAddACSourse
            // 
            this.ClientSize = new System.Drawing.Size(1062, 660);
            this.Controls.Add(this.uiTreeView1);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddACSourse";
            this.RectColor = System.Drawing.Color.DodgerBlue;
            this.ShowInTaskbar = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "AC Sourse";
            this.TopMost = true;
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UIPanel uiPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UITextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private UITextBox txtGPIBName;
        private System.Windows.Forms.Label label1;
        private UISymbolButton btnRefresh;
        private UIPanel uiPanel2;
        private UISymbolButton btnAdd;
        private UITreeView uiTreeView1;
        private UIGroupBox uiGroupBox1;
        private UICheckBox btnselectFrequency;
        private UICheckBox btnselectVoltage;
        private UITextBox txtFreqVlaue;
        private UITextBox txtVoltValue;
        private UIRadioButton btnOff;
        private UIRadioButton btnON;
        private UILine uiLine1;
        private UILine uiLine8;
        private UISymbolButton btnDebugger;
        private UISymbolButton btnCancel;
        private UILine LogLine;
        private UIIntegerUpDown txtTryCount;
        private UILine uiLine2;
        private Label labTryCount;
    }
}
