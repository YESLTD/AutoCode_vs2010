using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AutoCode
{
    public partial class uctlAbout : UserControl
    {
        public uctlAbout()
        {
            InitializeComponent();
            this.richTextBox1.Text = " 1.将从数据读取的表信息转换为代码PO和DAO层\n 2.可配置引用集 \n 3.可配置命名空间 \n 4.可配置数据库连接串 5.可配置PO和DAO的生成目录 \n 6.目前只支持Oracle";
        }
    }
}
