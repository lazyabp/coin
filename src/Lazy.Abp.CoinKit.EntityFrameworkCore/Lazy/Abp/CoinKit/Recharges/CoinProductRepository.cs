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

namespace Lazy.Abp.CoinKit.Recharges
{
    public class CoinProductRepository : EfCoreRepository<ICoinKitDbContext, CoinProduct, Guid>, ICoinProductRepository
    {
        public CoinProductRepository(IDbContextProvider<ICoinKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<CoinProduct>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => ids.Contains(q.Id))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            bool? isActive = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(isActive, minPrice, maxPrice, creationAfter, creationBefore, filter);

            return await query
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<CoinProduct>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            bool? isActive = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(isActive, minPrice, maxPrice, creationAfter, creationBefore, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected async Task<IQueryable<CoinProduct>> GetListQuery(
            bool? isActive = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                .WhereIf(minPrice.HasValue, e => e.SalePrice >= minPrice)
                .WhereIf(maxPrice.HasValue, e => e.SalePrice < maxPrice)
                .WhereIf(creationAfter.HasValue, e => e.CreationTime >= creationAfter.Value.Date)
                .WhereIf(creationBefore.HasValue, e => e.CreationTime < creationBefore.Value.AddDays(1).Date)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.Name.Contains(filter)
                    || e.Description.Contains(filter)
                );
        }
    }
}