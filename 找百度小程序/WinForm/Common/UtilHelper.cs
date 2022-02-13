using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;


namespace Ku.Common
{
    public static class UtilHelper
    {

        #region ##########常规转换操作###########

        #region 字符串转换
        /// <summary>
        /// 弃用方法，请用新方法 o.ToStr()
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [Obsolete]//标记该方法已弃用
        public static string ConvertToString(object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != string.Empty)
                {
                    return o.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 新版对象转字符串
        /// </summary> 
        /// <returns></returns>
        public static string ToStr(this object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != string.Empty)
                {
                    return o.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        public static string ToStr(this Stream stream)
        {
            try
            {
                if (null == stream)
                {
                    return string.Empty;
                }
                //stream.Position = 0;
                //byte[] byts = new byte[stream.Length];
                //stream.Read(byts, 0, byts.Length);
                //string req = System.Text.Encoding.Default.GetString(byts);
                //return req;
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 转换保留2位小数 的金额
        public static string ToMoney(this object o, int len = 2)
        {
            var ning = "";
            for (int i = 0; i < len; i++)
            {
                ning += "0";
            }

            var d = o.ToDouble();
            var m = d.ToString("0." + ning);
            if (m.EndsWith("." + ning))
            {
                m = m.Replace("." + ning, "");
            }

            return m.ToDouble().ToStr();

        }
        #endregion

        #region 转换成 Int64
        /// <summary>
        /// 弃用方法，请用新方法 o.ToInt64();
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [Obsolete]//标记该方法已弃用
        public static long ConvertToInt64(object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    long num = Convert.ToInt64(o);
                    return num;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// 对象转64位数字
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static long ToInt64(this object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    long num = Convert.ToInt64(o);
                    return num;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
        /// <summary>
        /// 对象转double
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static double ToDouble(this object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    double num = Convert.ToDouble(o);
                    return num;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
        #endregion

        #region 转换成   Int32
        /// <summary>
        /// 弃用方法，请用新方法 o.ToInt32();
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns></returns>
        [Obsolete]//标记该方法已弃用
        public static int ConvertToInt32(object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    int num = Convert.ToInt32(o);
                    return num;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
        /// <summary>
        /// 对象转32位数字
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns></returns>
        public static int ToInt32(this object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    int num = Convert.ToInt32(o);
                    return num;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
        #endregion

        #region 日期格式转换
        /// <summary>
        /// 转换成日期格式--转换失败返回当前默认时间
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    return Convert.ToDateTime(o);
                }
                else
                {
                    return default(DateTime);
                }
            }
            catch
            {
                return default(DateTime);
            }
        }
        /// <summary>
        /// 转换成日期格式--转换失败 返回null
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime2(this object o)
        {
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    return Convert.ToDateTime(o);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 转换成 日期字符串
        /// </summary>
        /// <param name="o"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToDateTimeStr(this object o, string format = "yyyy-MM-dd HH:mm")
        {
            string str = "";
            try
            {

                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    if (o.ToStr() == "0001/1/1 0:00:00")
                    {
                        return str;
                    }
                    else
                    {
                        return Convert.ToDateTime(o).ToString(format, System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    }
                }
                else
                {
                    return str;
                }
            }
            catch
            {
                return str;
            }
        }

        public static string ToDateStr(this object o)
        {
            string str = "";
            try
            {
                if (o != DBNull.Value && o != null && o.ToString() != String.Empty)
                {
                    if (o.ToStr() == "0001/1/1 0:00:00")
                    {
                        return str;
                    }
                    else
                    {
                        return Convert.ToDateTime(o).ToString("yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    }
                }
                else
                {
                    return str;
                }
            }
            catch
            {
                return str;
            }
        }
        #endregion

        #region 去掉空白 Trim 
        /// <summary>
        /// 转换 字符串 然后 Trim
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToTrim(this object o)
        {
            string str = ToStr(o);
            return str.Trim();
        }

        #endregion

        #region 转首字母大写
        /// <summary>
        /// 转首次字母小写
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToLowerFirst(this object o)
        {
            string s = o.ToStr();
            if (IsNull(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToLower(a[0]);
            return new string(a);
        }

        #endregion

        #endregion

        #region 分割 和组合 字符串
        /// <summary>
        /// 二次封装 Split 分割 字符串 
        ///  返回值不包括含有空字符串的数组元素
        /// </summary>
        /// <param name="separator">分隔符，用什么来分割 可以是 , ★★ 等等</param>
        /// <returns></returns>
        public static List<string> ToSplit(this string strValue, string separator)
        {
            return strValue.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        /// <summary>
        /// 二次封装  string.Join 
        /// 构造集合的成员，其中在每个成员之间使用指定的分隔符。
        /// </summary>
        /// <param name="separator">分隔符</param>
        /// <param name="objList">集合列表</param>
        /// <returns></returns>
        public static string ToJoin<T>(this List<T> objList, string separator)
        {
            return string.Join(separator, objList);
        }

        /// <summary>
        /// 截取子字符串从指定长度
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubString(object obj, int length)
        {
            string inputstr = obj.ToStr();
            if (IsNull(inputstr))
            {
                return "";
            }

            int strLen = inputstr.Length;
            if (length > strLen)
            {
                return inputstr;
            }
            else
            {
                return inputstr.Substring(0, length);
            }



        }
        /// <summary>
        /// 截取返回字节长度
        /// 一个字母 一个字节
        /// 一个汉字 2个字节
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="byteLength">指定字节长度</param>
        /// <returns></returns>
        public static string SubString2(object obj, int byteLength)
        {
            string inputstr = obj.ToStr();

            if (IsNull(inputstr))
            {
                return "";
            }

            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(inputstr);
            int n = 0;  //  表示当前的字节数
            int i = 0;  //  要截取的字节数
            for (; i < bytes.GetLength(0) && n < byteLength; i++)
            {
                //  偶数位置，如0、2、4等，为UCS2编码中两个字节的第一个字节
                if (i % 2 == 0)
                {
                    n++;      //  在UCS2第一个字节时n加1
                }
                else
                {
                    //  当UCS2编码的第二个字节大于0时，该UCS2字符为汉字，一个汉字算两个字节
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }
            }
            //  如果i为奇数时，处理成偶数
            if (i % 2 == 1)
            {
                //  该UCS2字符是汉字时，去掉这个截一半的汉字
                if (bytes[i] > 0)
                    i = i - 1;
                //  该UCS2字符是字母或数字，则保留该字符
                else
                    i = i + 1;
            }
            return System.Text.Encoding.Unicode.GetString(bytes, 0, i);



        }

        #endregion

        #region 通用获取处理
        public static T GetValue<T>(this Dictionary<string, object> dicList, string key)
        {
            object obj = null;
            if (dicList.ContainsKey(key))
            {

                dicList.TryGetValue(key, out obj);
                if (obj != null && obj != DBNull.Value)
                {
                    return (T)Convert.ChangeType(obj, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
            else { return default(T); }
        }
        #endregion

        #region JSON操作
        public static string ToJson(this object objData)
        {
            try
            {
                var iso = new IsoDateTimeConverter();
                iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                return JsonConvert.SerializeObject(objData, iso);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static T DeserializeObject<T>(this string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
        #endregion

        
        #region  实体转换
        /// <summary>
        /// DataTable 转换成实体 List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertDataTableToEntityList<T>(DataTable dt)
        {
            var list = new List<T>();
            Type t = typeof(T);
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());

            foreach (DataRow item in dt.Rows)
            {
                T s = System.Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name.ToLower() == dt.Columns[i].ColumnName.ToLower());
                    if (info != null)
                    {
                        if (!Convert.IsDBNull(item[i]))
                        {
                            try
                            {
                                switch (info.PropertyType.Name.ToLower())
                                {
                                    case "datetime":
                                        info.SetValue(s, Convert.ToDateTime(item[i]), null);
                                        break;

                                    case "decimal":
                                        info.SetValue(s, Convert.ToDecimal(item[i]), null);
                                        break;

                                    case "string":
                                        info.SetValue(s, item[i].ToString(), null);
                                        break;

                                    case "int32":
                                        info.SetValue(s, ToInt32(item[i]), null);
                                        break;

                                    case "int64":
                                        info.SetValue(s, item[i].ToInt64(), null);
                                        break;
                                    case "double":
                                        info.SetValue(s, item[i].ToDouble(), null);
                                        break;
                                    default:
                                        info.SetValue(s, item[i], null);
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                               
                            }
                        }

                    }
                }
                list.Add(s);
            }
            return list;
        }

        public static T ConvertDataTableToEntity<T>(DataTable dt)
        {

            var list = new List<T>();
            Type t = typeof(T);
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            T s = System.Activator.CreateInstance<T>();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow item = dt.Rows[0];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name.ToLower() == dt.Columns[i].ColumnName.ToLower());
                    if (info != null)
                    {
                        if (!Convert.IsDBNull(item[i]))
                        {
                            try
                            {
                                switch (info.PropertyType.Name.ToLower())
                                {
                                    case "datetime":
                                        info.SetValue(s, Convert.ToDateTime(item[i]), null);
                                        break;

                                    case "decimal":
                                        info.SetValue(s, Convert.ToDecimal(item[i]), null);
                                        break;

                                    case "string":
                                        info.SetValue(s, item[i].ToString(), null);
                                        break;

                                    case "int32":
                                        info.SetValue(s, ToInt32(item[i]), null);
                                        break;

                                    case "int64":
                                        info.SetValue(s, item[i].ToInt64(), null);
                                        break;
                                    case "double":
                                        info.SetValue(s, item[i].ToDouble(), null);
                                        break;
                                    default:
                                        info.SetValue(s, item[i], null);
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                
                            }
                        }
                    }
                }
            }
            return s;

        }

        public static DataTable ListToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new
            DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }
        #endregion

        #region 检测判断
        /// <summary>
        /// 检测 是否为空
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsNull(object o)
        {
            try
            {
                if (o == null)
                {
                    return true;
                }
                Type type = o.GetType();
                if (type.Name == "DateTime")
                {
                    DateTime str = o.ToDateTime();
                    if (str == DateTime.MinValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    string str = ToStr(o).ToTrim();
                    if (str == "null")
                    {
                        return true;
                    }
                    else
                    {
                        return string.IsNullOrEmpty(str);
                    }
                }
            }
            catch (Exception)
            {

                //返回 为空
                return true;
            }
        }
        public static bool IsNull(DateTime o)
        {
            try
            {
                if (o == DateTime.MinValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return true;
            }
        }

         
        #region 检测是否存在重复项
        /// <summary>
        /// 检测是否存在重复项--2个空也算重复
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsRepeat(params string[] values)
        {
            var count = values.ToList().Distinct().Count();

            if (count == values.Length)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 检测是否存在重复项--2个空也算重复
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public static bool IsRepeat(List<string> strList)
        {
            var count = strList.ToList().Distinct().Count();

            if (count == strList.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #endregion

        #region 数据库中与C#中的数据类型对照
        /// <summary>
        /// 数据库中与C#中的数据类型对照
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToCSharpType(this string type)
        {
            string reval = string.Empty;
            switch (type.ToLower())
            {
                case "int":
                    reval = "int";
                    break;
                case "text":
                    reval = "string";
                    break;
                case "bigint":
                    reval = "long";
                    break;
                case "binary":
                    reval = "System.Byte[]";
                    break;
                case "bit":
                    reval = "Boolean";
                    break;
                case "char":
                    reval = "string";
                    break;
                case "datetime":
                    reval = "DateTime";
                    break;
                case "decimal":
                    reval = "decimal";
                    break;
                case "float":
                    reval = "double";
                    break;
                case "image":
                    reval = "System.Byte[]";
                    break;
                case "money":
                    reval = "System.Decimal";
                    break;
                case "nchar":
                case "ntext":
                case "nvarchar":
                    reval = "string";
                    break;
                case "numeric":
                    reval = "decimal";
                    break;
                case "real":
                    reval = "Single";
                    break;
                case "smalldatetime":
                    reval = "DateTime";
                    break;
                case "smallint":
                    reval = "Int16";
                    break;
                case "smallmoney":
                    reval = "System.Decimal";
                    break;
                case "timestamp":
                    reval = "System.DateTime";
                    break;
                case "tinyint":
                    reval = "System.Byte";
                    break;
                case "uniqueidentifier":
                    reval = "System.Guid";
                    break;
                case "varbinary":
                    reval = "System.Byte[]";
                    break;
                case "varchar":
                    reval = "String";
                    break;
                case "Variant":
                    reval = "Object";
                    break;
                default:
                    reval = "String";
                    break;
            }
            return reval;
        }

        #endregion

        #region 列表分组转换
        public static Dictionary<int, List<T>> ConvertToGroupList<T>(List<T> gridList, int groupNum)
        {
            Dictionary<int, List<T>> dicList = new Dictionary<int, List<T>>();
            if (gridList != null && gridList.Count > 0)
            {
                var gridcount = gridList.Count;
                var grcount = 0;
                var groupIndex = 1;
                var numIndex = 0;
                List<T> tempList = new List<T>();
                foreach (var item in gridList)
                {
                    numIndex++;
                    grcount++;
                    tempList.Add(item);
                    if (numIndex == groupNum)
                    {
                        dicList.Add(groupIndex, tempList);
                        tempList = new List<T>();
                        groupIndex++;
                        numIndex = 0;
                    }
                    else if (grcount == gridcount)
                    {
                        dicList.Add(groupIndex, tempList);
                        tempList = new List<T>();
                    }
                }
            }
            return dicList;
        }
        #endregion

     

    }
}

