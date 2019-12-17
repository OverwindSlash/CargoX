using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;

namespace Pensees.CargoX.Web.Host.Startup
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder RegisterConsul(
            this IApplicationBuilder app,
            IHostApplicationLifetime lifetime,
            ServiceEntity serviceEntity)
        {
            var consulClient = new ConsulClient(x =>
                x.Address = new Uri($@"http://{serviceEntity.ConsulIP}:{serviceEntity.ConsulPort}"));

            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                Interval = TimeSpan.FromSeconds(10),
                HTTP = $"http://{serviceEntity.IP}:{serviceEntity.Port}/api/health",
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] {httpCheck},
                ID = Guid.NewGuid().ToString(),
                Name = serviceEntity.ServiceName,
                Address = serviceEntity.IP,
                Port = serviceEntity.Port,
                Tags = new[]{$"urlprefix-/{serviceEntity.ServiceName}"}
            };

            consulClient.Agent.ServiceRegister(registration).Wait();
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }
    }

    public class ServiceEntity
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public string ServiceName { get; set; }
        public string ConsulIP { get; set; }
        public int ConsulPort { get; set; }
    }
}
