using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.CoinKit.Coins
{
    public interface ICoinOrderRepository : IRepository<CoinOrder, Guid>
    {
        Task<CoinOrder> GetByIdAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<CoinOrder> GetByOrderNoAsync(string orderNO, bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<CoinOrder> GetByTradeNoAsync(string tradeNO, bool includeDetails = false, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            PaymentGateway? gateway = null,
            PaymentStatus? status = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<CoinOrder>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            PaymentGateway? gateway = null,
            PaymentStatus? status = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );
    }
}