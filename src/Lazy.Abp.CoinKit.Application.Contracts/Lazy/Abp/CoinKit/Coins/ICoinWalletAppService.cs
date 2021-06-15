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

        /// <summary>
        /// 增加账户积点
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CoinWalletDto> IncreaseCoinAsync(Guid userId, CoinAdjustmentRequestDto input);

        /// <summary>
        /// 扣除账户积点
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CoinWalletDto> DecreaseCoinAsync(Guid userId, CoinAdjustmentRequestDto input);
    }
}