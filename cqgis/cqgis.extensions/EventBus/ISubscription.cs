  
// ReSharper disable once CheckNamespace
namespace cqgis.extensions
{
    /// <summary>
    ///cqgis:  一个订阅
    /// </summary>
    public interface ISubscription
    {

        /// <summary>
        /// cqgis: 订阅标记
        /// </summary>
        SubscriptionToken SubscriptionToken { get; }

 
        /// <summary>
        /// cqgis：发布事件
        /// </summary>
        /// <param name="eventBase"></param>
        void Publish(EventBase eventBase);
    }
}
