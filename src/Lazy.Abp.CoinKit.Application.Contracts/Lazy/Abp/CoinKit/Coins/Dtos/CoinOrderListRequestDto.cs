﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    public class CoinOrderListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public PaymentGateway? Gateway { get; set; }
        public PaymentStatus? Status { get; set; }
        public DateTime? CreationAfter { get; set; }
        public DateTime? CreationBefore { get; set; }
        public string Filter { get; set; }
        public bool IncludeDetails { get; set; }
    }
}