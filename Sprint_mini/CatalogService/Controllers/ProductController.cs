using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly StockService _stock;

    public ProductController(IMediator mediator, StockService stock)
    {
        _mediator = mediator;
        _stock = stock;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetProductsQuery());
        return Ok(result);
    }

    [HttpPost("lock/{id}")]
    public async Task<IActionResult> Lock(int id)
    {
        var success = await _stock.LockStock(id, "user123");

        if (!success)
            return BadRequest("Already locked");

        return Ok("Locked for 5 min");
    }
}