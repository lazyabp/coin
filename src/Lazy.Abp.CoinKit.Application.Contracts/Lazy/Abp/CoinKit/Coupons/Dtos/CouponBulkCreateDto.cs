using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.CoinKit.Coupons.Dtos
{
    public class CouponBulkCreateDto
    {
        public int Count { get; set; }

        public int Coins { get; set; }
    }
}
