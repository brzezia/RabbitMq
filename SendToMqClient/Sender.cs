using System;
using System.Collections.Generic;
using System.Text;
using RabbitMqClient;
using RabbitMqClient.Publish;

namespace SendToMqClient
{
    public class Sender
    {
        private  IMessanger _messanger;
        public void SendMessage(string message)
        {
            if (_messanger != null)
            {
                _messanger.Send(
                    exchangeName: "demoEx",
                    rabbitMessage: message,
                    routingKey: "Demo"
                    );
            }
        }

        public bool EstablishConnection(IRabbitOptions options)
        {
            var managerPool = new ConnectionPoolManager();

            if (managerPool.RegisterConnecton("bird", options))
            {
                var connectionManager = managerPool.Get("bird");
                if (connectionManager != null)
                {
                    _messanger = new Messanger(connectionManager);
                    return true;
                }
            }
            return false;
        }

     
    }
}
