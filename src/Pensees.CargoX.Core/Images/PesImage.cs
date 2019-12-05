﻿using System;
using System.IO;
using Abp.Domain.Entities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace Pensees.CargoX.Images
{
    public class PesImage : Entity<long>
    {
        private Image _innerImage;

        private PesImage(Image innerImage)
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
            var image = Image.Load(_bytesArray);
            return new PesImage(image);
        }

        public byte[] ToByteArray()
        {
            using (var ms = new MemoryStream())
            {
                _innerImage.Save(ms, PngFormat.Instance);
                return ms.ToArray();
            }
        }
    }
}
