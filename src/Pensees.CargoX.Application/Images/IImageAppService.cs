using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Pensees.CargoX.Images.Dtos;

namespace Pensees.CargoX.Images
{
    public interface IImageAppService : IApplicationService
    {
        Task<SaveImageResponse> SaveImageByBase64StringAsync(SaveImageRequest request);
    }
}
