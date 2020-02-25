using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.Common
{
    public class PagedAndSortedRequestDto : PagedAndSortedResultRequestDto
    {
        public Dictionary<string, Dictionary<string, string>> Parameters { get; set; }
    }
}
