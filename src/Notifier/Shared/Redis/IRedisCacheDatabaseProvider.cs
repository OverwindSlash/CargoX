using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Redis
{
    public interface IRedisCacheDatabaseProvider
    {
        TimeSpan Timeout { get; set; }
        IDatabase GetDatabase();
    }
}
