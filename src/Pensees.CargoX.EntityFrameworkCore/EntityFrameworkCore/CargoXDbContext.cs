using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Pensees.CargoX.Authorization.Roles;
using Pensees.CargoX.Authorization.Users;
using Pensees.CargoX.MultiTenancy;

namespace Pensees.CargoX.EntityFrameworkCore
{
    public class CargoXDbContext : AbpZeroDbContext<Tenant, Role, User, CargoXDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CargoXDbContext(DbContextOptions<CargoXDbContext> options)
            : base(options)
        {
        }
    }
}
