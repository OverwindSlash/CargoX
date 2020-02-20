using System;
using System.Collections.Generic;
using System.Text;
using Abp.AutoMapper;
using AutoMapper.Configuration.Annotations;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Entities.Common;

namespace Pensees.CargoX.Faces.Dto
{
    [AutoMap(typeof(SubImageInfoList))]
    public class SubImageInfoDtoList
    {
        public List<SubImageInfoDto> SubImageInfoObject { get; set; }
    }
}
