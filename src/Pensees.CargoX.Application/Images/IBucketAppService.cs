using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Repository;

namespace Pensees.CargoX.Images
{
    public interface IBucketAppService : IApplicationService
    {
        Task<ListBucketResponse> ListBucketAsync(ListBucketRequest request);
    }
}
