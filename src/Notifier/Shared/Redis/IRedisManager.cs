using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Redis
{
    public interface IRedisManager
    {
        void StringSet<T>(string key, T value);
        void StringSet<T>(string key, T value, TimeSpan timeout);
        Task StringSetAsync<T>(string key, T value);
        Task StringSetAsync<T>(string key, T value, TimeSpan timeout);
        T StringGet<T>(string key);
        Task<T> StringGetAsync<T>(string key);
        void StringDelete(string key);
    }
}
