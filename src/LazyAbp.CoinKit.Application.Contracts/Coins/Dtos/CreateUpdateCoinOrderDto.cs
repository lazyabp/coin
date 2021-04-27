using System;

namespace LazyAbp.CoinKit.Coins.Dtos
{
    [Serializable]
    public class CreateUpdateCoinOrderDto
    {
        public Guid CoinProductId { get; set; }

        public PaymentGateway? Gateway { get; set; }
    }
}