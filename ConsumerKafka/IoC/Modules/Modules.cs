using Domain.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Modules
{
    public static class Modules
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TopicConfigOptions>(configuration.GetSection(TopicConfigOptions.TopicConfig));
            services.Configure<KafkaConfigOptions>(configuration.GetSection(KafkaConfigOptions.KafkaConfig));

            return services;
        }

        public static IServiceCollection AddMessageBuilder(this IServiceCollection services)
        {
            return services;
        }
    }
}
