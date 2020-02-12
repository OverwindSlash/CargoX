using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Abp.IO.Extensions;

namespace Pensees.CargoX.Repository
{
    public class SaveImageParam
    {
        public string BucketName { get; set; }
        public string ImageName { get; set; }
        public Stream ImageData { get; set; }
        public long ImageSize { get; set; }
        public string ContentType { get; set; }
        public Dictionary<string, string> MetaData { get; set; }

        public SaveImageParam(byte[] imageData)
        {
            ImageData = new MemoryStream(imageData);
            ImageSize = imageData.Length;
            BucketName = GenerateBucketName();
            ImageName = GenerateImageName();
            ContentType = "application/octet-stream";
            MetaData = null;
        }

        private string GenerateBucketName()
        {
            return DateTime.Today.ToString("yyyy-MM-dd") ;
        }

        private string GenerateImageName()
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] md5Bytes = md5Hash.ComputeHash(ImageData);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5Bytes.Length; i++)
                {
                    sb.Append(md5Bytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
