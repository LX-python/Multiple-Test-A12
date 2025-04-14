#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.HIPOT
 * 唯一标识：9bc5c0d6-9259-4d9a-bd85-df5849434c0d
 * 文件名：EntityInputFlag
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/19 15:27:15
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/19 15:27:15
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
    public class EntityInputFlag
    {
        /// <summary>
        /// 输入的状态
        /// </summary>
        public bool Flag { get; set; }
        /// <summary>
        /// 是否退出步骤
        /// </summary>
        public bool ExitFlag { get; set; }
        /// <summary>
        /// message
        /// </summary>
        public string message { get; set; }

        public int vehicle_Qty { get; set; }
    }
}
