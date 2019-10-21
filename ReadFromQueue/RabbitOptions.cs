using RabbitMqClient;

namespace ReadFromQueue
{
    public class RabbitOptions : IRabbitOptions
    {
        public string RabbitMQHost { get; set; }
        public string RabbitMQUsername { get; set; }
        public string RabbitMQPassword { get; set; }
        public string VirtualHost { get; set; }

        public int NumberConsumers { get; set; }
        public int BackOffIterations { get; set; }
        public int BackOffInterval { get; set; }
        public bool IsBackoffExponential { get; set; }
    }
}