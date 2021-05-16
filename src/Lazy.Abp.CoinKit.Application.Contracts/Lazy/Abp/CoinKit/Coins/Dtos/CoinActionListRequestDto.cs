using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    public class CoinActionListRequestDto : PagedAndSortedResultRequestDto
    {
        public CoinActionType? ActionType { get; set; }

        public string Filter { get; set; }
    }
}
