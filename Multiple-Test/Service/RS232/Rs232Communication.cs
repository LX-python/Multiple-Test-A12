#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.RS232
 * 唯一标识：3d064cfd-39d4-4c0c-81e8-5e6dc979d442
 * 文件名：Rs232Communication
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/6 10:53:26
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/6 10:53:26
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multiple_Test.Service.RS232
{
    public class Rs232Communication : IDisposable
    {
        private SerialPort _serialPort;

        public void Dispose()
        {
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                _serialPort.Dispose();
            }
        }
        /// <summary>
        /// 初始化窗口
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        public Rs232Communication(string portName, int baudRate)
        {
            _serialPort = new SerialPort(portName, baudRate);
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public void Open()
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
                Console.WriteLine($"Serial port {_serialPort.PortName} opened.");
            }
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                Console.WriteLine($"Serial port {_serialPort.PortName} closed.");
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data"></param>
        public void SendData(string data)
        {
            if (_serialPort.IsOpen)
            {
                FileLog.LogDebug("EquipmentCommand", $"{_serialPort.PortName}==> {data}");
                _serialPort.WriteLine(data);
      
            }
            else
            {
                FileLog.LogDebug("EquipmentCommand", $"{_serialPort.PortName}==> {data} ,Serial port is not open. Cannot send data.");
                Console.WriteLine("Serial port is not open. Cannot send data.");
            }
        }
        /// <summary>
        /// 读取返回数据
        /// </summary>
        /// <returns></returns>
        public string ReceiveData()
        {
            if (_serialPort.IsOpen)
            {
                
                string receivedData = _serialPort.ReadExisting();
                Console.WriteLine($"Received data: {receivedData}");
                FileLog.LogDebug("ReceiveData", $"{_serialPort.PortName} {receivedData}");
                return receivedData;
            }
            else
            {
                FileLog.LogDebug("ReceiveData", $"{_serialPort.PortName} \"Serial port is not open. Cannot receive data.\"");
                return string.Empty;
            }
        }

       

        //static void Main()
        //{
        //    Rs232Communication rs232 = new Rs232Communication("COM1", 9600);
        //    rs232.Open();

        //    rs232.SendData("Hello, RS232!");

        //    string receivedData = rs232.ReceiveData();
        //    Console.WriteLine($"Received: {receivedData}");

        //    rs232.Close();
        //}  
    }
}
