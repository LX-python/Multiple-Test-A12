using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Models.Conf
{
    public class ConPCI7230
    {

        /// <summary>
        /// 气缸下压 引脚
        /// </summary>
        public int DI_Cylinder_Down { get; set; }

        /// <summary>
        /// 气缸上升 引脚
        /// </summary>
        public int DO_Cyclinder_up { get; set; }

        /// <summary>
        /// 3.3 V 引脚
        /// </summary>
        public int DO_Voltage3 { get; set; }
       
    }
}
