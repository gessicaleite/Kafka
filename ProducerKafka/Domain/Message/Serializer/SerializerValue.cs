using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Message.Serializer
{
    public class SerializerValue<TValue> :IAsyncSerializer<TValue>
    {
        public async Task<byte[]> SerializeAsync(TValue value, SerializationContext context)
        {
            return await Task.Run(() => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
        }
    }
}
