using Lazy.Abp.CoinKit.Recharges;
using Lazy.Abp.CoinKit.Spreads;
using Lazy.Abp.CoinKit.Coupons;
using Lazy.Abp.CoinKit.Coins;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lazy.Abp.CoinKit.EntityFrameworkCore
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
                options.AddRepository<CoinProduct, CoinProductRepository>();
                options.AddRepository<CoinWallet, CoinWalletRepository>();
                options.AddRepository<CoinWalletLog, CoinWalletLogRepository>();
                options.AddRepository<Coupon, CouponRepository>();
                options.AddRepository<SpreadInvite, SpreadInviteRepository>();
                options.AddRepository<SpreadUser, SpreadUserRepository>();
                options.AddRepository<CoinRechargeHistory, CoinRechargeHistoryRepository>();
            });
        }
    }
}
