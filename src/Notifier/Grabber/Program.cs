using Grabber.Grabber;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Shared.Cache;
using Shared.Events;
using Shared.Query;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Grabber
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

                    string connectionString = hostContext.Configuration.GetSection("ConnectionStrings")["MySql"];
                    services.AddTransient<ISubscribeQueries, SubscribeQueries>(provider => new SubscribeQueries(connectionString));
                    //redis
                    services.AddStackExchangeRedisCache(options =>
                    {
                        //var connection = hostContext.Configuration.GetSection("Redis")["Connection"];
                        //options.Configuration = connection;
                        //options.InstanceName = "NotifierInstance";
                        options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions
                        {
                            EndPoints =
                            {
                                { hostContext.Configuration.GetSection("Redis")["Host"], Convert.ToInt32(hostContext.Configuration.GetSection("Redis")["Port"]) }
                            },
                            DefaultDatabase = Convert.ToInt32(hostContext.Configuration.GetSection("Redis")["DatabaseId"])
                        };
                    });

                    services.AddMassTransit(cfg =>
                    {
                        cfg.AddConsumer<FaceGrabber>();
                        cfg.AddConsumer<PersonGrabber>();
                        cfg.AddBus(ConfigureBus);
                    });

                    services.AddTransient<ICacheService, CacheService>();
                    services.AddHostedService<MassTransitConsoleHostedService>();
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
    }
}
