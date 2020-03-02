using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Pensees.CargoX.Authorization.Roles;
using Pensees.CargoX.Authorization.Users;
using Pensees.CargoX.Entities;
using Pensees.CargoX.MultiTenancy;

namespace Pensees.CargoX.EntityFrameworkCore
{
    public class CargoXDbContext : AbpZeroDbContext<Tenant, Role, User, CargoXDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Tollgate> Tollgates { get; set; }
        public virtual DbSet<Lane> Lanes { get; set; }
        public virtual DbSet<Face> Faces { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public CargoXDbContext(DbContextOptions<CargoXDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Face>()
                .HasMany(p => p.SubImageInfos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Person>()
                .HasMany(p => p.SubImageInfos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
