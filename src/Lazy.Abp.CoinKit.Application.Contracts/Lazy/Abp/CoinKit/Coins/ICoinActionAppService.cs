using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Coins
{
    public interface ICoinActionAppService : IApplicationService
    {
        Task<CoinActionDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinActionDto>> GetListAsync(CoinActionListRequestDto input);

        Task<CoinActionDto> CreateAsync(CoinActionCreateUpdateDto input);

        Task<CoinActionDto> UpdateAsync(Guid id, CoinActionCreateUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}