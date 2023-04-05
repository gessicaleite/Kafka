using Domain.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerKafka.Interfaces
{
    public interface IProducerService
    {
        Task<MessagePayload> ProduceMessage();
    }
}
