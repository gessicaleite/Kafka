using ConsumerKafka.Interfaces;
using Domain.Config;
using Domain.Message;
using Microsoft.Extensions.Options;

namespace ConsumerKafka.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly ILogger<ConsumerService> _logger;
        private IKafkaConsumer<MessagePayload> _kafkaConsumer;
        private readonly TopicConfigOptions _topicConfig;

        public ConsumerService(ILogger<ConsumerService> logger, IOptions<TopicConfigOptions> topicConfig, IKafkaConsumer<MessagePayload> kafkaConsumer)
        {
            _logger = logger;
            _topicConfig = topicConfig.Value;
            _kafkaConsumer = kafkaConsumer;
        }
        public async Task ConsumeMessage()
        {
            _logger.LogInformation($"Started message consumption from {_topicConfig.TopicName}.");

            await _kafkaConsumer.ConsumeTopic(_topicConfig.TopicName);
        }
    }
}
