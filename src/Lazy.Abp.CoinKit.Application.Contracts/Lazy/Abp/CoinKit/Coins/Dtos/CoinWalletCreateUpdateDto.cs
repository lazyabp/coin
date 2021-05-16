using System;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    [Serializable]
    public class CoinWalletCreateUpdateDto
    {
        public Guid UserId { get; set; }

        public int Balance { get; set; }

        public int LockedAmount { get; set; }
    }
}