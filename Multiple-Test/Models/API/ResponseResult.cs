#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.API
 * 唯一标识：36aacee5-d54a-43a2-ac91-de93d205fdd1
 * 文件名：EntityApiResult
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/18 13:15:00
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/18 13:15:00
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
    public class ResponseResult
    {
        /// <summary>
        /// 函数执行结果
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// data 数量
        /// </summary>
        public int? count { get; set; }

        public double responseTime { get; set; }
        /// <summary>
        /// msg
        /// </summary>
        public string msg { get; set; } = "";

        /// <summary>
        /// 返回结果
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// Uuid
        /// </summary>
        public string Uuid { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");

    }
}
