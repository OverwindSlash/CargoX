using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Cache;
using Shared.Redis;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Notifier
{
    class Program
    {
        public static AppConfig AppConfig { get; set; }
        static async Task Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddEnvironmentVariables();

                    if (args != null)
                        config.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<AppConfig>(hostContext.Configuration.GetSection("AppConfig"));

                    //redis
                    //services.Configure<RedisOptions>(hostContext.Configuration.GetSection("RedisOptions"));
                    var redis = hostContext.Configuration.GetSection("Redis");
                    //var redisOptions = new RedisOptions
                    //{
                    //    ConnectionString = redis["ConnectionString"],
                    //    DatabaseId = Convert.ToInt32(redis["DatabaseId"]),
                    //    Timeout = TimeSpan.FromSeconds(Convert.ToInt32(redis["Timeout"]))
                    //};
                    services.AddRedis(cfg=> {
                        cfg.ConnectionString = redis["ConnectionString"];
                        cfg.DatabaseId = Convert.ToInt32(redis["DatabaseId"]);
                        cfg.Timeout = TimeSpan.FromSeconds(Convert.ToInt32(redis["Timeout"]));
                    });
                    //services.AddStackExchangeRedisCache(options =>
                    //{
                    //    options.Configuration = "localhost";
                    //    //options.InstanceName = "NotifierInstance";
                    //});

                    services.AddMassTransit(cfg =>
                    {
                        cfg.AddConsumer<Notifier>();
                        cfg.AddBus(ConfigureBus);
                        //cfg.AddRequestClient<IsItTime>();
                    });

                    services.AddTransient<ICacheService, CacheService>();
                    services.AddTransient<ITimerParam, TimerParam>();
                    services.AddHostedService<MassTransitConsoleHostedService>();
                    //services.AddHostedService<TimeService>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                });

            if (isService)
            {
                await builder.UseWindowsService().Build().RunAsync();
                //await builder.UseSystemd().Build().RunAsync(); // For Linux, replace the nuget package: "Microsoft.Extensions.Hosting.WindowsServices" with "Microsoft.Extensions.Hosting.Systemd", and then use this line instead
            }
            else
            {
                await builder.RunConsoleAsync();
            }

        }

        static IBusControl ConfigureBus(IServiceProvider provider)
        {
            AppConfig = provider.GetRequiredService<IOptions<AppConfig>>().Value;
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(AppConfig.Host, AppConfig.VirtualHost, h =>
                {
                    h.Username(AppConfig.Username);
                    h.Password(AppConfig.Password);
                    
                });

                cfg.ConfigureEndpoints(provider);
            });
        }

        static RedisOptions ConfigureRedis(IServiceProvider provider)
        {
            var redisOptions = provider.GetRequiredService<IOptions<RedisOptions>>().Value;
            return new RedisOptions
            {
                ConnectionString = redisOptions.ConnectionString,
                DatabaseId = redisOptions.DatabaseId,
                Timeout = redisOptions.Timeout
            };
        }
    }
}
