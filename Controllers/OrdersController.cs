using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SampleRabbitMqApi.Contracts;

namespace SampleRabbitMqApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public OrdersController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        var evt = new OrderCreatedEvent
        {
            OrderId = Guid.NewGuid(),
            CustomerName = request.CustomerName,
            CreatedAt = DateTime.UtcNow
        };

        await _publishEndpoint.Publish(evt);
        return Ok(evt);
    }
}

public record CreateOrderRequest(string CustomerName);