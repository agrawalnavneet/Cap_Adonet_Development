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

    // ➕ Add Product
    [HttpPost]
    public async Task<IActionResult> Add(AddProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // 📦 Get Products (Redis + DB)
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetProductsQuery());
        return Ok(result);
    }

    // 🔒 Lock Product (Dummy user = admin)
    [HttpPost("lock/{id}")]
    public async Task<IActionResult> Lock(int id)
    {
        string userId = "admin"; // 👈 dummy user

        // Step 1: check product exists
        var products = await _mediator.Send(new GetProductsQuery());

        if (!products.Any(p => p.Id == id))
            return NotFound($"Product with ID {id} not found");

        // Step 2: lock using Redis
        var success = await _stock.LockStock(id, userId);

        if (!success)
            return BadRequest("Product already locked");

        return Ok($"Product {id} locked by {userId} for 5 min");
    }

    // 🔍 Check Lock Status
    [HttpGet("lock/{id}")]
    public async Task<IActionResult> CheckLock(int id)
    {
        var result = await _stock.GetLockStatus(id);

        if (string.IsNullOrEmpty(result))
            return Ok($"Product {id} is not locked");

        return Ok($"Product {id} is locked by {result}");
    }
}