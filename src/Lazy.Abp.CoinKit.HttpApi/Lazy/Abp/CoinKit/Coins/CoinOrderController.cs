using Lazy.Abp.CoinKit.Coins.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coins
{
    [RemoteService(Name = CoinKitRemoteServiceConsts.RemoteServiceName)]
    [Area("coin")]
    [ControllerName("CoinOrder")]
    [Route("api/coin/coin-orders")]
    public class CoinOrderController : CoinKitController, ICoinOrderAppService
    {
        private readonly ICoinOrderAppService _service;

        public CoinOrderController(ICoinOrderAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CoinOrderDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CoinOrderDto>> GetListAsync(GetCoinOrderListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("management")]
        public Task<PagedResultDto<CoinOrderDto>> GetManagementListAsync(GetCoinOrderListRequestDto input)
        {
            return _service.GetManagementListAsync(input);
        }

        [HttpPost]
        public Task<CoinOrderDto> CreateAsync(CreateUpdateCoinOrderDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
