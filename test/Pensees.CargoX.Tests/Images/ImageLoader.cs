using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Abp.IO.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;

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
