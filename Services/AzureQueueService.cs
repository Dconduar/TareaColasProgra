using System;
using System.Threading.Tasks;
using Azure.Storage.Queues;

namespace QueueApp.Services
{
    public class AzureQueueService : IQueueService
    {
        private readonly QueueClient _queueClient;

        public AzureQueueService()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=;AccountKey=";
            string queueName = "myqueue";

            _queueClient = new QueueClient(connectionString, queueName);
            _queueClient.CreateIfNotExists();
        }

        public void Enqueue(string message)
        {
            _queueClient.SendMessageAsync(message).Wait();
            Console.WriteLine($"[Enqueued to Azure Queue]: {message}");
        }

        public string? Dequeue()
        {
            var response = _queueClient.ReceiveMessageAsync().Result;

            if (response?.Value == null)
            {
                Console.WriteLine("[Azure Queue is empty]");
                return null;
            }

            _queueClient.DeleteMessageAsync(response.Value.MessageId, response.Value.PopReceipt).Wait();
            Console.WriteLine($"[Dequeued from Azure Queue]: {response.Value.MessageText}");
            return response.Value.MessageText;
        }
    }
}
