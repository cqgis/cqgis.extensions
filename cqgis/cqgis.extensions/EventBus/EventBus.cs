using System;
using System.Collections.Generic;
using System.Linq; 

// ReSharper disable once CheckNamespace
namespace cqgis.extensions
{

    /// <summary>
    /// cqgis: 消息总线
    /// </summary>
    public class EventBus
    {
        private static EventBus _default;
        private static readonly object ObjectHelper = new object();

        /// <summary>
        /// cqgis: 默认的消息总线
        /// </summary>
        public static EventBus Default
        {
            get
            {
                if (_default == null)
                {
                    lock (ObjectHelper)
                    {
                        if (_default == null)
                            _default = new EventBus();
                    }
                }

                return _default;
            }
        }


        private EventBus()
        {
            _subscriptions = new Dictionary<Type, List<ISubscription>>();
        }

        /// <summary>
        /// cqgis: 订阅消息
        /// </summary>
        /// <typeparam name="TEventBase"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>

        public SubscriptionToken Subscribe<TEventBase>(Action<TEventBase> action) where TEventBase : EventBase
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            lock (SubscriptionsLock)
            {
                if (!_subscriptions.ContainsKey(typeof(TEventBase)))
                    _subscriptions.Add(typeof(TEventBase), new List<ISubscription>());

                var token = new SubscriptionToken(typeof(TEventBase));
                _subscriptions[typeof(TEventBase)].Add(new Subscription<TEventBase>(action, token));
                return token;
            }
        }

        /// <summary>
        ///cqgis:  订阅消息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public SubscriptionToken Subscribe(Type type, Action<EventBase> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            lock (SubscriptionsLock)
            {
                if (!_subscriptions.ContainsKey(type))
                    _subscriptions.Add(type, new List<ISubscription>());

                var token = new SubscriptionToken(type);
                _subscriptions[type].Add(new Subscription<EventBase>(action, token));
                return token;
            }
        }


        /// <summary>
        ///cqgis:  取消订阅
        /// </summary>
        /// <param name="token"></param>
        public void Unsubscribe(SubscriptionToken token)
        {
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            lock (SubscriptionsLock)
            {
                if (_subscriptions.ContainsKey(token.EventItemType))
                {
                    var allSubscriptions = _subscriptions[token.EventItemType];
                    var subscriptionToRemove = allSubscriptions.FirstOrDefault(x => x.SubscriptionToken.Token == token.Token);
                    if (subscriptionToRemove != null)
                        _subscriptions[token.EventItemType].Remove(subscriptionToRemove);
                }
            }
        }

        /// <summary>
        /// cqgis: 取消所有某种类型的订阅
        /// </summary>
        /// <typeparam name="TEventBase"></typeparam>
        public void UnsubscribeAll<TEventBase>() where TEventBase : EventBase
        {
            lock (SubscriptionsLock)
            {
                if (_subscriptions.ContainsKey(typeof(TEventBase)))
                {
                    var allSubscriptions = _subscriptions[typeof(TEventBase)];
                    allSubscriptions.Clear();

                    _subscriptions.Remove(typeof(TEventBase));
                }
            }
        }


        /// <summary>
        /// cqgis: 发布一种类型的消息
        /// </summary>
        /// <typeparam name="TEventBase"></typeparam>
        /// <param name="eventItem"></param>
        public void Publish<TEventBase>(TEventBase eventItem) where TEventBase : EventBase
        {
            if (eventItem == null)
                throw new ArgumentNullException(nameof(eventItem));

            List<ISubscription> allSubscriptions = new List<ISubscription>();
            lock (SubscriptionsLock)
            {
                var type = eventItem.GetType();

                if (_subscriptions.ContainsKey(type))
                    allSubscriptions = _subscriptions[type];
                //if (_subscriptions.ContainsKey(typeof(TEventBase)))
                //    allSubscriptions = _subscriptions[typeof(TEventBase)];
            }

            foreach (var subscription in allSubscriptions)
            {
                try
                {
                    subscription.Publish(eventItem);
                }
                catch (Exception)
                {
                    //
                }
            }
        }

        /// <summary>
        /// cqgis: 异步发布一种类型的消息
        /// </summary>
        /// <typeparam name="TEventBase"></typeparam>
        /// <param name="eventItem"></param>
        public void PublishAsync<TEventBase>(TEventBase eventItem) where TEventBase : EventBase
        {
            PublishAsyncInternal(eventItem, null);
        }

        /// <summary>
        /// cqgis: 异步发布消息
        /// </summary>
        /// <typeparam name="TEventBase"></typeparam>
        /// <param name="eventItem"></param>
        /// <param name="callback"></param>
        public void PublishAsync<TEventBase>(TEventBase eventItem, AsyncCallback callback) where TEventBase : EventBase
        {
            PublishAsyncInternal(eventItem, callback);
        }

        #region PRIVATE METHODS

        private void PublishAsyncInternal<TEventBase>(TEventBase eventItem, AsyncCallback callback) where TEventBase : EventBase
        {
            Action publishAction = () => Publish(eventItem);
            publishAction.BeginInvoke(callback, null);
        }

        #endregion

        private readonly Dictionary<Type, List<ISubscription>> _subscriptions;
        private static readonly object SubscriptionsLock = new object();
    }
}
