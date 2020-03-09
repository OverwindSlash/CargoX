using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Images.Dtos;

namespace Pensees.CargoX.Images
{
    public interface IImageAppService : IApplicationService
    {
        Task<SaveImageResponse> SaveImageByBinaryBodyAsync();

        Task<SaveImageResponse> SaveImageByFormFileAsync(IFormFile file);

        Task<SaveImageResponse> SaveImageByUrlAsync(SaveImageByUrlRequest request);

        Task<SaveImageResponse> SaveImageByBase64Async(SaveImageByBase64Request request);

        Task<SaveImageResponse> SaveImageByBytesAsync(SaveImageByBytesRequest request);

        Task<GetImageWithBytesResponse> GetImageWithBytesAsync(GetImageRequest request);
        Task<GetImageBase64Response> GetImageBase64Async(GetImageRequest request);

        Task<GetImageStatusResponse> GetImageStatusAsync(GetImageRequest request);

        Task<FileStreamResult> DownloadImageAsync(DownloadImageRequest request);
        Task GetSubImageInfoDtoList(List<SubImageInfoDto> subImageInfoDtos);
    }
}
