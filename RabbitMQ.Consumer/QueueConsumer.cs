using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQ.Consumer;

public class QueueConsumer
{
    public static void Consumer(IModel channel)
    {
        channel.QueueDeclare("demo-queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, args) =>
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);
        };

        channel.BasicConsume("demo-queue", true, consumer);
        Console.WriteLine("Consumer started.");
        Console.ReadKey();
    }
}
