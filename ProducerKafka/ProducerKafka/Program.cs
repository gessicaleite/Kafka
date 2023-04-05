using Domain.Message;
using IoC;
using ProducerKafka;
using ProducerKafka.Interfaces;
using ProducerKafka.Producer;
using ProducerKafka.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IProducerService, ProducerService>();
        services.AddSingleton<IKafkaProducer<MessagePayload>, KafkaProducer<MessagePayload>>();
        services.Register(hostContext.Configuration);
    })
    .Build();

await host.RunAsync();

