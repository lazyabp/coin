using System;
using Lazy.Abp.CoinKit.Permissions;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using System.Collections.Generic;

namespace Lazy.Abp.CoinKit.Coins
{
    public class CoinWalletAppService : ApplicationService, ICoinWalletAppService
    {
        private readonly ICoinWalletRepository _repository;
        
        public CoinWalletAppService(ICoinWalletRepository repository)
        {
            _repository = repository;
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
        public async Task<PagedResultDto<CoinWalletDto>> GetListAsync(GetCoinWalletListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.UserId, input.MinBalance, input.MaxBalance, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount,
                input.SkipCount, input.UserId, input.MinBalance, input.MaxBalance, input.Filter);

            return new PagedResultDto<CoinWalletDto>(
                count,
                ObjectMapper.Map<List<CoinWallet>, List<CoinWalletDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.CoinWallet.Reset)]
        public async Task<CoinWalletDto> ResetAsync(Guid userId)
        {
            var wallet = await _repository.GetByUserIdAsync(userId);
            wallet.Reset();

            return ObjectMapper.Map<CoinWallet, CoinWalletDto>(wallet);
        }
    }
}
