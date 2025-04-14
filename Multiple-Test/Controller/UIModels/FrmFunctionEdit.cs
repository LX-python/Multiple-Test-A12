using Multiple_Test.Service.FrmEdit;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Controller.UIModels
{
    public partial class FrmFunctionEdit : UIForm
    {
        private readonly FrmeditService service;
        private const string BtnAcsourse = "radioBtnAcsourse";
        private const string Btndcload = "radioBtndcload";
        private const string BtnMultimeter = "radioBtnMultimeter";
        public FrmFunctionEdit(int item, string title)
        {
            InitializeComponent();
            this.Text = $"Item:{item}  ,Add ({title}) to functional test!";
            service = new FrmeditService(this);
            this.btnAddFunction.Click += BtnAddFunction_Click;
        }




        private void BtnAddFunction_Click(object sender, EventArgs e)
        {
            string flag = getRadioBtnSelectStatus();
            if (string.IsNullOrEmpty(flag))
            {
                 this.ShowErrorDialog("Please select features for your test system");
                return;
            }
            var showFrm = new UIForm();
            switch (flag)
            {
                case BtnAcsourse:
                    {
                        showFrm = new frmAddACSource();
                        showFrm.ShowDialog();
                        break;
                    }

                case Btndcload:
                    {
                        showFrm = new frmAddDCload();
                        showFrm.ShowDialog();
                        break;
                    }

                case BtnMultimeter:
                    {
                        showFrm = new frmAddMultimeter();
                        showFrm.ShowDialog();
                        break;

                    }
                default:
                    {
                        break;


                    }

            }
        }

        private string getRadioBtnSelectStatus()
        {
            if (radioBtnAcsourse.Checked)
            {
                return BtnAcsourse;
            }

            if (radioBtndcload.Checked)
            {
                return Btndcload;
            }

            if (radioBtnMultimeter.Checked)
            {
                return BtnMultimeter;
            }


            return null;
        }


    }
}
