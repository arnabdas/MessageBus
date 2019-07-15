using System;

namespace MessageBus.lib
{
    public class MessageBus<T>
    {
        private static MessageBus<T> _instance = null;
        private static readonly object _lock = new object();

        protected MessageBus()
        {

        }

        public static MessageBus<T> Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MessageBus<T>();
                    }
                    return _instance;
                }
            }
        }

        public event EventHandler<MessageBusEventArgs<T>> MessageReceived;
        public void SendMessage(object sender, T message)
        {
            MessageReceived?.Invoke(sender, new MessageBusEventArgs<T>(message));
        }
    }
}
