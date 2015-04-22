using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToolFunction;
using TestAutoCode;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Xml;

namespace AutoCode
{
    
    public partial class frmMain : Form
    {
        uctlBaseConfig ubc = null;
        uctlCreateCode ucc = null;
        uctlTimeAxis uta = null;
        TreeNode tn = null;
        public static TreeView tv_temp = null;
        public frmMain()
        {
            InitializeComponent();
            //初始化连接字符串
            string conn = CommonFunction.GetConnectionString(Settings.Default.DBType);
            //CommonFunction.SetConnectionString(Settings.Default.DataSource, Settings.Default.UserID, Settings.Default.Password);
            InitControls();
        }

        public void SetText()
        { }


        /// <summary>
        /// 初始化控件
        /// </summary>
        public void InitControls()
        {
            cmb_type.SelectedIndex = 0;
            LoadTimeAxis();
            LoadTempletPanel();
            LoadBaseSetting();
            LoadTables();
            LoadTempletList();
            LoadSql();
        }

        /// <summary>
        /// 载入时间轴控件
        /// 2015-04-16
        /// 吴海龙
        /// </summary>
        public void LoadTimeAxis()
        {
            SortedDictionary<string, string> sdict = new SortedDictionary<string, string>();
            sdict.Add("1", "读取配置");
            sdict.Add("2", "选择模板");
            sdict.Add("3", "确认数据");
            sdict.Add("4", "生成代码");
            uta = new uctlTimeAxis(sdict,1);
            uta.lc = new ToolFunction.uctlTimeAxis.TimeAxisClick(SayHello);
            CommonFunction.AddForm3(splitContainer4.Panel2, uta);
        }

        public void SayHello()
        {
            MessageBox.Show("Hello");
        } 

        /// <summary>
        /// 载入基础设置
        /// </summary>
        public void LoadBaseSetting() {
            te_basepath.Text = Settings.Default.BasePath;
            txt_ds.Text = Settings.Default.DataSource;
            txt_ui.Text = Settings.Default.UserID;
            txt_pd.Text = Settings.Default.Password;
            cmb_DBType.Text = Settings.Default.DBType;
        }

        /// <summary>
        /// 载入模板用户控件
        /// </summary>
        public void LoadTempletPanel()
        {
            uctlTemplet ut = new uctlTemplet();
            PublicProperty.UcTemplet = ut;
            CommonFunction.AddForm3(pl_container, ut);
        }

        ///// <summary>
        ///// 载入模板属性
        ///// </summary>
        //public void LoadTempletDetail()
        //{
        //    dgv_function.DataSource = null;
        ////PublicProperty.methodNameSet.Add
        //    DataTable _dtFunction = new DataTable();
        //    _dtFunction.Columns.Add("FUNCTION");
        //    foreach (var item in PublicProperty.methodNameSet)
        //    {
        //        _dtFunction.Rows.Add(item);
        //    }
        //    dgv_function.DataSource = _dtFunction.DefaultView;
        //}

        /// <summary>
        /// 载入数据源
        /// </summary>
        public void LoadTables()
        {
            try
            {
                PublicProperty.DBType = Settings.Default.DBType;
                PublicProperty.Source = GetAllColumn.getTable();
                //gc_talbelist.DataSource = PublicProperty.Source.DefaultView;
                dgv_tables.DataSource = PublicProperty.Source.DefaultView;
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "没有获取到数据源");
            }

        }

        

        /// <summary>
        /// 载入左侧treeview数据信息
        /// </summary>
        public  void LoadTempletList()
        {
            LoadTempletList(tv_templet);
            tv_temp = tv_templet;
            //TreeNode root = new TreeNode("模板列表");//创建节点
            //root.Name = "模板列表";//为节点取个名字,这儿创建的是根节点
            //tv_templet.Nodes.Add(root);//将节点添加到treeView1上
            //string[] files = Directory.GetFiles(PublicProperty.TempletPath);
            //foreach (string item in files)
            //{
            //    int _iIndex = item.LastIndexOf("\\");
            //    string _strNodeName = item.Substring(_iIndex + 1);
            //    TreeNode node = new TreeNode(_strNodeName);
            //    node.Name = _strNodeName;
            //    if (!root.Nodes.ContainsKey(node.Name))
            //    {
            //        root.Nodes.Add(node);
            //    }
            //}
        }

        public static void LoadTempletList(TreeView tv)
        {
            tv.Nodes.Clear();
            TreeNode root = new TreeNode("模板列表");//创建节点
            root.Name = "模板列表";//为节点取个名字,这儿创建的是根节点
            tv.Nodes.Add(root);//将节点添加到treeView1上
            string[] files = Directory.GetFiles(PublicProperty.TempletPath);
            foreach (string item in files)
            {
                int _iIndex = item.LastIndexOf("\\");
                string _strNodeName = item.Substring(_iIndex + 1);
                TreeNode node = new TreeNode(_strNodeName);
                node.Name = _strNodeName;
                if (!root.Nodes.ContainsKey(node.Name))
                {
                    root.Nodes.Add(node);
                }
            }
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ubc = new uctlBaseConfig();
            CommonFunction.AddForm3(pl_container, ubc);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ucc = new uctlCreateCode();
            CommonFunction.AddForm3(pl_container, ucc);
        }


        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctlAbout ua = new uctlAbout();
            CommonFunction.AddForm3(pl_container, ua);
        }



        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmTest f = new frmTest();
            f.Show();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctlTemplet ut = new uctlTemplet();
            CommonFunction.AddForm3(pl_container, ut);
        }

        private void 连接配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ubc = new uctlBaseConfig();
            CommonFunction.ShowForm(ubc, Color.White, Color.LightSlateGray, 4);
            //CommonFunction.AddTabControl(tc_contener, "连接配置", ubc);
        }

        private void 模板编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uctlTemplet ubc = new uctlTemplet();
            CommonFunction.AddForm3(pl_container, ubc);
            //CommonFunction.AddTabControl(tc_contener, "模板编辑", ubc);
        }

        private void 数据源选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucc = new uctlCreateCode();
            CommonFunction.AddForm3(pl_container, ucc);
            //CommonFunction.AddTabControl(tc_contener, "数据源选择", ucc);
        }

        private void 软件介绍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开一个txt文档展示说明
            try
            {
                Process Pnotepad = new Process();
                Pnotepad.StartInfo.FileName = PublicProperty.ReadMe;
                Pnotepad.Start();
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "应该是没找到文件readme");
            }
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest f = new frmTest();
            f.ShowDialog();
        }

        /// <summary>
        /// 初始化所有tab页
        /// </summary>
        public void InitAllTabs()
        {
            //uctlBaseConfig ubc = new uctlBaseConfig();
            //CommonFunction.AddTabControl(tc_contener, "连接配置", ubc);

            //uctlTemplet utc = new uctlTemplet();
            //CommonFunction.AddTabControl(tc_contener, "模板编辑", utc);

            //ucc = new uctlCreateCode();
            //CommonFunction.AddTabControl(tc_contener, "数据源选择", ucc);

            //uctlAbout ua = new uctlAbout();
            //CommonFunction.AddTabControl(tc_contener, "软件介绍", ua);
        }

        private void tv_templet_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PublicProperty.TempletName = tv_templet.SelectedNode.Name;
            PublicProperty.ExportPath = PublicProperty.TempletPath + tv_templet.SelectedNode.Name;
            PublicProperty.UcTemplet.OpenFile(PublicProperty.TempletPath + tv_templet.SelectedNode.Name);
            CreateCode cc = new CreateCode();
            cc.LoadTempletProperity();
            //LoadTempletDetail();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fbd_path.ShowDialog();
            te_basepath.Text = fbd_path.SelectedPath;
        }

        public void savefile()
        {
            try
            {
                Settings.Default.BasePath = te_basepath.Text;
                Settings.Default.DataSource = txt_ds.Text;
                Settings.Default.UserID = txt_ui.Text;
                Settings.Default.Password = txt_pd.Text;
                Settings.Default.DBType = cmb_DBType.Text;
                PublicProperty.DBType = cmb_DBType.Text;
                Settings.Default.Save();
                CommonFunction.GetConnectionString( cmb_DBType.Text);
                //CommonFunction.SetConnectionString(txt_ds.Text, txt_ui.Text, txt_pd.Text);
                uctlMessageBox.Show("保存成功！");
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "基础配置保存错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            savefile();
        }

        //private void gc_talbelist_Click(object sender, EventArgs e)
        //{
        //    if (gridView1.FocusedRowHandle >= 0)
        //    {
        //        DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
        //        if (dr["CHK"].ToString() == "0")
        //        {
        //            dr["CHK"] = "1";
        //            //dgv_ColumnSet.DataSource = GetColumnSet(dr["TABLE_NAME"].ToString()).DefaultView;
        //        }
        //        else
        //        {
        //            dr["CHK"] = "0";
        //        }
        //    }
        //}

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.Name.ToString() == "gridColumn1" & e.IsGetData)
            {
                if (PublicProperty.Source != null && PublicProperty.Source.Rows.Count > 0 && PublicProperty.Source.DefaultView[e.ListSourceRowIndex]["CHK"].ToString() == "1")
                {
                    e.Value = true;
                }
                else
                {
                    e.Value = false;
                }
            }
        }

        ///// <summary>
        ///// 获取勾选的数据源
        ///// </summary>
        ///// <returns></returns>
        //public List<string> getSelectTable()
        //{
        //    List<string> tablelist = new List<string>();
        //    foreach (DataRow dr in PublicProperty.Source.Rows)
        //    {
        //        if (dr["CHK"].ToString() == "1")
        //        {
        //            tablelist.Add(dr["TABLE_NAME"].ToString());
        //        }
        //    }
        //    return tablelist;
        //}

        ///// <summary>
        ///// 根据表名返回表结构
        ///// </summary>
        ///// <param name="p_strTableName">表名</param>
        ///// <returns>表</returns>
        //public DataTable GetTable(string p_strTableName)
        //{
        //    string _strSQL = "select * from " + p_strTableName + " where 1=0";
        //    return CommonFunction.OraExecuteBySQL(_strSQL, new Dictionary<string, string>(), p_strTableName);
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            LoadTables();
            //foreach (string s in PublicProperty.getSelectTable())
            //{
            //    CreateCode cc = new CreateCode();
            //    //cc.LoadProperity();
            //    DataTable _dtTable = PublicProperty.GetTable(s);
            //    cc.OutPutCode(_dtTable);
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PublicProperty.ExportType = cmb_type.Text;
        }


        /// <summary>
        /// 重命名文件
        /// </summary>
        public void ReNameFile()
        {
            try
            {
                if (tv_temp != null)
                {
                    string newName = tv_temp.Text;
                    FileInfo f = new FileInfo(PublicProperty.TempletPath + "\\" + tv_temp.Name);
                    f.MoveTo(PublicProperty.TempletPath + "\\" + newName);
                }
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp,"重命名文件出错！");
            }
        }

        private void tv_templet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (13 == e.KeyChar)
            {
                ReNameFile();
            }
        }

        private void tv_templet_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                ReNameFile();
            }
        }

        private void tv_templet_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tn = e.Node;
            tn.BeginEdit();
        }

        //private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        //{
        //    LoadTables();
        //}

        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //LoadTables();
        //}



        public void ProxySetStep()
        {
            //Thread.Sleep(1000);
            //uta.SetKeyValue("1");
            //Thread.Sleep(1000);
            //uta.SetKeyValue("2");
            //Thread.Sleep(1000);
            uta.SetKeyValue("3");

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                List<string> tablelist = PublicProperty.getSelectTable();
                CreateCode cc = new CreateCode();
                if (tablelist.Count > 0)
                {
                    foreach (string s in tablelist)
                    {
                        PublicProperty.TableProperty = PublicProperty.GetTable(s);
                        uta.SetKeyValue("2");
                        cc.OutPutCode(PublicProperty.TableProperty);
                        uta.SetKeyValue("4");
                    }
                }
                else  if (PublicProperty.SelfDefiTable != null)
                {
                    cc.OutPutCode(PublicProperty.SelfDefiTable);
                }
                else
                {
                    uctlMessageBox.Show("未选择数据源");
                    return;
                }
                if (PublicProperty.SuccessFlag)
                {
                    uctlMessageBox.Show("生成成功！");
                }
                else
                {
                    uctlMessageBox.Show("生成失败，详情查看错误日志！");
                }
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "生成代码时出错！");
            }
        }

        /// <summary>
        /// 将表的列转换成表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetColumn(DataTable dt)
        {
            DataTable dtColumns = new DataTable();
            dtColumns.Columns.Add("column");
            foreach (DataColumn item in dt.Columns)
            {
                dtColumns.Rows.Add(item.ColumnName);
            }
            return dtColumns;
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            string _strMethodBody = "";
            foreach (var item in PublicProperty.methodSet.Keys)
            {
                _strMethodBody += PublicProperty.methodSet[item].ToString() + "\n";
            }
            CreateCode cc = new CreateCode();
            cc.ComplieClass(_strMethodBody);
        }

        private void dgv_tables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string s = dgv_tables[0, e.RowIndex].Value.ToString();
            if ("False" == dgv_tables[0, e.RowIndex].Value.ToString())
            {
                dgv_tables[0, e.RowIndex].Value = true;
            }
            else
            {
                dgv_tables[0, e.RowIndex].Value = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("unrealized function");
        }

        private void btn_exeSQL_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtb_name.Text=="")
                {
                    uctlMessageBox.Show("未填写文件名！");
                    return;
                }
                ExeSql( rtb_sql.Text);
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, exp.Message);
            }
        }

        /// <summary>
        /// 执行sql
        /// 语句
        /// </summary>
        public void ExeSql(string sql)
        {
            try
            {
                //string sql = rtb_sql.Text;
                PublicProperty.SelfDefiTable = CommonFunction.OleExecuteBySQL(sql, new SortedDictionary<string, string>(), rtb_name.Text);
                dgv_columns.DataSource = GetColumn(PublicProperty.SelfDefiTable);
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp.Message);
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (rtb_name.Text=="")
            {
                return;
            }
            WriteSQL(rtb_name.Text,rtb_sql.Text);
            LoadSql();
        }


        #region 操作SQL

        /// <summary>
        /// 写日志信息
        /// </summary>
        /// <param name="p_expEx">异常信息</param>
        /// <param name="sql">个性化信息</param>
        public static void WriteSQL(string name, string sql)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Application.StartupPath + @"\" + Application.ProductName + "SQL.xml");
            }
            catch (FileNotFoundException)
            {
                CreateSQLFile();
            }
            AppendLogMessage(doc, name, sql);
        }

        /// <summary>
        /// 删除指定节点
        /// </summary>
        /// <param name="nodeName"></param>
        public static void DeleteNode(string nodeName) {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Application.StartupPath + @"\" + Application.ProductName + "SQL.xml");
                XmlElement root = doc.DocumentElement;
                foreach (XmlElement item in root.ChildNodes)
                {
                    string name = item.Attributes["name"].Value;
                    if (name == nodeName)
                    {
                        root.RemoveChild(item);
                    }
                }
                doc.Save(Application.StartupPath + @"\" + Application.ProductName + "SQL.xml");
            }
            catch (FileNotFoundException)
            {
                //CreateSQLFile();
            }
        }

        /// <summary>
        /// 没有日志文件创建日志文件
        /// </summary>
        /// <param name="doc">xml文件</param>
        public static void CreateSQLFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null);
            doc.AppendChild(dec);
            XmlNode root = doc.CreateElement("Root");
            doc.AppendChild(root);
            doc.Save(Application.StartupPath + @"\" + Application.ProductName + "SQL.xml");
        }



        /// <summary>
        /// 成功载入Log文件并添加节点日志信息
        /// </summary>
        /// <param name="doc">载入的xml文件</param>
        /// <param name="ex">异常信息</param>
        /// <param name="mess">传入个性化信息</param>
        private static void AppendLogMessage(XmlDocument doc, string name, string sql)
        {
            try
            {
                //载入日志文件
                doc.Load(Application.StartupPath + @"\" + Application.ProductName + "SQL.xml");
                //创建节点(一级)
                XmlNode root = doc.SelectSingleNode("Root");
                //创建节点（二级）
                XmlNode node = doc.CreateElement("sql");
                node.Attributes.Append(doc.CreateAttribute("name")).Value=name;
                node.Attributes.Append(doc.CreateAttribute("value")).Value = sql;
                ////创建节点（三级）
                //XmlElement element1 = doc.CreateElement("name");
                //element1.InnerText = name;
                //node.AppendChild(element1);
                //XmlElement element2 = doc.CreateElement("string");
                //element2.InnerText = sql;
                //node.AppendChild(element2);
                root.AppendChild(node);
                doc.Save(Application.StartupPath + @"\" + Application.ProductName + "SQL.xml");
            }
            catch (Exception exp)
            {
                CommonFunction.WriteErrorLog(exp.Message);
            }
        }

        /// <summary>
        /// 载入sql
        /// </summary>
        public void LoadSql()
        {
            string path = Application.StartupPath + @"\" + Application.ProductName + "SQL.xml";
            DataSet ds =null;
            try
            {
                ds = CommonFunction.ConvertXMLFileToDataSet(path);
                dgv_sql.DataSource = ds.Tables.Count > 0 ? ds.Tables[0].DefaultView : null;
            }
            catch (Exception)
            {
                CreateSQLFile();
            }
        }

        #endregion


        private void dgv_sql_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (1 == e.ColumnIndex)
            {
                string sqlname = dgv_sql["name", e.RowIndex].Value.ToString();
                DeleteNode(sqlname);
                LoadSql();
            }
            else
            {
                string sql = dgv_sql[e.ColumnIndex, e.RowIndex].Value.ToString();
                rtb_sql.Text = sql;
                rtb_name.Text = dgv_sql["name", e.RowIndex].Value.ToString();
                ExeSql(rtb_sql.Text);
            }
           
        }
    }
}