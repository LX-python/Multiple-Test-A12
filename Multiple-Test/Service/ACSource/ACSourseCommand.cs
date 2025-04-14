#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.GPIB
 * 唯一标识：9cfb2db7-fd54-436a-b41d-07faba5204ad
 * 文件名：ACSourseCommand
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/15 10:21:08
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/15 10:21:08
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

namespace Multiple_Test.Service.GPIB.ACSource
{
    /// <summary>
    /// AC-Sourse 的相关指令
    /// </summary>
    public class ACSourseCommand
    {
        /// <summary>
        /// 查询仪器测量的交流（AC）功率。这个指令用于从支持该命令的仪器中获取交流功率测量结果
        /// </summary>
        public static string GetACPower = "MEAS:POW:AC?";
        /// <summary>
        /// 启动仪器
        /// </summary>
        public static string Set_AC_ON = "OUTP ON";
        /// <summary>
        /// 关闭仪器
        /// </summary>
        public static string Set_AC_OFF = "OUTP OFF";
        /// <summary>
        /// 初始化仪器
        /// </summary>
        public static string Set_AC_Init = "*CLS";
        /// <summary>
        /// 设置电压
        /// </summary>
        public static string Set_AC_VOLT = "VOLT {0}";
        /// <summary>
        /// 获取电压
        /// </summary>
        public static string Get_AC_VOLT = "VOLT?";
        /// <summary>
        /// 设置频率
        /// </summary>
        public static string Set_AC_FREQ = "FREQ {0}";
        /// <summary>
        /// 获取频率
        /// </summary>
        public static string Get_AC_FREQ = "FREQ?";

    }
}
