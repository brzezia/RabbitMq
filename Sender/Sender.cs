using System;
using System.Text;
using RabbitMQ.Client;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            do
            {
                Console.Write("Message:");

                SendMessage(Console.ReadLine());

                Console.WriteLine(" Press [enter] to send message, [Q] to exit.");
            } while (Console.ReadKey().Key != ConsoleKey.Q);
        }

        private static void SendMessage(string v)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "stoga",
                    exclusive: false,
                    arguments: null,
                    durable: false,
                    autoDelete: false);

                var body = Encoding.UTF8.GetBytes(v);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "stoga",
                    basicProperties: properties,
                    body: body);
                Console.WriteLine(" [x] Sent {0}", v);
            }
        }
    }
}
