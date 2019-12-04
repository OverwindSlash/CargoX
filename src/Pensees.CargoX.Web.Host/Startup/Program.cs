using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Sentry;

namespace Pensees.CargoX.Web.Host.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (SentrySdk.Init("http://75d6b0a220a342ddb893c6b3b0d33787@192.168.1.8:9000/1"))
            {
                BuildWebHost(args).Run();
            }
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
