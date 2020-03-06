using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pensees.CargoX.Entities
{
    public class ResponseStatus
    {
        [Required]
        public string RequestURL { get; set; }
        [Required]
        public int StatusCode { get; set; }
        public string StatusString { get; set; }
        public string Id { get; set; }
        public DateTime LocalTime { get; set; }
    }

    public class ResponseStatusList
    {
        public IList<ResponseStatus> ResponseStatusObject { get; set; } = new List<ResponseStatus>();
    }
}
