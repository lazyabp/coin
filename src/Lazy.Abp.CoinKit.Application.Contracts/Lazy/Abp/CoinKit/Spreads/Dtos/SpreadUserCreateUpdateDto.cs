using System;

namespace Lazy.Abp.CoinKit.Spreads.Dtos
{
    [Serializable]
    public class SpreadUserCreateUpdateDto
    {
        public Guid UserId { get; set; }

        public string SpreadCode { get; set; }

        public Guid? InviterUserId { get; set; }

        public string InviterUser { get; set; }

        public string InviterSpreadCode { get; set; }
    }
}