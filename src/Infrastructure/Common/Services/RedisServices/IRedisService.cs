namespace Infrastructure.Common.Services.RedisServices
{
    public interface IRedisService
    {
        Task<List<T>?> TolistAsync<T>(string key);
        Task<RedisResult> AddAsync<T>(string key, T data, TimeSpan? expireTime = null, bool isAbsoluteExpire = true);
        Task<RedisResult> SetCacheAsync<T>(string key, T model, TimeSpan? expireTime = null, bool isAbsoluteExpire = true);
        Task<T?> GetCacheAsync<T>(string key);
        Task<RedisResult> RemoveCacheAsync(string key);
    }
}