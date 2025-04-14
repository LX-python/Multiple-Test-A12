#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.ChromaMES
 * 唯一标识：a2b3fedb-fd47-401a-a4c8-0424eea4c6ae
 * 文件名：MesConmmand
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/19 16:28:43
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/19 16:28:43
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Utilities.Constant;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.ChromaMES
{
    public static class MesConmmand
    {
        
        static MesConmmand() 
        {
        
        }

        [DllImport(ConstantService.sajectDllPath, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "SajetTransStart")]
        public static extern bool SajetTransStart();

        [DllImport(ConstantService.sajectDllPath, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "SajetTransData")]
        public static extern bool SajetTransData(int f_iCommandNo, StringBuilder f_pData, ref int f_pLen);

        [DllImport(ConstantService.sajectDllPath, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "SajetTransClose")]
        public static extern bool SajetTransClose();


    }
}
