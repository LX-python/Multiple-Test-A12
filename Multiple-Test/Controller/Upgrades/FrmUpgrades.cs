using Multiple_Test.Controller.Upgrades;
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

namespace ASI_Multiple_Test.Controller.Upgrades
{
    public partial class FrmUpgrades : UIForm
    {
        private readonly Multiple_Test.Controller.Upgrades.UpgradesService _update = new Multiple_Test.Controller.Upgrades.UpgradesService();
        public FrmUpgrades()
        {
            InitializeComponent();
            this.TopMost = true;
            _update.OnSuccess += _update_OnSuccess;
            _update.OnError += _update_OnError;
            this.Load += FrmUpgrades_Load;



        }

        private void FrmUpgrades_Load(object sender, EventArgs e)
        {
            _update.DownloadFileWithProgress();
        }

        private void _update_OnError(string type, string ErrorMessage)
        {
           this.ShowErrorDialog(type, ErrorMessage);
            Environment.Exit(0);
        }

        private void _update_OnSuccess(double progress)
        {
           // uiProcessBar1.Value = int.Parse(progress.ToString());
            uiProcessBar1.Value = Convert.ToInt32(progress);
        }
    }
}
