using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Coins
{
    public interface ICoinWalletLogAppService : IApplicationService
    {
        Task<CoinWalletLogDto> GetAsync(Guid id);

        Task<PagedResultDto<CoinWalletLogDto>> GetListAsync(GetCoinWalletLogListRequestDto input);

        Task<PagedResultDto<CoinWalletLogDto>> GetManagementListAsync(GetCoinWalletLogListRequestDto input);
    }
}