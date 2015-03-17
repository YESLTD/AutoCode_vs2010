using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSScriptLibrary;
using System.Drawing;

namespace AutoCode
{
    class PublicProperty
    {

        #region 文件导出设置

        //导出文件路径
        public static string FILEPATH = ""; 

        #endregion

        #region 关键字颜色设置

        //蓝色关键字
        public static List<string> blueKeyWords = new List<string> 
            { "using", "namespace", "public", "private", "protected","abstract",
               "partial", "class", "new",  "this",
               "while","foreach", "for",  "if", "else", "switch","case","null","return","try","catch","static",
               "string","int", "float", "double", "char", "bool", "short", "void" };
        //红色关键字
        public static List<string> redKeyWords = new List<string> { "@GetClassName(SourceTable)", "@InitProperty(SourceTable)" };
        //绿色关键字
        public static List<string> greenKeyWords = new List<string> { "//", "///", "<summary>", "</summary>", "<param name=", "</param>", "<returns>", "</returns>" };
        //粉色关键字
        public static List<string> magentaKeyWords = new List<string> { "<script>", "</script>", "<%", "%>", "#START", "#END" }; 

        #endregion

        #region 动态编译设置

        //未知方法
        public static string UNKNOWN = "_UNKNOWN_METHOD_";
        //模板所注册的方法名集合
        public static List<string> methodNameSet = new List<string>();
        //方法字典
        public static Dictionary<string, string> methodSet = new Dictionary<string, string>();
        //临时存方法名的字符串
        public static string tempMethodName = "";
        //临时存方法的字符串
        public static string tempMethod = "";
        //到达函数区标识
        public static bool functionFlag = false;
        //动态编译完成的类
        public static AsmHelper script = null; 

        #endregion

        #region 窗体外观设置

        //窗体背景色
        public static Color colorBack = Color.White;
        //控件前景色
        public static Color colorFront = Color.LightSlateGray;
        //边距
        public static int iBorderWidth = 4;

        #endregion

    }
}
