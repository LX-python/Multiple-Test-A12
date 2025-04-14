#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.Grid
 * 唯一标识：c6c6ef6a-8887-4693-850f-022e2f4d7c17
 * 文件名：entityGPIBList
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/18 10:53:05
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/18 10:53:05
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

namespace Multiple_Test.Models.Grid
{
    public class entityGPIBList
    {
        /// <summary>
        /// GPIB 的名称
        /// </summary>
        public string GPIB_Name { get; set; }
        /// <summary>
        /// GPIB的地址
        /// </summary>
        public int GPIB_Address { get; set; }
        /// <summary>
        /// GPIB 下的卡型号 类型
        /// </summary>
        public string Card_Type { get; set; }
    }
}
