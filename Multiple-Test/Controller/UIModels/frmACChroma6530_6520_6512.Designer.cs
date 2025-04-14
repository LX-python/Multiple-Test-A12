namespace Multiple_Test.Controller.UIModels
{
    partial class frmACChroma6530_6520_6512
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

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupbox = new Sunny.UI.UIGroupBox();
            this.txtAddress = new Sunny.UI.UITextBox();
            this.labAddress = new System.Windows.Forms.Label();
            this.txtName = new Sunny.UI.UITextBox();
            this.labName = new System.Windows.Forms.Label();
            this.btnGpibList = new Sunny.UI.UISymbolButton();
            this.btnExec = new Sunny.UI.UIButton();
            this.labResult = new System.Windows.Forms.Label();
            this.uiRichTextBox1 = new Sunny.UI.UIRichTextBox();
            this.txtCommand = new Sunny.UI.UITextBox();
            this.labCommand = new System.Windows.Forms.Label();
            this.groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox
            // 
            this.groupbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox.Controls.Add(this.txtAddress);
            this.groupbox.Controls.Add(this.labAddress);
            this.groupbox.Controls.Add(this.txtName);
            this.groupbox.Controls.Add(this.labName);
            this.groupbox.Controls.Add(this.btnGpibList);
            this.groupbox.Controls.Add(this.btnExec);
            this.groupbox.Controls.Add(this.labResult);
            this.groupbox.Controls.Add(this.uiRichTextBox1);
            this.groupbox.Controls.Add(this.txtCommand);
            this.groupbox.Controls.Add(this.labCommand);
            this.groupbox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupbox.Location = new System.Drawing.Point(13, 3);
            this.groupbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupbox.Name = "groupbox";
            this.groupbox.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.groupbox.Size = new System.Drawing.Size(770, 409);
            this.groupbox.TabIndex = 0;
            this.groupbox.Text = "AC Sourse Chroma 6530/6520/6512";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.FillColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtAddress.Location = new System.Drawing.Point(114, 99);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Maximum = 2147483647D;
            this.txtAddress.Minimum = -2147483648D;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new System.Windows.Forms.Padding(5);
            this.txtAddress.Size = new System.Drawing.Size(552, 29);
            this.txtAddress.TabIndex = 9;
            this.txtAddress.Text = "*IDN?";
            // 
            // labAddress
            // 
            this.labAddress.AutoSize = true;
            this.labAddress.Location = new System.Drawing.Point(15, 103);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(74, 21);
            this.labAddress.TabIndex = 8;
            this.labAddress.Text = "Address:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.FillColor = System.Drawing.Color.White;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtName.Location = new System.Drawing.Point(114, 64);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Maximum = 2147483647D;
            this.txtName.Minimum = -2147483648D;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(5);
            this.txtName.Size = new System.Drawing.Size(552, 29);
            this.txtName.TabIndex = 7;
            this.txtName.Text = "*IDN?";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(15, 68);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(60, 21);
            this.labName.TabIndex = 6;
            this.labName.Text = "Name:";
            // 
            // btnGpibList
            // 
            this.btnGpibList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGpibList.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnGpibList.Location = new System.Drawing.Point(17, 29);
            this.btnGpibList.Name = "btnGpibList";
            this.btnGpibList.Size = new System.Drawing.Size(103, 30);
            this.btnGpibList.TabIndex = 5;
            this.btnGpibList.Text = "GPIB List";
            this.btnGpibList.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // btnExec
            // 
            this.btnExec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExec.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnExec.Location = new System.Drawing.Point(681, 128);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(73, 35);
            this.btnExec.TabIndex = 4;
            this.btnExec.Text = "Exec";
            this.btnExec.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Location = new System.Drawing.Point(17, 172);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(60, 21);
            this.labResult.TabIndex = 3;
            this.labResult.Text = "Result:";
            // 
            // uiRichTextBox1
            // 
            this.uiRichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiRichTextBox1.AutoWordSelection = true;
            this.uiRichTextBox1.FillColor = System.Drawing.Color.White;
            this.uiRichTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiRichTextBox1.Location = new System.Drawing.Point(20, 198);
            this.uiRichTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRichTextBox1.Name = "uiRichTextBox1";
            this.uiRichTextBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiRichTextBox1.Size = new System.Drawing.Size(734, 199);
            this.uiRichTextBox1.TabIndex = 2;
            this.uiRichTextBox1.Text = "VOLT 110 ;FREO\n120<PMT>";
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCommand.FillColor = System.Drawing.Color.White;
            this.txtCommand.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtCommand.Location = new System.Drawing.Point(114, 134);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommand.Maximum = 2147483647D;
            this.txtCommand.Minimum = -2147483648D;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Padding = new System.Windows.Forms.Padding(5);
            this.txtCommand.Size = new System.Drawing.Size(552, 29);
            this.txtCommand.TabIndex = 1;
            this.txtCommand.Text = "*IDN?";
            // 
            // labCommand
            // 
            this.labCommand.AutoSize = true;
            this.labCommand.Location = new System.Drawing.Point(15, 138);
            this.labCommand.Name = "labCommand";
            this.labCommand.Size = new System.Drawing.Size(94, 21);
            this.labCommand.TabIndex = 0;
            this.labCommand.Text = "Command:";
            // 
            // frmACChroma6530_6520_6512
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 414);
            this.Controls.Add(this.groupbox);
            this.Name = "frmACChroma6530_6520_6512";
            this.Load += new System.EventHandler(this.frmACChroma6530_6520_6512_Load);
            this.groupbox.ResumeLayout(false);
            this.groupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIGroupBox groupbox;
        private System.Windows.Forms.Label labResult;
        private Sunny.UI.UIRichTextBox uiRichTextBox1;
        private Sunny.UI.UITextBox txtCommand;
        private System.Windows.Forms.Label labCommand;
        private Sunny.UI.UIButton btnExec;
        private Sunny.UI.UISymbolButton btnGpibList;
        private Sunny.UI.UITextBox txtAddress;
        private System.Windows.Forms.Label labAddress;
        private Sunny.UI.UITextBox txtName;
        private System.Windows.Forms.Label labName;
    }
}
