using QueueApp.Services;

class Program
{
    static void Main()
    {
        IQueueService queueService;

        Console.WriteLine("Seleccione el proveedor de cola:");
        Console.WriteLine("1. InMemory");
        Console.WriteLine("2. Amazon SQS");
        Console.WriteLine("3. Azure Queue Storage");

        string option = Console.ReadLine();

        queueService = option switch
        {
            "1" => new InMemoryQueueService(),
            "2" => new AmazonSqsQueueService(),
            "3" => new AzureQueueService(),
            _ => throw new Exception("Opción no válida")
        };

        queueService.Enqueue("Mensaje de prueba");
        queueService.Dequeue();
    }
}
