using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CoinKit.Coupons
{
    public class Coupon : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        /// <summary>
        /// 点券编号
        /// </summary>
        public virtual string SerialNumber { get; protected set; }

        /// <summary>
        /// 可用点数
        /// </summary>
        public virtual int AmountCoins { get; protected set; }

        /// <summary>
        /// 激活状态
        /// </summary>
        public virtual bool IsActive { get; protected set; }

        /// <summary>
        /// 认领人ID
        /// </summary>
        public virtual Guid? UserId { get; protected set; }

        public virtual DateTime? ClaimedTime { get; private set; }

        protected Coupon()
        {
        }

        public Coupon(
            Guid id,
            Guid? tenantId,
            string serialNumber,
            int amountCoins,
            bool isActive,
            Guid? userId,
            DateTime? claimedTime
        ) : base(id)
        {
            TenantId = tenantId;
            SerialNumber = serialNumber;
            AmountCoins = amountCoins;
            IsActive = isActive;
            UserId = userId;
            ClaimedTime = claimedTime;
        }
    }
}
