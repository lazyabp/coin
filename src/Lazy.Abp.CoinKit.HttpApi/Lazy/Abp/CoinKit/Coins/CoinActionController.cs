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
    [ControllerName("CoinAction")]
    [Route("api/coin/coin-actions")]
    public class CoinActionController : CoinKitController, ICoinActionAppService
    {
        private readonly ICoinActionAppService _service;

        public CoinActionController(ICoinActionAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CoinActionDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CoinActionDto>> GetListAsync(CoinActionListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<CoinActionDto> CreateAsync(CoinActionCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CoinActionDto> UpdateAsync(Guid id, CoinActionCreateUpdateDto input)
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
