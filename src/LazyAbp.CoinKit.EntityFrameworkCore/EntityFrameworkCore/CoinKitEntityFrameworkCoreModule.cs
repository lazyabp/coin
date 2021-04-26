using LazyAbp.CoinKit.Spreads;
using LazyAbp.CoinKit.Coupons;
using LazyAbp.CoinKit.Coins;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.CoinKit.EntityFrameworkCore
{
    [DependsOn(
        typeof(CoinKitDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class CoinKitEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CoinKitDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<CoinAction, CoinActionRepository>();
                options.AddRepository<CoinOrder, CoinOrderRepository>();
                options.AddRepository<CoinProduct, CoinProductRepository>();
                options.AddRepository<CoinWallet, CoinWalletRepository>();
                options.AddRepository<CoinWalletLog, CoinWalletLogRepository>();
                options.AddRepository<Coupon, CouponRepository>();
                options.AddRepository<SpreadInvite, SpreadInviteRepository>();
                options.AddRepository<SpreadUser, SpreadUserRepository>();
            });
        }
    }
}
