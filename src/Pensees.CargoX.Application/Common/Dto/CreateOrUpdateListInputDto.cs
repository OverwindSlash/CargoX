using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.Common.Dto
{
    public class CreateOrUpdateListInputDto<TDto>
    {
        public IList<TDto> List { get; set; }
    }
}
