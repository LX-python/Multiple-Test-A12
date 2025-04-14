#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.HIPOT
 * 唯一标识：63aa508e-cb47-46fb-886f-b569bf1ece35
 * 文件名：EntityTestRecord
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/11 19:44:40
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/11 19:44:40
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
    public class EntityTestRecord
    {
        public int id { get; set; }
        public string Box_No { get; set; }
        public string Test_Script { get; set; }
        public int Total_Qty { get; set; }
        public int Test_Qty { get; set; }
        public string Fixture { get; set; }
        public int Fixture_Qty { get; set; }
        public string Test_Time { get; set; }
        public string Test_Result { get; set; }
        public int Step_Count { get; set; }
        public string Test_Value { get; set; }
        /// <summary>
        /// 測試穴位
        /// </summary>
        public int Cavity { get; set; }
    }
}
