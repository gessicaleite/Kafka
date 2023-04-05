using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Message
{
    public class MessagePayload : MessageBase
    {
        [JsonProperty("Nome")]
        public string? Name { get; set; }
        public string? Nickname { get; set; }
        public DateTime RegisterDate { get; set; }

        public MessagePayload(string name, string nickName, Guid id) : base(id)
        {
            Name = name;
            Nickname = nickName;
            RegisterDate = DateTime.Now;
        }
    }
}
