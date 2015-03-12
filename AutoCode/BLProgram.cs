using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCode
{
    class BLProgram
    {

            protected const string PROCESS_METHOD_CODE = @"
		 
		 public class Program
		 {{
				public static void Main()
				{{
					 string parameter = ""{0}""; 
					 string result = ""{1}"";
					 Detection(parameter,result);
			    }}
				static void Detection(string testParameters,string testResults)
				{{
					Console.WriteLine(testParameters+""-""+testResults);
				}}
		 }}";
            /// <summary>
            /// 判断程序题是否正确
            /// </summary>
            /// <param name="strCode"></param>
            /// <returns></returns>
            public bool IsCProgramRight(string strCode)
            {
                string id = Guid.NewGuid().ToString();
                List<string> output = new CodeRun().Run(strCode, id);
                string strOutpt = "";
                for (int i = 0; i < output.Count; i++)
                {
                    strOutpt += output[i];
                }
                return (strOutpt == "对/n");
            }
            /// <summary>
            /// 输出执行结果
            /// </summary>
            /// <param name="strCode"></param>
            /// <returns></returns>
            public string GetOutPut(string strCode)
            {
                string id = Guid.NewGuid().ToString();
                List<string> output = new CodeRun().Run(strCode, id);
                string strOutpt = "";
                for (int i = 0; i < output.Count; i++)
                {
                    strOutpt += output[i];
                }
                return strOutpt;
            }
            /// <summary>
            /// 生成程序
            /// </summary>
            /// <param name="parameter"></param>
            /// <param name="result"></param>
            /// <returns></returns>
            public string GetProgramStyle(string parameter, string result)
            {
                StringBuilder processMethod = new StringBuilder();
                processMethod.AppendFormat(PROCESS_METHOD_CODE, parameter, result);
                return processMethod.ToString();
            }
            /// <summary>
            /// 判断程序是否能生成成功
            /// </summary>
            /// <param name="strCode"></param>
            /// <returns></returns>
            public bool BianYI(string strCode)
            {
                string id = Guid.NewGuid().ToString();
                List<string> output = new CodeRun().Run(strCode, id);
                string strOutpt = "";
                for (int i = 0; i < output.Count; i++)
                {
                    strOutpt += output[i];
                }
                return (strOutpt == "对/n" || strOutpt == "错/n");
            }
        }
    
}
