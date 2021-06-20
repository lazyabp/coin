using System;
using Lazy.Abp.CoinKit.Permissions;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using System.Collections.Generic;
using Volo.Abp;

namespace Lazy.Abp.CoinKit.Coins
{
    public class CoinWalletAppService : ApplicationService, ICoinWalletAppService
    {
        private readonly ICoinWalletRepository _repository;
        private readonly CoinWalletLogManager _coinWalletLogManager;

        public CoinWalletAppService(
            ICoinWalletRepository repository,
            CoinWalletLogManager coinWalletLogManager
        )
        {
            _repository = repository;
            _coinWalletLogManager = coinWalletLogManager;
        }

        [Authorize]
        public async Task<CoinWalletDto> GetAsync()
        {
            var wallet = await _repository.GetByUserIdAsync(CurrentUser.GetId());

            if (null == wallet)
            {
                wallet = new CoinWallet(GuidGenerator.Create(), CurrentUser.TenantId, CurrentUser.GetId(), 0, 0);

                await _repository.InsertAsync(wallet);
            }

            return ObjectMapper.Map<CoinWallet, CoinWalletDto>(wallet);
        }

        [Authorize(CoinKitPermissions.CoinWallet.Management)]
        public async Task<PagedResultDto<CoinWalletDto>> GetListAsync(CoinWalletListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.UserId, input.MinBalance, input.MaxBalance, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount,
                input.SkipCount, input.UserId, input.MinBalance, input.MaxBalance, input.Filter);

            return new PagedResultDto<CoinWalletDto>(
                count,
                ObjectMapper.Map<List<CoinWallet>, List<CoinWalletDto>>(list)
            );
        }

        /// <summary>
        /// 增加账户积点
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(CoinKitPermissions.CoinWallet.Adjustment)]
        public async Task<CoinWalletDto> IncreaseCoinAsync(Guid userId, CoinAdjustmentRequestDto input)
        {
            var wallet = await _repository.GetByUserIdAsync(userId);
            input.Amount = Math.Abs(input.Amount);
            var balance = wallet.Balance + input.Amount;

            wallet.IncBalance(input.Amount);
            await _coinWalletLogManager.WriteLogForInAsync(wallet.TenantId, wallet.UserId, "IncreaseCoin", input.Amount, balance, L["IncreaseCoin"], input.Reason);

            return ObjectMapper.Map<CoinWallet, CoinWalletDto>(wallet);
        }

        /// <summary>
        /// 扣除账户积点
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(CoinKitPermissions.CoinWallet.Adjustment)]
        public async Task<CoinWalletDto> DecreaseCoinAsync(Guid userId, CoinAdjustmentRequestDto input)
        {
            var wallet = await _repository.GetByUserIdAsync(userId);
            input.Amount = Math.Abs(input.Amount);
            var balance = wallet.Balance - input.Amount;
            if (balance < 0)
                throw new UserFriendlyException(L["InsufficientBalance"]);

            wallet.DecBalance(input.Amount);
            await _coinWalletLogManager.WriteLogForOutAsync(wallet.TenantId, wallet.UserId, "DecreaseCoin", input.Amount, balance, L["DecreaseCoin"], input.Reason);

            return ObjectMapper.Map<CoinWallet, CoinWalletDto>(wallet);
        }
    }
}
