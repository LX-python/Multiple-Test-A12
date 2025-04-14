using Multiple_Test.Controller.Home;
using Multiple_Test.Controller.Upgrades;
using Multiple_Test.Models.API;
using Multiple_Test.Service.Buttons;
using Multiple_Test.Service.ChromaMES;
using Multiple_Test.Service.Frm;
using Multiple_Test.Service.HIPOT;
using Multiple_Test.Service.Login;
using Multiple_Test.Service.RS232;
using Multiple_Test.Utilities.Constant;
using Multiple_Test.Utilities.Update;
using Sunny.UI;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Controller.Login
{
    public partial class pageLogin : UIForm
    {
        /// <summary>
        /// 服务注入
        /// </summary>
        LoginService service = new LoginService();
        UpdateService updateService = new UpdateService();
        private readonly UpgradesService _update = new UpgradesService();
        private string usernameTempFilePath = Application.StartupPath + "\\username.txt";
        /// <summary>
        /// 初始化
        /// </summary>
        public pageLogin()
        {
            InitializeComponent();
            this.Load +=  PageLogin_Load;
            this.btnLogin.Click += BtnLogin_Click;
            this.btnExit.Click += BtnExit_Click;
            this.txtPassword.TextChanged += TxtPassword_TextChanged;
            this.ShowSuccessNotifier("歡迎您登錄 PDC-ASI Testing System,請輸入賬號密碼即可繼續啦", false, 1000);

         
            this.service.InitMesConnect();
            this.MouseDown += PageLogin_MouseDown;
            this.linkVersion.Text ="Version: "+ Application.ProductVersion;
            this.txtPassword.KeyDown += TxtPassword_KeyDown;
        }

        private async void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // 判断是否按下回车键
            if (e.KeyCode == Keys.Enter)
            {
                // 执行登录操作
                await Login();
            }
        }

        private async void PageLogin_Load(object sender, EventArgs e)
        {
            if (!await service.LoadAPIUrl())
            {
                txtProxy.Text = "没有可用的Api地址";
                this.ShowErrorNotifier("没有配置地址API地址", false, 2000);
            }
            else 
            {
                txtProxy.Text = APISRC.API;
                ///服务器通了才进行
                //_update.CheckVersion();
            }


            if (File.Exists(usernameTempFilePath))
            {
                txtUserName.Text = File.ReadAllText(usernameTempFilePath);
            }
                //string version = Application.ProductVersion;
                //var CheckVersionObject = await updateService.CheckProgramerVersion(Application.ProductName);
                //if (!(CheckVersionObject is null))
                //{
                //    if (version != CheckVersionObject.version)
                //    {
                //        if (this.ShowAskDialog($"{Application.ProductName} 发现新版本，是否更新版本{CheckVersionObject.version}", UIStyle.Red))
                //        {

                //        }

                //    }
                //}


            }

        private async void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            // 尝试将 EventArgs 转换为 KeyPressEventArgs
            if (e is KeyPressEventArgs keyPressEvent)
            {
                // 判断是否按下回车键
                if (keyPressEvent.KeyChar == (char)Keys.Enter)
                {
                    // 执行登录操作
                    await Login();
                }
            }

        }

        /// <summary>
        /// 按住拖动窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageLogin_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HTCAPTION = 2;

            if (e.Button == MouseButtons.Left) // 按下的是鼠标左键 
            {
                FrmService.ReleaseCapture();
                FrmService.SendMessage(this.Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero); // 拖动窗体 
            }
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            MES_Service.MesDisConnect();
            Environment.Exit(0);
        }
        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            await Login();
        }

        private async Task Login()
        {

            ButtonsService.DisableBtn(btnLogin);

            var result = await service.LoginSystem(comCustomer.Text,txtUserName.Text, txtPassword.Text);
            if (result.flag)
            {
                this.Hide();
                if (File.Exists(usernameTempFilePath))
                {
                    File.Delete(usernameTempFilePath);
                }
                File.WriteAllText(usernameTempFilePath, txtUserName.Text);
                var frm = new FrmMaster();
                frm.ShowDialog();
            }
            else
            {
                this.Style = UIStyle.Red;
                this.ShowErrorTip($"登錄失敗，{result.result}");
                this.ShowErrorDialog($"登錄失敗，{result.result}");
                this.Style = UIStyle.Blue;

            }
            ButtonsService.EnableBtn(btnLogin);
        }
    }
}
