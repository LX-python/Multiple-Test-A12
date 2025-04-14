#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2023 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.GPIB
 * 唯一标识：2e349337-926f-4c47-9613-d7cdd396ebc8
 * 文件名：GPIBEquipmentType
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2023/12/18 10:13:18
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2023/12/18 10:13:18
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Models.Grid;
using OfficeOpenXml.Drawing.Chart.ChartEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.GPIB
{
    public class GPIBEquipmentType
    {
        private readonly GPIBServices visa = new GPIBServices();
        public GPIBEquipmentType()
        {

        }

        private const string ACSource = "AC-Source";
        private const string DCLoad = "DC-Load";
        private const string Multimeter = "Multimeter";

        /// <summary>
        /// 获取AC Source的清单
        /// </summary>
        /// <returns></returns>
        public List<entityGPIBList> GetACSourceList()
        {
            var relist = new List<entityGPIBList>();
            var list = visa.getGPIBList("gpib?*INSTR");
            if (list.Count > 0)
            {

                for (int i = 0; i < list.Count; i++)
                {
                    string[] gpibInfo = list[i].Split(':');
                    if (gpibInfo.Length < 2) 
                    {
                        return relist;
                    }
                    string GPIB_Name = gpibInfo[0];
                    string GPIB_Address = gpibInfo[2];
                    string GPIB_CMD = "*IDN?";
                    var CardString = visa.getCardList(GPIB_Name, GPIB_Address, GPIB_CMD);
                    FileLog.LogInformation("CardString", CardString);
                    if (!string.IsNullOrEmpty(CardString))
                    {
                        var reGPIB_Info = new entityGPIBList();
                        string card = ConvertCardName(CardString);
                        if (CheckAC_CardType(card))
                        {
                            reGPIB_Info.GPIB_Address=int.Parse(GPIB_Address);
                            reGPIB_Info.GPIB_Name=GPIB_Name;
                            reGPIB_Info.Card_Type = card;
                            relist.Add(reGPIB_Info);
                        }

                    }
                }

            }
            return relist;
        }

        /// <summary>
        /// 获取DC Load的清单
        /// </summary>
        /// <returns></returns>
        public List<entityGPIBList> Get_DC_Load_List()
        {
            var relist = new List<entityGPIBList>();
            var list = visa.getGPIBList("gpib?*INSTR");
            if (list.Count > 0)
            {

                for (int i = 0; i < list.Count; i++)
                {
                    string[] gpibInfo = list[i].Split(':');
                    if (gpibInfo.Length < 2)
                    {
                        return relist;
                    }
                    string GPIB_Name = gpibInfo[0];
                    string GPIB_Address = gpibInfo[2];
                    string GPIB_CMD = "*IDN?";
                    var CardString = visa.getCardList(GPIB_Name, GPIB_Address, GPIB_CMD);
                    FileLog.LogInformation("CardString", CardString);
                    if (!string.IsNullOrEmpty(CardString))
                    {
                        var reGPIB_Info = new entityGPIBList();
                        string card = ConvertCardName(CardString);
                        if (CheckDC_CardType(card))
                        {
                            reGPIB_Info.GPIB_Address = int.Parse(GPIB_Address);
                            reGPIB_Info.GPIB_Name = GPIB_Name;
                            reGPIB_Info.Card_Type = card;
                            relist.Add(reGPIB_Info);
                        }

                    }
                }

            }
            return relist;
        }


        /// <summary>
        /// 获取示波器的清单
        /// </summary>
        /// <returns></returns>
        public List<entityGPIBList> Get_Oscilloscope_List()
        {
            var relist = new List<entityGPIBList>();
            var list = visa.getGPIBList("gpib?*INSTR");
            if (list.Count > 0)
            {

                for (int i = 0; i < list.Count; i++)
                {
                    string[] gpibInfo = list[i].Split(':');
                    if (gpibInfo.Length < 2)
                    {
                        return relist;
                    }
                    string GPIB_Name = gpibInfo[0];
                    string GPIB_Address = gpibInfo[2];
                    string GPIB_CMD = "*IDN?";
                    var CardString = visa.getCardList(GPIB_Name, GPIB_Address, GPIB_CMD);
                    FileLog.LogInformation("CardString", CardString);
                    if (!string.IsNullOrEmpty(CardString))
                    {
                        var reGPIB_Info = new entityGPIBList();
                        string card = ConvertCardName(CardString);
                        if (CheckOscilloscope_CardType(card))
                        {
                            reGPIB_Info.GPIB_Address = int.Parse(GPIB_Address);
                            reGPIB_Info.GPIB_Name = GPIB_Name;
                            reGPIB_Info.Card_Type = card;
                            relist.Add(reGPIB_Info);
                        }

                    }
                }

            }
            return relist;
        }

        /// <summary>
        /// 转换得到卡号
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private string ConvertCardName(string result)
        {

            string childrenResult = result.Split(',')[1].ToString();
            if (childrenResult.IndexOf("-") > -1)
            {
                childrenResult = childrenResult.Split('-')[0].ToString();
            }

            char[] symbols = { ',', '!', '.', ';', '-', '_', '#', '$', '^', '&', '*', '`', '/' };

            int index = childrenResult.IndexOfAny(symbols);

            if (index != -1)
            {
                char symbol = childrenResult[index];
                Console.WriteLine($"第一个符号是: {symbol}");
                childrenResult = childrenResult.Split(symbol)[0].ToString().Trim();
            }

            return childrenResult;


        }
        /// <summary>
        /// 检查AC的卡类型
        /// </summary>
        /// <param name="Card_Name"></param>
        /// <returns></returns>
        private bool CheckAC_CardType(string Card_Name)
        {
            switch (Card_Name)
            {
                case "6530":
                    {
                        return true;
                    }
                case "6520":
                    {
                        return true;
                    }

                case "6512":
                    {
                        return true;
                    }
                default:
                    {

                        return false;
                    }

            }


        }

        /// <summary>
        /// 检查DC LOAD 型号
        /// </summary>
        /// <param name="Card_Name"></param>
        /// <returns></returns>

        private bool CheckDC_CardType(string Card_Name)
        {
            switch (Card_Name)
            {
                case "63600":
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// 检查是否是示波器
        /// </summary>
        /// <param name="Card_Name"></param>
        /// <returns></returns>
        private bool CheckOscilloscope_CardType(string Card_Name)
        {
            switch (Card_Name)
            {
                case "DPO7054C":
                    {
                        return true;
                    }
                case "DPO7000":
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

    
    }

}
