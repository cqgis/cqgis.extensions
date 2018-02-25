using System;

namespace cqgis.extensions
{
    /// <summary>
    /// cqgis: 单例模式的基类，继承此类后自动拥有单例模式的特征
    /// </summary>
    /// <typeparam name="T">子类</typeparam>
    public class SingletonBase<T> where T : ISingleInit
    {
        /// <summary>
        ///  cqgis: 用于线程之间安全锁定的变量
        /// </summary>
        private static readonly object SyncRoot = new Object();

        /// <summary>
        ///  cqgis: 多个线程共享的类实例
        /// </summary>
        private static volatile object _instance;

        /// <summary>
        ///  cqgis: 类的单一实体
        /// </summary>
        /// <example>Class1.Instance</example>
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (SyncRoot)
                    {
                        _instance = Activator.CreateInstance(typeof(T), true);
                        (_instance as ISingleInit)?.Init();
                    }
                }
                return (T)_instance;
            }
        }


    }

    /// <summary>
    ///  cqgis: 单例模式中，需要初始化的
    /// </summary>
    public interface ISingleInit
    {
        /// <summary>
        ///  cqgis: 初始化
        /// </summary>
        void Init();
    }
}