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
            te_basepath.Text = Settings.Default.BasePath;
            txt_ds.Text = Settings.Default.DataSource;
            txt_ui.Text = Settings.Default.UserID;
            txt_pd.Text = Settings.Default.Password;
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
                uctlMessageBox.Show("保存成功！");
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "基础配置保存错误！");
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            savefile();
        }


        private void uctlBaseConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control&&e.KeyCode==Keys.S)
            {
                savefile();
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

        private void button1_Click(object sender, EventArgs e)
        {
            fbd_path.ShowDialog();
            te_basepath.Text = fbd_path.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            savefile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

    }
}
