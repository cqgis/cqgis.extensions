using System;
using System.Linq;
using System.Reflection;
using cqgis.extensions.data;

namespace cqgis.extensions
{
    public static class EnumExtension
    {
        #region 对枚举类型的操作
        /// <summary>
        /// cqgis:返回指定属性类的实例
        /// </summary>
        /// <param name="enumSubitem">枚举类子项</param>
        /// <param name="attributeType">属性类型</param>
        /// <returns></returns>
        private static object GetAttributeClass(this Enum enumSubitem, Type attributeType)
        {
            FieldInfo fieldinfo = enumSubitem.GetType().GetRuntimeField(enumSubitem.ToString());
            var objs = fieldinfo.GetCustomAttributes(attributeType, false);
            if (!objs.Any())
                return null;
            return objs.First();
        }

        ///<summary>
        ///cqgis: 返回指定的属性
        ///</summary>
        ///<param name="enumSubitem">属性项</param>
        ///<typeparam name="T">属性类型</typeparam>
        ///<returns>返回得到的项</returns>
        public static T GetAttribute<T>(this Enum enumSubitem) where T : Attribute
        {
            object obj = enumSubitem.GetAttributeClass(typeof(T));
            return (T)obj;
        }

        /// <summary>
        /// cqgis:返回枚举的描述信息，如果没有描述，返回枚举本身字符串
        /// </summary>
        /// <param name="enumSubitem"></param>
        /// <returns></returns>
        public static string ToChinese(this Enum enumSubitem)
        {
            try
            {
                var chinese = enumSubitem.GetAttribute<ChineseAttribute>();
                if (chinese == null)
                    return enumSubitem.ToString();
                return chinese.ChineseName;
            }
            catch (Exception)
            {
                return enumSubitem.ToString();
            }
        }
        /// <summary>
        /// cqgis: 从描述信息转换成枚举类型
        /// </summary>
        /// <typeparam name="T">要转换成的枚举类型</typeparam>
        /// <param name="desciptionstring">描述信息</param>
        /// <param name="enumsubitem">转换后的结果</param>
        /// <returns>转换是否成功</returns>
        public static bool TryFromChineseToEnum<T>(this string desciptionstring, out T enumsubitem)
        {
            try
            {
                Array values = Enum.GetValues(typeof(T));
                foreach (var value in from object value in values
                                      let enums = (Enum)Enum.Parse(typeof(T), value.ToString())
                                      where enums.ToChinese().ToUpper() == desciptionstring.ToUpper()
                                      select value)
                {
                    enumsubitem = (T)Enum.Parse(typeof(T), value.ToString());
                    return true;
                }
                enumsubitem = default(T);
                return false;
            }
            catch
            {
                enumsubitem = default(T);
                return false;
            }
        }
        /// <summary>
        /// cqgis:  尝试把字符串转换成枚举类型
        /// </summary>
        /// <typeparam name="T">要转换成的枚举类型</typeparam>
        /// <param name="value">字符串值</param>
        /// <param name="enumsubitem">返回的枚举 </param>
        /// <returns>返回是否成功</returns>
        public static bool TryParseToEnum<T>(this string value, out T enumsubitem)
        {
            try
            {
                enumsubitem = (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                enumsubitem = default(T);
                return false;
            }
            return true;
        }
        #endregion
    }
}