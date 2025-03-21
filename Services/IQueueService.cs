namespace QueueApp.Services
{
    public interface IQueueService
    {
        void Enqueue(string message);
        string? Dequeue();
    }
}
