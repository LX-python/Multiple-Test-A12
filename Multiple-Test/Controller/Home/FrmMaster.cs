using Multiple_Test.Controller.Derating;
using Multiple_Test.Controller.HIPOT;
using Multiple_Test.Controller.STM32;
using Multiple_Test.Service.Buttons;
using Multiple_Test.Service.ChromaMES;
using Multiple_Test.Service.Frm;
using Multiple_Test.Service.Login;
using NXP_TEA_IC;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Controller.Home
{
    public partial class FrmMaster : UIForm
    {

        public FrmMaster()
        {
            InitializeComponent();
            //this.ShowSuccessNotifier("歡迎您登錄 PDC-ASI Testing System,請選擇您的測試項目",false,1000);
            this.FormClosing += FrmMaster_FormClosing;
            this.btnStm32Download.Click += BtnStm32_Click;
            this.btnStm32Verify.Click += BtnStm32Verify_Click;
            this.btnFWDownloadAutoScan.Click += BtnFWDownloadAutoScan_Click;
            this.btnFWDownloadAutoScan_PCI7230.Click += BtnFWDownloadAutoScan_PCI7230_Click;
            //this.MouseDown += FrmMaster_MouseDown;
            this.Text = $"PDC-ASI Multiple-Test System   Version:{Application.ProductVersion}";
     
        }

        /// <summary>
        /// FW 烧录 7230版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFWDownloadAutoScan_PCI7230_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(btnFWDownloadAutoScan_PCI7230);
            ShowFrm(new pageSTM32DownloadAutoScan7230());
            ButtonsService.EnableBtn(btnFWDownloadAutoScan_PCI7230);
        }

        /// <summary>
        /// FW 烧录 MCU 控制版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFWDownloadAutoScan_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn( btnFWDownloadAutoScan);
            ShowFrm(new pageSTM32DownloadAutoScan());
            ButtonsService.EnableBtn(btnFWDownloadAutoScan);
            
        }

        /// <summary>
        /// BtnStm32Verify
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStm32Verify_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(btnStm32Verify);
            ShowFrm(new pageSTM32VerifyAutoScan());
            ButtonsService.EnableBtn(btnStm32Verify);
        }

        /// <summary>
        /// BtnStm32
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStm32_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(btnStm32Download);
            ShowFrm(new pageSTM32Download());
            ButtonsService.EnableBtn(btnStm32Download);
        }

        /// <summary>
        /// 按住拖动窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaster_MouseDown(object sender, MouseEventArgs e)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HTCAPTION = 2;

            if (e.Button == MouseButtons.Left) // 按下的是鼠标左键 
            {
                FrmService.ReleaseCapture();
                FrmService.SendMessage(this.Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero); // 拖动窗体 
            }
        }

        private void FrmMaster_FormClosing(object sender, FormClosingEventArgs e)
        {

            MesConmmand.SajetTransClose();
            Environment.Exit(0);
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            ShowFrm(new frmDeratintMain());
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
           
            ButtonsService.DisableBtn(uiButton5);
            ShowFrm(new FrmHipotAuto());
            ButtonsService.EnableBtn(uiButton5);
        }

        /// <summary>
        /// Open Window Frm
        /// </summary>
        /// <param name="frm"></param>
        private void ShowFrm(UIForm frm) 
        {
            frm.ShowDialog();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(uiButton3);
            ShowFrm(new FrmHipotManual());
            ButtonsService.EnableBtn(uiButton3);
        }

        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(btnSemiAutomatic);
            ShowFrm(new FrmHipotSemi_Automatic());
            ButtonsService.EnableBtn(btnSemiAutomatic);
            
        }

        private void btnNXP_TEA2376_Click(object sender, EventArgs e)
        {
            ButtonsService.DisableBtn(btnNXP_TEA2376);
            FormGUI f2 =new FormGUI();
            this.Hide();
            f2.ShowDialog();
            this.Dispose();
            ButtonsService.EnableBtn(btnNXP_TEA2376);
        }

    }
}
