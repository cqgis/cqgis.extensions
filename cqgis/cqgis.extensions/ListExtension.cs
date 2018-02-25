using System;
using System.Collections.Generic;
using System.Text;

namespace cqgis.extensions
{
    /// <summary>
    /// cqgis: 列表相关的的扩展
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// cqgis: 随机交换列表中数据的位置
        /// </summary>
        /// <typeparam name="T"></typeparam>

        /// <param name="deck"></param>

        public static void Shuffle<T>(this IList<T> deck)
        {

            var N = deck.Count;
            var random = new Random();

            for (var i = 0; i < N; ++i)
            {

                var r = i + (int)(random.Next(N - i));

                T t = deck[r];

                deck[r] = deck[i];

                deck[i] = t;
            }
        }

    }
}
