#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.GPIB
 * 唯一标识：a50d265e-509a-4004-9016-27ee7b8970b6
 * 文件名：DCLoadCommand
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/15 10:21:27
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/15 10:21:27
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

namespace Multiple_Test.Service.GPIB.DCLoad
{
    /// <summary>
    /// 电子负载的相关指令
    /// </summary>
    public class DCLoadCommand
    {

        public DCLoadCommand() { }

        /// <summary>
        /// 获取当前的的DC-Load 模式
        /// </summary>
        public static string Get_NowMode = "MODE?";

        /// <summary>
        /// 设置DC-Load 为CC 模式(定电流模式)
        /// CC 模式下操作时，VFD 示 CC 模式。
        /// CC 模式高档位
        /// </summary>
        public static string Set_DC_Mode_is_CCH = "MODE CCH";
        /// <summary>
        /// 设置DC-Load 为CC 模式(定电流模式)
        /// CC 模式下操作时，VFD 示 CC 模式。
        /// CC 模式下的低档位
        /// </summary>
        public static string Set_DC_Mode_is_CCL = "MODE CCL";

        /// <summary>
        /// 设置DC-Load 为CC 模式(定电流模式)
        /// CC 模式下操作时，VFD 示 CC 模式。
        /// CC 模式下的 动态模式下的低档位
        /// </summary>
        public static string Set_DC_Mode_is_CCDL = "MODE CCDL";
        /// <summary>
        /// 设置DC-Load 为CC 模式(定电流模式)
        /// CC 模式下操作时，VFD 示 CC 模式。
        /// CC 模式下的 动态下的高档位
        /// </summary>
        public static string Set_DC_Mode_is_CCDH = "MODE CCDH";
        /// <summary>
        /// 设置DC-Load 为CR 模式(定电组模式)
        /// CR 模式下操作时，VFD 示 CR 模式。
        /// 设定CR 模式的低挡位
        /// </summary>
        public static string Set_DC_Mode_is_CRL = "MODE CRL";
        /// <summary>
        /// 设置DC-Load 为CR 模式(定电组模式)
        /// CR 模式下操作时，VFD 示 CR 模式。
        /// 设定CR 模式的高挡位
        /// </summary>
        public static string Set_DC_Mode_is_CRH = "MODE CRH";

        /// <summary>
        /// 设置DC-Load 为CV 模式(定电压模式)
        /// CV 模式下操作时，VFD 示 CV 模式。
        /// CV 模式的低挡位
        /// </summary>
        public static string Set_DC_Mode_is_CVL = "MODE CVL";
        /// <summary>
        /// 设置DC-Load 为CV 模式(定电压模式)
        /// CV 模式下操作时，VFD 示 CV 模式。
        /// CV 模式的高挡位
        /// </summary>
        public static string Set_DC_Mode_is_CVH = "MODE CVH";


        /// <summary>
        /// 设置DC-Load 为CP 模式(定功率模式)
        /// CP 模式下操作时，VFD 示 CP 模式。
        /// CP 模式的低挡位
        /// </summary>
        public static string Set_DC_Mode_is_CPL = "MODE CPL";

        /// <summary>.
        /// 
        /// 设置DC-Load 为CP 模式(定功率模式)
        /// CP 模式下操作时，VFD 示 CP 模式。
        /// CP 模式的高挡位
        /// </summary>
        public static string Set_DC_Mode_is_CPH = "MODE CPH";

        /// <summary>
        /// 设置DC-Load 为CZ 模式(阻抗模式)
        /// CZ 模式下操作时，VFD 示 CZ 模式。
        /// CZ 模式的低挡位
        /// </summary>
        public static string Set_DC_Mode_is_CZL = "MODE CZL";
        /// <summary>
        /// 设置DC-Load 为CZ 模式(阻抗模式)
        /// CZ 模式下操作时，VFD 示 CZ 模式。
        /// CZ 模式的高挡位
        /// </summary>
        public static string Set_DC_Mode_is_CZH = "MODE CZH";

        /// <summary>
        /// 设定Load 通 (1---10)
        /// </summary>
        public static string Set_Channel = $"CHAN {0}";
        /// <summary>
        /// 设定 正玄波动模式的频率
        /// </summary>
        public static string Set_DC_FREQ = $"ADV:SINE:FREQ {0}";
        /// <summary>
        /// 设定 正玄波动模式的频率(最大值)
        /// </summary>
        public static string Set_DC_FREQ_MAX = $"ADV:SINE:FREQ MAX {0}";
        /// <summary>
        ///  设定 正玄波动模式的频率(最小值)
        /// </summary>
        public static string Set_DC_FREQ_MIN = $"ADV:SINE:FREQ MIN {0}";
        /// <summary>
        /// 获取正玄波动模式的频率
        /// </summary>
        public static string Get_FREQ = "ADV:SINE:FREQ?";
        /// <summary>
        /// 获取正玄波动模式的频率(最大值)
        /// </summary>
        public static string Get_FREQ_MAX = "ADV:SINE:FREQ? MAX";
        /// <summary>
        /// 获取正玄波动模式的频率(最小值)
        /// </summary>
        public static string Get_FREQ_MIN = "ADV:SINE:FREQ? MIN";

        /// <summary>
        /// 设定CC 模式下的电流
        /// </summary>
        public static string Set_DC_Current_L1 = $"CURR:STAT:L1 {0}";
        /// <summary>
        /// 设定CC 模式下的电流
        /// </summary>
        public static string Set_DC_Current_L2 = $"CURR:STAT:L2 {0}";
        /// <summary>
        /// 获取CC 模式下的电流
        /// </summary>
        public static string Get_DC_Current_L1 = $"CURR:STAT:L1?";
        /// <summary>
        /// 获取CC 模式下的电流
        /// </summary>
        public static string Get_DC_Current_L2 = $"CURR:STAT:L2?";
        /// <summary>
        /// 设定完成后开启 DC-LOAD
        /// </summary>
        public static string Set_DC_LOAD_ON = "LOAD ON";

        /// <summary>
        /// 初始化完成后关闭 DC-LOAD
        /// </summary>
        public static string Set_DC_LOAD_OFF = "LOAD OFF";
    }
}
