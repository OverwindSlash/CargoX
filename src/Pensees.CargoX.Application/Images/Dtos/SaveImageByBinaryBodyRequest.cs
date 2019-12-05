using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Pensees.CargoX.Images.Dtos
{
    public class SaveImageByBinaryBodyRequest
    {
        public string Extention { get; set; }
    }
}
