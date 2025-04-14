using Multiple_Test.AuthorityManagement;
using Multiple_Test.Controller.UIModels.HIPOT;
using Multiple_Test.Controller.UIModels.Pages;
using Multiple_Test.Controller.UIModels.Pages.Result;
using Multiple_Test.Controller.UIModels.Pages.SystemProcess;
using Multiple_Test.Enumeration;
using Multiple_Test.Models.HIPOT;
using Multiple_Test.Models.QRCode;
using Multiple_Test.Service;
using Multiple_Test.Service.Buttons;
using Multiple_Test.Service.Charts;
using Multiple_Test.Service.ChromaMES;
using Multiple_Test.Service.DataGridViewService;
using Multiple_Test.Service.Files;
using Multiple_Test.Service.HIPOT;
using Multiple_Test.Service.QRCode;
using Multiple_Test.Utilities.Constant;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace Multiple_Test.Controller.Home
{
    public partial class FrmHipotAuto : UIForm
    {

        /// <summary>
        /// 服务注入
        /// </summary>
        private readonly Hipot_Service service = new Hipot_Service();
        private readonly QRCode_Service qRCode = new QRCode_Service();
        private readonly FilesService file_servic = new FilesService();
        private readonly MES_Service mes = new MES_Service();
        private List<EntitySerialNumber> serialNumbers = new List<EntitySerialNumber>();
        private bool isBoxFullFlag = false;
        private bool ClostFlag = false;
        DataGridView_Service dataGrid;
        pageProcess processfrm = new pageProcess();
        public int Now_TestTotalQty = 0;
        /// <summary>
        /// 脚本信息
        /// </summary>
        List<EntityTestStep> listStep = new List<EntityTestStep>();
        /// <summary>
        /// 初始化
        /// </summary>
        public FrmHipotAuto()
        {
            InitializeComponent();
            initializationEventAsync();

        }
        /// <summary>
        /// 打開測試記錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenTestRawData_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + ConstantService.pathSlash + ConstantService.TestLogs;
            file_servic.OpenPath(path);
        }

        /// <summary>
        /// 關閉窗體
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void FrmHipot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClostFlag)
            {
                this.Dispose();
                return;

            }
            if (this.ShowAskDialog("您確定要退出Hi-Pot系統嗎?"))
            {
                ClostFlag = true;
            }
            else
            {
                e.Cancel = true;

            }
        }

        /// <summary>
        /// 打开系统Log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void BtnOpenLog_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + ConstantService.pathSlash + ConstantService.LogsPath;
            file_servic.OpenPath(path);
        }
        /// <summary>
        /// 打开脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpenScript_Click(object sender, EventArgs e)
        {
            //初始化圖標
            ChartsPicService.Set_TestData(0, 0, 0, ref PieChart);
            ButtonsService.DisableBtn(btnOpenScript);
            string message = string.Empty;
            string SelectScriptPath = file_servic.OpenScriptFile(ref message);
            if (string.IsNullOrEmpty(SelectScriptPath))
            {
                ShowMessage(message);
                ButtonsService.EnableBtn(btnOpenScript);
                return;
            }
            List<EntityTestStep> script = file_servic.ConvertStepScript(SelectScriptPath);
            if (script.Count == 0)
            {
                ShowMessage($"没有读到脚本 {SelectScriptPath}");
                ButtonsService.EnableBtn(btnOpenScript);
                return;
            }
            //
            //检查Relay
            scriptPath.Text = SelectScriptPath;
            SetProgramModel(EnumProgramsModel.Run);

            //加载脚本
            listStep = script;
            CreateTestStep();

            ButtonsService.EnableBtn(btnOpenScript);
        }
        /// <summary>
        /// 保存脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (dataGrid.GetDataGridViewCount() == 0)
            {
                ShowMessage("请先创建测试脚本....");
                return;
            }
            UIInputForm myUIInputForm = new UIInputForm();
            myUIInputForm.Text = "提示";
            myUIInputForm.Label.Text = "请输入脚本名称";
            if (myUIInputForm.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(myUIInputForm.Editor.Text))
                {
                    ShowMessage("没有输入内容");
                    return;
                }
                string scrpit = dataGrid.ConvertDataGridViewToJson();
                if (file_servic.SaveScript(myUIInputForm.Editor.Text, scrpit))
                {
                    this.ShowSuccessTip($"{myUIInputForm.Editor.Text}脚本保存成功..");
                }
                else
                {
                    ShowMessage("脚本保存失败,请重新测试!!!");
                }

            }
            else
            {
                ShowMessage("没有输入脚本名称");
            }

            return;
        }

        /// <summary>
        /// 运行按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnRun_Click(object sender, EventArgs e)
        {
            this.btnRun.Enabled = false;
            //校验仪器参数
            if (EquipmentTester()) // 假设"成功"是你期望的成功返回值
            {
                //自动循环测试
                await AutoTesModel();
            }
            else
            {
                ShowMessage($"请检查脚本或通讯是否正常 !!!");
                this.dataGridView1.DataSource = null;
                this.scriptPath.Text = "";
                PieChart.Visible = false;
            }

            this.btnRun.Enabled = true;
        }
        /// <summary>
        /// 添加功能按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddFunction_Click(object sender, EventArgs e)
        {
            CreateFunction();
        }

        /// <summary>
        /// 添加测试功能
        /// </summary>
        private void CreateFunction()
        {

            if (radioAC.Checked)
            {
                CreateACTestModel();
                return;
            }

            if (radioDC.Checked)
            {
                CreateDCTestModel();
                return;
            }

            if (radioiR.Checked)
            {
                // frm = new pageSettingHipotIR();
            }

            // ShowFrm(ref frm);


        }

        /// <summary>
        /// 創建AC 測試
        /// </summary>
        private void CreateACTestModel()
        {

            var frm = new pageSettingHipotAC(0);
            frm.ShowDialog();
            if (DialogResult.OK == frm.DialogResult)
            {

                var step = new EntityTestStep();
                step.Mode = ConstantService.AC;
                step.Step = listStep.Count + 1;
                step.Test_Time = frm.entity.Time;
                step.Condition = $"{JsonConvert.SerializeObject(frm.entity)}";
                step.Limit_Low = frm.entity.Limit_Low + "mA";
                step.Limit_High = frm.entity.Limit_High + "mA";
                step.Test_Item = frm.entity.Test_Item;
                listStep.Add(step);
                CreateTestStep();
            }
        }

        /// <summary>
        /// 创建DC 测试
        /// </summary>
        private void CreateDCTestModel()
        {
            var frm = new pageSettingHipotDC();
            frm.ShowDialog();
            if (DialogResult.OK == frm.DialogResult)
            {
            }


        }
        /// <summary>
        /// 創建新的測試步驟
        /// </summary>
        private void CreateTestStep()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listStep;
            //  dataGridView1.AutoResizeColumns();
            dataGridView1.Columns["Error_Msg"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Refresh();
        }
        /// <summary>
        /// 显示log
        /// </summary>
        /// <param name="frm"></param>
        private void ShowMessage(string message)
        {
            StyleManager.Style = UIStyle.Red;
            this.Style = StyleManager.Style;
            this.ShowErrorDialog(message);
            //this.ShowErrorNotifier(message,false,2000);
            //await Task.Delay(1000);
            StyleManager.Style = UIStyle.Blue;
            this.Style = StyleManager.Style;
            FileLog.LogInformation("Testing", message);
            //this.ShowErrorTip(message);
        }

        /// <summary>
        /// 箱號碼内容解析 窗體賦值
        /// </summary>
        /// <param name="qrcodeInfo"></param>
        private async Task CreateQrCodeInfo(EntityQRCode qrcodeInfo)
        {
            txtSupplier.Text = qrcodeInfo.supplier;
            txtcycle.Text = qrcodeInfo.cycle;
            txtqty.Text = qrcodeInfo.qty.ToString();
            txtserial_number.Text = qrcodeInfo.serial_number;
            txtPart_Number.Text = qrcodeInfo.part_Number;
            txtLot_Number.Text = qrcodeInfo.Lot_Number;
        }

        /// <summary>
        /// 显示当前步骤
        /// </summary>
        /// <param name="NowRunStep"></param>
        /// <returns></returns>
        private async Task ShowTestStep(string NowRunStep)
        {

        }
        /// <summary>
        /// 自动循环测试
        /// </summary>
        /// <returns></returns>
        private async Task AutoTesModel()
        {    //计算测试总时间
            int Test_Time = service.GetTestScriptTotalTime(dataGridView1);
            while (true)
            {
                //输入箱号
                var checkBox = await InputBoxNumber();
                if (checkBox.Flag)
                {   //清除上次测试结果
                    service.ClearTestResult(ref dataGridView1);
                    //输入治具号
                    var checkVehicle = await service.InputVehicleNumber();
                    if (checkVehicle.Flag)
                    {
                        if (radioSnFlag.Checked)
                        {
                            var snlist = new pageInputSerialNumber(checkVehicle.vehicle_Qty);
                            snlist.ShowDialog();
                            ///获取扫码的条码
                            if (snlist.ScanInfo.Count != checkVehicle.vehicle_Qty)
                            {
                                this.ShowErrorDialog("扫码数量一致");
                                return;
                            }
                            serialNumbers = snlist.ScanInfo;

                        }
                        int vehicle_qty = checkVehicle.vehicle_Qty;
                        txtVQty.Text = vehicle_qty.ToString();
                        this.ShowWaitForm("气缸下降...");
                     
                        //下压治具
                        string message = string.Empty;
                        if (service.Machine_Down(txtRelay.Text, ref message))
                        {
                             this.SetWaitFormDescription("测试中...请等待...");
                            // await Task.Delay(2000);
                            ShowVehicleNumber(checkVehicle.message);
                            //啓動測試
                            //ShowProcess();
                            if (service.AutoTesting(txtComName.Text, Test_Time, ref message))
                            {
                                this.SetWaitFormDescription("测试结束,读取测试结果...请等待...");
                                //测试结束 读取测试信息
                                await Read_AutoTestResult();
                                this.HideWaitForm();
                                // CloseProcess();
                            }
                            else
                            {
                                // CloseProcess(); 
                                ShowMessage("啓動測試失败:" + message);
                                //this.dataGridView1.Columns[0].
                            }

                        }
                        else
                        {

                            ShowMessage(message);
                        }


                    }
                    else
                    {
                        ShowMessage(checkVehicle.message);
                        //如果用户取消输入退出脚本
                        if (checkVehicle.ExitFlag)
                        {
                            ClearTestScriptConfig();
                            return;
                        }
                    }
                    this.HideWaitForm();
                    await Task.Delay(1000);
                }
                else
                {
                    //ShowMessage("退出脚本:"+checkBox.message);
                    //如果用户取消输入退出脚本
                    if (checkBox.ExitFlag)
                    {
                        return;
                    }
                }

            }
        }


        /// <summary>
        /// 配置测试步骤
        /// </summary>
        /// <returns></returns>
        private bool EquipmentTester()
        {
            string message = "";
            //检查是否有测试步骤
            if (dataGridView1.DataSource == null)
            {
                ShowMessage("没有测试程序，请选择或者创建");
                this.btnRun.Enabled = true;
                return false;
            }
            string com = string.Empty;
            string cardType = string.Empty;
            string realy = string.Empty;
            //清除测试步骤
            if (service.ClearEquipmentStep(ref com, ref cardType, ref realy, ref message))
            {
                SetComInfo(com, cardType, realy);
                //配置測試步驟22
                if (service.CreateEquipmentStep(com, dataGridView1, ref message))
                {
                    return true;
                }
                else
                {
                    ShowMessage("配置測試步驟失败:" + message);
                    return false;
                }
            }
            else
            {
                ShowMessage("清除测试步骤失败:" + message);
                return false;
            }
            //检查Relay  Status

        }

        /// <summary>
        /// 设置串口信息 获取Chroma测试的型号设备
        /// </summary>
        /// <param name="ComName"></param>
        /// <param name="cardType"></param>
        /// <returns></returns>
        private async Task SetComInfo(string ComName, string cardType)
        {
            txtComName.Text = ComName;
            txtCardType.Text = cardType;
        }
        private async Task SetComInfo(string ComName, string cardType, string relay)
        {
            txtComName.Text = ComName;
            txtCardType.Text = cardType;
            txtRelay.Text = relay;
        }

        /// <summary>
        /// 输入箱号
        /// </summary>
        /// <param name="ExitFlag">如果等于True 退出当前脚本测试</param>
        /// <returns></returns>
        private async Task<EntityInputFlag> InputBoxNumber()
        {
            if (!string.IsNullOrEmpty(txtqty.Text))
            {
                if (Now_TestTotalQty >= int.Parse(txtqty.Text))
                {
                    if (this.ShowAskDialog($"测试的数量已经大于{Now_TestTotalQty} 设定箱号数量{txtqty.Text}，请更换新的箱号?"))
                    {
                        isBoxFullFlag = true;
                    }

                }
            }

            var result = new EntityInputFlag();
            if (!isBoxFullFlag)
            {
                // 创建 UIInputForm 对话框
                UIInputForm myUIInputForm = new UIInputForm();
                myUIInputForm.Text = "提示";
                myUIInputForm.Label.Text = "请输入箱号条码";
                if (myUIInputForm.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(myUIInputForm.Editor.Text))
                    {
                        ShowMessage("没有输入内容");
                    }

                    string message = "";
                    var qrcodeInfo = new EntityQRCode();
                    if (myUIInputForm.Editor.Text.IndexOf(";") > -1)
                    {
                        qrcodeInfo = qRCode.GetQRCodeInfo(myUIInputForm.Editor.Text, ref message);
                    }
                    else
                    {
                        qrcodeInfo = qRCode.ConvertQrCode(myUIInputForm.Editor.Text, ref message);
                    }


                    if (!string.IsNullOrEmpty(message))
                    {
                        ShowMessage(message);
                        result.Flag = false;
                        result.message = message;
                        return result;
                    }
                    if (qrcodeInfo != null)
                    {
                        //MES 检查箱号 如果失败就退出MES 
                        if (!MES_Service.CommandCheckBox(qrcodeInfo.serial_number, ref message))
                        {
                            result.Flag = false;
                            result.message = message;
                            return result;
                        }
                        //获取机种
                        //var model = MES_Service.Get_Mes_Model(qrcodeInfo.serial_number, ref message);
                        //if (model.Count > 0) 
                        //{
                        //  comProductionModel.DataSource= model;
                        //}


                        //获取品名
                        var name = MES_Service.Get_Mes_Model_FINPARTEAN(qrcodeInfo.serial_number, ref message);
                        if (name.Count > 0)
                        {
                            comProductionModel.DataSource = name;
                        }
                        CreateQrCodeInfo(qrcodeInfo);
                        var last_testData = service.GetTestQty(qrcodeInfo.serial_number);
                        int NowTestQty = last_testData.total_qty;
                        ChartsPicService.Set_TestData(qrcodeInfo.qty, last_testData.fail_qty, last_testData.pass_qty, ref PieChart);
                        //判断是否满箱
                        if (NowTestQty <= qrcodeInfo.qty)
                        {
                            isBoxFullFlag = true;
                            result.Flag = false;
                            result.message = message;
                            return result;
                        }

                    }
                    else
                    {
                        result.Flag = false;
                        result.message = message;
                        return result;
                    }
                    result.Flag = true;
                    result.message = message;
                    return result;
                }
                else
                {
                    //ShowMessage("用户取消输入");

                    ClearTestScriptConfig();
                    result.Flag = false;
                    result.ExitFlag = true;
                    result.message = "用户取消输入";
                    return result;
                }
            }
            else
            {
                //没有满箱 直接调用扫描治具测试
                result.Flag = true;
                result.ExitFlag = false;
                return result;

            }
        }

        /// <summary>
        /// 显示输入的治具号
        /// </summary>
        /// <param name="VehicleNumber"></param>
        /// <returns></returns>
        private async Task ShowVehicleNumber(string VehicleNumber)
        {
            txtVehicleNumber.BeginInvoke(new Action(() =>
            {
                txtVehicleNumber.Text = VehicleNumber;
            }));
        }

        /// <summary>
        /// 清除当前测试步骤
        /// </summary>
        private void ClearTestScriptConfig()
        {
            dataGridView1.DataSource = null;
            listStep.Clear();

        }

        /// <summary>
        /// 显示测试结果
        /// </summary>
        /// <param name="result"></param>
        private void ShowTestResult(string result)
        {
            var frm = new pageResult(result);
            frm.ShowDialog();
        }
        /// <summary>
        /// 更新圖片數據
        /// </summary>
        /// <param name="boxNumber"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        private async Task ShowPicData(string boxNumber, int qty)
        {
            var last_testData = service.GetTestQty(boxNumber);
            int NowTestQty = last_testData.total_qty;
            this.ShowSuccessNotifier($"Total:{last_testData.total_qty} Pass:{last_testData.fail_qty},Fail:{last_testData.fail_qty}", false, 1000);
            await Task.Delay(1000);
            ChartsPicService.Set_TestData(qty, last_testData.fail_qty, last_testData.pass_qty, ref PieChart);
            Now_TestTotalQty = NowTestQty;
        }

        /// <summary>
        /// 把Data 輸入的資料封裝
        /// </summary>
        /// <param name="Cavity">测试穴位</param>
        /// <returns></returns>
        private DataTable GetOsData(int Cavity)
        {
            DataTable dataTable1 = new DataTable("Table1");
            dataTable1.Columns.Add("Equipment_Type", typeof(string));
            dataTable1.Columns.Add("Customer", typeof(string));
            dataTable1.Columns.Add("Production_Model", typeof(string));
            dataTable1.Columns.Add("Part_Number", typeof(string));
            dataTable1.Columns.Add("Supplier", typeof(string));
            dataTable1.Columns.Add("Cycle", typeof(string));
            dataTable1.Columns.Add("Qty", typeof(string));
            dataTable1.Columns.Add("Serial_number", typeof(string));
            dataTable1.Columns.Add("Lot_Number", typeof(string));
            dataTable1.Columns.Add("Fixture", typeof(string));
            dataTable1.Columns.Add("Vehicle", typeof(string));
            dataTable1.Columns.Add("Cavity", typeof(string));
            DataRow dr = dataTable1.NewRow();
            dr["Equipment_Type"] = txtCardType.Text;
            dr["Customer"] = comCustomer.Text;
            dr["Production_Model"] = comProductionModel.Text;
            dr["Part_Number"] = txtPart_Number.Text;
            dr["Supplier"] = txtSupplier.Text;
            dr["Cycle"] = txtcycle.Text;
            dr["Qty"] = txtqty.Text;
            dr["Serial_number"] = txtserial_number.Text;
            dr["Lot_Number"] = txtLot_Number.Text;
            dr["Fixture"] = comFixture.Text;
            dr["Vehicle"] = txtVehicleNumber.Text;
            dr["Cavity"] = Cavity;
            dataTable1.Rows.Add(dr);
            return dataTable1;


        }
        /// <summary>
        /// 設置程序模式
        /// </summary>
        /// <param name="model"></param>
        private void SetProgramModel(EnumProgramsModel model)
        {
            switch (model)
            {
                case EnumProgramsModel.Run:
                    {
                        ButtonsService.HideVisible(btnAddFunction);
                        ButtonsService.HideVisible(btnMinus);
                        PieChart.Visible = true;
                        comCustomer.Enabled = false;
                        comProductionModel.Enabled = false;
                        comFixture.Enabled = false;
                        //this.dataGridView1.Top -= btnAddFunction.Height;
                        //this.dataGridView1.Height += btnAddFunction.Height;
                        break;
                    }
                case EnumProgramsModel.Edit:
                    {

                        comCustomer.Enabled = true;
                        comProductionModel.Enabled = true;
                        comFixture.Enabled = true;
                        ButtonsService.ShowVisible(btnAddFunction);
                        ButtonsService.ShowVisible(btnMinus);
                        PieChart.Visible = false;
                        //this.dataGridView1.Top += btnAddFunction.Height;
                        //this.dataGridView1.Height -= btnAddFunction.Height;

                        break;
                    }
                case EnumProgramsModel.Stop:
                    {
                        break;
                    }


            }
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        private async Task initializationEventAsync()
        {
            //this.DoubleBuffered = true;
            this.btnAddFunction.Click += BtnAddFunction_Click;
            this.btnRun.Click += BtnRun_Click;
            this.btnSave.Click += BtnSave_Click;
            this.btnOpenScript.Click += BtnOpenScript_Click;
            this.btnOpenLog.Click += BtnOpenLog_Click;
            dataGrid = new DataGridView_Service(dataGridView1);
            ChartsPicService.Set_TestData(0, 0, 0, ref PieChart);
            //SwitchInputLanguageService.SwitchInputLanguage();
            this.FormClosing += FrmHipot_FormClosing;
            this.btnOpenTestRawData.Click += BtnOpenTestRawData_Click;
            this.btnNewScript.Click += BtnNewScript_Click;
            this.exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            PieChart.Visible = false;
            //显示登录用户信息
            this.lab_UserName.Text = UserInfo.username + "-" + UserInfo.Name;
            this.lab_UserName.Left = this.Width - uiAvatar1.Width - this.lab_UserName.Width - 15;
            this.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (listStep[e.RowIndex].Mode == "AC")
                {
                    var setting = JsonConvert.DeserializeObject<EntityACSetting>(listStep[e.RowIndex].Condition);
                    var frm = new pageSettingHipotAC(1);
                   //frm = new pageSettingHipotAC(1);
                    frm.entity = setting;
                    frm.ShowPram();
                    frm.ShowDialog();
                }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 創建脚本模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewScript_Click(object sender, EventArgs e)
        {
            SetProgramModel(EnumProgramsModel.Edit);
        }

        /// <summary>
        /// 转换测试结果成Object 插入DB
        /// </summary>
        /// <param name="result"></param>
        /// <param name="acupoint"></param>
        /// <returns></returns>
        private EntityTestRecord ConvertTestResult(string result, int Cavity)
        {
            var results = new EntityTestRecord();
            results.Total_Qty = int.Parse(txtqty.Text);
            results.Test_Result = result;
            results.Test_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            results.Test_Qty = int.Parse(txtVQty.Text);
            results.Box_No = txtserial_number.Text;
            results.Test_Script = JsonConvert.SerializeObject(dataGridView1.DataSource);
            results.Step_Count = dataGridView1.Rows.Count;
            results.Cavity = Cavity;
            return results;

        }

        /// <summary>
        /// 读取测试结果
        /// </summary>
        private async Task Read_AutoTestResult()
        {
            string message = string.Empty;
            string result = string.Empty;
            //獲取測試結果 
            if (!service.GetTestResult(txtComName.Text, ref result, ref dataGridView1, ref message))
            {
                ShowMessage("獲取測試結果失败:");
                return;
            }
            //不良穴位
            int Cavity = 0;
            bool FlagMisjudge = false;
            bool FlagPending = false;
            switch (result)
            {
                case ConstantService.PASS:
                    {

                        StyleManager.Style = UIStyle.Green;
                        this.Style = StyleManager.Style;
                        ShowTestResult(ConstantService.PASS);
                        StyleManager.Style = UIStyle.Blue;
                        this.Style = StyleManager.Style;
                        //测试记录输出
                        await TestRecordOutput(result, Cavity);
                        //气缸上升
                        service.Machine_Up(txtRelay.Text, ref message);
                        break;
                    }
                default:
                    {
                        this.Style = UIStyle.Red;
                        this.Style = StyleManager.Style;
                        ShowTestResult(ConstantService.FAIL);
                        this.Style = UIStyle.Blue;
                        this.Style = StyleManager.Style;
                        this.ShowErrorDialog("产品测试Fail ,点击后即将治具上升，请注意安全", true);
                        //如果是误判 就重新测试
                        if (!FlagPending)
                        {
                            //锁住测试载具
                            var flag = await service.Modify_VehicleStatus(txtVehicleNumber.Text, status: 2, "产品测试 Fail");
                            if (flag.flag)
                            {
                                this.ShowSuccessTip($"{txtVehicleNumber.Text} 锁住成功");
                                //气缸上升 电脑配置较差需要Call 两次
                                //气缸上升
                                service.Machine_Up(txtRelay.Text, ref message);
                                service.Machine_Up(txtRelay.Text, ref message);
                                this.ShowErrorTip(message);
                            }
                            else
                            {
                                this.ShowErrorTip($"{txtVehicleNumber.Text} 锁住失败");
                            }
                        }

                        //测试记录输出
                        await TestRecordOutput(result, Cavity);

                        await Task.Delay(1000);
                        break;
                    }
            }

        }

        /// <summary>
        /// 测试记录输出
        /// </summary>
        /// <param name="result"></param>
        /// <param name="Cavity"></param>
        private async Task TestRecordOutput(string result, int Cavity)
        {
            //转换测试结果
            var results = ConvertTestResult(result, Cavity);
            //記錄測試值
            service.InsertTestRecord(results);
            //更新測試圖片
            ShowPicData(txtserial_number.Text, int.Parse(txtqty.Text));
            //導出測試Csv
            var dt = GetOsData(Cavity);

            service.SaveTestRecord(txtserial_number.Text, dt, dataGridView1);
            //上传mes
            UploadMes(result, Cavity);

        }

        /// <summary>
        /// UploadMes
        /// </summary>
        /// <param name="Result_Final">Result_Final</param>
        /// <param name="Cavity">Cavity</param>
        private void UploadMes(string Result_Final, int Cavity)
        {
            var result = JsonConvert.SerializeObject(dataGridView1.DataSource);
            var listdata = new List<string>();
            listdata.Add($"Result_Final:{Result_Final}");
            var entity = JsonConvert.DeserializeObject<List<EntityTestStep>>(result);
            for (int i = 0; i < entity.Count; i++)
            {
                listdata.Add($"Step0{i + 1}-Step:Step");
                listdata.Add($"Step0{i + 1}-Test_Item:" + entity[i].Test_Item);
                listdata.Add($"Step0{i + 1}-Model:" + comProductionModel.Text);
                // listdata.Add($"Step0{i + 1}-Name:" + comProductionName.Text);
                var StepEntity = JsonConvert.DeserializeObject<EntityACSetting>(entity[i].Condition);
                listdata.Add($"Step0{i + 1}-Condition:{entity[i].Mode},{StepEntity.Volt}V,{StepEntity.High}mA,{StepEntity.Time}S");
                listdata.Add($"Step0{i + 1}-Test_Time:" + entity[i].Test_Time);
                listdata.Add($"Step0{i + 1}-Limit_High:" + entity[i].Limit_High);
                listdata.Add($"Step0{i + 1}-Limit_Low:" + entity[i].Limit_Low);
                listdata.Add($"Step0{i + 1}-Result:" + entity[i].Result);
                listdata.Add($"Step0{i + 1}-Test_Volt:" + entity[i].Test_Volt);
                listdata.Add($"Step0{i + 1}-Test_Current:" + entity[i].Test_Current);
                listdata.Add($"Step0{i + 1}-Fixture:" + comFixture.Text);
                listdata.Add($"Step0{i + 1}-Vehicle:" + txtVehicleNumber.Text);
                //listdata.Add($"Step0{i + 1}-Vehicle:" + txtVehicleNumber.Text);
                //listdata.Add($"Step0{i + 1}-APN:" + txtAPN.Text);
                //listdata.Add($"Step{i+1}-Cavity:" + Cavity.ToString());

            }

            if (radioSnFlag.Checked)
            {

                for (int i = 0; i < serialNumbers.Count; i++)
                {

                    for (int j = 0; j < entity.Count; j++)
                    {
                        listdata.Add($"Step0{j+1}-SN:" + serialNumbers[i].SerialNumber);
                    }

                }

            }
            string message = string.Empty;
            if (MES_Service.UploadTestRecords(txtserial_number.Text, listdata, ref message))
            {
                this.ShowSuccessTip(message);
            }
            else
            {
                this.ShowErrorDialog(message);
            }

        }

        private void 治具上升ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtRelay.Text))
            {
                ShowMessage("请先连接测试治具，或者检查测试治具是否有连接");
                return;
            }
            string message = string.Empty;
            if (!service.Machine_Up(txtRelay.Text, ref message))
            {

                ShowMessage(message);
            }
        }

        private void 气缸下降ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtRelay.Text))
            {
                ShowMessage("请先连接测试治具，或者检查测试治具是否有连接");
                return;
            }
            string message = string.Empty;
            if (!service.Machine_Down(txtRelay.Text, ref message))
            {

                ShowMessage(message);
            }
        }
    }
}
