using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToolFunction;

namespace AutoCode
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            CommonFunction.STRCONN = Settings.Default.StrConn;
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctlBaseConfig ubc = new uctlBaseConfig();
            CommonFunction.AddForm3(pl_container, ubc);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctlCreateCode ucc = new uctlCreateCode();
            CommonFunction.AddForm3(pl_container, ucc);
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {
            
               
            
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctlAbout ua = new uctlAbout();
            CommonFunction.AddForm3(pl_container,ua);
        }
    }
}