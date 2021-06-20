using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Permissions;
using Lazy.Abp.CoinKit.Spreads.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Lazy.Abp.CoinKit.Spreads
{
    public class SpreadInviteAppService : ApplicationService, ISpreadInviteAppService
    {
        private readonly ISpreadInviteRepository _repository;
        
        public SpreadInviteAppService(ISpreadInviteRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public async Task<SpreadInviteDto> GetAsync(Guid id)
        {
            var invite = await _repository.GetAsync(id);

            return ObjectMapper.Map<SpreadInvite, SpreadInviteDto>(invite);
        }

        [Authorize]
        public async Task<PagedResultDto<SpreadInviteDto>> GetListAsync(SpreadInviteListRequestDto input)
        {
            Guid? userId = null;
            if (false == await AuthorizationService.IsGrantedAsync(CoinKitPermissions.SpreadInvite.Management))
                userId = CurrentUser.GetId();

            var count = await _repository.GetCountAsync(userId, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, userId, input.Filter);

            return new PagedResultDto<SpreadInviteDto>(
                count,
                ObjectMapper.Map<List<SpreadInvite>, List<SpreadInviteDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.SpreadInvite.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
