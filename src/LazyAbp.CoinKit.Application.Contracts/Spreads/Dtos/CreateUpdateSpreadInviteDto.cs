using System;

namespace LazyAbp.CoinKit.Spreads.Dtos
{
    [Serializable]
    public class CreateUpdateSpreadInviteDto
    {
        public Guid UserId { get; set; }

        public Guid? InviteeUserId { get; set; }
    }
}