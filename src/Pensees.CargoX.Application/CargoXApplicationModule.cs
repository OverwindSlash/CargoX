﻿using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Pensees.CargoX.Authorization;

namespace Pensees.CargoX
{
    [DependsOn(
        typeof(CargoXCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CargoXApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CargoXAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CargoXApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
