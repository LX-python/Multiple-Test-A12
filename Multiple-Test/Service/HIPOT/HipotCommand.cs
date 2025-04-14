#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.HIPOT
 * 唯一标识：ab4c8407-c7bc-4130-8c47-abb5b2c883c5
 * 文件名：HipotCommand
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/3 16:12:43
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/3 16:12:43
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Multiple_Test.Service.HIPOT
{
    public class HipotCommand
    {

        /// <summary>
        /// 启动测试
        /// </summary>
        public static string Start_Test = "SOURce:SAFEty:STARt";
        /// <summary>
        /// 读取状态
        /// </summary>
        public static string Read_Status = "SOURce:SAFEty:STATUS?";
        /// <summary>
        /// 停止测试
        /// </summary>
        public static string Stop_Test = "SOURce:SAFEty:STOP";

        /// <summary>
        /// 获取设定的个数
        /// </summary>
        public static string Get_Snumber = "SOURce:SAFETY:SNUMBer?";

        /// <summary>
        ///  设定电压 0 是STEP 的Number,1是AC/DC 模式2是电压值 单位是V 
        /// </summary>
        public static string Set_LEVel = "SOURce:SAFEty:STEP{0}:{1}:LEVel {2}";
        /// <summary>
        /// 设置电流上限 0 是STEP 的Number,1是AC/DC 模式 2是电流的的上限值 单位是MA毫安 
        /// </summary>
        public static string Set_LIMIT_HIGH = "SOURce:SAFEty:STEP{0}:{1}:LIMit:HIGH {2}";
        /// <summary>
        /// SOURce:SAFEty:STEP1:AC:TIME:TEST 3
        /// 设置测试时间
        /// </summary>
        public static string Set_TestTime = "SOURce:SAFEty:STEP{0}:{1}:TIME:TEST {2}";
        /// <summary>
        ///  测试电压结果 单位KV
        /// </summary>
        public static string Get_Test_Volt = "SAFEty:RESult:STEP{0}:OMET?";
        /// <summary>
        ///  测试电流结果 单位A
        /// </summary>
        public static string Get_Test_Curr = "SAFEty:RESult:STEP{0}:MMET?";
        /// <summary>
        /// AC 模式结果 PASS(116)/FAIL /NG-CODE
        /// 获取测试项目的结果
        /// </summary>
        public static string Get_Test_Result = "SAFE:RES:STEP{0}:JUDG?";
        /// <summary>
        /// SOURce:SAFETY:SETP1:DELete 清除设定setp1 data
        /// </summary>
        public static string Delete_Test_Step = "SOURce:SAFETY:STEP{0}:DELete";
        /// <summary>
        ///Get_IDN Chroma,19053,190530007199,5.1
        /// </summary>
        public static string Get_IDN = "*IDN?";
        /// <summary>
        /// 获取设备记忆体中的Step 个数
        /// 回复“497,3"表示剩余可设定的步骤(STEP)为497个，已使用3个步骤
        /// </summary>
        public static string Get_Step_Count = "MEM:FREE:STEP?";

        public static string Get_Step_List = "SOURce:SAFETY:SNUMBer?";
        /// <summary>
        /// 设定步骤的Chanel
        /// </summary>
        public static string Set_Chan = "SOUR:SAFE:STEP{0}:{1}:CHAN:HIGH(@({2})):LOW(@({3}))";
        /// <summary>
        /// 设置ARC电弧长度
        /// </summary>
        public static string Set_ARC = "SOUR:SAFE:STEP{0}:{1}:LIMIT:ARC {2}";
        public static string Down = "DOWN";
        public static string UP = "UP";

        public static string ReadVolt = "READ";
        //SOURce:SAFEty:STEP1:AC:LEVel? 返回AC模式耐压的的电压

        //SOUR:SAFE:STEP1:AC 3600 设置AC 模式电压

        //SOUR:SAFE:STEP1:AC:TIME 4 设置测试时间

        //SOUR:SAFE:STEP1:AC:LIMIT:HIGH 0.010 电流上限
        // SOUR:SAFE:STEP1:AC:CHAN:HIGH(@(1,2,3)):LOW(@(4))
    }
}
