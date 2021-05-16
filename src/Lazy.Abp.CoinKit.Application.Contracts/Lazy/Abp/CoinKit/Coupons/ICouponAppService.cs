using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Coupons.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Coupons
{
    public interface ICouponAppService : IApplicationService
    {
        Task<CouponDto> GetAsync(Guid id);

        Task<PagedResultDto<CouponDto>> GetListAsync(CouponListRequestDto input);

        /// <summary>
        /// 批量生成
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateBulkAsync(CouponBulkCreateDto input);

        Task<CouponDto> CreateAsync(CouponCreateUpdateDto input);

        Task<CouponDto> UpdateAsync(Guid id, CouponCreateUpdateDto input);

        /// <summary>
        /// 认领
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CouponDto> ClaimAsync(ClaimCouponDto input);

        Task DeleteAsync(Guid id);
    }
}