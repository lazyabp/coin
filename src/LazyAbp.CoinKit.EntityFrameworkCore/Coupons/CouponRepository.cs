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

namespace LazyAbp.CoinKit.Coupons
{
    public class CouponRepository : EfCoreRepository<ICoinKitDbContext, Coupon, Guid>, ICouponRepository
    {
        public CouponRepository(IDbContextProvider<ICoinKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Coupon> GetBySerialNumberAsync(string serialNumber, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .Where(q => q.SerialNumber == serialNumber)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync(
            bool? isActive = null,
            bool? isClaimed = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(isActive, isClaimed, filter);

            return await query
                .CountAsync(cancellationToken);
        }

        public async Task<List<Coupon>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            bool? isActive = null,
            bool? isClaimed = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(isActive, isClaimed, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<Coupon>> GetListQuery(
            bool? isActive = null,
            bool? isClaimed = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                .WhereIf(isClaimed.HasValue, e => e.UserId.HasValue)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.SerialNumber.Contains(filter)
                );
        }
    }
}