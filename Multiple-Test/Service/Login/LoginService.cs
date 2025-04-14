#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.Login
 * 唯一标识：6a801b31-5bca-4f1e-9ab3-290bdcf6afd6
 * 文件名：LoginService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/18 8:57:09
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/18 8:57:09
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>



using Multiple_Test.AuthorityManagement;
using Multiple_Test.Utilities.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Multiple_Test.Models.API;
using Multiple_Test.Service.HTTP;
using Newtonsoft.Json;
using Multiple_Test.Models.User;
using Multiple_Test.Service.ChromaMES;
using System.Windows;
using System.IO;
using System.Net.Http;

namespace Multiple_Test.Service.Login
{
    public class LoginService
    {
        /// <summary>
        /// 服务注入
        /// </summary>
        private readonly ConnectService service = new ConnectService();

        public LoginService() { }

        /// <summary>
        /// 系統登錄校驗
        /// </summary>
        /// <param name="FactoryName">Factory</param>
        /// <param name="UserName">賬號</param>
        /// <param name="Password">密碼</param>
        /// <param name="message">返回的信息</param>
        /// <returns></returns>
        public async Task<EntityResult> LoginSystem(string FactoryName, string UserName, string Password)
        {
            var re_object = new EntityResult();
            try
            {

                //賬號判斷
                if (string.IsNullOrEmpty(UserName))
                {
                    re_object.result = "請輸入賬號";
                    re_object.flag = false;
                    return re_object;
                }

                //賬號判斷
                if (string.IsNullOrEmpty(Password))
                {
                    re_object.result = "請輸入密码";
                    re_object.flag = false;
                    return re_object;
                }

                //賬號厂区
                if (string.IsNullOrEmpty(FactoryName))
                {
                    re_object.result = "請輸入厂区";
                    re_object.flag = false;
                    return re_object;
                }

                var obj = new Dictionary<string, string>();
                obj.Add("username", UserName);
                obj.Add("password", Password);
                //
                //呼叫API 
                var result = await service.SendData($"{APISRC.API}{APIConstant.Login}", "", JsonConvert.SerializeObject(obj));

                //setwinform 中的User seesion用於權限判斷
                if (result.flag)
                {
                    var info = JsonConvert.DeserializeObject<ResponseResult>(result.result);
                    if (info.code == -1)
                    {
                        re_object.flag = false;
                        re_object.result = info.msg;
                        return re_object;
                    }
                    else
                    {
                        var token = JsonConvert.DeserializeObject<EntityUserResponse>(info.data.ToString());

                        string message = string.Empty;
                        if (MES_Service.CommandCheckUser(UserName, ref message))
                        {
                            var userinfo = JsonConvert.DeserializeObject<EntityUserResponse>(info.data.ToString());
                            UserInfo.username = UserName;
                            UserInfo.Name = userinfo.RealName;
                            UserInfo.Token = userinfo.Token;
                            UserInfo.FactoryName = FactoryName;
                            FileLog.LogInformation(ConstantService.LoginSucceed, $"{UserName} LoginSucceed!");
                            //Dictionary<string, object> objs = new Dictionary<string, object>();
                            //objs.Add("Vehicle_Number", "B900-IB03-A6");
                            //objs.Add("Factory_Name", UserInfo.FactoryName);
                            //objs.Add("status", 2);
                            ////呼叫API 
                            //var res = await service.SendData($"{APISRC.API}{APIConstant.ModifyVehicleStatus}", UserInfo.Token, JsonConvert.SerializeObject(objs));
                            //if (res.flag)
                            //{
                            //    re_object.flag = false;
                            //}
                        }
                        else
                        {
                            re_object.flag = false;
                            re_object.result = message;
                            return re_object;
                        }

                    }
                }
                re_object = result;
                return re_object;
            }
            catch (Exception ex)
            {
                re_object.result = ex.Message;
                FileLog.WriteLog(ConstantService.LoginError, ex.Message);
                return re_object;
            }

        }
        /// <summary>
        /// 加载后端地址
        /// </summary>
        /// <returns></returns>
        public async Task<bool> LoadAPIUrl()
        {
            try
            {
                string apiUrlFileName = ConstantService.Config;
                if (File.Exists(apiUrlFileName))
                {
                    var configString = File.ReadAllText(ConstantService.Config);
                    var data = JsonConvert.DeserializeObject<APIConfig>(configString);

                    string selectedApi = await GetAvailableApiAsync(data.api.Split(','));

                    if (selectedApi != null)
                    {
                        APISRC.API = selectedApi;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("No available API found.");
                     return false;
                    }
                   
                }
                else
                {
                    File.WriteAllText(apiUrlFileName, JsonConvert.SerializeObject(new APIConfig()));
                    return false;
                }

            }
            catch (Exception ex)
            {
                FileLog.LogError("APIConfigError", ex.Message);
                return false;
            }
        }


        private async Task<string> GetAvailableApiAsync(string[] apis)
        {
            using (HttpClient client = new HttpClient())
            {
                foreach (var api in apis)
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(api);
                        if (response.IsSuccessStatusCode)
                        {
                            return api;
                        }
                    }
                    catch (HttpRequestException)
                    {
                        // Ignore exceptions and try the next API
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 初始化Chroma MES connect
        /// </summary>
        /// <returns></returns>
        public bool InitMesConnect()
        {

            return MES_Service.MesConnect();
        }
    }

}
