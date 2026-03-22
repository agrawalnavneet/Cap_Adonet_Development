using StackExchange.Redis;
using System.Text.Json;

public class RedisService
{
    private readonly IDatabase _db;

    public RedisService(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    public async Task SetAsync(string key, object value, TimeSpan ttl)
    {
        var data = JsonSerializer.Serialize(value);
        await _db.StringSetAsync(key, data, ttl);
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var data = await _db.StringGetAsync(key);

        if (data.IsNullOrEmpty)
            return default;

        return JsonSerializer.Deserialize<T>(data.ToString());
    }

    public async Task RemoveAsync(string key)
    {
        await _db.KeyDeleteAsync(key);
    }
}