﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.System
{
    public interface ISystemAppService : IApplicationService
    {
        Task<ResponseStatus> Register(Register input);
        Task<ResponseStatus> UnRegister(Register input);
        Task<ResponseStatus> Keepalive(Register input);


        Task<SystemTimeDto> Time();
    }
}
