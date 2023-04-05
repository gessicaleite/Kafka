using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Message.Serializer
{
    public class SerializerKey<TKey> :IAsyncSerializer<TKey>
    {
        public async Task<byte[]> SerializeAsync(TKey key, SerializationContext context)
        {
            return await Task.Run(() => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(key)));
        }
    }
}
