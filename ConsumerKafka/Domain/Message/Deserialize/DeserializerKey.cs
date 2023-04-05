using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Message.Deserialize
{
    public class DeserializerKey<TKey> : IDeserializer<TKey>
    {
        public TKey Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return JsonConvert.DeserializeObject<TKey>(Encoding.UTF8.GetString(data.ToArray(), 0, data.Length));
        }

    }
}
