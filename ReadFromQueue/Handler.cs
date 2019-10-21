using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMqClient.Publish;

namespace ReadFromQueue
{
    public class ReceiveHandlers
    {
        public void Handler(object sender, BasicDeliverEventArgs e)
        {
           var body =  Encoding.UTF8.GetString(e.Body);
            var message  = JsonConvert.DeserializeObject<RabbitMessage>(body);
            Console.WriteLine(message.Payload);
        }
    }
}
