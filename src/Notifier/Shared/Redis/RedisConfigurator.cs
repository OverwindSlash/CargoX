using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Redis
{
    public class RedisConfigurator
    {
        public int DatabaseId { get; set; }
        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }
        private IServiceCollection Collection { get; }

        public RedisConfigurator(IServiceCollection collection)
        {
            Collection = collection;
        }
    }
}
