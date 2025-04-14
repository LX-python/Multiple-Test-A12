#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Utilities.Constant
 * 唯一标识：1da36082-7606-4fae-aaf9-b69c7365a705
 * 文件名：ConstantService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/11 21:28:48
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/11 21:28:48
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Utilities.Constant
{
    public static class ConstantService
    {

        public const string AC = "AC";
        public const string DC = "DC";
        public const string IR = "IR";
        public const string OS = "OS";
        public const string PA = "PA";
        public const string PASS = "PASS";
        public const string FAIL = "FAIL";
        public const int baudRate_9600 = 9600;
        public const int baudRate_115200 = 115200;
        public const string Step = "Step";
        public const string Mode = "Mode";
        public const string Test_Time = "Test_Time";
        public const string Condition = "Condition";
        public const string Abnormal_Comunication = "通讯异常,请检查COM或GPIB连接线是否正常";
        public const string Result = "Result";
        public const string Error_Msg = "Error_Msg";
        public const string dbPath = @"\dbs";
        public const string dbName = "TestData.db";
        public const string Test_Volt = "Test_Volt";
        public const string Test_Current = "Test_Current";
        public const string ScriptPath = @"\Scripts";
        public const string LogsPath = @"\Logs";
        public const string HipotScriptName = ".IQCHipotScript";
        public const string pathSlash = @"\";
        public const string ScriptSaveError = "ScriptSaveError";
        public const string TestLogs = @"\TestLogs";
        public const string Limit_Low = "Limit_Low";
        public const string Limit_High = "Limit_High";
        public const string LoginError = "LoginError";
        public const string LoginSucceed = "LoginSucceed";
        public const string ApiCallError = "ApiCallError";
        public const string ApiCallSucceed = "ApiCallSucceed";
        public const string ScriptError = "ScriptError";
        public const string Config= "Progarms.config";
        public const string FwPath = @"\FW";
        public const string ST_Link = @"\Lib\ST32\bin\STM32_Programmer_CLI.exe";
        public const string PrintModePath= @"\Lib\Teklynx\CLIENT_PA-1461-1A.lab";
        public const string sajectDllPath = @"\lib\Saject\SajetConnect.dll";

    }
}
