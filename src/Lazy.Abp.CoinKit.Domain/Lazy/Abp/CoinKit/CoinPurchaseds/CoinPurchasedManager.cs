using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace Lazy.Abp.CoinKit.CoinPurchaseds
{
    public class CoinPurchasedManager : DomainService, IUnitOfWorkEnabled
    {
        private readonly ICoinPurchasedRepository _repository;

        public CoinPurchasedManager(ICoinPurchasedRepository repository)
        {
            _repository = repository;
        }

        public async Task<CoinPurchased> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<CoinPurchased> GetAsync(Guid id, Guid? tenantId)
        {
            using (CurrentTenant.Change(tenantId))
            {
                return await _repository.GetAsync(id);
            }
        }
                
        [UnitOfWork]
        public async Task<CoinPurchased> CreateAsync(
            Guid? tenantId,
            Guid userId,
            Guid coinProductId,
            int quantity,
            string orderId,
            int coinCount,
            decimal paidAmount
        )
        {
            var coinPurchases = new CoinPurchased(GuidGenerator.Create(), tenantId, userId, coinProductId, quantity, orderId, coinCount, paidAmount);

            return await _repository.InsertAsync(coinPurchases);
        }
    }
}
