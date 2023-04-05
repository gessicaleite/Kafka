using Confluent.Kafka;
using ConsumerKafka.Interfaces;
using Domain.Config;
using Domain.Message.Deserialize;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerKafka.Consumer
{
    public class KafkaConsumer<TValue> : IKafkaConsumer<TValue>, IDisposable
    {
        private readonly ILogger<KafkaConsumer<TValue>> _logger;
        private readonly IConsumer<string, TValue> _consumer;
        private readonly KafkaConfigOptions _kafkaConfig;

        public KafkaConsumer(ILogger<KafkaConsumer<TValue>> logger, IOptions<KafkaConfigOptions> kafkaConfig)
        {
            _logger = logger;
            _kafkaConfig = kafkaConfig.Value;
            _consumer = new ConsumerBuilder<string, TValue>(CreateConfig())
                                                            .SetKeyDeserializer(new DeserializerKey<string>())
                                                            .SetValueDeserializer(new DeserializerValue<TValue>())
                                                            .Build();
        }

        public async Task<TValue> ConsumeTopic(string topic)
        {
            _logger.LogInformation($"GroupId {_kafkaConfig.GroupId} received message from Topic {topic}.");

            _consumer.Subscribe(topic);

            var message = _consumer.Consume();

            return message.Message.Value;
        }

        public void Dispose()
        {
            _consumer.Unsubscribe();
            _consumer.Close();
            _consumer.Dispose();
        }

        private ConsumerConfig CreateConfig()
            => new ConsumerConfig
            {
                BootstrapServers = _kafkaConfig.BootstrapServers,
                GroupId = _kafkaConfig.GroupId
            };
    }
}
