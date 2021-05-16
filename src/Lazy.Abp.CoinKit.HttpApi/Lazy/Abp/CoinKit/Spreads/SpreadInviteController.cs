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
    [ControllerName("SpreadInvite")]
    [Route("api/coin/spread-invites")]
    public class SpreadInviteController : CoinKitController, ISpreadInviteAppService
    {
        private readonly ISpreadInviteAppService _service;

        public SpreadInviteController(ISpreadInviteAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<SpreadInviteDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<SpreadInviteDto>> GetListAsync(SpreadInviteListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
