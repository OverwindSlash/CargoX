using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities.Common;
using Pensees.CargoX.Entities.Faces;
using Pensees.CargoX.Faces.Dto;
using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Repository.Faces;

namespace Pensees.CargoX.Faces
{
    public class FaceAppService : AsyncCrudAppService<Face, FaceRequiredDto, long, PagedResultRequestDto, FaceRequiredDto, FaceRequiredDto>, IFaceAppService
    {
        private readonly IFaceRepository _faceRepository;
        public FaceAppService(IFaceRepository faceRepository) : base(faceRepository)
        {
            _faceRepository = faceRepository;
        }

        public async Task<ListResultDto<FaceDto>> QuesyByParams(Dictionary<string, string> parameters)
        {
            var faces = await _faceRepository.QueryByParams(parameters).ConfigureAwait(false);
            return new ListResultDto<FaceDto>(ObjectMapper.Map<List<FaceDto>>(faces));
        private readonly IRepository<Face, long> _faceRepository;
        private readonly IImageAppService _imageAppService;

        public FaceAppService(
            IRepository<Face, long> faceRepository,
            IImageAppService imageAppService
            ) : base(faceRepository)
        {
            _faceRepository = faceRepository;
            _imageAppService = imageAppService;
        }

        public override async Task<FaceRequiredDto> CreateAsync(FaceRequiredDto input)
        {
            foreach (var subImageInfoDto in input.SubImageList)
            {
                SaveImageByBase64Request request = new SaveImageByBase64Request()
                {
                    ImageBase64 = subImageInfoDto.Data
                };
                
                SaveImageResponse response = await _imageAppService.SaveImageByBase64Async(request);

                subImageInfoDto.NodeId = response.BucketName;
                subImageInfoDto.ImageKey = response.ImageName;
            }

            return await base.CreateAsync(input);
        }

        public override async Task<FaceRequiredDto> GetAsync(EntityDto<long> input)
        {
            Face face = _faceRepository.GetAllIncluding(t => t.SubImageList)
                .SingleOrDefault(f => f.Id == input.Id);

            foreach (var subImageInfo in face.SubImageList)
            {
                GetImageRequest request = new GetImageRequest()
                {
                    BucketName = subImageInfo.NodeId,
                    ImageName = subImageInfo.ImageKey
                };

                GetImageWithBytesResponse response = await _imageAppService.GetImageWithBytesAsync(request);
                subImageInfo.Data = Convert.ToBase64String(response.ImageData);
            }

            return MapToEntityDto(face);
        }
    }
}
