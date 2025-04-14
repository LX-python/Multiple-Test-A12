#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Utilities.Office
 * 唯一标识：30d9b851-1f9a-41c5-83ac-f2586b9fc626
 * 文件名：ExcelService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/12 20:16:01
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/12 20:16:01
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Utilities.Office
{
    public  class ExcelService
    {
        public ExcelService() { }

        /// <summary>
        /// 转换测试记录
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="csvFilePath"></param>
        public static void ConvertDataTableToCsv(DataTable dataTable, string csvFilePath)
        {
            // 创建一个StreamWriter用于写入CSV文件，使用UTF-8编码
            using (StreamWriter sw = new StreamWriter(csvFilePath, false, Encoding.UTF8))
            {
                // 写入CSV文件的表头（列名）
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sw.Write($"\"{EscapeQuotes(dataTable.Columns[i].ColumnName)}\"");
                    if (i < dataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();

                // 写入每一行的数据
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        sw.Write($"\"{EscapeQuotes(row[i].ToString())}\"");
                        if (i < dataTable.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }

        // 转义字段中的引号
        private static string EscapeQuotes(string input)
        {
            return input.Replace("\"", "\"\"");
        }


    }

}
