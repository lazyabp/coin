using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using LazyAbp.CoinKit.Coins;
using LazyAbp.CoinKit.Coupons;
using LazyAbp.CoinKit.Spreads;

namespace LazyAbp.CoinKit.EntityFrameworkCore
{
    [ConnectionStringName(CoinKitDbProperties.ConnectionStringName)]
    public interface ICoinKitDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<CoinAction> CoinActions { get; set; }
        DbSet<CoinOrder> CoinOrders { get; set; }
        DbSet<CoinProduct> CoinProducts { get; set; }
        DbSet<CoinWallet> CoinWallets { get; set; }
        DbSet<CoinWalletLog> CoinWalletLogs { get; set; }
        DbSet<Coupon> Coupons { get; set; }
        DbSet<SpreadInvite> SpreadInvites { get; set; }
        DbSet<SpreadUser> SpreadUsers { get; set; }
    }
}
