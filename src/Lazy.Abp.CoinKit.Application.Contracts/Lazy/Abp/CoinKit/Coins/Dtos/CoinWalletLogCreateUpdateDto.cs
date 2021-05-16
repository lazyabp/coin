using System;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    [Serializable]
    public class CoinWalletLogCreateUpdateDto
    {
        public Guid UserId { get; set; }

        public string TypeName { get; set; }

        public bool IsOut { get; set; }

        public int Amount { get; set; }

        public int CurrentBalance { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}