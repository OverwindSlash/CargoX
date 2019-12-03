using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Reflection.Extensions;

namespace Pensees.CargoX.ObjectStorage
{
    [DependsOn(
        typeof(CargoXCoreModule))]
    public class CargoXObjectStorageModule : AbpModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
        }


        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CargoXObjectStorageModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}
