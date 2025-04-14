#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.HIPOT
 * 唯一标识：f5b65bbb-4c58-4ea8-a190-28d26fe3794c
 * 文件名：EntityACSetting
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/8 16:29:11
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/8 16:29:11
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

namespace Multiple_Test.Models.HIPOT
{
    public class EntityACSetting
    {

        public string Test_Item { get; set; }
        /// <summary>
        /// AC 测试电压
        /// </summary>
        public string Volt { get; set; }
        /// <summary>
        /// 电流上限
        /// </summary>
        public string High { get; set; }
        /// <summary>
        /// 测试时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 测试漏电流上限
        /// </summary>
        public string Limit_High { get; set; }
        /// <summary>
        /// 测试漏电流下限
        /// </summary>
        public string Limit_Low { get; set; }
        /// <summary>
        /// 设置高通道
        /// </summary>
        public string Chan_HIGH { get; set; }
        /// <summary>
        /// 设置低通道
        /// </summary>
        public string Chan_LOW { get; set;}
        /// <summary>
        /// 电弧长度
        /// </summary>
        public float ARC { get; set; }
        
    }
}
