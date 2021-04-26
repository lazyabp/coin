using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CoinKit.Spreads
{
    public class SpreadUser : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public Guid UserId { get; private set; }

        /// <summary>
        /// 推广代码
        /// </summary>
        [MaxLength(CommonConsts.MaxLength64)]
        public virtual string SpreadCode { get; private set; }

        /// <summary>
        /// 推荐的用户ID
        /// </summary>
        public virtual Guid? InviterUserId { get; private set; }

        public virtual string InviterUser { get; private set; }

        /// <summary>
        /// 绑定的推荐人推广代码
        /// </summary>
        [MaxLength(CommonConsts.MaxLength64)]
        public virtual string InviterSpreadCode { get; private set; }

        protected SpreadUser()
        {
        }

        public SpreadUser(
            Guid id,
            Guid? tenantId,
            Guid userId,
            string spreadCode,
            Guid? inviterUserId,
            string inviterUser,
            string inviterSpreadCode
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            SpreadCode = spreadCode;
            InviterUserId = inviterUserId;
            InviterUser = inviterUser;
            InviterSpreadCode = inviterSpreadCode;
        }
    }
}
