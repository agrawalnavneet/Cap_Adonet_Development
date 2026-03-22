using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
{
    private readonly AppDbContext _db;
    private readonly RedisService _redis;

    public GetProductsHandler(AppDbContext db, RedisService redis)
    {
        _db = db;
        _redis = redis;
    }

    public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken ct)
    {
        // Redis check
        var cache = await _redis.GetAsync<List<Product>>("products");

        if (cache != null)
            return cache; // Redis hit ⚡

        var products = await _db.Products.ToListAsync();

        await _redis.SetAsync("products", products, TimeSpan.FromMinutes(10));

        return products; // DB hit
    }
}