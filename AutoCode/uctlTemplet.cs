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

        private List<string> blueKeyWords = new List<string> 
            { "using", "namespace", "public", "private", "protected","abstract",
               "partial", "class", "new",  "this",
               "while","foreach", "for",  "if", "else", "switch","case","null","return","try","catch","static",
               "string","int", "float", "double", "char", "bool", "short", "void" };

        private List<string> redKeyWords = new List<string> 
            { "<%=GetClassName(SourceTable)%>","<%=InitProperty(SourceTable)%>" };

        private List<string> greenKeyWords = new List<string> 
            { "//","///", "<summary>", "</summary>","<param name=", "</param>","<returns>", "</returns>" };


        private List<string> magentaKeyWords = new List<string> { "<script>", "</script>" };

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
            PublicProperty.FILEPATH = openTemplet.FileName;
            SetTextColor();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTemplet.Filter = "文本文件|*.txt|C#文件|*.cs|所有文件|*.*"; 
            try
            {
                //if (saveTemplet.ShowDialog() == DialogResult.OK)
                //{

                //    StreamReader sr = new StreamReader(
                //    StreamWriter sw = new StreamWriter(saveTemplet.FileName, false, Encoding.Default);
                //    sw.Write(richTextBox1.Text);
                //    sw.Close();
                //}
                if (saveTemplet.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveTemplet.FileName))
                    {
                        File.Delete(saveTemplet.FileName);
                        File.AppendAllText(saveTemplet.FileName, richTextBox1.Text.Replace("\n", "\r\n"), Encoding.Default);
                    }
                    else
                    {
                        File.AppendAllText(saveTemplet.FileName, richTextBox1.Text.Replace("\n", "\r\n"), Encoding.Default);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "保存文件出错！");
            } 

        }

        /// <summary>
        /// 设置字体颜色蓝色
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="hilightString">关键字</param>
        private void HilightRichText(RichTextBox control, string hilightString)
        {
            HilightRichText(control, hilightString, Color.Blue);
        }

        /// <summary>
        /// 设置字体颜色
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="hilightString">关键字</param>
        /// <param name="color">颜色</param>
        private void HilightRichText(RichTextBox control, string hilightString, Color color)
        {
            int nSelectStart = control.SelectionStart;
            int nSelectLength = control.SelectionLength;
            int nIndex = 0;
            while (nIndex < control.Text.Length)
            {
                nIndex = control.Find(hilightString, nIndex, RichTextBoxFinds.None);
                if (nIndex < 0)
                {
                    break;
                }
                control.Select(nIndex, hilightString.Length);
                control.SelectionColor = color;
                nIndex += hilightString.Length;
            }
            control.Select(nSelectStart, nSelectLength);
        }

        /// <summary>
        /// 设置注释颜色
        /// </summary>
        /// <param name="control"></param>
        private void HilightZSRichText(RichTextBox control)
        {
            int nSelectLength = 0;
            int nIndex = 0;
            int eIndex = 0;
            while (nIndex < control.Text.Length)
            {
                if (nIndex < 0)
                {
                    break;
                }
                nIndex = control.Text.ToString().IndexOf('>', nIndex+1);
                eIndex = control.Text.ToString().IndexOf('<', nIndex+1);
                if (nIndex < 0)
                {
                    break;
                }
                nSelectLength=eIndex-nIndex;
                control.Select(nIndex, nSelectLength);
                control.SelectionColor = Color.Green;
                nIndex += nSelectLength;
                nSelectLength = 0;
            }
            //control.Select(nSelectStart, nSelectLength);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SetTextColor();
        }

        public void SetTextColor()
        {

            foreach (string item in blueKeyWords)
            {
                HilightRichText(richTextBox1, item);
            }

            foreach (var item in redKeyWords)
            {
                HilightRichText(richTextBox1, item, Color.Red);
            }

            foreach (var item in greenKeyWords)
            {
                HilightRichText(richTextBox1, item, Color.Green);
            }

            foreach (var item in magentaKeyWords)
            {
                HilightRichText(richTextBox1, item, Color.Magenta);
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTextColor();
        }
    }
}
