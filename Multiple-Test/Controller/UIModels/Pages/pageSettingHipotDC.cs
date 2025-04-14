using Multiple_Test.Models.HIPOT;
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

namespace Multiple_Test.Controller.UIModels.Pages
{
    public partial class pageSettingHipotDC : UIEditForm
    {
        public EntityACSetting entity = new EntityACSetting();
        public pageSettingHipotDC()
        {
            InitializeComponent();
        }
    }
}
