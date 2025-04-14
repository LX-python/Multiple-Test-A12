using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Models.Conf
{
    public class FirmWareType
    {
        public ConfigRS232 Scan { get; set; }

        public ConfigRS232 mcu { get; set; }

        public ConPCI7230 Pci_7230 { get; set; }
    }
}
