using System;

namespace Lazy.Abp.CoinKit.Spreads.Dtos
{
    [Serializable]
    public class SpreadInviteCreateUpdateDto
    {
        public Guid UserId { get; set; }

        public Guid? InviteeUserId { get; set; }
    }
}