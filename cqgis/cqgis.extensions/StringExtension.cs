using cqgis.extensions.data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace cqgis.extensions
{
    /// <summary>
    ///  cqgis: 字符串的辅助类
    /// </summary>
    public static class StringExtension
    {
        #region 字符串 String
        #region 字符串功能
        #region 判断字符串
        /// <summary>
        ///  cqgis: 判断字符串是否为Null或空字符串,或是只有空白字符串组成
        /// </summary>
        /// <param name="string">判断的字符串</param>
        /// <returns>布尔型</returns>
        /// <example>"Hello World".IsNullorEmpty</example>
        public static bool IsNullorEmpty(this string @string)
        {
            return string.IsNullOrWhiteSpace(@string);
        }

        #endregion
        #region 处理字符串
        /// <summary>
        ///  cqgis: 在字符串尾部加上特定的字符串，如果已存在，则不添加
        /// </summary>
        /// <param name="string">原字符串</param>
        /// <param name="suffix">要在字符串后面加的字符串</param>
        /// <returns>添加后的字符串</returns>
        public static string LastWithString(this string @string, string suffix)
        {
            if (@string.IsNullorEmpty())
                return suffix;
            int defaultStringLenght = suffix.Length;
            if (@string.Length >= defaultStringLenght &&
                @string.Substring(@string.Length - defaultStringLenght, defaultStringLenght) == suffix)
                return @string;
            return @string + suffix;
        }
        /// <summary>
        ///  cqgis: 在字符串开头加上特定的字符串，如果已存在，则不添加
        /// </summary>
        /// <param name="string">原字符串</param>
        /// <param name="prefix">要在字符串前面加的字符串</param>
        /// <returns>添加后的字符串</returns>
        public static string StartWithString(this string @string, string prefix)
        {
            if (@string.IsNullorEmpty())
                return prefix;
            int defaultStringLenght = prefix.Length;
            if (@string.Length >= defaultStringLenght && @string.Substring(0, defaultStringLenght) == prefix)
                return @string;
            return prefix + @string;
        }
        #endregion
        #endregion
        #region 转换功能
        #region 转换成Int


        /// <summary>
        ///  cqgis: 把字符串转换成Int
        /// </summary>
        /// <param name="string">字符串</param>
        /// <returns>返回转换后的Int型,如果转换失败，返回 int.MinValue</returns>
        public static int ToInt(this string @string)
        {
            return @string.ToInt(int.MinValue);
        }
        /// <summary>
        ///  cqgis: 把字符串转换成Int；如果转换失败，返回设置的默认值
        /// </summary>
        /// <param name="string">需要转换的字符串</param>
        /// <param name="defaultInt">默认的int值</param>
        /// <returns></returns>
        public static int ToInt(this string @string, int defaultInt)
        {
            if (int.TryParse(@string, out var i))
                return i;
            return defaultInt;
        }


        /// <summary>
        ///  cqgis: 转换为可空的int
        /// </summary>
        /// <param name="string"></param>
        /// <param name="defaultInt">如果转换失败，返回的默认值 ，默认为Null</param>
        /// <returns></returns>
        public static int? ToNullableInt(this string @string, int? defaultInt = null)
        {
            return int.TryParse(@string, out var i) ?
                i : defaultInt;
        }

        #endregion
        #region 转换成Double
        /// <summary>
        ///  cqgis: 把字符串转换成double
        /// </summary>
        /// <param name="string">字符串</param>
        /// <returns>返回转换后的Int型,如果转换失败，返回负无穷(double.NaN)</returns>
        public static double ToDouble(this string @string)
        {
            return @string.ToDouble(double.NaN);
        }
        /// <summary>
        ///  cqgis: 把字符串转换成double；如果转换失败，返回设置的默认值
        /// </summary>
        /// <param name="string">需要转换的字符串</param>
        /// <param name="defaultInt">默认的double值</param>
        /// <returns></returns>
        public static double ToDouble(this string @string, double defaultInt)
        {
            if (double.TryParse(@string, out double i))
                return i;
            return defaultInt;
        }

        /// <summary>
        ///  cqgis: 把字符串转换成double；如果转换失败，返回设置的默认值
        /// </summary>
        /// <param name="string">需要转换的字符串</param>
        /// <param name="defaultvalue"></param>
        /// <returns></returns>
        public static double? ToNullableDouble(this string @string, double? defaultvalue = null)
        {
            if (double.TryParse(@string, out double i))
                return i;
            return defaultvalue;
        }



        #endregion
        #region 转换成float

        /// <summary>
        ///  cqgis: 把字符串转换成float
        /// </summary>
        /// <param name="string">要转换的字符串</param>
        /// <param name="defaultFloat">转换不成功，需要返回的默认值</param>
        /// <returns>转换后的结果，如果不成功，返回传入的默认值</returns>
        public static float? ToNullableFloat(this string @string, float? defaultFloat = null)
        {
            if (float.TryParse(@string, out float outFloat))
                return outFloat;
            return defaultFloat;
        }


        /// <summary>
        ///  cqgis: 把字符串转换成float
        /// </summary>
        /// <param name="string">要转换的字符串</param>
        /// <param name="defaultFloat">转换不成功，需要返回的默认值</param>
        /// <returns>转换后的结果，如果不成功，返回传入的默认值</returns>
        public static float ToFloat(this string @string, float defaultFloat)
        {
            if (float.TryParse(@string, out float outFloat))
                return outFloat;
            return defaultFloat;
        }


        /// <summary>
        ///  cqgis: 把字符串转换成float型，转换不成功，返回Float.MinValue
        /// </summary>
        /// <param name="string">要转换的字符串</param>
        /// <returns>转换后的结果,转换不成功，返回负无穷(float.NaN)</returns>
        public static float ToFloat(this string @string)
        {
            return ToFloat(@string, float.NaN);
        }
        #endregion
        #region 转换成时间

        /// <summary>
        ///  cqgis: 把字符串转换成DateTime
        /// </summary>
        /// <param name="string">要转换的字符串</param>
        /// <param name="defaultTime">转换不成功，需要返回的默认值</param>
        /// <returns>转换后的结果，如果不成功，返回传入的默认值</returns>
        public static DateTime? ToNullableDateTime(this string @string, DateTime? defaultTime = null)
        {
            if (DateTime.TryParse(@string, out DateTime outDateTime))
                return outDateTime;
            return defaultTime;
        }


        /// <summary>
        ///  cqgis: 把字符串转换成DateTime
        /// </summary>
        /// <param name="string">要转换的字符串</param>
        /// <param name="defaultTime">转换不成功，需要返回的默认值</param>
        /// <returns>转换后的结果，如果不成功，返回传入的默认值</returns>
        public static DateTime ToDateTime(this string @string, DateTime defaultTime)
        {
            if (DateTime.TryParse(@string, out DateTime outDateTime))
                return outDateTime;
            return defaultTime;
        }
        /// <summary>
        ///  cqgis: 把字符串转换成float型，转换不成功，返回DateTime.MinValue
        /// </summary>
        /// <param name="string">要转换的字符串</param>
        /// <returns>转换后的结果,转换不成功，返DateTime.MinValue</returns>
        public static DateTime ToDateTime(this string @string)
        {
            return ToDateTime(@string, DateTime.MinValue);
        }
        #endregion
        #region 转换成枚举
        /// <summary>
        ///  cqgis: 转换成枚举类型
        /// </summary>
        /// <typeparam name="T">转换成的枚举类型</typeparam>
        /// <param name="string">字符串</param> 
        /// <returns>如果转换成功，返回转换后的值，否则返回默认值</returns>
        public static T ToEnum<T>(this string @string)
        {
            return ToEnum(@string, default(T));
        }
        /// <summary>
        ///  cqgis: 转换成枚举类型
        /// </summary>
        /// <typeparam name="T">转换成的枚举类型</typeparam>
        /// <param name="string">字符串</param>
        /// <param name="defaultEnum">转换失败返回的默认值</param>
        /// <returns>如果转换成功，返回转换后的值，否则返回默认值</returns>
        public static T ToEnum<T>(this string @string, T defaultEnum)
        {
            if (@string.TryParseToEnum<T>(out var outEnum))
                return outEnum;
            return defaultEnum;
        }
        /// <summary>
        ///  cqgis: 根据描述信息转换成枚举类型
        /// </summary>
        /// <typeparam name="T">要转换成的枚举类型</typeparam>
        /// <param name="string">字符串</param> 
        /// <returns>如果转换成功，返回转换后的值，否则返回默认值 </returns>
        public static T ToEnumFromChinese<T>(this string @string)
        {
            return ToEnumFromChinese(@string, default(T));
        }
        /// <summary>
        ///  cqgis: 根据描述信息转换成枚举类型
        /// </summary>
        /// <typeparam name="T">要转换成的枚举类型</typeparam>
        /// <param name="string">字符串</param>
        /// <param name="defaultEnum">默认值</param>
        /// <returns>如果转换成功，返回转换后的值，否则返回默认值 </returns>
        public static T ToEnumFromChinese<T>(this string @string, T defaultEnum)
        {
            if (@string.TryFromChineseToEnum<T>(out var outenum))
                return outenum;
            return defaultEnum;
        }
        #endregion
        #region 转换成bool

        /// <summary>
        ///  cqgis: 把字符串转成bool
        /// </summary>
        /// <param name="string">要转换的字符串</param>
        /// <param name="defaultvalue">转换不成功，需要返回的默认值</param>
        /// <returns>转换后的结果，如果不成功，返回传入的默认值</returns>
        public static bool? ToNullableBool(this string @string, bool? defaultvalue = null)
        {
            if (@string.IsNullorEmpty())
                return defaultvalue;
            return bool.TryParse(@string, out bool b) ? b : defaultvalue;
        }


        /// <summary>
        ///  cqgis: 把字符串转成bool
        /// </summary>
        /// <param name="string">要转换的字符串</param>
        /// <param name="defaultvalue">转换不成功，需要返回的默认值</param>
        /// <returns>转换后的结果，如果不成功，返回传入的默认值</returns>
        public static bool ToBool(this string @string, bool defaultvalue = false)
        {
            if (@string.IsNullorEmpty())
                return defaultvalue;
            if (bool.TryParse(@string, out bool b))
                return b;
            return defaultvalue;
        }
        #endregion
        #endregion
        #region 连接功能
        ///<summary>
        ///  cqgis: 把一个字符串列表用符号串起来，
        /// 如{"1","2","3"}用";"串起来为:"1;2;3"
        /// 返加的字符串末尾不包括符号
        ///</summary>
        ///<param name="strings">字符串列表</param>
        ///<param name="symbol">串的符号</param>
        ///<returns>连接后的字符串</returns>
        public static string JoinWith(this IEnumerable<string> strings, string symbol)
        {

            if (strings == null)
                return string.Empty;

            var strs = strings.ToArray();
            if (strs.Length == 0) return string.Empty;

            if (strs.Length == 1)
                return strs[0];
            string outstring = "";
            foreach (var item in strs)
            {
                if (outstring.IsNullorEmpty())
                    outstring = item;
                else
                    outstring += symbol + item;
            }
            return outstring;
        }
        /// <summary>
        ///  cqgis: 把一个其它类型的列表转成字符串
        /// </summary>
        /// <param name="lists"></param>
        /// <returns>转换后的list</returns>
        public static IList<string> ToStringList(this IEnumerable lists)
        {
            return (from object item in lists select item.ToString()).ToList();
        }
        #endregion
        #endregion

        /// <summary>
        ///  cqgis: 如果 value 和equalvalue相等就执行action
        /// </summary>
        /// <param name="value"></param>
        /// <param name="equalvalue"></param>
        /// <param name="action"></param>
        public static string Cast(this string value, string equalvalue, Action action)
        {
            if (string.Equals(value, equalvalue))
                action.Invoke();
            return value;
        }

        /// <summary>
        /// cqgis:  检测是否为空，如果是，抛出异常
        /// </summary>
        /// <param name="value"></param>
        /// <param name="argumentName">参数名字，在字符串为空时，返回的异常信息中，参数的名字</param>
        /// <param name="throwFriendlyException">是否返回<see cref="FriendlyException"></see>/></param>
        public static void CheckIsNullOrEmpty(this string value, string argumentName, bool throwFriendlyException = false)
        {
            if (value.IsNullorEmpty())
            {
                if (throwFriendlyException)
                {
                    throw new FriendlyException(argumentName);
                }

                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        ///  cqgis: 检测是否为空，如果是，抛出异常
        /// </summary>
        /// <param name="value"></param>
        /// <param name="argumentName">参数名字，在为NULL时，返回异常信息中的参数名字</param>
        /// <param name="throwFriendlyException">是否返回<see cref="FriendlyException"></see>/></param>
        public static void CheckIsNull(this object value, string argumentName, bool throwFriendlyException = false)
        {
            if (value == null)
            {
                if (throwFriendlyException)
                {
                    throw new FriendlyException(argumentName);
                }
                throw new ArgumentNullException(argumentName);
            }
        }


        /// <summary>
        ///  cqgis: 是否包含字符串。通过指定的比较方法，默认为忽略大小写
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <param name="value">被包含的字符串</param>
        /// <param name="stringComparison">字符串比较的方法，默认不区分大小写</param>
        /// <returns></returns>
        public static bool ContainsStringValue(this string str, string value, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return str.IndexOf(value, stringComparison) >= 0;
        }
    }
}