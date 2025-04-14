using Multiple_Test.Utilities.Constant;
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
    public partial class pageResult : Form
    {
        public pageResult(string result)
        {
            InitializeComponent();
            uiLabel1.ForeColor = Color.White;

            this.uiLabel1.Text = result;
            // 将 AcceptButton 设置为 null，避免回车键触发默认按钮
            this.AcceptButton = null;
            SetColor(result);
            this.TopMost = true;
            CloseWindow();

        }

        private void SetColor(string Result)
        {
            switch (Result)
            {
                case ConstantService.PASS:
                    {
                        this.BackColor = Color.SpringGreen;
                        break;
                    }

                 default:
                    {

                        this.BackColor = Color.Red;
                        break;
                    }

            }
        }

        private async Task CloseWindow()
        {
            await Task.Delay(3000);
            this.Close();

        }


        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
