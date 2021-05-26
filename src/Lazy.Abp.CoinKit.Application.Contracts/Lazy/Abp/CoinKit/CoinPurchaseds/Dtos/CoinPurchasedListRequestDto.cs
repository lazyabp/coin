﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.CoinPurchaseds.Dtos
{
    public class CoinPurchasedListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? CoinProductId { get; set; }

        public decimal? MinPaidAmount { get; set; }

        public decimal? MaxPaidAmount { get; set; }

        public DateTime? CreationAfter { get; set; }

        public DateTime? CreationBefore { get; set; }

        public string Filter { get; set; }
    }
}
