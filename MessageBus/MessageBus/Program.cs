using MessageBus.lib;
using System;

namespace MessageBus
{
    class Program
    {
        static void Main(string[] args)
        {
            var intBus = MessageBus<int>.Instance;
            var stringBus = MessageBus<string>.Instance;

            var intBus2 = MessageBus<int>.Instance;

            intBus.MessageReceived += intBusMessageReceived;
            stringBus.MessageReceived += stringBusMessageReceived;
            intBus2.MessageReceived += intBus2MessageReceived;

            intBus.SendMessage("intBus", 2);
            stringBus.SendMessage("stringBus", "Hello");

            Console.ReadLine();
        }

        private static void intBusMessageReceived(object sender, MessageBusEventArgs<int> e)
        {
            Console.WriteLine($"intBus: {e.Message}");
        }

        private static void intBus2MessageReceived(object sender, MessageBusEventArgs<int> e)
        {
            Console.WriteLine($"intBus2: {e.Message}");
        }

        private static void stringBusMessageReceived(object sender, MessageBusEventArgs<string> e)
        {
            Console.WriteLine($"stringBus: {e.Message}");
        }
    }
}
