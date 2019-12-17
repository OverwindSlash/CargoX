using Abp.IO.Extensions;
using System;
using System.IO;

namespace Pensees.CargoX.Tests.Images
{
    public class ImageLoader
    {
        public static string ConvertToBase64(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] allBytes = fs.GetAllBytes();
                return Convert.ToBase64String(allBytes);
            }
        }
    }
}
