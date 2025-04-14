#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Utilities
 * 唯一标识：808c6d6d-08da-463f-a2ac-036f959f38c6
 * 文件名：SystemInfo
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/2/22 11:30:29
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/2/22 11:30:29
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Utilities
{
    public class SystemInfo
    {
        public static List<string> getIpaddress() 
        {
            var reobj=new List<string>();   
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface netInterface in networkInterfaces)
            {
                // 排除非物理和非运行状态的接口
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    netInterface.OperationalStatus == OperationalStatus.Up)
                {
                    // 获取该接口的 IP 属性集合
                    IPInterfaceProperties ipProperties = netInterface.GetIPProperties();

                    // 循环遍历该接口的每个 IP 地址
                    foreach (UnicastIPAddressInformation ip in ipProperties.UnicastAddresses)
                    {
                        // 过滤出 IPv4 地址
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine($"网卡名称：{netInterface.Name}");
                            Console.WriteLine($"IPv4 地址：{ip.Address}");
                            reobj.Add( ip.ToString() );
                        }
                    }
                }
            }
            return reobj;
        }

    }
}
