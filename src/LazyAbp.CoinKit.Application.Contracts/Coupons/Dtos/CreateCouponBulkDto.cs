using System;
using System.Collections.Generic;
using System.Text;

namespace LazyAbp.CoinKit.Coupons.Dtos
{
    public class CreateCouponBulkDto
    {
        public int Count { get; set; }

        public int Coins { get; set; }
    }
}
