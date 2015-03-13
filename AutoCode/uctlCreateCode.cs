using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ToolFunction;

namespace AutoCode
{
    public partial class uctlCreateCode : UserControl
    {
        private DataTable source = new DataTable();
        public uctlCreateCode()
        {
            InitializeComponent();
            initControl();
        }

        /// <summary>
        /// 根据表名返回表结构
        /// </summary>
        /// <param name="p_strTableName">表名</param>
        /// <returns>表</returns>
        public DataTable GetTable(string p_strTableName)
        {
            string _strSQL = "select * from " + p_strTableName + " where 1=0";
            return CommonFunction.OraExecuteBySQL(_strSQL, new Dictionary<string, string>(), p_strTableName);
        }

        /// <summary>
        /// 更具表名获取表列的详细信息
        /// </summary>
        /// <param name="p_strName">表名</param>
        /// <returns></returns>
        public DataTable GetColumnSet(string p_strName) {

            DataTable _dtTable = GetTable(p_strName);
            DataTable _dtResult = new DataTable();
            _dtResult.Columns.Add("表名");
            _dtResult.Columns.Add("数据类型");
            foreach (DataColumn item in _dtTable.Columns)
            {
                _dtResult.Rows.Add(item.ColumnName, item.DataType.Name);
            }
            return _dtResult;
        }


        private void code_selected_Click(object sender, EventArgs e)
        {
            foreach (string s in getSelectTable())
            {
                CreateCode cc = new CreateCode();
                DataTable _dtTable = GetTable(s);
                cc.OutPutCode(_dtTable);
            }
        }
        public List<string> getSelectTable()
        {
            List<string> tablelist = new List<string>();
            foreach (DataRow dr in source.Rows)
            {
                if (dr["CHK"].ToString()=="1")
                {
                    tablelist.Add(dr["TABLE_NAME"].ToString());
                }
            }
            return tablelist;
        }
        private void code_all_Click(object sender, EventArgs e)
        {
             
        }
        public void initControl()
        {
            source = GetAllColumn.getTable();
            gc_talbelist.DataSource = source.DefaultView;
        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            
            if (e.Column.Name.ToString() == "gridColumn1" & e.IsGetData)
            {
                if (source != null && source.Rows.Count > 0 && source.DefaultView[e.ListSourceRowIndex]["CHK"].ToString() == "1")
                {
                    e.Value = true;
                }
                else
                {
                    e.Value = false;
                }
            }
        }

        private void gc_talbelist_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (dr["CHK"].ToString() == "0")
                {
                    dr["CHK"] = "1";
                    dgv_ColumnSet.DataSource = GetColumnSet(dr["TABLE_NAME"].ToString()).DefaultView;
                }
                else
                {
                    dr["CHK"] = "0";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string s in getSelectTable())
            {
                CreateCode cc = new CreateCode();
                DataTable _dtTable = GetTable(s);
                cc.LoadProperity();
                cc.OutPutCode(_dtTable);
            }
        }

       
    }
}
