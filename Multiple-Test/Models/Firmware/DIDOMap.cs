using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Models.Firmware
{
    public class DIDOMap
    {
        public Dictionary<int, (string Type, int IOIndex)> IOMap { get; set; } = new Dictionary<int, (string Type, int IOIndex)>();
        private const string DI = "DI"; // 输入
        private const string DO = "DO"; // 输出

        public DIDOMap()
        {
            AddMappings(DI, new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 1, 3, 5, 7, 9, 11, 13, 15 }, 1, 8, 20, 27);
            AddMappings(DO, new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 1, 3, 5, 7, 9, 11, 13, 15 }, 11, 18, 30, 37); // 修正为 pin37
        }

        //private void AddMappings(string type, int[] indexes, int start1, int end1, int start2, int end2)
        //{
        //    for (int i = start1; i <= end1; i++)
        //    {
        //        IOMap.Add(i, (type, indexes[i - start1]));
        //    }
        //    for (int i = start2; i <= end2; i++)
        //    {
        //        IOMap.Add(i, (type, indexes[i - start2]));
        //    }
        //}

        private void AddMappings(string type, int[] indexes, int start1, int end1, int start2, int end2)
        {
            for (int i = start1; i <= end1; i++)
            {
                IOMap.Add(i, (type, indexes[i - start1]));
            }
            for (int i = start2; i <= end2; i++)
            {
                // 修正这里的索引计算以确保正确映射到最后一个元素
                IOMap.Add(i, (type, indexes[(i - start2) + (end1 - start1 + 1)]));
            }
        }

        /// <summary>
        /// 根据脚位索引
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public (string Type, int IOIndex)? GetMappingByPin(int pin)
        {
            if (IOMap.ContainsKey(pin))
            {
                return IOMap[pin];
            }
            return null;
        }
    }
}
