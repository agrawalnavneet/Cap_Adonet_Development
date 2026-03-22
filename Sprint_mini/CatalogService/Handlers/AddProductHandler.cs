using MediatR;

public class AddProductHandler : IRequestHandler<AddProductCommand, string>
{
    private readonly AppDbContext _db;
    private readonly RedisService _redis;

    public AddProductHandler(AppDbContext db, RedisService redis)
    {
        _db = db;
        _redis = redis;
    }

    public async Task<string> Handle(AddProductCommand request, CancellationToken ct)
    {
        var product = new Product
        {
            Name = request.Name,
            Stock = request.Stock
        };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        // cache invalidation
        await _redis.RemoveAsync("products");

        return "Product Added";
    }
}