using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Events;

namespace RabbitMqClient.Consume
{
    public interface IConsumer
    {
        void Listen(string exchangeName, string queueName, EventHandler<BasicDeliverEventArgs> handler);
    }
}
