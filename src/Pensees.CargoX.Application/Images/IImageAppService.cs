using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using Pensees.CargoX.Images.Dtos;

namespace Pensees.CargoX.Images
{
    public interface IImageAppService : IApplicationService
    {
        Task<SaveImageResponse> SaveImageByBinaryBodyAsync();

        Task<SaveImageResponse> SaveImageByFormFileAsync(IFormFile file);

        Task<SaveImageResponse> SaveImageByUrlAsync(SaveImageByUrlRequest request);

        Task<SaveImageResponse> SaveImageByBase64Async(SaveImageByBase64Request request);

        Task<GetImageWithBytesResponse> GetImageWithBytes(GetImageWithBytesRequest request);
    }
}
