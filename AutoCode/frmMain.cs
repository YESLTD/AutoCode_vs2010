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
            CommonFunction.STRCONN = Settings.Default.StrConn;
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
                uctlMessageBox.Show("±£´æ³É¹¦£¡");
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
    }
}