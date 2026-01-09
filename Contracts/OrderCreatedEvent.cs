namespace SampleRabbitMqApi.Contracts;

public record OrderCreatedEvent
{
    public Guid OrderId { get; init; }
    public string CustomerName { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}