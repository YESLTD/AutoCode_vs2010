using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using ToolFunction;
using System.Data;
namespace AutoCode
{
    public class GetAllColumn
    {
        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <returns></returns>
        public static DataTable getTable()
        {
            DataTable tablename = new DataTable();
            string sql = "";
            if ("Oracle" == PublicProperty.DBType)
            {
                sql = "SELECT 'false'  CHK,T.TABLE_NAME FROM USER_TABLES T";
            }
            else if ("SQLServer" == PublicProperty.DBType)
            {
                sql = "select 'false' as CHK, [name] as TABLE_NAME from [sysobjects] where [type] = 'u' order by [name]";
            }
            else if ("MySQL" == PublicProperty.DBType)
            {

            }
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            //tablename = CommonFunction.OraExecuteBySQL(sqlGetTable, dic, "");
            tablename = CommonFunction.OleExecuteBySQL(sql, dic, "");
            DataTable dt = ConvertTable(tablename);
            return dt;
        }

        /// <summary>
        /// 绑定datagridview 列要为bool值
        /// 2015-04-20
        /// wuhailong
        /// </summary>
        /// <param name="p_dt"></param>
        /// <returns></returns>
        public static DataTable ConvertTable(DataTable p_dt)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CHK", typeof(bool));
            dt.Columns.Add("TABLE_NAME", typeof(string));
            foreach (DataRow item in p_dt.Rows)
            {
                dt.Rows.Add(bool.Parse(item["CHK"].ToString()), item["TABLE_NAME"].ToString());
            }
            return dt;
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
                colulmnproperity = CommonFunction.OraExecuteBySQL(sqlGetColumn, dic, "");
                foreach (DataRow dr in colulmnproperity.Rows)
                {
                    string[] column = { dr["TABLE_NAME"].ToString(), dr["COLUMN_NAME"].ToString(), dr["DATA_TYPE"].ToString(), dr["DATA_LENGTH"].ToString() };
                    columnlist.Add(column);
                }
            }
            catch (Exception e)
            {
                CommonFunction.WriteErrorLog(e.ToString());
            }
            return columnlist;
        }
    }
}
