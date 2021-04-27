using System;
using System.Threading.Tasks;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public interface ICoinWalletLogAppService : IApplicationService
    {
        Task<CoinWalletLogDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinWalletLogDto>> GetListAsync(GetCoinWalletLogListRequestDto input);

        Task<PagedResultDto<CoinWalletLogDto>> GetManagementListAsync(GetCoinWalletLogListRequestDto input);
    }
}