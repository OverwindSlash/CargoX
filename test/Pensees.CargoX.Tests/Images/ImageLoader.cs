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

        //public static string ConvertToBase64(string path)
        //{
        //    using (FileStream fs = File.OpenRead(path))
        //    {
        //        Image<Rgba32> image = Image.Load<Rgba32>(fs, out IImageFormat format);

        //        string nonStdBase64Str = image.ToBase64String(format);
        //        int startPosition = nonStdBase64Str.IndexOf(",", StringComparison.Ordinal) + 1;

        //        return nonStdBase64Str.Substring(startPosition);
        //    }
        //}
    }
}
