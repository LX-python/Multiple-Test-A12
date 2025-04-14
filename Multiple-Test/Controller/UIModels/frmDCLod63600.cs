using Multiple_Test.Service.GPIB;
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
    public partial class frmDCLod63600 : UIPage
    {
        GPIBServices visa = new GPIBServices();
        public frmDCLod63600()
        {
            InitializeComponent();
        }

        private void labResult_Click(object sender, EventArgs e)
        {

        }

        private void uiRadioButton2_ValueChanged(object sender, bool value)
        {

        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnExec.Enabled = false;

                var list = visa.WriteString(txtName.Text, txtAddress.Text, txtCommand.Text);
                log(list);

            }
            catch (Exception ex)
            {

                log("Exception: " + ex.Message);

            }

            this.btnExec.Enabled = true;
        }

        private void btnGpibList_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnGpibList.Enabled = false;

                var list = visa.getGPIBList("gpib?*INSTR");
                if (list.Count == 0)
                {
                    MessageBox.Show("No found gpib device", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                foreach (var item in list)
                {
                    log(item);
                }

            }
            catch (Exception ex)
            {

                log("Exception: " + ex.Message);

            }

            this.btnGpibList.Enabled = true;
        }


        private void log(string log)
        {
            uiRichTextBox1.BeginInvoke(new Action(() =>
            {
                if (uiRichTextBox1.Text.Length > 1024)
                {
                    uiRichTextBox1.Text = "";
                }

                uiRichTextBox1.Text += log + "\r";


            }));


        }

        private void uiRadioButton1_ValueChanged(object sender, bool value)
        {
            
        }
    }
}
