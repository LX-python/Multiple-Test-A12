//using LabelManager2;
using Multiple_Test.AuthorityManagement;
using Multiple_Test.Controller.Debugger;
using Multiple_Test.Controller.FrmEditor;
using Multiple_Test.Controller.UIModels.Pages.Result;
using Multiple_Test.Models;
using Multiple_Test.Models.Firmware;
using Multiple_Test.Service;
using Multiple_Test.Service.Buttons;
using Multiple_Test.Service.Charts;
using Multiple_Test.Service.ChromaMES;
using Multiple_Test.Service.Files;
using Multiple_Test.Service.Printing;
using Multiple_Test.Service.STM32;
using Multiple_Test.Utilities.Constant;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Application = System.Windows.Forms.Application;
using DateTime = System.DateTime;

namespace Multiple_Test.Controller.STM32
{
    public partial class pageSTM32VerifyAutoScan : UIForm
    {
        private readonly STM32_Service sTM32 = new STM32_Service();
        private readonly FilesService fileService = new FilesService();
        private readonly string runPath = Application.StartupPath;
        private readonly string proConfig = "ProConfig.json";
        private ConfigBasic config = new ConfigBasic();
        private SerialPort serialPortScan, serialPortMcu;
        private bool scanFlag; // 条码扫描标志
        private bool closeFlag;
        private bool SN_Status = false;

        public pageSTM32VerifyAutoScan()
        {
            InitializeComponent();
            Initialize();
            this.Text += " Version:" + Application.ProductVersion;
        }

        private void Initialize()
        {
            ChartsPicService.Set_Production_BarChar(ref BarChart);
            ChartsPicService.Set_PieTestData(ref PieChart);
            this.btnOpenHex.Click += BtnOpenHex_Click;
            this.btnOpenLog.Click += BtnOpenLog_Click;
            this.btnRun.Click += BtnRun_Click;
            this.FormClosing += PageSTM32Download_FormClosing;
            this.Load += PageSTM32DownloadAutoScan_Load;
            this.Rs232ToolStripMenuItem.Click += Rs232ToolStripMenuItem_Click;
            this.scanConfigToolStripMenuItem.Click += ScanConfigToolStripMenuItem_Click;
            this.mCUConfigToolStripMenuItem1.Click += MCUConfigToolStripMenuItem_Click;
            this.lab_UserName.Text = $"{UserInfo.username}-{UserInfo.Name}";
            this.lab_UserName.Left = this.Width - uiAvatar1.Width - this.lab_UserName.Width - 15;
            CheckSerialOpenStatus();
        }

        private void _serialPortScan_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!SN_Status)
            {
                SN_Status = true;
                Thread.Sleep(400);
                string receivedData = serialPortScan.IsOpen ? serialPortScan.ReadExisting() : "Close";
                ShowCommand($" Serial-Number:{receivedData}");
                receivedData = receivedData.Trim();
                receivedData = receivedData.Replace("\r", string.Empty);
                receivedData = receivedData.Replace("\n", string.Empty);
                txtSerialNumber.BeginInvoke(new Action(() =>
                {
                    txtSerialNumber.Text = receivedData;
                }));

                MESCheckAsync(receivedData);
            }
            else
            {
                ShowCommand("非正常模式触发扫码");
            }

        }

        private void _serialPortMcu_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedData = serialPortMcu.IsOpen ? serialPortMcu.ReadExisting() : "Close";
                ShowCommand(receivedData);

                if (receivedData.Contains("Voltage:"))
                {

                    var voltageValue = float.Parse(receivedData.Split("Voltage:")[1]);
                    ShowCommand($"Process Staus:{voltageValue}> 4 = {voltageValue > 4}");
                    if (voltageValue > 4 && !scanFlag && !SN_Status)
                    {
                        scanFlag = true;
                        string command = "LON\r";
                        byte[] commandBytes = Encoding.ASCII.GetBytes(command);
                        serialPortScan.Write(commandBytes, 0, commandBytes.Length);

                    }
                    else if (voltageValue == 0)
                    {
                        ShowCommand("等待治具下压 进入下一个流程");
                        SN_Status = false;
                        scanFlag = false;
                    }
                }
            }
            catch (Exception ex)
            {

                ShowCommand(ex.Message);
            }
          
        }
        /// <summary>
        /// MES 检查
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        private async Task<Task> MESCheckAsync(string serialNumber)
        {
            try
            {
                string message = string.Empty;

                var status = MES_Service.CheckSerialNumber(serialNumber, ref message);

                ShowCommand($"检查 MES SerialNumber:{serialNumber} Status:{status}");
                if (status)
                {
                    ///给电3.3V
                    btnMCU_Turns_ON_Voltage.PerformClick();
                    Thread.Sleep(200);
                    await VerifyFirmware(serialNumber);
                }
                else
                {
                    ShowMessage(message);
                    this.ShowAskDialog(message);
                }

            }
            catch (Exception ex)
            {

                this.ShowErrorDialog(ex.Message);
            }
         

            return Task.CompletedTask;
        }

        /// <summary>
        /// Checksum Verify
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        private async Task<Task> VerifyFirmware(string serialNumber)
        {
            try
            {
                var runPath = Application.StartupPath + ConstantService.ST_Link;
                this.ShowWaitForm("Reading to STM32 MCU Firmware Info......");
                ShowCommand("Checking......");
                //var result = await sTM32.RunProcessVerifyFirmware(runPath, txtCheckSum.Text,txtSize.Text, uiRichTextBox1);

                var result = await sTM32.RunProcessVerifyFirmware(runPath, txtCheckSum.Text, txtCheckSumSize.Text, uiRichTextBox1, txtReadCheckSum);
                ShowCommand("Checking Successfuly......");
                this.SetWaitFormDescription("Firmware Check Complete...");
                Thread.Sleep(200);
                this.HideWaitForm();
                Thread.Sleep(200);
                sTM32.Get_DayHoursTestRecord(ref BarChart, ref PieChart);

                if (result.flag && result.result.Contains("complete"))
                {
                    UploadTestRecord(serialNumber, "PASS");
                    HandleSuccess(serialNumber);

                }
                else
                {
                    UploadTestRecord(serialNumber, "FAIL");
                    HandleFailure(serialNumber);
                }
            }
            catch (Exception ex)
            {

                this.ShowErrorDialog(ex.Message);
            }
            return Task.CompletedTask;


        }

        /// <summary>
        /// FW CheckSum Success  检查成功 上传MES 上升气缸
        /// </summary>
        /// <param name="serialNumber">产品序列号</param>
        private void HandleSuccess(string serialNumber)
        {
            try
            {   //关闭3.3V MCU 电压
                btnMCU_Turns_Off_Voltage.PerformClick();
                Thread.Sleep(200);
                //上傳MES
                string message = string.Empty;

                //上传MES 测试记录

                var data = new List<string>();
                data.Add($"{MesConst.FW_REV}:{txtSelectVersion.Text}");
                data.Add($"{MesConst.CheckSumValue}:{txtCheckSum.Text}");
                data.Add($"{MesConst.CheckSumSet}:{txtCheckSum.Text}");
                data.Add($"{MesConst.CheckSumSize}:{txtCheckSumSize.Text}");
                if (MES_Service.UploadTestRecords(serialNumber, data, ref message))
                {
                    this.ShowSuccessNotifier(message, false, 1000);
                    if (MES_Service.SerialNumberCorssingStationPass(serialNumber, ref message))
                    {
                        Style = UIStyle.Green;
                        this.ShowSuccessNotifier(message);
                    }
                    else
                    {
                        Style = UIStyle.Red;
                        this.ShowErrorDialog(message);
                        return;
                    }

                }
                else
                {
                    Style = UIStyle.Red;
                    this.ShowErrorDialog(message);
                    return;
                }
                //气缸上升
                btnCylinderRising.PerformClick();
                Thread.Sleep(200);
                //显示PASS
                var frm = new pageResult(ConstantService.PASS);
                frm.ShowDialog();
                //允许气缸可以下降
                btnCylinderDescent.PerformClick();
                Thread.Sleep(200);
                Style = UIStyle.Blue;

            }
            catch (Exception ex)
            {

                ShowCommand(ex.Message);
            }
         
            // await PrintandUploadMesAsync(serialNumber);

        }

        /// <summary>
        /// FW 检查失败
        /// </summary>
        /// <param name="serialNumber"></param>
        private void HandleFailure(string serialNumber)
        {
            try
            {
                btnMCU_Turns_Off_Voltage.PerformClick();

                Style = UIStyle.Red;
                var frm = new pageResult(ConstantService.FAIL);
                frm.ShowDialog();
                Style = UIStyle.Blue;
                string message = string.Empty;


                //上次测试记录

                var data = new List<string>();
                data.Add($"{MesConst.FW_REV}:{txtSelectVersion.Text}");
                data.Add($"{MesConst.CheckSumValue}:{txtReadCheckSum.Text}");
                data.Add($"{MesConst.CheckSumSet}:{txtCheckSum.Text}");
                data.Add($"{MesConst.CheckSumSize}:{txtCheckSumSize.Text}");
                if (MES_Service.UploadTestRecords(serialNumber, data, ref message))
                {
                    //this.ShowSuccessNotifier(message, false, 1000);
                    if (MES_Service.SerialNumberCorssingStationFail(serialNumber, "ZX2", ref message))
                    {
                        this.ShowSuccessTip(message);
                        FileLog.WriteLog("verify", message);

                    }
                    else
                    {
                        this.ShowErrorTip(message);
                        FileLog.WriteErrorLog("verify", message);

                    }

                }
                else
                {
                    Style = UIStyle.Red;
                    this.ShowErrorDialog(message);
                    return;
                }
            }
            catch (Exception ex)
            {

                ShowCommand(ex.Message);
            }

        }

        private async Task PrintandUploadMesAsync(string serialNumber)
        {
            string message = string.Empty;
            var resultPrint = PrintingService.Prints(txtSelectVersion.Text, ref message);
            if (resultPrint.flag)
            {
                var data = new List<string> { $"{MesConst.FW_REV}:{txtSelectVersion.Text}" };
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

        private void BtnOpenHex_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(btnOpenHex);
            string message = string.Empty;
            string selectScriptPath = fileService.OpenHex(ref message);
            if (string.IsNullOrEmpty(selectScriptPath))
            {
                ShowMessage(message);
                ButtonsService.EnableBtn(btnOpenHex);
                return;
            }

            var fileSize = sTM32.CalculateHexFileSize(selectScriptPath, ref message);
            if (fileSize == -1)
            {
                ShowMessage(message);
                ButtonsService.EnableBtn(btnOpenHex);
                return;
            }
            txtSize.Text = "0x" + fileSize.ToString("X");

            string fileName = Path.GetFileName(selectScriptPath);
            if (!sTM32.SubStringVersion(fileName, ref message))
            {
                ShowMessage(message);
                ButtonsService.EnableBtn(btnOpenHex);
                return;
            }

            // var checkcum = sTM32.CalculateChecksum(selectScriptPath,0x08000000,0x1000);
            //  txtReadCheckSum.Text = $"0x{checkcum:X8}";

            txtSelectVersion.Text = message;
            linePath.Text = selectScriptPath;
            ButtonsService.EnableBtn(btnOpenHex);
        }

        private void BtnOpenLog_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + ConstantService.pathSlash + ConstantService.LogsPath;
            fileService.OpenPath(path);
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(btnRun);
            _ = AutoRun();
        }

        private async Task AutoRun()
        {
            if (string.IsNullOrEmpty(txtMCUPortName.Text))
            {
                ShowMessage("請配置MCU COM");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (string.IsNullOrEmpty(txtScanProtName.Text))
            {
                ShowMessage("請配置Scan COM");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (!OpenSerialPort())
            {
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (string.IsNullOrEmpty(txtVersion.Text))
            {
                ShowMessage("沒有輸入預燒錄版本");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (string.IsNullOrEmpty(linePath.Text))
            {
                ShowMessage("請選擇FW文件");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (txtSelectVersion.Text != txtVersion.Text)
            {
                ShowMessage("選擇的版本與預設的版本不一致");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            var runPath = Application.StartupPath + ConstantService.ST_Link;
            if (!File.Exists(runPath))
            {
                ShowMessage("請配置執行軟體");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (!File.Exists(Application.StartupPath + ConstantService.PrintModePath))
            {
                ShowMessage($"请设定模板 {Application.StartupPath + ConstantService.PrintModePath}");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            ButtonsService.EnableBtn(btnRun);
        }

        private bool OpenSerialPort()
        {
            try
            {
                if (File.Exists(Path.Combine(runPath, proConfig)))
                {
                    var configString = File.ReadAllText(Path.Combine(runPath, proConfig));
                    config = JsonConvert.DeserializeObject<ConfigBasic>(configString) ?? new ConfigBasic();

                    if (config?.fwAutoVerify?.Scan != null)
                    {
                        if (serialPortScan == null || !serialPortScan.IsOpen)
                        {
                            serialPortScan = new SerialPort()
                            {
                                PortName = config.fwAutoVerify.Scan.PortName,
                                BaudRate = config.fwAutoVerify.Scan.BaudRate,
                                DataBits = config.fwAutoVerify.Scan.DataBits,
                                StopBits = config.fwAutoVerify.Scan.StopBits,
                                Handshake = config.fwAutoVerify.Scan.Handshake,
                                Parity = config.fwAutoVerify.Scan.Parity
                            };
                            serialPortScan.Open();
                            serialPortScan.DataReceived += new SerialDataReceivedEventHandler(_serialPortScan_DataReceived);
                        }
                    }

                    if (config?.fwAutoVerify?.mcu != null)
                    {
                        if (serialPortMcu == null || !serialPortMcu.IsOpen)
                        {
                            serialPortMcu = new SerialPort()
                            {
                                PortName = config.fwAutoVerify.mcu.PortName,
                                BaudRate = config.fwAutoVerify.mcu.BaudRate,
                                DataBits = config.fwAutoVerify.mcu.DataBits,
                                StopBits = config.fwAutoVerify.mcu.StopBits,
                                Handshake = config.fwAutoVerify.mcu.Handshake,
                                Parity = config.fwAutoVerify.mcu.Parity
                            };
                            serialPortMcu.Open();
                            serialPortMcu.DataReceived += _serialPortMcu_DataReceived;
                            btnMCU_Turns_Off_Voltage.PerformClick();
                            Thread.Sleep(100);
                            btnCylinderRising.PerformClick();
                            Thread.Sleep(100);
                            btnCylinderDescent.PerformClick();
                            Thread.Sleep(100);
                        }
                    }
                }

                return serialPortMcu != null && serialPortMcu.IsOpen && serialPortScan != null && serialPortScan.IsOpen;
            }
            catch (Exception ex)
            {
                this.ShowErrorDialog(ex.Message);
                return false;
            }
        }

        private async Task CheckSerialOpenStatus()
        {
            while (true)
            {
                if (serialPortMcu == null || !serialPortMcu.IsOpen)
                {
                    ledMcu.On = true;
                    ledMcu.Color = Color.Red;
                    ledMcu.Blink = false;
                }
                else
                {
                    ledMcu.On = false;
                    ledMcu.Color = Color.Lime;
                    ledMcu.Blink = true;
                    serialPortMcu.WriteLine("READ");
                }

                if (serialPortScan == null || !serialPortScan.IsOpen)
                {
                    ledSan.On = true;
                    ledSan.Color = Color.Red;
                    ledSan.Blink = false;
                }
                else
                {
                    ledSan.On = false;
                    ledSan.Color = Color.Lime;
                    ledSan.Blink = true;
                }

                await Task.Delay(1000);
            }
        }
        /// <summary>
        /// RS232 Debugger 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rs232ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmRs232();
            frm.ShowDialog();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageSTM32DownloadAutoScan_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void MCUConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCommand("控制器 MCU 配置");
            var frm = new FrmRS232Editor("AutoFWverifyMCU", "FW 站 控制器 MCU 配置");
            frm.ShowDialog();
            LoadConfig();
        }

        private void ScanConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCommand("SR-710 扫码器配置");
            var frm = new FrmRS232Editor("AutoFWverifyScan", "FW 站 SR-710 扫码器配置");
            frm.ShowDialog();
            LoadConfig();
        }

        private void PageSTM32Download_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeFlag)
            {
                this.Dispose();
                return;
            }

            if (this.ShowAskDialog("您確定要退出Firmware Download 系統嗎?"))
            {
                closeFlag = true;
                if (!(serialPortScan is null) && serialPortScan.IsOpen)
                {
                    serialPortScan.Close();
                }

                if (!(serialPortMcu is null) && serialPortMcu.IsOpen)
                {
                    serialPortMcu.Close();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void UploadTestRecord(string serialNumber, string result)
        {
            var data = new EntityFirmwareTestRecord
            {
                fw_version = txtSelectVersion.Text,
                serial_number = serialNumber,
                test_result = result,
                test_datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            sTM32.InsertTestRecord(data);
        }

        private void ShowMessage(string message)
        {
            this.Style = UIStyle.Red;
            this.ShowErrorDialog(message);
            this.Style = UIStyle.Blue;
            FileLog.LogInformation("Testing", message);
        }

        private void SendMcuCommand(string command)
        {
            if (serialPortMcu == null || !serialPortMcu.IsOpen)
            {
                this.ShowErrorTip("Com is Close or null,Please Open Com");
                ShowCommand("Com is Close or null,Please Open Com");
                return;
            }

            serialPortMcu.WriteLine(command);
            Thread.Sleep(300);
        }

        private void 气缸上升ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMcuCommand("R4_OFF");
            ShowCommand("气缸上升");
        }

        private void 气缸可下降ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMcuCommand("R4_ON");
            ShowCommand("气缸可下降");
        }

        private void 关闭控制器串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPortMcu != null && serialPortMcu.IsOpen)
            {
                serialPortMcu.Close();
                this.ShowSuccessTip($"{serialPortMcu.PortName} is Close");
            }
        }

        private void mCU33V开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMcuCommand("R2_OFF");
            ShowCommand("开启 3.3V ");
        }

        private void mCU33V关ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMcuCommand("R2_ON");
            ShowCommand("关闭 3.3V ");
        }

        private void 关闭扫码器串口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPortScan != null && serialPortScan.IsOpen)
            {
                serialPortScan.Close();
                this.ShowSuccessTip($"{serialPortScan.PortName} is Close");
            }
        }


        public void ShowLogs(string message)
        {

            uiRichTextBox1.BeginInvoke(new Action(() =>
            {
                if (uiRichTextBox1.Text.Length > 1024)
                {
                    uiRichTextBox1.Text = string.Empty;
                }
                uiRichTextBox1.Text += $"{message} \r";
                FileLog.WriteLog("Logs", message);
            }));
        }
        private void ShowCommand(string message)
        {
            txtCommandLog.BeginInvoke(new Action(() =>
            {
                if (txtCommandLog.Text.Length > 1024)
                {
                    txtCommandLog.Text = string.Empty;
                }
                txtCommandLog.Text = $"{message}\r" + txtCommandLog.Text;
                FileLog.WriteLog("Logs", message);
            }));
        }

        private void LoadConfig()
        {
            if (File.Exists(Path.Combine(runPath, proConfig)))
            {
                var configString = File.ReadAllText(Path.Combine(runPath, proConfig));
                config = JsonConvert.DeserializeObject<ConfigBasic>(configString) ?? new ConfigBasic();

                if (config?.fwAutoVerify?.Scan != null)
                {
                    txtScanProtName.Text = config.fwAutoVerify.Scan.PortName;
                }

                if (config?.fwAutoVerify?.mcu != null)
                {
                    txtMCUPortName.Text = config.fwAutoVerify.mcu.PortName;
                }
            }
        }
    }
}