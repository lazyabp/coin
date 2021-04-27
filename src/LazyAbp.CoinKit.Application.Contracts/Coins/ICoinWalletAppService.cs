using System;
using System.Threading.Tasks;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public interface ICoinWalletAppService : IApplicationService
    {
        Task<CoinWalletDto> GetAsync();

        Task<PagedResultDto<CoinWalletDto>> GetListAsync(GetCoinWalletListRequestDto input);

        Task<CoinWalletDto> ResetAsync(Guid userId);
    }
}