using MassTransit;
using SampleRabbitMqApi.Contracts;

namespace SampleRabbitMqApi.Consumers;

public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
{
    public Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        var msg = context.Message;
        Console.WriteLine($"Order received: {msg.OrderId} - {msg.CustomerName}");
        return Task.CompletedTask;
    }
}