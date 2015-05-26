using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ToolFunction;

namespace AutoCode
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class DBModel
    {
        /// <summary>
        /// 数据模型名称
        /// </summary>
        public static string strModelName = string.Empty;

        /// <summary>
        /// 列
        /// </summary>
        public DBColumn column = null;

        /// <summary>
        /// 数据模型列
        /// </summary>
        public List<DBColumn> ColumnList = new List<DBColumn>();

        /// <summary>
        /// 数据表
        /// </summary>
        public DataTable dtModelTable = null;

        /// <summary>
        /// 获取勾选的数据源
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSelectTable()
        {
            List<string> tablelist = new List<string>();
            foreach (DataRow dr in PublicProperty.Source.Rows)
            {
                if (dr["CHK"].ToString() == "True")
                {
                    tablelist.Add(dr["TABLE_NAME"].ToString());
                }
            }
            return tablelist;
        }

        /// <summary>
        /// 根据表生成类的名字
        /// </summary>
        /// <param name="p_dtTable">表</param>
        /// <returns></returns>
        public static void GetClassName(DataTable p_dtTable)
        {
            if (p_dtTable == null)
            {
                return;
            }
            string _strTemp = p_dtTable.TableName.Substring(0, 1).ToUpper() + p_dtTable.TableName.Substring(1).ToLower();
            strModelName = _strTemp;
        }

        /// <summary>
        /// 根据表名返回表结构
        /// </summary>
        /// <param name="p_strTableName">表名</param>
        /// <returns>表</returns>
        public static DataTable GetTable(string p_strTableName)
        {
            string _strSQL = "select * from " + p_strTableName + " where 1=0";
             DataTable dtTemp =  CommonFunction.OleExecuteBySQL(_strSQL, new SortedDictionary<string, string>(), p_strTableName);
             GetClassName(dtTemp);
             return dtTemp;
        }

    }
}
