using Lazy.Abp.CoinKit.Recharges.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Recharges
{
    [RemoteService(Name = CoinKitRemoteServiceConsts.RemoteServiceName)]
    [Area("coin")]
    [ControllerName("CoinRechargeHistory")]
    [Route("api/coin/recharge-histories/management")]
    public class CoinRechargeHistoryAdminController : CoinKitController, ICoinRechargeHistoryAdminAppService
    {
        private readonly ICoinRechargeHistoryAdminAppService _service;

        public CoinRechargeHistoryAdminController(ICoinRechargeHistoryAdminAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CoinRechargeHistoryDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CoinRechargeHistoryDto>> GetListAsync(CoinRechargeHistoryListRequestDto input)
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
