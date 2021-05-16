using Lazy.Abp.CoinKit.Spreads.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Spreads
{
    [RemoteService(Name = CoinKitRemoteServiceConsts.RemoteServiceName)]
    [Area("coin")]
    [ControllerName("SpreadUser")]
    [Route("api/coin/spread-users")]
    public class SpreadUserController : CoinKitController, ISpreadUserAppService
    {
        private readonly ISpreadUserAppService _service;

        public SpreadUserController(ISpreadUserAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("my-spread")]
        public Task<SpreadUserDto> GetMySpreadInfoAsync()
        {
            return _service.GetMySpreadInfoAsync();
        }

        [HttpGet]
        [Route("by-code/{spreadCode}")]
        public Task<SpreadUserDto> GetBySpreadCodeAsync(string spreadCode)
        {
            return _service.GetBySpreadCodeAsync(spreadCode);
        }

        [HttpGet]
        public Task<PagedResultDto<SpreadUserDto>> GetListAsync(SpreadUserListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<SpreadUserDto> UpdateAsync(Guid id, SpreadUserCreateUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/set-inviter/{inviterUserId}")]
        public Task SetInviterAsync(Guid id, Guid inviterUserId)
        {
            return _service.SetInviterAsync(id, inviterUserId);
        }

        [HttpPut]
        [Route("set-my-inviter")]
        public Task SetInviterBySpreadCodeAsync(SetInviterRequestDto input)
        {
            return _service.SetInviterBySpreadCodeAsync(input);
        }
    }
}
