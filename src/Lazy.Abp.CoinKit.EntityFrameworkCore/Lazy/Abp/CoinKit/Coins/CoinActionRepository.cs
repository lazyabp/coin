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
    public class CoinActionRepository : EfCoreRepository<ICoinKitDbContext, CoinAction, Guid>, ICoinActionRepository
    {
        public CoinActionRepository(IDbContextProvider<ICoinKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<CoinAction> GetByActionTypeAsync(CoinActionType actionType, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => q.ActionType == actionType)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<int> GetCountAsync(
            CoinActionType? actionType = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(actionType, filter);

            return await query
                .CountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<CoinAction>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            CoinActionType? actionType = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(actionType, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected async Task<IQueryable<CoinAction>> GetListQuery(
            CoinActionType? actionType = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(actionType.HasValue, e => e.ActionType == actionType)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.Title.Contains(filter)
                );
        }
    }
}