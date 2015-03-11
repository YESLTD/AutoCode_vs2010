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
          
        }
        public void savefile()
        {
            Settings.Default.BasePath = te_basepath.Text.Trim();
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
                Settings.Default.BasePath = te_basepath.Text.Trim();
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

    }
}
