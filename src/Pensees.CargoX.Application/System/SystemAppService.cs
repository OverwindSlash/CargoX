using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.System
{
    public class SystemAppService : ApplicationService, ISystemAppService
    {
        [AbpAuthorize]
        public Task<ResponseStatus> Register(Register input)
        {
            Trace.WriteLine("VIID/Register");
            return null;
        }
    }
}
