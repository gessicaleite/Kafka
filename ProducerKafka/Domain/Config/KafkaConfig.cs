using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Config
{
    public class KafkaConfigOptions
    {
        public static string KafkaConfig = "KafkaConfig";
        public string? BootstrapServers { get; set; }
    }
}
