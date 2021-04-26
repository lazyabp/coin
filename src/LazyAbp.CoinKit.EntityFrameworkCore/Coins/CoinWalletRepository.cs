using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using LazyAbp.CoinKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinWalletRepository : EfCoreRepository<ICoinKitDbContext, CoinWallet, Guid>, ICoinWalletRepository
    {
        public CoinWalletRepository(IDbContextProvider<ICoinKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<CoinWallet> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => q.UserId == userId)
                .FirstOrDefaultAsync(cancellationToken);
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
                .LongCountAsync(cancellationToken);
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
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<CoinWallet>> GetListQuery(
           Guid? userId = null,
           decimal? minBalance = null,
           decimal? maxBalance = null,
           string filter = null
       )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(minBalance.HasValue, e => e.Balance >= minBalance)
                .WhereIf(maxBalance.HasValue, e => e.Balance < maxBalance);
        }
    }
}