using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToolFunction;

namespace TestAutoCode
{
    public partial class frmTest : Form,IBase
    {
        public frmTest()
        {
            
            InitializeComponent();
           
        }



        public void InitControls()
        {
            //uctlComboxcs1.source = CommonFunction.getComboxDatasource("number");
            //uctlComboxcs3 = CommonFunction.getComboxDatasource("number");
            //comboBox1.DataSource = CommonFunction.getComboxDatasource("number");
            //comboBox1.DisplayMember = "itemtext";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox1.Text = CommonFunction.returnSelectItemValue("number",comboBox1.Text.ToString());
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            InitControls();
        }
    }
}
