using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Recharges.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Recharges
{
    public interface ICoinProductAppService : IApplicationService
    {
        Task<CoinProductDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinProductDto>> GetListAsync(CoinProductListRequestDto input);

        Task<CoinProductDto> CreateAsync(CoinProductCreateUpdateDto input);

        Task<CoinProductDto> UpdateAsync(Guid id, CoinProductCreateUpdateDto input);

        Task DeleteAsync(Guid id);
    }
}