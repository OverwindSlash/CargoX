using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Pensees.CargoX.Repository
{
    public interface IImageRepository : IRepository
    {
        Task<SaveImageResult> SaveImageByteAsync(SaveImageParam param);
    }
}
