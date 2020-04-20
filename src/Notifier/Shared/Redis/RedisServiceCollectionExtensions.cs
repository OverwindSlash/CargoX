using Castle.Windsor.MsDependencyInjection;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Redis
{
    public static class RedisServiceCollectionExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, Action<RedisConfigurator> configure = null)
        {
            var configurator = new RedisConfigurator(services);

            configure?.Invoke(configurator);

            services.Configure<RedisOptions>(cfg =>
            {
                cfg.ConnectionString = configurator.ConnectionString;
                cfg.DatabaseId = configurator.DatabaseId;
                cfg.Timeout = configurator.Timeout != TimeSpan.FromSeconds(0) ? configurator.Timeout : TimeSpan.FromSeconds(600);
            });

            services.AddSingleton<IRedisCacheDatabaseProvider, RedisCacheDatabaseProvider>();
            services.AddTransient<IRedisManager, RedisManager>();

            return services;
        }
        public static IServiceCollection AddRedis(this IServiceCollection services, RedisOptions options)
        {
            services.Configure<RedisOptions>(cfg =>
            {
                cfg.ConnectionString = options.ConnectionString;
                cfg.DatabaseId = options.DatabaseId;
                cfg.Timeout = options.Timeout != TimeSpan.FromSeconds(0) ? options.Timeout : TimeSpan.FromSeconds(600);
            });

            services.AddSingleton<IRedisCacheDatabaseProvider, RedisCacheDatabaseProvider>();
            services.AddTransient<IRedisManager, RedisManager>();

            return services;
        }

        //public static IServiceCollection AddRedis(this IServiceCollection services, Func<IServiceProvider, RedisOptions> optionsFactory)
        //{
        //    var provider = services.BuildServiceProvider();
        //    var options = optionsFactory(provider);

        //    services.Configure<RedisOptions>(cfg =>
        //    {
        //        cfg.ConnectionString = options.ConnectionString;
        //        cfg.DatabaseId = options.DatabaseId;
        //        cfg.Timeout = options.Timeout != TimeSpan.FromSeconds(0) ? options.Timeout : TimeSpan.FromSeconds(600);
        //    });

        //    services.AddSingleton<IRedisCacheDatabaseProvider, RedisCacheDatabaseProvider>();
        //    services.AddTransient<IRedisManager, RedisManager>();

        //    return services;
        //}
    }
}
