using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Query
{
    public interface ISubscribeQueries
    {
        Task<IEnumerable<Subscribe>> GetAllSubscribes();
    }
}
