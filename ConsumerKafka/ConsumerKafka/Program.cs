using ConsumerKafka;
using ConsumerKafka.Consumer;
using ConsumerKafka.Interfaces;
using ConsumerKafka.Services;
using Domain.Message;
using IoC;
using IoC.Modules;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IKafkaConsumer<MessagePayload>, KafkaConsumer<MessagePayload>>();
        services.AddSingleton<IConsumerService, ConsumerService>();
        services.Register(hostContext.Configuration);
    })
    .Build();

await host.RunAsync();
