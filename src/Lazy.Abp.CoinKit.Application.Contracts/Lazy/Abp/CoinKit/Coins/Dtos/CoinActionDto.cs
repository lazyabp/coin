using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    [Serializable]
    public class CoinActionDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public CoinActionType ActionType { get; set; }

        public int RewardCoins { get; set; }

        public DateTime BeginTime { get; set; }

        public DateTime? ExpireTime { get; set; }
    }
}