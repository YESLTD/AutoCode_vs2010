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

namespace AutoCode
{
    
    public partial class frmMain : Form
    {
        uctlBaseConfig ubc = null;
        uctlCreateCode ucc = null;
        TreeNode tv = null;
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
            LoadTempletPanel();
            LoadBaseSetting();
            LoadTables();
            LoadTempletList();
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

        /// <summary>
        /// 载入模板属性
        /// </summary>
        public void LoadTempletDetail()
        {
            dgv_function.DataSource = null;
        //PublicProperty.methodNameSet.Add
            DataTable _dtFunction = new DataTable();
            _dtFunction.Columns.Add("FUNCTION");
            foreach (var item in PublicProperty.methodNameSet)
            {
                _dtFunction.Rows.Add(item);
            }
            dgv_function.DataSource = _dtFunction.DefaultView;
        }

        /// <summary>
        /// 载入数据源
        /// </summary>
        public void LoadTables()
        {
            try
            {
                PublicProperty.DBType = Settings.Default.DBType;
                PublicProperty.Source = GetAllColumn.getTable();
                gc_talbelist.DataSource = PublicProperty.Source.DefaultView;
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "没有获取到数据源");
            }

        }

        /// <summary>
        /// 载入左侧treeview数据信息
        /// </summary>
        public void LoadTempletList()
        {
            TreeNode root = new TreeNode("模板列表");//创建节点
            root.Name = "模板列表";//为节点取个名字,这儿创建的是根节点
            tv_templet.Nodes.Add(root);//将节点添加到treeView1上
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
            LoadTempletDetail();
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

        private void gc_talbelist_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                if (dr["CHK"].ToString() == "0")
                {
                    dr["CHK"] = "1";
                    //dgv_ColumnSet.DataSource = GetColumnSet(dr["TABLE_NAME"].ToString()).DefaultView;
                }
                else
                {
                    dr["CHK"] = "0";
                }
            }
        }

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
            foreach (string s in PublicProperty.getSelectTable())
            {
                CreateCode cc = new CreateCode();
                //cc.LoadProperity();
                DataTable _dtTable = PublicProperty.GetTable(s);
                cc.OutPutCode(_dtTable);
            }
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
                if (tv != null)
                {
                    string newName = tv.Text;
                    FileInfo f = new FileInfo(PublicProperty.TempletPath + "\\" + tv.Name);
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
            tv = e.Node;
            tv.BeginEdit();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToolFunction.uctlTimeAxis uc = new uctlTimeAxis();
            uc.Refresh();
            CommonFunction.ShowForm(uc,Color.Green,Color.White,4);
            uc.SetStep("4");
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            ToolFunction.uctlTimeAxis.sdict.Add("1", "读取配置");
            ToolFunction.uctlTimeAxis.sdict.Add("2", "选择模板");
            ToolFunction.uctlTimeAxis.sdict.Add("3", "确认数据");
            ToolFunction.uctlTimeAxis.sdict.Add("4", "生成代码");
            ToolFunction.uctlTimeAxis.InitTimeAxis(e.Graphics);
        }

    }
}