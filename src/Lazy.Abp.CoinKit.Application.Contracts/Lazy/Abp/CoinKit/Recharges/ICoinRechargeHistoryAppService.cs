using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Recharges.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Recharges
{
    public interface ICoinRechargeHistoryAppService : IApplicationService
    {
        Task<CoinRechargeHistoryDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinRechargeHistoryDto>> GetListAsync(CoinRechargeHistoryListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}