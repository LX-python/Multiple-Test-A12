using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.PCI7230Helper
{
    public static class PCI7230
    {
        // P/Invoke声明
        [DllImport("PCI-Dask.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern short Register_Card(ushort CardType, ushort card_num);
        [DllImport("PCI-Dask.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern short Release_Card(short CardNumber);


        [DllImport("PCI-Dask.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern short DI_ReadPort(short CardNumber, ushort port, out ushort value);


        [DllImport("PCI-Dask.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern short DO_WritePort(short CardNumber, ushort port, ushort value);
    }

}
