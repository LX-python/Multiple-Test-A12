#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.QRCode
 * 唯一标识：7a6800ac-c828-44f5-85b9-064ff07c13bd
 * 文件名：EntityQRCode
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/6 10:32:33
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/6 10:32:33
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

namespace Multiple_Test.Models.QRCode
{
    public class EntityQRCode
    {
        /// <summary>
        /// 料号
        /// </summary>
        public string part_Number{get;set;}
        /// <summary>
        /// 供应商
        /// </summary>
        public string supplier { get;set;}
        /// <summary>
        /// 周期
        /// </summary>
        public string cycle { get; set; }
        /// <summary>
        /// 数量 (箱装数量）
        /// </summary>
        public int qty { get; set; }
        /// <summary>
        /// 箱号
        /// </summary>
        public string serial_number { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string Lot_Number { get; set; }
    }
}
