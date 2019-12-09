using System;
using System.Collections.Generic;
using System.Text;
using Pensees.CargoX.Repository;

namespace Pensees.CargoX.Images.Dtos
{
    public class GetImageStatusResponse
    {
        public GetImageStatusResponse(GetImageStatusResult result)
        {
            ImageName = result.ImageName;
            Size = result.Size;
            LastModified = result.LastModified;
            ETag = result.ETag;
            ContentType = result.ContentType;
            MetaData = result.MetaData;
        }

        public string ImageName { get; set; }
        public long Size { get; set; }
        public DateTime LastModified { get; set; }
        public string ETag { get; set; }
        public string ContentType { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
    }
}
