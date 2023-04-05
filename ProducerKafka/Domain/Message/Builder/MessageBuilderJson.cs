using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Message.Builder
{
    public class MessageBuilderJson : IMessageBuilderJson
    {
        public Message<string, TValue> BuildJsonMessage<TValue>(Guid id, TValue message)
            where TValue : MessagePayload
        {
            return new Message<string, TValue>
            {
                Headers = new Headers()
                {
                    {
                        "id", id.ToByteArray()
                    }
                },
                Key = id.ToString(),
                Timestamp = new Timestamp(DateTimeOffset.Now),
                Value = message
            };
        }
    }
}
