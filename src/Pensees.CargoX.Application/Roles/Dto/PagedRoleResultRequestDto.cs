using Abp.Application.Services.Dto;

namespace Pensees.CargoX.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

