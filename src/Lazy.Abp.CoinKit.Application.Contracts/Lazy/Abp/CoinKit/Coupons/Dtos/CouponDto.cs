using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coupons.Dtos
{
    [Serializable]
    public class CouponDto : FullAuditedEntityDto<Guid>
    {
        public string SerialNumber { get; set; }

        public int AmountCoins { get; set; }

        public bool IsActive { get; set; }

        public Guid? UserId { get; set; }

        public DateTime? ClaimedTime { get; set; }
    }
}