#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Dal.Firware
 * 唯一标识：2e5d5ad7-5aa4-4ffd-afd5-545a8f178fec
 * 文件名：FWDalMapper
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/27 23:57:30
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/27 23:57:30
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Dal.Hipot;
using Multiple_Test.Service;
using Multiple_Test.Service.Files;
using Multiple_Test.Utilities.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Multiple_Test.Dal.Firware
{
    public class FWDalMapper
    {
        FilesService file = new FilesService();
        FWCreateTableMaper CreateTable;
        sqlLiteHelper db;
        public FWDalMapper(string dbPath,string DbName)
        {
            file.CheckPath(dbPath);
            db = new sqlLiteHelper(dbPath + @"\" + DbName);
            CreateTable = new FWCreateTableMaper(db);
            initTable(db);
        }

        /// <summary>
        /// 初始化表
        /// </summary>
        /// <param name="db"></param>
        private void initTable(sqlLiteHelper db)
        {
            //创建db Table
            CreateTable.CreateTest_RecordTable();
        }
        /// <summary>
        /// 插入测试数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool InsertTestFwRecord(object data)
        {
            try
            {
                Type type = data.GetType();
                var properties = type.GetProperties();
                string columns = string.Join(", ", properties.Select(p => p.Name));
                string values = string.Join(", ", properties.Select(p => $"'{p.GetValue(data)}'"));
                string sql = $"INSERT INTO main.test_fw_record ({columns}) VALUES ({values});";
                FileLog.LogError("DbError", sql);
                return db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {

                FileLog.LogError("DbError", ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 获取当天的每个测试小时测试数据
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public DataTable GetDayTestData(string result) 
        {
            var sql = $"SELECT " +
                $" strftime('%Y-%m-%d %H:00:00', hours_of_day.hour) AS datetime_hour," +
                $" COALESCE(COUNT(main.test_fw_record.test_datetime), 0) AS production_capacity " +
                $" FROM " +
                $" (SELECT " +
                $" datetime(CURRENT_DATE, '+' || (a + b * 10) || ' HOURS') AS hour" +
                $" FROM" +
                $" (SELECT 0 AS a UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8 UNION SELECT 9) AS a" +
                $" CROSS JOIN" +
                $" (SELECT 0 AS b UNION SELECT 1 UNION SELECT 2) AS b) AS hours_of_day" +
                $" LEFT JOIN " +
                $" main.test_fw_record ON " +
                $" strftime('%Y-%m-%d',main.test_fw_record.test_datetime)='{DateTime.Now.ToString("yyyy-MM-dd")}'" +
                $" and  main.test_fw_record.test_result='{result}'" +
                $" and  strftime('%Y-%m-%d %H:00:00', hours_of_day.hour) = strftime('%Y-%m-%d %H:00:00', main.test_fw_record.test_datetime)" +
                $" where  strftime('%Y-%m-%d', hours_of_day.hour)='{DateTime.Now.ToString("yyyy-MM-dd")}'" +
                $" GROUP BY " +
                $" hours_of_day.hour" +
                $" ORDER BY " +
                $" hours_of_day.hour;";
            return db.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取当天测试良品不良品产能
        /// </summary>
        /// <returns></returns>
        public DataTable GetDayTestRate() 
        {
            var sql = $"SELECT" +
                $"  COALESCE(SUM(CASE WHEN test_result = 'PASS' THEN 1 ELSE 0 END), 0) AS PassCount," +
                $"  COALESCE(SUM(CASE WHEN test_result = 'FAIL' THEN 1 ELSE 0 END), 0) AS FailCount" +
                $"  FROM" +
                $"  main.test_fw_record" +
                $"  WHERE" +
                $"  strftime('%Y-%m-%d', main.test_fw_record.test_datetime) = '{DateTime.Now.ToString("yyyy-MM-dd")}'";
            return db.ExecuteQuery(sql);
        }
    }
}
