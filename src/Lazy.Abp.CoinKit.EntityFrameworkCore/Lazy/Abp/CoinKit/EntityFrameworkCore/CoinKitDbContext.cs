using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Lazy.Abp.CoinKit.Coins;
using Lazy.Abp.CoinKit.Coupons;
using Lazy.Abp.CoinKit.Spreads;

namespace Lazy.Abp.CoinKit.EntityFrameworkCore
{
    [ConnectionStringName(CoinKitDbProperties.ConnectionStringName)]
    public class CoinKitDbContext : AbpDbContext<CoinKitDbContext>, ICoinKitDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<CoinAction> CoinActions { get; set; }
        public DbSet<CoinOrder> CoinOrders { get; set; }
        public DbSet<CoinProduct> CoinProducts { get; set; }
        public DbSet<CoinWallet> CoinWallets { get; set; }
        public DbSet<CoinWalletLog> CoinWalletLogs { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<SpreadInvite> SpreadInvites { get; set; }
        public DbSet<SpreadUser> SpreadUsers { get; set; }

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
