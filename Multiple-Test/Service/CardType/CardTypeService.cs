#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.CardType
 * 唯一标识：bd26b740-e6a0-4370-8aab-f437e2bfbba3
 * 文件名：CardTypeService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/9 20:32:35
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/9 20:32:35
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.CardType
{
    public class CardTypeService
    {
        /// <summary>
        /// 检查HIPOT 机器的型号
        /// </summary>
        /// <param name="Card_Name"></param>
        /// <returns></returns>
        private bool CheckHipot_CardType(string Card_Name)
        {
            switch (Card_Name)
            {
                case "19051":
                    {
                        return true;
                    }
                case "19052":
                    {
                        return true;
                    }
                case "19053":
                    {
                        return true;
                    }
                case "19054":
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
        /// 转换得到卡号
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public string ConvertCardName(string result)
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
    }
}
