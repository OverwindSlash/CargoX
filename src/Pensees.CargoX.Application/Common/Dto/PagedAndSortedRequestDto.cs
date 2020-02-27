using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Pensees.CargoX.Common.Dto
{
    public class PagedAndSortedRequestDto : PagedAndSortedResultRequestDto
    {
        public Dictionary<string, Dictionary<string, string>> Parameters { get; set; }
    }
}
