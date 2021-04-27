using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.CoinKit.Coins
{
    public interface ICoinActionRepository : IRepository<CoinAction, Guid>
    {
        Task<CoinAction> GetByActionTypeAsync(CoinActionType actionType, CancellationToken cancellationToken = default);

        Task<int> GetCountAsync(
            CoinActionType? actionType = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<CoinAction>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            CoinActionType? actionType = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}