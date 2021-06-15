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
    public class CoinRechargeHistoryRepository : EfCoreRepository<ICoinKitDbContext, CoinRechargeHistory, Guid>, ICoinRechargeHistoryRepository
    {
        public CoinRechargeHistoryRepository(IDbContextProvider<ICoinKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<CoinRechargeHistory>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.CoinProduct);
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? coinProductId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, coinProductId, minPaidAmount, maxPaidAmount, creationAfter, creationBefore, filter);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<CoinRechargeHistory>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            Guid? coinProductId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, coinProductId, minPaidAmount, maxPaidAmount, creationAfter, creationBefore, filter);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<CoinRechargeHistory>> GetListQuery(
            Guid? userId = null,
            Guid? coinProductId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null
        )
        {
            var dbSet = await GetDbSetAsync();

            return (await GetQueryableAsync())
                .Include(q => q.CoinProduct)
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(coinProductId.HasValue, e => e.CoinProductId == coinProductId)
                .WhereIf(minPaidAmount.HasValue, e => e.PaidAmount >= minPaidAmount)
                .WhereIf(maxPaidAmount.HasValue, e => e.PaidAmount <= maxPaidAmount)
                .WhereIf(creationAfter.HasValue, e => e.CreationTime >= creationAfter.Value.Date)
                .WhereIf(creationBefore.HasValue, e => e.CreationTime < creationBefore.Value.AddDays(1).Date)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.OrderId.Contains(filter)
                    || e.CoinProduct.Name.Contains(filter)
                );
        }
    }
}