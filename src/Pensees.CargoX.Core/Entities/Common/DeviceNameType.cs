using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pensees.CargoX.Entities
{
    public class DeviceNameType
    {
        [Required]
        [StringLength(100)]
        public string NameValue { get; set; }
    }
}
