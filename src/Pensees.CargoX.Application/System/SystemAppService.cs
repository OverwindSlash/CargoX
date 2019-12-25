using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.System
{
    public class SystemAppService : ApplicationService, ISystemAppService
    {
        public Task<ResponseStatus> Register(Register input)
        {
            throw new NotImplementedException();
        }
    }
}
