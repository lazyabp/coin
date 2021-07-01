using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.CoinKit.Coins
{
    public class CoinWalletRepository : EfCoreRepository<ICoinKitDbContext, CoinWallet, Guid>, ICoinWalletRepository
    {
        public CoinWalletRepository(IDbContextProvider<ICoinKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<CoinWallet> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(q => q.UserId == userId)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<CoinWallet>> GetByUserIdAsync(IEnumerable<Guid> userIds, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(q => userIds.Contains(q.UserId))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            decimal? minBalance = null,
            decimal? maxBalance = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, minBalance, maxBalance, filter);

            return await query
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<CoinWallet>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            decimal? minBalance = null,
            decimal? maxBalance = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, minBalance, maxBalance, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected async Task<IQueryable<CoinWallet>> GetListQuery(
           Guid? userId = null,
           decimal? minBalance = null,
           decimal? maxBalance = null,
           string filter = null
       )
        {
            return (await GetDbSetAsync())
                .AsNoTracking()
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(minBalance.HasValue, e => e.Balance >= minBalance)
                .WhereIf(maxBalance.HasValue, e => e.Balance < maxBalance);
        }
    }
}