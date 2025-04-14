using Multiple_Test.Controller.UIModels;
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

namespace Multiple_Test.Controller.CommunicationTest
{
    public partial class FrmCommunicationTest : UIForm
    {
        const string ACCHROMA6530_6520_6512 = "ACCHROMA6530_6520_6512";
        const string CHROMA63600 = "CHROMA63600";
        public FrmCommunicationTest()
        {
            InitializeComponent();
            this.Load += FrmCommunicationTest_Load;
        }

        private void FrmCommunicationTest_Load(object sender, EventArgs e)
        {
            uiTreeView1.ExpandAll();
        }



        private void uiTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (uiTreeView1.SelectedNode.Name != null)
            {
                openFrom(uiTreeView1.SelectedNode.Name.ToUpper());
            }
        }

        /// <summary>
        /// 打开窗体
        /// </summary>
        /// <param name="nodeName"></param>
        private void openFrom(string nodeName)
        {
            var page = new UIPage();
            if (this.uiPanel1.Controls.Count > 0)
            {
                this.uiPanel1.Controls.Clear();
            }

            switch (nodeName)
            {
                case ACCHROMA6530_6520_6512:
                    {
                        page = new frmACChroma6530_6520_6512();
                        page.Dock = DockStyle.Fill;
                        page.Show();
                        this.uiPanel1.Controls.Add(page);
                        break;
                    }
                case CHROMA63600: 
                    {

                        page = new frmDCLod63600();
                        page.Dock = DockStyle.Fill;
                        page.Show();
                        this.uiPanel1.Controls.Add(page);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }


        }



    }
}
