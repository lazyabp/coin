using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.CoinPurchaseds.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.CoinPurchaseds
{
    public interface ICoinPurchasedAdminAppService : IApplicationService
    {
        Task<CoinPurchasedDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinPurchasedDto>> GetListAsync(CoinPurchasedListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}