namespace Multiple_Test.Controller.FrmEditor
{
    partial class FrmRS232Editor
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
            this.uiLedBulb1 = new Sunny.UI.UILedBulb();
            this.comboxDataBit = new Sunny.UI.UIComboBox();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.comboxHandshake = new Sunny.UI.UIComboBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.comboxStopBits = new Sunny.UI.UIComboBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.comParity = new Sunny.UI.UIComboBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.cbBaudRate = new Sunny.UI.UIComboBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.cbComlist = new Sunny.UI.UIComboBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.btnRefresh = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton22 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton19 = new Sunny.UI.UISymbolButton();
            this.pnlBtm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 473);
            this.pnlBtm.Size = new System.Drawing.Size(371, 55);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(243, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(128, 12);
            // 
            // uiLedBulb1
            // 
            this.uiLedBulb1.Color = System.Drawing.Color.Red;
            this.uiLedBulb1.Location = new System.Drawing.Point(333, 41);
            this.uiLedBulb1.Name = "uiLedBulb1";
            this.uiLedBulb1.Size = new System.Drawing.Size(32, 32);
            this.uiLedBulb1.TabIndex = 95;
            this.uiLedBulb1.Text = "uiLedBulb1";
            // 
            // comboxDataBit
            // 
            this.comboxDataBit.DataSource = null;
            this.comboxDataBit.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comboxDataBit.FillColor = System.Drawing.Color.White;
            this.comboxDataBit.Font = new System.Drawing.Font("宋体", 12F);
            this.comboxDataBit.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.comboxDataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboxDataBit.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboxDataBit.Location = new System.Drawing.Point(122, 320);
            this.comboxDataBit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboxDataBit.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboxDataBit.Name = "comboxDataBit";
            this.comboxDataBit.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboxDataBit.Size = new System.Drawing.Size(243, 34);
           // this.comboxDataBit.SymbolSize = 24;//
            this.comboxDataBit.TabIndex = 94;
            this.comboxDataBit.Text = "8";
            this.comboxDataBit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboxDataBit.Watermark = "";
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel10.Location = new System.Drawing.Point(19, 320);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(88, 32);
            this.uiLabel10.TabIndex = 93;
            this.uiLabel10.Text = "Data Bits:";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboxHandshake
            // 
            this.comboxHandshake.DataSource = null;
            this.comboxHandshake.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comboxHandshake.FillColor = System.Drawing.Color.White;
            this.comboxHandshake.Font = new System.Drawing.Font("宋体", 12F);
            this.comboxHandshake.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.comboxHandshake.Items.AddRange(new object[] {
            "None",
            "XOnXOff",
            "RequestToSend",
            "RequestToSendXOnXOff"});
            this.comboxHandshake.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboxHandshake.Location = new System.Drawing.Point(122, 279);
            this.comboxHandshake.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboxHandshake.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboxHandshake.Name = "comboxHandshake";
            this.comboxHandshake.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboxHandshake.Size = new System.Drawing.Size(243, 34);
         //   this.comboxHandshake.SymbolSize = 24;
            this.comboxHandshake.TabIndex = 92;
            this.comboxHandshake.Text = "None";
            this.comboxHandshake.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboxHandshake.Watermark = "";
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel9.Location = new System.Drawing.Point(19, 279);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(88, 32);
            this.uiLabel9.TabIndex = 91;
            this.uiLabel9.Text = "Handshake:";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboxStopBits
            // 
            this.comboxStopBits.DataSource = null;
            this.comboxStopBits.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comboxStopBits.FillColor = System.Drawing.Color.White;
            this.comboxStopBits.Font = new System.Drawing.Font("宋体", 12F);
            this.comboxStopBits.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.comboxStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboxStopBits.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboxStopBits.Location = new System.Drawing.Point(122, 238);
            this.comboxStopBits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboxStopBits.MinimumSize = new System.Drawing.Size(63, 0);
            this.comboxStopBits.Name = "comboxStopBits";
            this.comboxStopBits.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comboxStopBits.Size = new System.Drawing.Size(243, 34);
          //  this.comboxStopBits.SymbolSize = 24;
            this.comboxStopBits.TabIndex = 90;
            this.comboxStopBits.Text = "1";
            this.comboxStopBits.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comboxStopBits.Watermark = "";
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel8.Location = new System.Drawing.Point(19, 238);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(88, 32);
            this.uiLabel8.TabIndex = 89;
            this.uiLabel8.Text = "StopBits:";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comParity
            // 
            this.comParity.DataSource = null;
            this.comParity.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.comParity.FillColor = System.Drawing.Color.White;
            this.comParity.Font = new System.Drawing.Font("宋体", 12F);
            this.comParity.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.comParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comParity.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comParity.Location = new System.Drawing.Point(122, 197);
            this.comParity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comParity.MinimumSize = new System.Drawing.Size(63, 0);
            this.comParity.Name = "comParity";
            this.comParity.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.comParity.Size = new System.Drawing.Size(243, 34);
           // this.comParity.SymbolSize = 24;
            this.comParity.TabIndex = 88;
            this.comParity.Text = "None";
            this.comParity.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.comParity.Watermark = "";
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel7.Location = new System.Drawing.Point(19, 197);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(88, 32);
            this.uiLabel7.TabIndex = 87;
            this.uiLabel7.Text = "Parity:";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DataSource = null;
            this.cbBaudRate.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbBaudRate.FillColor = System.Drawing.Color.White;
            this.cbBaudRate.Font = new System.Drawing.Font("宋体", 12F);
            this.cbBaudRate.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaudRate.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbBaudRate.Location = new System.Drawing.Point(122, 156);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbBaudRate.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbBaudRate.Size = new System.Drawing.Size(243, 34);
            //this.cbBaudRate.SymbolSize = 24;
            this.cbBaudRate.TabIndex = 86;
            this.cbBaudRate.Text = "115200";
            this.cbBaudRate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbBaudRate.Watermark = "";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(19, 156);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(88, 32);
            this.uiLabel6.TabIndex = 85;
            this.uiLabel6.Text = "Baudrate:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbComlist
            // 
            this.cbComlist.DataSource = null;
            this.cbComlist.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbComlist.FillColor = System.Drawing.Color.White;
            this.cbComlist.Font = new System.Drawing.Font("宋体", 12F);
            this.cbComlist.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbComlist.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbComlist.Location = new System.Drawing.Point(122, 115);
            this.cbComlist.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbComlist.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbComlist.Name = "cbComlist";
            this.cbComlist.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbComlist.Size = new System.Drawing.Size(243, 34);
           // this.cbComlist.SymbolSize = 24;
            this.cbComlist.TabIndex = 84;
            this.cbComlist.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbComlist.Watermark = "";
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(19, 115);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(88, 32);
            this.uiLabel5.TabIndex = 83;
            this.uiLabel5.Text = "PortName:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 12F);
            this.btnRefresh.Location = new System.Drawing.Point(95, 38);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RadiusSides = ((Sunny.UI.UICornerRadiusSides)((Sunny.UI.UICornerRadiusSides.RightTop | Sunny.UI.UICornerRadiusSides.RightBottom)));
            this.btnRefresh.RectSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.btnRefresh.Size = new System.Drawing.Size(46, 35);
            this.btnRefresh.Symbol = 361473;
            this.btnRefresh.TabIndex = 107;
            this.btnRefresh.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton22
            // 
            this.uiSymbolButton22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton22.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSymbolButton22.Location = new System.Drawing.Point(49, 38);
            this.uiSymbolButton22.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton22.Name = "uiSymbolButton22";
            this.uiSymbolButton22.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiSymbolButton22.Size = new System.Drawing.Size(46, 35);
            this.uiSymbolButton22.Symbol = 81;
            this.uiSymbolButton22.TabIndex = 105;
            this.uiSymbolButton22.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiSymbolButton19
            // 
            this.uiSymbolButton19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton19.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSymbolButton19.Location = new System.Drawing.Point(3, 38);
            this.uiSymbolButton19.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton19.Name = "uiSymbolButton19";
            this.uiSymbolButton19.RadiusSides = ((Sunny.UI.UICornerRadiusSides)((Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom)));
            this.uiSymbolButton19.Size = new System.Drawing.Size(46, 35);
            this.uiSymbolButton19.Symbol = 61851;
            this.uiSymbolButton19.TabIndex = 104;
            this.uiSymbolButton19.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // FrmRS232Editer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(373, 531);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.uiSymbolButton22);
            this.Controls.Add(this.uiSymbolButton19);
            this.Controls.Add(this.cbComlist);
            this.Controls.Add(this.uiLedBulb1);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.comboxDataBit);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel10);
            this.Controls.Add(this.cbBaudRate);
            this.Controls.Add(this.comboxHandshake);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.comParity);
            this.Controls.Add(this.comboxStopBits);
            this.Controls.Add(this.uiLabel8);
            this.Name = "FrmRS232Editer";
            this.Text = "FrmRS232Editer";
            this.Controls.SetChildIndex(this.uiLabel8, 0);
            this.Controls.SetChildIndex(this.comboxStopBits, 0);
            this.Controls.SetChildIndex(this.comParity, 0);
            this.Controls.SetChildIndex(this.uiLabel9, 0);
            this.Controls.SetChildIndex(this.uiLabel7, 0);
            this.Controls.SetChildIndex(this.comboxHandshake, 0);
            this.Controls.SetChildIndex(this.cbBaudRate, 0);
            this.Controls.SetChildIndex(this.uiLabel10, 0);
            this.Controls.SetChildIndex(this.uiLabel6, 0);
            this.Controls.SetChildIndex(this.comboxDataBit, 0);
            this.Controls.SetChildIndex(this.uiLabel5, 0);
            this.Controls.SetChildIndex(this.uiLedBulb1, 0);
            this.Controls.SetChildIndex(this.cbComlist, 0);
            this.Controls.SetChildIndex(this.uiSymbolButton19, 0);
            this.Controls.SetChildIndex(this.uiSymbolButton22, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.pnlBtm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILedBulb uiLedBulb1;
        private Sunny.UI.UIComboBox comboxDataBit;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UIComboBox comboxHandshake;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIComboBox comboxStopBits;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UIComboBox comParity;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIComboBox cbBaudRate;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIComboBox cbComlist;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UISymbolButton btnRefresh;
        private Sunny.UI.UISymbolButton uiSymbolButton22;
        private Sunny.UI.UISymbolButton uiSymbolButton19;
    }
}