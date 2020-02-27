using System.Collections.Generic;
using Abp.AutoMapper;
using Pensees.CargoX.Entities.Common;

namespace Pensees.CargoX.Common.Dto
{
    [AutoMap(typeof(SubImageInfoList))]
    public class SubImageInfoDtoList
    {
        public List<SubImageInfoDto> SubImageInfoObject { get; set; }
    }
}
