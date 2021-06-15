using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Recharges.Dtos
{
    [Serializable]
    public class CoinRechargeHistoryDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid CoinProductId { get; set; }

        public int Quantity { get; set; }

        public string OrderId { get; set; }

        public int CoinCount { get; set; }

        public decimal PaidAmount { get; set; }

        public CoinProductDto CoinProduct { get; set; }
    }
}