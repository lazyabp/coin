using System;

namespace Lazy.Abp.CoinKit.CoinPurchaseds.Dtos
{
    [Serializable]
    public class CoinPurchasedCreateUpdateDto
    {
        public Guid UserId { get; set; }

        public Guid CoinProductId { get; set; }

        public int Quantity { get; set; }

        public string OrderId { get; set; }

        public int CoinCount { get; set; }

        public decimal PaidAmount { get; set; }
    }
}