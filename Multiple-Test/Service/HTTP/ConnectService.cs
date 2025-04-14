#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.HTTP
 * 唯一标识：7c9950fa-0f75-4453-abe3-da1e44585560
 * 文件名：ConnectService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/18 11:04:21
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/18 11:04:21
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Models.API;
using Multiple_Test.Utilities.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.HTTP
{
    public class ConnectService
    {
        HttpRequestClient httpClient = new HttpRequestClient();
        //private string Authorization = "";
        //private string HeaderValue = "";
        //public ConnectService(string Authorization,string HeaderValue) 
        //{
        //    this.Authorization = Authorization;
        //    this.HeaderValue = HeaderValue;
        //}
        public async Task<EntityResult> Get_Data(string url, string HeaderValue, string data)
        {
            var re_object = new EntityResult();
            try
            {
                string getUrl = url;
                string getHeaderKey = "token";
                string getHeaderValue = HeaderValue;
                string result = await httpClient.GetWithHeaders(getUrl, getHeaderKey, getHeaderValue);
                re_object.flag = true;
                re_object.result = result;
            }
            catch (Exception ex)
            {
                re_object.flag = false;
                re_object.result = ex.Message;
                FileLog.LogError("APIException",ex.Message);
            }
            finally
            {
               // httpClient.Dispose();
            }
            return re_object;
        }
        public async Task<EntityResult> SendData(string postUrl, string HeaderValue,string postData)
        {
            var re_object = new EntityResult();
            try
            {
     
                string postHeaderKey = "token";
                string postHeaderValue = HeaderValue;
                string responseDataWithHeaders = await httpClient.PostWithHeaders(postUrl, postData, postHeaderKey, postHeaderValue);
                re_object.result = responseDataWithHeaders;
                re_object.flag = true;
            }
            catch (Exception ex)
            {
                re_object.flag = false;
                re_object.result = ex.Message;
                FileLog.LogError(ConstantService.ApiCallError,ex.Message);
            }
            finally
            {
               // httpClient.Dispose();
            }
            return re_object;
        }
    }
}
