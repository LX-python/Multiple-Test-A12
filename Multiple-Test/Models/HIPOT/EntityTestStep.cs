#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.HIPOT
 * 唯一标识：b35adff5-4dc1-4f7a-9bf8-898071cbf1d8
 * 文件名：EntityTestStep
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/8 16:08:21
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/8 16:08:21
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

namespace Multiple_Test.Models.HIPOT
{
    public class EntityTestStep
    {
        public EntityTestStep() { }

        /// <summary>
        /// 步骤
        /// </summary>
        public int Step { get; set; }
        /// <summary>
        /// 测试项目
        /// </summary>
        public string Test_Item { get; set; }
        /// <summary>
        /// 模式
        /// </summary
        public string Mode { get; set; }
        /// <summary>
        /// 条件
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        ///  步骤测试时间
        /// </summary>
        public string Test_Time { get; set; }
        /// <summary>
        ///上限
        /// </summary>
        public string Limit_High { get; set; }
        
        /// <summary>
        /// 下限
        /// </summary>
        public string Limit_Low { get;set; }
        /// <summary>
        /// 测试结果
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 测试电压
        /// </summary>
        public string Test_Volt { get; set; }
        /// <summary>
        /// 测试电流
        /// </summary>
        public string Test_Current { get; set; }
        /// <summary>
        /// 报警信息
        /// </summary>
        public string Error_Msg { get; set; }
    }
}
