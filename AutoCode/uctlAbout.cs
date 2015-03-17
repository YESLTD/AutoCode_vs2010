using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ToolFunction;

namespace AutoCode
{
    public partial class uctlAbout : UserControl
    {
        public uctlAbout()
        {
            InitializeComponent();
            LoadAboutMessage();
        }

        /// <summary>
        /// װ��˵����Ϣ
        /// </summary>
        public void LoadAboutMessage()
        {
            try
            {
                string _strAboutPath = Application.StartupPath + @"\" + "About.txt";
                StreamReader sr = new StreamReader(_strAboutPath, Encoding.Default);
                string _strLine,_strMesage="";
                //װ��������Ϣ��������������
                while ((_strLine = sr.ReadLine()) != null)
                {
                    _strMesage += _strLine + "\n";
                }
                richTextBox1.Text = _strMesage;
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "û��About.txt��");
            }

        }
    }
}
