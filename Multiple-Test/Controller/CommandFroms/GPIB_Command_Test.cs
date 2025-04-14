using Multiple_Test.Service;
using Multiple_Test.Service.GPIB;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Controller.CommandFroms
{
    public partial class GPIB_Command_Test : UIForm
    {
        private readonly GPIBServices service = new GPIBServices();
        private bool OpenFlags;
        public GPIB_Command_Test()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            var list = service.getGPIBList();
            this.ShowSuccessTip($"getGPIBList {list.Count}");
            txtGPIBList.DataSource = list;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGPIBList.Text) && !string.IsNullOrEmpty(txtGPIBCommand.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {
                var re_respoense = service.WriteString(txtGPIBList.Text, txtAddress.Text, txtGPIBCommand.Text);

                uiRichTextBox1.AppendText($"{txtGPIBList.Text}::{txtAddress.Text} Cmd={txtGPIBCommand.Text}");
                if (string.IsNullOrEmpty(re_respoense))
                {
                    FileLog.LogDebug("Debugger", "No read Data...");
                    uiRichTextBox1.AppendText("No read Data... \r");


                }

                uiRichTextBox1.AppendText(re_respoense + "\r");




            }
            else
            {


                this.ShowErrorTip("No  No 。。。。Command");
                uiRichTextBox1.AppendText("GPIB Command is null  or  GPIB  IS NULL \r");
            }



        }


        public void ShowCommandString(string message)
        {

            uiRichTextBox1.AppendText($"{message} \r");

        }


        public async Task StartListen(Action<string> Result)

        {

            while (true)
            {

                try
                {
                    if (!string.IsNullOrEmpty(txtGPIBList.Text) && !string.IsNullOrEmpty(txtGPIBCommand.Text) && !string.IsNullOrEmpty(txtAddress.Text))
                    {
                        Result($"Gpib {txtGPIBList.Text}:{txtAddress.Text}");
                        var gpib = service.ConnectGPIB(txtGPIBList.Text, txtAddress.Text);
                        var msg = service.ReadString();
                        Result(msg.message);
                    }
                    else
                    {

                        Result("Gpib 没有选择");
                        return;
                    }
                    if (!OpenFlags)
                    {
                        Result("已经停止");
                        return;
                    }
                }
                catch (Exception ex)
                {

                    Result(ex.Message);
                }


                await Task.Delay(300);
            }


        }

        private async void uiButton3_Click(object sender, EventArgs e)
        {
            await StartListen(

                Result: res =>
                {
                    ShowCommandString(res);
                }
                                );
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            OpenFlags = false;
        }
    }
}
