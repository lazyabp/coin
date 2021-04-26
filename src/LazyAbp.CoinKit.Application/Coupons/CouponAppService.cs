using System;
using LazyAbp.CoinKit.Permissions;
using LazyAbp.CoinKit.Coupons.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coupons
{
    public class CouponAppService : CrudAppService<Coupon, CouponDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCouponDto, CreateUpdateCouponDto>,
        ICouponAppService
    {
        protected override string GetPolicyName { get; set; } = CoinKitPermissions.Coupon.Default;
        protected override string GetListPolicyName { get; set; } = CoinKitPermissions.Coupon.Default;
        protected override string CreatePolicyName { get; set; } = CoinKitPermissions.Coupon.Create;
        protected override string UpdatePolicyName { get; set; } = CoinKitPermissions.Coupon.Update;
        protected override string DeletePolicyName { get; set; } = CoinKitPermissions.Coupon.Delete;

        private readonly ICouponRepository _repository;
        
        public CouponAppService(ICouponRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
