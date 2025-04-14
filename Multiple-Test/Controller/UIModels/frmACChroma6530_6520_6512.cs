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
    public partial class frmACChroma6530_6520_6512 : UIPage
    {
        GPIBServices visa = new GPIBServices();
        public frmACChroma6530_6520_6512()
        {
            InitializeComponent();
        }

        private void frmACChroma6530_6520_6512_Load(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

            try
            {
                this.btnExec.Enabled = false;

                var list = visa.WriteString(txtName.Text, txtAddress.Text, txtCommand.Text);
                var logs = visa.ReadString();
                log(logs.message);

            }
            catch (Exception ex)
            {

                log("Exception: " + ex.Message);

            }

            this.btnExec.Enabled = true;

        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
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
    
    }
}
