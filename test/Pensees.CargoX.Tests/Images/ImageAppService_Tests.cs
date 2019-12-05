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
            SaveImageByBase64Request request = new SaveImageByBase64Request()
            {
                ImageBase64 = ImageLoader.ConvertToBase64("images/image3.jpg")
            };

            SaveImageResponse response = await _imageAppService.SaveImageByBase64Async(request);

            response.Location.ShouldBe("us-east-1");
            response.BucketName.ShouldBe(DateTime.Today.ToString("yyyy-MM-dd"));
            response.ImageName.Length.ShouldBe(32);
        }
    }
}
