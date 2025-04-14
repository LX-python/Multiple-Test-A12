#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.GPIB
 * 唯一标识：7159604b-795d-4c85-9c3e-ceb09145f6da
 * 文件名：GPIBCommand
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/15 10:18:04
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/15 10:18:04
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

namespace Multiple_Test.Service.GPIB
{
    public class GPIBCommand
    {
        /// <summary>
        /// 获取GPIB 列表信息
        /// </summary>
        public static string GetGPIB_List = "gpib?*INSTR";

      

    }
}
