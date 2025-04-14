#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.Files
 * 唯一标识：9009340c-44ef-47ef-9ec4-66e477754548
 * 文件名：FileComparer
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/2/24 9:29:19
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/2/24 9:29:19
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.Files
{
    public class FileComparer
    {
        /// <summary>
        /// 文件相同检查
        /// </summary>
        /// <param name="filePath1">Filepath1</param>
        /// <param name="filePath2">filePath2</param>
        /// <returns></returns>
        public static bool AreFilesEqual(string filePath1, string filePath2,ref string result)
        {
            try
            {
                if (!File.Exists(filePath1))
                {
                    result = $"No found File ({filePath1})";
                    return false ;
                }
                if (!File.Exists(filePath2))
                {

                    result = $"No found File ({filePath2})";
                    return false;
                }

                using (var md5 = MD5.Create())
                {
                    string hash1 = GetFileHash(filePath1, md5);
                    string hash2 = GetFileHash(filePath2, md5);

                    if (hash1 == hash2)
                    {
                        result = $"File1==File2";
                        return true;
                    }
                    else 
                    {
                        result = $"内容不相同..";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                result=ex.Message;
               return false;
            }

        }
        /// <summary>
        ///  GetFileHash
        /// </summary>
        /// <param name="filePath"><filePath/param>
        /// <param name="algorithm">algorithm</param>
        /// <returns></returns>
        private static string GetFileHash(string filePath, HashAlgorithm algorithm)
        {
            using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000)) // 使用缓冲区
            {
                byte[] hash = algorithm.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}
