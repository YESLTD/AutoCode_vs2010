using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoCode
{
    public partial class uctlTemplet : UserControl
    {
        public uctlTemplet()
        {
            InitializeComponent();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTemplet.ShowDialog();
            StreamReader sr = new StreamReader(openTemplet.FileName, Encoding.Default);
            String _strLine;
            string _strMess = "";
            while ((_strLine = sr.ReadLine()) != null)
            {
                _strMess += _strLine+"\n";
            }
            richTextBox1.Text = _strMess;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTemplet.ShowDialog();

        }
    }
}
