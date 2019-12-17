using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Pensees.CargoX.Configuration;

namespace Pensees.CargoX.Rpc.Host.Startup
{
    [DependsOn(
       typeof(CargoXWebCoreModule))]
    public class CargoXRpcHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CargoXRpcHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CargoXRpcHostModule).GetAssembly());
        }
    }
}
