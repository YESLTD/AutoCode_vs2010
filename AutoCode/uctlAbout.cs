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
        /// 装载说明信息
        /// </summary>
        public void LoadAboutMessage()
        {
            try
            {
                string _strAboutPath = Application.StartupPath + @"\" + "About.txt";
                StreamReader sr = new StreamReader(_strAboutPath, Encoding.Default);
                string _strLine,_strMesage="";
                //装载配置信息，函数名函数体
                while ((_strLine = sr.ReadLine()) != null)
                {
                    _strMesage += _strLine + "\n";
                }
                richTextBox1.Text = _strMesage;
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "没有About.txt！");
            }

        }
    }
}
