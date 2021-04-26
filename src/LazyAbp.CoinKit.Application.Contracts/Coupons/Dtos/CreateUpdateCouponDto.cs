using System;

namespace LazyAbp.CoinKit.Coupons.Dtos
{
    [Serializable]
    public class CreateUpdateCouponDto
    {
        public string SerialNumber { get; set; }

        public int AmountCoins { get; set; }

        public bool IsActive { get; set; }

        public Guid? UserId { get; set; }

        public DateTime? ClaimedTime { get; set; }
    }
}