using System;
using Xunit;

namespace cqgis.extensions.xunit
{
    /// <summary>
    ///cqgis:   XUnit 断言的一些扩展方法
    /// </summary>
    public static class AssertExtensions
    {
        /// <summary>
        ///cqgis:   相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="actual"></param>
        public static void ShouldBe<T>(this T value, T actual)
        {
            Assert.Equal(value, actual);
        }

        /// <summary>
        /// cqgis:  相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <param name="actual"></param>
        public static void ShouldBe<T, S>(this T value, Func<T, S> action, S actual)
        {
            Assert.Equal(action(value), actual);
        }

        /// <summary>
        ///cqgis:   相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="action"></param>
        public static void ShouldBe<T>(this T value, Func<T, bool> action)
        {
            value.ShouldBe(action, true);
        }


        /// <summary>
        /// cqgis:  应该为NULL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public static void ShouldNull<T>(this T value) where T : class
        {
            Assert.Null(value);
        }

        /// <summary>
        /// cqgis:  应该不为NULL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public static void ShouldNotNull<T>(this T value) where T : class
        {
            Assert.NotNull(value);
        }

        /// <summary>
        /// cqgis:  不能为NULL或空字符串
        /// </summary>
        /// <param name="value"></param>
        public static void ShouldNotNullOrEmpty(this string value)
        {
            value.ShouldBe(t => !string.IsNullOrWhiteSpace(t));
        }


    }
}