using System;

namespace LazyAbp.CoinKit.Coupons.Dtos
{
    [Serializable]
    public class CreateUpdateCouponDto
    {
        public int AmountCoins { get; set; }

        public bool IsActive { get; set; }
    }
}