using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Spreads.Dtos
{
    public class SpreadInviteListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public string Filter { get; set; }
    }
}
