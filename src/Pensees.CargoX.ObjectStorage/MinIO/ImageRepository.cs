using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Abp.Modules;
using Minio;
using Minio.Exceptions;
using Pensees.CargoX.Repository;

namespace Pensees.CargoX.ObjectStorage.MinIO
{
    [DependsOn(
        typeof(CargoXCoreModule))]
    public class ImageRepository : IImageRepository
    {
        private static MinioClient minio =
            new MinioClient("10.10.1.101:9005",
            "minio",
            "minio123"
        );

        public async Task<SaveImageResult> SaveImageByteAsync(SaveImageParam param)
        {
            string defaultLocation = "us-east-1";

            try
            {
                bool isBucketExist = await minio.BucketExistsAsync(param.BucketName);

                if (!isBucketExist)
                {
                    await minio.MakeBucketAsync(param.BucketName, defaultLocation);
                }

                param.ImageData.Position = 0;

                await minio.PutObjectAsync(
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
