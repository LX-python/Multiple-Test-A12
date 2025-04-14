#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.AuthorityManagement
 * 唯一标识：852ca4fd-9326-4ee1-96d2-15e17dcf27ed
 * 文件名：UserInfo
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/17 16:47:45
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/17 16:47:45
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

namespace Multiple_Test.AuthorityManagement
{
    public class UserInfo
    {
        public UserInfo() { }
        /// <summary>
        /// 用户名
        /// </summary>
        public static string username {get;set;}
        /// <summary>
        /// 名称
        /// </summary>
        public static string Name { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public static string Token { get; set; }
        /// <summary>
        /// 厂区
        /// </summary>
        public static string FactoryName { get; set; }

    }
}
