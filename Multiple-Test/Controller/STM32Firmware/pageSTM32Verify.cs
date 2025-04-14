//using LabelManager2;
using Multiple_Test.Controller.UIModels.Pages.Result;
using Multiple_Test.Service;
using Multiple_Test.Service.Buttons;
using Multiple_Test.Service.Charts;
using Multiple_Test.Service.ChromaMES;
using Multiple_Test.Service.Files;
using Multiple_Test.Service.Printing;
using Multiple_Test.Service.STM32;
using Multiple_Test.Utilities.Constant;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace Multiple_Test.Controller.STM32
{
    public partial class pageSTM32Verify : UIForm
    {
        /// <summary>
        /// 服務注入
        /// </summary>
        private readonly STM32_Service sTM32 = new STM32_Service();
        private readonly FilesService file_servic = new FilesService();
        private bool ClostFlag;
        public pageSTM32Verify()
        {
            InitializeComponent();
            ChartsPicService.Set_Production_BarChar(ref BarChart);
            string message = string.Empty;
            this.btnOpenHex.Click += BtnOpenHex_Click;
            this.btnRun.Click += BtnRun_Click;
            this.FormClosing += PageSTM32Verify_FormClosing;
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageSTM32Verify_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (ClostFlag)
            {
                this.Dispose();
                return;

            }
            if (this.ShowAskDialog("您確定要退出Firmware Verify 系統嗎?"))
            {
                ClostFlag = true;

            }
            else
            {
                e.Cancel = true;

            }


        }

        /// <summary>
        ///运行脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnRun_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(btnRun);

            //檢查 有沒有輸入預燒錄版本
            if (string.IsNullOrEmpty(txtVersion.Text))
            {
                ShowMessage("沒有輸入預燒錄版本");
                ButtonsService.EnableBtn(btnRun);
                return;
            }
            //檢查是否有選擇Fw
            if (string.IsNullOrEmpty(linePath.Text))
            {
                ShowMessage("請選擇FW文件");
                ButtonsService.EnableBtn(btnRun);
                return;
            }
            //檢查選擇Fw與預設值的FW版本檢查
            if (txtSelectVersion.Text != txtVersion.Text)
            {
                ShowMessage("選擇的版本與預設的版本不一致");
                ButtonsService.EnableBtn(btnRun);
                return;
            }
            //檢查是否有Copy ST-LINK
            var runPath = Application.StartupPath + ConstantService.ST_Link;
            if (!File.Exists(runPath))
            {
                ShowMessage("請配置執行軟體");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            //檢查條碼
            while (true)
            {
                var resultCheckSerialNumber = await sTM32.InputSerialNumber();
                if (resultCheckSerialNumber.Flag)
                {
                    //检查模板是否存在
                    if (!File.Exists(Application.StartupPath + ConstantService.PrintModePath))
                    {
                        ShowMessage($"请设定模板 {Application.StartupPath + ConstantService.PrintModePath}");
                        break;
                    }
                    //執行燒錄
                    var result = await sTM32.RunProcessAndGetOutputAsync(runPath, linePath.Text, uiRichTextBox1);

                    //判斷結果
                    if (result.flag && result.result.IndexOf("complete") > -1)
                    {

                        this.Style = UIStyle.Green;
                        var frm = new pageResult(ConstantService.PASS);
                        frm.ShowDialog();
                        this.Style = UIStyle.Blue;
                       // PrintandUploadMes(resultCheckSerialNumber.message);

                    }
                    else
                    {
                        this.Style = UIStyle.Red;
                        var frm = new pageResult(ConstantService.FAIL);
                        frm.ShowDialog();
                        this.Style = UIStyle.Blue;
                        string message = string.Empty;
                        //上傳MES ZX2信息不能燒進IC
                        if (MES_Service.SerialNumberCorssingStationFail(resultCheckSerialNumber.message, "ZX2", ref message))
                        {
                            this.ShowSuccessTip(message);
                        }
                        else
                        {
                            this.ShowErrorTip(message);
                        }

                    }

                }
                else
                {
                    if (resultCheckSerialNumber.ExitFlag)
                    {
                        this.ShowErrorNotifier(resultCheckSerialNumber.message);
                        break;
                    }
                    ShowMessage(resultCheckSerialNumber.message);
                }
            }
            //檢查版本
            ButtonsService.EnableBtn(btnRun);
        }


        private void UploadMes(string serialNumber)
        {
            //打印Qrqode
            string message = string.Empty;
            var resultPrint = PrintingService.Prints(txtVersion.Text, ref message);
            if (resultPrint.flag)
            {
                this.ShowSuccessTip(resultPrint.result);
                var data = new List<string>();
                data.Add($"{MesConst.FW_REV}:{txtVersion.Text}");
                if (MES_Service.UploadTestRecords(serialNumber, data, ref message))
                {
                    this.ShowSuccessTip(message);
                }
                else
                {
                    this.ShowErrorTip(message);
                }
                //上傳MES
                if (MES_Service.SerialNumberCorssingStationPass(serialNumber, ref message))
                {
                    this.ShowSuccessTip(message);
                }
                else
                {
                    this.ShowErrorTip(message);
                }
            }
            else
            {
                //打印机连接失败 不上传
                while (true)
                {
                    if (PrintingService.Prints(txtVersion.Text, ref message).flag)
                    {
                        break;
                    }
                    ShowMessage(resultPrint.result);
                }

            }


        }

        /// <summary>
        /// 打開Hex 檔案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenHex_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(btnOpenHex);
            string message = string.Empty;
            string SelectScriptPath = file_servic.OpenHex(ref message);
            if (string.IsNullOrEmpty(SelectScriptPath))
            {
                ShowMessage(message);
                ButtonsService.EnableBtn(btnOpenHex);
                return;
            }
            // 提取文件名
            string fileName = Path.GetFileName(SelectScriptPath);
            if (!sTM32.SubStringVersion(fileName, ref message))
            {
                ShowMessage(message);
                ButtonsService.EnableBtn(btnOpenHex);
                return;
            }
            txtSelectVersion.Text = message;
            linePath.Text = SelectScriptPath;
            ButtonsService.EnableBtn(btnOpenHex);
        }


        /// <summary>
        /// 显示log
        /// </summary>
        /// <param name="frm"></param>
        public void ShowMessage(string message)
        {
            this.Style = UIStyle.Red;
            this.ShowErrorDialog( message);
            //this.ShowErrorNotifier(message,false,2000);
            //await Task.Delay(1000);
            this.Style = UIStyle.Blue;
            FileLog.LogInformation("Testing", message);
            //this.ShowErrorTip(message);
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            PrintingService.Prints("sss", ref message);
        }
    }
}
