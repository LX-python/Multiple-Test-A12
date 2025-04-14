#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Utilities.Update
 * 唯一标识：f58049c4-f84e-494e-9409-0116a81c76dd
 * 文件名：UpdateService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/3/12 8:29:40
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/3/12 8:29:40
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Service.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiple_Test.Models.Programs;
using Multiple_Test.Models.API;
using Newtonsoft.Json;
using Multiple_Test.Service;

namespace Multiple_Test.Utilities.Update
{
    public class UpdateService
    {
        /// <summary>
        /// 服务注入
        /// </summary>
        private readonly ConnectService service = new ConnectService();
        public UpdateService() { }

        /// <summary>
        /// 检查服务器最新版本
        /// </summary>
        /// <param name="ProgramName"></param>
        /// <returns></returns>
        public async Task<EntityProgramsInfo> CheckProgramerVersion(string ProgramName)
        {
            var reObject = new EntityProgramsInfo();
            try
            {
                //呼叫API 
                var result = await service.Get_Data($"{APISRC.API}{APIConstant.GetProgramsVersion}?ProgramName={ProgramName}", "","");

                //setwinform 中的User seesion用於權限判斷
                if (result.flag)
                {
                    var info = JsonConvert.DeserializeObject<ResponseResult>(result.result);
                    if (info.code == 0)
                    {
                        reObject = JsonConvert.DeserializeObject<EntityProgramsInfo>(info.data.ToString());
                    }
                    
                }
            }
            catch (Exception ex)
            {

                FileLog.LogError("UpdateError",ex.Message);
            }

        
        return reObject;
        
        }

    }
}
