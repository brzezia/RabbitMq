using System;
using RabbitMqClient;

namespace ReadFromQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            IRabbitOptions options = new RabbitOptions
            {
                RabbitMQHost = "localhost",
                RabbitMQUsername = "guest",
                VirtualHost = "bird",
                RabbitMQPassword = "guest"
            };

            var receiver = new Receiver();

            if (!receiver.EstablishConnection(options))
            {
                Console.WriteLine("Connection could not be established");
                return;
            }
            receiver.RegisterHandler("demoEx", "DemoQueue", new ReceiveHandlers().Handler);
        }
    }
}
