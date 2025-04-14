using Multiple_Test.Models.HIPOT;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Controller.UIModels.Pages
{
    public partial class pageSettingHipotAC : UIEditForm
    {
        public pageSettingHipotAC(int type)
        {

            InitializeComponent();
            txtVolt.TextChanged += TxtVolt_TextChanged;


        }


        public void ShowPram()
        {

            txtTime.Text = entity.Time;
            txtHigh.Text = entity.High;
            txtVolt.Text = entity.Volt;
            txtTest_Item.Text = entity.Test_Item;
            if (entity.Chan_LOW != null)
            {
                var sp = entity.Chan_LOW.Split(',');
                for (int i = 0; i < sp.Length; i++)
                {
                    SetRadioButtons(int.Parse(sp[i]), "LOW");
                }

            }

            if (entity.Chan_HIGH != null)
            {

                var sp = entity.Chan_HIGH.Split(',');
                for (int i = 0; i < sp.Length; i++)
                {
                    SetRadioButtons(int.Parse(sp[i]), "HIGH");
                }

            }
            txtARC.Text = entity.ARC.ToString();

            txtTime.ReadOnly = true;
            txtHigh.ReadOnly = true;
            txtVolt.ReadOnly = true;
            txtTest_Item.ReadOnly = true;
            txtARC.ReadOnly = true;
            txtREAL.ReadOnly = true;
            txtRamp.ReadOnly = true;
            txtFALL.ReadOnly = true;
            txtLow.ReadOnly = true;
            txtHigh.ReadOnly = true;
            SetAllRadioButtonsReadOnly();
        }

        private void SetAllRadioButtonsReadOnly()
        {
            // 遍历uiGroupBox1中的所有RadioButton并设置为只读
            foreach (UIRadioButton radioButton in uiGroupBox1.Controls.OfType<UIRadioButton>())
            {
                // 将RadioButton设为只读
                radioButton.Enabled = false;
            }
        }


        private void SetRadioButtons(int groupIndex, string setting)
        {
            // 遍历所有RadioButton并设置状态
            foreach (UIRadioButton radioButton in uiGroupBox1.Controls.OfType<UIRadioButton>())
            {
                // 确认当前RadioButton属于传入的groupIndex
                if (radioButton.GroupIndex == groupIndex)
                {
                    // 根据传入的setting设置状态
                    if ((setting == "HIGH" && radioButton.Text == "HIGH") ||
                        (setting == "LOW" && radioButton.Text == "LOW"))
                    {
                        radioButton.Checked = true;
                    }
                    else
                    {
                        radioButton.Checked = false;
                    }
                }
            }
        }




        public EntityACSetting entity = new EntityACSetting();
        protected override bool CheckData()
        {
            string High = string.Empty;
            string Low = string.Empty;
            init(ref High, ref Low);
            // MessageBox.Show("H:"+High+"L:"+Low);
            entity.Time = txtTime.Text;
            entity.High = txtHigh.Text;
            entity.Volt = txtVolt.Text;
            entity.Test_Item = txtTest_Item.Text;
            entity.Chan_LOW = Low;
            entity.Chan_HIGH = High;
            entity.ARC = float.Parse(txtARC.Text);
            return CheckLimit()
                   && CheckEmpty(txtTest_Item, "(Test Item)测试项目不能为空")
                   && CheckRange(txtVolt, 50, 5000, $"AC 测试电压 50 - 5000 V")
                   && CheckRange(txtHigh, double.Parse(txtHigh.Minimum.ToString()), double.Parse(txtHigh.Maximum.ToString()), $"测试电流 {txtHigh.Minimum.ToString()}mA - {txtHigh.Maximum.ToString()}mA")
                   && CheckRange(txtTime, 1, 180, "测试时间范围 1S - 180S");

        }


        private bool CheckLimit()
        {
            var hight = txtHigh.Text;
            var low = txtLow.Text;
            if (!(double.Parse(hight) > double.Parse(low)))
            {
                this.ShowWarningDialog($"上限值必须大于下限值 Limit_High:{double.Parse(hight)}mA Limit_Low:{double.Parse(low)}mA");
                return false;
            }
            return true;
        }

        private void TxtVolt_TextChanged(object sender, EventArgs e)
        {
            var value = this.txtVolt.Text;

            var max = int.Parse(this.txtVolt.Maximum.ToString());
            var min = int.Parse(this.txtVolt.Minimum.ToString());

            if (string.IsNullOrEmpty(value))
            {
                //this.txtVolt.Text = min.ToString();
                return;
            }
            if (int.Parse(value) > max)
            {
                this.txtVolt.Text = max.ToString();
            }

            if (int.Parse(value) < min)
            {
                this.txtVolt.Text = min.ToString();
            }
        }

        private void TxtVolt_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void init(ref string High, ref string Low)
        {
            // 假设所有的RadioButton都放在一个名为 groupBox1 的 GroupBox 控件中
            // 你可以使用下面的代码获取选中的RadioButton的值
            string selectedValue = string.Empty;

            foreach (UIRadioButton radioButton in uiGroupBox1.Controls.OfType<UIRadioButton>())
            {
                if (radioButton.Checked)
                {
                    selectedValue += radioButton.GroupIndex + radioButton.Text; // 使用RadioButton上显示的文本作为值

                    // 或者你可以将值存储在RadioButton的Tag属性中，然后获取： string selectedValue = radioButton.Tag.ToString();
                    switch (radioButton.Text)
                    {
                        case "HIGH":
                            {
                                High += radioButton.GroupIndex + ",";
                                break;
                            }
                        case "LOW":
                            {
                                Low += radioButton.GroupIndex + ",";
                                break;
                            }
                    }
                    // 这里可以执行相应的操作，使用 selectedValue
                    //break; // 如果只关心第一个选中的RadioButton，可以使用 break 结束循环
                }
            }
            if (High.Length > 0)
            {
                High = High.Substring(0, High.Length - 1);
            }
            else
            {
                High = "0";
            }
            if (Low.Length > 0)
            {
                Low = Low.Substring(0, Low.Length - 1);
            }
            else
            {
                Low = "0";
            }
            // MessageBox.Show(selectedValue+High+Low);
        }

    }
}
