using System;

namespace cqgis.extensions
{
    /// <summary>
    /// cqgis: GUID 的辅助方法集合
    /// </summary>
    public static class GuidExtension
    {
        /// <summary>
        ///  cqgis: 转换为16位长的字符串,注意： 这个字符串有随机性，同一个字符串在不同的时候得到的结果不一样
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string Tostring16(this Guid guid)
        {
            long i = 1;
            foreach (byte b in guid.ToByteArray())
            {
                i *= ((int)b + 1);
            }
            var str = $"{i - DateTime.Now.Ticks:x}";

            while (str.Length < 16)
            {
                str += '0';
            }

            return str;
        }

        /// <summary>
        ///  cqgis: 转换为19位长的long类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static long Tolong19(this Guid id)
        {
            var buffer = id.ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}