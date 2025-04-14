using Multiple_Test.Models.Conf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Models
{

    public class ConfigBasic
    {
        /// <summary>
        /// 自动扫码 自动 Download Fireware
        /// </summary>
        public FirmWareType fwAutoDownload { get; set; } = new FirmWareType();
        /// <summary>
        /// 自动扫码 自动Check Fireware
        /// </summary>
        public FirmWareType fwAutoVerify { get; set; } = new FirmWareType();
    }
}
