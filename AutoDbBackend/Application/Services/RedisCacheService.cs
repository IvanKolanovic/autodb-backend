using System.Text.Json;
using Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Services;

public class RedisCacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    private readonly JsonSerializerOptions _jsonOptions;

    public RedisCacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var cachedValue = await _distributedCache.GetStringAsync(key);

        if (string.IsNullOrEmpty(cachedValue))
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(cachedValue, _jsonOptions);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var options = new DistributedCacheEntryOptions();

        if (expiry.HasValue)
        {
            options.AbsoluteExpirationRelativeToNow = expiry;
        }
        else
        {
            // Default expiration of 1 hour
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
        }

        var serializedValue = JsonSerializer.Serialize(value, _jsonOptions);
        await _distributedCache.SetStringAsync(key, serializedValue, options);
    }

    public async Task RemoveAsync(string key)
    {
        await _distributedCache.RemoveAsync(key);
    }

    public async Task<bool> ExistsAsync(string key)
    {
        var cachedValue = await _distributedCache.GetStringAsync(key);
        return !string.IsNullOrEmpty(cachedValue);
    }
}