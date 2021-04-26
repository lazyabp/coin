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
            });
        }
    }
}