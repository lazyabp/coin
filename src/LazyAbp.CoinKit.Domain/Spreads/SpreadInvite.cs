using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CoinKit.Spreads
{
    public class SpreadInvite : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public Guid UserId { get; private set; }

        /// <summary>
        /// 被邀请人ID
        /// </summary>
        public virtual Guid? InviteeUserId { get; protected set; }

        protected SpreadInvite()
        {
        }

        public SpreadInvite(
            Guid id,
            Guid? tenantId,
            Guid userId,
            Guid? inviteeUserId
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            InviteeUserId = inviteeUserId;
        }
    }
}
