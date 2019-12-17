using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using System.Threading.Tasks;

namespace Pensees.CargoX.Rpc.Host.Services
{
    public class ImageRpcService : ImageRpc.ImageRpcBase
    {
        private readonly ILogger<ImageRpcService> _logger;
        private readonly IImageAppService _imageAppService;

        public ImageRpcService(ILogger<ImageRpcService> logger, 
            IImageAppService imageAppService)
        {
            _logger = logger;
            _imageAppService = imageAppService;
        }

        public override async Task<GetImageWithBytesRpcResponse> GetImageWithBytesRpc(
            GetImageRpcRequest request, ServerCallContext context)
        {
            GetImageWithBytesResponse result = await _imageAppService.GetImageWithBytesAsync(new GetImageRequest()
            {
                BucketName = request.Bucketname,
                ImageName = request.ImageName
            }).ConfigureAwait(false);

            return new GetImageWithBytesRpcResponse()
            {
                ImageData = ByteString.CopyFrom(result.ImageData)
            };
        }

        public override async Task<SaveImageRpcResponse> SaveImageByBase64Rpc(
            SaveImageByBase64RpcRequest request, ServerCallContext context)
        {
            SaveImageResponse result = await _imageAppService.SaveImageByBase64Async(new SaveImageByBase64Request()
            {
                ImageBase64 = request.ImageBase64
            }).ConfigureAwait(false);

            return new SaveImageRpcResponse()
            {
                BucketName = result.BucketName,
                ImageName = result.ImageName,
                Location = result.Location
            };
        }

        public override async Task<SaveImageRpcResponse> SaveImageByBytesRpc(
            SaveImageByBytesRpcRequest request, ServerCallContext context)
        {
            SaveImageResponse result = await _imageAppService.SaveImageByBytesAsync(new SaveImageByBytesRequest()
            {
                ImageBytes = request.ImageData.ToByteArray()
            }).ConfigureAwait(false);

            return new SaveImageRpcResponse()
            {
                BucketName = result.BucketName,
                ImageName = result.ImageName,
                Location = result.Location
            };
        }
    }
}
