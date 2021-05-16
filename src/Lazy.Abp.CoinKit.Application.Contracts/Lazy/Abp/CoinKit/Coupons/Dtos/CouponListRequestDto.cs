using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coupons.Dtos
{
    public class CouponListRequestDto : PagedAndSortedResultRequestDto
    {
        public bool? IsActive { get; set; }
        public bool? IsClaimed { get; set; }
        public string Filter { get; set; }
    }
}
