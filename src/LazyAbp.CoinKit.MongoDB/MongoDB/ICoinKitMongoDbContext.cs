using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LazyAbp.CoinKit.MongoDB
{
    [ConnectionStringName(CoinKitDbProperties.ConnectionStringName)]
    public interface ICoinKitMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
