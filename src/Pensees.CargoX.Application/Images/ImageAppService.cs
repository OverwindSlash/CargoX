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
using Microsoft.AspNetCore.Mvc;

namespace Pensees.CargoX.Images
{
    public class ImageAppService : ApplicationService, IImageAppService
    {
        private readonly IMinioRepository _minioRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _httpClientFactory;

        public ImageAppService(
            IMinioRepository minioRepository,
            IHttpContextAccessor httpContext,
            IHttpClientFactory httpClientFactory)
        {
            _minioRepository = minioRepository;
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

        public async Task<SaveImageResponse> SaveImageByBytesAsync(SaveImageByBytesRequest request)
        {
            try
            {
                return await SaveImageBytes(request.ImageBytes);
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }

        private async Task<SaveImageResponse> SaveImageBytes(byte[] bytes)
        {
            try
            {
                SaveImageParam param = new SaveImageParam(bytes);
                SaveImageResult result = await _minioRepository.SaveImageByteAsync(param);

                return new SaveImageResponse()
                {
                    Location = result.Location,
                    BucketName = result.BucketName,
                    ImageName = result.ImageName
                };
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }

        public async Task<GetImageWithBytesResponse> GetImageWithBytesAsync(GetImageRequest request)
        {
            try
            {
                ImageLocationParam param = new ImageLocationParam()
                {
                    BucketName = request.BucketName,
                    ImageName = request.ImageName
                };

                GetImageResult result = await _minioRepository.GetImageByteAsync(param);

                return new GetImageWithBytesResponse()
                {
                    ImageData = result.ImageData.GetAllBytes()
                };
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }

        public async Task<GetImageStatusResponse> GetImageStatusAsync(GetImageRequest request)
        {
            try
            {
                ImageLocationParam param = new ImageLocationParam()
                {
                    BucketName = request.BucketName,
                    ImageName = request.ImageName
                };

                GetImageStatusResult result = await _minioRepository.GetImageStatusAsync(param);

                return new GetImageStatusResponse(result);

            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }

        [HttpGet]
        public async Task<FileStreamResult> DownloadImageAsync(DownloadImageRequest request)
        {
            try
            {
                ImageLocationParam param = new ImageLocationParam()
                {
                    BucketName = request.BucketName,
                    ImageName = request.ImageName
                };

                GetImageResult result = await _minioRepository.GetImageByteAsync(param);

                return new FileStreamResult(new MemoryStream(result.ImageData.GetAllBytes()), "image/jpeg");
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }
    }
}
