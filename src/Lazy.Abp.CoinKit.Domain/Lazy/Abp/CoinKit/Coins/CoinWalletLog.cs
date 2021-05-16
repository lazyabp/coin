using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.CoinKit.Coins
{
    public class CoinWalletLog : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public Guid UserId { get; private set; }

        [MaxLength(CommonConsts.MaxLength128)]
        public string TypeName { get; private set; }

        /// <summary>
        /// 收入或支出
        /// </summary>
        public bool IsOut { get; private set; }

        public int Amount { get; private set; }

        public int CurrentBalance { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        protected CoinWalletLog()
        {
        }

        public CoinWalletLog(
            Guid id,
            Guid? tenantId,
            Guid userId,
            string typeName,
            bool isOut,
            int amount,
            int currentBalance,
            string title,
            string description
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            TypeName = typeName;
            IsOut = isOut;
            Amount = amount;
            CurrentBalance = currentBalance;
            Title = title;
            Description = description;
        }
    }
}
