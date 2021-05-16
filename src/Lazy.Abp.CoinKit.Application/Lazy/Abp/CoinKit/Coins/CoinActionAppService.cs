using System;
using Lazy.Abp.CoinKit.Permissions;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Volo.Abp;

namespace Lazy.Abp.CoinKit.Coins
{    
    public class CoinActionAppService : ApplicationService, ICoinActionAppService
    {
        private readonly ICoinActionRepository _repository;
        
        public CoinActionAppService(ICoinActionRepository repository)
        {
            _repository = repository;
        }

        [Authorize(CoinKitPermissions.CoinAction.Default)]
        public async Task<CoinActionDto> GetAsync(Guid id)
        {
            var act = await _repository.GetAsync(id);

            return ObjectMapper.Map<CoinAction, CoinActionDto>(act);
        }

        [Authorize(CoinKitPermissions.CoinAction.Default)]
        public async Task<PagedResultDto<CoinActionDto>> GetListAsync(CoinActionListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.ActionType, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.ActionType, input.Filter);

            return new PagedResultDto<CoinActionDto>(
                count,
                ObjectMapper.Map<List<CoinAction>, List<CoinActionDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.CoinAction.Create)]
        public async Task<CoinActionDto> CreateAsync(CoinActionCreateUpdateDto input)
        {
            var act = await _repository.GetByActionTypeAsync(input.ActionType);
            if (null != act)
                throw new UserFriendlyException(L["TheActionTypeHasBeenUsed"]);

            act = new CoinAction(GuidGenerator.Create(), CurrentUser.TenantId, input.Title, input.ActionType, input.RewardCoins, input.BeginTime, input.ExpireTime);

            await _repository.InsertAsync(act);

            return ObjectMapper.Map<CoinAction, CoinActionDto>(act);
        }

        [Authorize(CoinKitPermissions.CoinAction.Update)]
        public async Task<CoinActionDto> UpdateAsync(Guid id, CoinActionCreateUpdateDto input)
        {
            var act = await _repository.GetAsync(id);
            act.Update(input.Title, input.RewardCoins, input.BeginTime, input.ExpireTime);

            return ObjectMapper.Map<CoinAction, CoinActionDto>(act);
        }

        [Authorize(CoinKitPermissions.CoinAction.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
