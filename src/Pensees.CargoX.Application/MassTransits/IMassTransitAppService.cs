using Abp.Application.Services;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.MassTransits
{
    public interface IMassTransitAppService:IApplicationService
    {
        Task NotifyEntityCreated();
    }
}
