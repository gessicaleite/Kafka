namespace ConsumerKafka.Interfaces
{
    public interface IConsumerService
    {
        Task ConsumeMessage();
    }
}
