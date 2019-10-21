using System;
using RabbitMqClient;
using RabbitMqClient.Publish;

namespace SendToMqClient
{
    class Program
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

            var sender = new Sender();

            if (!sender.EstablishConnection(options))
            {
                Console.WriteLine("Connection could not be established");
                return;
            }

            do
            {
                Console.Write("Message:");

                sender.SendMessage(Console.ReadLine());

                Console.WriteLine(" Press [enter] to send message, [Q] to exit.");

            } while (Console.ReadKey().Key != ConsoleKey.Q);

            Console.WriteLine("End");
            Console.ReadKey();

        }
    }
}
