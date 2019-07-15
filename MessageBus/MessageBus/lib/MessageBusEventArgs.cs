using System;

namespace MessageBus.lib
{
    public class MessageBusEventArgs<T> : EventArgs
    {
        private T _message;
        public MessageBusEventArgs(T message)
        {
            _message = message;
        }
        public T Message
        {
            get { return _message; }
        }
    }
}
