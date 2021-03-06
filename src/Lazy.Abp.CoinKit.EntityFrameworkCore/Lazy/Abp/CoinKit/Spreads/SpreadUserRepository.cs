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

namespace Lazy.Abp.CoinKit.Spreads
{
    public class SpreadUserRepository : EfCoreRepository<ICoinKitDbContext, SpreadUser, Guid>, ISpreadUserRepository
    {
        public SpreadUserRepository(IDbContextProvider<ICoinKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<SpreadUser> GetBySpreadCodeAsync(string spreadCode, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => q.SpreadCode == spreadCode)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<SpreadUser> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => q.UserId == userId)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? inviterUserId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, inviterUserId, filter);

            return await query
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<SpreadUser>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            Guid? inviterUserId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, inviterUserId, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected async Task<IQueryable<SpreadUser>> GetListQuery(
            Guid? userId = null,
            Guid? inviterUserId = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(inviterUserId.HasValue, e => e.InviterUserId == inviterUserId)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.SpreadCode.Contains(filter)
                );
        }
    }
}