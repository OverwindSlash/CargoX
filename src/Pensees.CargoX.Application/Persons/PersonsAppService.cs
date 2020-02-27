using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Persons.Dto;

namespace Pensees.CargoX.Persons
{
    public class PersonsAppService : CargoXAsyncCrudAppService<Person, PersonDto, long, PagedAndSortedResultRequestDto, PersonDto, PersonDto>, IPersonsAppService
    {
        public PersonsAppService(IRepository<Person, long> repository) : base(repository)
        {
        }
    }
}
