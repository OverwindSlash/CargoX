using Abp.Application.Services;
using Abp.IO.Extensions;
using Microsoft.AspNetCore.Http;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Repository;
using RestSharp.Extensions;
using Sentry;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.Events.Bus;

namespace Pensees.CargoX.Images
{
    public class ImageAppService : ApplicationService, IImageAppService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _httpClientFactory;

        public ImageAppService(
            IImageRepository imageRepository,
            IHttpContextAccessor httpContext,
            IHttpClientFactory httpClientFactory)
        {
            _imageRepository = imageRepository;
            _httpContext = httpContext;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<SaveImageResponse> SaveImageByBinaryBodyAsync()
        {
            try
            {
                using (Stream stream = _httpContext.HttpContext.Request.Body)
                {
                    return await SaveImageBytes(stream.GetAllBytes());
                }
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }

        public async Task<SaveImageResponse> SaveImageByFormFileAsync(IFormFile file)
        {
            try
            {
                using (Stream stream = file.OpenReadStream())
                {
                    return await SaveImageBytes(stream.ReadAsBytes());
                }
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }

        public async Task<SaveImageResponse> SaveImageByUrlAsync(SaveImageByUrlRequest request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                using (var stream = await client.GetStreamAsync(request.ImageUrl))
                {
                    return await SaveImageBytes(stream.GetAllBytes());
                }
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }

        public async Task<SaveImageResponse> SaveImageByBase64Async(SaveImageByBase64Request request)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(request.ImageBase64);

                return await SaveImageBytes(bytes);
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }

        private async Task<SaveImageResponse> SaveImageBytes(byte[] bytes)
        {
            SaveImageParam param = new SaveImageParam(bytes);
            SaveImageResult result = await _imageRepository.SaveImageByteAsync(param);

            return new SaveImageResponse()
            {
                Location = result.Location,
                BucketName = result.BucketName,
                ImageName = result.ImageName
            };
        }
    }
}
