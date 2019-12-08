using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using Pensees.CargoX.Repository;

namespace Pensees.CargoX.Images.Dtos
{
    public class ListBucketResponse
    {
        public int BucketCount { get; set; }
        public List<BucketInfo> BucketInfos { get; set; }
    }
}
