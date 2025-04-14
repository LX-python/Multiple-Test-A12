#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.Command
 * 唯一标识：38d35b5a-e53a-465c-a76d-8a94e1f8bb84
 * 文件名：entityChildNodeCommand
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/19 8:25:39
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/19 8:25:39
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

namespace Multiple_Test.Models.Command
{
    public class entityChildNodeCommand
    {
        public entityChildNodeCommand() { }
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// cmd 类型
        /// </summary>
        public string control_Type { get; set; }
        //cmd
        public string control_cmd { get; set; }
        /// <summary>
        /// 是否要读值校验
        /// </summary>
        public bool read_flag { get; set; }
    }
}
