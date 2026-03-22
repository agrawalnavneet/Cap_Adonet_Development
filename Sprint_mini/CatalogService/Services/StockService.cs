public class StockService
{
    private readonly RedisService _redis;

    public StockService(RedisService redis)
    {
        _redis = redis;
    }

    public async Task<bool> LockStock(int productId, string userId)
    {
        string key = $"lock_{productId}";

        var existing = await _redis.GetAsync<string>(key);

        if (existing != null)
            return false; // already locked

        await _redis.SetAsync(key, userId, TimeSpan.FromMinutes(5));

        return true;
    }
}