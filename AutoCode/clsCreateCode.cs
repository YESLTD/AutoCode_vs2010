using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ToolFunction;
namespace AutoCode
{
    public class clsCreateCode : IBaseCreateCode
    {
        #region 加载配置信息
        string basepath = Settings.Default.BasePath;
        string modelpath = Settings.Default.ModelClassPath;
        string daopath = Settings.Default.DaoClassPath;
        string servicepath = Settings.Default.ServiceClassPath;
        //获取表的列
        public List<string[]> columnproperity = null;

        #endregion
        #region IBaseCreateCode 成员

        public void createModel()
        {

            FileStream fs = null;
            StreamWriter sw = null;
            string t1 = "\t";
            string t2 = "\t\t";
            string t3 = "\t\t\t";
            try
            {
                string path = basepath + "\\" + modelpath + "\\";
                string filename = "";
                if (columnproperity.Count == 0)
                {
                    return;
                }
                filename = columnproperity[0][0].ToString() + ".cs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(path + filename))
                {
                    File.Delete(path + filename);
                }
                fs = new FileStream(path + filename, FileMode.Create, FileAccess.ReadWrite);
                sw = new StreamWriter(fs);
                sw.AutoFlush = true;
                sw.Write(Settings.Default.UsingDLL + "\n");
                sw.Write("namespace " + Settings.Default.NameSpace + "{\n");
                sw.Write(t1 + "public class " + columnproperity[0][0].ToString() + "\n    {\n");
                sw.Write(t2 + "public " + columnproperity[0][0].ToString() + "(){}\n");
                sw.Write(t2 + "#region Properity \n");
                foreach (string[] s in columnproperity)
                {
                    string property = "private ";
                    string name = s[1].ToString();
                    string type = "";
                    if (s[2].ToString() == "NUMBER")
                    {
                        type = "long ";
                    }
                    else if (s[2].ToString().StartsWith("VARCHAR"))
                    {
                        type = "string ";
                    }
                    else if (s[2].ToString().StartsWith("DATE"))
                    {
                        type = "DateTime ";
                    }

                    string shuxing =
                        t2 + property + type + name + ";\n";
                    sw.Write(shuxing);

                }
                sw.Write(t2 + "#endregion\n");
                sw.Write(t2 + "#region Properity get set method \n");
                foreach (string[] s in columnproperity)
                {
                    string property = "private ";
                    string name = s[1].ToString();
                    string type = "";
                    if (s[2].ToString() == "NUMBER")
                    {
                        type = "long ";
                    }
                    else if (s[2].ToString().StartsWith("VARCHAR"))
                    {
                        type = "string ";
                    }
                    else if (s[2].ToString().StartsWith("DATE"))
                    {
                        type = "DateTime ";
                    }
                    string getMethod =
                           t2 + "public " + type + "get" + name + "()\n" +
                           t2 + "{\n" +
                           t3 + "return " + name + ";\n" +
                           t2 + "}\n";
                    sw.Write(getMethod);
                    string setMethod =
                        t2 + "public void set" + name + "(" + type + " value)\n" +
                        t2 + "{\n" +
                        t3 + name + "= value;\n" +
                        t2 + "}\n";
                    sw.Write(setMethod);
                }
                sw.Write(t2 + "#endregion \n");
                sw.Write(t1 + "}\n");
                sw.Write("}");
            }
            catch (Exception e)
            {
                CommonFunction.WriteErrotLog(e.ToString());
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public void createDao()
        {
            FileStream fs = null;
            StreamWriter sw = null;
            string t1 = "\t";
            string t2 = "\t\t";
            string t3 = "\t\t\t";
            try
            {
                string path = basepath + "\\" + daopath + "\\";
                string filename = "";
                if (columnproperity.Count == 0)
                {
                    return;
                }
                filename = columnproperity[0][0].ToString() + "Dao.cs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(path + filename))
                {
                    File.Delete(path + filename);
                }
                fs = new FileStream(path + filename, FileMode.Create, FileAccess.ReadWrite);
                sw = new StreamWriter(fs);
                sw.AutoFlush = true;
                sw.Write(Settings.Default.UsingDLL + "\n");
                sw.Write("namespace " + Settings.Default.NameSpace + "{\n");
                sw.Write(t1 + "public interface " + "Dao" + columnproperity[0][0].ToString() + "\n    {\n");
                sw.Write(t2 + "public " + "Dao" + columnproperity[0][0].ToString() + "Dao" + "(){}\n");
                //string sqlInsert = "insert into " + columnproperity[0][0].ToString() + "vlaues(" + ")";
                //string sqlUpdate = "update " + columnproperity[0][0].ToString() + "";
                //string sqlDeletesql = "";
                //string sqlQuery = "";
                foreach (string[] s in columnproperity)
                {

                }
                sw.Write(t1 + "}\n");
                sw.Write("}");
            }
            catch (Exception e)
            {
                CommonFunction.WriteErrotLog(e.ToString());
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        void IBaseCreateCode.createService()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
