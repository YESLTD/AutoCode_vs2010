using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ToolFunction;
namespace TestAutoCode
{
	public class PT_CODE_DETAIL
	{
		public PT_CODE_DETAIL(){}
		#region Properity 
		private string CODE;
		private string CODE_NAME;
		private string DICT_ID;
		#endregion
		#region Properity get set method 
		public string getCODE()
		{
			return CODE;
		}
		public void setCODE(string  value)
		{
			CODE= value;
		}
		public string getCODE_NAME()
		{
			return CODE_NAME;
		}
		public void setCODE_NAME(string  value)
		{
			CODE_NAME= value;
		}
		public string getDICT_ID()
		{
			return DICT_ID;
		}
		public void setDICT_ID(string  value)
		{
			DICT_ID= value;
		}
		#endregion 
	}
}