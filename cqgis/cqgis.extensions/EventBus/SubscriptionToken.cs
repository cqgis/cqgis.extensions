using System;

// ReSharper disable once CheckNamespace
namespace cqgis.extensions
{
    /// <summary>
    /// 一个订阅的标记
    /// </summary>
    public class SubscriptionToken
    {
        internal SubscriptionToken(Type eventItemType)
        {
            Token = Guid.NewGuid();
            EventItemType = eventItemType;
        }
        
        public Guid Token { get; }

        public Type EventItemType { get; }
    }
}
