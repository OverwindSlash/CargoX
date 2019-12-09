using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.Repository
{
    public class GetImageStatusResult
    {
        public string ImageName { get; set; }
        public long Size { get; set; }
        public DateTime LastModified { get; set; }
        public string ETag { get; set; }
        public string ContentType { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
    }
}
