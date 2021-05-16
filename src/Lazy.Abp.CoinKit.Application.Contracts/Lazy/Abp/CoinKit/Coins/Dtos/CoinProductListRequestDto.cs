using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    public class CoinProductListRequestDto : PagedAndSortedResultRequestDto
    {
        public bool? IsActive { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public DateTime? CreationAfter { get; set; }
        public DateTime? CreationBefore { get; set; }
        public string Filter { get; set; }
    }
}
