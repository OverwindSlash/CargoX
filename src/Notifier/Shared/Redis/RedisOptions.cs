using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Redis
{
    public class RedisOptions
    {
        public int DatabaseId { get; set; }
        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }
    }
}
