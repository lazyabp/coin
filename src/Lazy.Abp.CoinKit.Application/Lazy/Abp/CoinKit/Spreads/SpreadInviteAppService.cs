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
            var count = await _repository.GetCountAsync(CurrentUser.GetId(), input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, CurrentUser.GetId(), input.Filter);

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
