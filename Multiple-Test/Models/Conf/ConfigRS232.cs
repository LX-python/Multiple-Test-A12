using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Models.Conf
{
   public class ConfigRS232
    {

        public bool IsStatus { get; set; }
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public System.IO.Ports.Parity Parity { get; set; }
        public System.IO.Ports.StopBits StopBits { get; set; }
        public System.IO.Ports.Handshake Handshake { get; set; }
    }
}
