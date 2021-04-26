using System;

namespace LazyAbp.CoinKit.Spreads.Dtos
{
    [Serializable]
    public class CreateUpdateSpreadUserDto
    {
        public Guid UserId { get; set; }

        public string SpreadCode { get; set; }

        public Guid? InviterUserId { get; set; }

        public string InviterUser { get; set; }

        public string InviterSpreadCode { get; set; }
    }
}