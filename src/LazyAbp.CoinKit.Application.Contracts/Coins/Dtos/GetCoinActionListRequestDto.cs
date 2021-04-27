using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CoinKit.Coins.Dtos
{
    public class GetCoinActionListRequestDto : PagedAndSortedResultRequestDto
    {
        public CoinActionType? ActionType { get; set; }

        public string Filter { get; set; }
    }
}
