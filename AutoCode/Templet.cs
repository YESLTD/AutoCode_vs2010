using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolFunction;
using System.IO;
using System.Reflection;
using CSScriptLibrary;

namespace AutoCode
{
    public class Templet
    {
        private Templet() { }

        private static Templet templet = new Templet();
        /// <summary>
        /// 模板名称
        /// </summary>
        public string strTempletName = string.Empty;
        /// <summary>
        /// 模板路径
        /// </summary>
        public string strTempletPath = string.Empty;
        /// <summary>
        /// 模板文本
        /// </summary>
        public string strTempletText = string.Empty;
        /// <summary>
        /// 方法对象
        /// </summary>
        Method method = null;
        /// <summary>
        /// 类体
        /// </summary>
        public string strClassBody = string.Empty;
        /// <summary>
        /// 编译完成的脚本
        /// </summary>
        public  AsmHelper script = null; 
        /// <summary>
        /// 模板方法集
        /// </summary>
        public Dictionary<string, string> dictMethodSet = new Dictionary<string, string>();

        public static Templet GetInstance()
        {
            return templet;
        }

        /// <summary>
        /// 打开模板文件，并赋值给strTempletText
        /// 2015-05-26 wuhailong
        /// </summary>
        /// <param name="p_strPath">文件路径</param>
        public void OpenFile(string p_strPath)
        {
            try
            {
                StreamReader sr = null;
                using (sr = new StreamReader(p_strPath, Encoding.Default))
                {

                    String _strLine;
                    string _strMess = "";
                    while ((_strLine = sr.ReadLine()) != null)
                    {
                        _strMess += _strLine + "\n";
                    }
                    this.strTempletText = _strMess;

                }
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "这是根节点--！该怎么办呢？");
            }
        }


        /// <summary>
        /// 装载方法
        /// 2015-05-26 wuhailong
        /// </summary>
        public void LoadTempletProperity()
        {
            try
            {
                dictMethodSet.Clear();
                using (StreamReader sr = new StreamReader(strTempletPath, Encoding.Default))
                {
                    string _strLine;
                    //装载配置信息，函数名函数体
                    while ((_strLine = sr.ReadLine()) != null)
                    {
                        //模板头，注册信息不打印
                        GetAllMethod(_strLine);
                    }
                }
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "没有载入模板！");
            }

        }


        /// <summary>
        /// 将文本行拼接成函数，并存入 dictMethodSet
        /// 2015-05-26 wuhailong
        /// </summary>
        /// <param name="p_strLine">文本行</param>
        public void GetAllMethod(string p_strLine)
        {
            try
            {
                if (p_strLine.Contains("<script>"))
                {
                    PublicProperty.functionFlag = true;
                }
                if (p_strLine.Contains("</script>"))
                {
                    PublicProperty.functionFlag = false;
                }
                if ("<script>" != p_strLine.Trim() && "</script>" != p_strLine.Trim() && PublicProperty.functionFlag)
                {
                    if (p_strLine.Contains("#region"))
                    {//函数开始
                        method = new Method();
                        int _iStart = p_strLine.IndexOf("@");
                        string _strName = p_strLine.Substring(_iStart);
                        method.strMethodName = _strName;
                    }
                    else if (p_strLine.Contains("#endregion") && method != null)
                    {//函数结束
                        if (PublicProperty.methodSet.ContainsKey(PublicProperty.tempMethodName))
                        {
                            return;
                        }
                        dictMethodSet.Add(method.strMethodName, method.strMethodBody);
                    }
                    else if (method != null)
                    {
                        //函数文本追加
                        method.strMethodBody += p_strLine + "\n";
                    }
                }
            }
            catch (Exception exp)
            {

                CommonFunction.WriteLog(exp, "GetAllMethod方法读取函数错误！");
            }
        }

        /// <summary>
        /// 执行动态编译
        /// </summary>
        public void ComplieClass()
        {
            this.strClassBody = GetClassBody();
            AsmHelper script = null;
            try
            {
                Assembly assembly = CSScript.LoadCode(
                @"using System;
                  using System.Collections.Generic;
                  using System.Text;
                  using System.IO;
                  using System.Data;
                  using System.Reflection;
                  using System.Windows.Forms;
                  public class Script
                  {
                    public static void SayHello(string s)
                    {
                        MessageBox.Show(""Hello!""+s);
                    }"
                               + strClassBody +
                 "}"
                  );
                script = new AsmHelper(assembly);
                this.script = script;
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "模板编译失败！");
            }
        }

        /// <summary>
        /// 获取类体
        /// 2015-05-26 wuhailong
        /// </summary>
        /// <returns></returns>
        public string GetClassBody()
        {
            string strResult = "";

            foreach (string item in dictMethodSet.Keys)
            {
                strResult += dictMethodSet[item];
            }
            return strResult;
        }

        /// <summary>
        /// 检查文本行内是否有方法名，有则输出方法名
        /// </summary>
        /// <param name="_strLine">文本行</param>
        /// <returns>方法名</returns>
        public string CheckMethod(string _strLine)
        {
            string _strMethodName = PublicProperty.UNKNOWN;
            try
            {
                foreach (var item in dictMethodSet.Keys)
                {
                    if (_strLine.Contains(item))
                    {
                        _strMethodName = item;
                    }
                }
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "检查方法出错！");
            }
            return _strMethodName;
        }

        /// <summary>
        /// 运行动态编译的类中的方法
        /// </summary>
        /// <param name="p_strMethodName">方法名</param>
        /// <param name="p_objParam">参数</param>
        public object RunDynamicCode(string p_strMethodName, object[] p_objParam)
        {
            return script.Invoke("Script." + p_strMethodName, p_objParam);
        }


        /// <summary>
        /// 截取出字符串按第一个p_strStarChar 到第一个p_strEndChar中的内容
        /// </summary>
        /// <param name="p_strMy">输入字符串</param>
        /// <param name="p_strStarChar">开始字符</param>
        /// <param name="p_strEndChar">结束字符</param>
        /// <returns></returns>
        public string SubString(string p_strMy, string p_strStarChar, string p_strEndChar)
        {

            //函数头
            int _iMethodStart = p_strMy.IndexOf(p_strStarChar);
            //函数尾部
            int _iMethodEnd = p_strMy.IndexOf(p_strEndChar);
            //函数长度
            int _iLength = _iMethodEnd - _iMethodStart + 1;
            //获取应替换部分
            string _strReplace = p_strMy.Substring(_iMethodStart, _iLength);
            return _strReplace;
        }

    }
}
