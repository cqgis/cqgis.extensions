using System;


// ReSharper disable once CheckNamespace
namespace cqgis.extensions
{
    internal class Subscription<TEventBase> : ISubscription where TEventBase : EventBase
    {
        public SubscriptionToken SubscriptionToken { get; }

        public Subscription(Action<TEventBase> action, SubscriptionToken token)
        {
            action.CheckIsNull(nameof(action));
            token.CheckIsNull(nameof(token));

            _action = action;
            SubscriptionToken = token;
        }


        public void Publish(EventBase eventItem)
        {
            if (!(eventItem is TEventBase))
                throw new ArgumentException("Event Item is not the correct type.");

            _action.Invoke((TEventBase) eventItem);
        }

        private readonly Action<TEventBase> _action;
    }
}
