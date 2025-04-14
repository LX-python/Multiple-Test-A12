#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.Firmware
 * 唯一标识：e8e7f264-79d5-4ea7-aa5c-fca5e7d98da8
 * 文件名：EntityFirmwareTestRecord
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/29 8:59:40
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/29 8:59:40
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

namespace Multiple_Test.Models.Firmware
{
    /// <summary>
    /// FW 测试记录
    /// </summary>
    public class EntityFirmwareTestRecord
    {
        public string serial_number { get; set; }
        public string test_result { get; set; }
        public string fw_version { get; set; }

        public string test_datetime { get; set; }
    }
}
