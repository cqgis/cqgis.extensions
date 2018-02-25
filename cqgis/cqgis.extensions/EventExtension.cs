namespace cqgis.extensions
{
    public static class EventExtension
    {
        #region 事件的泛型声明
        /// <summary>
        /// cqgis:  只带默认参数的事件委托
        /// </summary>
        /// <param name="sender">触发事件的对象</param>
        public delegate void EventHandlers(object sender);
        /// <summary>
        ///  cqgis: 带自定义参数的事件委托
        /// </summary>
        /// <typeparam name="T">指定的参数类型</typeparam>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="t">参数类型T的对象</param>
        public delegate void EventHandlers<in T>(object sender, T t);
        /// <summary>
        /// cqgis:  带自定义参数的事件委托
        /// </summary>
        /// <typeparam name="TA">指定的参数类型A</typeparam>
        /// <typeparam name="TB">指定的参数类型B</typeparam>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="a">参数类型A的对象</param>
        /// <param name="b">参数类型B的对象</param>
        public delegate void EventHandlers<in TA, in TB>(object sender, TA a, TB b);
        /// <summary>
        /// cqgis:  带自定义参数的事件委托
        /// </summary>
        /// <typeparam name="TA">指定的参数类型A</typeparam>
        /// <typeparam name="TB">指定的参数类型B</typeparam>
        /// <typeparam name="TC">指定的参数类型C</typeparam>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="a">参数类型A的对象</param>
        /// <param name="b">参数类型B的对象</param>
        /// <param name="c">参数类型C的对象</param>
        public delegate void EventHandlers<in TA, in TB, in TC>(object sender, TA a, TB b, TC c);
        /// <summary>
        /// cqgis:  带自定义参数的事件委托
        /// </summary>
        /// <typeparam name="TA">指定的参数类型A</typeparam>
        /// <typeparam name="TB">指定的参数类型B</typeparam>
        /// <typeparam name="TC">指定的参数类型C</typeparam>
        /// <typeparam name="TD">指定的参数类型D</typeparam>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="a">参数类型A的对象</param>
        /// <param name="b">参数类型B的对象</param>
        /// <param name="c">参数类型C的对象</param>
        /// <param name="d">参数类型D的对象</param>
        public delegate void EventHandlers<in TA, in TB, in TC, in TD>(object sender, TA a, TB b, TC c, TD d);
        /// <summary>
        ///  cqgis: 带自定义参数的事件委托
        /// </summary>
        /// <typeparam name="TA">指定的参数类型A</typeparam>
        /// <typeparam name="TB">指定的参数类型B</typeparam>
        /// <typeparam name="TC">指定的参数类型C</typeparam>
        /// <typeparam name="TD">指定的参数类型D</typeparam>
        /// <typeparam name="TE">指定的参数类型E</typeparam>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="a">参数类型A的对象</param>
        /// <param name="b">参数类型B的对象</param>
        /// <param name="c">参数类型C的对象</param>
        /// <param name="d">参数类型D的对象</param>
        /// <param name="e">参数类型E的对象</param>
        public delegate void EventHandlers<in TA, in TB, in TC, in TD, in TE>(object sender, TA a, TB b, TC c, TD d, TE e);
        /// <summary>
        ///  cqgis: 带自定义参数的事件委托
        /// </summary>
        /// <typeparam name="TA">指定的参数类型A</typeparam>
        /// <typeparam name="TB">指定的参数类型B</typeparam>
        /// <typeparam name="TC">指定的参数类型C</typeparam>
        /// <typeparam name="TD">指定的参数类型D</typeparam>
        /// <typeparam name="TE">指定的参数类型E</typeparam>
        /// <typeparam name="TF">指定的参数类型F</typeparam>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="a">参数类型A的对象</param>
        /// <param name="b">参数类型B的对象</param>
        /// <param name="c">参数类型C的对象</param>
        /// <param name="d">参数类型D的对象</param>
        /// <param name="e">参数类型E的对象</param>
        /// <param name="f">参数类型F的对象</param>
        public delegate void EventHandlers<in TA, in TB, in TC, in TD, in TE, in TF>(object sender, TA a, TB b, TC c, TD d, TE e, TF f);
        /// <summary>
        ///  cqgis: 带自定义参数的事件委托
        /// </summary>
        /// <typeparam name="TA">指定的参数类型A</typeparam>
        /// <typeparam name="TB">指定的参数类型B</typeparam>
        /// <typeparam name="TC">指定的参数类型C</typeparam>
        /// <typeparam name="TD">指定的参数类型D</typeparam>
        /// <typeparam name="TE">指定的参数类型E</typeparam>
        /// <typeparam name="TF">指定的参数类型F</typeparam>
        /// <typeparam name="TG">指定的参数类型G</typeparam>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="a">参数类型A的对象</param>
        /// <param name="b">参数类型B的对象</param>
        /// <param name="c">参数类型C的对象</param>
        /// <param name="d">参数类型D的对象</param>
        /// <param name="e">参数类型E的对象</param>
        /// <param name="f">参数类型F的对象</param>
        /// <param name="g">参数类型G的对象</param>
        public delegate void EventHandlers<in TA, in TB, in TC, in TD, in TE, in TF, in TG>(
            object sender, TA a, TB b, TC c, TD d, TE e, TF f, TG g);
        #endregion

        #region 触发事件的泛型方法
        /// <summary>
        /// cqgis:  触发事件
        /// </summary>
        /// <param name="Event">事件</param>
        /// <param name="sender">触发事件的实体</param>
        public static void Fire(this EventHandlers Event, object sender)
        {
            if (Event != null)
            {
                var temp = Event;
                temp(sender);
            }
        }
        /// <summary>
        /// cqgis:  触发事件
        /// </summary>
        /// <param name="Event">事件</param>
        /// <param name="sender">触发事件的实体</param>
        /// <param name="t">参数1</param>
        public static void Fire<T>(this EventHandlers<T> Event, object sender, T t)
        {
            if (Event != null)
            {
                var temp = Event;
                temp(sender, t);
            }
        }
        /// <summary>
        ///  cqgis: 触发事件
        /// </summary>
        /// <param name="Event">事件</param>
        /// <param name="sender">触发事件的实体</param>
        /// <param name="ta">参数1</param>
        /// <param name="tb">参数2</param>
        public static void Fire<TA, TB>(this EventHandlers<TA, TB> Event, object sender, TA ta, TB tb)
        {
            if (Event != null)
            {
                var temp = Event;
                temp(sender, ta, tb);
            }
        }
        /// <summary>
        ///  cqgis: 触发事件
        /// </summary>
        /// <param name="Event">事件</param>
        /// <param name="sender">触发事件的实体</param>
        /// <param name="ta">参数1</param>
        /// <param name="tb">参数2</param>
        /// <param name="tc">参数3</param>
        public static void Fire<TA, TB, TC>(this EventHandlers<TA, TB, TC> Event, object sender, TA ta, TB tb, TC tc)
        {
            if (Event != null)
            {
                var temp = Event;
                temp(sender, ta, tb, tc);
            }
        }
        /// <summary>
        /// cqgis:  触发事件
        /// </summary>
        /// <param name="Event">事件</param>
        /// <param name="sender">触发事件的实体</param>
        /// <param name="ta">参数1</param>
        /// <param name="tb">参数2</param>
        /// <param name="tc">参数3</param>
        /// <param name="td">参数4</param>
        public static void Fire<TA, TB, TC, TD>(this EventHandlers<TA, TB, TC, TD> Event, object sender, TA ta, TB tb,
            TC tc, TD td)
        {
            if (Event != null)
            {
                var temp = Event;
                temp(sender, ta, tb, tc, td);
            }
        }
        /// <summary>
        ///  cqgis: 触发事件
        /// </summary>
        /// <param name="Event">事件</param>
        /// <param name="sender">触发事件的实体</param>
        /// <param name="ta">参数1</param>
        /// <param name="tb">参数2</param>
        /// <param name="tc">参数3</param>
        /// <param name="td">参数4</param>
        /// <param name="te">参数5</param>
        public static void Fire<TA, TB, TC, TD, TE>(this EventHandlers<TA, TB, TC, TD, TE> Event, object sender, TA ta,
            TB tb, TC tc, TD td, TE te)
        {
            if (Event != null)
            {
                var temp = Event;
                temp(sender, ta, tb, tc, td, te);
            }
        }
        /// <summary>
        ///  cqgis: 触发事件
        /// </summary>
        /// <param name="Event">事件</param>
        /// <param name="sender">触发事件的实体</param>
        /// <param name="ta">参数1</param>
        /// <param name="tb">参数2</param>
        /// <param name="tc">参数3</param>
        /// <param name="td">参数4</param>
        /// <param name="te">参数5</param>
        /// <param name="tf">参数6</param>
        public static void Fire<TA, TB, TC, TD, TE, TF>(this EventHandlers<TA, TB, TC, TD, TE, TF> Event,
            object sender, TA ta, TB tb, TC tc, TD td, TE te, TF tf)
        {
            if (Event != null)
            {
                var temp = Event;
                temp(sender, ta, tb, tc, td, te, tf);
            }
        }
        /// <summary>
        /// cqgis:  触发事件
        /// </summary>
        /// <param name="Event">事件</param>
        /// <param name="sender">触发事件的实体</param>
        /// <param name="ta">参数1</param>
        /// <param name="tb">参数2</param>
        /// <param name="tc">参数3</param>
        /// <param name="td">参数4</param>
        /// <param name="te">参数5</param>
        /// <param name="tf">参数6</param>
        /// <param name="tg">参数7</param>
        public static void Fire<TA, TB, TC, TD, TE, TF, TG>(this EventHandlers<TA, TB, TC, TD, TE, TF, TG> Event,
            object sender, TA ta, TB tb, TC tc, TD td, TE te, TF tf, TG tg)
        {
            if (Event != null)
            {
                var temp = Event;
                temp(sender, ta, tb, tc, td, te, tf, tg);
            }
        }
        #endregion
    }
}