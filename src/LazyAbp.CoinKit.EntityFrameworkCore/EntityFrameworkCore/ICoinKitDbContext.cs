using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.CoinKit.EntityFrameworkCore
{
    [ConnectionStringName(CoinKitDbProperties.ConnectionStringName)]
    public interface ICoinKitDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}