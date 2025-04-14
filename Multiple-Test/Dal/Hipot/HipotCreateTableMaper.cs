#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Dal.Hipot
 * 唯一标识：6813006a-0346-4b0e-a802-e4bb25d8b2f6
 * 文件名：HipotCreateTableMaper
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/11 16:58:16
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/11 16:58:16
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Utilities.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Dal.Hipot
{
    public class HipotCreateTableMaper
    {
       private sqlLiteHelper _db = null;
        public HipotCreateTableMaper(sqlLiteHelper db)
        {
            _db = db;
        }
        /// <summary>
        /// 创建测试记录表
        /// </summary>
        public void CreateTest_RecordTable() 
        {
            // 创建一个名为 "test_record" 的表格，仅在不存在时创建
            string createTableQuery = $"CREATE TABLE IF NOT EXISTS main.test_record (" +
                $" \"id\" integer NOT NULL," +
                $" \"box_no\" text(60)," +
                $" \"test_script\" text(60)," +
                $" \"total_qty\" integer(60)," +
                $" \"test_qty\" integer(60)," +
                $" \"fixture\" text(60)," +
                $" \"fixture_qty\" INTEGER," +
                $" \"test_time\" TEXT(30)," +
                $" \"test_result\" TEXT(10)," +
                $" \"step_count\" integer," +
                $" \"test_value\" TEXT(220)," +
                $" \"cavity\" integer(60)," +
                $" PRIMARY KEY (\"id\"));";

            // 设置外键约束
            string enableForeignKeyQuery = "PRAGMA foreign_keys = true;";

            // 执行查询
            _db.ExecuteNonQuery(enableForeignKeyQuery);
            _db.ExecuteNonQuery(createTableQuery);


        }

    }
}
