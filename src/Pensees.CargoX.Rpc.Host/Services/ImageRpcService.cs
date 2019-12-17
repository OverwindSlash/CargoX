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

        public override async Task<GetImageWithBytesRpcResponse> GetImageWithBytesRpc(GetImageRpcRequest request, ServerCallContext context)
        {
            GetImageWithBytesResponse result = await _imageAppService.GetImageWithBytesAsync(new GetImageRequest()
            {
                BucketName = request.Bucketname,
                ImageName = request.ImageName
            });

            return new GetImageWithBytesRpcResponse()
            {
                ImageData = ByteString.CopyFrom(result.ImageData)
            };
        }
    }
}
