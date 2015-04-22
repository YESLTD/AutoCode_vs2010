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
            //��ʼ�������ַ���
            string conn = CommonFunction.GetConnectionString(Settings.Default.DBType);
            //CommonFunction.SetConnectionString(Settings.Default.DataSource, Settings.Default.UserID, Settings.Default.Password);
            InitControls();
        }

        public void SetText()
        { }


        /// <summary>
        /// ��ʼ���ؼ�
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
        /// ����ʱ����ؼ�
        /// 2015-04-16
        /// �⺣��
        /// </summary>
        public void LoadTimeAxis()
        {
            SortedDictionary<string, string> sdict = new SortedDictionary<string, string>();
            sdict.Add("1", "��ȡ����");
            sdict.Add("2", "ѡ��ģ��");
            sdict.Add("3", "ȷ������");
            sdict.Add("4", "���ɴ���");
            uta = new uctlTimeAxis(sdict,1);
            uta.lc = new ToolFunction.uctlTimeAxis.TimeAxisClick(SayHello);
            CommonFunction.AddForm3(splitContainer4.Panel2, uta);
        }

        public void SayHello()
        {
            MessageBox.Show("Hello");
        } 

        /// <summary>
        /// �����������
        /// </summary>
        public void LoadBaseSetting() {
            te_basepath.Text = Settings.Default.BasePath;
            txt_ds.Text = Settings.Default.DataSource;
            txt_ui.Text = Settings.Default.UserID;
            txt_pd.Text = Settings.Default.Password;
            cmb_DBType.Text = Settings.Default.DBType;
        }

        /// <summary>
        /// ����ģ���û��ؼ�
        /// </summary>
        public void LoadTempletPanel()
        {
            uctlTemplet ut = new uctlTemplet();
            PublicProperty.UcTemplet = ut;
            CommonFunction.AddForm3(pl_container, ut);
        }

        ///// <summary>
        ///// ����ģ������
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
        /// ��������Դ
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
                CommonFunction.WriteLog(exp, "û�л�ȡ������Դ");
            }

        }

        

        /// <summary>
        /// �������treeview������Ϣ
        /// </summary>
        public  void LoadTempletList()
        {
            LoadTempletList(tv_templet);
            tv_temp = tv_templet;
            //TreeNode root = new TreeNode("ģ���б�");//�����ڵ�
            //root.Name = "ģ���б�";//Ϊ�ڵ�ȡ������,����������Ǹ��ڵ�
            //tv_templet.Nodes.Add(root);//���ڵ���ӵ�treeView1��
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
            TreeNode root = new TreeNode("ģ���б�");//�����ڵ�
            root.Name = "ģ���б�";//Ϊ�ڵ�ȡ������,����������Ǹ��ڵ�
            tv.Nodes.Add(root);//���ڵ���ӵ�treeView1��
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

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ubc = new uctlBaseConfig();
            CommonFunction.ShowForm(ubc, Color.White, Color.LightSlateGray, 4);
            //CommonFunction.AddTabControl(tc_contener, "��������", ubc);
        }

        private void ģ��༭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uctlTemplet ubc = new uctlTemplet();
            CommonFunction.AddForm3(pl_container, ubc);
            //CommonFunction.AddTabControl(tc_contener, "ģ��༭", ubc);
        }

        private void ����Դѡ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucc = new uctlCreateCode();
            CommonFunction.AddForm3(pl_container, ucc);
            //CommonFunction.AddTabControl(tc_contener, "����Դѡ��", ucc);
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //��һ��txt�ĵ�չʾ˵��
            try
            {
                Process Pnotepad = new Process();
                Pnotepad.StartInfo.FileName = PublicProperty.ReadMe;
                Pnotepad.Start();
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "Ӧ����û�ҵ��ļ�readme");
            }
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest f = new frmTest();
            f.ShowDialog();
        }

        /// <summary>
        /// ��ʼ������tabҳ
        /// </summary>
        public void InitAllTabs()
        {
            //uctlBaseConfig ubc = new uctlBaseConfig();
            //CommonFunction.AddTabControl(tc_contener, "��������", ubc);

            //uctlTemplet utc = new uctlTemplet();
            //CommonFunction.AddTabControl(tc_contener, "ģ��༭", utc);

            //ucc = new uctlCreateCode();
            //CommonFunction.AddTabControl(tc_contener, "����Դѡ��", ucc);

            //uctlAbout ua = new uctlAbout();
            //CommonFunction.AddTabControl(tc_contener, "�������", ua);
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
                uctlMessageBox.Show("����ɹ���");
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "�������ñ������");
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
        ///// ��ȡ��ѡ������Դ
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
        ///// ���ݱ������ر�ṹ
        ///// </summary>
        ///// <param name="p_strTableName">����</param>
        ///// <returns>��</returns>
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
        /// �������ļ�
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
                CommonFunction.WriteLog(exp,"�������ļ�����");
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
                    uctlMessageBox.Show("δѡ������Դ");
                    return;
                }
                if (PublicProperty.SuccessFlag)
                {
                    uctlMessageBox.Show("���ɳɹ���");
                }
                else
                {
                    uctlMessageBox.Show("����ʧ�ܣ�����鿴������־��");
                }
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "���ɴ���ʱ����");
            }
        }

        /// <summary>
        /// �������ת���ɱ�
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
                    uctlMessageBox.Show("δ��д�ļ�����");
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
        /// ִ��sql
        /// ���
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


        #region ����SQL

        /// <summary>
        /// д��־��Ϣ
        /// </summary>
        /// <param name="p_expEx">�쳣��Ϣ</param>
        /// <param name="sql">���Ի���Ϣ</param>
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
        /// ɾ��ָ���ڵ�
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
        /// û����־�ļ�������־�ļ�
        /// </summary>
        /// <param name="doc">xml�ļ�</param>
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
        /// �ɹ�����Log�ļ�����ӽڵ���־��Ϣ
        /// </summary>
        /// <param name="doc">�����xml�ļ�</param>
        /// <param name="ex">�쳣��Ϣ</param>
        /// <param name="mess">������Ի���Ϣ</param>
        private static void AppendLogMessage(XmlDocument doc, string name, string sql)
        {
            try
            {
                //������־�ļ�
                doc.Load(Application.StartupPath + @"\" + Application.ProductName + "SQL.xml");
                //�����ڵ�(һ��)
                XmlNode root = doc.SelectSingleNode("Root");
                //�����ڵ㣨������
                XmlNode node = doc.CreateElement("sql");
                node.Attributes.Append(doc.CreateAttribute("name")).Value=name;
                node.Attributes.Append(doc.CreateAttribute("value")).Value = sql;
                ////�����ڵ㣨������
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
        /// ����sql
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