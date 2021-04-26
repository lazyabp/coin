using System;
using LazyAbp.CoinKit.Coupons.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coupons
{
    public interface ICouponAppService :
        ICrudAppService< 
            CouponDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCouponDto,
            CreateUpdateCouponDto>
    {

    }
}