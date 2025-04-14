#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (C) 2024 $Liteon$  保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：REDEEMER
 * 公司名称：$Liteon$
 * 命名空间：Multiple_Test.Service.Files
 * 唯一标识：e3b2f3a0-06f0-4b08-b6f9-2a15da58dd89
 * 文件名：FilesService
 * 当前用户域：REDEEMER
 *
 * 创建者：Administrator
 * 电子邮箱：yysvent@163.com
 * 创建时间：2024/1/10 20:23:36
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 版本：V 1.0.1
 * 修改人：Shengbi
 * 时间：2024/1/10 20:23:36
 * 修改说明：新模组上线
 * 修改功能：
 * 
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>
using Multiple_Test.Models.HIPOT;
using Multiple_Test.Utilities.Constant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Test.Service.Files
{
    public class FilesService
    {
      
 
        /// <summary>
        /// 打开脚本
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string OpenScriptFile(ref string message)
        {

            CheckPath(Application.StartupPath+ConstantService.ScriptPath);
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置文件筛选器以仅显示 .Script 文件
            openFileDialog.Filter = "Script Files (*.IQCHipotScript)|*.IQCHipotScript";
            openFileDialog.InitialDirectory =Application.StartupPath+ ConstantService.ScriptPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                return filePath;
             
            }

            message = "用户没有选择脚本";
            return null;
        }

        /// <summary>
        /// 打開燒錄的Hex 儅
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string OpenHex(ref string message) 
        {
            CheckPath(Application.StartupPath + ConstantService.FwPath);
            string[] files = Directory.GetFiles(Application.StartupPath + ConstantService.FwPath);
            if (files.Length > 1)
            {

                message = "有多个FW 版本文件";
                OpenPath(Application.StartupPath + ConstantService.FwPath);
                return null;
            }

            if (files.Length == 0)
            {

                message = "没有FW 版本文件,请放入Fw版本文件";
                OpenPath(Application.StartupPath + ConstantService.FwPath);
                return null;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // 设置文件筛选器以仅显示 .Hex 文件
            openFileDialog.Filter = "Hex Files (*.Hex)|*.Hex";
            openFileDialog.InitialDirectory = Application.StartupPath + ConstantService.FwPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                return filePath;

            }


            message = "用户没有选择脚本";
            return null;

        }
        /// <summary>
        /// 转换读取脚本
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<EntityTestStep> ConvertStepScript(string filePath)
        {
            try
            {
                // 使用 StreamReader 逐行读取文件内容
                string script = "";
                using (StreamReader reader = new StreamReader(filePath))
                {
                    Console.WriteLine("文件内容:");

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        script += line;
                        Console.WriteLine(line);
                    }

                    var entity=JsonConvert.DeserializeObject<List<EntityTestStep>>(script);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"读取文件时发生错误: {ex.Message}");
                FileLog.LogError("ScriptReadError", $"读取脚本时发生错误: {ex.Message}");
            }

            return new List<EntityTestStep>();
        }
        /// <summary>
        /// 保存脚本
        /// </summary>
        /// <param name="scriptName"></param>
        /// <param name="scriptString"></param>
        /// <returns></returns>
        public bool SaveScript(string scriptName,string scriptString) 
        {
            CheckPath(Application.StartupPath+ConstantService.ScriptPath);
            try
            {
                // 将字符写入文件
                File.WriteAllText($"{Application.StartupPath}{ConstantService.ScriptPath}{ConstantService.pathSlash}{scriptName}{ ConstantService.HipotScriptName}", scriptString);
                return true;

            }
            catch (Exception ex)
            {
                FileLog.LogError(ConstantService.ScriptSaveError,$"保存文件时发生错误: {ex.Message}");

                return false;
            }

        }
        /// <summary>
        /// 检查路径是否存在没有就创建
        /// </summary>
        /// <param name="newPath"></param>
        public void CheckPath(string newPath) 
        {

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
        }
        /// <summary>
        /// 打開路徑
        /// </summary>
        /// <param name="path"></param>
        public void OpenPath(string path)
        {
            try
            {
                CheckPath(path);
                // 使用系统关联的程序打开路径
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"无法打开路径: {ex.Message}");
            }
        }
    }
}
