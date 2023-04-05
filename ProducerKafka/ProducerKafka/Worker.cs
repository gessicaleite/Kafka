using ProducerKafka.Interfaces;

namespace ProducerKafka
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IProducerService _produterService;

        public Worker(ILogger<Worker> logger, IProducerService produterService)
        {
            _logger = logger;
            _produterService = produterService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _produterService.ProduceMessage();

                await Task.Delay(1000, stoppingToken);
            }

            _logger.LogInformation("Nada mais pra ver aqui");
        }
    }
}