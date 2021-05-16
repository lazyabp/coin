using System;
using Lazy.Abp.CoinKit.Permissions;
using Lazy.Abp.CoinKit.Coupons.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Volo.Abp.Users;

namespace Lazy.Abp.CoinKit.Coupons
{
    public class CouponAppService : ApplicationService, ICouponAppService
    {
        private readonly ICouponRepository _repository;
        
        public CouponAppService(ICouponRepository repository)
        {
            _repository = repository;
        }

        [Authorize(CoinKitPermissions.Coupon.Default)]
        public async Task<CouponDto> GetAsync(Guid id)
        {
            var coupon = await _repository.GetAsync(id);

            return ObjectMapper.Map<Coupon, CouponDto>(coupon);
        }

        [Authorize(CoinKitPermissions.Coupon.Default)]
        public async Task<PagedResultDto<CouponDto>> GetListAsync(GetCouponListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.IsActive, input.IsClaimed, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.IsActive, input.IsClaimed, input.Filter);

            return new PagedResultDto<CouponDto>(
                count,
                ObjectMapper.Map<List<Coupon>, List<CouponDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.Coupon.Create)]
        public async Task CreateBulkAsync(CreateCouponBulkDto input)
        {
            var coupons = new List<Coupon>();

            for (int i = 0; i < input.Count; i++)
            {
                var coupon = new Coupon(GuidGenerator.Create(), CurrentUser.TenantId, "", input.Coins, true);

                coupons.Add(coupon);
            }

            if (coupons.Count > 0)
                await _repository.InsertManyAsync(coupons);
        }

        [Authorize(CoinKitPermissions.Coupon.Create)]
        public async Task<CouponDto> CreateAsync(CreateUpdateCouponDto input)
        {
            var coupon = new Coupon(GuidGenerator.Create(), CurrentUser.TenantId, "", input.AmountCoins, input.IsActive);

            await _repository.InsertAsync(coupon);

            return ObjectMapper.Map<Coupon, CouponDto>(coupon);
        }

        [Authorize(CoinKitPermissions.Coupon.Update)]
        public async Task<CouponDto> UpdateAsync(Guid id, CreateUpdateCouponDto input)
        {
            var coupon = await _repository.GetAsync(id);
            coupon.Update(input.AmountCoins, input.IsActive);

            await _repository.UpdateAsync(coupon);

            return ObjectMapper.Map<Coupon, CouponDto>(coupon);
        }

        [Authorize]
        public async Task<CouponDto> ClaimAsync(ClaimCouponDto input)
        {
            var coupon = await _repository.GetBySerialNumberAsync(input.SerialNumber);
            coupon.SetAsClaimed(CurrentUser.GetId(), Clock.Now);

            return ObjectMapper.Map<Coupon, CouponDto>(coupon);
        }

        [Authorize(CoinKitPermissions.Coupon.Default)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
