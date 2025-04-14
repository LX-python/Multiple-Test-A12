using Multiple_Test.Models.Conf;
using Multiple_Test.Models;
using Newtonsoft.Json;
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
using System.IO;
using System.IO.Ports;
using Multiple_Test.Models.Firmware;

namespace Multiple_Test.Controller.FrmEditor
{
    public partial class FrmPCI7230: UIEditForm
    {
        private readonly string runPath = Application.StartupPath;
        private readonly string ProConfig = "ProConfig.json";
        private readonly string _TypeString;
        public FrmPCI7230(string type, string title)
        {
            InitializeComponent();
            Text = title;
            _TypeString = type;

            btnOK.Click += BtnOK_Click;
            Load += FrmPCI7230_Load;
        }

        private void FrmPCI7230_Load(object sender, EventArgs e)
        {
            DIDOMap didoMap = new DIDOMap();
            cbCyclinder_Down.Items.Clear();
            cbCyclinder_Up.Items.Clear();
            cb33v.Items.Clear();
            didoMap.IOMap.ForEach(x =>
            {
                if (x.Value.Type == "DO")
                {
                    cbCyclinder_Up.Items.Add(x.Key);
                    cb33v.Items.Add(x.Key);
                }
                else 
                {
                    cbCyclinder_Down.Items.Add(x.Key);


                }

            });
            

            LoadConfig();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_TypeString))
            {
                this.ShowErrorNotifier("未指定的功能添加");
                return;
            }

            SaveConfig(_TypeString);
        }
        

        /// <summary>
        /// 读取 JSON 配置
        /// </summary>
        private ConfigBasic GetConfig()
        {
            string filePath = Path.Combine(runPath, ProConfig);
            return File.Exists(filePath)
                ? JsonConvert.DeserializeObject<ConfigBasic>(File.ReadAllText(filePath)) ?? new ConfigBasic()
                : new ConfigBasic();
        }

        /// <summary>
        /// 读取配置并赋值到窗体控件
        /// </summary>
        private void LoadConfig()
        {
            ConfigBasic config = GetConfig();
            ConPCI7230 server = null;

            switch (_TypeString)
            {

                case "AutoFWMCU":
                    server = config?.fwAutoDownload?.Pci_7230;
                    break;
        
                case "AutoFWverifyMCU":
                    server = config?.fwAutoVerify?.Pci_7230;
                    break;
   
            }

            if (server != null)
            {
                cbCyclinder_Down.Text= server.DI_Cylinder_Down.ToString();
                cbCyclinder_Up.Text = server.DO_Cyclinder_up.ToString() ;
                cb33v.Text = server.DO_Voltage3.ToString(); ;

            }
        }

        /// <summary>
        /// 保存串口配置
        /// </summary>
        private void SaveConfig(string type)
        {
            ConfigBasic config = GetConfig();
            ConPCI7230 server = new ConPCI7230();
            server.DO_Cyclinder_up = int.Parse(cbCyclinder_Up.Text);
            server.DI_Cylinder_Down = int.Parse(cbCyclinder_Down.Text);
            server.DO_Voltage3 = int.Parse(cb33v.Text);
            

            // 更新配置
            UpdateConfig(config, type, server);

            string jsonString = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(Path.Combine(runPath, ProConfig), jsonString);

            this.ShowSuccessNotifier("保存成功");
        }


        /// <summary>
        /// 根据设备类型更新配置
        /// </summary>
        private void UpdateConfig(ConfigBasic config, string type, ConPCI7230 server)
        {
            switch (type)
            {
                case "AutoFWMCU": config.fwAutoDownload.Pci_7230 = server; break;
                case "AutoFWverifyMCU": config.fwAutoVerify.Pci_7230 = server; break;
                default: this.ShowErrorNotifier("未指定的功能添加"); break;
            }
        }
    }
}
