#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.GPIB
 * 唯一标识：ceadb19f-6d94-4818-a8bf-d0407968d76f
 * 文件名：OcilliscopeCommand
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/20 10:27:57
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/20 10:27:57
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.GPIB.Ocilliscope
{
    /// <summary>
    /// 示波器的相关指令
    /// </summary>
    public class OcilliscopeCommand
    {

        public OcilliscopeCommand() { }

        /// <summary>
        /// 启动设备
        /// </summary>
        public static string Set_Machine_ON = "ACQ:STATE ON";
        /// <summary>
        /// 停止设备
        /// </summary>
        public static string Set_Machine_OFF = "ACQ:STATE OFF";
        /// <summary>
        /// 选择通道
        /// </summary>
        public static string Set_Machine_CHAN_ON = "SELECT:CH{0} ON";
        /// <summary>
        /// 关闭通道
        /// </summary>
        public static string Set_Machine_CHAN_OFF = "SELECT:CH{0} OFF";

    }
}
