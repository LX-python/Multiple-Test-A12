#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.Programs
 * 唯一标识：5fd35dad-f068-40a9-8c48-96488996c725
 * 文件名：EntityProgramsInfo
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/3/12 8:39:20
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/3/12 8:39:20
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

namespace Multiple_Test.Models.Programs
{
    public class EntityProgramsInfo
    {

        /// <summary>
        /// 程序名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public string size { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string publish_time { get; set; }
        /// <summary>
        /// 版本描述
        /// </summary>
        public string description { get; set; }
    }
}
