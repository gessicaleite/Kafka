using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Message
{
    public class MessageBase
    {
        public Guid Id { get; set; }

        public MessageBase(Guid id)
        {
            Id = id;
        }
    }
}
