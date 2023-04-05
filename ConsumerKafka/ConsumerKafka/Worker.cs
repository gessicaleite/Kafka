using ConsumerKafka.Interfaces;

namespace ConsumerKafka
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConsumerService _consumerService;

        public Worker(ILogger<Worker> logger, IConsumerService consumerService)
        {
            _logger = logger;
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await _consumerService.ConsumeMessage();

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}