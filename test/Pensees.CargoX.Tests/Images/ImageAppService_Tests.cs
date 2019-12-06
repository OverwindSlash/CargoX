using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using Shouldly;
using System;
using System.Threading.Tasks;
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
        public async Task SaveImageByUrlAsync_Test()
        {
            SaveImageByUrlRequest request = new SaveImageByUrlRequest()
            {
                ImageUrl = "https://www.baidu.com/img/bd_logo1.png?where=super"
            };

            SaveImageResponse response = await _imageAppService.SaveImageByUrlAsync(request);

            response.Location.ShouldBe("us-east-1");
            response.BucketName.ShouldBe(DateTime.Today.ToString("yyyy-MM-dd"));
            response.ImageName.ShouldBe("B15C113AEDDBEB606D938010B88CF8E6");
        }

        [Fact]
        public async Task SaveImageByBase64Async_Test()
        {
            SaveImageByBase64Request request = new SaveImageByBase64Request()
            {
                ImageBase64 = ImageLoader.ConvertToBase64("images/image2.png")
            };

            SaveImageResponse response = await _imageAppService.SaveImageByBase64Async(request);

            response.Location.ShouldBe("us-east-1");
            response.BucketName.ShouldBe(DateTime.Today.ToString("yyyy-MM-dd"));
            response.ImageName.ShouldBe("384E5061724501F88E9EE4854CEDE6CA");
        }
    }
}
