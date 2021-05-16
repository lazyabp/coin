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
    [ControllerName("CoinWalletLog")]
    [Route("api/coin/coin-wallet-logs")]
    public class CoinWalletLogController : CoinKitController, ICoinWalletLogAppService
    {
        private readonly ICoinWalletLogAppService _service;

        public CoinWalletLogController(ICoinWalletLogAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CoinWalletLogDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CoinWalletLogDto>> GetListAsync(CoinWalletLogListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("management")]
        public Task<PagedResultDto<CoinWalletLogDto>> GetManagementListAsync(CoinWalletLogListRequestDto input)
        {
            return _service.GetManagementListAsync(input);
        }
    }
}
