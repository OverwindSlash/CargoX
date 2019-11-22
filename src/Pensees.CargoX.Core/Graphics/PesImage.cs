using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Pensees.CargoX.Graphics
{
    public class PesImage : Entity<long>
    {
        private Image<Rgba32> _innerImage;

        private PesImage(Image<Rgba32> innerImage)
        {
            _innerImage = innerImage;
        }

        public static PesImage FromBase64String(string base64Str)
        {
            if (string.IsNullOrEmpty(base64Str))
            {
                throw new ArgumentException("Invalid base64 string.");
            }

            byte[] _bytesArray = Convert.FromBase64String(base64Str);
            var image = Image<Rgba32>.Load(_bytesArray);
            return new PesImage(image);
        }
    }
}
