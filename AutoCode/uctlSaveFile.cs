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

namespace AutoCode
{
    public partial class uctlSaveFile : UserControl
    {
        public uctlSaveFile()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path =PublicProperty.TempletPath + txt_filename.Text + ltype.Text;
                if (File.Exists(path))
                {
                    File.Delete(path);
                    File.AppendAllText(path, PublicProperty.TempletString.Replace("\n", "\r\n"), Encoding.Default);
                    this.FindForm().Close();
                    uctlMessageBox.Show("保存成功！");
                }
                else
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Templet\\");
                    File.AppendAllText(path, PublicProperty.TempletString.Replace("\n", "\r\n"), Encoding.Default);
                    this.FindForm().Close();
                    uctlMessageBox.Show("保存成功！");

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "保存文件出错！");
            }
        }
    }
}
