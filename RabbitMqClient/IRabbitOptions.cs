using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqClient
{
    public interface IRabbitOptions
    {
        string RabbitMQHost { get; }

        string RabbitMQUsername { get; }

        string RabbitMQPassword { get; }

        string VirtualHost { get; }

        int NumberConsumers { get; }

        int BackOffIterations { get; }

        int BackOffInterval { get; }

        bool IsBackoffExponential { get; }
    }
}
