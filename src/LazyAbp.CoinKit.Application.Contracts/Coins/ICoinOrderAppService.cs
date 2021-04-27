using System;
using System.Threading.Tasks;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public interface ICoinOrderAppService : IApplicationService
    {
        Task<CoinOrderDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinOrderDto>> GetListAsync(GetCoinOrderListRequestDto input);

        Task<PagedResultDto<CoinOrderDto>> GetManagementListAsync(GetCoinOrderListRequestDto input);

        Task<CoinOrderDto> CreateAsync(CreateUpdateCoinOrderDto input);

        Task DeleteAsync(Guid id);
    }
}