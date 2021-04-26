using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.CoinKit.Spreads
{
    public interface ISpreadUserRepository : IRepository<SpreadUser, Guid>
    {
        Task<SpreadUser> GetBySpreadCodeAsync(string spreadCode, CancellationToken cancellationToken = default);

        Task<SpreadUser> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<SpreadUser>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}