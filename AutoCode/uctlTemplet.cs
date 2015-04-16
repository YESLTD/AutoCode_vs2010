using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ToolFunction;
using System.Diagnostics;

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
            if (""==openTemplet.FileName)
            {
                return;
            }
            else
            {
                PublicProperty.ExportPath = openTemplet.FileName;
            }
            OpenFile(openTemplet.FileName);
            CreateCode cc = new CreateCode();
            cc.LoadTempletProperity();
            //LoadTempletDetail();
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="p_strPath">文件路径</param>
        public  void OpenFile(string p_strPath)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(p_strPath, Encoding.Default);
                String _strLine;
                string _strMess = "";
                while ((_strLine = sr.ReadLine()) != null)
                {
                    _strMess += _strLine + "\n";
                }
                richTextBox1.Text = _strMess;
               
                SetTextColor();
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "这是根节点--！该怎么办呢？");
            }
            finally
            {
                if (sr != null)
                {
                    sr.Dispose();
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = PublicProperty.TempletPath +PublicProperty.TempletName;
                if (File.Exists(path))
                {
                    File.Delete(path);
                    File.AppendAllText(path, richTextBox1.Text.Replace("\n", "\r\n"), Encoding.Default);
                    uctlMessageBox.Show("保存成功！");
                }
                else
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Templet\\");
                    File.AppendAllText(path, richTextBox1.Text.Replace("\n", "\r\n"), Encoding.Default);
                    uctlMessageBox.Show("保存成功！");

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
                nIndex = control.Find(hilightString, nIndex, RichTextBoxFinds.WholeWord);
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
            uctlCreateCode ucc = new uctlCreateCode();
            CommonFunction.ShowForm(ucc, Color.White, Color.LightSlateGray, 4);
            SetTextColor();
        }

        public  void SetTextColor()
        {
            //文本框关键字添加颜色的确很好看，但是效果不好。
            //foreach (string item in PublicProperty.blueKeyWords)
            //{
            //    HilightRichText(richTextBox1, item);
            //}

            //foreach (var item in PublicProperty.redKeyWords)
            //{
            //    HilightRichText(richTextBox1, item, Color.Red);
            //}

            //foreach (var item in PublicProperty.greenKeyWords)
            //{
            //    HilightRichText(richTextBox1, item, Color.Green);
            //}

            //foreach (var item in PublicProperty.magentaKeyWords)
            //{
            //    HilightRichText(richTextBox1, item, Color.Magenta);
            //}
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTextColor();
            frmMain fm = new frmMain();
            fm.LoadTempletList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uctlCreateCode ucc = new uctlCreateCode();
            CommonFunction.ShowForm(ucc, Color.White, Color.LightSlateGray, 4);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTemplet.Filter = "文本文件|*.txt|C#文件|*.cs|所有文件|*.*";
            try
            {
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

        private void readmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开一个txt文档展示说明
            try
            {
                Process Pnotepad = new Process();
                Pnotepad.StartInfo.FileName = PublicProperty.ReadMe;
                Pnotepad.Start();
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "应该是没找到文件readme");
            }
        }

    


        

        private void 生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string s in PublicProperty.getSelectTable())
                {
                    CreateCode cc = new CreateCode();
                    PublicProperty.TableProperty = PublicProperty.GetTable(s);
                    cc.OutPutCode(PublicProperty.TableProperty);
                }
                if (PublicProperty.SuccessFlag)
                {
                    uctlMessageBox.Show("生成成功！");
                }
                else
                {
                    uctlMessageBox.Show("生成失败，详情查看错误日志！");
                }
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "生成代码时出错！");
            }
        }

        private void 校验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _strMethodBody = "";
            foreach (var item in PublicProperty.methodSet.Keys)
            {
                _strMethodBody += PublicProperty.methodSet[item].ToString() + "\n";
            }
            CreateCode cc = new CreateCode();
            cc.ComplieClass(_strMethodBody);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = PublicProperty.TempletPath + PublicProperty.TempletName;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception exp)
            {
                CommonFunction.WriteLog(exp, "无法删除文件");
            }
              
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain fm = new frmMain();
            fm.ProxySetStep();
        }
    }
}
