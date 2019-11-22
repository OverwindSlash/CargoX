using System;
using System.Collections.Generic;
using System.Text;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Pensees.CargoX.Service
{
    [DependsOn(
        typeof(CargoXCoreModule)
        )]
    public class CargoXServiceModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CargoXServiceModule).GetAssembly());
        }
    }
}
