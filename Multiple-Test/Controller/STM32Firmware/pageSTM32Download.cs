//using LabelManager2;
using Multiple_Test.AuthorityManagement;
using Multiple_Test.Controller.UIModels.Pages.Result;
using Multiple_Test.Models.Firmware;
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
    public partial class pageSTM32Download : UIForm
    {
        /// <summary>
        /// 服務注入
        /// </summary>
        private readonly STM32_Service sTM32 = new STM32_Service();
        private readonly FilesService file_servic = new FilesService();
        private bool ClostFlag;
        public pageSTM32Download()
        {
            InitializeComponent();
            Initialize();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize() 
        {

            ChartsPicService.Set_Production_BarChar(ref BarChart);
            ChartsPicService.Set_PieTestData(ref PieChart);
            string message = string.Empty;
            this.btnOpenHex.Click += BtnOpenHex_Click;
            this.btnOpenLog.Click += BtnOpenLog_Click;
            this.btnRun.Click += BtnRun_Click;
            this.FormClosing += PageSTM32Download_FormClosing;
            //显示登录用户信息
            this.lab_UserName.Text = UserInfo.username + "-" + UserInfo.Name;
            this.lab_UserName.Left = this.Width - uiAvatar1.Width - this.lab_UserName.Width - 15;
        }
        /// <summary>
        /// 打开日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenLog_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + ConstantService.pathSlash + ConstantService.LogsPath;
            file_servic.OpenPath(path);
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageSTM32Download_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClostFlag)
            {
                this.Dispose();
                return;

            }
            if (this.ShowAskDialog("您確定要退出Firmware Download 系統嗎?"))
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
            await AutoRun();
            //檢查版本
            ButtonsService.EnableBtn(btnRun);
        }
        /// <summary>
        /// 自动运行
        /// </summary>
        /// <returns></returns>
        private async Task AutoRun()
        {
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

            //检查模板是否存在
            if (!File.Exists(Application.StartupPath + ConstantService.PrintModePath))
            {
                ShowMessage($"请设定模板 {Application.StartupPath + ConstantService.PrintModePath}");
                ButtonsService.EnableBtn(btnRun);
            }
            //檢查條碼
            while (true)
            {   //如果在异步任务中检查窗体是否触发关闭 
                //如果是True 表示User 要退出窗体 应该结束异步线程
                if (ClostFlag)
                {
                    break;
                }

                var resultCheckSerialNumber = await sTM32.InputSerialNumber();
                if (resultCheckSerialNumber.Flag)
                {

                    //執行燒錄
                    this.ShowWaitForm("正在烧录中......");
                    var result = await sTM32.RunProcessAndGetOutputAsync(runPath, linePath.Text, uiRichTextBox1);
       
                    //刷新产能
                    sTM32.Get_DayHoursTestRecord(ref BarChart, ref PieChart);
                    //判斷結果
                    if (result.flag && result.result.IndexOf("complete") > -1)
                    {
                        this.SetWaitFormDescription("烧录完成");
                        this.HideWaitForm();
                        UploadTestRecord(resultCheckSerialNumber.message, ConstantService.PASS);
                        this.Style = UIStyle.Green;
                        var frm = new pageResult(ConstantService.PASS);
                        frm.ShowDialog();
                        this.Style = UIStyle.Blue;
                        await PrintandUploadMes(resultCheckSerialNumber.message);
                    }
                    else
                    {
                        this.SetWaitFormDescription("烧录失败...");
                        this.HideWaitForm();
                        string message = string.Empty;
                        UploadTestRecord(resultCheckSerialNumber.message, ConstantService.FAIL);
                        this.Style = UIStyle.Red;
                        var frm = new pageResult(ConstantService.FAIL);
                        frm.ShowDialog();
                        this.Style = UIStyle.Blue;
                        //上傳MES ZX2信息不能燒進IC
                        if (MES_Service.SerialNumberCorssingStationFail(resultCheckSerialNumber.message, "ZX2", ref message))
                        {
                            this.ShowSuccessNotifier(message, false, 1000);
                            await Task.Delay(1000);
                        }
                        else
                        {
                            this.ShowErrorNotifier(message, false, 1000);
                            await Task.Delay(1000);
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

        }

        /// <summary>
        /// 上传测试记录
        /// </summary>
        /// <param name="serial_number"></param>
        /// <param name="result"></param>
        private void UploadTestRecord(string serial_number, string result)
        {

            var data = new EntityFirmwareTestRecord();
            data.fw_version = txtSelectVersion.Text;
            data.serial_number = serial_number;
            data.test_result = result;
            data.test_datetime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            sTM32.InsertTestRecord(data);
        }

        /// <summary>
        /// 打印条码 并上传MES
        /// </summary>
        /// <param name="serialNumber"></param>
        private async Task PrintandUploadMes(string serialNumber)
        {
            //打印Qrqode
            string message = string.Empty;
            var resultPrint = PrintingService.Prints(txtSelectVersion.Text, ref message);
            if (resultPrint.flag)
            {


                var data = new List<string>();
                data.Add($"{MesConst.FW_REV}:{txtSelectVersion.Text}");
                if (MES_Service.UploadTestRecords(serialNumber, data, ref message))
                {
                    this.ShowSuccessNotifier(message, false, 1000);
                    await Task.Delay(1300);
                }
                else
                {
                    this.ShowSuccessNotifier(message, false, 1000);
                    await Task.Delay(1300);
                }
                //上傳MES
                if (MES_Service.SerialNumberCorssingStationPass(serialNumber, ref message))
                {
                    this.ShowSuccessNotifier(message, false, 1000);
                    await Task.Delay(1300);
                }
                else
                {
                    this.ShowSuccessNotifier(message, false, 1000);
                    await Task.Delay(1300);
                }
            }
            else
            {
                //打印机连接失败 不上传
                while (true)
                {
                    if (PrintingService.Prints(txtSelectVersion.Text, ref message).flag)
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
            //判断文件是否正确转换文件大小
            var fileSize = sTM32.CalculateHexFileSize(SelectScriptPath, ref message);
            if (fileSize == -1) 
            {
                ShowMessage(message);
                ButtonsService.EnableBtn(btnOpenHex);
                return;
            }
            string hexSize = "0x" + fileSize.ToString("X");
            txtSize.Text = hexSize;
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
            this.Style = UIStyle.Blue;
            FileLog.LogInformation("Testing", message);
        }

        private void initToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uiLine1_Click(object sender, EventArgs e)
        {

        }
    }
}
