using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HidLibrary; // 允許訪問 HidLibrary 提供的類別和方法；HidLibrary 是一個開源的 .NET 庫，用於與 HID (Human Interface Device) 類型的 USB 設備進行通信，[bash] $Install-Package HidLibrary
using Microsoft.VisualBasic;
using System.IO; // 加入以便儲存日誌文件
using System.Text;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using System.Threading;
using Multiple_Test.Service.ChromaMES;
using Multiple_Test.Models.Firmware;
using Multiple_Test.AuthorityManagement;
using Multiple_Test.Service.Charts;
using Sunny.UI;
using Multiple_Test.Service.Buttons;
using Multiple_Test.Service.PCI7230Helper;
using System.IO.Ports;
using Multiple_Test.Models;
using Multiple_Test.Service.Files;
using Newtonsoft.Json;
using Multiple_Test.Controller.FrmEditor;
using Multiple_Test.Controller.Debugger;
using System.Threading.Tasks;
using Multiple_Test.Controller.UIModels.Pages.Result;
using Multiple_Test.Service;
using Multiple_Test.Utilities.Constant;
using Multiple_Test.Service.ACSource;
// ----------------------------------------------------------------------------------------------------------------------------------

namespace NXP_TEA_IC
{
    public partial class FormGUI : Form
    {
        private NotifyIcon notifyIcon;      // 背景模式執行
        private ContextMenuStrip trayMenu;  // 背景模式執行

        private const string TARGET_VID = "1FC9";            // Vendor ID
        private const string TARGET_PID = "00A0";            // Product ID
        private const string TARGET_USAGE_PAGE = "FF42";     // Usage Page
        private const string TARGET_USAGE = "0001";          // Usage
        //private const string TARGET_ReportID = "01";         // ReportID 發送指令前記得加上去

        private bool isDeviceConnected = false;              // 追蹤裝置的連接狀態

        // 在 FormGUI 類別中新增這個成員變數
        private int previousDeviceCount = 0;

        // 其他成員變數
        private HidDevice targetDevice;        // 設為可為 null, 在類別的頂部宣告為全域變數

        // 從控件中查找標籤
        private Label GetLabel(string labelName)
        {
            return this.Controls.Find(labelName, true).FirstOrDefault() as Label ?? new Label();
        }

        /// 宣告: 開啟並讀取 project list 的資訊
        /// 
        public string mifFileName = ""; //.mif 檔案名, 不包含副檔名
        // .mif 檔案名稱上的專案名
        public string mifFileProjectName = "";
        // project list 目錄之路徑
        public string directoryInfo_projectList_path = "";
        public string projectListProjectName = "";
        public string projectListProjectI2cCommitSpeed = "0";
        public int comparisonBetweenProjectListAndMifFileName = 0;     // 1: Yes , 0: No

        /// 宣告: 開啟並讀取 min file 的資訊
        /// 
        public byte[] NewMinFileCode = new byte[0];
        public List<uint> minFileList = new List<uint>();
        public List<uint> minFileList_Count = new List<uint>();
        public String mifString = "";

        /// 宣告: Power Status
        /// 
        public string powerStatus = "01"; // 00: On , 01: Off

        /// 宣告: 讀取 .mif 檔案，暫時紀錄 .mif 每個 page 的 DATA 值
        /// 
        public string mifVersion = "";
        public string mif_page8_Byte_Input = "";
        public string mif_page9_Byte_Input = "";
        public string mif_page10_Byte_Input = "";
        public string mif_page11_Byte_Input = "";
        public string mif_page12_Byte_Input = "";
        public string mif_page13_Byte_Input = "";
        public string mif_page14_Byte_Input = "";
        public string mif_page15_Byte_Input = "";
        public string mif_page16_Byte_Input = "";

        public string mif_page17_Byte_Input = "";
        public string mif_page18_Byte_Input = "";
        public string mif_page19_Byte_Input = "";
        public string mif_page20_Byte_Input = "";
        public string mif_page21_Byte_Input = "";
        public string mif_page22_Byte_Input = "";
        public string mif_page23_Byte_Input = "";
        public string mif_page24_Byte_Input = "";
        public string mif_page25_Byte_Input = "";
        public string mif_page26_Byte_Input = "";
        public string mif_page27_Byte_Input = "";
        public string mif_page28_Byte_Input = "";
        public string mif_page29_Byte_Input = "";
        public string mif_page30_Byte_Input = "";
        public string mif_page31_Byte_Input = "";

        // ----------------------------------------------------------------------------------------------------------------------------------

        /// 宣告: 陣列 存儲所有 Target IC 的 MTP 狀態
        /// 
        string[] varReadingMTPstatus = new string[4] { "02", "02", "02", "02" }; // 02: unlock, 06: Read-Lock, 0A: Write-Lock, 0E: Read & Write - Lock

        /// IC Status
        /// 
        public string varICstatus = "00"; // 00: 正常, 01: 異常

        /// IC Number
        /// 
        public string icNum0_1 = "00"; // 廣播
        public string icNum0_2 = "00"; // 廣播

        /// TEA2376 GUI Command
        /// 
        private string teaCommand_3_1 = "00"; // 0x0003 ( 寫資料 )
        private string teaCommand_3_2 = "03"; // 0x0003 ( 寫資料 )
        // ----------------------------------------------------------------------------------------------------------------------------------

        public FormGUI()
        {
            InitializeComponent();
            // ----------------------------------------------------------------------------------------------------------------------------------

            //this.FormBorderStyle = FormBorderStyle.Sizable; // 設置視窗可調整大小

            //this.MaximizeBox = true;    // 允許最大化
            this.MinimizeBox = true;    // 允許最小化

            //this.MinimumSize = new Size(300, 200);  // 設置最小大小
            //this.MaximumSize = new Size(1200, 800);   // 設置最大大小

            // 設置 NotifyIcon
            notifyIcon = new NotifyIcon();
            //notifyIcon.Icon = new System.Drawing.Icon("favicon_WPG.ico"); // 需要使用自己的 .ico 文件
            notifyIcon.Text = "NXP TEA IC Program";
            notifyIcon.Visible = false; // 一開始不顯示，最小化時才顯示

            // 設置右鍵選單
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Restore", null, Restore_Click);
            trayMenu.Items.Add("Exit", null, Exit_Click);

            // 將 ContextMenuStrip 綁定到 NotifyIcon
            notifyIcon.ContextMenuStrip = trayMenu;

            // 雙擊托盤圖標事件
            notifyIcon.DoubleClick += new EventHandler(NotifyIcon_DoubleClick);

            // 訂閱 Resize 事件處理視窗最小化
            this.Resize += new EventHandler(FormGUI_Resize);
            // ----------------------------------------------------------------------------------------------------------------------------------

            targetDevice = null; // 初始化為 null

            // 設置 USBCheckTimer 的 Tick 事件處理
            USBCheckTimer.Start();
            // ----------------------------------------------------------------------------------------------------------------------------------

        }

        private void FormGUI_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //this.Hide(); // 隱藏主視窗

                // 顯示托盤圖標，但不隱藏視窗
                notifyIcon.Visible = true; // 顯示托盤圖標
            }
            else if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                // 在視窗恢復時隱藏托盤圖標
                notifyIcon.Visible = false;
            }
        }

        // 恢復應用程式
        private void Restore_Click(object sender, EventArgs e)
        {
            RestoreApplication();
        }
        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            RestoreApplication();
        }

        private void RestoreApplication()
        {
            this.Show(); // 顯示主視窗
            this.WindowState = FormWindowState.Normal; // 恢復正常大小
            notifyIcon.Visible = false; // 隱藏托盤圖標
        }

        // 退出應用程式
        private void Exit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false; // 隱藏托盤圖標
            Application.Exit(); // 關閉應用程式
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        private void FormGUI_Load(object sender, EventArgs e)
        {
            // 隱藏指定的標籤，顯示基礎狀態
            ToggleLabelVisibility(
                new[] { label_Target_4_Red, label_Target_4_Green, label_Target_3_Red, label_Target_3_Green,
                        label_Target_2_Red, label_Target_2_Green, label_Target_1_Red, label_Target_1_Green }, false);
            ToggleLabelVisibility(
                new[] { label_Target_4_BGreen, label_Target_3_BGreen,
                        label_Target_2_BGreen, label_Target_1_BGreen }, true);
        }

        // 更新 UI 操作 - 記錄日誌的方法，每 11 byte 一行，最多顯示 64 byte, 記錄回應數據的詳細信息
        private void LogDebugData(byte[] readData)
        {
            listBoxLogs.Items.Add("\r\n");
            listBoxLogs.Items.Add("deBug - log: ");

            // 限制最大顯示 64 byte
            int maxBytesToDisplay = Math.Min(64, readData.Length);
            for (int i = 0; i < maxBytesToDisplay; i += 11)
            {
                listBoxLogs.Items.Add(string.Join(" ", readData.Skip(i).Take(11).Select(b => $"0x{b:X2}")));
            }

            listBoxLogs.Items.Add("\r\n");
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
        }

        // 更新 UI 操作 - 顯示系統時間日期
        private void timer_Now_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now; // 獲取當前系統時間
            label_NowDate.Text = currentTime.ToString("yyyy/MM/dd"); // 更新日期
            label_NowTime.Text = currentTime.ToString("HH:mm:ss"); // 更新時間
        }

        // 更新 UI 操作 - 批量設置 Label 的可見性
        private void ToggleLabelVisibility(Label[] labels, bool visible)
        {
            foreach (var label in labels)
            {
                label.Visible = visible;
            }
        }

        // 更新 UI 操作 - 清除 Target IC Labels Color
        private void clearTargetICLabelsColor(System.Drawing.Color color)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    label_Target_1_status.ForeColor = color;
                    label_Target_2_status.ForeColor = color;
                    label_Target_3_status.ForeColor = color;
                    label_Target_4_status.ForeColor = color;
                }));
            }
            else
            {
                label_Target_1_status.ForeColor = color;
                label_Target_2_status.ForeColor = color;
                label_Target_3_status.ForeColor = color;
                label_Target_4_status.ForeColor = color;
            }
        }

        /// 算出 CRC -> CRC16/IBM-3740
        /// 
        public static int CRC16(byte[] data, int offset, int length)
        {
            if (data == null || offset < 0 || offset > data.Length - 1 || offset + length > data.Length)
            {
                return 0;
            }

            int crc = 0xFFFF;
            for (int i = 0; i < length; ++i)
            {
                crc ^= data[offset + i] << 8;
                for (int j = 0; j < 8; ++j)
                {
                    crc = (crc & 0x8000) > 0 ? (crc << 1) ^ 0x1021 : crc << 1;
                }
            }
            return crc & 0xFFFF;
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
            .Where(x => x % 2 == 0)
            .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
            .ToArray();
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        // 設置 USBCheckTimer, 確保這個方法的參數不允許為 null
        private void USBCheckTimer_Tick(object sender, EventArgs e)
        {
            CheckHIDDevice();
        }
        // 列出所有 HID 裝置
        private void CheckHIDDevice()
        {
            var deviceList = HidDevices.Enumerate().ToList(); // 列出所有 HID 裝置
            targetDevice = deviceList.FirstOrDefault(IsTargetDevice); // 使用已定義的 deviceList 查找目標裝置

            // 如果設備數量變化，才顯示 log 信息
            if (deviceList.Count != previousDeviceCount)
            {
                StringBuilder deviceInfoBuilder = new StringBuilder();
                int deviceNumber = 1;
                foreach (var device in deviceList)
                {
                    deviceInfoBuilder.AppendLine($"Device {deviceNumber}:");
                    deviceInfoBuilder.AppendLine($"Description: {device.Description}");
                    deviceInfoBuilder.AppendLine($"Device Path: {device.DevicePath}");
                    deviceInfoBuilder.AppendLine($"Vendor ID: {device.Attributes.VendorId}, Product ID: {device.Attributes.ProductId}");
                    deviceInfoBuilder.AppendLine();
                    deviceNumber++;
                }

                //listBoxLogs.Items.Add(deviceInfoBuilder.ToString());  // 不顯示有哪些裝置
                //listBoxLogs.TopIndex = listBoxLogs.Items.Count - 1;   // 不顯示有哪些裝置
            }

            // 更新設備數量
            previousDeviceCount = deviceList.Count;

            if (targetDevice != null)
            {
                HandleDeviceConnected(targetDevice);
            }
            else
            {
                HandleDeviceDisconnected();
            }
        }
        // 判斷是否為目標設備的方法
        private bool IsTargetDevice(HidDevice device)
        {
            return device.Attributes.VendorId.ToString("X4") == TARGET_VID &&
                   device.Attributes.ProductId.ToString("X4") == TARGET_PID &&
                   device.Capabilities.UsagePage.ToString("X4") == TARGET_USAGE_PAGE &&
                   device.Capabilities.Usage.ToString("X4") == TARGET_USAGE;
        }
        // 處理設備連接的邏輯
        private void HandleDeviceConnected(HidDevice targetDevice)
        {
            if (!isDeviceConnected)
            {
                isDeviceConnected = true;
                // ----------------------------------------------------------------------------------------------------------------------------------

                ReadFirmwareVersion(targetDevice);

            }

        }

        // 讀取韌體版本號的方法 - WriteData
        private void ReadFirmwareVersion(HidDevice targetDevice)
        {
            byte[] opKatakuriVerstion_WriteData = { 0x01, 0x00, 0x00, 0x0F, 0x0E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };

            if (targetDevice.Write(opKatakuriVerstion_WriteData))
            {
                HidDeviceData data = targetDevice.Read(500);

                if (data.Status == HidDeviceData.ReadStatus.Success)
                {
                    ParseFirmwareData(data.Data);
                }
                else
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - The data cannot be read from the device.");
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to query the version number.");
            }
            listBoxLogs.Items.Add("*********************************************************");
            listBoxLogs.Items.Add("\r\n");
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
        }
        // 解析韌體版本數據的方法
        private void ParseFirmwareData(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {
                    PowerOff_Click(targetDevice);
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    string firmwareVersion = $"{Convert.ToInt32(readData[13].ToString("X2"), 16)}.{Convert.ToInt32(readData[14].ToString("X2"), 16)}";
                    //$"{readData[13]:X2}.{readData[14]:X2}";
                    string fwVersionUpdate = GetFirmwareUpdateString(readData, 15, 25);
                    string fwVersionUpdate2 = GetFirmwareUpdateString(readData, 28, 35);

                    listBoxLogs.Items.Add($"[{DateTime.Now}] Firmware Version: {firmwareVersion}");
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Firmware Version Update: {fwVersionUpdate} {fwVersionUpdate2}");

                    label_Connected.Text = "OK!";
                    label_Connected.ForeColor = SystemColors.ControlText;
                    label_fwVerstion.Text = $"FW Version : {firmwareVersion}　 Firmware Version Update : {fwVersionUpdate} {fwVersionUpdate2}";
                    label_fwVerstion.ForeColor = SystemColors.ControlText;

                    LogDebugData(readData);
                }
                else
                {
                    HandleFirmwareError(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The firmware data length is insufficient and cannot be parsed.");
                LogDebugData(readData);
            }
        }

        // 獲取韌體更新字串的方法
        private string GetFirmwareUpdateString(byte[] data, int start, int end)
        {
            return string.Concat(data.Skip(start).Take(end - start + 1).Select(b => ((char)b).ToString()));
        }
        // 處理韌體【ERROR】的邏輯
        private void HandleFirmwareError(byte[] readData)
        {
            label_fwVerstion.Text = "FW Version : -";
            label_fwVerstion.ForeColor = SystemColors.ControlText;
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device responded with 【ERROR】, unable to retrieve the firmware version.");
            LogDebugData(readData);
            // ----------------------------------------------------------------------------------------------------------------------------------

            button_eraseIC.Enabled = false;
            button_searchTargetIC.Enabled = false;
            buttonWriteDevice.Enabled = false;
            button_readLockIC.Enabled = false;
            button_writeLockIC.Enabled = false;
            button_PowerOn.Enabled = false;
            button_PowerOff.Enabled = false;
        }
        // 處理設備斷開連接的邏輯
        private void HandleDeviceDisconnected()
        {
            if (isDeviceConnected)
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The programmer is not connected or the device cannot be found.");
                listBoxLogs.Items.Add("*********************************************************");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                isDeviceConnected = false;
            }

            label_Connected.Text = "Disconnected";
            label_Connected.ForeColor = Color.Red;
            label_fwVerstion.Text = "FW Version : -";
            label_fwVerstion.ForeColor = SystemColors.ControlText;
            // ----------------------------------------------------------------------------------------------------------------------------------

            button_eraseIC.Enabled = false;
            button_searchTargetIC.Enabled = false;
            buttonWriteDevice.Enabled = false;
            button_readLockIC.Enabled = false;
            button_writeLockIC.Enabled = false;
            button_PowerOn.Enabled = false;
            button_PowerOff.Enabled = false;
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        // 清除 log 紀錄
        private void btn_clearLogs_Click(object sender, EventArgs e)
        {
            // 設備斷電
            PowerOff_Click(targetDevice);

            // 清空所有版本和 CRC 顯示
            ClearLabelsText(new[] { label_Target_1_Version, label_Target_2_Version, label_Target_3_Version, label_Target_4_Version });
            ClearLabelsText(new[] { label_Target_1_CRC, label_Target_2_CRC, label_Target_3_CRC, label_Target_4_CRC });

            // 設置所有版本和 CRC 顯示顏色為系統原黑色
            SetLabelsForeColor(new[] { label_Target_1_Version, label_Target_2_Version, label_Target_3_Version, label_Target_4_Version }, SystemColors.ControlText);
            SetLabelsForeColor(new[] { label_Target_1_CRC, label_Target_2_CRC, label_Target_3_CRC, label_Target_4_CRC }, SystemColors.ControlText);

            // 設置所有狀態顯示顏色為灰色
            SetLabelsForeColor(new[] { label_Target_1_status, label_Target_2_status, label_Target_3_status, label_Target_4_status }, Color.Gray);

            // 隱藏所有紅綠燈顯示
            SetLabelsVisibility(new[] { label_Target_1_Green, label_Target_2_Green, label_Target_3_Green, label_Target_4_Green,
                                label_Target_1_Red, label_Target_2_Red, label_Target_3_Red, label_Target_4_Red }, false);

            // 顯示所有底色紅綠燈
            SetLabelsVisibility(new[] { label_Target_1_BGreen, label_Target_2_BGreen, label_Target_3_BGreen, label_Target_4_BGreen }, true);

            // 隱藏所有 R 和 W 狀態顯示
            SetLabelsVisibility(new[] { label_Target_1_R, label_Target_1_W, label_Target_2_R, label_Target_2_W,
                                label_Target_3_R, label_Target_3_W, label_Target_4_R, label_Target_4_W }, false);

            // 顯示所有未設定的 R 和 W 狀態
            SetLabelsVisibility(new[] { label_Target_1_UnR, label_Target_1_UnW, label_Target_2_UnR, label_Target_2_UnW,
                                label_Target_3_UnR, label_Target_3_UnW, label_Target_4_UnR, label_Target_4_UnW }, true);

            // 清空日誌
            listBoxLogs.Items.Clear();
        }
        // 批量清空 Label 的文本
        private void ClearLabelsText(Label[] labels)
        {
            foreach (var label in labels)
            {
                label.Text = null;
            }
        }
        // 批量設置 Label 的 ForeColor
        private void SetLabelsForeColor(Label[] labels, Color color)
        {
            foreach (var label in labels)
            {
                label.ForeColor = color;
            }
        }
        // 批量設置 Label 的可見性
        private void SetLabelsVisibility(Label[] labels, bool visible)
        {
            foreach (var label in labels)
            {
                label.Visible = visible;
            }
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        // 儲存 log 紀錄
        private void btn_saveLogs_Click(object sender, EventArgs e)
        {
            if (listBoxLogs.Items.Count > 0)
            {
                try
                {
                    // 確認日誌路徑
                    string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log file");

                    // 如果路徑不存在，則創建目錄
                    if (!Directory.Exists(logDirectory))
                    {
                        Directory.CreateDirectory(logDirectory);
                    }

                    // 使用更可讀的文件名格式（包含毫秒，避免文件名衝突）
                    string logFileName = Path.Combine(logDirectory, $"{DateTime.Now:yyyyMMdd-HHmm-ss}.txt");

                    // 寫入日誌文件
                    using (StreamWriter file = new StreamWriter(logFileName))
                    {
                        foreach (string log in listBoxLogs.Items)
                        {
                            file.WriteLine(log);
                        }
                    }

                    // 成功訊息
                    MessageBox.Show("A new log record has been generated and saved!", "Save Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // 【ERROR】處理
                    MessageBox.Show($"An 【ERROR】 occurred during the process of saving logs.: {ex.Message}", "【ERROR】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // 如果沒有日誌記錄時提示
                MessageBox.Show("You have not left any log records yet!", "Save Logs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        /// 傳送指令至裝置的方法
        /// 
        private bool SendCommandToDevice(byte[] command, string actionName)
        {
            try
            {
                // 假設有一個 targetDevice 是當前連接的 HID 裝置
                var targetDevice = HidDevices.Enumerate().FirstOrDefault(IsTargetDevice);

                if (targetDevice != null && targetDevice.Write(command))
                {
                    // 記錄指令發送到 log
                    listBoxLogs.Items.Add($"[{DateTime.Now}] Successfully sent【 {actionName} 】command: {BitConverter.ToString(command)}");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    // 假設裝置有一個確認回應的過程
                    System.Threading.Thread.Sleep(300); // 模擬等待裝置回應
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] The device executed successfully【 {actionName} 】command.");
                        //listBoxLogs.Items.Add($"[{DateTime.Now}] 回應數據: {BitConverter.ToString(data.Data)}"); // 列印回應數據
                        // ----------------------------------------------------------------------------------------------------------------------------------

                        LogDebugData(data.Data); // 調用方法詳細列印數據到log中
                        listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                        return true;
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] The device responded with a failure and could not execute【 {actionName} 】command.");
                        listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                        return false;
                    }
                }
                else
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] Unable to send【 {actionName} 】command, Please check the device connection status.");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    return false;
                }
            }
            catch (Exception ex)
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] Send【 {actionName} 】command, An【ERROR】occurred during the process.: " + ex.Message);
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                return false;
            }
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        // 給電按鈕
        private void button_PowerOn_Click(object sender, EventArgs e)
        {
            // 設備給電
            PowerOn_Click(targetDevice);
            button_PowerOn.Enabled = false;
        }
        // 給電
        public void PowerOn_Click(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {
                byte[] powerOnCommand = new byte[] { 0x01, 0x00, 0x00, 0x00, 0xB0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };

                if (targetDevice.Write(powerOnCommand))
                {
                    // 假設裝置有一個確認回應的過程
                    System.Threading.Thread.Sleep(300); // 模擬等待裝置回應
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        powerOnData(data.Data);

                        btn_OpenReadMinFile.Enabled = true;
                        button_searchTargetIC.Enabled = true;
                        buttonWriteDevice.Enabled = true;

                        button_eraseIC.Enabled = true;
                        button_readLockIC.Enabled = true;
                        button_writeLockIC.Enabled = true;

                        btn_saveLogs.Enabled = true;
                        btn_clearLogs.Enabled = true;

                        button_PowerOn.Enabled = false;
                        button_PowerOff.Enabled = true;
                        // ----------------------------------------------------------------------------------------------------------------------------------
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm whether the device is powered on.");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the power-on command.");
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the power-on command.");
                button_PowerOn.Enabled = true;
            }
        }
        // 解析給電的方法
        private void powerOnData(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {
                    powerStatus = "00"; // 00: On , 01: Off
                    this.button_PowerOn.Enabled = false;
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    listBoxLogs.Items.Add($"[{DateTime.Now}] - The device has been successfully powered on.");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    #region Power On Target 1 IC log
                    if ((readData[13] == 0x00) && (readData[14] == 0x00))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 1 IC - 24V Power On !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[13] == 0x00) && (readData[14] == 0x01))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 1 IC - SDA short to GND !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[13] == 0x00) && (readData[14] == 0x02))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 1 IC - SCL short to GND !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[13] == 0x00) && (readData[14] == 0x03))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 1 IC - SDA short to SCL !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[13] == 0x00) && (readData[14] == 0x04))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 1 IC - OCP !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[13] == 0x00) && (readData[14] == 0x05))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 1 IC - SDA short to 24V !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[13] == 0x00) && (readData[14] == 0x06))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 1 IC - SCL short to 24V !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    #endregion

                    #region Power On Target 2 IC log
                    if ((readData[15] == 0x00) && (readData[16] == 0x00))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 2 IC - 24V Power On !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[15] == 0x00) && (readData[16] == 0x01))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 2 IC - SDA short to GND !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[15] == 0x00) && (readData[16] == 0x02))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 2 IC - SCL short to GND !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[15] == 0x00) && (readData[16] == 0x03))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 2 IC - SDA short to SCL !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[15] == 0x00) && (readData[16] == 0x04))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 2 IC - OCP !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[15] == 0x00) && (readData[16] == 0x05))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 2 IC - SDA short to 24V !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[15] == 0x00) && (readData[16] == 0x06))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 2 IC - SCL short to 24V !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    #endregion

                    #region Power On Target 3 IC log
                    if ((readData[17] == 0x00) && (readData[18] == 0x00))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 3 IC - 24V Power On !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[17] == 0x00) && (readData[18] == 0x01))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 3 IC - SDA short to GND !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[17] == 0x00) && (readData[18] == 0x02))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 3 IC - SCL short to GND !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[17] == 0x00) && (readData[18] == 0x03))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 3 IC - SDA short to SCL !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[17] == 0x00) && (readData[18] == 0x04))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 3 IC - OCP !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[17] == 0x00) && (readData[18] == 0x05))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 3 IC - SDA short to 24V !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[17] == 0x00) && (readData[18] == 0x06))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 3 IC - SCL short to 24V !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    #endregion

                    #region Power On Target 4 IC log
                    if ((readData[19] == 0x00) && (readData[20] == 0x00))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 4 IC - 24V Power On !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[19] == 0x00) && (readData[20] == 0x01))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 4 IC - SDA short to GND !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[19] == 0x00) && (readData[20] == 0x02))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 4 IC - SCL short to GND !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[19] == 0x00) && (readData[20] == 0x03))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 4 IC - SDA short to SCL !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[19] == 0x00) && (readData[20] == 0x04))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 4 IC - OCP !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[19] == 0x00) && (readData[20] == 0x05))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 4 IC - SDA short to 24V !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else if ((readData[19] == 0x00) && (readData[20] == 0x06))
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Target 4 IC - SCL short to 24V !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    #endregion

                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
                else
                {
                    powerOnError(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the power-on method is insufficient and cannot be parsed.");
                LogDebugData(readData);
            }
        }
        // 處理給電的方法【ERROR】的邏輯
        private void powerOnError(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The power-on method responded with【ERROR】, unable to power on.");

            LogDebugData(readData);
            this.button_PowerOn.Enabled = true;
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        // 斷電按鈕
        private void button_PowerOff_Click(object sender, EventArgs e)
        {
            PowerOff_Click(targetDevice);
            button_PowerOn.Enabled = true;
        }
        // 斷電
        public void PowerOff_Click(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {
                byte[] powerOffCommand = new byte[] { 0x01, 0x00, 0x00, 0x00, 0xB1, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };

                if (targetDevice.Write(powerOffCommand))
                {
                    // 假設裝置有一個確認回應的過程
                    System.Threading.Thread.Sleep(300); // 模擬等待裝置回應
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        powerOffData(data.Data);
                        // ----------------------------------------------------------------------------------------------------------------------------------

                        btn_OpenReadMinFile.Enabled = true;
                        button_searchTargetIC.Enabled = true;
                        buttonWriteDevice.Enabled = true;

                        button_eraseIC.Enabled = false;
                        button_readLockIC.Enabled = false;
                        button_writeLockIC.Enabled = false;

                        btn_saveLogs.Enabled = true;
                        btn_clearLogs.Enabled = true;

                        button_PowerOn.Enabled = true;
                        button_PowerOff.Enabled = true;
                        // ----------------------------------------------------------------------------------------------------------------------------------
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm whether the device is powered off.");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the power-off command.");
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the power-off command.");
                button_PowerOn.Enabled = false;
            }
        }
        // 解析斷電的方法
        private void powerOffData(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {
                    powerStatus = "01"; // 00: On , 01: Off
                    this.button_PowerOn.Enabled = true;
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    listBoxLogs.Items.Add($"[{DateTime.Now}] - The device has been successfully powered off.");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
                else
                {
                    powerOffError(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the power-off method is insufficient and cannot be parsed.");
                LogDebugData(readData);
            }
        }
        // 處理斷電的方法【ERROR】的邏輯
        private void powerOffError(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The power-off method responded with【ERROR】, unable to power off.");

            LogDebugData(readData);
            this.button_PowerOn.Enabled = false;
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        /// 開啟並且讀取 min file 的資訊
        /// 
        private void btn_OpenReadMinFile_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string Today = dt.ToString("yyyy/MM/dd");
            string NowTime = dt.ToString(" HH:mm:ss");
            // ----------------------------------------------------------------------------------------------------------------------------------

            // 建立一個 OpenFileDialog 用來載入文字檔
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // 檔案開啟位置, 暫時用絕對位置
            openFileDialog.InitialDirectory = ".\\";
            openFileDialog.Title = "Select min file";
            openFileDialog.Filter = "mif files (*.*)|*.mif"; // "mif files (*.*)|*.mif|All files (*.*)|*.*";
                                                             // openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                                                             // ----------------------------------------------------------------------------------------------------------------------------------

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                /// 在文字框顯示檔案的路徑和檔名
                /// 
                labOpenReadMinFile.Text = openFileDialog.FileName;

                string constString_Path = "";
                constString_Path = openFileDialog.FileName;
                string[] words = constString_Path.Split('\\', '.');

                // 計算 .mif 檔案位置的路徑長度可分多少陣列
                int i = 0; int j = 0;
                foreach (var word in words)
                {
                    i++;
                    j = i;
                }

                // 僅顯示 .mif 檔案名稱
                labOpenReadMinFile.Text = words[j - 2] + ".mif";

                mifFileName = words[j - 2];
                string[] newMifFileName = mifFileName.Split('_');

                // .mif 檔案名稱僅要留專案名
                int i2 = 0; int j2 = 0;
                foreach (var word2 in newMifFileName)
                {
                    i2++;
                    j2 = i2;
                }

                mifFileProjectName = newMifFileName[0];
                NewMinFileCode = File.ReadAllBytes(openFileDialog.FileName);

                string FileToRead = openFileDialog.FileName;
                // ----------------------------------------------------------------------------------------------------------------------------------

                try
                {
                    // 讀取所有文字檔的行數
                    string[] allLines = File.ReadAllLines(openFileDialog.FileName);

                    bool found = false; // 標記是否找到 '0020'

                    // 逐行檢查是否包含 '0020'
                    foreach (string line in allLines)
                    {
                        if (line.Contains("0020"))
                        {
                            found = true;
                            int charCount = line.Length;

                            // 如果字元數大於 11，則顯示警告訊息
                            if (charCount > 11)
                            {
                                listBoxLogs.Items.Add("The version of the .mif file is incorrect. Please reload the .mif file. Thank you.\r\n");
                                listBoxLogs.Items.Add("\r\n");
                                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                                labOpenReadMinFile.Text = null;
                                label_mifVersion.Text = null;
                                label_mifCRC.Text = null;

                                MessageBox.Show("The version of the .mif file is incorrect. Please reload the .mif file. Thank you.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                using (StreamReader ReaderObject = new StreamReader(FileToRead))
                                using (StreamReader MinFileData = new StreamReader(openFileDialog.FileName))
                                {
                                    string st_MinFileData = MinFileData.ReadLine();

                                    // 印出 min file 整份原始內文
                                    listBoxLogs.Items.Add(Today + NowTime + " - Open and Read min file.\r\n");
                                    listBoxLogs.Items.Add("--- --- --- --- --- --- ---\r\n");

                                    while (st_MinFileData != null)
                                    {
                                        string[] mfData = st_MinFileData.Split(':');
                                        if (mfData.Length == 2)
                                        {
                                            // TEA2376
                                            // 使用正規表示式僅保留十六進位字元（0-9, A-F）
                                            string cleanedData = System.Text.RegularExpressions.Regex.Replace(mfData[1], "[^0-9A-Fa-f]", "");

                                            if (UInt32.TryParse(cleanedData, System.Globalization.NumberStyles.HexNumber, null, out uint parsedValue))
                                            {
                                                minFileList.Add(parsedValue);
                                            }
                                            else
                                            {
                                                // 處理轉換失敗的情況，例如記錄日誌或提供預設值
                                                listBoxLogs.Items.Add("Invalid hex data: " + mfData[1]);
                                            }

                                        }
                                        listBoxLogs.Items.Add(st_MinFileData + "\r\n");
                                        listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                                        st_MinFileData = MinFileData.ReadLine();
                                    }

                                    listBoxLogs.Items.Add("\r\n");

                                    // 印出 min file 內容
                                    uint[] minFileArr = minFileList.ToArray();

                                    // min file Version
                                    label_mifVersion.Text = $"{Convert.ToInt32(minFileArr[0x20] >> 8)}.{Convert.ToInt32(minFileArr[0x20] & 0xFF)}";
                                    mifVersion = $"{Convert.ToInt32(minFileArr[0x20] >> 8)}";

                                    // min file CRC -> CRC16/IBM-3740
                                    listBoxLogs.Items.Add("CRC16/IBM-3740 [1F]~[0B] \r\n");
                                    listBoxLogs.Items.Add("--- --- --- --- --- --- ---\r\n");
                                    for (int index = 31; index > (minFileArr.Length) - 23; index--)
                                        listBoxLogs.Items.Add($"{Convert.ToString(index, toBase: 16).PadLeft(4, '0').ToUpper()}  |  {Convert.ToString(minFileArr[index], toBase: 16).PadLeft(4, '0').ToUpper()}\r\n");
                                    listBoxLogs.Items.Add("\r\n");

                                    listBoxLogs.Items.Add("Show min file CRC.\r\n");
                                    listBoxLogs.Items.Add("--- --- --- --- --- --- ---\r\n");

                                    var str = (Convert.ToString(minFileArr[0x1F] = 0x0000, toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x1E], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x1D], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x1C], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x1B], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x1A], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x19], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x18], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x17], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x16], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x15], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x14], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x13], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x12], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x11], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x10], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x0F], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x0E], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x0D], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x0C], toBase: 16).PadLeft(4, '0').ToUpper()) +
                                               (Convert.ToString(minFileArr[0x0B] &= 0x3FFF, toBase: 16).PadLeft(4, '0').ToUpper());
                                    // ----------------------------------------------------------------------------------------------------------------------------------

                                    // 暫時紀錄 .mif 每個 page 的 DATA 值
                                    mif_page8_Byte_Input = (Convert.ToString(minFileArr[0x08], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page9_Byte_Input = (Convert.ToString(minFileArr[0x09], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page10_Byte_Input = (Convert.ToString(minFileArr[0x0A], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page11_Byte_Input = (Convert.ToString(minFileArr[0x0B], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page12_Byte_Input = (Convert.ToString(minFileArr[0x0C], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page13_Byte_Input = (Convert.ToString(minFileArr[0x0D], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page14_Byte_Input = (Convert.ToString(minFileArr[0x0E], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page15_Byte_Input = (Convert.ToString(minFileArr[0x0F], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page16_Byte_Input = (Convert.ToString(minFileArr[0x10], toBase: 16).PadLeft(4, '0').ToUpper());

                                    mif_page17_Byte_Input = (Convert.ToString(minFileArr[0x11], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page18_Byte_Input = (Convert.ToString(minFileArr[0x12], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page19_Byte_Input = (Convert.ToString(minFileArr[0x13], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page20_Byte_Input = (Convert.ToString(minFileArr[0x14], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page21_Byte_Input = (Convert.ToString(minFileArr[0x15], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page22_Byte_Input = (Convert.ToString(minFileArr[0x16], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page23_Byte_Input = (Convert.ToString(minFileArr[0x17], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page24_Byte_Input = (Convert.ToString(minFileArr[0x18], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page25_Byte_Input = (Convert.ToString(minFileArr[0x19], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page26_Byte_Input = (Convert.ToString(minFileArr[0x1A], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page27_Byte_Input = (Convert.ToString(minFileArr[0x1B], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page28_Byte_Input = (Convert.ToString(minFileArr[0x1C], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page29_Byte_Input = (Convert.ToString(minFileArr[0x1D], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page30_Byte_Input = (Convert.ToString(minFileArr[0x1E], toBase: 16).PadLeft(4, '0').ToUpper());
                                    mif_page31_Byte_Input = (Convert.ToString(minFileArr[0x1F], toBase: 16).PadLeft(4, '0').ToUpper());
                                    // ----------------------------------------------------------------------------------------------------------------------------------

                                    mifString = str;
                                    var data = StringToByteArray(str);
                                    var result = CRC16(data, 0, data.Length);

                                    label_mifCRC.Text = "0x" + Convert.ToString(CRC16(data, 0, data.Length), toBase: 16).PadLeft(4, '0').ToUpper();
                                    listBoxLogs.Items.Add("0x" + Convert.ToString(CRC16(data, 0, data.Length), toBase: 16).PadLeft(4, '0').ToUpper() + "\r\n");
                                    listBoxLogs.Items.Add("\r\n");
                                    // ----------------------------------------------------------------------------------------------------------------------------------

                                    listBoxLogs.Items.Add("Show min file.\r\n");
                                    listBoxLogs.Items.Add("--- --- --- --- --- --- ---\r\n");
                                    listBoxLogs.Items.Add($"TEA2376 version: {Convert.ToInt32(minFileArr[0x20] >> 8)}.{Convert.ToInt32(minFileArr[0x20] & 0xFF)}\r\n");
                                    listBoxLogs.Items.Add("Page | Contents\tPage | Contents\tPage | Contents\tPage | Contents\n");

                                    for (int index = 0; index < (minFileArr.Length / 4); index++)
                                        listBoxLogs.Items.Add($"  {Convert.ToString(index, toBase: 16).PadLeft(2, '0').ToUpper()}  |  {Convert.ToString(minFileArr[index], toBase: 16).PadLeft(4, '0').ToUpper()}\t" +
                                                              $"  {Convert.ToString(index + 8, toBase: 16).PadLeft(2, '0').ToUpper()}  |  {Convert.ToString(minFileArr[index + 8], toBase: 16).PadLeft(4, '0').ToUpper()}\t" +
                                                              $"  {Convert.ToString(index + 16, toBase: 16).PadLeft(2, '0').ToUpper()}  |  {Convert.ToString(minFileArr[index + 16], toBase: 16).PadLeft(4, '0').ToUpper()}\t" +
                                                              $"  {Convert.ToString(index + 24, toBase: 16).PadLeft(2, '0').ToUpper()}  |  {Convert.ToString(minFileArr[index + 24], toBase: 16).PadLeft(4, '0').ToUpper()}\n"
                                                             );

                                    listBoxLogs.Items.Add("\r\n");
                                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                                    listBoxLogs.Items.Add("\r\n");
                                    minFileList.Clear();
                                }

                                // 載入新的 .mif 檔案，資訊呈現紅色 - V0.3 2022.06.15
                                this.label_mifVersion.ForeColor = System.Drawing.Color.Red;
                                this.label_mifCRC.ForeColor = System.Drawing.Color.Red;
                                // ----------------------------------------------------------------------------------------------------------------------------------

                                Project_List();

                            }
                            break; // 找到後結束迴圈
                        }
                    }

                    // 如果沒找到
                    if (!found)
                    {
                        listBoxLogs.Items.Add("No version number was found in the【.mif】 file. Please reload the .mif file. Thank you.");
                        listBoxLogs.Items.Add("\r\n");
                        listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                        labOpenReadMinFile.Text = null;
                        label_mifVersion.Text = null;
                        label_mifCRC.Text = null;
                    }
                }
                catch (Exception ex)
                {
                    // 顯示【ERROR】訊息
                    MessageBox.Show("An【ERROR】occurred while reading the file: " + ex.Message);
                }

            }
            else
            {
                // 讓 Search IC 按鈕可以點擊 - V0.3 2022.06.15
                button_searchTargetIC.Enabled = true;
            }

        }
        // 只讀取 .mif 檔案的名稱, 不顯示檔案詳細路徑
        public void Project_List()
        {

            DateTime dt = DateTime.Now;
            try
            {

                /// 使用 AppDomain.CurrentDomain.BaseDirectory 屬性獲取可執行檔案路徑，該屬性返回目錄路徑，該路徑包含當前程式碼檔案的可執行檔案（字串變數）。
                ///
                string execPath = AppDomain.CurrentDomain.BaseDirectory;

                /// 列出目錄及檔案
                ///
                DirectoryInfo directoryInfo = new DirectoryInfo(execPath + "\\" + "project list");

                var directoryFilesName = directoryInfo.GetFiles("projectList.txt");
                directoryInfo_projectList_path = directoryInfo.FullName;

                // ---------------------------------------------------------------------------------------------------- //

                string dir = directoryInfo_projectList_path;

                Directory.SetCurrentDirectory(dir);

                int file_i = 0; int file_j = 0;
                foreach (var file in directoryFilesName)
                {
                    file_i++;
                    file_j = file_i;
                }

                if (file_j != 0)
                {
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - projectList.txt is Found ! ");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    /// 開啟並載入 projectList.txt
                    ///
                    string path = directoryInfo_projectList_path + "\\projectList.txt";
                    Console.WriteLine("\r\n");
                    Console.WriteLine("/* *********************************");
                    Console.WriteLine(" | Open and load projectList.txt");
                    Console.WriteLine(" | " + path);
                    Console.WriteLine(" ******************************** */");
                    Console.WriteLine("\r\n");

                    // This text is added only once to the file.
                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        string createText = "Hello and Welcome" + Environment.NewLine;
                        File.WriteAllText(path, createText, Encoding.UTF8);
                    }

                    // ---------------------------------------------------------------------------------------------------- //

                    /// Open the file to read from.
                    ///
                    string readText = File.ReadAllText(path);
                    Console.WriteLine(readText);
                    Console.WriteLine("/* ****************************** */");
                    Console.WriteLine("\r\n");

                    int counter = 0;
                    // Read the file and display it line by line.
                    foreach (string line in System.IO.File.ReadLines(path))
                    {
                        System.Console.WriteLine(line);
                        counter++;
                    }

                    Console.WriteLine("\r\n");
                    System.Console.WriteLine("There were {0} lines.", counter);
                    System.Console.ReadLine();
                    Console.WriteLine("/* ****************************** */");
                    Console.WriteLine("\r\n");

                    // ---------------------------------------------------------------------------------------------------- //

                    #region 印出 projectList.txt 整份內文, 與 .mif 檔案名稱比對, 並確認燒錄速率

                    string FileToRead = path;

                    using (StreamReader ReaderObject = new StreamReader(FileToRead))
                    {

                        /// We have to create Streader Object to use this method
                        ///
                        StreamReader projectListFileData = new StreamReader(FileToRead);
                        string st_projectListFileData = projectListFileData.ReadLine();  // 使用 string? 來允許 null

                        /// 印出 projectList.txt 整份原始內文
                        ///
                        string Today = dt.ToString("yyyy/MM/dd");
                        string NowTime = dt.ToString(" HH:mm:ss");
                        listBoxLogs.Items.Add(Today + NowTime + " - Open and Read projectList.txt file.\r\n");
                        listBoxLogs.Items.Add("\r\n");

                        comparisonBetweenProjectListAndMifFileName = 0;
                        projectListProjectI2cCommitSpeed = "0";
                        int st_projectListFileData_num = 0;
                        while (st_projectListFileData != null)
                        {
                            st_projectListFileData_num++;

                            if (st_projectListFileData.StartsWith(mifFileProjectName))
                            {
                                /// 讀取 project 的燒錄速度
                                ///
                                string[] words = st_projectListFileData.Split('=');
                                projectListProjectName = words[0];
                                projectListProjectI2cCommitSpeed = words[1];
                                comparisonBetweenProjectListAndMifFileName = 1;   // make a comparison between .mif file name and project list file

                                Console.WriteLine("Project List File Data Number : " + st_projectListFileData_num);
                                Console.WriteLine("Project List Merge Mif File Name : Yes ! " + comparisonBetweenProjectListAndMifFileName);
                                Console.WriteLine("Project : " + projectListProjectName + " Burning speed : " + projectListProjectI2cCommitSpeed);

                                listBoxLogs.Items.Add("→ Matching the project : " + projectListProjectName + "\r\n");
                                listBoxLogs.Items.Add("→ Burning speed : " + projectListProjectI2cCommitSpeed + "\r\n");
                                listBoxLogs.Items.Add("\r\n");
                                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                            }

                            // ---------------------------------------------------------------------------------------------------- //

                            listBoxLogs.Items.Add(st_projectListFileData + "\r\n");
                            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                            st_projectListFileData = projectListFileData.ReadLine();
                        }

                        listBoxLogs.Items.Add("--- --- --- --- --- --- ---\r\n");
                        listBoxLogs.Items.Add("\r\n");
                        listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                        /// make a comparison between .mif file name and project list file
                        ///
                        if (comparisonBetweenProjectListAndMifFileName == 0)
                        {
                            listBoxLogs.Items.Add("\r\n" + "❌ .mif file does not match with project list after comparison.\r\n");
                            listBoxLogs.Items.Add("　→ Programming times with 15nF ( Default ) !");
                            listBoxLogs.Items.Add("\r\n");
                            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                            projectI2cCommitSpeed_15(targetDevice);
                        }
                        else
                        {
                            listBoxLogs.Items.Add("\r\n" + "⭕️ .mif file does match with project list after comparison.\r\n");

                            if (projectListProjectI2cCommitSpeed == "0")
                            {
                                listBoxLogs.Items.Add("　→ Programming times with 15nF !");
                                projectI2cCommitSpeed_15(targetDevice);
                            }
                            else if (projectListProjectI2cCommitSpeed == "1")
                            {
                                listBoxLogs.Items.Add("　→ Programming times with 10nF !");
                                projectI2cCommitSpeed_10(targetDevice);
                            }
                            else if (projectListProjectI2cCommitSpeed == "2")
                            {
                                listBoxLogs.Items.Add("　→ Programming times with 33nF !");
                                projectI2cCommitSpeed_33(targetDevice);
                            }

                            listBoxLogs.Items.Add("\r\n");
                            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                        }

                    }

                    #endregion

                }
                else
                {
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Not Found projectList.txt ! ");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    projectListProjectI2cCommitSpeed = "0";
                    listBoxLogs.Items.Add("　→ Programming times with 15nF ( Default ) !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    projectI2cCommitSpeed_15(targetDevice);

                    //this.Close();
                    //Application.Exit();
                    //Application.ExitThread();
                    //System.Environment.Exit(0);
                }

            }
            catch (DirectoryNotFoundException dirEx)
            {
                // Let the user know that the directory did not exist.
                Console.WriteLine("Directory not found: " + dirEx.Message);

                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Directory not found: " + dirEx.Message);
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                projectListProjectI2cCommitSpeed = "0";
                listBoxLogs.Items.Add("　→ Programming times with 15nF ( Default ) !");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
            }

        }

        // 發送指令: 燒錄速率 - 0 = 0x00B3 ( I2C 預設速率 : 15nF / 62.5 KHz )
        public void projectI2cCommitSpeed_15(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 定義 I2C 燒錄數據
                byte[] projectI2cCommitSpeedCommand_15 = new byte[] { 0x01, 0x00, 0x00, 0x00, 0xB3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };

                if (targetDevice.Write(projectI2cCommitSpeedCommand_15))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        projectI2cCommitSpeed_15Data(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm Programming times with 15nF / 62.5 KHz!");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ .mif file does not match with project list after comparison.\r\n");
                    listBoxLogs.Items.Add($"[{DateTime.Now}] 　→ Programming times with 15nF ( Default ) !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define I2C burning data.");
            }
        }
        // 解析指令: 燒錄速率 - 0 = 0x00B3 ( I2C 預設速率 : 15nF / 62.5 KHz )
        private void projectI2cCommitSpeed_15Data(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {

                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Programming times with 15nF !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    LogDebugData(readData);
                    
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - The device successfully defined I2C burning data.");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
                else
                {
                    projectI2cCommitSpeed_15Error(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the device-defined I2C burning data is insufficient and cannot be parsed.");
                LogDebugData(readData);
            }
        }
        // 處理指令: 燒錄速率 - 【ERROR】的邏輯 - 0 = 0x00B3 ( I2C 預設速率 : 15nF / 62.5 KHz )
        private void projectI2cCommitSpeed_15Error(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device-defined I2C burning data method responded with【ERROR】, unable to define.");
            LogDebugData(readData);
        }

        // 發送指令: 燒錄速率 - 1 = 0x00B4 ( I2C 快速 : 10nF / 80.64 KHz )
        public void projectI2cCommitSpeed_10(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 定義 I2C 燒錄數據
                byte[] projectI2cCommitSpeedCommand_10 = new byte[] { 0x01, 0x00, 0x00, 0x00, 0xB4, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };

                if (targetDevice.Write(projectI2cCommitSpeedCommand_10))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        projectI2cCommitSpeed_10Data(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm Programming times with 10nF / 62.5 KHz!");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ .mif file does not match with project list after comparison.\r\n");
                    listBoxLogs.Items.Add($"[{DateTime.Now}] 　→ Programming times with 10nF ( Default ) !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define I2C burning data.");
            }
        }
        // 解析指令: 燒錄速率燒錄速率 - 1 = 0x00B4 ( I2C 快速 : 10nF / 80.64 KHz )
        private void projectI2cCommitSpeed_10Data(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {

                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Programming times with 10nF !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    LogDebugData(readData);

                    listBoxLogs.Items.Add($"[{DateTime.Now}] - The device successfully defined I2C burning data.");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
                else
                {
                    projectI2cCommitSpeed_10Error(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the device-defined I2C burning data is insufficient and cannot be parsed.");
                LogDebugData(readData);
            }
        }
        // 處理指令: 燒錄速率 - 【ERROR】的邏輯燒錄速率 - 1 = 0x00B4 ( I2C 快速 : 10nF / 80.64 KHz )
        private void projectI2cCommitSpeed_10Error(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device-defined I2C burning data method responded with【ERROR】, unable to define.");
            LogDebugData(readData);
        }

        // 發送指令: 燒錄速率 - 2 = 0x00B5 ( I2C 慢速 : 33nF / 38.46 KHz )
        public void projectI2cCommitSpeed_33(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 定義 I2C 燒錄數據
                byte[] projectI2cCommitSpeedCommand_33 = new byte[] { 0x01, 0x00, 0x00, 0x00, 0xB5, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };

                if (targetDevice.Write(projectI2cCommitSpeedCommand_33))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        projectI2cCommitSpeed_33Data(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm Programming times with 33nF / 62.5 KHz!");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ .mif file does not match with project list after comparison.\r\n");
                    listBoxLogs.Items.Add($"[{DateTime.Now}] 　→ Programming times with 33nF ( Default ) !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define I2C burning data.");
            }
        }
        // 解析指令: 燒錄速率 - 2 = 0x00B5 ( I2C 慢速 : 33nF / 38.46 KHz )
        private void projectI2cCommitSpeed_33Data(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {

                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Programming times with 33nF !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    LogDebugData(readData);
                    
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - The device successfully defined I2C burning data.");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
                else
                {
                    projectI2cCommitSpeed_33Error(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the device-defined I2C burning data is insufficient and cannot be parsed.");
                LogDebugData(readData);
            }
        }
        // 處理指令: 燒錄速率 - 【ERROR】的邏輯 - 2 = 0x00B5 ( I2C 慢速 : 33nF / 38.46 KHz )
        private void projectI2cCommitSpeed_33Error(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device-defined I2C burning data method responded with【ERROR】, unable to define.");
            LogDebugData(readData);
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        /// Search Target IC
        ///
        private void button_searchTargetIC_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 設備斷電
                PowerOff_Click(targetDevice);

                // 2. 設備給電
                PowerOn_Click(targetDevice);

                if (powerStatus.ToUpper() == "00")
                {
                    // 3. 傳送尋找 IC 的指令
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Send the command to search for the IC.");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    searchTargetIC(targetDevice);

                    // 設備斷電
                    PowerOff_Click(targetDevice);

                }
                else
                {
                    listBoxLogs.Items.Add("*********************************************************");
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - The device is not powered on: have something error!");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    powerStatus = "01";

                    // 設備斷電
                    PowerOff_Click(targetDevice);
                }

                /// 執行 Search IC，.mif 檔案資訊呈現紅色
                /// 
                this.label_mifVersion.ForeColor = System.Drawing.Color.Red;
                this.label_mifCRC.ForeColor = System.Drawing.Color.Red;

            }
            catch (Exception ex)
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - An【ERROR】occurred during the execution process: " + ex.Message);
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
            }
        }
        // 發送指令: Search Target IC
        public void searchTargetIC(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 清空所有版本和 CRC 顯示
                ClearLabelsText(new[] { label_Target_1_Version, label_Target_2_Version, label_Target_3_Version, label_Target_4_Version });
                ClearLabelsText(new[] { label_Target_1_CRC, label_Target_2_CRC, label_Target_3_CRC, label_Target_4_CRC });

                // 設置所有版本和 CRC 顯示顏色系統原黑色
                SetLabelsForeColor(new[] { label_Target_1_Version, label_Target_2_Version, label_Target_3_Version, label_Target_4_Version }, SystemColors.ControlText);
                SetLabelsForeColor(new[] { label_Target_1_CRC, label_Target_2_CRC, label_Target_3_CRC, label_Target_4_CRC }, SystemColors.ControlText);

                // 定義 Search Target IC
                byte[] searchTargetIC = new byte[] { 0x01, 0x00, 0x00, 0x00, 0xAD, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };

                if (targetDevice.Write(searchTargetIC))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        searchTargetIC_Data(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm the definition of Search Target IC.");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ Unable to confirm the definition of Search Target IC.");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define Search Target IC.");
            }
        }
        // 解析指令: Search Target IC
        private void searchTargetIC_Data(byte[] readData)
        {
            if (readData.Length < 256 || readData[11] != 0x00)
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the device-defined Search Target IC is insufficient or the response is【ERROR】, unable to parse.");
                LogDebugData(readData);

                return;
            }

            LogDebugData(readData);
            listBoxLogs.Items.Add($"[{DateTime.Now}] - Send the command for Search Target IC.");
            listBoxLogs.Items.Add("\r\n");
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

            // 系統回應: Byte 8 [00] 沒有任何 IC
            if (readData[8] == 0x00)
            {
                // 更新 UI 操作 - 清除 Target IC Labels Color
                clearTargetICLabelsColor(System.Drawing.Color.Gray);

                listBoxLogs.Items.Add($"[{DateTime.Now}] - Search Target IC : not find any Target IC !");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - find Target IC !");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                // IC info
                icInfo(targetDevice);
                // IC CRC
                icCRC(targetDevice);

                // 使用迴圈更新 IC 標籤狀態
                for (int i = 1; i <= 4; i++)
                {
                    Label versionLabel = GetLabel($"label_Target_{i}_Version");
                    Label crcLabel = GetLabel($"label_Target_{i}_CRC");

                    Label redLabel = GetLabel($"label_Target_{i}_Red");
                    Label greenLabel = GetLabel($"label_Target_{i}_Green");
                    Label bGreenLabel = GetLabel($"label_Target_{i}_BGreen");

                    if (versionLabel != null && crcLabel != null)
                    {
                        redLabel.Visible = false;
                        greenLabel.Visible = false;
                        bGreenLabel.Visible = true;
                    }
                    else
                    {
                        redLabel.Visible = true;
                        greenLabel.Visible = false;
                        bGreenLabel.Visible = false;
                    }
                }

                // Reading IC MTP status
                reading_IC_MTP_status(targetDevice);
            }
        }
        // 處理指令: Search Target IC - 【ERROR】的邏輯
        private void searchTargetIC_Error(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device-defined Search Target IC method responded with【ERROR】, unable to define.");
            LogDebugData(readData);
        }

        // 發送指令: IC info - Version
        public void icInfo(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 定義 IC info - Version
                byte[] icInfo_WriteData = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x13, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };


                if (targetDevice.Write(icInfo_WriteData))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        icInfo_Data(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm IC info - Version!");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ Unable to confirm IC info - Version!\r\n");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define IC info - Version.");
            }
        }
        // 解析指令: IC info - Version
        private void icInfo_Data(byte[] readData)
        {
            if (readData.Length < 256 || readData[11] != 0x00)
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the device-defined IC info - Version is insufficient or the response is【ERROR】, unable to parse.");
                LogDebugData(readData);
                return;
            }

            listBoxLogs.Items.Add($"[{DateTime.Now}] - IC info - Version\r\n");
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

            // 使用 for 迴圈來處理每個 IC 的版本資料
            for (int i = 0; i < 4; i++)
            {
                int dataIndex = 13 + (i * 2);
                Label targetVersionLabel = GetLabel($"label_Target_{i + 1}_Version");

                if (readData[dataIndex] != 0xFF || readData[dataIndex + 1] != 0xFF)
                {
                    int varVersion = Convert.ToInt32(readData[dataIndex].ToString("X2"), 16);
                    int varVersionSub = Convert.ToInt32(readData[dataIndex + 1].ToString("X2"), 16);
                    targetVersionLabel.Text = $"{varVersion}.{varVersionSub}";
                }
                else
                {
                    targetVersionLabel.Text = null;
                }
            }

            LogDebugData(readData);
            
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device successfully defined IC info - Version.");
            listBoxLogs.Items.Add("\r\n");
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
        }
        // 處理指令: IC info - Version - 【ERROR】的邏輯
        private void icInfo_Error(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device-defined IC info - Version method responded with【ERROR】, unable to define.");
            LogDebugData(readData);
        }

        // 發送指令: IC CRC
        public void icCRC(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 定義 IC info - Version
                byte[] icInfo_WriteData = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };


                if (targetDevice.Write(icInfo_WriteData))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        icCRC_Data(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm IC CRC!");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ Unable to confirm IC CRC!\r\n");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define IC CRC.");
            }
        }
        // 解析指令: IC CRC
        private void icCRC_Data(byte[] readData)
        {
            if (readData.Length < 256 || readData[11] != 0x00)
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the device-defined IC CRC is insufficient or the response is【ERROR】, unable to parse.");
                LogDebugData(readData);
                return;
            }

            listBoxLogs.Items.Add($"[{DateTime.Now}] - IC CRC\r\n");
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

            // 使用迴圈處理每個 IC 的 CRC 資料
            for (int i = 0; i < 4; i++)
            {
                int dataIndex = 13 + (i * 2);
                string crcValue = GetCRCValue(readData[dataIndex], readData[dataIndex + 1]);

                if (crcValue != "FFFF")
                {
                    Label targetCRCLabel = GetLabel($"label_Target_{i + 1}_CRC");
                    targetCRCLabel.Text = "0x" + crcValue;
                }
            }

            LogDebugData(readData);

            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device successfully defined IC CRC.");
            listBoxLogs.Items.Add("\r\n");
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
        }
        // 取得 CRC 值的函式
        private string GetCRCValue(byte highByte, byte lowByte)
        {
            return highByte.ToString("X2") + lowByte.ToString("X2");
        }
        // 處理指令: IC CRC - 【ERROR】的邏輯
        private void icCRC_Error(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device-defined IC CRC method responded with【ERROR】, unable to define.");
            LogDebugData(readData);
        }

        // 發送指令: Reading IC MTP status
        public void reading_IC_MTP_status(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 定義 IC info - Version
                byte[] icInfo_WriteData = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x12, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };


                if (targetDevice.Write(icInfo_WriteData))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        readingIC_MTPstatusData(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm Reading IC MTP status!");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ Unable to confirm Reading IC MTP status!\r\n");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define Reading IC MTP status.");
            }
        }
        // 解析指令: Reading IC MTP status
        private void readingIC_MTPstatusData(byte[] readData)
        {
            if (readData.Length < 256 || readData[11] != 0x00)
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the device-defined Reading IC MTP status is insufficient or the response is【ERROR】, unable to parse.");
                LogDebugData(readData);
                return;
            }

            listBoxLogs.Items.Add($"[{DateTime.Now}] - Reading IC MTP status\r\n");
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

            // 使用迴圈處理所有 Target IC 的狀態
            for (int i = 0; i < 4; i++)
            {
                int dataIndex = 13 + (i * 2);
                string status = GetMTPStatus(readData[dataIndex], readData[dataIndex + 1]);
                UpdateTargetLabels(i + 1, status);
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Target IC {i + 1}: {status}!");

                // 帶入 IC 可被使用的狀態
                string var_status = $"{readData[dataIndex + 1]:X2}";
                varReadingMTPstatus[i] = var_status; // 使用陣列來儲存狀態
                //MessageBox.Show(var_status);
            }

            LogDebugData(readData);
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device successfully defined Reading IC MTP status.\r\n");
            listBoxLogs.Items.Add("\r\n");
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
        }
        // 取得 MTP 狀態的函式，根據回應的值返回狀態描述
        private string GetMTPStatus(byte highByte, byte lowByte)
        {
            // highByte == 0x00;
            switch (lowByte)
            {
                case 0x06:
                    {
                        return "Read-Lock";
                    }
                case 0x0A: { return "Write-Lock"; }
                case 0x0E: { return "Read/Write-Lock"; }
                case 0x02: { return "Unlocked"; }
                case 0xFF: { return "No Response"; }// 針對 lowByte 為 0xFF 的情況
                default:
                    return "Unknown";
            }
        }
        // 更新指定 Target IC 標籤狀態的函式
        private void UpdateTargetLabels(int targetNumber, string status)
        {
            Label statusLabel = GetLabel($"label_Target_{targetNumber}_status");
            bool isLocked = status.Contains("Lock");
            bool isUnlocked = status == "Unlocked";
            bool isUnknown = status == "Unknown";
            bool isNoResponse = status == "No Response";

            statusLabel.ForeColor = isLocked || isUnlocked || isNoResponse ? System.Drawing.Color.Green : System.Drawing.Color.Gray;

            GetLabel($"label_Target_{targetNumber}_R").Visible = status == "Read-Lock" || status == "Read/Write-Lock";
            GetLabel($"label_Target_{targetNumber}_W").Visible = status == "Write-Lock" || status == "Read/Write-Lock";
            
            // 額外針對 "Unknown" 和 "No Response" 狀態設定
            GetLabel($"label_Target_{targetNumber}_UnR").Visible = isUnknown || isNoResponse || isUnlocked;
            GetLabel($"label_Target_{targetNumber}_UnW").Visible = isUnknown || isNoResponse || isUnlocked;

            // 確保在 Read-Lock 和 Write-Lock 狀態時，符合您的要求
            if (status == "Read-Lock")
            {
                GetLabel($"label_Target_{targetNumber}_R").Visible = true;
                GetLabel($"label_Target_{targetNumber}_UnW").Visible = true;
            }
            else if (status == "Write-Lock")
            {
                GetLabel($"label_Target_{targetNumber}_W").Visible = true;
                GetLabel($"label_Target_{targetNumber}_UnR").Visible = true;
            }
        }
        // 處理指令: Reading IC MTP status - 【ERROR】的邏輯
        private void readingIC_MTPstatusError(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device-defined Reading IC MTP status method responded with【ERROR】, unable to define.");
            LogDebugData(readData);
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        /// Program :: Write device
        ///
        private void buttonWriteDevice_Click(object sender, EventArgs e)
        {
            // 1. 確認 .mif 是否正確載入
            if (string.IsNullOrEmpty(labOpenReadMinFile.Text))
            {
                MessageBox.Show("Please Load .MIF!", "Load .MIF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // .mif 檔案的 版本號 以及 CRC 欄位顏色為紅色
                label_mifVersion.ForeColor = System.Drawing.Color.Red;
                label_mifCRC.ForeColor = System.Drawing.Color.Red;

                // 設置所有版本和 CRC 顯示顏色為系統原黑色
                SetLabelsForeColor(new[] { label_Target_1_Version, label_Target_2_Version, label_Target_3_Version, label_Target_4_Version }, SystemColors.ControlText);
                SetLabelsForeColor(new[] { label_Target_1_CRC, label_Target_2_CRC, label_Target_3_CRC, label_Target_4_CRC }, SystemColors.ControlText);

                // 設置所有狀態顯示顏色為灰色
                SetLabelsForeColor(new[] { label_Target_1_status, label_Target_2_status, label_Target_3_status, label_Target_4_status }, Color.Gray);

                // 隱藏所有紅綠燈顯示
                SetLabelsVisibility(new[] { label_Target_1_Green, label_Target_2_Green, label_Target_3_Green, label_Target_4_Green,
                                label_Target_1_Red, label_Target_2_Red, label_Target_3_Red, label_Target_4_Red }, false);

                // 顯示所有底色紅綠燈
                SetLabelsVisibility(new[] { label_Target_1_BGreen, label_Target_2_BGreen, label_Target_3_BGreen, label_Target_4_BGreen }, true);

                // 隱藏所有 R 和 W 狀態顯示
                SetLabelsVisibility(new[] { label_Target_1_R, label_Target_1_W, label_Target_2_R, label_Target_2_W,
                                label_Target_3_R, label_Target_3_W, label_Target_4_R, label_Target_4_W }, false);

                // 顯示所有未設定的 R 和 W 狀態
                SetLabelsVisibility(new[] { label_Target_1_UnR, label_Target_1_UnW, label_Target_2_UnR, label_Target_2_UnW,
                                label_Target_3_UnR, label_Target_3_UnW, label_Target_4_UnR, label_Target_4_UnW }, true);
                // ----------------------------------------------------------------------------------------------------------------------------------

                // 2. 設備斷電
                PowerOff_Click(targetDevice);

                // 3. 設備給電
                PowerOn_Click(targetDevice);

                if (powerStatus.ToUpper() == "00")
                {
                    // 4. Search Target IC
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Send the command to search for the IC.");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    searchTargetIC(targetDevice);

                    // 5. 檢查是否找到任何 Target IC
                    bool noICFound = true;
                    for (int i = 1; i <= 4; i++)
                    {
                        Label versionLabel = GetLabel($"label_Target_{i}_Version");
                        if (!string.IsNullOrEmpty(versionLabel.Text))
                        {
                            noICFound = false;
                            break;
                        }
                    }

                    // 5-1. 檢查是否找到任何 Target IC MTP status is Lock
                    bool isLockStatusFound = false;
                    for (int i = 0; i < 4; i++)
                    {
                        if ((varReadingMTPstatus[i] != "02") && (varReadingMTPstatus[i] != "FF"))
                        {
                            listBoxLogs.Items.Add($"[{DateTime.Now}] - Write Device_" + i + " - IC MTP status is : " + varReadingMTPstatus[i]);

                            isLockStatusFound = true;
                            break;
                        }
                    }

                    if (isLockStatusFound)
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Write Device : IC MTP status is Lock");
                        listBoxLogs.Items.Add("\r\n");
                        listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                        MessageBox.Show("IC MTP status is Lock. Cannot proceed with burning!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // 設備斷電
                        PowerOff_Click(targetDevice);

                        // 停止進行燒錄動作
                        return;
                    }
                    else if (noICFound)
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Write Device : Not find any Target IC");
                        listBoxLogs.Items.Add("\r\n");
                        listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    }
                    else
                    {
                        // 6. 檢查 IC 與 .mif 的版本號是否相同，並燒錄 IC
                        CheckTargetICVersions();
                    }

                }
                else
                {
                    powerStatus = "01";

                    listBoxLogs.Items.Add("*********************************************************");
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - The device is not powered on: have something error!");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }

                // 10. 設備斷電
                PowerOff_Click(targetDevice);
            }
        }
        // .mif 與 IC 的版本號比對 - 判斷邏輯的方法
        private bool CheckVersionMismatch(Label versionLabel, Label greenLabel, Label bGreenLabel, Label redLabel, Label statusLabel, Label crcLabel)
        {
            if (!string.IsNullOrEmpty(versionLabel.Text) && versionLabel.Text != label_mifVersion.Text)
            {
                bGreenLabel.Visible = true;
                greenLabel.Visible = false;
                redLabel.Visible = true;

                statusLabel.ForeColor = System.Drawing.Color.Red;
                versionLabel.ForeColor = System.Drawing.Color.Red;
                crcLabel.ForeColor = System.Drawing.Color.Red;

                return true; // 表示發生版本不匹配
            }
            return false;
        }
        // 開始燒錄 IC - .mif 與 IC 的版本號比對 - 判斷邏輯的方法
        private void CheckTargetICVersions()
        {
            bool versionMismatchFound = false;

            versionMismatchFound |= CheckVersionMismatch(label_Target_1_Version, label_Target_1_Green, label_Target_1_BGreen, label_Target_1_Red, label_Target_1_status, label_Target_1_CRC);
            versionMismatchFound |= CheckVersionMismatch(label_Target_2_Version, label_Target_2_Green, label_Target_2_BGreen, label_Target_2_Red, label_Target_2_status, label_Target_2_CRC);
            versionMismatchFound |= CheckVersionMismatch(label_Target_3_Version, label_Target_3_Green, label_Target_3_BGreen, label_Target_3_Red, label_Target_3_status, label_Target_3_CRC);
            versionMismatchFound |= CheckVersionMismatch(label_Target_4_Version, label_Target_4_Green, label_Target_4_BGreen, label_Target_4_Red, label_Target_4_status, label_Target_4_CRC);

            if (versionMismatchFound)
            {
                listBoxLogs.Items.Add("Target IC Status Have Something is Wrong !");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                MessageBox.Show("Target IC Status Have Something is Wrong ! Program / Write device STOP !", "Some thing is Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Program / Write device");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                // 7. 開始進行燒錄動作
                WriteDeviceIC(targetDevice);

                // Search Target IC
                searchTargetIC(targetDevice);

                // 8. 再次確認 IC 的 版本號/CRC 與 .mif 的版本號是否相同
                for (int i = 1; i <= 4; i++)
                {
                    Label versionLabel = GetLabel($"label_Target_{i}_Version");
                    Label greenLabel = GetLabel($"label_Target_{i}_Green");
                    Label bGreenLabel = GetLabel($"label_Target_{i}_BGreen");
                    Label redLabel = GetLabel($"label_Target_{i}_Red");
                    Label statusLabel = GetLabel($"label_Target_{i}_status");
                    Label crcLabel = GetLabel($"label_Target_{i}_CRC");

                    // 確保 versionLabel.Text 和 crcLabel.Text 都不為 null 或空白
                    if ((!string.IsNullOrEmpty(versionLabel.Text) && !string.IsNullOrEmpty(crcLabel.Text)) &&
                         ((versionLabel.Text == label_mifVersion.Text) && (crcLabel.Text == label_mifCRC.Text)))
                    {
                        // 比對成功
                        greenLabel.Visible = true;
                        bGreenLabel.Visible = true;
                        redLabel.Visible = false;
                        statusLabel.ForeColor = System.Drawing.Color.Green;
                        versionLabel.ForeColor = System.Drawing.Color.Blue;
                        crcLabel.ForeColor = System.Drawing.Color.Blue;

                        // 燒錄完畢 - .mif 檔案的 版本號 以及 CRC 欄位顏色為藍色
                        label_mifVersion.ForeColor = System.Drawing.Color.Blue;
                        label_mifCRC.ForeColor = System.Drawing.Color.Blue;

                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Write Target {i} IC is Finish !");
                        listBoxLogs.Items.Add("\r\n");
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(versionLabel.Text) && !string.IsNullOrEmpty(crcLabel.Text))
                        {
                            greenLabel.Visible = false;
                            bGreenLabel.Visible = true;
                            redLabel.Visible = true;
                            statusLabel.ForeColor = System.Drawing.Color.Red;
                            versionLabel.ForeColor = System.Drawing.Color.Red;
                            crcLabel.ForeColor = System.Drawing.Color.Red;

                            listBoxLogs.Items.Add($"[{DateTime.Now}] - 【ERROR】 - ❌ Write Target {i} IC  Have Something is Wrong !");
                            listBoxLogs.Items.Add("\r\n");
                        }
                        else
                        {
                            // 如果 versionLabel.Text 或 crcLabel.Text 為 null 或空白，則跳過該次比較
                            greenLabel.Visible = false;
                            bGreenLabel.Visible = true;
                            redLabel.Visible = false;
                            statusLabel.ForeColor = System.Drawing.Color.Gray;
                        }

                    }
                }
                // ----------------------------------------------------------------------------------------------------------------------------------

                // 9. 完成燒錄動作
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Write Target IC is Finish !");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                //MessageBox.Show("Read-Lock Integrate Circuits are finished !", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_OpenReadMinFile.Enabled = true;
                button_searchTargetIC.Enabled = true;
                button_eraseIC.Enabled = true;

                btn_saveLogs.Enabled = true;
                btn_clearLogs.Enabled = true;
            }

        }

        // 發送指令: Write Device IC
        public void WriteDeviceIC(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Write Target IC:");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                // ----------------------------------------------------------------------------------------------------------------------------------

                // 執行燒錄動作時候, 關閉不必要的按鈕
                btn_OpenReadMinFile.Enabled = false;
                button_searchTargetIC.Enabled = false;
                buttonWriteDevice.Enabled = false;

                button_eraseIC.Enabled = false;
                button_readLockIC.Enabled = false;
                button_writeLockIC.Enabled = false;

                btn_saveLogs.Enabled = true;
                btn_clearLogs.Enabled = true;

                button_PowerOn.Enabled = false;
                button_PowerOff.Enabled = true;
                // ----------------------------------------------------------------------------------------------------------------------------------

                for (int page = 11; page <= 31; page++)
                {
                    WritePage(targetDevice, page);

                    // 暫停, 避免 MCU 尚未處理完畢上一筆信息, 就被塞下一筆信息
                    System.Threading.Thread.Sleep(10);
                }
                
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define Write Device IC.");
            }
        }
        private void WritePage(HidDevice targetDevice, int pageNumber)
        {
            if (targetDevice == null)
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] targetDevice is null. Cannot write to page{pageNumber}.");
                return;
            }

            string varLabelMifPage = pageNumber.ToString("X4");
            string varPageByteInput = GetMifPageByteInput(pageNumber);

            // 計算 Page Date CRC
            string strMifPageCRC = teaCommand_3_1 + teaCommand_3_2 + varLabelMifPage + varPageByteInput;

            mifString = strMifPageCRC;

            var crcData = StringToByteArray(strMifPageCRC);  // 重新命名變數為 crcData
            var result = CRC16(crcData, 0, crcData.Length);
            string resultMifPageCRC = result.ToString("X4");

            byte byte1 = Convert.ToByte(icNum0_1, 16);
            byte byte2 = Convert.ToByte(icNum0_2, 16);
            byte byte3 = Convert.ToByte(teaCommand_3_1, 16);
            byte byte4 = Convert.ToByte(teaCommand_3_2, 16);
            byte byte5 = Convert.ToByte(varLabelMifPage.Substring(0, 2), 16);
            byte byte6 = Convert.ToByte(varLabelMifPage.Substring(2, 2), 16);
            byte byte7 = Convert.ToByte(varPageByteInput.Substring(0, 2), 16);
            byte byte8 = Convert.ToByte(varPageByteInput.Substring(2, 2), 16);
            byte byte9 = Convert.ToByte(resultMifPageCRC.Substring(0, 2), 16);
            byte byte10 = Convert.ToByte(resultMifPageCRC.Substring(2, 2), 16);
            byte byte11 = Convert.ToByte(varICstatus, 16);

            byte totalByte = (byte)(byte1 + byte2 + byte3 + byte4 + byte5 + byte6 + byte7 + byte8 + byte9 + byte10);
            byte totalByteChecksum = (byte)(0xFF - totalByte + 0x01);

            // 定義 Write Device IC
            byte[] pageWriteDeviceIC = new byte[] { 0x01, byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, byte9, byte10, byte11, totalByteChecksum };

            if (targetDevice.Write(pageWriteDeviceIC))
            {
                HidDeviceData responseData = targetDevice.Read(50);  // 重新命名變數為 responseData

                if (responseData.Status == HidDeviceData.ReadStatus.Success)
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - GUI Send page{pageNumber} : ");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    WriteDeviceIC_Data(responseData.Data);
                }
                else
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm page{pageNumber} Write Device IC");
                }
            }
            else
            {
                listBoxLogs.Items.Add($"\r\n[{DateTime.Now}] ❌ Unable to confirm page{pageNumber} Write Device IC.\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
            }
        }
        private string GetMifPageByteInput(int pageNumber)
        {
            switch (pageNumber)
            {
                case 8:
                    { return mif_page8_Byte_Input; }
                case 9:
                    { return mif_page9_Byte_Input; }
                case 10:
                    { return mif_page10_Byte_Input; }
                case 11:
                    { return mif_page11_Byte_Input; }
                case 12:
                    { return mif_page12_Byte_Input; }
                case 13:
                    { return mif_page13_Byte_Input; }
                case 14:
                    { return mif_page14_Byte_Input; }
                case 15:
                    { return mif_page15_Byte_Input; }
                case 16:
                    { return mif_page16_Byte_Input; }
                case 17:
                    { return mif_page17_Byte_Input; }
                case 18:
                    { return mif_page18_Byte_Input; }
                case 19:
                    { return mif_page19_Byte_Input; }
                case 20:
                    { return mif_page20_Byte_Input; }
                case 21:
                    { return mif_page21_Byte_Input; }
                case 22:
                    { return mif_page22_Byte_Input; }
                case 23:
                    { return mif_page23_Byte_Input; }
                case 24:
                    { return mif_page24_Byte_Input; }
                case 25:
                    { return mif_page25_Byte_Input; }
                case 26:
                    { return mif_page26_Byte_Input; }
                case 27:
                    { return mif_page27_Byte_Input; }
                case 28:
                    { return mif_page28_Byte_Input; }
                case 29:
                    { return mif_page29_Byte_Input; }
                case 30:
                    { return mif_page30_Byte_Input; }
                case 31:
                    { return mif_page31_Byte_Input; }
                default: return "Unsupported page number";
            }
        }
        // 解析指令: Write Device IC
        private void WriteDeviceIC_Data(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {
                    LogDebugData(readData);
                }
                else
                {
                    WriteDeviceICError(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The data length for the device-defined Write Device IC is insufficient and cannot be parsed.");
                LogDebugData(readData);
            }
        }
        // 處理指令: Write Device IC - 【ERROR】的邏輯
        private void WriteDeviceICError(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - The device-defined Write Device IC method responded with【ERROR】, unable to define.");
            LogDebugData(readData);
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        /// erase IC
        ///
        private void button_eraseIC_Click(object sender, EventArgs e)
        {
            if (powerStatus.ToUpper() == "00")
            {
                // Search Target IC
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Send command to find IC");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                searchTargetIC(targetDevice);
                // ----------------------------------------------------------------------------------------------------------------------------------

                if (((label_Target_1_Version.Text == null) || (label_Target_1_Version.Text == "")) &&
                          ((label_Target_2_Version.Text == null) || (label_Target_2_Version.Text == "")) &&
                          ((label_Target_3_Version.Text == null) || (label_Target_3_Version.Text == "")) &&
                          ((label_Target_4_Version.Text == null) || (label_Target_4_Version.Text == "")))
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - erase IC : Not find any Target IC");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                }
                else
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Erase IC ");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.Items.Add("*********************************************************");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    // ----------------------------------------------------------------------------------------------------------------------------------
                    
                    // erase IC
                    eraseIC(targetDevice);

                    btn_OpenReadMinFile.Enabled = true;
                    button_searchTargetIC.Enabled = true;
                    btn_saveLogs.Enabled = true;
                    btn_clearLogs.Enabled = true;

                }
            }
            else
            {
                listBoxLogs.Items.Add("*********************************************************");
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The device is not powered on: there is an error!");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                powerStatus = "01";
            }
        }
        // 發送指令: erase IC
        public void eraseIC(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 定義 erase IC
                byte[] eraseIC = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };


                if (targetDevice.Write(eraseIC))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        eraseIC_Data(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm erase IC");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ Unable to confirm erase IC.\r\n");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define erase IC.");
            }
        }
        // 解析指令: erase IC
        private void eraseIC_Data(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {
                    LogDebugData(readData);
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    // Search Target IC
                    searchTargetIC(targetDevice);

                    // 設備斷電
                    PowerOff_Click(targetDevice);
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    // 設置所有版本和 CRC 顯示顏色為綠色
                    SetLabelsForeColor(new[] { label_Target_1_Version, label_Target_2_Version, label_Target_3_Version, label_Target_4_Version }, Color.Green);
                    SetLabelsForeColor(new[] { label_Target_1_CRC, label_Target_2_CRC, label_Target_3_CRC, label_Target_4_CRC }, Color.Green);

                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Erase Integrate Circuits are finished !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    listBoxLogs.Items.Add("*********************************************************");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    MessageBox.Show("Erase Integrate Circuits are finished !", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    eraseICError(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The device definition for erase IC has insufficient data length and cannot be parsed.");
                LogDebugData(readData);
            }
        }
        // 處理指令: erase IC - 【ERROR】的邏輯
        private void eraseICError(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - Device definition for erase IC method - Response:【ERROR】, unable to define.");
            LogDebugData(readData);
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        /// read-Lock IC
        /// 
        private void button_readLockIC_Click(object sender, EventArgs e)
        {
            if (powerStatus.ToUpper() == "00")
            {
                // Search Target IC
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Send command to find the IC.");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                searchTargetIC(targetDevice);
                // ----------------------------------------------------------------------------------------------------------------------------------

                if (((label_Target_1_Version.Text == null) || (label_Target_1_Version.Text == "")) &&
                          ((label_Target_2_Version.Text == null) || (label_Target_2_Version.Text == "")) &&
                          ((label_Target_3_Version.Text == null) || (label_Target_3_Version.Text == "")) &&
                          ((label_Target_4_Version.Text == null) || (label_Target_4_Version.Text == "")))
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - read-Lock IC : Not find any Target IC");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                }
                else
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - read-Lock IC ");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.Items.Add("*********************************************************");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    // ----------------------------------------------------------------------------------------------------------------------------------

                    // read-Lock IC
                    readLockIC(targetDevice);

                    btn_OpenReadMinFile.Enabled = true;
                    button_searchTargetIC.Enabled = true;
                    btn_saveLogs.Enabled = true;
                    btn_clearLogs.Enabled = true;

                }
            }
            else
            {
                listBoxLogs.Items.Add("*********************************************************");
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The device is not powered on: have something error !");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                powerStatus = "01";
            }
        }
        // 發送指令: read-Lock IC
        public void readLockIC(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 定義 read-Lock IC
                byte[] readLockIC = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };


                if (targetDevice.Write(readLockIC))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        readLockIC_Data(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] Unable to confirm read-Lock IC");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ Unable to confirm read-Lock IC.\r\n");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define read-Lock IC.");
            }
        }
        // 解析指令: read-Lock IC
        private void readLockIC_Data(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {
                    LogDebugData(readData);
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    // Search Target IC
                    searchTargetIC(targetDevice);

                    // 設備斷電
                    PowerOff_Click(targetDevice);
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    // 設置所有版本和 CRC 顯示顏色為綠色
                    SetLabelsForeColor(new[] { label_Target_1_Version, label_Target_2_Version, label_Target_3_Version, label_Target_4_Version }, Color.Green);
                    SetLabelsForeColor(new[] { label_Target_1_CRC, label_Target_2_CRC, label_Target_3_CRC, label_Target_4_CRC }, Color.Green);

                    listBoxLogs.Items.Add($"[{DateTime.Now}] - Read-Lock Integrate Circuits are finished !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    listBoxLogs.Items.Add("*********************************************************");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    MessageBox.Show("Read-Lock Integrate Circuits are finished !", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    readLockICError(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The device definition for read-Lock IC has insufficient data length and cannot be parsed.");
                LogDebugData(readData);
            }
        }
        // 處理指令: read-Lock IC - 【ERROR】的邏輯
        private void readLockICError(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - Device definition for read-Lock IC method - Response:【ERROR】, unable to define.");
            LogDebugData(readData);
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

        /// writeLockIC
        /// 
        private void button_writeLockIC_Click(object sender, EventArgs e)
        {
            if (powerStatus.ToUpper() == "00")
            {
                // Search Target IC
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Send command to find the IC.");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                searchTargetIC(targetDevice);
                // ----------------------------------------------------------------------------------------------------------------------------------

                if (((label_Target_1_Version.Text == null) || (label_Target_1_Version.Text == "")) &&
                          ((label_Target_2_Version.Text == null) || (label_Target_2_Version.Text == "")) &&
                          ((label_Target_3_Version.Text == null) || (label_Target_3_Version.Text == "")) &&
                          ((label_Target_4_Version.Text == null) || (label_Target_4_Version.Text == "")))
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - write-Lock IC : Not find any Target IC");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                }
                else
                {
                    listBoxLogs.Items.Add($"[{DateTime.Now}] - write-Lock IC ");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.Items.Add("*********************************************************");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    // ----------------------------------------------------------------------------------------------------------------------------------

                    // write-Lock IC
                    writeLockIC(targetDevice);

                    btn_OpenReadMinFile.Enabled = true;
                    button_searchTargetIC.Enabled = true;
                    btn_saveLogs.Enabled = true;
                    btn_clearLogs.Enabled = true;

                }
            }
            else
            {
                listBoxLogs.Items.Add("*********************************************************");
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The device is not powered on: have something error !");
                listBoxLogs.Items.Add("\r\n");
                listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                powerStatus = "01";
            }
        }
        // 發送指令: write-Lock IC
        public void writeLockIC(HidDevice targetDevice)
        {
            if (targetDevice != null && isDeviceConnected)
            {

                // 定義 write-Lock IC
                byte[] writeLockIC = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };


                if (targetDevice.Write(writeLockIC))
                {
                    HidDeviceData data = targetDevice.Read(100);

                    if (data.Status == HidDeviceData.ReadStatus.Success)
                    {
                        writeLockIC_Data(data.Data);
                    }
                    else
                    {
                        listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to confirm write-Lock IC");
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("\r\n" + $"[{DateTime.Now}] ❌ Unable to confirm write-Lock IC.\r\n");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - Unable to send the command to define write-Lock IC.");
            }
        }
        // 解析指令: write-Lock IC
        private void writeLockIC_Data(byte[] readData)
        {
            if (readData.Length >= 256)
            {
                if (readData[11] == 0x00)
                {
                    LogDebugData(readData);
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    // Search Target IC
                    searchTargetIC(targetDevice);

                    // 設備斷電
                    PowerOff_Click(targetDevice);
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    // 設置所有版本和 CRC 顯示顏色為綠色
                    SetLabelsForeColor(new[] { label_Target_1_Version, label_Target_2_Version, label_Target_3_Version, label_Target_4_Version }, Color.Green);
                    SetLabelsForeColor(new[] { label_Target_1_CRC, label_Target_2_CRC, label_Target_3_CRC, label_Target_4_CRC }, Color.Green);

                    listBoxLogs.Items.Add($"[{DateTime.Now}] - write-Lock Integrate Circuits are finished !");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;

                    listBoxLogs.Items.Add("*********************************************************");
                    listBoxLogs.Items.Add("\r\n");
                    listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
                    // ----------------------------------------------------------------------------------------------------------------------------------

                    MessageBox.Show("write-Lock Integrate Circuits are finished !", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    writeLockICError(readData);
                }
            }
            else
            {
                listBoxLogs.Items.Add($"[{DateTime.Now}] - The device definition for write-Lock IC has insufficient data length and cannot be parsed.");
                LogDebugData(readData);
            }
        }
        // 處理指令: write-Lock IC - 【ERROR】的邏輯
        private void writeLockICError(byte[] readData)
        {
            listBoxLogs.Items.Add($"[{DateTime.Now}] - Device definition for write-Lock IC method - Response:【ERROR】, unable to define.");
            LogDebugData(readData);
        }
        // ----------------------------------------------------------------------------------------------------------------------------------

    }
}
