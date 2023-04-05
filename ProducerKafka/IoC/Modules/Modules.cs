using Domain.Config;
using Domain.Message.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Modules
{
    public static class Modules
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KafkaConfigOptions>(configuration.GetSection(KafkaConfigOptions.KafkaConfig));
            services.Configure<TopicsConfig>(configuration.GetSection(TopicsConfig.TopicConfig));
            return services;
        }

        public static IServiceCollection AddBuilder(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBuilderJson, MessageBuilderJson>();
            return services;
        }
    }
}
