using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMq_Producer;
using System.Text;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

QueueProducer.Publish(channel);