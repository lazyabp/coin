using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LazyAbp.CoinKit.MongoDB
{
    [ConnectionStringName(CoinKitDbProperties.ConnectionStringName)]
    public class CoinKitMongoDbContext : AbpMongoDbContext, ICoinKitMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureCoinKit();
        }
    }
}