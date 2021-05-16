using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.CoinKit.Coins
{
    public interface ICoinWalletRepository : IRepository<CoinWallet, Guid>
    {
        Task<CoinWallet> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            decimal? minBalance = null,
            decimal? maxBalance = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<CoinWallet>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            decimal? minBalance = null,
            decimal? maxBalance = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}