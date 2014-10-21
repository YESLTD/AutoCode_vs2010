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
        FileStream fs = null;
        StreamWriter sw = null;
        //获取表的列
        public List<string[]> columnproperity = null;

        #endregion

        #region IBaseCreateCode 成员
        /// <summary>
        /// 创建model层
        /// </summary>
        public void CreateModel()
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
                sw = new StreamWriter(fs, Encoding.Default);
                sw.AutoFlush = true;
                sw.Write(Settings.Default.UsingDLL + "\n" +
                "namespace " + Settings.Default.NameSpace + "\n{\n" +
                t1 + "public class " + columnproperity[0][0].ToString() + "\n" +
                t1 + "{\n" +
                t2 + "public " + columnproperity[0][0].ToString() + "(){}\n" +
                t2 + "#region Properity \n");
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
                sw.Write(
                t2 + "#endregion\n" +
                t2 + "#region Properity get set method \n");
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
                sw.Write(
                t2 + "#endregion \n" +
                t1 + "}\n" +
                "}");
            }
            catch (Exception e)
            {
                CommonFunction.WriteErrorLog(e.ToString());
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 生成insertsql
        /// </summary>
        /// <returns>返回插入行的主键</returns>
        public string CreateInsertSql()
        {
            string id = "";
            string sql = "insert into " + columnproperity[0][0].ToString() + " ({0}) values ({1})";
            string columns = "";
            string values = "";
            foreach (string[] s in columnproperity)
            {
                columns += s[1] + ",";
                if (s[2].ToString().StartsWith("VARCHAR"))
                {
                    values += "'@" + s[1] + "',";
                }
                else if (s[2].ToString().StartsWith("DATE"))
                {
                    values += "@" + s[1] + ",";
                }
            }
            columns = columns.Trim(',');
            values = values.Trim(',');
            sql = string.Format(sql, columns, values);
            return sql;
        }

        /// <summary>
        ///创建删除记录的sql 
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>删除sql</returns>
        public string CreateDelSql()
        {
            string sql = "delete " + columnproperity[0][0].ToString() + " where id = '@id'";
            return sql;
        }

        /// <summary>
        /// 创建修改记录的sql
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>更新sql</returns>
        public string CreateUpdateSql()
        {
            string sql = "update " + columnproperity[0][0].ToString() + "set {0}";
            string updatevalue = "";
            foreach (string[] s in columnproperity)
            {
                if (s[2].ToString().StartsWith("VARCHAR"))
                {
                    updatevalue += s[1] + "'@" + s[1] + "',";
                }
                else
                {
                    updatevalue += s[1] + "@" + s[1] + ",";
                }
            }
            updatevalue = updatevalue.Trim(',');
            return string.Format(sql,updatevalue);
        }

        /// <summary>
        /// 创建查询记录sql
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>查询sql</returns>
        public string CreateQuerySql()
        {
            string sql = "select * from " + columnproperity[0][0].ToString() + "where id = '@id'";
            return sql;
        }

        /// <summary>
        /// 创建dao 层
        /// </summary>
        public void CreateDao()
        {
            string id = "";
           
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
                sw = new StreamWriter(fs, Encoding.Default);
                sw.AutoFlush = true;
                sw.Write(Settings.Default.UsingDLL + "\n" +
                "namespace " + Settings.Default.NameSpace + "\n{\n" +
                t1 + "public class " + "Dao" + columnproperity[0][0].ToString() + "\n" +
                t1 + "{\n" +
                t2 + "private " +columnproperity[0][0].ToString() +" " +columnproperity[0][0].ToString().ToLower() +" = new "+columnproperity[0][0].ToString()+"();\n"+
                t2 + "public " + "Dao" + columnproperity[0][0].ToString() + "(){}\n" +
                //插入函数
                t2 + "/// <summary> \n" +
                t2 + "///  数据插入\n" +
                t2 + "/// <summary> \n" +
                t2 + "/// <param name=\"dict\">载有对象值的字典</param> \n" +
                t2 + "/// <returns>主键ID</returns> \n" +
                t2 + "public string InsertEntity(Dictionary<string, string> dict)\n" +
                t2 + "{\n" +
                t3 + "string sql = \"" + CreateInsertSql() + "\";\n" +
                t3 + "string id = Guid.NewGuid().ToString();\n" +
                t3 + "try\n" +
                t3 + "{\n" +
                t3 + t1 + "CommonFunction.ExecutenonQuery(sql,dict);\n" +
                t3 + "}\n" +
                t3 + "catch(Exception e)\n" +
                t3 + "{\n" +
                t3 + t1 + "CommonFunction.WriteErrorLog(e.ToString());\n" +
                t3 + "}\n" +
                t3 + "return id;\n" +
                t2 + "}\n\n" +
                //删除函数
                t2 + "/// <summary> \n" +
                t2 + "///  数据删除\n" +
                t2 + "/// <summary> \n" +
                t2 + "/// <param name=\"dict\">主键id</param> \n" +
                t2 + "/// <returns>主键ID</returns> \n" +
                t2 + "public string DeleteEntity(Dictionary<string, string> dict)\n" +
                t2 + "{\n" +
                t3 + "string sql = \"" +CreateDelSql() + "\";\n" +
                t3 + "string id = Guid.NewGuid().ToString();\n" +
                t3 + "try\n" +
                t3 + "{\n" +
                t3 + t1 + "CommonFunction.ExecutenonQuery(sql,dict);\n" +
                t3 + "}\n" +
                t3 + "catch(Exception e)\n" +
                t3 + "{\n" +
                t3 + t1 + "CommonFunction.WriteErrorLog(e.ToString());\n" +
                t3 + "}\n" +
                t3 + "return id;\n" +
                t2 + "}\n\n" +
                //修改函数
                t2 + "/// <summary> \n" +
                t2 + "///  数据修改\n" +
                t2 + "/// <summary> \n" +
                t2 + "/// <param name=\"dict\">主键id</param> \n" +
                t2 + "/// <returns>主键ID</returns> \n" +
                t2 + "public string UpdateEntity(Dictionary<string, string> dict)\n" +
                t2 + "{\n" +
                t3 + "string sql = \"" + CreateUpdateSql() + "\";\n" +
                t3 + "string id = Guid.NewGuid().ToString();\n" +
                t3 + "try\n" +
                t3 + "{\n" +
                t3 + t1 + "CommonFunction.ExecutenonQuery(sql,dict);\n" +
                t3 + "}\n" +
                t3 + "catch(Exception e)\n" +
                t3 + "{\n" +
                t3 + t1 + "CommonFunction.WriteErrorLog(e.ToString());\n" +
                t3 + "}\n" +
                t3 + "return id;\n" +
                t2 + "}\n\n" +
                //查询函数
                t2 + "/// <summary> \n" +
                t2 + "///  数据查询\n" +
                t2 + "/// <summary> \n" +
                t2 + "/// <param name=\"dict\">主键id</param> \n" +
                t2 + "/// <returns>主键ID</returns> \n" +
                t2 + "public string QueryEntity(Dictionary<string, string> dict)\n" +
                t2 + "{\n" +
                t3 + "string sql = \"" + CreateQuerySql() + "\";\n" +
                t3 + "string id = Guid.NewGuid().ToString();\n" +
                t3 + "try\n" +
                t3 + "{\n" +
                t3 + t1 + "CommonFunction.ExecutenonQuery(sql,dict);\n" +
                t3 + "}\n" +
                t3 + "catch(Exception e)\n" +
                t3 + "{\n" +
                t3 + t1 + "CommonFunction.WriteErrorLog(e.ToString());\n" +
                t3 + "}\n" +
                t3 + "return id;\n" +
                t2 + "}\n\n" +

                t1 + "}\n" +
                "}");
            }
            catch (Exception e)
            {
                CommonFunction.WriteErrorLog(e.ToString());
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
