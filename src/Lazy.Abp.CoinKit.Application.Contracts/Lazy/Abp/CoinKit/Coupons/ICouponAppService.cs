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

        Task<PagedResultDto<CouponDto>> GetListAsync(GetCouponListRequestDto input);

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateBulkAsync(CreateCouponBulkDto input);

        Task<CouponDto> CreateAsync(CreateUpdateCouponDto input);

        Task<CouponDto> UpdateAsync(Guid id, CreateUpdateCouponDto input);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CouponDto> ClaimAsync(ClaimCouponDto input);

        Task DeleteAsync(Guid id);
    }
}