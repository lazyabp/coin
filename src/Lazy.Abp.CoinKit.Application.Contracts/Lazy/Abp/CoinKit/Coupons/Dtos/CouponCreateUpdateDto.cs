using System;

namespace Lazy.Abp.CoinKit.Coupons.Dtos
{
    [Serializable]
    public class CouponCreateUpdateDto
    {
        public int AmountCoins { get; set; }

        public bool IsActive { get; set; }
    }
}