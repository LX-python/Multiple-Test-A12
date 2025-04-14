#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Controller.UIModels
 * 唯一标识：ee9b74ba-8a31-4fe5-840b-de56245945df
 * 文件名：frmAddACSourse
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/15 17:22:00
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/15 17:22:00
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Models.Command;
using Multiple_Test.Models.Grid;
using Multiple_Test.Service;
using Multiple_Test.Service.GPIB;
using Multiple_Test.Service.GPIB.ACSource;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Controller.UIModels
{
    public partial class frmAddACSource:UIForm
    {


        public frmAddACSource()
        {
            InitializeComponent();
            this.uiTreeView1.ExpandAll();
            this.Load += FrmAddACSourse_Load;
            this.uiTreeView1.NodeMouseDoubleClick += UiTreeView1_NodeMouseDoubleClick;
            this.btnAdd.Click += BtnAdd_Click;
        }



        private async void UiTreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (uiTreeView1.SelectedNode.Text != null && !string.IsNullOrEmpty(uiTreeView1.SelectedNode.Text))
            {
                string[] nodeName = uiTreeView1.SelectedNode.Text.Split(':');
                if (nodeName.Length < 2)
                {
                    return;
                }
                txtGPIBName.Text = nodeName[0];
                txtAddress.Text = nodeName[2];
                await cmd.Set_Output_CLS(txtGPIBName.Text, txtAddress.Text);
                FileLog.LogDebug("Debugger",ACSourseCommand.Set_AC_Init);
            }
        }


        private void FrmAddACSourse_Load(object sender, EventArgs e)
        {
            //1.初始化GPIB 并找到AC
            cmd.GetAC_Sourse_Type_PopulateTreeView(ref uiTreeView1, ref LogLine);
        }

      


        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnDebugger.Enabled = false;
            cmd.GetAC_Sourse_Type_PopulateTreeView(ref uiTreeView1,ref LogLine);
            btnRefresh.Enabled = true;
            btnDebugger.Enabled = true;
        }

        private async void btnDebugger_Click(object sender, EventArgs e)
        {
            var f = float.Parse(txtFreqVlaue.Text);
            if (!string.IsNullOrEmpty(txtGPIBName.Text) && !string.IsNullOrEmpty(txtAddress.Text))
            {

                if (btnselectFrequency.Checked)
                {
                    var respoense_freq = await cmd.WriteFrequency(txtGPIBName.Text,txtAddress.Text,float.Parse(txtFreqVlaue.Text));
                    if (!respoense_freq.flag)
                    {
                        this.ShowInfoDialog( respoense_freq.message);

                    }
                    else 
                    {
                        this.ShowErrorDialog(respoense_freq.message);
                        return;
                    }
                }
                if (btnselectVoltage.Checked)
                {
                    var respoense_freq = await cmd.WriteVoltage(txtGPIBName.Text,txtAddress.Text,float.Parse(txtVoltValue.Text));
                    if (!respoense_freq.flag)
                    {
                        this.ShowInfoDialog(respoense_freq.message);
                        
                    }
                    else
                    {
                        this.ShowErrorDialog(respoense_freq.message);
                        return;
                    }
                }
                if (btnOff.Checked) 
                {
                  await cmd.Set_Output_OFF(txtGPIBName.Text, txtAddress.Text);

                }
                if (btnON.Checked) 
                {
                    await cmd.Set_Output_ON(txtGPIBName.Text, txtAddress.Text);
                }
            }
            else 
            {
                this.ShowErrorDialog("No Setting GPIB,No found GPIB Dervice!!!");
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
