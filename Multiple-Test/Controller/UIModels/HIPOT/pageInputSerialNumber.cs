#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2024 Shengbi NJRN 保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：国际开源协会
 * 唯一标识：549e8135-171f-4df2-8412-925203412c82
 * 文件名：pageInputSerialNumber
 * 当前用户域：REDEEMER
 * 
 * 创建者：Shengbi
 * 电子邮箱：（yysvent@163.com）
 * Github  ：https://github.com/Countonme
 * 创建时间：2024/6/14 15:55:38
 * 版本：V1.0.0
 * 描述：初始版本
 *  
 * 1.在追求理想的道路上，剑锋所指，坚韧与担当铸就人生的意义
 * 2.开源是遍地生花的最好方法， 闭源是确保利益不受损害的最好方法
 * 3.预测未来的最好方法就是去创造它 
 * 承接 Web/小程序/App/测试系统/AI/视觉/卷积网络神经/物联网/等项目开发
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/

#endregion << 版 本 注 释 >>
using Multiple_Test.Models.QRCode;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Multiple_Test.Controller.UIModels.HIPOT
{
    public partial class pageInputSerialNumber : UIForm
    {
        private int NeedTotalCount;
        public List<EntitySerialNumber> ScanInfo = new List<EntitySerialNumber>();

        public pageInputSerialNumber(int total)
        {
           

            InitializeComponent();
            NeedTotalCount = total;
            ScanNumberList();
            showQty();
            this.txtSerialNumber.KeyDown += TxtSerialNumber_KeyDown;
            this.Shown += PageInputSerialNumber_Shown;
            this.Load += PageInputSerialNumber_Load;

        }

        private void PageInputSerialNumber_Load(object sender, EventArgs e)
        {
            if (NeedTotalCount <= 0)
            {
                this.ShowErrorDialog($"需要扫码的数量小于1  设定值:{NeedTotalCount}");
                this.Close();
            }
        }

        private void PageInputSerialNumber_Shown(object sender, EventArgs e)
        {
            txtSerialNumber.Focus();
            txtSerialNumber.SelectAll();

        }

        private void TxtSerialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleSerialNumberInput();
            }
        }

        private void HandleSerialNumberInput()
        {
            string input = txtSerialNumber.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                ClearAndNotify($"{input.ToUpper()}没有内容");
                return;
            }

            if (ScanInfo.Exists(p => p.SerialNumber.ToUpper() == input.ToUpper()))
            {
                ClearAndNotify($"{input.ToUpper()} 条码已经使用");
                return;
            }

            AddSerialNumber(input);
            txtSerialNumber.Clear();
            txtSerialNumber.Focus();
            txtSerialNumber.SelectAll();

            if (ScanInfo.Count == NeedTotalCount)
            {
                this.ShowSuccessNotifier("扫码完毕");
                this.Close();
            }
        }

        private void AddSerialNumber(string serialNumber)
        {
            var info = new EntitySerialNumber
            {
                No = dataGridView1.RowCount + 1,
                SerialNumber = serialNumber,
                len = serialNumber.Length,
            };

            ScanInfo.Add(info);
            showQty();
            ScanNumberList();
        }

        private void ClearAndNotify(string message)
        {
            txtSerialNumber.Clear();
            this.ShowErrorNotifier(message);
        }

        private void showQty()
        {
            uiLine7.Text = $"已扫码数量:{ScanInfo.Count} / 总数:{NeedTotalCount}";
        }

        private void ScanNumberList()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ScanInfo;
            dataGridView1.Columns["No"].Width = 80;
            dataGridView1.Columns["SerialNumber"].Width = 280;
            dataGridView1.Columns["len"].Width = 80;
            dataGridView1.Columns["msg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Refresh();
        }
    }

}
