using Domain.Config;
using Domain.Message;
using Domain.Message.Builder;
using Microsoft.Extensions.Options;
using ProducerKafka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerKafka.Service
{
    public class ProducerService : IProducerService
    {
        private readonly ILogger<ProducerService> _logger;

        private readonly IKafkaProducer<MessagePayload> _kafkaProducer;
        private readonly TopicsConfig _topicConfig;
        private readonly IMessageBuilderJson _messageBuilderJson;
        public ProducerService(ILogger<ProducerService> logger, IKafkaProducer<MessagePayload> kafkaProducer, IOptions<TopicsConfig> topicConfig, IMessageBuilderJson messageBuilderJson)
        {
            _logger = logger;
            _kafkaProducer = kafkaProducer;
            _topicConfig = topicConfig.Value;
            _messageBuilderJson = messageBuilderJson;
        }
        public async Task<MessagePayload> ProduceMessage()
        {
            _logger.LogInformation("Preparing message...");

            var message = new MessagePayload("Paçoca", "Paçoquinha", Guid.NewGuid());

            var messageJson = _messageBuilderJson.BuildJsonMessage(Guid.NewGuid(), message);

            await _kafkaProducer.PublishToTopic(_topicConfig.TopicName, Guid.NewGuid().ToString(), messageJson);

            return message;
        }
    }
}
