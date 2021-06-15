using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.CoinKit.Recharges
{
    public interface ICoinProductRepository : IRepository<CoinProduct, Guid>
    {
        Task<List<CoinProduct>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            bool? isActive = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            DateTime? creationAfter = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<CoinProduct>> GetListAsync(
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
        );
    }
}