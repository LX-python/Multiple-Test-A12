using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Controller.UIModels.Pages.Result
{
    public partial class pageHipotFail : UIForm
    {
        public int result = 0;
        public bool FlagMisjudge=false;
        public bool FlagPending = false;

        public pageHipotFail(string fixturenNumber)
        {
            InitializeComponent();
            this.uiGroupBox1.Text = "測試治具號:"+fixturenNumber + " 請選擇不良的穴位";
            this.FormClosing += PageHipotFail_FormClosing;
            this.Style = UIStyle.Red;
            this.btn1.Click += Btn_Click;
            this.btn2.Click += Btn_Click;
            this.btn3.Click += Btn_Click;
            this.btn4.Click += Btn_Click;
            this.btn5.Click += Btn_Click;
            this.btn6.Click += Btn_Click;
            this.btnMisjudge.Click += BtnMisjudge_Click;
            this.btnPending.Click += BtnPending_Click;
        }

        private void BtnPending_Click(object sender, EventArgs e)
        {
            FlagPending = true;
            this.Close();
        }

        private void BtnMisjudge_Click(object sender, EventArgs e)
        {
           FlagMisjudge = true;
           this.Close();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            // 将 sender 转换为 Button 类型
            if (sender is UIButton clickedButton)
            {
                returnResult(clickedButton);
            }
          
        }

        private void PageHipotFail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.result == 0)
            {
                this.ShowErrorNotifier("請選擇正確的巢穴位", false, 2000);
                e.Cancel = true;
            }
        }

        private void returnResult(UIButton btn) 
        {
            result = int.Parse(btn.Text);
            this.DialogResult= DialogResult.OK;
            this.ShowSuccessNotifier($"您選擇了{btn.Text}號穴位",true,2000);
            this.Close();
        }
    }
}
