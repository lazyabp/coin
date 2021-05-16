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
    [ControllerName("CoinWallet")]
    [Route("api/coin/coin-wallets")]
    public class CoinWalletController : CoinKitController, ICoinWalletAppService
    {
        private readonly ICoinWalletAppService _service;

        public CoinWalletController(ICoinWalletAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("my")]
        public Task<CoinWalletDto> GetAsync()
        {
            return _service.GetAsync();
        }

        [HttpGet]
        [Route("management")]
        public Task<PagedResultDto<CoinWalletDto>> GetListAsync(CoinWalletListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPut]
        [Route("{userId}/reset")]
        public Task<CoinWalletDto> ResetAsync(Guid userId)
        {
            return _service.ResetAsync(userId);
        }
    }
}
