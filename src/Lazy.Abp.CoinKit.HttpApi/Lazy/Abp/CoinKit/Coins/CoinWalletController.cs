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
    [Route("api/coin/wallets")]
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
        [Route("{userId}/increase-coins")]
        public Task<CoinWalletDto> IncreaseCoinAsync(Guid userId, CoinAdjustmentRequestDto input)
        {
            return _service.IncreaseCoinAsync(userId, input);
        }

        [HttpPut]
        [Route("{userId}/decrease-coins")]
        public Task<CoinWalletDto> DecreaseCoinAsync(Guid userId, CoinAdjustmentRequestDto input)
        {
            return _service.DecreaseCoinAsync(userId, input);
        }
    }
}
