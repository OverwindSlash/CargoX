using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using Shouldly;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task SaveImageByFormFileAsync_Test()
        {
            using (FileStream fs = new FileStream("images/image2.png", FileMode.Open))
            {
                FormFile file = new FormFile(fs, 0, fs.Length, "file", "image2.png")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "image/png"
                };

                SaveImageResponse response = await _imageAppService.SaveImageByFormFileAsync(file);

                response.Location.ShouldBe("us-east-1");
                response.BucketName.ShouldBe(DateTime.Today.ToString("yyyy-MM-dd"));
                response.ImageName.ShouldBe("384E5061724501F88E9EE4854CEDE6CA");
            }
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

        [Fact]
        public async Task GetImageWithBytesAsync_Test()
        {
            SaveImageByUrlRequest saveRequest = new SaveImageByUrlRequest()
            {
                ImageUrl = "https://www.baidu.com/img/bd_logo1.png?where=super"
            };

            SaveImageResponse saveResponse = await _imageAppService.SaveImageByUrlAsync(saveRequest);

            GetImageRequest getRequest = new GetImageRequest()
            {
                BucketName = saveResponse.BucketName,
                ImageName = saveResponse.ImageName
            };

            GetImageWithBytesResponse getResponse = await _imageAppService.GetImageWithBytesAsync(getRequest);

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] md5Bytes = md5Hash.ComputeHash(getResponse.ImageData);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5Bytes.Length; i++)
                {
                    sb.Append(md5Bytes[i].ToString("X2"));
                }

                sb.ToString().ShouldBe("B15C113AEDDBEB606D938010B88CF8E6");
            }
        }

        [Fact]
        public async Task GetImageStatusAsync_Test()
        {
            SaveImageByUrlRequest saveRequest = new SaveImageByUrlRequest()
            {
                ImageUrl = "https://www.baidu.com/img/bd_logo1.png?where=super"
            };

            SaveImageResponse saveResponse = await _imageAppService.SaveImageByUrlAsync(saveRequest);

            GetImageRequest getRequest = new GetImageRequest()
            {
                BucketName = saveResponse.BucketName,
                ImageName = saveResponse.ImageName
            };

            GetImageStatusResponse getResponse = await _imageAppService.GetImageStatusAsync(getRequest);

            getResponse.ImageName.ShouldBe("B15C113AEDDBEB606D938010B88CF8E6");
            getResponse.Size.ShouldBe(7877);
        }

        [Fact]
        public async Task DownloadImageAsync_Test()
        {
            SaveImageByUrlRequest saveRequest = new SaveImageByUrlRequest()
            {
                ImageUrl = "https://www.baidu.com/img/bd_logo1.png?where=super"
            };

            SaveImageResponse saveResponse = await _imageAppService.SaveImageByUrlAsync(saveRequest);

            DownloadImageRequest downloadRequest = new DownloadImageRequest()
            {
                BucketName = saveResponse.BucketName,
                ImageName = saveResponse.ImageName,
                ImageType = "png"
            };

            FileStreamResult getResponse = await _imageAppService.DownloadImageAsync(downloadRequest);
            getResponse.FileStream.Length.ShouldBe(7877);
        }
    }
}
