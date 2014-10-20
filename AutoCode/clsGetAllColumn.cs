using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using ToolFunction;
using System.Data;
namespace AutoCode
{
    public class clsGetAllColumn
    {
        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <returns></returns>
        public static DataTable getTable()
        {
            DataTable tablename = new DataTable();
            string sqlGetTable = "SELECT distinct 0 CHK,T.* FROM USER_TABLES T";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            tablename = CommonFunction.ExecuteBySQL(sqlGetTable, dic, "");
            return tablename;
        }
        /// <summary>
        /// 获取表的所有列，表名，列名，数据类型，长度
        /// </summary>
        /// <returns></returns>
        public static List<string[]> getColunm(string tablename)
        {
            List<string[]> columnlist = new List<string[]>();
            try
            {
                DataTable colulmnproperity = new DataTable();
                Dictionary<string, string> dicColumnProperity = new Dictionary<string, string>();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                string sqlGetColumn = string.Format("SELECT * FROM USER_TAB_COLUMNS WHERE TABLE_NAME = '{0}' ORDER BY COLUMN_ID",tablename.ToUpper());
                colulmnproperity = CommonFunction.ExecuteBySQL(sqlGetColumn, dic, "");
                foreach (DataRow dr in colulmnproperity.Rows)
                {
                    string[] column = { dr["TABLE_NAME"].ToString(), dr["COLUMN_NAME"].ToString(), dr["DATA_TYPE"].ToString(), dr["DATA_LENGTH"].ToString() };
                    columnlist.Add(column);
                }
            }
            catch (Exception e)
            {
                CommonFunction.WriteErrotLog(e.ToString());
            }
            return columnlist;
        }
    }
}
