using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ToolFunction;
using System.Data;
namespace AutoCode
{
    public class CreateCode : IBaseCreateCode
    {
        #region 加载配置信息
        string basepath = Settings.Default.BasePath;

        public string Basepath
        {
            get { return basepath; }
            set { basepath = value; }
        }

        FileStream fs = null;
        StreamWriter sw = null;
        //获取表的列
        public List<string[]> columnproperity = null;

        #endregion

        /// <summary>
        /// 按照模板生成代码
        /// </summary>
        /// <param name="p_dtTable"></param>
        public void OutPutCode(DataTable p_dtTable)
        {
            StreamReader sr = new StreamReader(PublicProperty.FILEPATH, Encoding.Default);
            string path = basepath + "\\";
            string _strFileName;
            string _strLine;
            _strFileName = GetClassName(p_dtTable) + ".cs";
            fs = new FileStream(path + _strFileName, FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs, Encoding.Default);
            sw.AutoFlush = true;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //if (File.Exists(path + _strFileName))
            //{
            //    File.Delete(path + _strFileName);
            //}
            while ((_strLine = sr.ReadLine()) != null)
            {
                if (_strLine.Contains("<%=GetClassName(SourceTable)%>"))
                {
                    _strLine = _strLine.Replace("<%=GetClassName(SourceTable)%>", GetClassName(p_dtTable));
                    sw.WriteLine(_strLine);
                }
                else if (_strLine.Contains("<%=InitProperty(SourceTable)%>"))
                {
                    string _strTab = _strLine.Replace("<%=InitProperty(SourceTable)%>", "");
                    foreach (DataColumn item in p_dtTable.Columns)
                    {
                        _strLine = _strTab + "private " + GetCSharpVariableType(item) + " " + item.ColumnName.ToLower() + ";";
                        sw.WriteLine(_strLine);
                        _strLine = "\n" + _strTab + "public " + GetCSharpVariableType(item) + " " + GetPropertyName(item.ColumnName);
                        sw.WriteLine(_strLine);
                        _strLine = "\n" + _strTab + "{ ";
                        sw.WriteLine(_strLine);
                        _strLine = "\n" + _strTab + "get { return " + item.ColumnName.ToLower() + ";}";
                        sw.WriteLine(_strLine);
                        _strLine = "\n" + _strTab + "set {" + item.ColumnName.ToLower() + "= value;}";
                        sw.WriteLine(_strLine);
                        _strLine = "\n" + _strTab + "}";
                        sw.WriteLine(_strLine);
                    }
                }
                else
                {
                    sw.WriteLine(_strLine);
                    //sw.WriteLine(_strLine);
                }
                
            }
        }


        #region IBaseCreateCode 成员
        /// <summary>
        /// 创建model层
        /// </summary>
        public void CreateModel()
        {

            //FileStream fs = null;
            //StreamWriter sw = null;
            //string t1 = "\t";
            //string t2 = "\t\t";
            //string t3 = "\t\t\t";
            //try
            //{
            //    string path = basepath + "\\" + modelpath + "\\";
            //    string filename = "";
            //    if (columnproperity.Count == 0)
            //    {
            //        return;
            //    }
            //    filename = columnproperity[0][0].ToString() + ".cs";
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }
            //    if (File.Exists(path + filename))
            //    {
            //        File.Delete(path + filename);
            //    }
            //    fs = new FileStream(path + filename, FileMode.Create, FileAccess.ReadWrite);
            //    sw = new StreamWriter(fs, Encoding.Default);
            //    sw.AutoFlush = true;
            //    sw.Write(Settings.Default.UsingDLL + "\n" +
            //    "namespace " + Settings.Default.NameSpace + "\n{\n" +
            //    t1 + "public class " + columnproperity[0][0].ToString() + "\n" +
            //    t1 + "{\n" +
            //    t2 + "public " + columnproperity[0][0].ToString() + "(){}\n" +
            //    t2 + "#region Properity \n");
            //    foreach (string[] s in columnproperity)
            //    {
            //        string property = "private ";
            //        string name = s[1].ToString();
            //        string type = "";
            //        if (s[2].ToString() == "NUMBER")
            //        {
            //            type = "long ";
            //        }
            //        else if (s[2].ToString().StartsWith("VARCHAR"))
            //        {
            //            type = "string ";
            //        }
            //        else if (s[2].ToString().StartsWith("DATE"))
            //        {
            //            type = "DateTime ";
            //        }

            //        string shuxing =
            //            t2 + property + type + name + ";\n";
            //        sw.Write(shuxing);

            //    }
            //    sw.Write(
            //    t2 + "#endregion\n" +
            //    t2 + "#region Properity get set method \n");
            //    foreach (string[] s in columnproperity)
            //    {
            //        string property = "private ";
            //        string name = s[1].ToString();
            //        string type = "";
            //        if (s[2].ToString() == "NUMBER")
            //        {
            //            type = "long ";
            //        }
            //        else if (s[2].ToString().StartsWith("VARCHAR"))
            //        {
            //            type = "string ";
            //        }
            //        else if (s[2].ToString().StartsWith("DATE"))
            //        {
            //            type = "DateTime ";
            //        }
            //        string getMethod =
            //               t2 + "public " + type + "get" + name + "()\n" +
            //               t2 + "{\n" +
            //               t3 + "return " + name + ";\n" +
            //               t2 + "}\n";
            //        sw.Write(getMethod);
            //        string setMethod =
            //            t2 + "public void set" + name + "(" + type + " value)\n" +
            //            t2 + "{\n" +
            //            t3 + name + "= value;\n" +
            //            t2 + "}\n";
            //        sw.Write(setMethod);
            //    }
            //    sw.Write(
            //    t2 + "#endregion \n" +
            //    t1 + "}\n" +
            //    "}");
            //}
            //catch (Exception e)
            //{
            //    CommonFunction.WriteErrorLog(e.ToString());
            //}
            //finally
            //{
            //    if (fs != null)
            //    {
            //        fs.Close();
            //    }
            //}
        }

        /// <summary>
        /// 生成insertsql
        /// </summary>
        /// <returns>返回插入行的主键</returns>
        public string CreateInsertSql()
        {
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
            return string.Format(sql, updatevalue);
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
            //string id = "";

            //string t1 = "\t";
            //string t2 = "\t\t";
            //string t3 = "\t\t\t";
            //try
            //{
            //    string path = basepath + "\\" + daopath + "\\";
            //    string filename = "";
            //    if (columnproperity.Count == 0)
            //    {
            //        return;
            //    }
            //    filename = columnproperity[0][0].ToString() + "Dao.cs";
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }
            //    if (File.Exists(path + filename))
            //    {
            //        File.Delete(path + filename);
            //    }
            //    fs = new FileStream(path + filename, FileMode.Create, FileAccess.ReadWrite);
            //    sw = new StreamWriter(fs, Encoding.Default);
            //    sw.AutoFlush = true;
            //    sw.Write(Settings.Default.UsingDLL + "\n" +
            //    "namespace " + Settings.Default.NameSpace + "\n{\n" +
            //    t1 + "public class " + "Dao" + columnproperity[0][0].ToString() + "\n" +
            //    t1 + "{\n" +
            //    t2 + "private " + columnproperity[0][0].ToString() + " " + columnproperity[0][0].ToString().ToLower() + " = new " + columnproperity[0][0].ToString() + "();\n" +
            //    t2 + "public " + "Dao" + columnproperity[0][0].ToString() + "(){}\n" +
            //        //插入函数
            //    t2 + "/// <summary> \n" +
            //    t2 + "///  数据插入\n" +
            //    t2 + "/// <summary> \n" +
            //    t2 + "/// <param name=\"dict\">载有对象值的字典</param> \n" +
            //    t2 + "/// <returns>主键ID</returns> \n" +
            //    t2 + "public string InsertEntity(Dictionary<string, string> dict)\n" +
            //    t2 + "{\n" +
            //    t3 + "string sql = \"" + CreateInsertSql() + "\";\n" +
            //    t3 + "string id = Guid.NewGuid().ToString();\n" +
            //    t3 + "try\n" +
            //    t3 + "{\n" +
            //    t3 + t1 + "CommonFunction.ExecutenonQuery(sql,dict);\n" +
            //    t3 + "}\n" +
            //    t3 + "catch(Exception e)\n" +
            //    t3 + "{\n" +
            //    t3 + t1 + "CommonFunction.WriteErrorLog(e.ToString());\n" +
            //    t3 + "}\n" +
            //    t3 + "return id;\n" +
            //    t2 + "}\n\n" +
            //        //删除函数
            //    t2 + "/// <summary> \n" +
            //    t2 + "///  数据删除\n" +
            //    t2 + "/// <summary> \n" +
            //    t2 + "/// <param name=\"dict\">主键id</param> \n" +
            //    t2 + "/// <returns>主键ID</returns> \n" +
            //    t2 + "public string DeleteEntity(Dictionary<string, string> dict)\n" +
            //    t2 + "{\n" +
            //    t3 + "string sql = \"" + CreateDelSql() + "\";\n" +
            //    t3 + "string id = Guid.NewGuid().ToString();\n" +
            //    t3 + "try\n" +
            //    t3 + "{\n" +
            //    t3 + t1 + "CommonFunction.ExecutenonQuery(sql,dict);\n" +
            //    t3 + "}\n" +
            //    t3 + "catch(Exception e)\n" +
            //    t3 + "{\n" +
            //    t3 + t1 + "CommonFunction.WriteErrorLog(e.ToString());\n" +
            //    t3 + "}\n" +
            //    t3 + "return id;\n" +
            //    t2 + "}\n\n" +
            //        //修改函数
            //    t2 + "/// <summary> \n" +
            //    t2 + "///  数据修改\n" +
            //    t2 + "/// <summary> \n" +
            //    t2 + "/// <param name=\"dict\">主键id</param> \n" +
            //    t2 + "/// <returns>主键ID</returns> \n" +
            //    t2 + "public string UpdateEntity(Dictionary<string, string> dict)\n" +
            //    t2 + "{\n" +
            //    t3 + "string sql = \"" + CreateUpdateSql() + "\";\n" +
            //    t3 + "string id = Guid.NewGuid().ToString();\n" +
            //    t3 + "try\n" +
            //    t3 + "{\n" +
            //    t3 + t1 + "CommonFunction.ExecutenonQuery(sql,dict);\n" +
            //    t3 + "}\n" +
            //    t3 + "catch(Exception e)\n" +
            //    t3 + "{\n" +
            //    t3 + t1 + "CommonFunction.WriteErrorLog(e.ToString());\n" +
            //    t3 + "}\n" +
            //    t3 + "return id;\n" +
            //    t2 + "}\n\n" +
            //        //查询函数
            //    t2 + "/// <summary> \n" +
            //    t2 + "///  数据查询\n" +
            //    t2 + "/// <summary> \n" +
            //    t2 + "/// <param name=\"dict\">主键id</param> \n" +
            //    t2 + "/// <returns>主键ID</returns> \n" +
            //    t2 + "public string QueryEntity(Dictionary<string, string> dict)\n" +
            //    t2 + "{\n" +
            //    t3 + "string sql = \"" + CreateQuerySql() + "\";\n" +
            //    t3 + "string id = Guid.NewGuid().ToString();\n" +
            //    t3 + "try\n" +
            //    t3 + "{\n" +
            //    t3 + t1 + "CommonFunction.ExecutenonQuery(sql,dict);\n" +
            //    t3 + "}\n" +
            //    t3 + "catch(Exception e)\n" +
            //    t3 + "{\n" +
            //    t3 + t1 + "CommonFunction.WriteErrorLog(e.ToString());\n" +
            //    t3 + "}\n" +
            //    t3 + "return id;\n" +
            //    t2 + "}\n\n" +

            //    t1 + "}\n" +
            //    "}");
            //}
            //catch (Exception e)
            //{
            //    CommonFunction.WriteErrorLog(e.ToString());
            //}
            //finally
            //{
            //    if (fs != null)
            //    {
            //        fs.Close();
            //    }
            //}
        }

        void IBaseCreateCode.createService()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region 代码生成配置方法

        public string GetCamelCaseName(string value)
        {
            return value.ToLower();
        }

        public string ConvertFirstCharToUpper(string value)
        {
            return value.Substring(0, 1).ToUpper() + value.Substring(1);
        }

        /// <summary>
        /// 根据表生成类的名字
        /// </summary>
        /// <param name="p_dtTable">表</param>
        /// <returns></returns>
        public string GetClassName(DataTable p_dtTable)
        {
            if (p_dtTable == null)
            {
                return null;
            }
            string _strTemp =  p_dtTable.TableName.Substring(0, 1).ToUpper() + p_dtTable.TableName.Substring(1).ToLower();
            return _strTemp;
        }

        /// <summary>
        /// 根据表名生成类
        /// </summary>
        /// <param name="p_strName"></param>
        /// <returns></returns>
        public string GetPropertyName(string p_strName)
        {

            if (p_strName == null)
            {
                return null;
            }
            if (p_strName.Length == 1)
            {
                return p_strName.ToLower();
            }
            return p_strName.Substring(0, 1).ToUpper() + p_strName.Substring(1).ToLower();
        }

        public string GetLowerCaseName(string value)
        {
            return value.ToLower();
        }

        //public string GetModuleInstanceName(TableSchema table)
        //{
        //    return table.Name.ToLower();
        //}

        /// <summary>
        /// 根据表的列转化代码中的数据类型
        /// </summary>
        /// <param name="p_dcColumn">表列</param>
        /// <returns></returns>
        public string GetCSharpVariableType(DataColumn p_dcColumn)
        {
            if (p_dcColumn.ColumnName.EndsWith("TypeCode")) return p_dcColumn.ColumnName;

            switch (p_dcColumn.DataType.Name.ToString())
            {
                case "AnsiString": return "string";
                case "AnsiStringFixedLength": return "string";
                case "Binary": return "byte[]";
                case "Boolean": return "bool";
                case "Byte": return "byte";
                case "Currency": return "decimal";
                case "Date": return "DateTime";
                case "DateTime": return "DateTime";
                case "Decimal": return "decimal";
                case "Double": return "double";
                case "Guid": return "Guid";
                case "Int16": return "short";
                case "Int32": return "int";
                case "Int64": return "long";
                case "Object": return "object";
                case "SByte": return "sbyte";
                case "Single": return "float";
                case "String": return "string";
                case "StringFixedLength": return "string";
                case "Time": return "TimeSpan";
                case "UInt16": return "ushort";
                case "UInt32": return "uint";
                case "UInt64": return "ulong";
                case "VarNumeric": return "decimal";
                default:
                    {
                        return "__UNKNOWN__";
                    }
            }
        }

        //public string GetPrimaryKeyCSharpType()
        //{
        //    return GetCSharpVariableType(SourceTable.PrimaryKey.MemberColumns[0]);
        //}

        //public string GetValidateInputString()
        //{
        //    DbType dbtype = SourceTable.PrimaryKey.MemberColumns[0].DataType;
        //    string result = String.Empty;
        //    switch (dbtype)
        //    {
        //        case DbType.Byte:
        //        case DbType.Currency:
        //        case DbType.Decimal:
        //        case DbType.Int16:
        //        case DbType.Int32:
        //        case DbType.Int64:
        //            result = "if(" + GetCamelCaseName(SourceTable.PrimaryKey.MemberColumns[0].Name) + "<0)";
        //            break;
        //        case DbType.AnsiStringFixedLength:
        //        case DbType.AnsiString:
        //        case DbType.String:
        //        case DbType.StringFixedLength:
        //        case DbType.Binary:
        //            result = "if(" + GetCamelCaseName(SourceTable.PrimaryKey.MemberColumns[0].Name) + ".Length==0)";
        //            break;
        //            break;
        //        case DbType.Guid:
        //            result = "if(" + GetCamelCaseName(SourceTable.PrimaryKey.MemberColumns[0].Name) + "==null)";
        //            break;
        //        case DbType.DateTime:
        //        case DbType.Date:
        //            result = "if(" + GetCamelCaseName(SourceTable.PrimaryKey.MemberColumns[0].Name) + "==null)";
        //            break;
        //        default:
        //            result = "if(" + GetCamelCaseName(SourceTable.PrimaryKey.MemberColumns[0].Name) + "==null)";
        //            break;
        //    }
        //    return result;
        //}

        //public override string GetFileName()
        //{
        //    return this.GetClassName(this.SourceTable) + ".cs";
        //}

        #endregion
    }
}
