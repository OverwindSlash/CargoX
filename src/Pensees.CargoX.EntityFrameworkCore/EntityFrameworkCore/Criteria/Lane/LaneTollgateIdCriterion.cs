using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class LaneTollgateIdCriterion : ICriterion<Lane>
    {
        private readonly string _tollgateId;

        public LaneTollgateIdCriterion(string tollgateId)
        {
            _tollgateId = tollgateId;
        }

        public IQueryable<Lane> HandleQueryable(IQueryable<Lane> queryable)
        {
            return queryable.Where(lane => lane.TollgateId == _tollgateId);
        }
    }
}
