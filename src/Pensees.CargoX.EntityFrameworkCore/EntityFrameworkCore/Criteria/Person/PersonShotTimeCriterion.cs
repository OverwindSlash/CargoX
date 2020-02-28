﻿using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class PersonShotTimeCriterion : ICriterion<Person>
    {
        private readonly Dictionary<string, string> _conditions;

        public PersonShotTimeCriterion(Dictionary<string, string> conditions)
        {
            _conditions = conditions;
        }
        public IQueryable<Person> HandleQueryable(IQueryable<Person> queryable)
        {
            foreach (var condition in _conditions)
            {
                switch (condition.Key)
                {
                    case "=":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime == Convert.ToDateTime(condition.Value)));
                        break;
                    case "<>":
                    case "!=":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime != Convert.ToDateTime(condition.Value)));
                        break;
                    case ">":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime > Convert.ToDateTime(condition.Value)));
                        break;
                    case "<":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime < Convert.ToDateTime(condition.Value)));
                        break;
                    case ">=":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime >= Convert.ToDateTime(condition.Value)));
                        break;
                    case "<=":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime <= Convert.ToDateTime(condition.Value)));
                        break;
                    default:
                        break;
                }
            }
            return queryable;
        }
    }
}
