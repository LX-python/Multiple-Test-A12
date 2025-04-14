#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.ACSourse
 * 唯一标识：739a7a26-f107-4bcc-8ff6-4dbe0b91a997
 * 文件名：AC_Sourse_Service
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/18 13:12:52
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/18 13:12:52
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
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

namespace Multiple_Test.Service.ACSource
{
    public class AC_Source_Service
    {
        private readonly GPIBServices gpib_service = new GPIBServices();
        private readonly GPIBEquipmentType gpib_type = new GPIBEquipmentType();
        const string debugger = "debugger";
        public AC_Source_Service()
        {

        }

        /// <summary>
        /// 渲染设备型号
        /// </summary>
        /// <param name="uiTreeView1"></param>
        /// <param name="LogLine"></param>
        public void GetAC_Sourse_Type_PopulateTreeView(ref UITreeView uiTreeView1, ref UILine LogLine)
        {
            // 清空 TreeView 中的节点
            uiTreeView1.Nodes.Clear();
            // 初始化数据（这里用假数据代替，你需要根据你的实际情况获取数据）
            var dataList = gpib_type.GetACSourceList();

            // 添加根节点
            TreeNode rootNode = new TreeNode("GPIB ListInfo");
            uiTreeView1.Nodes.Add(rootNode);
            // 添加实体数据节点
            foreach (var entity in dataList)
            {
                TreeNode entityNode = new TreeNode($"{entity.GPIB_Name}::{entity.GPIB_Address}::{entity.Card_Type}");
                rootNode.Nodes.Add(entityNode);
            }

            FileLog.LogShow($"GPIB initialization EquipmentCount:{dataList.Count}", Color.Green, ref LogLine);
            uiTreeView1.ExpandAll();
        }

        /// <summary>
        /// 写入频率参数
        /// </summary>
        /// <param name="gpib_Name">gpib_Name</param>
        /// <param name="gpib_Address">gpib_Address</param>
        /// <param name="FreqValue">FreqValue</param>
        /// <returns></returns>
        public async Task<Bools> WriteFrequency(string gpib_Name, string gpib_Address, float FreqValue)
        {
            var re_respoense = new Bools();
            try
            {
                string write_cmd = string.Format(ACSourseCommand.Set_AC_FREQ, FreqValue);
                string read_cmd = string.Format(ACSourseCommand.Get_AC_FREQ);
               // FileLog.LogDebug(debugger, write_cmd);
                gpib_service.WriteString(gpib_Name, gpib_Address, write_cmd);
                await Task.Delay(1);
                gpib_service.WriteString(gpib_Name, gpib_Address, read_cmd);
                FileLog.LogDebug(debugger, read_cmd);
                await Task.Delay(1);
                re_respoense = gpib_service.ReadString();
                if (string.IsNullOrEmpty(re_respoense.message))
                {
                    FileLog.LogDebug(debugger, "No read Data...");

                }
                FileLog.LogDebug(debugger, re_respoense.message);
                if (float.TryParse( re_respoense.message,out FreqValue))
                {
                    re_respoense.flag = false;
                    re_respoense.message = $"Data Write Error: {re_respoense.message}";
                }

            }
            catch (Exception ex)
            {

                re_respoense.flag = false;
                re_respoense.message = $"{ex.Message}";
            }



            return re_respoense;

        }
        /// <summary>
        /// 写入电压参数
        /// </summary>
        /// <param name="gpib_Name">gpib_Name</param>
        /// <param name="gpib_Address">gpib_Address</param>
        /// <param name="VoltValue">float VoltValue</param>
        /// <returns></returns>
        public async Task<Bools> WriteVoltage(string gpib_Name, string gpib_Address, float VoltValue)
        {
            var re_respoense = new Bools();
            try
            {
                string write_cmd = string.Format(ACSourseCommand.Set_AC_VOLT, VoltValue);
                string read_cmd = string.Format(ACSourseCommand.Get_AC_VOLT);
                gpib_service.WriteString(gpib_Name, gpib_Address, write_cmd);
                await Task.Delay(1);
                gpib_service.WriteString(gpib_Name, gpib_Address, read_cmd);
                re_respoense = gpib_service.ReadString();
                if (string.IsNullOrEmpty(re_respoense.message))
                {
                    FileLog.LogDebug("Command", "No read Data...");

                }
                FileLog.LogDebug("Command", re_respoense.message);
                if (float.Parse(re_respoense.message) != VoltValue)
                {
                    re_respoense.flag = false;
                    re_respoense.message = $"Data Write Error: {re_respoense.message}";
                }
            }
            catch (Exception ex)
            {
                re_respoense.flag = false;
                re_respoense.message = $"{ex.Message}";
            }
            return re_respoense;
        }
        /// <summary>
        /// 设置 OUTP IS ON
        /// </summary>
        /// <param name="gpib_Name"></param>
        /// <param name="gpib_Address"></param>
        /// <returns></returns>
        public async Task<Bools> Set_Output_ON(string gpib_Name, string gpib_Address) 
        {
            var re_respoense = new Bools();
            try
            {
                FileLog.LogDebug("Command", $"{gpib_Name}, {gpib_Address}, {ACSourseCommand.Set_AC_ON}");
                gpib_service.WriteString(gpib_Name, gpib_Address, ACSourseCommand.Set_AC_ON);
                await Task.Delay(1);
                re_respoense.flag = true;
            }
            catch (Exception ex)
            {

                re_respoense.message = $"{ex.Message}";
            }
            return re_respoense;
        }

        /// <summary>
        /// 设置 OUTP IS OFF
        /// </summary>
        /// <param name="gpib_Name"></param>
        /// <param name="gpib_Address"></param>
        /// <returns></returns>
        public async Task<Bools> Set_Output_OFF(string gpib_Name, string gpib_Address)
        {
            var re_respoense = new Bools();
            try
            {
                FileLog.LogDebug("Command",$"{gpib_Name}, {gpib_Address}, {ACSourseCommand.Set_AC_OFF}");
                gpib_service.WriteString(gpib_Name, gpib_Address, ACSourseCommand.Set_AC_OFF);
                await Task.Delay(1);
                re_respoense.flag = true;
            }
            catch (Exception ex)
            {

                re_respoense.message = $"{ex.Message}";
            }
            return re_respoense;
        }

        /// <summary>
        /// 设置 CLS 清除仪器的所有设定
        /// </summary>
        /// <param name="gpib_Name"></param>
        /// <param name="gpib_Address"></param>
        /// <returns></returns>
        public async Task<Bools> Set_Output_CLS(string gpib_Name, string gpib_Address)
        {
            var re_respoense = new Bools();
            try
            {
                FileLog.LogDebug("Command", $"{gpib_Name}, {gpib_Address}, {ACSourseCommand.Set_AC_OFF}");
                gpib_service.WriteString(gpib_Name, gpib_Address, ACSourseCommand.Set_AC_Init);
                await Task.Delay(1);
                re_respoense.flag = true;
            }
            catch (Exception ex)
            {

                re_respoense.message = $"{ex.Message}";
            }
            return re_respoense;
        }
    }
}
