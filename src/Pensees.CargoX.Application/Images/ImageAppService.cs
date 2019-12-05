using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IO.Extensions;
using Microsoft.AspNetCore.Http;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Repository;
using RestSharp.Extensions;
using Sentry;

namespace Pensees.CargoX.Images
{
    public class ImageAppService : ApplicationService, IImageAppService
    {
        private IImageRepository _imageRepository;
        private IHttpContextAccessor _httpContext;

        public ImageAppService(IImageRepository imageRepository, IHttpContextAccessor httpContext)
        {
            _imageRepository = imageRepository;
            _httpContext = httpContext;
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
            throw new NotImplementedException();
        }

        public async Task<SaveImageResponse> SaveImageByBase64Async(SaveImageByBase64Request request)
        {
            PesImage pesImage = PesImage.FromBase64String(request.ImageBase64);

            return await SaveImageBytes(pesImage.ToByteArray());
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
