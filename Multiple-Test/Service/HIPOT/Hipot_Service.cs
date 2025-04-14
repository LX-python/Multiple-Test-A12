#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.HIPOT
 * 唯一标识：2924b73d-6b95-44bf-91fe-9d17c06a8f94
 * 文件名：Hipot_Service
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/5 14:27:23
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/5 14:27:23
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.AuthorityManagement;
using Multiple_Test.Dal.Hipot;
using Multiple_Test.Models.API;
using Multiple_Test.Models.Equipment;
using Multiple_Test.Models.HIPOT;
using Multiple_Test.Service.APIResult;
using Multiple_Test.Service.CardType;
using Multiple_Test.Service.CommunicationTest;
using Multiple_Test.Service.Files;
using Multiple_Test.Service.HTTP;
using Multiple_Test.Service.RS232;
using Multiple_Test.Utilities.Constant;
using Multiple_Test.Utilities.db;
using Multiple_Test.Utilities.Office;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Multiple_Test.Service.HIPOT
{
    public class Hipot_Service
    {
        /// <summary>
        /// 注入服务
        /// </summary>
        CardTypeService card_Type = new CardTypeService();
        /// <summary>
        /// 注入sql 层
        /// </summary>
        HipotDalMapper dal;
        /// <summary>
        /// 注入文件管理服务
        /// </summary>
        FilesService files = new FilesService();
        /// <summary>
        /// 接口注入
        /// </summary>
        ConnectService api = new ConnectService();
        /// <summary>
        /// Hipot_Service Initlize()
        /// </summary>
        public Hipot_Service()
        {
            string path = Application.StartupPath + ConstantService.dbPath;
            dal = new HipotDalMapper(path, ConstantService.dbName);
        }

        /// <summary>
        /// 获取串口列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetComList()
        {
            return SerialPort.GetPortNames().ToList();
        }

        /// <summary>
        /// 检查串口是否有效
        /// </summary>
        /// <param name="Card_Type"></param>
        /// <param name="ComName"></param>
        /// <returns></returns>
        public bool CheckComCommunication(ref string Card_Type, ref string ComName)
        {
            try
            {
                var com = GetComList();
                if (com.Count == 0)
                {
                    return false;
                }

                for (int i = 0; i < com.Count; i++)
                {
                    Rs232Communication rs232 = new Rs232Communication(com[i], ConstantService.baudRate_9600);
                    rs232.Open();
                    rs232.SendData(HipotCommand.Get_IDN);
                    string receivedData = rs232.ReceiveData();
                    if (!string.IsNullOrEmpty(receivedData))
                    {
                        ComName = com[i];
                        Card_Type = card_Type.ConvertCardName(receivedData);
                        rs232.Close();
                        return true;
                    }
                    rs232.Close();
                }
            }
            catch (Exception ex)
            {

                FileLog.LogError("CommunicationMsg", ex.Message);
            }
            return false;

        }

        /// <summary>
        /// CheckComCommunication
        /// </summary>
        /// <param name="Card_Type">Card_Type</param>
        /// <param name="ComRelay">ComRelay</param>
        /// <param name="ComName">ComName</param>
        /// <returns></returns>
        public bool CheckComCommunication(ref string Card_Type, ref string ComRelay, ref string ComName)
        {
            try
            {
                var com = GetComList();
                if (com.Count == 0)
                {
                    return false;
                }
                FileLog.LogInformation("CommunicatioinCheck", com.Count.ToString());

                for (int i = 0; i < com.Count; i++)
                {
                    Rs232Communication rs232 = new Rs232Communication(com[i], ConstantService.baudRate_9600);
                    rs232.Open();
                    rs232.SendData(HipotCommand.Get_IDN);
                    Thread.Sleep(500);
                    string receivedData = rs232.ReceiveData();
                    FileLog.LogInformation("CommunicatioinCheck", $"{com[i]} ==>  {receivedData}");
                    if (receivedData.IndexOf("Relay") > -1)
                    {
                        ComRelay = com[i];
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(receivedData))
                        {
                            ComName = com[i];
                            Card_Type = card_Type.ConvertCardName(receivedData);
                        }
                    }
                    rs232.Close();
                }
                FileLog.LogInformation("Config", $"ComRelay={ComRelay},ComName={ComName}");

                if (!string.IsNullOrEmpty(ComRelay) && !string.IsNullOrEmpty(ComName) && !string.IsNullOrEmpty(Card_Type))
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {

                FileLog.LogError("CommunicationMsg", ex.Message);
            }
            return false;

        }

        /// <summary>
        /// 清除上次测试结果
        /// </summary>
        /// <param name="dataGrid"></param>
        public void ClearTestResult(ref UIDataGridView dataGrid)
        {
            // 遍历 DataGridView 的行
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                // 忽略 DataGridView 的最后一行（可能是用于新行的空白行）
                if (!row.IsNewRow)
                {
                    row.Cells[ConstantService.Result].Value = string.Empty;
                    row.Cells[ConstantService.Error_Msg].Value = string.Empty;
                    SetDataGridViewRowColor(Color.White, string.Empty, row);
                }

            }

        }
        /// <summary>
        /// 創建測試步驟
        /// </summary>
        /// <param name="dataGrid"></param>
        public bool CreateEquipmentStep(string ComName, UIDataGridView dataGrid, ref string message)
        {
            try
            {

                Rs232Communication rs232 = new Rs232Communication(ComName, ConstantService.baudRate_9600);
                rs232.Open();
                rs232.SendData(HipotCommand.Get_IDN);
                Thread.Sleep(200);
                string receivedData = rs232.ReceiveData();
                if (string.IsNullOrEmpty(receivedData))
                {
                    rs232.Close();
                    message = ConstantService.Abnormal_Comunication;
                    return false;
                }
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    // 忽略 DataGridView 的最后一行（可能是用于新行的空白行）
                    if (!row.IsNewRow)
                    {

                        string Step = row.Cells[ConstantService.Step].Value.ToString();
                        string Mode = Convert.ToString(row.Cells[ConstantService.Mode].Value);
                        string Condition = Convert.ToString(row.Cells[ConstantService.Condition].Value);
                        switch (Mode)
                        {
                            case ConstantService.AC:
                                {
                                    var StepEntity = JsonConvert.DeserializeObject<EntityACSetting>(Condition);
                                    //设定电压
                                    rs232.SendData(string.Format(HipotCommand.Set_LEVel, Step, ConstantService.AC, StepEntity.Volt));
                                    Thread.Sleep(200);
                                    //设定电流
                                    rs232.SendData(string.Format(HipotCommand.Set_LIMIT_HIGH, Step, ConstantService.AC, double.Parse(StepEntity.High) / 1000)); ;
                                    Thread.Sleep(200);
                                    //设定测试时间
                                    rs232.SendData(string.Format(HipotCommand.Set_TestTime, Step, ConstantService.AC, StepEntity.Time));
                                    Thread.Sleep(200);
                                    //设定测试通道
                                    rs232.SendData(string.Format(HipotCommand.Set_Chan, Step, ConstantService.AC, StepEntity.Chan_HIGH, StepEntity.Chan_LOW));
                                    Thread.Sleep(200);
                                    //设定测试电弧
                                    if (StepEntity.ARC > 0)
                                    {
                                        StepEntity.ARC = StepEntity.ARC / 1000;
                                    }
                                    rs232.SendData(string.Format(HipotCommand.Set_ARC, Step, ConstantService.AC, StepEntity.ARC));
                                    break;
                                }

                            case ConstantService.DC:
                                {
                                    var StepEntity = JsonConvert.DeserializeObject<EntityACSetting>(Condition);
                                    //设定电压
                                    rs232.SendData(string.Format(HipotCommand.Set_LEVel, Step, ConstantService.DC, StepEntity.Volt));
                                    Thread.Sleep(200);
                                    //设定电流
                                    rs232.SendData(string.Format(HipotCommand.Set_LIMIT_HIGH, Step, ConstantService.DC, double.Parse(StepEntity.High) / 1000)); ;
                                    Thread.Sleep(200);
                                    //设定测试时间
                                    rs232.SendData(string.Format(HipotCommand.Set_TestTime, Step, ConstantService.DC, StepEntity.Time));
                                    Thread.Sleep(200);
                                    //设定测试通道
                                    rs232.SendData(string.Format(HipotCommand.Set_Chan, Step, ConstantService.DC, StepEntity.Chan_HIGH, StepEntity.Chan_LOW));
                                    Thread.Sleep(200);
                                    //设定测试电弧
                                    if (StepEntity.ARC > 0)
                                    {
                                        StepEntity.ARC = StepEntity.ARC / 1000;
                                    }
                                    rs232.SendData(string.Format(HipotCommand.Set_ARC, Step, ConstantService.DC, StepEntity.ARC));
                                    break;
                                }


                            case ConstantService.IR:
                                {
                                    var StepEntity = JsonConvert.DeserializeObject<EntityACSetting>(Condition);
                                    //设定电压
                                    rs232.SendData(string.Format(HipotCommand.Set_LEVel, Step, ConstantService.IR, StepEntity.Volt));
                                    Thread.Sleep(200);
                                    //设定电流
                                    rs232.SendData(string.Format(HipotCommand.Set_LIMIT_HIGH, Step, ConstantService.IR, double.Parse(StepEntity.High) / 1000)); ;

                                    Thread.Sleep(200);//设定测试时间
                                    rs232.SendData(string.Format(HipotCommand.Set_TestTime, Step, ConstantService.IR, StepEntity.Time));
                                    //设定测试通道
                                    rs232.SendData(string.Format(HipotCommand.Set_Chan, Step, ConstantService.IR, StepEntity.Chan_HIGH, StepEntity.Chan_LOW));
                                    Thread.Sleep(200);
                                    //设定测试电弧
                                    if (StepEntity.ARC > 0)
                                    {
                                        StepEntity.ARC = StepEntity.ARC / 1000;
                                    }
                                    rs232.SendData(string.Format(HipotCommand.Set_ARC, Step, ConstantService.IR, StepEntity.ARC));
                                    break;
                                }
                        }

                    }

                }

                rs232.Close();
                return true;


                message = ConstantService.Abnormal_Comunication;
                return false;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 清除测试步骤
        /// </summary>
        /// <param name="reComName">reComName</param>
        /// <param name="reCardType">reCardType</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ClearEquipmentStep(ref string reComName, ref string reCardType, ref string message)
        {
            string ComName = "";
            string CardType = "";
            if (CheckComCommunication(ref CardType, ref ComName))
            {
                reComName = ComName;
                reCardType = CardType;
                Rs232Communication rs232 = new Rs232Communication(ComName, 9600);
                rs232.Open();
                rs232.SendData(HipotCommand.Get_IDN);
                Thread.Sleep(200);
                string receivedData = rs232.ReceiveData();
                if (string.IsNullOrEmpty(receivedData))
                {
                    rs232.Close();
                    message = $"{ConstantService.Abnormal_Comunication}";
                    return false;
                }
                //读取测试的步骤
                rs232.SendData(HipotCommand.Get_Step_List);

                string count = rs232.ReceiveData();
                if (!string.IsNullOrEmpty(count))
                {
                    count = count.Substring(1, count.Length - 1);
                    for (int i = 0; i < int.Parse(count); i++)
                    {
                        rs232.SendData(string.Format(HipotCommand.Delete_Test_Step, (i + 1)));
                        Thread.Sleep(200);
                    }

                }
                rs232.Close();
                return true;

            }
            message = ConstantService.Abnormal_Comunication;
            return false;

        }

        public bool ClearEquipmentStep(ref string reComName, ref string reCardType, ref string relayCom, ref string message)
        {
            string ComName = string.Empty;
            string CardType = string.Empty;
            string Comrelay = string.Empty;
            if (CheckComCommunication(ref CardType, ref Comrelay, ref ComName))
            {
                reComName = ComName;
                reCardType = CardType;
                relayCom = Comrelay;
                Rs232Communication rs232 = new Rs232Communication(ComName, 9600);
                rs232.Open();
                rs232.SendData(HipotCommand.Get_IDN);
                Thread.Sleep(500);
                string receivedData = rs232.ReceiveData();
                if (string.IsNullOrEmpty(receivedData))
                {
                    rs232.Close();
                    message = $"{ConstantService.Abnormal_Comunication}";
                    return false;
                }
                //读取测试的步骤
                rs232.SendData(HipotCommand.Get_Step_List);
                Thread.Sleep(500);
                string count = rs232.ReceiveData();
                if (!string.IsNullOrEmpty(count))
                {
                    count = count.Substring(1, count.Length - 1);
                    for (int i = 0; i < int.Parse(count); i++)
                    {
                        rs232.SendData(string.Format(HipotCommand.Delete_Test_Step, (i + 1)));
                        Thread.Sleep(100);
                    }

                }
                rs232.Close();
                return true;

            }
            message = ConstantService.Abnormal_Comunication;
            FileLog.LogInformation("ClearEquipmentStep", message);
            return false;

        }

        /// <summary>
        /// 返回脚本测试所需时间
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public int GetTestScriptTotalTime(UIDataGridView dataGrid)
        {
            int time = 0;
            // 遍历 DataGridView 的行
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                // 忽略 DataGridView 的最后一行（可能是用于新行的空白行）
                if (!row.IsNewRow)
                {
                    string Test_Time = row.Cells[ConstantService.Test_Time].Value.ToString();
                    time += int.Parse(Test_Time);
                }
            }
            return time;
        }
        /// <summary>
        /// 自動測試
        /// </summary>
        public bool AutoTesting(string ComName, int TestTime, ref string message)
        {

            Rs232Communication rs232 = new Rs232Communication(ComName, ConstantService.baudRate_9600);
            rs232.Open();
            rs232.SendData(HipotCommand.Get_IDN);
            Thread.Sleep(100);
            string receivedData = rs232.ReceiveData();
            if (string.IsNullOrEmpty(receivedData))
            {
                rs232.Close();
                message = ConstantService.Abnormal_Comunication;
                return false;
            }

            rs232.SendData(HipotCommand.Start_Test);
            Thread.Sleep((TestTime * 1000) + 10);
            rs232.Close();
            return true;
        }

        /// <summary>
        /// 獲取測試結果
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="Test_Volt"></param>
        /// <param name="Test_Current"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool GetTestResult(string ComName, ref string result, ref UIDataGridView dataGrid, ref string message)
        {
            try
            {

                Rs232Communication rs232 = new Rs232Communication(ComName, ConstantService.baudRate_9600);
                rs232.Open();
                rs232.SendData(HipotCommand.Get_IDN);
                //string receivedData = rs232.ReceiveData();
                //if (string.IsNullOrEmpty(receivedData))
                //{
                //    rs232.Close();
                //    message = $"{ConstantService.Abnormal_Comunication}";
                //    FileLog.LogError("GetTestResultError", message);
                //    return false;
                //}

                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    // 忽略 DataGridView 的最后一行（可能是用于新行的空白行）
                    if (!row.IsNewRow)
                    {

                        string Step = row.Cells["Step"].Value.ToString();
                        string Mode = Convert.ToString(row.Cells["Mode"].Value);
                        string Condition = Convert.ToString(row.Cells["Condition"].Value);
                        switch (Mode)
                        {
                            case ConstantService.AC:
                                {
                                    var StepEntity = JsonConvert.DeserializeObject<EntityACSetting>(Condition);
                                    string dataResult = ConstantService.FAIL;
                                    //获取测试电流
                                    rs232.SendData(string.Format(HipotCommand.Get_Test_Curr, Step));
                                    string dataResultCurrent = rs232.ReceiveData();
                                    var Test_Current = double.Parse(dataResultCurrent, System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowExponent) * 1000;
                                    //var Test_Current_LimitHigh = row.Cells[ConstantService.Limit_High].Value.ToString();
                                    //var Test_Current_LimitLow = row.Cells[ConstantService.Limit_Low].Value.ToString();
                                    row.Cells[ConstantService.Test_Current].Value = $"{Test_Current} mA";
                                    //if (Test_Current < double.Parse(Test_Current_LimitHigh) && Test_Current >= double.Parse(Test_Current_LimitLow))
                                    //{
                                    //    dataResult = ConstantService.PASS;
                                    //}
                                    //获取测试电压
                                    rs232.SendData(string.Format(HipotCommand.Get_Test_Volt, Step));
                                    Thread.Sleep(100);
                                    string dataResultVolt = rs232.ReceiveData();
                                    row.Cells[ConstantService.Test_Volt].Value = $"{double.Parse(dataResultVolt, System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowExponent) / 1000}KV";

                                    //获取测试结果
                                    rs232.SendData(string.Format(HipotCommand.Get_Test_Result, Step));
                                    Thread.Sleep(100);
                                    dataResult = rs232.ReceiveData();
                                    dataResult = ConvertTestResultCode(dataResult);

                                    if (dataResult == ConstantService.PASS)
                                    {
                                        result = ConstantService.PASS;
                                        row.Cells[ConstantService.Result].Value = ConstantService.PASS;
                                        SetDataGridViewRowColor(Color.SpringGreen, "", row);
                                    }
                                    else
                                    {

                                        result = ConstantService.FAIL;
                                        row.Cells[ConstantService.Result].Value = ConstantService.FAIL;
                                        row.Cells[ConstantService.Error_Msg].Value = dataResult;
                                        SetDataGridViewRowColor(Color.Red, dataResult, row);
                                    }
                                    break;
                                }
                        }

                    }

                }
                //如果设备是Fail 需要按一下设备停止键
                if (result == ConstantService.FAIL)
                {
                    rs232.SendData(HipotCommand.Stop_Test);
                }
                rs232.Close();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                FileLog.WriteLog("GetTestResultError", ex.Message);
                return false;
            }


        }

        /// <summary>
        /// 设置行的背景颜色
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="ErrorMessage">报错信息</param>
        /// <param name="row">补充的行</param>
        private void SetDataGridViewRowColor(Color color, string ErrorMessage, DataGridViewRow row)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                row.Cells["Error_Msg"].Value = ErrorMessage;
            }
            row.DefaultCellStyle.BackColor = color;
        }

        /// <summary>
        /// 转换测试Logs
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string ConvertTestResultCode(string code)
        {
            code = code.Trim().Replace("\r\n", "");
            switch (code)
            {
                case "116":
                    {

                        return ConstantService.PASS;

                    }
                case "113":
                    {

                        return "User Stop";
                    }

                case "114":
                    {

                        return "Can Not Test";
                    }

                case "115":
                    {

                        return "Testing";
                    }


                case "112":
                    {

                        return "Stop";
                    }

                case "120":
                    {

                        return "GR Cont";
                    }

                case "121":
                    {

                        return "Tripped";
                    }

                case "17":
                    {

                        return "Hi";
                    }

                case "18":
                    {

                        return "Lo";
                    }

                case "19":
                    {

                        return "ARC";
                    }

                case "----":
                    {

                        return "Check low";
                    }

                case "22":
                    {

                        return "ADI OVER";
                    }



                case "23":
                    {

                        return "ADV OVER";
                    }

                case "26":
                    {

                        return "Real High";
                    }

                case "33":
                    {

                        return "HI";
                    }
                case "34":
                    {

                        return "LO";
                    }

                case "35":
                    {

                        return "ARC";
                    }

                case "37":
                    {

                        return "Check Low";
                    }

                case "49":
                    {

                        return "HI";
                    }
                case "50":
                    {

                        return "LO";
                    }
                case "38":
                    {

                        return "ADI OVER";
                    }

                case "39":
                    {

                        return "ADV OVER";
                    }
                case "97":
                    {

                        return "Short";
                    }

                case "98":
                    {

                        return "Open";
                    }

                case "100":
                    {

                        return "IO";
                    }

                case "103":
                    {

                        return "ADI OVER";
                    }
                case "102":
                    {

                        return "ADV OVER";
                    }


                case "54":
                    {

                        return "ADI OVER";
                    }

                case "55":
                    {

                        return "ADV OVER";
                    }
                default:
                    {

                        return code;
                    }

            }


        }
        /// <summary>
        /// 获取箱号当前测试数量
        /// </summary>
        /// <param name="box_no"></param>
        /// <returns></returns>
        public EntityTestQty GetTestQty(string box_no)
        {
            var total_qty = 0;
            var pass_qty = 0;
            var fail_qty = 0;
            //get total
            var total_data = dal.GetNowTotalTestQty(box_no);
            if (total_data.Rows.Count != 0)
            {
                string total_qty_str = total_data.Rows[0]["total_qty"].ToString();
                int.TryParse(total_qty_str, out total_qty);
            }
            //get pass
            var pass_data = dal.GetNowPassTestQty(box_no);
            if (pass_data.Rows.Count != 0)
            {
                string pass_qty_str = pass_data.Rows[0]["pass_qty"].ToString();
                int.TryParse(pass_qty_str, out pass_qty);
            }
            //Fail
            var fail_data = dal.GetNowFailTestQty(box_no);
            if (fail_data.Rows.Count != 0)
            {
                string fail_qty_str = fail_data.Rows[0]["fail_qty"].ToString();
                int.TryParse(fail_qty_str, out fail_qty);
            }

            return new EntityTestQty { total_qty = total_qty, pass_qty = pass_qty, fail_qty = fail_qty };

        }

        /// <summary>
        /// 插入测试数据
        /// </summary>
        /// <param name="TestData"></param>
        /// <returns></returns>
        public bool InsertTestRecord(object TestData)
        {
            return dal.InsertTestRecord(TestData);
        }
        /// <summary>
        /// 保存测试记录在本地
        /// </summary>
        /// <param name="gridView"></param>
        public void SaveTestRecord(string boxNumber, DataTable dt, UIDataGridView gridView)
        {
            try
            {
                var data = ConvertDataGridViewToDataTable(gridView.DataSource);
                string path = Application.StartupPath + ConstantService.pathSlash + ConstantService.TestLogs + ConstantService.pathSlash + DateTime.Now.ToString("yyyy-MM-dd");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                data = MergeDataTables(dt, data);
                string csvName = boxNumber + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
                ExcelService.ConvertDataTableToCsv(data, path + ConstantService.pathSlash + csvName);
            }
            catch (Exception ex)
            {

                FileLog.LogError("SaveLogError", ex.Message);
            }

        }
        /// <summary>
        /// 轉換數據 DataGridView.DataSource to dataTable
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        private DataTable ConvertDataGridViewToDataTable(object dataSource)
        {
            // 创建一个新的 DataTable
            DataTable dataTable = new DataTable();

            // 获取数据源的类型
            Type sourceType = dataSource.GetType();

            // 确保数据源是集合类型
            //if (sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(BindingList<>))
            //{
            // 获取集合的元素类型
            Type elementType = sourceType.GetGenericArguments()[0];

            // 添加 DataTable 的列，使用元素类型的属性
            foreach (var property in elementType.GetProperties())
            {
                dataTable.Columns.Add(property.Name, property.PropertyType);
            }

            // 添加数据行
            foreach (var item in (IEnumerable)dataSource)
            {
                DataRow row = dataTable.NewRow();

                foreach (var property in elementType.GetProperties())
                {
                    row[property.Name] = property.GetValue(item);
                }

                dataTable.Rows.Add(row);
            }
            //}

            return dataTable;
        }

        /// <summary>
        /// 合并两个 DataTable 
        /// </summary>
        /// <param name="table1"></param>
        /// <param name="table2"></param>
        /// <returns></returns>
        public DataTable MergeDataTables(DataTable table1, DataTable table2)
        {
            DataTable mergedTable = new DataTable("MergedTable");

            // 复制第一个 DataTable 结构
            mergedTable = table1.Clone();
            // 为所有 string 列设置 MaxLength
            foreach (DataColumn col in mergedTable.Columns)
            {
                if (col.DataType == typeof(string))
                {
                    col.MaxLength = int.MaxValue; // 或者您可以设置为适当的最大长度
                }
            }
            // 合并数据
            mergedTable.Merge(table1);
            mergedTable.Merge(table2);

            return mergedTable;
        }

        /// <summary>
        /// 检查测试载具状态
        /// </summary>
        /// <param name="Vehicle_Number"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<EntityResult> CheckVehicleStatus(string Vehicle_Number)
        {
            var re_object = new EntityResult();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"?factoryName={UserInfo.FactoryName}&Vehicle_Number={Vehicle_Number}");
                var result = await api.Get_Data(APISRC.API + APIConstant.GetVehicleStatus + sb.ToString(), UserInfo.Token, "");
                var info = JsonConvert.DeserializeObject<ResponseResult>(result.result);
                if (info.code == -1)
                {
                    re_object.flag = false;
                    re_object.result = info.msg;
                }
                else if (info.code == 0)
                {
                    var Vehicle = JsonConvert.DeserializeObject<EntityVehicle>(info.data.ToString());
                    if (Vehicle.Vehicle_Status != 1)
                    {
                        re_object.flag = false;
                        re_object.result = ApiService.GetStatus(Vehicle.Vehicle_Status);
                    }
                    else
                    {
                        re_object.flag = true;
                        re_object.vehicle_qty = Vehicle.Vehicle_Qty;
                        re_object.result = Vehicle.Vehicle_Status.ToString();
                    }
                }
                else
                {
                    re_object.flag = false;
                    re_object.result = info.msg;
                }

            }
            catch (Exception ex)
            {
                re_object.flag = false;
                re_object.result = ex.Message;
                FileLog.LogError("CheckVeicleStatus", ex.Message);
            }

            return re_object;


        }

        /// <summary>
        /// 输入载具编号
        /// </summary>
        /// <param name="ExitFlag"></param>
        /// <returns></returns>
        public async Task<EntityInputFlag> InputVehicleNumber()
        {
            var re = new EntityInputFlag();
            // 创建 UIInputForm 对话框
            UIInputForm myUIInputForm = new UIInputForm();
            myUIInputForm.Text = "提示";
            myUIInputForm.Label.Text = "请输入治具编号";
            if (myUIInputForm.ShowDialog() == DialogResult.OK)
            {
                string inputString = myUIInputForm.Editor.Text;
                if (string.IsNullOrEmpty(inputString))
                {

                    re.message = "没有输入内容";
                    return re;
                }
                //检查载具状态
                var status = await CheckVehicleStatus(inputString);
                if (status.flag)
                {
                    re.message = inputString;
                    re.Flag = true;
                    re.vehicle_Qty = status.vehicle_qty;
                    return re;
                }
                else
                {  //测试载具不能用 Show Message
                   //ShowMessage(status.result);
                    re.Flag = false;
                    re.message = status.result;
                    return re;
                }
            }
            else
            {
                re.ExitFlag = true;
                re.message = "用户取消输入";
                re.Flag = false;
                return re; ;
            }
        }


        /// <summary>
        /// 输入载具编号
        /// </summary>
        /// <param name="ExitFlag"></param>
        /// <returns></returns>
        public async Task<EntityInputFlag> InputVehicleNumberManual()
        {
            var re = new EntityInputFlag();
            // 创建 UIInputForm 对话框
            UIInputForm myUIInputForm = new UIInputForm();
            myUIInputForm.Text = "提示";
            myUIInputForm.Label.Text = "请输入治具编号NA";
            if (myUIInputForm.ShowDialog() == DialogResult.OK)
            {
                string inputString = myUIInputForm.Editor.Text;
                if (string.IsNullOrEmpty(inputString))
                {

                    re.message = "没有输入内容";
                    return re;
                }
                //检查载具状态
                if (inputString.ToUpper().Trim() == "NA")
                {
                    re.message = inputString;
                    re.Flag = true;
                    return re;
                }
                else
                {  //测试载具不能用 Show Message
                   //ShowMessage(status.result);
                    re.Flag = false;
                    re.message = "手动版本，请扫描NA测试";
                    return re;
                }
            }
            else
            {
                re.ExitFlag = true;
                re.message = "用户取消输入";
                re.Flag = false;
                return re; ;
            }
        }

        /// <summary>
        /// 修改测试载具的状态
        /// </summary>
        /// <param name="Vehicle_Number"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<EntityResult> Modify_VehicleStatus(string Vehicle_Number, int status, string modifyMessage)
        {
            var result = new EntityResult();
            try
            {
                Dictionary<string, object> obj = new Dictionary<string, object>();
                obj.Add("Vehicle_Number", Vehicle_Number);
                obj.Add("Factory_Name", UserInfo.FactoryName);
                obj.Add("status", status);
                obj.Add("modifyMessage", modifyMessage);
                //呼叫API 
                var res = await api.SendData($"{APISRC.API}{APIConstant.ModifyVehicleStatus}", UserInfo.Token, JsonConvert.SerializeObject(obj));
                if (res.flag)
                {
                    //转换JSON
                    var convertResult = JsonConvert.DeserializeObject<ResponseResult>(res.result);
                    if (convertResult.code == 0)
                    {
                        result.flag = true;
                        result.result = convertResult.msg;
                        return result;
                    }
                    else
                    {//(convertResult.code != 0)
                        result.result = convertResult.msg;
                        return result;
                    }

                }

                return res;
            }
            catch (Exception ex)
            {
                result.result = ex.Message;
            }
            return result;


        }

        /// <summary>
        /// 气缸下降
        /// </summary>
        /// <param name="com"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Machine_Down(string com, ref string message)
        {
            try
            {
                Rs232Communication rs232 = new Rs232Communication(com, ConstantService.baudRate_9600);
                rs232.Open();
                //rs232.SendData(HipotCommand.ReadVolt);
                //string receivedData = rs232.ReceiveData();
                //if (!string.isnullorempty(receiveddata))
                //{  //小于4v 表示治具是下压状态
                //    var result = double.parse(receiveddata);
                //    if (result > 4)
                //    {
                rs232.SendData(HipotCommand.Down);
                Thread.Sleep(300);
                var receivedData = rs232.ReceiveData();
                if (receivedData == "Machine is down...")
                {
                    rs232.Close();
                    return true;
                }
                // }
                rs232.Close();
                return true;



                message = "气缸下降控制失败....";
                rs232.Close();
                return false;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                FileLog.LogError("Machine_DownError", ex.Message);
                return false;
            }

        }
        /// <summary>
        /// 气缸上升
        /// </summary>
        /// <param name="com"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Machine_Up(string com, ref string message)
        {
            try
            {
                Rs232Communication rs232 = new Rs232Communication(com, ConstantService.baudRate_9600);
                rs232.Open();
                rs232.SendData(HipotCommand.UP);
                Thread.Sleep(200);
                string receivedData = rs232.ReceiveData();
                if (receivedData == "Machine is up...")
                {  //

                    rs232.SendData(HipotCommand.ReadVolt);
                    Thread.Sleep(200);
                    receivedData = rs232.ReceiveData();
                    //小于4V 表示治具是下压状态
                    var result = double.Parse(receivedData);
                    if (result < 4)
                    {
                        message = "请等待治具上升";
                        rs232.Close();
                        return false;

                    }
                    rs232.Close();
                    return true;

                }
                message = $"气缸上升控制失败....{receivedData}";
                rs232.Close();
                return false;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                FileLog.LogError("Machine_DownError", ex.Message);
                return false;
            }

        }

        /// <summary>
        /// 治具气缸上升
        /// </summary>
        /// <param name="ComName"></param>
        /// <param name="message"></param>
        public void CylinderUP(string ComName, ref string message)
        {
            try
            {
                Rs232Communication rs232 = new Rs232Communication(ComName, ConstantService.baudRate_9600);
                rs232.Open();

                rs232.SendData(HipotCommand.UP);
                Thread.Sleep(200);
            }
            catch (Exception ex)
            {
                message = ex.Message;

            }

        }

        /// <summary>
        /// 测试治具气缸下降
        /// </summary>
        /// <param name="ComName"></param>
        /// <param name="message"></param>
        public void CylinderDown(string ComName, ref string message)
        {
            try
            {
                Rs232Communication rs232 = new Rs232Communication(ComName, ConstantService.baudRate_9600);
                rs232.Open();
                rs232.SendData(HipotCommand.Down);
                Thread.Sleep(200);
            }
            catch (Exception ex)
            {
                message = ex.Message;

            }

        }
    }
}
