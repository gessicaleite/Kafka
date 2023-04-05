using Confluent.Kafka;
using Domain.Config;
using Domain.Message.Serializer;
using Microsoft.Extensions.Options;
using ProducerKafka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerKafka.Producer
{
    public class KafkaProducer<TValue> : IKafkaProducer<TValue>
    {
        private readonly ILogger<KafkaProducer<TValue>> _logger;
        private readonly IProducer<string, TValue> _producer;
        private readonly KafkaConfigOptions _kafkaConfig;

        public KafkaProducer(ILogger<KafkaProducer<TValue>> logger, IOptions<KafkaConfigOptions> kafkaConfig)
        {
            _logger = logger;

            _kafkaConfig = kafkaConfig.Value;

            _producer = new ProducerBuilder<string, TValue>(CreateConfig())
                                                           .SetKeySerializer(new SerializerKey<string>())
                                                           .SetValueSerializer(new SerializerValue<TValue>())
                                                           .Build();
        }

        public async Task PublishToTopic(string topic, string key, Message<string, TValue> message)
        {
            _logger.LogInformation($"Sending message to topic: {topic}.");
            await _producer.ProduceAsync(topic, message);
        }

        public void Dispose()
        {
            _producer.Flush();
            _producer.Dispose();
        }

        private ProducerConfig CreateConfig()
            => new ProducerConfig
            {
                BootstrapServers = _kafkaConfig.BootstrapServers,
                Acks = Acks.All
            };
    }
}
