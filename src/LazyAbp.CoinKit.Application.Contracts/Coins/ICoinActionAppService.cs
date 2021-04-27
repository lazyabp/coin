using System;
using System.Threading.Tasks;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public interface ICoinActionAppService : IApplicationService
    {
        Task<CoinActionDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinActionDto>> GetListAsync(GetCoinActionListRequestDto input);

        Task<CoinActionDto> CreateAsync(CreateUpdateCoinActionDto input);

        Task<CoinActionDto> UpdateAsync(Guid id, CreateUpdateCoinActionDto input);

        Task DeleteAsync(Guid id);
    }
}