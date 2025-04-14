using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Multiple_Test.Models;
using Multiple_Test.Models.Conf;
using Newtonsoft.Json;
using Sunny.UI;

namespace Multiple_Test.Controller.FrmEditor
{
    public partial class FrmRS232Editor : UIEditForm
    {
        private readonly string runPath = Application.StartupPath;
        private readonly string ProConfig = "ProConfig.json";
        private readonly string _TypeString;

        public FrmRS232Editor(string type, string title)
        {
            InitializeComponent();
            Text = title;
            _TypeString = type;

            btnOK.Click += BtnOK_Click;
            btnRefresh.Click += (sender, e) => loadComList();
            Load += FrmRS232Editer_Load;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void FrmRS232Editer_Load(object sender, EventArgs e)
        {
            loadComList();  // 加载可用串口
            LoadConfig();    // 读取配置并赋值到控件
        }

        /// <summary>
        /// 加载串口列表
        /// </summary>
        private void loadComList()
        {
            string[] ports = SerialPort.GetPortNames();
            cbComlist.Items.Clear();
            cbComlist.Items.AddRange(ports);

            if (ports.Length > 0)
            {
                cbComlist.SelectedIndex = 0; // 选择第一个可用端口
            }

            this.ShowInfoTip("Load Succeed!");
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
            ConfigRS232 server = null;
            switch (_TypeString)
            {
                case "AutoFWScan":
                    server = config?.fwAutoDownload?.Scan;
                    break;
                case "AutoFWMCU":
                    server = config?.fwAutoDownload?.mcu;
                    break;

                case "AutoFWverifyScan":
                    server = config?.fwAutoVerify?.Scan;
                    break;
                case "AutoFWverifyMCU":
                    server = config?.fwAutoVerify?.mcu;
                    break;
                case "Ultrasonic":

                    break;
                default:
                    server = null;
                    break;
            }

            if (server != null)
            {
                cbComlist.Text = server.PortName;
                cbBaudRate.Text = server.BaudRate.ToString();
                comParity.Text = server.Parity.ToString();
                comboxStopBits.Text = server.StopBits.ToString();
                comboxHandshake.Text = server.Handshake.ToString();
                comboxDataBit.Text=server.DataBits.ToString();
            }
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
        /// 保存串口配置
        /// </summary>
        private void SaveConfig(string type)
        {
            ConfigBasic config = GetConfig();
            ConfigRS232 server = new ConfigRS232
            {
                PortName = cbComlist.Text,
                BaudRate = int.TryParse(cbBaudRate.Text, out int baudRate) ? baudRate : 9600,
                Parity = Enum.TryParse(comParity.Text, true, out Parity parity) ? parity : Parity.None,
                StopBits = Enum.TryParse(comboxStopBits.Text, true, out StopBits stopBits) ? stopBits : StopBits.One,
                Handshake = Enum.TryParse(comboxHandshake.Text, true, out Handshake handshake) ? handshake : Handshake.None,
                DataBits = int.TryParse(comboxDataBit.Text, out int value) ? value : 8,
            };

            // 更新配置
            UpdateConfig(config, type, server);

            string jsonString = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(Path.Combine(runPath, ProConfig), jsonString);

            this.ShowSuccessNotifier("保存成功");
        }

        /// <summary>
        /// 根据设备类型更新配置
        /// </summary>
        private void UpdateConfig(ConfigBasic config, string type, ConfigRS232 server)
        {
            switch (type)
            {
                case "AutoFWScan": config.fwAutoDownload.Scan = server; break;
                case "AutoFWMCU": config.fwAutoDownload.mcu = server; break;
                case "AutoFWverifyScan":  config.fwAutoVerify.Scan=server; break;
                case "AutoFWverifyMCU":  config.fwAutoVerify.mcu=server;break;
                default: this.ShowErrorNotifier("未指定的功能添加"); break;
            }
        }
    }
}
