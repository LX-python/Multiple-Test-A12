#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Dal.Hipot
 * 唯一标识：e5a8bb06-402a-4913-90b8-fbe4734daaae
 * 文件名：HipotDalMapper
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/11 16:33:36
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/11 16:33:36
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Service;
using Multiple_Test.Service.Files;
using Multiple_Test.Utilities.Constant;
using Multiple_Test.Utilities.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Dal.Hipot
{
    public class HipotDalMapper
    {
        FilesService file = new FilesService();
        HipotCreateTableMaper CreateTable;
        sqlLiteHelper db;
        /// <summary>
        /// HipotDalMapper
        /// </summary>
        /// <param name="dbPath"></param>
        /// <param name="DbName"></param>
        public HipotDalMapper(string dbPath, string DbName)
        {
            file.CheckPath(dbPath);
            db = new sqlLiteHelper(dbPath + @"\" + DbName);
            CreateTable = new HipotCreateTableMaper(db);
            initTable(db);
        }

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
        public bool InsertTestRecord(object data)
        {
            try
            {
                Type type = data.GetType();
                var properties = type.GetProperties();

                // 排除主键列
                var nonPrimaryKeyProperties = properties.Where(p => !IsPrimaryKey(p));

                string columns = string.Join(", ", nonPrimaryKeyProperties.Select(p => p.Name));
                string values = string.Join(", ", nonPrimaryKeyProperties.Select(p => $"'{p.GetValue(data)}'"));

                string sql = $"INSERT INTO main.test_record ({columns}) VALUES ({values});";
                FileLog.LogError("DbError",sql);
                return db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {

                FileLog.LogError("DbError", ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 排除主键
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private bool IsPrimaryKey(PropertyInfo property)
        {
            // 这里假设主键的属性名称为 "id"，你可能需要根据实际情况进行调整
            return property.Name.ToLower() == "id";
        }

        /// <summary>
        /// 获取当前箱号的测试产能
        /// </summary>
        /// <param name="box_no"></param>
        /// <returns></returns>
        public DataTable GetNowTotalTestQty(string box_no)
        {
            try
            {
                string sql = $"SELECT sum(test_qty) as total_qty FROM test_record " +
                    $"WHERE box_no = '{box_no}' " +
                    $"ORDER BY test_time DESC LIMIT 1";

                return db.ExecuteQuery(sql);

            }
            catch (Exception ex)
            {

                FileLog.LogError("DbError", ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// 获取当前箱号的测试产能
        /// </summary>
        /// <param name="box_no"></param>
        /// <returns></returns>
        public DataTable GetNowPassTestQty(string box_no)
        {
            try
            {
                string sql = $"SELECT sum(test_qty) as pass_qty FROM test_record " +
                    $"WHERE box_no = '{box_no}' " +
                    $" and test_result='{ConstantService.PASS}' "+
                    $"ORDER BY test_time DESC LIMIT 1";

                return db.ExecuteQuery(sql);

            }
            catch (Exception ex)
            {

                FileLog.LogError("DbError", ex.Message);
                return new DataTable();
            }
        }


        /// <summary>
        /// 获取当前箱号的测试产能
        /// </summary>
        /// <param name="box_no"></param>
        /// <returns></returns>
        public DataTable GetNowFailTestQty(string box_no)
        {
            try
            {
                string sql = $"SELECT sum(test_qty) as fail_qty FROM test_record " +
                    $"WHERE box_no = '{box_no}' " +
                     $" and test_result='{ConstantService.FAIL}' " +
                    $"ORDER BY test_time DESC LIMIT 1";

                return db.ExecuteQuery(sql);

            }
            catch (Exception ex)
            {

                FileLog.LogError("DbError", ex.Message);
                return new DataTable();
            }
        }


    }
}
