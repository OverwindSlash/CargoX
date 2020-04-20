using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Shared.Redis
{
    public class RedisCacheDatabaseProvider:IRedisCacheDatabaseProvider
    {
        private readonly RedisOptions _redisOptions;
        private readonly Lazy<ConnectionMultiplexer> _connectionMultiplexer;

        public RedisCacheDatabaseProvider(IOptions<RedisOptions> redisOptions)
        {
            _redisOptions = redisOptions.Value;
            Timeout = redisOptions.Value.Timeout;
            _connectionMultiplexer = new Lazy<ConnectionMultiplexer>(CreateConnectionMultiplexer);
        }

        public TimeSpan Timeout { get; set; }

        public IDatabase GetDatabase()
        {
            return _connectionMultiplexer.Value.GetDatabase(_redisOptions.DatabaseId);
        }

        private ConnectionMultiplexer CreateConnectionMultiplexer()
        {
            return ConnectionMultiplexer.Connect(_redisOptions.ConnectionString);
        }
    }
}
