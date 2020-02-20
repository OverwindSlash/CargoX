using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace Pensees.CargoX.Entities.Common
{
    public class SubImageInfoList : Entity<long>
    {

        public List<SubImageInfo> ImageInfoObject { get; set; }
    }
}
