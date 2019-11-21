using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Pensees.CargoX.EntityFrameworkCore
{
    public static class CargoXDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CargoXDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CargoXDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
