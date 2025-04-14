#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.WindowsService
 * 唯一标识：ac737f49-0aa8-4eaa-bc02-f3f28a138834
 * 文件名：SwitchInputLanguageService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/15 17:00:38
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/15 17:00:38
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_Test.Service.WindowsService
{
    public class SwitchInputLanguageService
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        const uint WM_INPUTLANGCHANGEREQUEST = 0x0050;
        const uint KLF_ACTIVATE = 1;
        public static void SwitchInputLanguage()
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            uint processId;
            uint threadId = GetWindowThreadProcessId(foregroundWindow, out processId);
            IntPtr currentLayout = GetKeyboardLayout(threadId);

            // Load the English keyboard layout (en-US)
           // IntPtr englishLayout = LoadKeyboardLayout("00000409", KLF_ACTIVATE);

            // Post a message to the foreground window to change the input language
          //  PostMessage(foregroundWindow, WM_INPUTLANGCHANGEREQUEST, englishLayout, IntPtr.Zero);
        }
    }
}
