using System.ComponentModel.DataAnnotations;

namespace Pensees.CargoX.Entities
{
    public class DeviceIDType
    {
        [Required]
        [StringLength(20)]
        public string TypeValue { get; set; }
    }
}