using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.Events.Bus;
using Abp.Events.Bus.Exceptions;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Pensees.CargoX.Authorization;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Faces.Dto;
using Pensees.CargoX.Service;
using Sentry;

namespace Pensees.CargoX
{
    [DependsOn(
        typeof(CargoXCoreModule), 
        typeof(CargoXServiceModule),
        typeof(AbpAutoMapperModule))]
    public class CargoXApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CargoXAuthorizationProvider>();

            EventBus.Default.Register<AbpHandledExceptionData>(eventData =>
            {
                SentrySdk.CaptureException(eventData.Exception);
            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CargoXApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<FaceDto, Face>()
                    .ForMember(face => face.SubImageInfos,
                        opt => opt.MapFrom(
                            dto => dto.SubImageList.SubImageInfoObject));
            });
        }
    }
}
