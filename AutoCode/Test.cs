﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AutoCode
{
    class Test
    {
        #region @GetCamelCaseName
        public static string GetCamelCaseName(string value)
        {
            return value.ToLower();
        }
        #endregion

        #region@ConvertFirstCharToUpper
        public static string ConvertFirstCharToUpper(string value)
        {
            return value.Substring(0, 1).ToUpper() + value.Substring(1);
        }
        #endregion

        #region@InitProperty
        /// <summary>
        /// 生成属性代码
        /// </summary>
        /// <param name="p_dtSource">数据源</param>
        /// <returns>字符串</returns>
        public static string InitProperty(DataTable p_dtSource)
        {
            string _strLine = "";
            foreach (DataColumn item in p_dtSource.Columns)
            {
                _strLine += "\n private " + GetCSharpVariableType(item) + " " + item.ColumnName.ToLower() + ";";
                _strLine += "\n" + "public " + GetCSharpVariableType(item) + " " + GetPropertyName(item.ColumnName);
                _strLine += "\n" + "{ ";
                _strLine += "\n" + "get { return " + item.ColumnName.ToLower() + ";}";
                _strLine += "\n" + "set {" + item.ColumnName.ToLower() + "= value;}";
                _strLine += "\n" + "}";
            }
            return _strLine;
        }
        #endregion

        #region@InitSQL
        /// <summary>
        /// 生成SQL语句
        /// </summary>
        /// <param name="p_dtSource">数据源</param>
        /// <returns>字符串</returns>
        public static string InitSQL(DataTable p_dtSource)
        {
            string _strLine = "update @GetClassName(SourceTable) set ";
            foreach (DataColumn item in p_dtSource.Columns)
            {
                _strLine += item.ColumnName = item.ColumnName;
            }
            _strLine = _strLine.Trim(',');
            return _strLine;
        }
        #endregion

        #region@GetClassName
        /// <summary>
        /// 根据表生成类的名字
        /// </summary>
        /// <param name="p_dtTable">表</param>
        /// <returns></returns>
        public static string @GetClassName(DataTable p_dtTable)
        {
            if (p_dtTable == null)
            {
                return null;
            }
            string _strTemp = p_dtTable.TableName.Substring(0, 1).ToUpper() + p_dtTable.TableName.Substring(1).ToLower();
            return _strTemp;
        }
        #endregion

        #region@GetPropertyName
        /// <summary>
        /// 根据表名生成类
        /// </summary>
        /// <param name="p_strName"></param>
        /// <returns></returns>
        public static string GetPropertyName(string p_strName)
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
        #endregion

        #region@GetLowerCaseName
        public static string GetLowerCaseName(string value)
        {
            return value.ToLower();
        }
        #endregion

        #region@GetCSharpVariableType
        /// <summary>
        /// 根据表的列转化代码中的数据类型
        /// </summary>
        /// <param name="p_dcColumn">表列</param>
        /// <returns></returns>
        public static string GetCSharpVariableType(DataColumn p_dcColumn)
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
        #endregion
    }
}
