using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToolFunction;
using TestAutoCode;

namespace AutoCode
{
    public partial class frmMain : Form
    {
        string stritem = "";
        uctlBaseConfig ubc = null;
        uctlCreateCode ucc = null;
        public frmMain()
        {
            InitializeComponent();
            CommonFunction.SetConnectionString();
            //InitAllTabs();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            stritem = "uctlBaseConfig";
            ubc = new uctlBaseConfig();
            CommonFunction.AddForm3(pl_container, ubc);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            stritem = "uctlCreateCode";
            ucc = new uctlCreateCode();
            CommonFunction.AddForm3(pl_container, ucc);
        }


        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctlAbout ua = new uctlAbout();
            CommonFunction.AddForm3(pl_container,ua);
        }
        
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
             if (stritem =="uctlBaseConfig"&&(e.Control&&e.KeyCode==Keys.S))
            {
                ubc.savefile();
                uctlMessageBox.Show("保存成功！");
            }
            if (e.KeyCode ==Keys.Escape)
            {
                pl_container.Controls.Clear();
            }
            
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmTest f = new frmTest();
            f.Show();
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            stritem = "uctlTemplet";
            uctlTemplet ut = new uctlTemplet();
            CommonFunction.AddForm3(pl_container, ut);
        }

        private void 连接配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stritem = "uctlBaseConfig";
            ubc = new uctlBaseConfig();
            CommonFunction.ShowForm(ubc, Color.White, Color.LightSlateGray, 4);
            //CommonFunction.AddTabControl(tc_contener, "连接配置", ubc);
        }

        private void 模板编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stritem = "uctlTemplet";
            uctlTemplet ubc = new uctlTemplet();
            CommonFunction.AddForm3(pl_container, ubc);
            //CommonFunction.AddTabControl(tc_contener, "模板编辑", ubc);
        }

        private void 数据源选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stritem = "uctlCreateCode";
            ucc = new uctlCreateCode();
            CommonFunction.AddForm3(pl_container, ucc);
            //CommonFunction.AddTabControl(tc_contener, "数据源选择", ucc);
        }

        private void 软件介绍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uctlAbout ua = new uctlAbout();
            CommonFunction.AddForm3(pl_container, ua);
            //CommonFunction.AddTabControl(tc_contener, "软件介绍", ua);
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
            uctlBaseConfig ubc = new uctlBaseConfig();
            CommonFunction.AddTabControl(tc_contener, "连接配置", ubc);

            uctlTemplet utc = new uctlTemplet();
            CommonFunction.AddTabControl(tc_contener, "模板编辑", utc);

            ucc = new uctlCreateCode();
            CommonFunction.AddTabControl(tc_contener, "数据源选择", ucc);

            uctlAbout ua = new uctlAbout();
            CommonFunction.AddTabControl(tc_contener, "软件介绍", ua);
        }
    }
}