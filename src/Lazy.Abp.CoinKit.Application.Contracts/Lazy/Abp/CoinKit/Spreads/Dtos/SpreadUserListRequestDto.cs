using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Spreads.Dtos
{
    public class SpreadUserListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid? InviterUserId { get; set; }
        public string Filter { get; set; }
    }
}
