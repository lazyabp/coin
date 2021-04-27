using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CoinKit.Spreads.Dtos
{
    public class GetSpreadInviteListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public string Filter { get; set; }
    }
}
