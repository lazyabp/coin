using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Coins
{
    public interface ICoinOrderAppService : IApplicationService
    {
        Task<CoinOrderDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinOrderDto>> GetListAsync(CoinOrderListRequestDto input);

        Task<PagedResultDto<CoinOrderDto>> GetManagementListAsync(CoinOrderListRequestDto input);

        Task<CoinOrderDto> CreateAsync(CoinOrderCreateUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}