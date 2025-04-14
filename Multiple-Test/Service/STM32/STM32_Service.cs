#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.STM32
 * 唯一标识：0b2cea7c-7791-4519-962b-c67875ded3a7
 * 文件名：STM32_Service
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/26 11:45:01
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/26 11:45:01
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Dal.Firware;
using Multiple_Test.Dal.Hipot;
using Multiple_Test.Models.API;
using Multiple_Test.Models.HIPOT;
using Multiple_Test.Service.Charts;
using Multiple_Test.Service.ChromaMES;
using Multiple_Test.Utilities.Constant;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Multiple_Test.Service.STM32
{
    public class STM32_Service
    {

        /// <summary>
        /// 注入sql 层
        /// </summary>
        FWDalMapper dal;
        public STM32_Service()
        {

            string path = Application.StartupPath + ConstantService.dbPath;
            dal = new FWDalMapper(path, ConstantService.dbName);
        }

        public long CalculateHexFileSize(string filePath, ref string message)
        {
            try
            {
                long totalSize = 0;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Length >= 11 && line.StartsWith(":"))
                        {
                            // 每行记录的数据长度位于第2和第3个字符位置
                            string lengthStr = line.Substring(1, 2);
                            int length = int.Parse(lengthStr, System.Globalization.NumberStyles.HexNumber);

                            // 如果是数据记录（记录类型为0x00），则计算总大小
                            if (line.Substring(7, 2) == "00")
                            {
                                totalSize += length;
                            }

                            // 计算校验和
                            int checksum = 0;
                            for (int i = 1; i < line.Length - 2; i += 2)
                            {
                                checksum += Convert.ToInt32(line.Substring(i, 2), 16);
                            }

                            // 取校验和的低8位的补码
                            checksum = (~checksum + 1) & 0xFF;

                            // 检查校验和是否正确
                            string checksumStr = line.Substring(line.Length - 2, 2);
                            int expectedChecksum = int.Parse(checksumStr, System.Globalization.NumberStyles.HexNumber);
                            if (checksum != expectedChecksum)
                            {
                                Console.WriteLine($"Error: Invalid checksum in line: {line}");
                                message = $"Error: Invalid checksum in line: {line}";
                                return -1;
                                // 可以选择终止程序，或者记录错误信息
                                // return -1;
                            }
                        }
                    }

                }
                return totalSize;
            }
            catch (Exception ex)
            {
                message = $"Error: {ex.Message}";
                return -1;
            }

        }

        public bool SubStringVersion(string InputString, ref string message)
        {
            message = string.Empty;
            // 使用下划线分割字符串
            string[] parts = InputString.Split('_');

            // 如果找到足够的部分
            if (parts.Length >= 3)
            {
                // 获取需要的部分
                string result = parts[2];

                // 如果需要去除括号和其他字符，可以进一步处理
                result = result.Split('(')[0];
                result = result.Trim();
                message = result;
                // message="PSU-FW"+ConvertTempData(result);
                return true;
            }
            else
            {
                message = "未找到匹配的子字符串";
                return false;
            }

        }
        /// <summary>
        /// /ConvertTempData
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private string ConvertTempData(string inputString)
        {
            string result = inputString;
            result = result.Replace("0", "-");
            // var dataTemp = result.Split('');
            var tempArr = new StringBuilder();
            string nowstr = string.Empty;
            string oldstr = string.Empty;
            for (int i = 0; i < result.Length; i++)
            {
                nowstr = result.Substring(i, 1);
                if (result.Length - 1 != i)
                {
                    if (nowstr != oldstr)
                    {
                        tempArr.Append("-" + nowstr);
                    }
                    else if (oldstr == "-")
                    {
                        tempArr.Append("0");
                    }
                }
                else
                {
                    tempArr.Append(nowstr);
                }
                oldstr = nowstr;
            }

            var tempdata = tempArr.ToString().Split('-');
            var resultTempData = new StringBuilder();
            for (int i = 0; i < tempdata.Length; i++)
            {
                if (tempdata[i].ToString() == "00")
                {
                    resultTempData.Append("-0");
                }
                else if (!string.IsNullOrEmpty(tempdata[i].ToString()))
                {
                    if (tempdata.Length - 1 == i)
                    {
                        resultTempData.Append("" + tempdata[i].ToString());
                    }
                    else
                    {
                        resultTempData.Append("-" + tempdata[i].ToString());
                    }

                }
            }
            return resultTempData.ToString();
        }


        /// <summary>
        /// Download FirmWare To Mcu
        /// </summary>
        /// <param name="CLIPath">ST-LINK Path</param>
        /// <param name="firmwarePath">Fw-Path</param>
        /// <param name="show">show Message</param>
        /// <returns></returns>
        public async Task<EntityResult> RunProcessAndGetOutputAsync(string CLIPath, string firmwarePath, UIRichTextBox show)
        {
            var result = new EntityResult();
            try
            {


                if (File.Exists(firmwarePath))
                {
                    string tempPath = Application.StartupPath + ConstantService.FwPath + @"\temp";
                    if (!Directory.Exists(tempPath))
                    {
                        Directory.CreateDirectory(tempPath);
                    }
                    //有文件就删除
                    var fwPath = tempPath + @"\temp.hex";
                    if (File.Exists(fwPath))
                    {
                        File.Delete(fwPath);
                    }
                    //写入临时文件
                    File.Copy(firmwarePath, fwPath, true);
                    string command = $"{CLIPath} -c port=SWD -d" +
                        $"  \"{fwPath}\" 0x08000000 -v";
                    FileLog.LogDebug("Command", command);
                    string message = string.Empty;
                    if (!File.Exists(CLIPath))
                    {

                        result.flag = false;
                        result.result = $"No Found Run {CLIPath}";
                        return result;
                    }

                    using (Process process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "cmd",
                            RedirectStandardInput = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    })
                    {
                        process.Start();

                        StreamReader reader = process.StandardOutput;
                        StreamWriter writer = process.StandardInput;
                        writer.WriteLine(command);
                        writer.WriteLine("exit");
                        //清空上次
                        show.BeginInvoke(new Action(() =>
                        {
                            show.Text = "";
                        }));
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            show.BeginInvoke(new Action(() =>
                            {

                                show.Text += line + "\r";
                                FileLog.LogInformation("Download", line + "\r");

                            }));

                            await Task.Delay(100);
                        }
                        process.WaitForExit();

                        //删除temp.hex
                        if (File.Exists(fwPath))
                        {
                            File.Delete(fwPath);
                        }
                        if (process.ExitCode == 0)
                        {
                            result.flag = true;
                            result.result = $"Flash completed successfully.";
                            FileLog.LogInformation("Download", "Flash completed successfully.");
                            return result;
                        }
                        else
                        {
                            FileLog.LogError("DownloadError", $"Error: Process exited with code {process.ExitCode}");
                            result.flag = false;
                            result.result = $"Error: Process exited with code {process.ExitCode}";
                            return result;
                        }


                    }
                }
                else
                {
                    result.flag = false;
                    result.result = $"Firmware file does not exist.";
                    return result;
                }
            }
            catch (Exception ex)
            {
                FileLog.LogError("DownloadError", ex.Message);
                result.flag = false;
                result.result = ex.Message;
                return result;
            }

        }




        /// <summary>
        /// Download FirmWare To Mcu
        /// </summary>
        /// <param name="CLIPath">ST-LINK Path</param>
        /// <param name="firmwarePath">Fw-Path</param>
        /// <param name="show">show Message</param>
        /// <returns></returns>
        public async Task<EntityResult> RunProcessVerifyFirmware(string CLIPath, string firmware_CheckSum, string Fwsize, UIRichTextBox show, UITextBox ReadCheckSum)
        {
            var result = new EntityResult();
            var StringValue = string.Empty;
            try
            {
                string command = $"{CLIPath} -c port=SWD freq=8000 -checksum 0x08000000 {Fwsize}";
                FileLog.LogDebug("Command", command);
                string message = string.Empty;
                if (!File.Exists(CLIPath))
                {

                    result.flag = false;
                    result.result = $"No Found Run {CLIPath}";
                    return result;
                }

                using (Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                })
                {
                    process.Start();

                    StreamReader reader = process.StandardOutput;
                    StreamWriter writer = process.StandardInput;
                    writer.WriteLine(command);
                    writer.WriteLine("exit");
                    //清空上次
                    show.BeginInvoke(new Action(() =>
                    {
                        show.Text = "";
                    }));

                    ReadCheckSum.BeginInvoke(new Action(() =>
                    {
                        ReadCheckSum.Text = "";
                    }));

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        show.BeginInvoke(new Action(() =>
                        {

                            // show.Text += line + "\r";
                            ChangesTextBoxColor(show, line + "\r", Color.White);
                            StringValue += line + "\r";
                            FileLog.LogInformation("Verify", line + "\r");
                        }));

                        await Task.Delay(100);
                    }
                    process.WaitForExit();
                     string mcu_CheckSum ="Not Read Checksum";
                    if (process.ExitCode == 0)
                    {

                       
                        // 找到 "Checksum" 字段的位置
                        int checksumIndex = StringValue.IndexOf("Checksum");

                        // 检查 "Checksum" 是否存在于字符串中
                        if (checksumIndex == -1)
                        {
                            //return null;
                        }
                        else
                        {
                            // 计算从 "Checksum" 字段开始的位置+3 是因为有三个字符
                            int startIndex = checksumIndex + "Checksum".Length + 3;
                            // 截取从 "Checksum" 字段开始后的15位字符
                            mcu_CheckSum = StringValue.Substring(startIndex, Math.Min(firmware_CheckSum.Length, StringValue.Length - startIndex));

                        }

                        if (StringValue.IndexOf($"Checksum : {firmware_CheckSum}") > -1 && firmware_CheckSum==mcu_CheckSum)
                        {
                            ChangesTextBoxColor(show, "", Color.LimeGreen);
                            ChangesTextBoxColor(ReadCheckSum, mcu_CheckSum, Color.LimeGreen);

                            FileLog.LogError("Verify", message);
                            result.flag = true;
                            result.result = $"Flash completed successfully.";
                            FileLog.LogInformation("Verify", "Flash completed successfully.");
                            return result;
                        }
                        else
                        {
                          

                          
                            message = $"CheckSum Failed -> Setting:CheckSum: {firmware_CheckSum} {mcu_CheckSum}";
                            ChangesTextBoxColor(show, "", Color.Red);
                            ChangesTextBoxColor(ReadCheckSum, mcu_CheckSum, Color.Red);
                            FileLog.LogError("Verify", message);
                            result.flag = false;
                            result.result =message;
                            return result;
                        }
                    }
                    else
                    {
                        message = $"Error: Process exited with code {process.ExitCode}";
                        message = $"版本错误 目标版本: {firmware_CheckSum}";
                        ChangesTextBoxColor(show, "", Color.Red);
                        ChangesTextBoxColor(ReadCheckSum, "Not Read CheckSum", Color.Red);
                        FileLog.LogError("Verify", message);
                        FileLog.LogError("Verify", message);
                        result.flag = false;
                        result.result = message;
                        return result;
                    }


                }

            }
            catch (Exception ex)
            {

                var message = $"Exception: {firmware_CheckSum}";
                ChangesTextBoxColor(show, "", Color.Red);
                ChangesTextBoxColor(ReadCheckSum, "Not Read CheckSum", Color.Red);
                FileLog.LogError("Verify", message);
                FileLog.LogError("DownloadError", ex.Message);
                result.flag = false;
                result.result = ex.Message;
                return result;
            }

        }


        private void ChangesTextBoxColor(UIRichTextBox show, string value, Color color)
        {
            show.ForeColor = color;
            show.BeginInvoke(new Action(() =>
           {
               show.Text += value;
           }));

        }


        private void ChangesTextBoxColor(UITextBox ReadCheckSum, string value, Color color)
        {
            ReadCheckSum.ForeColor = color;
            ReadCheckSum.BeginInvoke(new Action(() =>
           {
               ReadCheckSum.Text += value;
           }));

        }

        /// <summary>
        /// 插入测试数据
        /// </summary>
        /// <param name="TestData"></param>
        /// <returns></returns>
        public bool InsertTestRecord(object TestData)
        {
            return dal.InsertTestFwRecord(TestData);
        }

        /// <summary>
        /// InputSerialNumber Check
        /// </summary>
        /// <param name="ExitFlag"></param>
        /// <returns></returns>
        public async Task<EntityInputFlag> InputSerialNumber()
        {
            var re = new EntityInputFlag();
            // 创建 UIInputForm 对话框
            UIInputForm myUIInputForm = new UIInputForm();
            myUIInputForm.Text = "提示";
            myUIInputForm.Label.Text = "请输入產品序列號";
            if (myUIInputForm.ShowDialog() == DialogResult.OK)
            {
                string inputString = myUIInputForm.Editor.Text;
                if (string.IsNullOrEmpty(inputString))
                {
                    re.message = "没有输入内容";
                    return re;
                }


                //检查 MES SerialNumber Status
                string message = string.Empty;
                var status = MES_Service.CheckSerialNumber(inputString, ref message);
                if (status)
                {
                    re.message = inputString;
                    re.Flag = true;
                    return re;
                }
                else
                {  //测试载具不能用 Show Message
                   //ShowMessage(status.result);
                    re.Flag = false;
                    re.message = message;
                    return re;
                }
            }
            else
            {
                re.ExitFlag = true;
                re.message = "用户取消输入";
                re.Flag = false;
                return re; ;
            }
        }

        /// <summary>
        /// 获取测试产能
        /// </summary>
        /// <param name="uIBarChar"></param>
        /// <param name="PieChart"></param>
        public void Get_DayHoursTestRecord(ref UIBarChart uIBarChar, ref UIPieChart PieChart)
        {
            //BarChar
            var fail = dal.GetDayTestData(ConstantService.FAIL);
            var pass = dal.GetDayTestData(ConstantService.PASS);
            //表示没有数据
            if (fail.Rows.Count == 24 && pass.Rows.Count == 24)
            {
                ///datetime_hour	production_capacity

                var x = new List<string>();
                var y1_pass = new List<int>();
                var y2_fail = new List<int>();
                for (int i = 0; i < 24; i++)
                {
                    System.DateTime dateTime = System.DateTime.Parse(pass.Rows[i]["datetime_hour"].ToString());
                    // 格式化为只包含小时部分的字符串
                    string formattedHour = dateTime.ToString("HH:mm");
                    x.Add(formattedHour);
                    // x.Add(pass.Rows[i]["datetime_hour"].ToString());
                    y1_pass.Add(int.Parse(pass.Rows[i]["production_capacity"].ToString()));
                    y2_fail.Add(int.Parse(fail.Rows[i]["production_capacity"].ToString()));
                }
                ChartsPicService.Set_Production_BarChar(x, y1_pass, y2_fail, ref uIBarChar);
            }
            else
            {
                ChartsPicService.Set_Production_BarChar(ref uIBarChar);

            }
            //Pie
            var data = dal.GetDayTestRate();
            int failCount = int.Parse(data.Rows[0]["FailCount"].ToString());
            int passCount = int.Parse(data.Rows[0]["PassCount"].ToString());
            ChartsPicService.Set_PieTestData(failCount, passCount, ref PieChart);
        }
        private const uint STM32BaseAddress = 0x08000000;


        /// <summary>
        /// 计算STM32的Hex文件的校验和
        /// </summary>
        /// <param name="hexContent">Hex文件内容</param>
        /// <param name="startAddress">开始地址</param>
        /// <param name="size">大小</param>
        /// <returns>校验和</returns>
        public uint CalculateChecksum(string hexContent, uint startAddress, uint size)
        {
            uint checksum = 0;
            string[] lines = hexContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                if (line.StartsWith(":"))
                {
                    try
                    {
                        (uint lineAddress, byte[] bytes) = ParseHexLine(line);

                        // 检查当前行的地址范围是否在指定的startAddress和size范围内
                        if (lineAddress >= startAddress && lineAddress < (startAddress + size))
                        {
                            int startIndex = (int)(startAddress > lineAddress ? startAddress - lineAddress : 0);
                            int endIndex = (int)Math.Min(bytes.Length, startAddress + size - lineAddress);

                            for (int i = startIndex; i < endIndex; i++)
                            {
                                checksum += bytes[i];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
                    }
                }
            }

            return checksum;
        }

        /// <summary>
        /// 解析Hex文件的一行
        /// </summary>
        /// <param name="line">Hex文件的一行</param>
        /// <returns>行地址和字节数组</returns>
        private (uint lineAddress, byte[] bytes) ParseHexLine(string line)
        {
            // 检查行长度是否合法
            if (line.Length < 11)
            {
                throw new ArgumentException("Hex行长度不合法", nameof(line));
            }

            // 移除初始的冒号
            string hex = line.Substring(1);

            // 获取字节数
            int byteCount = Convert.ToInt32(hex.Substring(0, 2), 16);

            // 获取地址
            uint address = Convert.ToUInt32(hex.Substring(2, 4), 16);

            // 获取数据类型
            int recordType = Convert.ToInt32(hex.Substring(6, 2), 16);

            // 获取数据
            byte[] bytes = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(8 + i * 2, 2), 16);
            }

            // 检查数据类型，只有数据记录类型（0x00）有效
            if (recordType != 0x00)
            {
                throw new ArgumentException("Hex行数据类型不合法", nameof(line));
            }

            return (address, bytes);
        }
        /// <summary>
        /// 将字节数组中的字节值累加到校验和
        /// </summary>
        /// <param name="checksum">当前校验和</param>
        /// <param name="bytes">字节数组</param>
        /// <returns>更新后的校验和</returns>
        private uint AddBytesToChecksum(uint checksum, byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                checksum += b;
            }
            return checksum;
        }
    }
}
