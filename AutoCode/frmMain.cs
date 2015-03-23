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
        private DataTable source = new DataTable();
        uctlBaseConfig ubc = null;
        uctlCreateCode ucc = null;
        public frmMain()
        {
            InitializeComponent();
            //��ʼ�������ַ���
            CommonFunction.SetConnectionString(Settings.Default.DataSource, Settings.Default.UserID, Settings.Default.Password);
            InitControls();
        }

        /// <summary>
        /// ��ʼ���ؼ�
        /// </summary>
        public void InitControls()
        {
            uctlTemplet ut = new uctlTemplet();
            PublicProperty.UcTemplet = ut;
            CommonFunction.AddForm3(pl_container, ut);

            te_basepath.Text = Settings.Default.BasePath;
            txt_ds.Text = Settings.Default.DataSource;
            txt_ui.Text = Settings.Default.UserID;
            txt_pd.Text = Settings.Default.Password;

            //uctlBaseConfig ubc = new uctlBaseConfig();
            //tabPage2.Controls.Add(ubc);
            source = GetAllColumn.getTable();
            gc_talbelist.DataSource = source.DefaultView;

            LoadTreeViewProperty();
        }

        /// <summary>
        /// �������treeview������Ϣ
        /// </summary>
        public void LoadTreeViewProperty()
        {
            TreeNode root = new TreeNode("ģ���б�");//�����ڵ�
            root.Name = "ģ���б�";//Ϊ�ڵ�ȡ������,����������Ǹ��ڵ�
            tv_templet.Nodes.Add(root);//���ڵ���ӵ�treeView1��
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
                Settings.Default.Save();
                CommonFunction.SetConnectionString(txt_ds.Text, txt_ui.Text, txt_pd.Text);
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

        /// <summary>
        /// ��ȡ��ѡ������Դ
        /// </summary>
        /// <returns></returns>
        public List<string> getSelectTable()
        {
            List<string> tablelist = new List<string>();
            foreach (DataRow dr in source.Rows)
            {
                if (dr["CHK"].ToString() == "1")
                {
                    tablelist.Add(dr["TABLE_NAME"].ToString());
                }
            }
            return tablelist;
        }

        /// <summary>
        /// ���ݱ������ر�ṹ
        /// </summary>
        /// <param name="p_strTableName">����</param>
        /// <returns>��</returns>
        public DataTable GetTable(string p_strTableName)
        {
            string _strSQL = "select * from " + p_strTableName + " where 1=0";
            return CommonFunction.OraExecuteBySQL(_strSQL, new Dictionary<string, string>(), p_strTableName);
        }

        private void button3_Click(object sender, EventArgs e)
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