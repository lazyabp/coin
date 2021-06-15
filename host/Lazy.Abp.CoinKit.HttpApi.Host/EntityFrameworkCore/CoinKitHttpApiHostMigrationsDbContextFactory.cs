using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lazy.Abp.CoinKit.EntityFrameworkCore
{
    public class CoinKitHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CoinKitHttpApiHostMigrationsDbContext>
    {
        public CoinKitHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CoinKitHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("CoinKit"));

            return new CoinKitHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
