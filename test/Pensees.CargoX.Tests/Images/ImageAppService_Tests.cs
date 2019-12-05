using System;
using System.IO;
using System.Text.Json;
using Pensees.CargoX.Images;
using System.Threading.Tasks;
using Pensees.CargoX.Images.Dtos;
using RestSharp;
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

        //[Fact]
        //public async Task SaveImageByBinaryBodyAsync_Test()
        //{
        //    var client = new RestClient("http://localhost:21021");

        //    var request = new RestRequest("VIID/Image/SaveImageByBinaryBody");
        //    request.AddFile("file", "Images/Image1.png");

        //    // execute the request
        //    var response = client.Post(request);
        //    var content = response.Content; // raw content as string

        //    SaveImageResponse saveImageResponse = JsonSerializer.Deserialize<SaveImageResponse>(content);
        //}

        [Fact]
        public async Task SaveImageByBase64Async_Test()
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
