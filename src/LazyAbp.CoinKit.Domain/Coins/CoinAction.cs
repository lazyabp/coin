using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CoinKit.Coins
{
    /// <summary>
    /// 用户行为奖励金币
    /// </summary>
    public class CoinAction : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public string Title { get; private set; }

        public CoinActionType ActionType { get; private set; }

        public int RewardCoins { get; private set; }

        public DateTime BeginTime { get; private set; }

        public DateTime? ExpireTime { get; private set; }

        protected CoinAction()
        {
        }

        public CoinAction(
            Guid id,
            Guid? tenantId,
            string title,
            CoinActionType actionType,
            int rewardCoins,
            DateTime beginTime,
            DateTime? expireTime
        ) : base(id)
        {
            TenantId = tenantId;
            Title = title;
            ActionType = actionType;
            RewardCoins = rewardCoins;
            BeginTime = beginTime;
            ExpireTime = expireTime;
        }

        public void Update(
            string title,
            int rewardCoins,
            DateTime beginTime,
            DateTime? expireTime
        )
        {
            Title = title;
            RewardCoins = rewardCoins;
            BeginTime = beginTime;
            ExpireTime = expireTime;
        }
    }
}
