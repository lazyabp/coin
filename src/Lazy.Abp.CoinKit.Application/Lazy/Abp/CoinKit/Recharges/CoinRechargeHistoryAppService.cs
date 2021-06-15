using System;
using Lazy.Abp.CoinKit.Permissions;
using Lazy.Abp.CoinKit.Recharges.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using Volo.Abp;
using System.Collections.Generic;

namespace Lazy.Abp.CoinKit.Recharges
{
    [Authorize]
    public class CoinRechargeHistoryAppService : CoinKitAppService, ICoinRechargeHistoryAppService
    {
        private readonly ICoinRechargeHistoryRepository _repository;
        
        public CoinRechargeHistoryAppService(ICoinRechargeHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CoinRechargeHistoryDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            return ObjectMapper.Map<CoinRechargeHistory, CoinRechargeHistoryDto>(result);
        }

        public async Task<PagedResultDto<CoinRechargeHistoryDto>> GetListAsync(CoinRechargeHistoryListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), input.CoinProductId,
                input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, CurrentUser.GetId(),
                input.CoinProductId, input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<CoinRechargeHistoryDto>(
                totalCount,
                ObjectMapper.Map<List<CoinRechargeHistory>, List<CoinRechargeHistoryDto>>(list)
            );
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            await _repository.DeleteAsync(result);
        }
    }
}
