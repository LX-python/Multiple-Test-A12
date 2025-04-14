#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.APIResult
 * 唯一标识：c8720bed-0cf6-47d9-98a8-55f7d217d43d
 * 文件名：ApiService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/20 16:10:53
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/20 16:10:53
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

namespace Multiple_Test.Service.APIResult
{
    public class ApiService
    {
        public static string GetStatus(int status) 
        {
            ///0 停用，1启用，2.产品不良中locked,3.维修，4报废
            switch (status) 
            {
                case 0:
                    {

                        return "载具已停用";
                            }
                case 2:
                    {

                        return "产品不良中locked";
                    }
                case 3:
                    {

                        return "载具维修中...";
                    }
                case 4:
                    {

                        return "测试载具已报废";
                    }
                default: {
                        return $"未知的状态{status}";
                    }
            }
        
        }
    }
}
