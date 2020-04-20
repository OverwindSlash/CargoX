using Pensees.CargoX.Entities;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Cache
{
    public interface ICacheService
    {
        Task<List<Subscribe>> GetAllSubscribesAsync();
        List<Device> GetAllDevices();
        Device GetDeviceById(string id);
    }
}
