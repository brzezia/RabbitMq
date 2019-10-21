using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMqClient
{
    public class ConnectionManager : IConnectionManager, IDisposable
    {
        private IConnection _connection;
        private readonly List<IModel> _channels = new List<IModel>();
        private readonly IRabbitOptions _rabbitOptions;
        public ConnectionManager(IRabbitOptions rabbitOptions)
        {
            _rabbitOptions = rabbitOptions;
        }
        public ConnectionResult CheckConnection(IModel channel)
        {
            return new ConnectionResult();
        }

        public void Connect()
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbitOptions.RabbitMQHost,
                Password = _rabbitOptions.RabbitMQPassword,
                VirtualHost = _rabbitOptions.VirtualHost,
                UserName = _rabbitOptions.RabbitMQUsername
            };

            _connection = factory.CreateConnection();
        }

        public IModel CreateChannel(int noIterations = 1)
        {
            var channel = _connection.CreateModel();
            _channels.Add(channel);
            return channel;
        }

        public void RemoveChannel(IModel channel)
        {
            _channels.Remove(channel);
        }

        public void Dispose()
        {
          foreach(var chan in _channels)
            {
                chan.Close(200, "by user");
                chan.Dispose();
            }
          (_connection as IDisposable).Dispose();
        }
    }
}
