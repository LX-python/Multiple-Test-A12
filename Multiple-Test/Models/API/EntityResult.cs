#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.API
 * 唯一标识：3423a675-a87d-468a-8380-5faf69cbd9b4
 * 文件名：EntityResult
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/18 11:00:30
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/18 11:00:30
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

namespace Multiple_Test.Models.API
{
    public class EntityResult
    {
        /// <summary>
        /// 調用的狀態
        /// </summary>
        public bool flag { get; set; }
        /// <summary>
        /// 返回的結果
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 治具测试数量
        /// </summary>
        public int vehicle_qty { get; set; } = 1;
    }
}
