using ASI_Multiple_Test.Controller.Upgrades;
using Multiple_Test.Models.API;
using Multiple_Test.Service;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Controller.Upgrades
{
     public partial class UpgradesService:UIForm
    {
        private const string programName = "Mulitple_Test.zip";
        private static string newVersion = Application.ProductVersion;
        //类内部定义委托 
        public delegate void ErrorHandler(string type, string ErrorMessage);
        public delegate void SuccessHandler(double progress);
        // 声明事件
        public event ErrorHandler OnError;
        public event SuccessHandler OnSuccess;
        public UpgradesService()
        {

        }

        /// <summary>
        /// 检查版本
        /// </summary>
        /// <returns></returns>
        public static async Task<(string error_message,string newVersion,bool flag)> CheckVersionAsync()
        {
            string url = $"{APISRC.API}{APIConstant.GetIotBinVersion}?FielName={programName}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 发送 GET 请求
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // 确保响应成功

                    // 读取响应内容
                    string version = await response.Content.ReadAsStringAsync();
                    if (version != Application.ProductVersion) 
                    {
                        newVersion = version;
                        return (string.Empty,version,true);
                    }
                     return (string.Empty, version, false); ; // 返回版本号
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"请求失败: {e.Message}");
                    return ($"请求失败: {e.Message}", "", false); ; // 返回版本号
                }
            }
            //2.更新版本
        }

        public  void DownloadFileWithProgress()
        {
            try
            {
                string url = $"{APISRC.API}{APIConstant.DownloadIoTbin}?FielName={programName}&Version={newVersion}";
                string tempDir = Path.Combine(Directory.GetCurrentDirectory(), "temp");
                string filePath = Path.Combine(tempDir, "Multiple_Test.zip");
                // 创建 temp 目录
                Directory.CreateDirectory(tempDir);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    long totalBytes = response.ContentLength;
                    long totalReadBytes = 0;

                    using (Stream responseStream = response.GetResponseStream())
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[8192];
                        int readBytes;

                        while ((readBytes = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, readBytes);
                            totalReadBytes += readBytes;

                            if (totalBytes > 0)
                            {
                                double progress = (double)totalReadBytes / totalBytes * 100;
                                Console.WriteLine($"下载进度: {progress:F2}%");
                              
                                OnSuccess?.Invoke(progress);
                               // CreateBatchFile();
                            }
                        }
                    }
                }

                Console.WriteLine("下载完成。");
              
                OnSuccess?.Invoke(100f);
                CreateBatchFile();

            }
            catch (Exception ex)
            {
                FileLog.WriteErrorLog("update Error",ex.Message);
                OnError?.Invoke("update Error", ex.Message);
            }
          
        }
        /// <summary>
        /// 创建BAT 脚本 此方法不兼容win7 如果需要使用
        /// "C:\Program Files\7-Zip\7z.exe" x "D:\path\to\your\file.zip" -o"D:\path\to\output\directory"
        /// 光宝IT 要求系统必须是win10/11 因此不需要考虑使用7z Power Shell  so .only using
        /// </summary>
        static void CreateBatchFile()
        {
            string tempDir = Path.Combine(Directory.GetCurrentDirectory(), "temp");
            string batchFilePath = Path.Combine(tempDir, "run.bat");
            string programDir = Directory.GetCurrentDirectory(); // 程序目录

            string batchContent = $@"
                @echo off
                timeout 3
                taskkill /im Multiple-Test.exe /f 
                REM 解压缩 zip 文件
                {Path.Combine(Directory.GetCurrentDirectory(), "lib", "7-Zip", "7z.exe")} x {Path.Combine(programDir, "temp", "Multiple_Test.zip")}  -o{programDir} -y
                REM 删除 temp 目录
                rem rmdir /s /q ""{tempDir}"" 
                REM 启动主程序
                start """" ""{Path.Combine(programDir, "Multiple-Test.exe")}""
                pause ";

            File.WriteAllText(batchFilePath, batchContent);
            Console.WriteLine("批处理文件创建完成。");
            ExecuteBatchFile(batchFilePath);

        }

        /// <summary>
        /// 执行软件 并退出
        /// </summary>
        /// <param name="batchFilePath"></param>
        static void ExecuteBatchFile(string batchFilePath)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = batchFilePath,
                UseShellExecute = false,
                CreateNoWindow = true
            });
            Console.WriteLine("批处理文件已执行。");
            Environment.Exit(0);
        }

        /// <summary>
        /// 自动检查版本功能
        /// </summary>
        /// <returns></returns>
        public  async Task CheckVersion() 
        {
            while (true)
            {
                try
                {
                    var serverVersion = await UpgradesService.CheckVersionAsync();
                    if (serverVersion.flag)
                    {
                        if (this.ShowAskDialog($"有新版本:{serverVersion.newVersion},您是否要更新呢？"))
                        {
                           var frm= new FrmUpgrades();
                            frm.ShowDialog();
                        }
                    }
                    else if (!string.IsNullOrEmpty(serverVersion.error_message))
                    {

                        this.ShowErrorDialog(serverVersion.error_message);
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    FileLog.LogError("CheckVersion",ex.Message);
                   
                }
                await Task.Delay(1000*60*6);
            }
        }
    }
}
