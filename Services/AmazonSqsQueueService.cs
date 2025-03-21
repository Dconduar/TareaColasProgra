using System;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace QueueApp.Services
{
    public class AmazonSqsQueueService : IQueueService
    {
        private readonly AmazonSQSClient _sqsClient;
        private readonly string _queueUrl;

        public AmazonSqsQueueService()
        {
            _sqsClient = new AmazonSQSClient(); // Usa credenciales de AWS configuradas en el entorno
            _queueUrl = "https://sqs.us-east-2.amazonaws.com/564111475296/ColaDi"; // Reemplaza con tu URL de SQS
        }

        public void Enqueue(string message)
        {
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = _queueUrl,
                MessageBody = message
            };

            _sqsClient.SendMessageAsync(sendMessageRequest).Wait();
            Console.WriteLine($"[Enqueued to SQS]: {message}");
        }

        public string? Dequeue()
        {
            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = _queueUrl,
                MaxNumberOfMessages = 1,
                WaitTimeSeconds = 5
            };

            var response = _sqsClient.ReceiveMessageAsync(receiveMessageRequest).Result;

            if (response.Messages.Count == 0)
            {
                Console.WriteLine("[SQS Queue is empty]");
                return null;
            }

            var message = response.Messages[0];
            _sqsClient.DeleteMessageAsync(_queueUrl, message.ReceiptHandle).Wait();
            Console.WriteLine($"[Dequeued from SQS]: {message.Body}");
            return message.Body;
        }
    }
}
