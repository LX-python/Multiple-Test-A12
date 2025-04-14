#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.User
 * 唯一标识：0589e30b-a065-4b52-b127-c64e259858a0
 * 文件名：EntityUserResponse
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/18 13:18:08
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/18 13:18:08
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

namespace Multiple_Test.Models.User
{
    public class EntityUserResponse
    {

        /// <summary>
        /// 賬號名稱
        /// </summary>
        public string Username { get; set; } = "";

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } = "";
        /// <summary>
        /// 真名
        /// </summary>

        public string RealName { get; set; } = "";
        /// <summary>
        /// 別名
        /// </summary>

        public string NickName { get; set; } = "";

        /// <summary>
        /// 頭像
        /// </summary>
        public string Avatar { get; set; } = "";
        /// <summary>
        /// 性別
        /// </summary>

        public int Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>

        public string Birthday { get; set; } = "";

        /// <summary>
        /// 手機
        /// </summary>

        public string MobilePhone { get; set; } = "";

        /// <summary>
        /// 郵件
        /// </summary>
        public string Email { get; set; } = "";
        /// <summary>
        /// 微信Openid
        /// </summary>

        public string Open_id { get; set; } = "";

        /// <summary>
        /// 簽名
        /// </summary>
        public string Signature { get; set; } = "";
        /// <summary>
        /// 地址
        /// </summary>

        public string Address { get; set; } = "";

        /// <summary>
        /// 廠區
        /// </summary>
        public string Factory_id { get; set; } = "";

        /// <summary>
        /// 廠區描述
        /// </summary>
        public string Factory_Desc { get; set; } = "";

        /// <summary>
        /// 部門id
        /// </summary>
        public string Department_id { get; set; } = "";

        /// <summary>
        /// 部門名稱
        /// </summary>
        public string Department_Name { get; set; } = "";
        /// <summary>
        /// 職等
        /// </summary>

        public int Duty_level { get; set; }

        /// <summary>
        /// 職等id
        /// </summary>
        public string Duty_id { get; set; } = "";

        /// <summary>
        /// 賬號狀態
        /// </summary>
        public int IsEnabled { get; set; }


        /// <summary>
        /// JWT Token
        /// </summary>
        public string Token { get; set; } = "";
    }

}
