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
            this.richTextBox1.Text = " 1.�������ݶ�ȡ�ı���Ϣת��Ϊ����PO��DAO��\n 2.���������ü� \n 3.�����������ռ� \n 4.���������ݿ����Ӵ� 5.������PO��DAO������Ŀ¼ \n 6.Ŀǰֻ֧��Oracle";
        }
    }
}
