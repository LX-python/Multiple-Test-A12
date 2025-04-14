#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.HTTP
 * 唯一标识：9c5e7eb9-bf39-44ba-8d3f-9911fdd61eca
 * 文件名：HttpRequestClient
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/18 11:03:41
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/18 11:03:41
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.HTTP
{
    public class HttpRequestClient : IDisposable
    {
        private readonly HttpClient httpClient;

        public HttpRequestClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> Get(string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Post(string url, string content)
        {
            StringContent stringContent = new StringContent(content);
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // 添加带头部信息的 GET 方法
        public async Task<string> GetWithHeaders(string url, string headerKey, string headerValue)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(headerKey, headerValue);

            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        // 添加带头部信息的 POST 方法
        public async Task<string> PostWithHeaders(string url, string content, string headerKey, string headerValue)
        {
            StringContent stringContent = new StringContent(content);

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(headerKey, headerValue);
            //httpClient.DefaultRequestHeaders.Add("Content-Type","application/json");
            // 设置内容头
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
