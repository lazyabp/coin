using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CoinKit.Spreads.Dtos
{
    [Serializable]
    public class SpreadInviteDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid? InviteeUserId { get; set; }
    }
}