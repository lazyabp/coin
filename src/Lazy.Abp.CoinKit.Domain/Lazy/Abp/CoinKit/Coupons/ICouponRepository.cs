using Lazy.Abp.CoinKit.Coins;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.CoinKit.Coupons
{
    public interface ICouponRepository : IRepository<Coupon, Guid>
    {
        Task<Coupon> GetBySerialNumberAsync(string serialNumber, CancellationToken cancellationToken = default);

        Task<int> GetCountAsync(
            bool? isActive = null,
            bool? isClaimed = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<Coupon>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            bool? isActive = null,
            bool? isClaimed = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}