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
using Application = System.Windows.Forms.Application;
using DateTime = System.DateTime;

namespace Multiple_Test.Controller.STM32
{
    public partial class pageSTM32DownloadAutoScan : UIForm
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

        public pageSTM32DownloadAutoScan()
        {
            InitializeComponent();
            Initialize();
            this.Text+= " Version:" + Application.ProductVersion;
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

        private  async void _serialPortScan_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!SN_Status)
            {
                SN_Status = true;
                Thread.Sleep(400);
                string receivedData = serialPortScan.IsOpen ? serialPortScan.ReadExisting() : "Close";
                receivedData = receivedData.Trim();
                receivedData = receivedData.Replace("\r", string.Empty);
                receivedData = receivedData.Replace("\n", string.Empty);
                ShowCommand($" Serial-Number:{receivedData}");
                txtSerialNumber.Text = receivedData;
              await  MESCheckAsync(receivedData);
            }
            else
            {
                ShowCommand("非正常模式触发扫码");
            }

        }

        private void _serialPortMcu_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Thread.Sleep(200);
            string receivedData = serialPortMcu.IsOpen ? serialPortMcu.ReadExisting() : "Close";
            ShowCommand(receivedData);
           
            if (receivedData.Contains("Voltage:") )
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
                else if(voltageValue==0)
                {
                    ShowCommand("等待治具下压 进入下一个流程");
                    SN_Status = false;
                    scanFlag = false;
                }
            }
        }
        /// <summary>
        /// MES 檢查
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        private async Task<Task> MESCheckAsync(string serialNumber)
        {
            string message = string.Empty;

            var status = MES_Service.CheckSerialNumber(serialNumber, ref message);

            ShowCommand($"检查 MES SerialNumber:{serialNumber} Status:{status}");
            if (status)
            {
                ///给电3.3V
                mCU33V开ToolStripMenuItem.PerformClick();
                Thread.Sleep(200);
                await DownloadFwHexAsync(serialNumber);
            }
            else
            {
                ShowCommand(message);
                this.ShowErrorDialog(message);
            }

            return Task.CompletedTask;

        }

        private async Task<Task> DownloadFwHexAsync(string serialNumber)
        {
            try
            {
                var runPath = Application.StartupPath + ConstantService.ST_Link;
                this.ShowWaitForm("正在烧录中......");
                ShowCommand("正在烧录中......");
                var result = await sTM32.RunProcessAndGetOutputAsync(runPath, linePath.Text, uiRichTextBox1);
                ShowCommand("烧录完成......");
                this.SetWaitFormDescription("烧录完成");
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
                    UploadTestRecord(serialNumber, "Fail");
                    HandleFailure(serialNumber);
                }
            }
            catch (Exception ex)
            {

                this.ShowErrorDialog(ex.Message);
            }
           
            return Task.CompletedTask;
        }

        private void HandleSuccess(string serialNumber)
        {
            mCU33V关ToolStripMenuItem.PerformClick();
            Thread.Sleep(200);
         
            //上傳MES
            string message = string.Empty;


            //上传测试记录

            var data = new List<string>();
            data.Add($"{MesConst.FW_REV}:{txtSelectVersion.Text}");
            if (MES_Service.UploadTestRecords(serialNumber, data, ref message))
            {
               // this.ShowSuccessNotifier(message, false, 1000);
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

            气缸上升ToolStripMenuItem.PerformClick();
            Thread.Sleep(300);

            var frm = new pageResult(ConstantService.PASS);
            frm.ShowDialog();

            气缸可下降ToolStripMenuItem.PerformClick();
            Thread.Sleep(500);
            Style = UIStyle.Blue;
            // await PrintandUploadMesAsync(serialNumber);


        }

        private void HandleFailure(string serialNumber)
        {
            mCU33V关ToolStripMenuItem.PerformClick();
       
            Style = UIStyle.Red;
            var frm = new pageResult(ConstantService.FAIL);
            frm.ShowDialog();
            Style = UIStyle.Blue;
            string message = string.Empty;
            this.HideWaitForm();
            if (MES_Service.SerialNumberCorssingStationFail(serialNumber, "ZX2", ref message))
            {
                this.ShowSuccessNotifier(message, false, 1000);
                FileLog.WriteLog("Download", message);
            }
            else
            {
                this.ShowErrorNotifier(message, false, 1000);
                FileLog.WriteLog("Download", message);
                  this.ShowErrorDialog(message); 
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
                ShowCommand(message);
                ButtonsService.EnableBtn(btnOpenHex);
                return;
            }
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
                ShowCommand("請配置MCU COM");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (string.IsNullOrEmpty(txtScanProtName.Text))
            {
                ShowCommand("請配置Scan COM");
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
                ShowCommand("沒有輸入預燒錄版本");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (string.IsNullOrEmpty(linePath.Text))
            {
                ShowCommand("請選擇FW文件");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (txtSelectVersion.Text != txtVersion.Text)
            {
                ShowCommand ("選擇的版本與預設的版本不一致");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            var runPath = Application.StartupPath + ConstantService.ST_Link;
            if (!File.Exists(runPath))
            {
                ShowCommand("請配置執行軟體");
                ButtonsService.EnableBtn(btnRun);
                return;
            }

            if (!File.Exists(Application.StartupPath + ConstantService.PrintModePath))
            {
                ShowCommand($"请设定模板 {Application.StartupPath + ConstantService.PrintModePath}");
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

                    if (config?.fwAutoDownload?.Scan != null)
                    {
                        if (serialPortScan == null || !serialPortScan.IsOpen)
                        {
                            serialPortScan = new SerialPort()
                            {
                                PortName = config.fwAutoDownload.Scan.PortName,
                                BaudRate = config.fwAutoDownload.Scan.BaudRate,
                                DataBits = config.fwAutoDownload.Scan.DataBits,
                                StopBits = config.fwAutoDownload.Scan.StopBits,
                                Handshake = config.fwAutoDownload.Scan.Handshake,
                                Parity = config.fwAutoDownload.Scan.Parity
                            };
                            serialPortScan.Open();
                            serialPortScan.DataReceived += new SerialDataReceivedEventHandler(_serialPortScan_DataReceived);
                        }
                    }

                    if (config?.fwAutoDownload?.mcu != null)
                    {
                        if (serialPortMcu == null || !serialPortMcu.IsOpen)
                        {
                            serialPortMcu = new SerialPort()
                            {
                                PortName = config.fwAutoDownload.mcu.PortName,
                                BaudRate = config.fwAutoDownload.mcu.BaudRate,
                                DataBits = config.fwAutoDownload.mcu.DataBits,
                                StopBits = config.fwAutoDownload.mcu.StopBits,
                                Handshake = config.fwAutoDownload.mcu.Handshake,
                                Parity = config.fwAutoDownload.mcu.Parity
                            };
                            serialPortMcu.Open();
                            serialPortMcu.DataReceived += _serialPortMcu_DataReceived;
                            mCU33V关ToolStripMenuItem.PerformClick();
                            Thread.Sleep(100);
                            气缸上升ToolStripMenuItem.PerformClick();
                            Thread.Sleep(100);
                            气缸可下降ToolStripMenuItem.PerformClick();
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

        private void Rs232ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmRs232();
            frm.ShowDialog();
        }

        private void PageSTM32DownloadAutoScan_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void MCUConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCommand("控制器 MCU 配置");
            var frm = new FrmRS232Editor("AutoFWMCU", "控制器 MCU 配置");
            frm.ShowDialog();
            LoadConfig();
        }

        private void ScanConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCommand("SR-710 扫码器配置");
            var frm = new FrmRS232Editor("AutoFWScan", "SR-710 扫码器配置");
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


        private void ShowLogs(string message)
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

                if (config?.fwAutoDownload?.Scan != null)
                {
                    txtScanProtName.Text = config.fwAutoDownload.Scan.PortName;
                }

                if (config?.fwAutoDownload?.mcu != null)
                {
                    txtMCUPortName.Text = config.fwAutoDownload.mcu.PortName;
                }
            }
        }
    }
}