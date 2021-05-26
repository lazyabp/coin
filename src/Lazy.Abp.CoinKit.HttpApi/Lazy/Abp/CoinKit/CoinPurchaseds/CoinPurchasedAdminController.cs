using Lazy.Abp.CoinKit.CoinPurchaseds.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.CoinPurchaseds
{
    [RemoteService(Name = CoinKitRemoteServiceConsts.RemoteServiceName)]
    [Area("coin")]
    [ControllerName("CoinPurchased")]
    [Route("api/coin/coin-purchaseds/management")]
    public class CoinPurchasedAdminController : CoinKitController, ICoinPurchasedAdminAppService
    {
        private readonly ICoinPurchasedAdminAppService _service;

        public CoinPurchasedAdminController(ICoinPurchasedAdminAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CoinPurchasedDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CoinPurchasedDto>> GetListAsync(CoinPurchasedListRequestDto input)
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
