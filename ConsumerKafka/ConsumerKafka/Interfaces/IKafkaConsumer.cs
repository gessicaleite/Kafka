namespace ConsumerKafka.Interfaces
{
    public interface IKafkaConsumer<TValue>
    {
        Task<TValue> ConsumeTopic(string topic);
    }
}
