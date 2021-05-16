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
    public class CoinWalletLogAppService : ApplicationService, ICoinWalletLogAppService
    {
        private readonly ICoinWalletLogRepository _repository;
        
        public CoinWalletLogAppService(ICoinWalletLogRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public async Task<CoinWalletLogDto> GetAsync(Guid id)
        {
            var log = await _repository.GetAsync(id);

            return ObjectMapper.Map<CoinWalletLog, CoinWalletLogDto>(log);
        }

        [Authorize]
        public async Task<PagedResultDto<CoinWalletLogDto>> GetListAsync(GetCoinWalletLogListRequestDto input)
        {
            var count = await _repository.GetCountAsync(CurrentUser.GetId(), input.IsOut, input.TypeName, 
                input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, CurrentUser.GetId(), 
                input.IsOut, input.TypeName, input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<CoinWalletLogDto>(
                count,
                ObjectMapper.Map<List<CoinWalletLog>, List<CoinWalletLogDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.CoinWalletLog.Management)]
        public async Task<PagedResultDto<CoinWalletLogDto>> GetManagementListAsync(GetCoinWalletLogListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.UserId, input.IsOut, input.TypeName,
                input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.UserId,
                input.IsOut, input.TypeName, input.MinAmount, input.MaxAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<CoinWalletLogDto>(
                count,
                ObjectMapper.Map<List<CoinWalletLog>, List<CoinWalletLogDto>>(list)
            );
        }
    }
}
