using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Coins
{
    public interface ICoinProductAppService : IApplicationService
    {
        Task<CoinProductDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinProductDto>> GetListAsync(GetCoinProductListRequestDto input);

        Task<CoinProductDto> CreateAsync(CreateUpdateCoinProductDto input);

        Task<CoinProductDto> UpdateAsync(Guid id, CreateUpdateCoinProductDto input);

        Task DeleteAsync(Guid id);
    }
}