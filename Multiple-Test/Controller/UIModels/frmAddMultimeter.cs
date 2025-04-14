#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Controller.UIModels
 * 唯一标识：ee9b74ba-8a31-4fe5-840b-de56245945df
 * 文件名：frmAddACSourse
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/15 17:22:00
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/15 17:22:00
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>

using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Controller.UIModels
{
    public class frmAddMultimeter : UIForm
    {
        private UIPanel uiPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UITextBox uiTextBox1;
        private System.Windows.Forms.Label label2;
        private UITextBox uiTextBox6;
        private System.Windows.Forms.Label label1;
        private UISymbolButton uiSymbolButton24;
        private UIPanel uiPanel2;
        private UISymbolButton uiSymbolButton1;
        private UITreeView uiTreeView1;
        private UIGroupBox uiGroupBox1;
        private UIComboBox uiComboBox4;
        private System.Windows.Forms.Label label3;
        private UILine uiLine8;
        private System.Windows.Forms.Label label4;
        private UITextBox uiTextBox3;
        private UILine uiLine1;
        private UIRadioButton uiRadioButton2;
        private UIRadioButton uiRadioButton1;
        private UISymbolButton uiSymbolButton18;
        private UISymbolButton uiSymbolButton2;

        public frmAddMultimeter()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.uiSymbolButton18 = new Sunny.UI.UISymbolButton();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiRadioButton2 = new Sunny.UI.UIRadioButton();
            this.uiRadioButton1 = new Sunny.UI.UIRadioButton();
            this.uiTextBox3 = new Sunny.UI.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiLine8 = new Sunny.UI.UILine();
            this.label3 = new System.Windows.Forms.Label();
            this.uiComboBox4 = new Sunny.UI.UIComboBox();
            this.uiSymbolButton24 = new Sunny.UI.UISymbolButton();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiTextBox6 = new Sunny.UI.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
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
            this.uiPanel1.Controls.Add(this.uiSymbolButton18);
            this.uiPanel1.Controls.Add(this.uiGroupBox1);
            this.uiPanel1.Controls.Add(this.uiSymbolButton24);
            this.uiPanel1.Controls.Add(this.uiTextBox1);
            this.uiPanel1.Controls.Add(this.label2);
            this.uiPanel1.Controls.Add(this.uiTextBox6);
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
            // uiSymbolButton18
            // 
            this.uiSymbolButton18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton18.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSymbolButton18.Location = new System.Drawing.Point(55, 3);
            this.uiSymbolButton18.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton18.Name = "uiSymbolButton18";
            this.uiSymbolButton18.RadiusSides = ((Sunny.UI.UICornerRadiusSides)((Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom)));
            this.uiSymbolButton18.Size = new System.Drawing.Size(46, 35);
            this.uiSymbolButton18.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton18.Symbol = 61515;
            this.uiSymbolButton18.TabIndex = 106;
            this.uiSymbolButton18.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiLine1);
            this.uiGroupBox1.Controls.Add(this.uiRadioButton2);
            this.uiGroupBox1.Controls.Add(this.uiRadioButton1);
            this.uiGroupBox1.Controls.Add(this.uiTextBox3);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.uiLine8);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.uiComboBox4);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(9, 149);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(767, 394);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 105;
            this.uiGroupBox1.Text = "Select Function";
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine1.Location = new System.Drawing.Point(15, 337);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(741, 20);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 83;
            this.uiLine1.Text = "Set Equipment Open Status?";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRadioButton2
            // 
            this.uiRadioButton2.Checked = true;
            this.uiRadioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiRadioButton2.Location = new System.Drawing.Point(171, 360);
            this.uiRadioButton2.Name = "uiRadioButton2";
            this.uiRadioButton2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton2.Size = new System.Drawing.Size(150, 29);
            this.uiRadioButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButton2.TabIndex = 82;
            this.uiRadioButton2.Text = "Load OFF";
            // 
            // uiRadioButton1
            // 
            this.uiRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiRadioButton1.Location = new System.Drawing.Point(15, 360);
            this.uiRadioButton1.Name = "uiRadioButton1";
            this.uiRadioButton1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButton1.Size = new System.Drawing.Size(150, 29);
            this.uiRadioButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButton1.TabIndex = 81;
            this.uiRadioButton1.Text = "Load ON";
            // 
            // uiTextBox3
            // 
            this.uiTextBox3.CanEmpty = true;
            this.uiTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox3.FillColor = System.Drawing.Color.White;
            this.uiTextBox3.Font = new System.Drawing.Font("宋体", 12F);
            this.uiTextBox3.Location = new System.Drawing.Point(90, 113);
            this.uiTextBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox3.Maximum = 2147483647D;
            this.uiTextBox3.Minimum = -2147483648D;
            this.uiTextBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox3.Name = "uiTextBox3";
            this.uiTextBox3.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox3.Size = new System.Drawing.Size(221, 26);
            this.uiTextBox3.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox3.TabIndex = 80;
            this.uiTextBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox3.Type = Sunny.UI.UITextBox.UIEditType.Double;
            this.uiTextBox3.Watermark = "Please input value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 79;
            this.label4.Text = "Current:";
            // 
            // uiLine8
            // 
            this.uiLine8.BackColor = System.Drawing.Color.Transparent;
            this.uiLine8.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine8.Location = new System.Drawing.Point(13, 85);
            this.uiLine8.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine8.Name = "uiLine8";
            this.uiLine8.Size = new System.Drawing.Size(743, 20);
            this.uiLine8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine8.TabIndex = 78;
            this.uiLine8.Text = "Set Current";
            this.uiLine8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 77;
            this.label3.Text = "Model";
            // 
            // uiComboBox4
            // 
            this.uiComboBox4.FillColor = System.Drawing.Color.White;
            this.uiComboBox4.Font = new System.Drawing.Font("宋体", 12F);
            this.uiComboBox4.Items.AddRange(new object[] {
            "CCL",
            "CCH",
            "CCDL",
            "CCDH",
            "CRL",
            "CRH",
            "CRDL",
            "CRDH",
            "CPL",
            "CPH",
            "CPDL",
            "CPDH",
            "CZL",
            "CZH",
            "CZDL",
            "CZDH"});
            this.uiComboBox4.Location = new System.Drawing.Point(73, 37);
            this.uiComboBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox4.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox4.Name = "uiComboBox4";
            this.uiComboBox4.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.uiComboBox4.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiComboBox4.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.uiComboBox4.Size = new System.Drawing.Size(150, 26);
            this.uiComboBox4.Style = Sunny.UI.UIStyle.Custom;
            this.uiComboBox4.TabIndex = 76;
            this.uiComboBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox4.Watermark = "Set Model";
            // 
            // uiSymbolButton24
            // 
            this.uiSymbolButton24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton24.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSymbolButton24.Location = new System.Drawing.Point(3, 3);
            this.uiSymbolButton24.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton24.Name = "uiSymbolButton24";
            this.uiSymbolButton24.RadiusSides = ((Sunny.UI.UICornerRadiusSides)((Sunny.UI.UICornerRadiusSides.RightTop | Sunny.UI.UICornerRadiusSides.RightBottom)));
            this.uiSymbolButton24.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.uiSymbolButton24.Size = new System.Drawing.Size(46, 35);
            this.uiSymbolButton24.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton24.Symbol = 61473;
            this.uiSymbolButton24.TabIndex = 104;
            this.uiSymbolButton24.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillColor = System.Drawing.Color.White;
            this.uiTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox1.Location = new System.Drawing.Point(81, 77);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.Maximum = 2147483647D;
            this.uiTextBox1.Minimum = -2147483648D;
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.Size = new System.Drawing.Size(221, 26);
            this.uiTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox1.TabIndex = 5;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address";
            // 
            // uiTextBox6
            // 
            this.uiTextBox6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox6.FillColor = System.Drawing.Color.White;
            this.uiTextBox6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox6.Location = new System.Drawing.Point(81, 41);
            this.uiTextBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox6.Maximum = 2147483647D;
            this.uiTextBox6.Minimum = -2147483648D;
            this.uiTextBox6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTextBox6.Name = "uiTextBox6";
            this.uiTextBox6.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox6.Size = new System.Drawing.Size(221, 26);
            this.uiTextBox6.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox6.TabIndex = 3;
            this.uiTextBox6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox6.Watermark = "GPIB名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Multiple_Test.Properties.Resources.b950ba61e18cbb27cb06e8ae213d1f9;
            this.pictureBox1.Location = new System.Drawing.Point(564, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.uiSymbolButton1);
            this.uiPanel2.Controls.Add(this.uiSymbolButton2);
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
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSymbolButton1.Location = new System.Drawing.Point(954, 15);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.StyleCustomMode = true;
            this.uiSymbolButton1.TabIndex = 108;
            this.uiSymbolButton1.Text = "OK";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton2.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSymbolButton2.Location = new System.Drawing.Point(830, 15);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton2.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton2.StyleCustomMode = true;
            this.uiSymbolButton2.Symbol = 61453;
            this.uiSymbolButton2.TabIndex = 107;
            this.uiSymbolButton2.Text = "Cancel";
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.Click += new System.EventHandler(this.uiSymbolButton2_Click);
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
            // frmAddMultimeter
            // 
            this.ClientSize = new System.Drawing.Size(1062, 660);
            this.Controls.Add(this.uiTreeView1);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddMultimeter";
            this.RectColor = System.Drawing.Color.DodgerBlue;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "Multimeter";
            this.TopMost = true;
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
