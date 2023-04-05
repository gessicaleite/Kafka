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
        public string? Nome { get; set; }

        [JsonProperty("Nickname")]
        public string? Apelido { get; set; }
        public DateTime DiaRegistro { get; set; }

        public MessagePayload(string? nome, string? apelido, Guid id) : base(id)
        {
            Nome = nome;
            Apelido = apelido;
            DiaRegistro = DateTime.Now;
        }
    }
}
