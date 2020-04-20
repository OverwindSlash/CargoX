using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Redis
{
    public class RedisManager:IRedisManager
    {
        private readonly IDatabase _database;
        private readonly IRedisCacheDatabaseProvider _provider;
        private readonly TimeSpan timeout;

        public RedisManager(IRedisCacheDatabaseProvider provider)
        {
            _provider = provider;
            _database = _provider.GetDatabase();
        }

        public void StringSet<T>(string key, T value)
        {
            _database.StringSet(key, JsonConvert.SerializeObject(value));
        }
        public void StringSet<T>(string key, T value, TimeSpan timeout)
        {
            _database.StringSet(key, JsonConvert.SerializeObject(value), timeout);
        }
        public Task StringSetAsync<T>(string key, T value)
        {
            return _database.StringSetAsync(key, JsonConvert.SerializeObject(value));
        }
        public Task StringSetAsync<T>(string key, T value, TimeSpan timeout)
        {
            return _database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeout);
        }

        public T StringGet<T>(string key)
        {
            var value = _database.StringGet(key);
            if (!value.HasValue)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(value);
        }

        public async Task<T> StringGetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);

            if (!value.HasValue)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(value);
        }

        public void StringDelete(string key)
        {
            _database.KeyDelete(key);
        }
    }
}
