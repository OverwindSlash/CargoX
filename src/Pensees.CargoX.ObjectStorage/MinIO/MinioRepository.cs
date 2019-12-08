using Abp.Modules;
using Minio;
using Minio.DataModel;
using Minio.Exceptions;
using Pensees.CargoX.Repository;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pensees.CargoX.ObjectStorage.MinIO
{
    [DependsOn(
        typeof(CargoXCoreModule))]
    public class MinioRepository : IMinioRepository
    {
        private static readonly MinioClient _minio = new MinioClient("play.min.io",
            "Q3AM3UQ867SPQQA43P2F",
            "zuf+tfteSlswRu7BJ86wekitnifILbZam1KYY3TG"
        ).WithSSL();

        //private static readonly MinioClient _minio =
        //    new MinioClient("10.10.1.101:9005",
        //    "minio",
        //    "minio123"
        //);

        public async Task<SaveImageResult> SaveImageByteAsync(SaveImageParam param)
        {
            string defaultLocation = "us-east-1";

            try
            {
                bool isBucketExist = await _minio.BucketExistsAsync(param.BucketName);

                if (!isBucketExist)
                {
                    await _minio.MakeBucketAsync(param.BucketName, defaultLocation);
                }

                param.ImageData.Position = 0;

                await _minio.PutObjectAsync(
                    param.BucketName,
                    param.ImageName,
                    param.ImageData,
                    param.ImageSize,
                    param.ContentType,
                    param.MetaData);

                return new SaveImageResult()
                {
                    BucketName = param.BucketName,
                    ImageName = param.ImageName,
                    Location = defaultLocation
                };
            }
            catch (MinioException e)
            {
                SentrySdk.CaptureException(e);
                throw;
            }
        }

        public async Task<List<BucketInfo>> ListBucketAsync(ListBucketParam param)
        {
            try
            {
                ListAllMyBucketsResult allMyBuckets = await _minio.ListBucketsAsync();

                List<BucketInfo> bucketInfos = new List<BucketInfo>();
                foreach (var bucket in allMyBuckets.Buckets)
                {
                    if (!string.IsNullOrEmpty(param.Keyword) && !bucket.Name.Contains(param.Keyword))
                    {
                        continue;
                    }

                    bucketInfos.Add(new BucketInfo()
                    {
                        BucketName = bucket.Name,
                        CreationDateTime = bucket.CreationDateDateTime
                    });
                }

                return bucketInfos;
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }

        public async Task<GetImageResult> GetImageByteAsync(GetImageParam param)
        {
            try
            {
                GetImageResult result = new GetImageResult();

                await _minio.GetObjectAsync(param.BucketName, param.ImageName,
                    (stream) =>
                    {
                        stream.CopyTo(result.ImageData);
                    });

                return result;
            }
            catch (Exception exception)
            {
                SentrySdk.CaptureException(exception);
                throw;
            }
        }
    }
}
