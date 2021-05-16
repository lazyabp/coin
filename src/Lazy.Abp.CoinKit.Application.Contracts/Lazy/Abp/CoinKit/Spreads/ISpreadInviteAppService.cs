using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Spreads.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Spreads
{
    public interface ISpreadInviteAppService : IApplicationService
    {
        Task<SpreadInviteDto> GetAsync(Guid id);

        Task<PagedResultDto<SpreadInviteDto>> GetListAsync(SpreadInviteListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}