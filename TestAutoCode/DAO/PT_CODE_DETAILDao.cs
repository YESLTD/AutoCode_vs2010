using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ToolFunction;
namespace TestAutoCode
{
	public class DaoPT_CODE_DETAIL
	{
		private PT_CODE_DETAIL pt_code_detail = new PT_CODE_DETAIL();
		public DaoPT_CODE_DETAIL(){}
		/// <summary> 
		///  数据插入
		/// <summary> 
		/// <param name="dict">载有对象值的字典</param> 
		/// <returns>主键ID</returns> 
		public string InsertEntity(Dictionary<string, string> dict)
		{
			string sql = "insert into PT_CODE_DETAIL (CODE,CODE_NAME,DICT_ID) values ('@CODE','@CODE_NAME','@DICT_ID')";
			string id = Guid.NewGuid().ToString();
			try
			{
				CommonFunction.ExecutenonQuery(sql,dict);
			}
			catch(Exception e)
			{
				CommonFunction.WriteErrorLog(e.ToString());
			}
			return id;
		}

		/// <summary> 
		///  数据删除
		/// <summary> 
		/// <param name="dict">主键id</param> 
		/// <returns>主键ID</returns> 
		public string DeleteEntity(Dictionary<string, string> dict)
		{
			string sql = "delete PT_CODE_DETAIL where id = '@id'";
			string id = Guid.NewGuid().ToString();
			try
			{
				CommonFunction.ExecutenonQuery(sql,dict);
			}
			catch(Exception e)
			{
				CommonFunction.WriteErrorLog(e.ToString());
			}
			return id;
		}

		/// <summary> 
		///  数据修改
		/// <summary> 
		/// <param name="dict">主键id</param> 
		/// <returns>主键ID</returns> 
		public string UpdateEntity(Dictionary<string, string> dict)
		{
			string sql = "update PT_CODE_DETAILset CODE'@CODE',CODE_NAME'@CODE_NAME',DICT_ID'@DICT_ID'";
			string id = Guid.NewGuid().ToString();
			try
			{
				CommonFunction.ExecutenonQuery(sql,dict);
			}
			catch(Exception e)
			{
				CommonFunction.WriteErrorLog(e.ToString());
			}
			return id;
		}

		/// <summary> 
		///  数据查询
		/// <summary> 
		/// <param name="dict">主键id</param> 
		/// <returns>主键ID</returns> 
		public string QueryEntity(Dictionary<string, string> dict)
		{
			string sql = "select * from PT_CODE_DETAILwhere id = '@id'";
			string id = Guid.NewGuid().ToString();
			try
			{
				CommonFunction.ExecutenonQuery(sql,dict);
			}
			catch(Exception e)
			{
				CommonFunction.WriteErrorLog(e.ToString());
			}
			return id;
		}

	}
}