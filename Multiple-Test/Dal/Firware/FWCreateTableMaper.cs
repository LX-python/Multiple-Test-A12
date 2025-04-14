#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Dal.Firware
 * 唯一标识：e37da92d-014b-4eeb-86ef-d782b8b465a6
 * 文件名：FWCreateTableMaper
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/27 23:52:15
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/27 23:52:15
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

namespace Multiple_Test.Dal.Firware
{
    public class FWCreateTableMaper
    {

        private sqlLiteHelper _db = null;
        public FWCreateTableMaper(sqlLiteHelper db)
        {
            _db = db;
        }

        /// <summary>
        /// 创建测试记录表
        /// </summary>
        public void CreateTest_RecordTable()
        {
            // 创建一个名为 "test_record" 的表格，仅在不存在时创建
            string createTableQuery = $"CREATE TABLE IF NOT EXISTS main.test_fw_record (" +
               
                $" \"serial_number\" text(60)," +
                $" \"test_result\" text(60)," +
                $" \"fw_version\" text(60)," +
                $" \"test_datetime\" text(60)" +
              
                $" );";

            // 设置外键约束
           // string enableForeignKeyQuery = "PRAGMA foreign_keys = true;";

            // 执行查询
           // _db.ExecuteNonQuery(enableForeignKeyQuery);
            _db.ExecuteNonQuery(createTableQuery);


        }

    }
}
