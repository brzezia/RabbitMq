using System;
using RabbitMQ.Client.Events;
using RabbitMqClient;
using RabbitMqClient.Consume;

namespace ReadFromQueue
{
    public class Receiver
    {
        private IConsumer _consumer;
        public bool EstablishConnection(IRabbitOptions options)
        {
            var managerPool = new ConnectionPoolManager();

            if (managerPool.RegisterConnecton("bird", options))
            {
                var connectionManager = managerPool.Get("bird");
                if (connectionManager != null)
                {
                    _consumer = new Consumer(connectionManager);
                    return true;
                }
            }
            return false;
        }

        public void RegisterHandler(string exchangeName, string queueName, EventHandler<BasicDeliverEventArgs> handler)
        {
            _consumer.Listen(exchangeName, queueName, handler);
        }
    }
}