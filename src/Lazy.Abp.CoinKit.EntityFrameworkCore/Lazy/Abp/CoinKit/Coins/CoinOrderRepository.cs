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
    public class CoinOrderRepository : EfCoreRepository<ICoinKitDbContext, CoinOrder, Guid>, ICoinOrderRepository
    {
        public CoinOrderRepository(IDbContextProvider<ICoinKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<CoinOrder>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.Product);
        }

        public async Task<CoinOrder> GetByIdAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .IncludeIf(includeDetails, q => q.Product)
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<CoinOrder> GetByOrderNoAsync(string orderNO, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .IncludeIf(includeDetails, q => q.Product)
                .Where(q => q.OrderNo == orderNO)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<CoinOrder> GetByTradeNoAsync(string tradeNO, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .IncludeIf(includeDetails, q => q.Product)
                .Where(q => q.TradeNo == tradeNO)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            PaymentGateway? gateway = null,
            PaymentStatus? status = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, gateway, status, creationAfter, creationBefore, filter, includeDetails);

            return await query
                .LongCountAsync(cancellationToken);
        }

        public async Task<List<CoinOrder>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            PaymentGateway? gateway = null,
            PaymentStatus? status = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, gateway, status, creationAfter, creationBefore, filter, includeDetails);

            return await query
                .OrderBy(sorting ?? "creationTime DESC")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        protected async Task<IQueryable<CoinOrder>> GetListQuery(
            Guid? userId = null,
            PaymentGateway? gateway = null,
            PaymentStatus? status = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            bool includeDetails = false
        )
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .AsNoTracking()
                .IncludeIf(includeDetails, q => q.Product)
                .WhereIf(userId.HasValue, e => e.CreatorId == userId)
                .WhereIf(gateway.HasValue, e => e.Gateway == gateway)
                .WhereIf(status.HasValue, e => e.Status == status)
                .WhereIf(creationAfter.HasValue, e => e.CreationTime >= creationAfter.Value.Date)
                .WhereIf(creationBefore.HasValue, e => e.CreationTime < creationBefore.Value.AddDays(1).Date)
                .WhereIf(!filter.IsNullOrEmpty(),
                    e => false
                    || e.OrderNo.Contains(filter)
                    || e.TradeNo.Contains(filter)
                );
        }
    }
}