using Lazy.Abp.CoinKit.Coupons.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coupons
{
    [RemoteService(Name = CoinKitRemoteServiceConsts.RemoteServiceName)]
    [Area("coin")]
    [ControllerName("Coupon")]
    [Route("api/coin/coupons")]
    public class CouponController : CoinKitController, ICouponAppService
    {
        private readonly ICouponAppService _service;

        public CouponController(ICouponAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CouponDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CouponDto>> GetListAsync(CouponListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<CouponDto> CreateAsync(CouponCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPost]
        [Route("bulk-create")]
        public Task CreateBulkAsync(CouponBulkCreateDto input)
        {
            return _service.CreateBulkAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CouponDto> UpdateAsync(Guid id, CouponCreateUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpPost]
        [Route("claim")]
        public Task<CouponDto> ClaimAsync(ClaimCouponDto input)
        {
            return _service.ClaimAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
