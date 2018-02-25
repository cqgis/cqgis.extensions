using System;
using System.Collections.Generic;
using System.Text;

namespace cqgis.extensions
{
    /// <summary>
    /// cqgis: 值的扩展方法
    /// </summary>
    public static class ValuesExtension
    {
        #region 对值类型的处理
        /// <summary>
        /// cqgis:  把一个数的值控制在一定的范围内
        /// </summary>
        /// <param name="num">要控制的数值 </param>
        /// <param name="min">最小值，不能小于这个值</param>
        /// <param name="max">最大值，不能大于这个值</param>
        /// <returns></returns>
        public static int ClipIn(this int num, int min, int max)
        {
            var maxvalue = Math.Max(min, max);
            var minvalue = Math.Min(min, max);
            return Math.Max(Math.Min(maxvalue, num), minvalue);
        }
        /// <summary>
        /// cqgis:  把一个数的值控制在一定的范围内
        /// </summary>
        /// <param name="num">要控制的数值 </param>
        /// <param name="min">最小值，不能小于这个值</param>
        /// <param name="max">最大值，不能大于这个值</param>
        /// <returns></returns>
        public static double ClipIn(this double num, double min, double max)
        {
            var maxvalue = Math.Max(min, max);
            var minvalue = Math.Min(min, max);
            return Math.Max(Math.Min(maxvalue, num), minvalue);
        }
        /// <summary>
        /// cqgis:  把一个数的值控制在一定的范围内
        /// </summary>
        /// <param name="num">要控制的数值 </param>
        /// <param name="min">最小值，不能小于这个值</param>
        /// <param name="max">最大值，不能大于这个值</param>
        /// <returns></returns>
        public static float ClipIn(this float num, float min, float max)
        {
            var maxvalue = Math.Max(min, max);
            var minvalue = Math.Min(min, max);
            return Math.Max(Math.Min(maxvalue, num), minvalue);
        }
        /// <summary>
        ///  cqgis: 把一个数的值控制在一定的范围内
        /// </summary>
        /// <param name="num">要控制的数值 </param>
        /// <param name="min">最小值，不能小于这个值</param>
        /// <param name="max">最大值，不能大于这个值</param>
        /// <returns></returns>
        public static byte ClipIn(this byte num, byte min, byte max)
        {
            var maxvalue = Math.Max(min, max);
            var minvalue = Math.Min(min, max);
            return Math.Max(Math.Min(maxvalue, num), minvalue);
        }
        /// <summary>
        ///  cqgis: 把一个数的值控制在一定的范围内
        /// </summary>
        /// <param name="num">要控制的数值 </param>
        /// <param name="min">最小值，不能小于这个值</param>
        /// <param name="max">最大值，不能大于这个值</param>
        /// <returns></returns>
        public static decimal ClipIn(this decimal num, decimal min, decimal max)
        {
            var maxvalue = Math.Max(min, max);
            var minvalue = Math.Min(min, max);
            return Math.Max(Math.Min(maxvalue, num), minvalue);
        }
        #endregion

        /// <summary>
        /// cqgis:  转成16进制,不足8位补0
        /// </summary>
        /// <param name="int"></param>
        /// <returns></returns>
        public static string to16(this int @int)
        {
            string value = Convert.ToString(@int, 16);
            while (value.Length < 8)
            {
                value = "0" + value;
            }
            return value;
        }
    }
}
