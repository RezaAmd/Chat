using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Common.Services.RedisServices
{
    public class RedisService : IRedisService
    {
        #region Constructor
        private readonly IDistributedCache cache;
        private readonly ILogger<RedisService> logger;
        public RedisService(IDistributedCache _cache,
            ILogger<RedisService> _logger)
        {
            cache = _cache;
            logger = _logger;
        }
        #endregion

        public async Task<List<T>?> TolistAsync<T>(string key)
        {
            try
            {
                string row = await cache.GetStringAsync(key);
                if (!string.IsNullOrEmpty(row))
                    return JsonSerializer.Deserialize<List<T>>(row);
            }
            catch (Exception ex)
            {
                logger.LogWarning("Not found any item in redis. EX:" + ex.Message);
            }
            return default;
        }

        public async Task<RedisResult> AddAsync<T>(string key, T data, TimeSpan? expireTime = null, bool isAbsoluteExpire = true)
        {
            try
            {
                var list = await TolistAsync<T>(key);
                list.Add(data);
                var result = await SetCacheAsync(key, list, expireTime, isAbsoluteExpire);
                return result;
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex.Message);
                return RedisResult.Failed();
            }
        }

        public async Task<RedisResult> SetCacheAsync<T>(string key, T model, TimeSpan? expireTime = null, bool isAbsoluteExpire = true)
        {
            try
            {
                string serializedObj = JsonSerializer.Serialize(model);

                if (expireTime != null)
                    if (isAbsoluteExpire)
                        await cache.SetStringAsync(key, serializedObj,
                            new DistributedCacheEntryOptions().SetAbsoluteExpiration(expireTime.Value));
                    else
                        await cache.SetStringAsync(key, serializedObj,
                            new DistributedCacheEntryOptions().SetSlidingExpiration(expireTime.Value));
                else
                    await cache.SetStringAsync(key, serializedObj);

                logger.LogInformation($"{key} key storage in Radis was successful.");
                return RedisResult.Success;
            }
            catch (Exception ex)
            {
                logger.LogError($"{key} key storage failed.");
                return RedisResult.Failed(new() { new(0, ex.Message) });
            }
        }

        public async Task<T?> GetCacheAsync<T>(string key)
        {
            try
            {
                string row = await cache.GetStringAsync(key);
                if (!string.IsNullOrEmpty(row))
                    return JsonSerializer.Deserialize<T>(row);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return default;
        }

        public async Task<RedisResult> RemoveCacheAsync(string key)
        {
            try
            {
                await cache.RemoveAsync(key);
                return RedisResult.Success;
            }
            catch
            {
                return RedisResult.Failed();
            }
        }
    }
}