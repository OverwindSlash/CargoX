using Pensees.CargoX.Entities;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grabber.Grabber
{
    public interface IGrabber<TEvent>
    {
        Task<List<Subscribe>> GetALLSubscribes(TEvent createEvent);
    }
}
