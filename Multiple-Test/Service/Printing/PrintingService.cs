#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.Printing
 * 唯一标识：b5c8f4cc-8b2b-4e2d-81ba-aab55ba0ee05
 * 文件名：PrintingService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/27 8:50:55
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/27 8:50:55
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//using LabelManager2;
using Multiple_Test.Models.API;
using Multiple_Test.Utilities.Constant;

namespace Multiple_Test.Service.Printing
{
    public class PrintingService
    {
        /// <summary>
        ///注入相关依赖
        /// </summary>
       //  static  LabelManager2.Application print = new LabelManager2.Application();
        public PrintingService() { }
        /// <summary>
        /// 打印条码
        /// </summary>
        /// <param name="serial_number"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static EntityResult Prints(string serial_number,ref string message)
        { 
           var result= new EntityResult();
           
            try
            {
              
                string path = System.Windows.Forms.Application.StartupPath+ ConstantService.PrintModePath;
                FileLog.LogDebug("Printing",path);
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                {
                    result.flag = false;
                    result.result = "先在系统设置中设置套版路径";
                    
                    return result;
                }
                //print.Documents.Open(path, false);
                //print.Dialogs.Item(LabelManager2.enumDialogType.lppxPrinterSelectDialog).Show();
               // Document doc = print.ActiveDocument;
               // doc.Variables.Item("SERIAL_NUMBER").Value = serial_number;
                //打印
                //doc.PrintLabel(1, 1, 1, 1, 0, "");
                //doc.FormFeed();
                //doc.Save();
                result.flag = true;
                result.result = $"打印成功 {serial_number}";
               // print.Quit();
                return result;
            }
            catch (Exception ex)
            {
                result.flag = false;
                result.result = ex.Message;
            }
       
            return result;
        }
    }
}
