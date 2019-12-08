using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Pensees.CargoX.Repository
{
    public interface IMinioRepository : IRepository
    {
        Task<SaveImageResult> SaveImageByteAsync(SaveImageParam param);

        Task<List<BucketInfo>> ListBucketAsync(ListBucketParam param);

        Task<GetImageResult> GetImageByteAsync(GetImageParam param);
    }
}
