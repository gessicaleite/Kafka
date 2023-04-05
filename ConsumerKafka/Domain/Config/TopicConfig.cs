using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Config
{
    public class TopicConfigOptions
    {
        public static string TopicConfig = "Topics";
        public string? TopicName { get; set; }
        public string? Domain { get; set; }
        public string? Action { get; set; }
    }
}
