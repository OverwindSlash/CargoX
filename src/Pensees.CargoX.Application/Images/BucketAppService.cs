using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Repository;

namespace Pensees.CargoX.Images
{
    public class BucketAppService : ApplicationService, IBucketAppService
    {
        private readonly IMinioRepository _minioRepository;

        public BucketAppService(IMinioRepository minioRepository)
        {
            _minioRepository = minioRepository;
        }

        [HttpGet]
        public async Task<ListBucketResponse> ListBucketAsync(ListBucketRequest request)
        {
            var result = await _minioRepository.ListBucketAsync(new ListBucketParam() {Keyword = request.Keyword});

            return new ListBucketResponse()
            {
                BucketCount = result.Count,
                BucketInfos = result
            };
        }
    }
}
