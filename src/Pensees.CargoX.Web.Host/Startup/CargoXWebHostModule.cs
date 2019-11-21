using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Pensees.CargoX.Configuration;

namespace Pensees.CargoX.Web.Host.Startup
{
    [DependsOn(
       typeof(CargoXWebCoreModule))]
    public class CargoXWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CargoXWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CargoXWebHostModule).GetAssembly());
        }
    }
}
