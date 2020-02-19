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
        public Task<ResponseStatus> UnRegister(Register input)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseStatus> Keepalive(Register input)
        {
            throw new NotImplementedException();
        }

        //[AbpAuthorize]
        public async Task<SystemTimeDto> Time()
        {
            var systemTime = await SystemTime.GetSystemTime().ConfigureAwait(false);
            var time = new SystemTimeDto();
            time.LocalTime = systemTime.LocalTime;
            time.TimeZone = systemTime.TimeZone;
            time.VIIDServerID = "DE01195";
            time.TimeMode = "1";
            return time;
        }

    }
}
