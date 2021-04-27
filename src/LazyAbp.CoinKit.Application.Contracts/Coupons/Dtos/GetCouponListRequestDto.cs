using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CoinKit.Coupons.Dtos
{
    public class GetCouponListRequestDto : PagedAndSortedResultRequestDto
    {
        public bool? IsActive { get; set; }
        public bool? IsClaimed { get; set; }
        public string Filter { get; set; }
    }
}
