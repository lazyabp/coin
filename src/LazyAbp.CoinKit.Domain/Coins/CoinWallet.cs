using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinWallet : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public Guid UserId { get; private set; }

        public int Balance { get; private set; }

        public int LockedAmount { get; private set; }

        public void IncBalance(int amount)
        {
            Balance += Math.Abs(amount);
        }

        public void DecBalance(int amount)
        {
            Balance -= Math.Abs(amount);
        }

        public void IncLockedAmount(int amount)
        {
            LockedAmount += Math.Abs(amount);
        }

        public void DecLockedAmount(int amount)
        {
            LockedAmount -= Math.Abs(amount);
        }

        public void Reset()
        {
            Balance = 0;
            LockedAmount = 0;
        }

        protected CoinWallet()
        {
        }

        public CoinWallet(
            Guid id,
            Guid? tenantId,
            Guid userId,
            int balance,
            int lockedAmount
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            Balance = balance;
            LockedAmount = lockedAmount;
        }
    }
}
