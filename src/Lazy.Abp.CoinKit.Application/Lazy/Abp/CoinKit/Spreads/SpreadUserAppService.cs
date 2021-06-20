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
    public class SpreadUserAppService : ApplicationService, ISpreadUserAppService
    {
        private readonly ISpreadUserRepository _repository;
        
        public SpreadUserAppService(ISpreadUserRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public async Task<SpreadUserDto> GetMySpreadInfoAsync()
        {
            var spreadUser = await _repository.GetByUserIdAsync(CurrentUser.GetId());

            if (null == spreadUser)
            {
                var spreadCode = StringHelper.RandString("L", 10, 1);

                spreadUser = new SpreadUser(GuidGenerator.Create(), CurrentUser.TenantId, CurrentUser.GetId(), spreadCode);

                await _repository.InsertAsync(spreadUser);
            }

            return ObjectMapper.Map<SpreadUser, SpreadUserDto>(spreadUser);
        }

        [Authorize]
        public async Task<SpreadUserDto> GetBySpreadCodeAsync(string spreadCode)
        {
            var spreadUser = await _repository.GetBySpreadCodeAsync(spreadCode);

            return ObjectMapper.Map<SpreadUser, SpreadUserDto>(spreadUser);
        }

        [Authorize(CoinKitPermissions.SpreadUser.Management)]
        public async Task<PagedResultDto<SpreadUserDto>> GetListAsync(SpreadUserListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.UserId, input.InviterUserId, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.UserId, input.InviterUserId, input.Filter);

            return new PagedResultDto<SpreadUserDto>(
                count,
                ObjectMapper.Map<List<SpreadUser>, List<SpreadUserDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.SpreadUser.Update)]
        public Task<SpreadUserDto> UpdateAsync(Guid id, SpreadUserCreateUpdateDto input)
        {
            throw new NotImplementedException();
        }

        [Authorize(CoinKitPermissions.SpreadUser.BindInviter)]
        public async Task SetInviterAsync(Guid id, Guid inviterUserId)
        {
            var spreadUser = await _repository.GetAsync(id);
            // get user info
            var inveiter = await _repository.GetByUserIdAsync(inviterUserId);
            spreadUser.SetInviter(inveiter.UserId, "", inveiter.SpreadCode);
        }

        [Authorize]
        public async Task SetInviterBySpreadCodeAsync(SetInviterRequestDto input)
        {
            var spreadUser = await _repository.GetByUserIdAsync(CurrentUser.GetId());
            // get user info
            var inveiter = await _repository.GetBySpreadCodeAsync(input.InviterSpreadCode);
            spreadUser.SetInviter(inveiter.UserId, "", inveiter.SpreadCode);
        }
    }
}
