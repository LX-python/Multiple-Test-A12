#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Models.API
 * 唯一标识：3f5f0e73-54ce-4bd2-97eb-89fc1e1313d9
 * 文件名：APIConstant
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/18 15:35:02
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/18 15:35:02
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

namespace Multiple_Test.Models.API
{
    public class APIConstant
    {
        /// <summary>
        /// 获取测试载具的状态
        /// Get
        /// </summary>
        public const string GetVehicleStatus = "/api/Vehicle/GetVehicleStatus";
        /// <summary>
        /// 用户登录界面
        /// </summary>
        public const string Login = "/api/User/Login";
        /// <summary>
        /// 修改测试载具状态
        /// </summary>
        public const string ModifyVehicleStatus = "/api/Equipment/Modify_Vehicle_Status";
        /// <summary>
        /// 检查程序版本
        /// </summary>
        public const string GetProgramsVersion = "/api/ProgramsManagement/CheckProgramsVersion";
        /// <summary>
        /// 獲取Thermal 測試脚本數據
        /// </summary>
        public const string Get_ThermalScriptSList = "/api/MultipleTestSystem/Get_ThermalScriptSList";

        /// <summary>
        /// 獲得Thermal 測試脚本的Detail 如檢查儀器等功能
        /// </summary>
        public const string Get_ThermalScriptDetail = "/api/MultipleTestSystem/Get_ThermalScriptDetail";
        /// <summary>
        /// 记录Thermal 测试记录
        /// </summary>
        public const string RecordThermalTestData = "/api/MultipleTestSystem/RecordThermalTestData";
        /// <summary>
        /// 获取服务器上最新的软件版本
        /// </summary>
        public const string GetIotBinVersion = "/api/ProgramsManagement/GetIotBinVersion";
        /// <summary>
        /// 下载服务器最新软件
        /// </summary>
        public const string DownloadIoTbin = "/api/ProgramsManagement/DownloadIoTbin";

        /// <summary>
        /// 检查页面上的权限
        /// </summary>
        public const string Get_Mutiple_SystemPageBtn = "/api/MultipleTestSystem/Get_Mutiple_SystemPageBtn";
        /// <summary>
        /// 點擊的接口
        /// </summary>
        public const string Record_Glue_dispensing_recording = "/api/MultipleTestSystem/Record_Glue_dispensing_recording";
    }
}
