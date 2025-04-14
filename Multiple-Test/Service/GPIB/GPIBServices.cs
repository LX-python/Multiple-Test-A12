#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.GPIB
 * 唯一标识：829d7426-fde0-43b6-bd27-9a3c437a1369
 * 文件名：GPIBServices
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/13 15:53:37
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/13 15:53:37
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Ivi.Visa.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using IMessage = Ivi.Visa.Interop.IMessage;
using ResourceManager = Ivi.Visa.Interop.ResourceManager;

namespace Multiple_Test.Service.GPIB
{
    public class GPIBServices
    {
        FormattedIO488 gpib = new FormattedIO488();
        ResourceManager rm = new ResourceManager();

        public GPIBServices()
        {

        }

        /// <summary>
        /// WriteString
        /// </summary>
        /// <param name="txtName">txtName</param>
        /// <param name="txtAddress">txtAddress</param>
        /// <param name="Command">Command</param>
        /// <returns></returns>
        public string WriteString(string txtName, string txtAddress, string Command)
        {
            try
            {
                if (ConnectGPIB(txtName, txtAddress))
                {

                    gpib.WriteString(Command);

                   return gpib.ReadString();

                }

                return "GPIB Connect Failed!";
            }
            catch (Exception ex)
            {

                FileLog.WriteErrorLog("GPIBConnectError", $"GPIB Connect Error!{ex.Message}");
                return $"GPIB Connect Error!{ex.Message}";
            }

        }

        /// <summary>
        /// 返回结果值
        /// </summary>
        /// <returns></returns>
        public Bools ReadString()
        {
            var respoense = new Bools();
            try
            {
                string str = gpib.ReadString();
                if (!string.IsNullOrEmpty(str))
                {
                    respoense.flag = true;
                    respoense.message = str;

                }
            }
            catch (Exception ex)
            {
                respoense.message = ex.Message;
              
            }

            return respoense;

        }
        /// <summary>
        /// ConnectGPIB
        /// </summary>
        /// <param name="txtName"></param>
        /// <param name="txtAddress"></param>
        /// <returns></returns>
        public bool ConnectGPIB(string txtName, string txtAddress)
        {
            try
            {

                if (string.IsNullOrEmpty(txtName))
                {
                    FileLog.WriteLog("OpenGPIB", "GPIP Name IS null");
                    return false;
                }
                string resourceName = $"{txtName}::{txtAddress}::INSTR";
                gpib.IO = (IMessage)rm.Open(resourceName, AccessMode.NO_LOCK, 5000, "");
                return true;
            }
            catch (Exception ex)
            {
                FileLog.WriteErrorLog("dllFailed", ex.Message);
            }
            return false;
        }


        public string getCardList(string txtName, string txtAddress, string Command)
        {

            string result = "";
            try
            {
                if (ConnectGPIB(txtName, txtAddress))
                {
                    //gpib.WriteString("*IDN?");
                    gpib.WriteString(Command);
                    result = gpib.ReadString();

                }
            }
            catch (Exception ex)
            {

                FileLog.WriteErrorLog("dllFailed", $"Name:{txtName} ,Address:{txtAddress},Command:{Command} {ex.Message} ");
            }
            return result;
        }

        public List<string> getGPIBList(string cmd = "gpib?*INSTR")
        {
            List<string> result = new List<string>();


            try
            {
                /// ?*INTFC 固定GPIB类型
                var results = rm.FindRsrc(cmd);
                if (results.Count() > 0)
                {
                    foreach (var item in results)
                    {
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                FileLog.WriteErrorLog("dllFailed", ex.Message);
                // FileLog.WriteErrorLog("dllFailed", $"Name:{txtName} ,Address:{txtAddress},Command:{Command}
            }

            return result;
        }


        /// <summary>
        /// getGPIBList
        /// </summary>
        /// <returns></returns>
        public List<string> getGPIBList()
        {
            List<string> result = new List<string>();


            try
            {
                /// ?*INTFC 固定GPIB类型
                var results = rm.FindRsrc("?*INTFC");
                if (results.Count() > 0)
                {
                    foreach (var item in results)
                    {
                        result.Add(item.ToString().Split(':')[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                FileLog.WriteErrorLog("dllFailed", ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Get GpibNamegetChildrenList
        /// </summary>
        /// <param name="GpibName"></param>
        public void getMasterList(string GpibName)
        {
            var rm = new ResourceManager();
            var resources = rm.FindRsrc($"{GpibName}::*INSTR");

            Console.WriteLine($"Found {resources.Length} resources on GPIB0:");
            foreach (var res in resources)
            {
                Console.WriteLine(res);
            }
            Marshal.ReleaseComObject(rm);
        }

        public void getEquipmentSerialNumber()
        {

        }

    }
}
