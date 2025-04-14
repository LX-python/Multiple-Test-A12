#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.DataGridViewService
 * 唯一标识：d0398741-e638-4cc3-bda3-a4957dbae1ad
 * 文件名：DataGridView_Service
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/15 16:13:25
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/15 16:13:25
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Controller.UIModels;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Service.DataGridViewService
{
    public class DataGridView_Service
    {
        private readonly UIDataGridView dataGridView;
        public DataGridView_Service(UIDataGridView dataGridView)
        {this.dataGridView = dataGridView;
        
        }

        public void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (dataGridView.CurrentRow != null)
            {
                // 获取选中行的数据
                DataGridViewRow selectedRow = dataGridView.CurrentRow;

                // 假设 TestItem 和 Describe 是 DataGridView 中的列名
                string testItemValue = selectedRow.Cells["TestItem"].Value?.ToString() ?? "";
                string describeValue = selectedRow.Cells["Describe"].Value?.ToString() ?? "";
                var frm = new FrmFunctionEdit(dataGridView.CurrentRow.Index+1,testItemValue);
                frm.ShowDialog();
                // 在控制台打印选中行的数据
                Console.WriteLine($"TestItem: {testItemValue}, Describe: {describeValue}");

                // 在这里，你可以使用选中行的数据进行其他操作
            }
        }

        /// <summary>
        /// 返回DataGridView 的Cout
        /// </summary>
        /// <returns></returns>
        public int GetDataGridViewCount()
        {
            return dataGridView.Rows.Count;
        }

        /// <summary>
        /// 转换DataGrid成JSON 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public string ConvertDataGridViewToJson()
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // 忽略空行
                if (!row.IsNewRow)
                {
                    Dictionary<string, object> rowData = new Dictionary<string, object>();

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        rowData[cell.OwningColumn.HeaderText] = cell.Value;
                    }

                    rows.Add(rowData);
                }
            }

            // 使用 Newtonsoft.Json 库将 List 转换为 JSON 字符串
            return JsonConvert.SerializeObject(rows, Formatting.Indented);
        }


     
    }
    
}
