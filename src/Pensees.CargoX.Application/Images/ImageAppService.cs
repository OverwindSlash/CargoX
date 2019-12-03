using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Repository;

namespace Pensees.CargoX.Images
{
    public class ImageAppService : ApplicationService, IImageAppService
    {
        private IImageRepository _imageRepository;

        public ImageAppService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<SaveImageResponse> SaveImageByBase64StringAsync(SaveImageRequest request)
        {
            PesImage pesImage = PesImage.FromBase64String(request.Base64ImageData);

            SaveImageParam param = new SaveImageParam(pesImage.ToByteArray());
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
