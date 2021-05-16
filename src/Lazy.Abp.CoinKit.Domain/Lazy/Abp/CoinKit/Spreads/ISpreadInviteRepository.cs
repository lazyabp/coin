using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.CoinKit.Spreads
{
    public interface ISpreadInviteRepository : IRepository<SpreadInvite, Guid>
    {
        Task<List<SpreadInvite>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<SpreadInvite>> GetListAsync(
            string sorting = null,
            int maxResultCount = 10,
            int skipCount = 0,
            Guid? userId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}