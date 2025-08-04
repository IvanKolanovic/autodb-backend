using System.Text.Json;
using Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Services;

public class RedisCacheService(IDistributedCache distributedCache) : ICacheService
{
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    public async Task<T?> GetAsync<T>(string key)
    {
        var cachedValue = await distributedCache.GetStringAsync(key);

        return string.IsNullOrEmpty(cachedValue) ? default : JsonSerializer.Deserialize<T>(cachedValue, _jsonOptions);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiry ??
                                              // Default expiration of 1 hour
                                              TimeSpan.FromHours(1)
        };

        var serializedValue = JsonSerializer.Serialize(value, _jsonOptions);
        await distributedCache.SetStringAsync(key, serializedValue, options);
    }

    public async Task RemoveAsync(string key)
    {
        await distributedCache.RemoveAsync(key);
    }

    public async Task<bool> ExistsAsync(string key)
    {
        var cachedValue = await distributedCache.GetStringAsync(key);
        return !string.IsNullOrEmpty(cachedValue);
    }
}