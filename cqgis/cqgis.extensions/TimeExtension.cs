using System;

namespace cqgis.extensions
{
    /// <summary>
    ///  cqgis: 时间日期的扩展方法
    /// </summary>
    public static class TimeExtension
    {
        /// <summary>
        ///  cqgis: 将时间只保留为年月日时分秒，其它小数部分去掉
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime Normal(this DateTime time)
        {
            return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
        }


        /// <summary>
        ///  cqgis: 时间的格式化字符串
        /// </summary>
        public static string TimeFormatString = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        ///  cqgis: 带毫秒的格式化字符串
        /// </summary>
        public static string TimeFormatStringWithMillisecond = $"{TimeFormatString}.fff";

        /// <summary>
        ///  cqgis: 返回格式化的时间字符串
        /// </summary>
        /// <param name="time"></param>
        /// <param name="includeMillisecond">是否包含毫秒</param>
        /// <returns></returns>
        public static string ToFormatString(this DateTime time, bool includeMillisecond = true)
        {
            if (includeMillisecond)
                return time.ToString(TimeFormatStringWithMillisecond);
            return time.ToString(TimeFormatString);
        }


        private static readonly DateTime OriginTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        /// <summary>
        ///  cqgis:  返回一个时间，距离原始时间（UTC 1970-1-1 0:0:0）的秒数。
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public static long ToSecValue(this DateTime time)
        {
            return (long)Math.Floor((time.ToUniversalTime() - OriginTime).TotalSeconds);
        }


        /// <summary>
        ///  cqgis:  返回一个秒数表示的时间。返回UTC时间
        /// </summary>
        /// <param name="value">距离原始时间（UTC 1970-1-1 0:0:0）的秒数</param>
        /// <returns></returns>
        public static DateTime FromSecTime(this long value)
        {
            return (OriginTime.AddSeconds(value)).ToUniversalTime();

        }


        /// <summary>
        ///  cqgis:  返回一个秒数表示的时间。返回UTC时间
        /// </summary>
        /// <param name="value">距离原始时间（UTC 1970-1-1 0:0:0）的秒数</param>
        /// <returns></returns>
        public static DateTime FromSecTime(this int value)
        {
            return (OriginTime.AddSeconds(value)).ToUniversalTime();

        }
    }
}