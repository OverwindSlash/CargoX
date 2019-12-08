using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.Images.Dtos
{
    public class GetImageWithBytesRequest
    {
        public string BucketName { get; set; }
        public string ImageName { get; set; }
    }
}
