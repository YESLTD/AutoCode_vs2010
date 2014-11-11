using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ToolFunction
{
    public partial class uctlComboxcs : UserControl
    {
        public DataTable source = new DataTable();
        public uctlComboxcs()
        {
            InitializeComponent();
            comboBox1.DataSource = source;
            comboBox1.DisplayMember = "itemtext";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = CommonFunction.returnSelectItemValue("number",comboBox1.Text.ToString());
        }

    }
}
