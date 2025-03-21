using System.Collections.Generic;

namespace QueueApp.Services
{
    public class InMemoryQueueService : IQueueService
    {
        private readonly Queue<string> _queue = new Queue<string>();

        public void Enqueue(string message)
        {
            _queue.Enqueue(message);
            Console.WriteLine($"Mensaje agregado: {message}");
        }

        public string? Dequeue()
        {
            if (_queue.Count == 0)
            {
                Console.WriteLine("La cola está vacía.");
                return null;
            }

            string message = _queue.Dequeue();
            Console.WriteLine($"Mensaje procesado: {message}");
            return message;
        }
    }
}
