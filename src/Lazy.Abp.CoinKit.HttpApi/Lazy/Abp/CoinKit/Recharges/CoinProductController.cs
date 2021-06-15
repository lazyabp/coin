using Lazy.Abp.CoinKit.Recharges.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Recharges
{
    [RemoteService(Name = CoinKitRemoteServiceConsts.RemoteServiceName)]
    [Area("coin")]
    [ControllerName("CoinProduct")]
    [Route("api/coin/products")]
    public class CoinProductController : CoinKitController, ICoinProductAppService
    {
        private readonly ICoinProductAppService _service;

        public CoinProductController(ICoinProductAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CoinProductDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CoinProductDto>> GetListAsync(CoinProductListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<CoinProductDto> CreateAsync(CoinProductCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CoinProductDto> UpdateAsync(Guid id, CoinProductCreateUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
