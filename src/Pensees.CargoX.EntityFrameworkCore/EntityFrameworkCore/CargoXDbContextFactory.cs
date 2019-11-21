using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pensees.CargoX.Configuration;
using Pensees.CargoX.Web;

namespace Pensees.CargoX.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CargoXDbContextFactory : IDesignTimeDbContextFactory<CargoXDbContext>
    {
        public CargoXDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CargoXDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CargoXDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CargoXConsts.ConnectionStringName));

            return new CargoXDbContext(builder.Options);
        }
    }
}
