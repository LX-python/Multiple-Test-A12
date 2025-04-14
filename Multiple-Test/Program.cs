using Multiple_Test.Controller.CommandFroms;
using Multiple_Test.Controller.Home;
using Multiple_Test.Controller.Login;
using Multiple_Test.Controller.STM32;
using Multiple_Test.Controller.UIModels.HIPOT;
using Multiple_Test.Service.Files;
using Multiple_Test.Service.QRCode;
using Multiple_Test.Service.STM32;
using Multiple_Test.Utilities;
using Multiple_Test.Utilities.AES;
using NXP_TEA_IC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Multiple_Test
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


            // 获取命令行参数
            string[] args = Environment.GetCommandLineArgs();
                ProcessCommandLineArgs(args);
                Application.SetCompatibleTextRenderingDefault(false);
            //  Application.Run(new pageSTM32DownloadAutoScan7230());
            //Application.Run(new pageLogin());
            Application.Run(new FormGUI());
            // Application.Run(new pageLogin());
            //  Application.Run(new pageInputSerialNumber(5));
        }

        static byte CalculateLineChecksum(string data)
        {
            // Convert the data to bytes (excluding the checksum byte itself)
            byte[] bytes = Enumerable.Range(0, data.Length / 2 - 1)
                .Select(x => Convert.ToByte(data.Substring(x * 2, 2), 16))
                .ToArray();

            // Calculate the sum of bytes
            int sum = bytes.Sum(x => x);

            // Calculate the checksum (two's complement of the sum)
            byte checksum = (byte)((~sum + 1) & 0xFF);

            return checksum;
        }


        static void ProcessCommandLineArgs(string[] args)
        {
            for (int i = 1; i < args.Length; i++)
            {
                // 从 args[1] 开始，因为 args[0] 是应用程序路径
                string argument = args[i];
               // MessageBox.Show(argument);
                if (argument.ToLower().Trim() == "debugger=true")
                {
                    MessageBox.Show("Debugger 模式 即将输出完整日志");
                    LogSetting.Debugger = true;
                }

            }
        }


        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Unhandled Thread Exception");
            // 在这里可以进行日志记录等操作
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception)?.Message ?? "Unknown Error", "Unhandled UI Exception");
            // 在这里可以进行日志记录等操作
        }

    }
}
