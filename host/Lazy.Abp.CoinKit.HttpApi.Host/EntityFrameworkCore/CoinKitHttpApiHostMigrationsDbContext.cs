using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.CoinKit.EntityFrameworkCore
{
    public class CoinKitHttpApiHostMigrationsDbContext : AbpDbContext<CoinKitHttpApiHostMigrationsDbContext>
    {
        public CoinKitHttpApiHostMigrationsDbContext(DbContextOptions<CoinKitHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureCoinKit();
        }
    }
}
