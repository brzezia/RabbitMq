using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqClient.Consume
{
    public class Consumer : IConsumer
    {
        IConnectionManager _connectionMenager;
        IModel _channel;
        public Consumer(IConnectionManager connectionMenager)
        {
            _connectionMenager = connectionMenager;
        }

        public void Listen(string exchangeName, string queueName, EventHandler<BasicDeliverEventArgs> handler)
        {
            var _channel = _connectionMenager.CreateChannel();

            _channel.QueueDeclare(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);


            _channel.ExchangeDeclarePassive(exchangeName);

            _channel.QueueBind(queueName, exchangeName, "Demo");


            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += handler;

            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);

        }

    }
}
