#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.Buttons
 * 唯一标识：58effdc6-efed-4c06-8c7f-8f4226c6a04b
 * 文件名：ButtonsService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/11 11:11:49
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/11 11:11:49
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Service.Buttons
{
    public class ButtonsService
    {
        /// <summary>
        /// Enable Button
        /// </summary>
        /// <param name="btn"></param>
        public static void EnableBtn(UIButton btn)
        {
            btn.Enabled = true;
        }

        public static void EnableBtn(UIHeaderButton btn)
        {
            btn.Enabled = true;
        }
        /// <summary>
        /// Enable ToolStripItem
        /// </summary>
        /// <param name="btn"></param>
        public static void EnableBtn(ToolStripItem btn)
        {
            btn.Enabled = true;
        }
        /// <summary>
        /// Disable Button
        /// </summary>
        /// <param name="btn"></param>
        public static void DisableBtn(UIHeaderButton btn) { btn.Enabled = false; }
        /// <summary>
        /// Disable Button
        /// </summary>
        /// <param name="btn"></param>
        public static void DisableBtn(UIButton btn) {  btn.Enabled = false; }
        /// <summary>
        /// Disable ToolStripItem
        /// </summary>
        /// <param name="btn"></param>
        public static void DisableBtn(ToolStripItem btn) {  btn.Enabled = false; }
        /// <summary>
        /// 显示按钮
        /// </summary>
        /// <param name="btn"></param>
        public static void ShowVisible(UIButton btn)
        {
            btn.Visible = true;
        }
        /// <summary>
        /// 隐藏按钮
        /// </summary>
        /// <param name="btn"></param>
        public static void HideVisible(UIButton btn)
        {
            btn.Visible = false;
        }
    }
}
