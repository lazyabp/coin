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

namespace LazyAbp.CoinKit.Spreads
{
    public class SpreadInviteRepository : EfCoreRepository<ICoinKitDbContext, SpreadInvite, Guid>, ISpreadInviteRepository
    {
        public SpreadInviteRepository(IDbContextProvider<ICoinKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<SpreadInvite>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => q.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, filter);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<SpreadInvite>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<SpreadInvite>> GetListQuery(
            Guid? userId = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(userId.HasValue, e => e.UserId == userId);
        }
    }
}