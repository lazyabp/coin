using System;
using Lazy.Abp.CoinKit.Permissions;
using Lazy.Abp.CoinKit.CoinPurchaseds.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using Volo.Abp;
using System.Collections.Generic;

namespace Lazy.Abp.CoinKit.CoinPurchaseds
{
    [Authorize]
    public class CoinPurchasedAppService : CoinKitAppService, ICoinPurchasedAppService
    {
        private readonly ICoinPurchasedRepository _repository;
        
        public CoinPurchasedAppService(ICoinPurchasedRepository repository)
        {
            _repository = repository;
        }

        public async Task<CoinPurchasedDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            if (result.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            return ObjectMapper.Map<CoinPurchased, CoinPurchasedDto>(result);
        }

        public async Task<PagedResultDto<CoinPurchasedDto>> GetListAsync(CoinPurchasedListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), input.CoinProductId,
                input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, CurrentUser.GetId(),
                input.CoinProductId, input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<CoinPurchasedDto>(
                totalCount,
                ObjectMapper.Map<List<CoinPurchased>, List<CoinPurchasedDto>>(list)
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
