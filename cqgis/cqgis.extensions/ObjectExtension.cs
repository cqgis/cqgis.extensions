using System;

namespace cqgis.extensions
{
    public static class ObjectExtension
    {
        #region 对泛型的处理
        /// <summary>
        /// cqgis: 当传入的对象值为NULL时，返回传入的默认值，否则返回该对象的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object"></param>
        /// <param name="defaultValue">为NULL时，返回的默认值</param>
        /// <returns>返回值</returns>
        public static T GetDefaultValueWhileNull<T>(this T @object, T defaultValue)
        {
            if (Object.Equals(@object, null))
                return defaultValue;
            return @object;
        }
        ///<summary>
        /// cqgis: 当传入的参数是Null时，执行传入的方法
        ///</summary>
        ///<param name="object"></param>
        ///<param name="action"></param>
        ///<typeparam name="T"></typeparam>
        ///<returns></returns>
        public static T WhileNullDoAction<T>(this T @object, Action action) where T : class
        {
            if (@object == null)
                action();
            return @object;
        }
        #endregion
    }
}