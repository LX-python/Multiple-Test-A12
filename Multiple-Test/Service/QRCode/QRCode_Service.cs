#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.QRCode
 * 唯一标识：402fac4b-f875-49e2-8543-806ef43b7337
 * 文件名：QRCode_Service
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/6 10:31:56
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/6 10:31:56
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Models.QRCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.QRCode
{
    public class QRCode_Service
    {
        //P827503;V101201;D2351;Q1600;S8275031012012351000016000EV;RB;C2;LPE14978C

        public QRCode_Service() { }
        /// <summary>
        /// 解析扫描箱号条码解析内容
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public EntityQRCode GetQRCodeInfo(string code, ref string message) 
        {
            var QrCode=code.Split(';');
            if (QrCode.Length == 8) 
            {
                string part_Number = "";
                string supplier = "";
                string cycle = "";
                int qty = 0;
                string serial_number = "";
                string lot_number = "";
                if (QrCode[0].Length <= 1) 
                {
                    message = $"料号长度错误,{code}";
                    return null;
                }

                if (QrCode[1].Length <= 1)
                {
                    message = $"供应商代码长度错误,{code}";
                    return null;
                }

                if (QrCode[2].Length <= 1)
                {
                    message = $"生产周期长度错误,{code}";
                    return null;
                }


                if (QrCode[3].Length <= 1)
                {
                    message = $"产能长度错误,{code}";
                    return null;
                }

                if (QrCode[4].Length <= 1)
                {
                    message = $"序列号长度错误,{code}";
                    return null;
                }


                if (QrCode[7].Length <= 1)
                {
                    message = $"Lot_Number 长度错误,{code}";
                    return null;
                }

                part_Number = QrCode[0].Substring(1, QrCode[0].Length - 1);

                supplier = QrCode[1].Substring(1, QrCode[1].Length - 1);
                cycle = QrCode[2].Substring(1, QrCode[2].Length - 1);
                qty=int.Parse(QrCode[3].Substring(1, QrCode[3].Length - 1));
                serial_number = QrCode[4].Substring(1, QrCode[4].Length - 1);
                lot_number= QrCode[7].Substring(1, QrCode[7].Length - 1);
                return new EntityQRCode
                {
                    part_Number = part_Number,
                    supplier = supplier,
                    cycle = cycle,
                    qty = qty,
                    serial_number =serial_number,
                    Lot_Number=lot_number

                };
            }
            if (QrCode.Length == 10)
            {
                string part_Number = "";
                string supplier = "";
                string cycle = "";
                int qty = 0;
                string serial_number = "";
                string lot_number = "";
                if (QrCode[0].Length <= 1)
                {
                    message = $"料号长度错误,{code}";
                    return null;
                }

                if (QrCode[3].Length <= 1)
                {
                    message = $"供应商代码长度错误,{code}";
                    return null;
                }

                if (QrCode[1].Length <= 1)
                {
                    message = $"生产周期长度错误,{code}";
                    return null;
                }


                if (QrCode[4].Length <= 1)
                {
                    message = $"产能长度错误,{code}";
                    return null;
                }

                if (QrCode[7].Length <= 1)
                {
                    message = $"序列号长度错误,{code}";
                    return null;
                }


                if (QrCode[2].Length <= 1)
                {
                    message = $"Lot_Number 长度错误,{code}";
                    return null;
                }

                part_Number = QrCode[0].Substring(1, QrCode[0].Length - 1);

                supplier = QrCode[3].Substring(1, QrCode[3].Length - 1);
                cycle = QrCode[1].Substring(1, QrCode[1].Length - 1);
                qty = int.Parse(QrCode[4].Substring(1, QrCode[4].Length - 1));
                serial_number = QrCode[7].Substring(1, QrCode[7].Length - 1);
                lot_number = QrCode[2].Substring(1, QrCode[2].Length - 1);
                return new EntityQRCode
                {
                    part_Number = part_Number,
                    supplier = supplier,
                    cycle = cycle,
                    qty = qty,
                    serial_number = serial_number,
                    Lot_Number = lot_number

                };
            }
            message = $"长度错误 {QrCode.Length} !!! {code}";
            return null;    
        }


        public EntityQRCode ConvertQrCode(string inputSerialNumber,ref string message) 
        {
            try
            {

                if (inputSerialNumber.Length != 27)
                {
                    message = "长度错误";
                    return null;
                }

                string part_Number = "";
                string supplier = "";
                string cycle = "";
                int qty = 0;
                string serial_number = "";
                string lot_number = "";

                part_Number = inputSerialNumber.Substring(0, 6);

                supplier = inputSerialNumber.Substring(6, 6);
                cycle = inputSerialNumber.Substring(12, 6);
                qty = int.Parse(inputSerialNumber.Substring(18, 6));
                serial_number = inputSerialNumber;
                //lot_number = inputSerialNumber.Substring(6, 11);
                return new EntityQRCode
                {
                    part_Number = part_Number,
                    supplier = supplier,
                    cycle = cycle,
                    qty = qty,
                    serial_number = serial_number,
                    Lot_Number = lot_number

                };

            }
            catch (Exception ex)
            {

                message=ex.Message;
                return null;
            }
        }
    }
}
