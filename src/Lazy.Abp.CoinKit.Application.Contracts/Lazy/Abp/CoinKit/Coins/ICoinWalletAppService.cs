using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Coins
{
    public interface ICoinWalletAppService : IApplicationService
    {
        Task<CoinWalletDto> GetAsync();

        Task<PagedResultDto<CoinWalletDto>> GetListAsync(CoinWalletListRequestDto input);

        Task<CoinWalletDto> ResetAsync(Guid userId);
    }
}