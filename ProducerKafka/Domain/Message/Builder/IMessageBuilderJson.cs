using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Message.Builder
{
    public interface IMessageBuilderJson
    {
        public Message<string, TValue> BuildJsonMessage<TValue>(Guid id, TValue message)
            where TValue : MessagePayload;
    }
}
