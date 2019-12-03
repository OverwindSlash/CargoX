using System;
using System.IO;
using System.Text.Json;
using Pensees.CargoX.Images;
using System.Threading.Tasks;
using Pensees.CargoX.Images.Dtos;
using Shouldly;
using Xunit;

namespace Pensees.CargoX.Tests.Images
{
    public class ImageAppService_Tests : CargoXTestBase
    {
        private IImageAppService _imageAppService;

        public ImageAppService_Tests()
        {
            _imageAppService = Resolve<IImageAppService>();
        }

        [Fact]
        public async Task SaveImageBase64_Test()
        {
            SaveImageRequest request = new SaveImageRequest()
            {
                Base64ImageData = ImageLoader.ConvertToBase64("images/image2.png")
            };

            SaveImageResponse response = await _imageAppService.SaveImageByBase64StringAsync(request);

            response.Location.ShouldBe("us-east-1");
            response.BucketName.ShouldBe(DateTime.Today.ToString("yyyy-MM-dd"));
            response.ImageName.Length.ShouldBe(32);
        }
    }
}
