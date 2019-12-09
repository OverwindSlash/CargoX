using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.Images.Dtos
{
    public class GetImageRequest
    {
        public string BucketName { get; set; }
        public string ImageName { get; set; }
    }
}
