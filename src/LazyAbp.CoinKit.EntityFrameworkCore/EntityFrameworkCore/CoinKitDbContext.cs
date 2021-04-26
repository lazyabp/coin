using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.CoinKit.EntityFrameworkCore
{
    [ConnectionStringName(CoinKitDbProperties.ConnectionStringName)]
    public class CoinKitDbContext : AbpDbContext<CoinKitDbContext>, ICoinKitDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public CoinKitDbContext(DbContextOptions<CoinKitDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCoinKit();
        }
    }
}