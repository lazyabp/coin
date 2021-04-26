using System;

namespace LazyAbp.CoinKit.Coins.Dtos
{
    [Serializable]
    public class CreateUpdateCoinOrderDto
    {
        public Guid CoinProductId { get; set; }

        public PaymentGateway? Gateway { get; set; }

        public PaymentStatus Status { get; set; }

        public string OrderNo { get; set; }

        public string TradeNo { get; set; }

        public DateTime? PaymentTime { get; set; }

        public CoinProduct Product { get; set; }
    }
}