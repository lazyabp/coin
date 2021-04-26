using System;

namespace LazyAbp.CoinKit.Coins.Dtos
{
    [Serializable]
    public class CreateUpdateCoinActionDto
    {
        public string Title { get; set; }

        public CoinActionType ActionType { get; set; }

        public int RewardCoins { get; set; }

        public DateTime BeginTime { get; set; }

        public DateTime? ExpireTime { get; set; }
    }
}