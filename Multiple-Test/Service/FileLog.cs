#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service
 * 唯一标识：d33adc4d-d77b-4b00-b21b-234663b10566
 * 文件名：FileLog
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/13 15:56:48
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/13 15:56:48
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Utilities;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service
{
    public static class FileLog
    {
        private static string IsLog = "true";
        private readonly static object lockObj = new object();
        private static bool win = true;
        private static bool linux = false;
        static FileLog()
        {

        }

        /// <summary>
        /// 写入日志 如果有新的日志迭代 日志只保留90 天
        /// </summary>
        /// <param name="type">日志类型</param>
        /// <param name="msg">日志信息</param>
        public static void WriteLog(string type, string msg)
        {
            if (linux)
            {
                type = type.Replace("\\", "/");
            }
            msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   |" + msg;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            path = Path.Combine(path, type);

            string fileName = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".log");

            // 创建目录（如果不存在）
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            lock (lockObj)
            {
                if (bool.Parse(IsLog))
                {
                    // 删除旧的日志文件（保留最近90天）
                    string[] oldLogFiles = Directory.GetFiles(path, "*.log")
                        .Where(filePath => Path.GetFileNameWithoutExtension(filePath).Length == 8) // 确保文件名为yyyyMMdd格式
                        .OrderByDescending(filePath => filePath)
                        .Skip(10) // 保留最新的10个文件
                        .ToArray();

                    foreach (string oldLogFile in oldLogFiles)
                    {
                        File.Delete(oldLogFile);
                    }

                    // 写入新的日志消息
                    using (StreamWriter writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(msg);
                    }
                }
            }
        }

        /// <summary>
        /// 写入日志 如果有新的日志迭代 日志只保留90 天
        /// </summary>
        /// <param name="type">日志类型</param>
        /// <param name="msg">日志信息</param>
        public static void WriteErrorLog(string type, string msg)
        {
            if (linux)
            {
                type = type.Replace("\\", "/");
            }
            msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   |" + msg;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Error");
            path = Path.Combine(path, type);
            string fileName = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".txt");

            // 创建目录（如果不存在）
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            lock (lockObj)
            {
                if (bool.Parse(IsLog))
                {
                    // 删除旧的日志文件（保留最近90天）
                    string[] oldLogFiles = Directory.GetFiles(path, "*.log")
                        .Where(filePath => Path.GetFileNameWithoutExtension(filePath).Length == 8) // 确保文件名为yyyyMMdd格式
                        .OrderByDescending(filePath => filePath)
                        .Skip(10) // 保留最新的10个文件
                        .ToArray();

                    foreach (string oldLogFile in oldLogFiles)
                    {
                        File.Delete(oldLogFile);
                    }

                    // 写入新的日志消息
                    using (StreamWriter writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(msg);
                    }
                }
            }
        }

        /// <summary>
        /// 写入错误的日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        public static void LogError(string type, string msg)
        {
            if (linux)
            {
                type = type.Replace("\\", "/");
            }
            msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   |" + msg;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Error");
            path = Path.Combine(path, type);

            string fileName = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".log");

            // 创建目录（如果不存在）
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            lock (lockObj)
            {
                if (bool.Parse(IsLog))
                {
                    // 删除旧的日志文件（保留最近90天）
                    string[] oldLogFiles = Directory.GetFiles(path, "*.log")
                        .Where(filePath => Path.GetFileNameWithoutExtension(filePath).Length == 8) // 确保文件名为yyyyMMdd格式
                        .OrderByDescending(filePath => filePath)
                        .Skip(10) // 保留最新的10个文件
                        .ToArray();

                    foreach (string oldLogFile in oldLogFiles)
                    {
                        File.Delete(oldLogFile);
                    }

                    // 写入新的日志消息
                    using (StreamWriter writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(msg);
                    }
                }
            }
        }



        /// <summary>
        /// 写入调试的日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        public static void LogDebug(string type, string msg)
        {
            if (!LogSetting.Debugger) 
            {
                return;
            }

            if (linux)
            {
                type = type.Replace("\\", "/");
            }
            msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   |" + msg;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Debug");
            path = Path.Combine(path, type);

            string fileName = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".log");

            // 创建目录（如果不存在）
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            lock (lockObj)
            {
                if (bool.Parse(IsLog))
                {
                    // 删除旧的日志文件（保留最近90天）
                    string[] oldLogFiles = Directory.GetFiles(path, "*.log")
                        .Where(filePath => Path.GetFileNameWithoutExtension(filePath).Length == 8) // 确保文件名为yyyyMMdd格式
                        .OrderByDescending(filePath => filePath)
                        .Skip(10) // 保留最新的10个文件
                        .ToArray();

                    foreach (string oldLogFile in oldLogFiles)
                    {
                        File.Delete(oldLogFile);
                    }

                    // 写入新的日志消息
                    using (StreamWriter writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(msg);
                    }
                }
            }
        }

        /// <summary>
        /// LogShow
        /// </summary>
        /// <param name="str"></param>
        /// <param name="color"></param>
        /// <param name="line"></param>
        public static void LogShow(string str,Color color,ref UILine line) 
        {
            line.Text = str;
            line.ForeColor = color;
            LogInformation("Runing",str);       
        }

        /// <summary>
        /// 写入常规的信息日志
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="msg">msg</param>
        public static void LogInformation(string type, string msg)
        {
            if (linux)
            {
                type = type.Replace("\\", "/");
            }
            msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "   |" + msg;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Information");
            path = Path.Combine(path, type);

            string fileName = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".log");

            // 创建目录（如果不存在）
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            lock (lockObj)
            {
                if (bool.Parse(IsLog))
                {
                    // 删除旧的日志文件（保留最近90天）
                    string[] oldLogFiles = Directory.GetFiles(path, "*.log")
                        .Where(filePath => Path.GetFileNameWithoutExtension(filePath).Length == 8) // 确保文件名为yyyyMMdd格式
                        .OrderByDescending(filePath => filePath)
                        .Skip(10) // 保留最新的10个文件
                        .ToArray();

                    foreach (string oldLogFile in oldLogFiles)
                    {
                        File.Delete(oldLogFile);
                    }

                    // 写入新的日志消息
                    using (StreamWriter writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(msg);
                    }
                }
            }
        }
    }
}
