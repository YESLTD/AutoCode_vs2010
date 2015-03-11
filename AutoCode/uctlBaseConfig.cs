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
    public partial class uctlBaseConfig : UserControl
    {
        public uctlBaseConfig()
        {
            InitializeComponent();
            initControls();
        }

        private void btn_savebasepath_Click(object sender, EventArgs e)
        {
            fbd_path.ShowDialog();
            te_basepath.Text = fbd_path.SelectedPath;
           
        }
        /// <summary>
        /// 初始化控件数据
        /// </summary>
        public void initControls()
        {
            //te_strconn.Text = Settings.Default.StrConn;
            te_basepath.Text = Settings.Default.BasePath;
            te_modelpath.Text = Settings.Default.ModelClassPath;
            te_daopath.Text = Settings.Default.DaoClassPath;
            te_servicepath.Text = Settings.Default.ServiceClassPath;
            te_namespace.Text = Settings.Default.NameSpace;
            rtb_dll.Text = Settings.Default.UsingDLL;
        }
        public void savefile()
        {
            //Settings.Default.StrConn = te_strconn.Text.Trim();
            Settings.Default.BasePath = te_basepath.Text.Trim();
            Settings.Default.ModelClassPath = te_modelpath.Text.Trim();
            Settings.Default.DaoClassPath = te_daopath.Text.Trim();
            Settings.Default.ServiceClassPath = te_servicepath.Text.Trim();
            Settings.Default.NameSpace = te_namespace.Text.Trim();
            Settings.Default.UsingDLL = rtb_dll.Text.ToString();
            Settings.Default.Save();
            CommonFunction.SetConnectionString();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            savefile();
        }


        private void uctlBaseConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control&&e.KeyCode==Keys.S)
            {
                //Settings.Default.StrConn = te_strconn.Text.Trim();
                Settings.Default.BasePath = te_basepath.Text.Trim();
                Settings.Default.ModelClassPath = te_modelpath.Text.Trim();
                Settings.Default.DaoClassPath = te_daopath.Text.Trim();
                Settings.Default.ServiceClassPath = te_servicepath.Text.Trim();
                Settings.Default.NameSpace = te_namespace.Text.Trim();
                Settings.Default.UsingDLL = rtb_dll.Text.ToString();
                Settings.Default.Save();
                CommonFunction.SetConnectionString();
            }
            if (e.KeyCode==Keys.Escape)
            {
                this.FindForm().Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

    }
}
