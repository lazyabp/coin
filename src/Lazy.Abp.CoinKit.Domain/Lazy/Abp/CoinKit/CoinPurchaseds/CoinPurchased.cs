using Lazy.Abp.CoinKit.Coins;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.CoinKit.CoinPurchaseds
{
    public class CoinPurchased : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public Guid UserId { get; private set; }

        public Guid CoinProductId { get; private set; }

        public int Quantity { get; private set; }

        public string OrderId { get; private set; }

        public int CoinCount { get; private set; }

        public decimal PaidAmount { get; private set; }

        public CoinProduct CoinProduct { get; private set; }

        protected CoinPurchased()
        {
        }

        public CoinPurchased(
            Guid id,
            Guid? tenantId,
            Guid userId,
            Guid coinProductId,
            int quantity,
            string orderId,
            int coinCount,
            decimal paidAmount
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            CoinProductId = coinProductId;
            Quantity = quantity;
            OrderId = orderId;
            CoinCount = coinCount;
            PaidAmount = paidAmount;
        }
    }
}
