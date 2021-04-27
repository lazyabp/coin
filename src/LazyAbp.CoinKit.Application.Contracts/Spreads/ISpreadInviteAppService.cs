using System;
using System.Threading.Tasks;
using LazyAbp.CoinKit.Spreads.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Spreads
{
    public interface ISpreadInviteAppService : IApplicationService
    {
        Task<SpreadInviteDto> GetAsync(Guid id);

        Task<PagedResultDto<SpreadInviteDto>> GetListAsync(GetSpreadInviteListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}