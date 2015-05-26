using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using ToolFunction;

namespace AutoCode
{
    /// <summary>
    /// 经模板处理所生产的代码对象
    /// </summary>
    public class Code
    {
        private Code() { }
        private static Code instance = new Code();

        /// <summary>
        /// 导出文件名
        /// </summary>
        string strCodeName = string.Empty;

        /// <summary>
        /// 导出文件路径
        /// </summary>
        string strCodePath = Settings.Default.BasePath;

        /// <summary>
        /// 导出文件的文本
        /// </summary>
        string strCodeText = string.Empty;
        /// <summary>
        /// 导出文件类型
        /// </summary>
        string strCodeType =  Settings.Default.ExportType;
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static Code GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// 按照模板生成代码，所有方法都局限在固有代码内，要想升级需改动源码
        /// </summary>
        /// <param name="p_dtTable"></param>
        public void OutPutCode(DataTable p_dtTable)
        {
            string strFilePath = strCodePath, _strLine;
            DBModel.GetClassName(p_dtTable);
            try
            {
                using (StreamReader sr = new StreamReader(Templet.GetInstance().strTempletPath, Encoding.Default))
                {
                    using (FileStream fs = new FileStream(strCodePath + "\\" + DBModel.strModelName+ strCodeType, FileMode.Create, FileAccess.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                        {
                            sw.AutoFlush = true;
                            if (!Directory.Exists(strFilePath))
                            {
                                Directory.CreateDirectory(strFilePath);
                            }
                            while ((_strLine = sr.ReadLine()) != null)
                            {
                                //模板尾，外部脚本区终止打印
                                if (_strLine.StartsWith("<script>") || _strLine.Contains("<script>"))
                                {
                                    break;
                                }
                                string _strMethodName = Templet.GetInstance().CheckMethod(_strLine);
                                if (PublicProperty.UNKNOWN != _strMethodName)
                                {
                                    object[] _objParam = new object[] { p_dtTable };
                                    string _strReplace = Templet.GetInstance().SubString(_strLine, "@", ")");
                                    //去掉@符的函数名
                                    string _strNOa = _strMethodName.Substring(1);
                                    object _objResult = Templet.GetInstance().RunDynamicCode(_strNOa, _objParam);
                                    _strLine = _strLine.Replace(_strReplace, _objResult.ToString());
                                    sw.WriteLine(_strLine);
                                }
                                else
                                {
                                    sw.WriteLine(_strLine);
                                }
                            }
                        }
                        PublicProperty.SuccessFlag = true;
                    }
                }
            }
            catch (Exception exp)
            {
                PublicProperty.SuccessFlag = false;
                CommonFunction.WriteLog(exp, "生成文件报错了在CreateCode里");
            }
        }
       

       

    }
}
