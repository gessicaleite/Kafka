using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerKafka.Interfaces
{
    public interface IKafkaProducer<TValue>
    {
        Task PublishToTopic(string topic, string key, Message<string, TValue> message);
    }
}
