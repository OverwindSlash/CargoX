using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.Repository.Persons
{
    public interface IPersonRepository:IRepository<Person,long>
    {
        Task<IQueryable<Person>> QueryByParams(Dictionary<string, Dictionary<string, string>> parameters, IQueryable<Person> query);
    }
}
