using Multiple_Test.Controller.STM32;
using Multiple_Test.Service.Buttons;
using System;

namespace Multiple_Test.Controller.Home
{
    partial class FrmMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaster));
            this.btnDearting = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiButton5 = new Sunny.UI.UIButton();
            this.btnStm32Download = new Sunny.UI.UIHeaderButton();
            this.btnStm32Verify = new Sunny.UI.UIHeaderButton();
            this.uiHeaderButton2 = new Sunny.UI.UIHeaderButton();
            this.uiLine2 = new Sunny.UI.UILine();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiLine3 = new Sunny.UI.UILine();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.btnSemiAutomatic = new Sunny.UI.UIButton();
            this.btnFWDownloadAutoScan = new Sunny.UI.UIHeaderButton();
            this.btnFWDownloadAutoScan_PCI7230 = new Sunny.UI.UIHeaderButton();
            this.btnNXP_TEA2376 = new Sunny.UI.UIHeaderButton();
            this.SuspendLayout();
            // 
            // btnDearting
            // 
            this.btnDearting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDearting.FillColor = System.Drawing.SystemColors.Highlight;
            this.btnDearting.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnDearting.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnDearting.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnDearting.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnDearting.Location = new System.Drawing.Point(216, 130);
            this.btnDearting.Margin = new System.Windows.Forms.Padding(2);
            this.btnDearting.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDearting.Name = "btnDearting";
            this.btnDearting.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnDearting.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnDearting.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnDearting.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnDearting.Size = new System.Drawing.Size(224, 80);
            this.btnDearting.Style = Sunny.UI.UIStyle.Custom;
            this.btnDearting.TabIndex = 0;
            this.btnDearting.Text = "Derating(DQE)";
            this.btnDearting.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDearting.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.uiButton2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.uiButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(97)))), ((int)(((byte)(198)))));
            this.uiButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.uiButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton2.Location = new System.Drawing.Point(730, 130);
            this.uiButton2.Margin = new System.Windows.Forms.Padding(2);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.uiButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(97)))), ((int)(((byte)(198)))));
            this.uiButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.uiButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.uiButton2.Size = new System.Drawing.Size(224, 80);
            this.uiButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton2.TabIndex = 1;
            this.uiButton2.Text = "Thermal Test System";
            this.uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiButton5
            // 
            this.uiButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton5.FillColor = System.Drawing.Color.Lime;
            this.uiButton5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton5.ForeColor = System.Drawing.Color.BlueViolet;
            this.uiButton5.ForeDisableColor = System.Drawing.Color.Blue;
            this.uiButton5.Location = new System.Drawing.Point(216, 279);
            this.uiButton5.Margin = new System.Windows.Forms.Padding(2);
            this.uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton5.Name = "uiButton5";
            this.uiButton5.RectColor = System.Drawing.Color.Red;
            this.uiButton5.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uiButton5.Size = new System.Drawing.Size(224, 80);
            this.uiButton5.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton5.TabIndex = 4;
            this.uiButton5.Text = "自动控制版\rHIPOT (IQC)\rChroma 19053~19054";
            this.uiButton5.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton5.TipsForeColor = System.Drawing.Color.Black;
            this.uiButton5.Click += new System.EventHandler(this.uiButton5_Click);
            // 
            // btnStm32Download
            // 
            this.btnStm32Download.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnStm32Download.CircleHoverColor = System.Drawing.Color.BlanchedAlmond;
            this.btnStm32Download.CircleSize = 60;
            this.btnStm32Download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStm32Download.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnStm32Download.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnStm32Download.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnStm32Download.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnStm32Download.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnStm32Download.Font = new System.Drawing.Font("宋体", 22F);
            this.btnStm32Download.Location = new System.Drawing.Point(44, 475);
            this.btnStm32Download.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStm32Download.Name = "btnStm32Download";
            this.btnStm32Download.Padding = new System.Windows.Forms.Padding(6);
            this.btnStm32Download.Radius = 12;
            this.btnStm32Download.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop;
            this.btnStm32Download.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnStm32Download.RectSize = 2;
            this.btnStm32Download.Size = new System.Drawing.Size(238, 92);
            this.btnStm32Download.Style = Sunny.UI.UIStyle.Custom;
            this.btnStm32Download.Symbol = 61465;
            this.btnStm32Download.SymbolColor = System.Drawing.Color.Blue;
            this.btnStm32Download.SymbolSize = 50;
            this.btnStm32Download.TabIndex = 28;
            this.btnStm32Download.Text = "FirmWare\r\nDownload";
            this.btnStm32Download.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStm32Download.TipsColor = System.Drawing.Color.Cyan;
            this.btnStm32Download.TipsFont = new System.Drawing.Font("宋体", 79F);
            this.btnStm32Download.TipsText = "STM32";
            // 
            // btnStm32Verify
            // 
            this.btnStm32Verify.CircleColor = System.Drawing.Color.Blue;
            this.btnStm32Verify.CircleHoverColor = System.Drawing.Color.BlanchedAlmond;
            this.btnStm32Verify.CircleSize = 60;
            this.btnStm32Verify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStm32Verify.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnStm32Verify.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnStm32Verify.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnStm32Verify.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnStm32Verify.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnStm32Verify.Font = new System.Drawing.Font("宋体", 22F);
            this.btnStm32Verify.Location = new System.Drawing.Point(776, 475);
            this.btnStm32Verify.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStm32Verify.Name = "btnStm32Verify";
            this.btnStm32Verify.Padding = new System.Windows.Forms.Padding(6);
            this.btnStm32Verify.Radius = 12;
            this.btnStm32Verify.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop;
            this.btnStm32Verify.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnStm32Verify.RectSize = 2;
            this.btnStm32Verify.ShowSelected = false;
            this.btnStm32Verify.Size = new System.Drawing.Size(238, 92);
            this.btnStm32Verify.Style = Sunny.UI.UIStyle.Custom;
            this.btnStm32Verify.Symbol = 62007;
            this.btnStm32Verify.SymbolColor = System.Drawing.SystemColors.MenuBar;
            this.btnStm32Verify.SymbolSize = 50;
            this.btnStm32Verify.TabIndex = 29;
            this.btnStm32Verify.Text = "FirmWare\rVerify";
            this.btnStm32Verify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStm32Verify.TipsFont = new System.Drawing.Font("宋体", 79F);
            this.btnStm32Verify.TipsText = "STM32\rFirmWare\rVerify";
            // 
            // uiHeaderButton2
            // 
            this.uiHeaderButton2.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uiHeaderButton2.CircleHoverColor = System.Drawing.Color.BlanchedAlmond;
            this.uiHeaderButton2.CircleSize = 60;
            this.uiHeaderButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiHeaderButton2.FillColor = System.Drawing.Color.DodgerBlue;
            this.uiHeaderButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiHeaderButton2.Location = new System.Drawing.Point(472, 130);
            this.uiHeaderButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiHeaderButton2.Name = "uiHeaderButton2";
            this.uiHeaderButton2.Padding = new System.Windows.Forms.Padding(6);
            this.uiHeaderButton2.Radius = 12;
            this.uiHeaderButton2.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop;
            this.uiHeaderButton2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton2.RectSize = 2;
            this.uiHeaderButton2.Size = new System.Drawing.Size(224, 80);
            this.uiHeaderButton2.Symbol = 561264;
            this.uiHeaderButton2.SymbolColor = System.Drawing.Color.SteelBlue;
            this.uiHeaderButton2.SymbolSize = 50;
            this.uiHeaderButton2.TabIndex = 30;
            this.uiHeaderButton2.Text = "Bench Test System";
            this.uiHeaderButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.uiHeaderButton2.TipsFont = new System.Drawing.Font("宋体", 79F);
            this.uiHeaderButton2.TipsText = "Automatic\rPhotograph";
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine2.Location = new System.Drawing.Point(216, 104);
            this.uiLine2.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(751, 20);
            this.uiLine2.TabIndex = 31;
            this.uiLine2.Text = "DQE";
            this.uiLine2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.Location = new System.Drawing.Point(216, 254);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(751, 20);
            this.uiLine1.TabIndex = 32;
            this.uiLine1.Text = "IQC";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLine3
            // 
            this.uiLine3.BackColor = System.Drawing.Color.Transparent;
            this.uiLine3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine3.Location = new System.Drawing.Point(44, 449);
            this.uiLine3.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine3.Name = "uiLine3";
            this.uiLine3.Size = new System.Drawing.Size(970, 20);
            this.uiLine3.TabIndex = 33;
            this.uiLine3.Text = "TE";
            this.uiLine3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 9F);
            this.linkLabel1.Location = new System.Drawing.Point(414, 644);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(317, 12);
            this.linkLabel1.TabIndex = 123;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "©LITEON Technology Corporation. All Rights Reserved.";
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.uiButton3.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.uiButton3.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(97)))), ((int)(((byte)(198)))));
            this.uiButton3.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.uiButton3.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.uiButton3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton3.ForeColor = System.Drawing.Color.BlueViolet;
            this.uiButton3.ForeDisableColor = System.Drawing.Color.Blue;
            this.uiButton3.Location = new System.Drawing.Point(730, 279);
            this.uiButton3.Margin = new System.Windows.Forms.Padding(2);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.RectColor = System.Drawing.Color.Red;
            this.uiButton3.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uiButton3.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(97)))), ((int)(((byte)(198)))));
            this.uiButton3.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.uiButton3.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.uiButton3.Size = new System.Drawing.Size(224, 80);
            this.uiButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton3.TabIndex = 125;
            this.uiButton3.Text = "手动版\rHIPOT (IQC)\rChroma 19053~19054";
            this.uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton3.TipsForeColor = System.Drawing.Color.Black;
            this.uiButton3.Click += new System.EventHandler(this.uiButton3_Click);
            // 
            // btnSemiAutomatic
            // 
            this.btnSemiAutomatic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSemiAutomatic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSemiAutomatic.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.btnSemiAutomatic.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(97)))), ((int)(((byte)(198)))));
            this.btnSemiAutomatic.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.btnSemiAutomatic.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.btnSemiAutomatic.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSemiAutomatic.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnSemiAutomatic.ForeDisableColor = System.Drawing.Color.Blue;
            this.btnSemiAutomatic.Location = new System.Drawing.Point(472, 279);
            this.btnSemiAutomatic.Margin = new System.Windows.Forms.Padding(2);
            this.btnSemiAutomatic.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSemiAutomatic.Name = "btnSemiAutomatic";
            this.btnSemiAutomatic.RectColor = System.Drawing.Color.Red;
            this.btnSemiAutomatic.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSemiAutomatic.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(97)))), ((int)(((byte)(198)))));
            this.btnSemiAutomatic.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.btnSemiAutomatic.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(46)))), ((int)(((byte)(147)))));
            this.btnSemiAutomatic.Size = new System.Drawing.Size(224, 80);
            this.btnSemiAutomatic.Style = Sunny.UI.UIStyle.Custom;
            this.btnSemiAutomatic.TabIndex = 126;
            this.btnSemiAutomatic.Text = "半自动版\rHIPOT (IQC)\rChroma 19053~19054";
            this.btnSemiAutomatic.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSemiAutomatic.TipsForeColor = System.Drawing.Color.Black;
            this.btnSemiAutomatic.Click += new System.EventHandler(this.uiButton1_Click_1);
            // 
            // btnFWDownloadAutoScan
            // 
            this.btnFWDownloadAutoScan.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFWDownloadAutoScan.CircleHoverColor = System.Drawing.Color.BlanchedAlmond;
            this.btnFWDownloadAutoScan.CircleSize = 60;
            this.btnFWDownloadAutoScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFWDownloadAutoScan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnFWDownloadAutoScan.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnFWDownloadAutoScan.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnFWDownloadAutoScan.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnFWDownloadAutoScan.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnFWDownloadAutoScan.Font = new System.Drawing.Font("宋体", 22F);
            this.btnFWDownloadAutoScan.Location = new System.Drawing.Point(288, 475);
            this.btnFWDownloadAutoScan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFWDownloadAutoScan.Name = "btnFWDownloadAutoScan";
            this.btnFWDownloadAutoScan.Padding = new System.Windows.Forms.Padding(6);
            this.btnFWDownloadAutoScan.Radius = 12;
            this.btnFWDownloadAutoScan.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop;
            this.btnFWDownloadAutoScan.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnFWDownloadAutoScan.RectSize = 2;
            this.btnFWDownloadAutoScan.Size = new System.Drawing.Size(238, 92);
            this.btnFWDownloadAutoScan.Style = Sunny.UI.UIStyle.Custom;
            this.btnFWDownloadAutoScan.Symbol = 61465;
            this.btnFWDownloadAutoScan.SymbolColor = System.Drawing.Color.Blue;
            this.btnFWDownloadAutoScan.SymbolSize = 50;
            this.btnFWDownloadAutoScan.TabIndex = 127;
            this.btnFWDownloadAutoScan.Text = "FirmWare\r\nDownload\r\nAuto Scan";
            this.btnFWDownloadAutoScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFWDownloadAutoScan.TipsColor = System.Drawing.Color.Cyan;
            this.btnFWDownloadAutoScan.TipsFont = new System.Drawing.Font("宋体", 79F);
            this.btnFWDownloadAutoScan.TipsText = "STM32";
            // 
            // btnFWDownloadAutoScan_PCI7230
            // 
            this.btnFWDownloadAutoScan_PCI7230.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFWDownloadAutoScan_PCI7230.CircleHoverColor = System.Drawing.Color.BlanchedAlmond;
            this.btnFWDownloadAutoScan_PCI7230.CircleSize = 60;
            this.btnFWDownloadAutoScan_PCI7230.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFWDownloadAutoScan_PCI7230.FillColor = System.Drawing.Color.Blue;
            this.btnFWDownloadAutoScan_PCI7230.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnFWDownloadAutoScan_PCI7230.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnFWDownloadAutoScan_PCI7230.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnFWDownloadAutoScan_PCI7230.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnFWDownloadAutoScan_PCI7230.Font = new System.Drawing.Font("宋体", 22F);
            this.btnFWDownloadAutoScan_PCI7230.Location = new System.Drawing.Point(532, 475);
            this.btnFWDownloadAutoScan_PCI7230.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFWDownloadAutoScan_PCI7230.Name = "btnFWDownloadAutoScan_PCI7230";
            this.btnFWDownloadAutoScan_PCI7230.Padding = new System.Windows.Forms.Padding(6);
            this.btnFWDownloadAutoScan_PCI7230.Radius = 12;
            this.btnFWDownloadAutoScan_PCI7230.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop;
            this.btnFWDownloadAutoScan_PCI7230.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnFWDownloadAutoScan_PCI7230.RectSize = 2;
            this.btnFWDownloadAutoScan_PCI7230.Size = new System.Drawing.Size(238, 92);
            this.btnFWDownloadAutoScan_PCI7230.Style = Sunny.UI.UIStyle.Custom;
            this.btnFWDownloadAutoScan_PCI7230.Symbol = 61465;
            this.btnFWDownloadAutoScan_PCI7230.SymbolColor = System.Drawing.Color.Blue;
            this.btnFWDownloadAutoScan_PCI7230.SymbolSize = 50;
            this.btnFWDownloadAutoScan_PCI7230.TabIndex = 128;
            this.btnFWDownloadAutoScan_PCI7230.Text = "FirmWare\r\nDownload\r\nPCI-7230";
            this.btnFWDownloadAutoScan_PCI7230.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFWDownloadAutoScan_PCI7230.TipsColor = System.Drawing.Color.Cyan;
            this.btnFWDownloadAutoScan_PCI7230.TipsFont = new System.Drawing.Font("宋体", 79F);
            this.btnFWDownloadAutoScan_PCI7230.TipsText = "STM32";
            // 
            // btnNXP_TEA2376
            // 
            this.btnNXP_TEA2376.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNXP_TEA2376.CircleHoverColor = System.Drawing.Color.BlanchedAlmond;
            this.btnNXP_TEA2376.CircleSize = 60;
            this.btnNXP_TEA2376.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNXP_TEA2376.FillColor = System.Drawing.Color.Blue;
            this.btnNXP_TEA2376.FillDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnNXP_TEA2376.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnNXP_TEA2376.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnNXP_TEA2376.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnNXP_TEA2376.Font = new System.Drawing.Font("宋体", 22F);
            this.btnNXP_TEA2376.Location = new System.Drawing.Point(44, 568);
            this.btnNXP_TEA2376.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnNXP_TEA2376.Name = "btnNXP_TEA2376";
            this.btnNXP_TEA2376.Padding = new System.Windows.Forms.Padding(6);
            this.btnNXP_TEA2376.Radius = 12;
            this.btnNXP_TEA2376.RadiusSides = Sunny.UI.UICornerRadiusSides.LeftTop;
            this.btnNXP_TEA2376.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnNXP_TEA2376.RectSize = 2;
            this.btnNXP_TEA2376.Size = new System.Drawing.Size(238, 92);
            this.btnNXP_TEA2376.Style = Sunny.UI.UIStyle.Custom;
            this.btnNXP_TEA2376.Symbol = 61465;
            this.btnNXP_TEA2376.SymbolColor = System.Drawing.Color.Blue;
            this.btnNXP_TEA2376.SymbolSize = 50;
            this.btnNXP_TEA2376.TabIndex = 129;
            this.btnNXP_TEA2376.Text = "NXP_TEA2376\r\n_PCI-7230";
            this.btnNXP_TEA2376.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNXP_TEA2376.TipsColor = System.Drawing.Color.Cyan;
            this.btnNXP_TEA2376.TipsFont = new System.Drawing.Font("宋体", 79F);
            this.btnNXP_TEA2376.TipsText = "STM32";
            this.btnNXP_TEA2376.Click += new System.EventHandler(this.btnNXP_TEA2376_Click);
            // 
            // FrmMaster
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1134, 663);
            this.Controls.Add(this.btnNXP_TEA2376);
            this.Controls.Add(this.btnFWDownloadAutoScan_PCI7230);
            this.Controls.Add(this.btnFWDownloadAutoScan);
            this.Controls.Add(this.btnSemiAutomatic);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.uiLine3);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.uiHeaderButton2);
            this.Controls.Add(this.btnStm32Verify);
            this.Controls.Add(this.btnStm32Download);
            this.Controls.Add(this.uiButton5);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.btnDearting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMaster";
            this.ShowRect = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "PDC-ASI Multiple-Test System   Version:10.0.5";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1166, 608);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



  

        #endregion

        private Sunny.UI.UIButton btnDearting;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIHeaderButton btnStm32Download;
        private Sunny.UI.UIHeaderButton btnStm32Verify;
        private Sunny.UI.UIHeaderButton uiHeaderButton2;
        private Sunny.UI.UILine uiLine2;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UILine uiLine3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton btnSemiAutomatic;
        private Sunny.UI.UIHeaderButton btnFWDownloadAutoScan;
        private Sunny.UI.UIHeaderButton btnFWDownloadAutoScan_PCI7230;
        private Sunny.UI.UIHeaderButton btnNXP_TEA2376;
    }
}