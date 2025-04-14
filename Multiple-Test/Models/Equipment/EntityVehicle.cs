#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.Equipment
 * 唯一标识：7eb4036c-0fc7-409a-bb98-d10309fd84a5
 * 文件名：EntityVehicle
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/20 14:51:28
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/20 14:51:28
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

namespace Multiple_Test.Models.Equipment
{
    public class EntityVehicle
    {
        public string Vehicle_Id { get; set; }
        public string Vehicle_Name { get; set; }
        public int Vehicle_Qty { get; set; }
        public int Vehicle_Status { get; set; }
        public string CreateUser { get; set; }
        public string Create_Time { get; set; }
        public string Last_Modify_User { get; set; }
        public string Last_Modify_Time { get; set; }
        public string Last_Modify_Info { get; set; }
    }

}
