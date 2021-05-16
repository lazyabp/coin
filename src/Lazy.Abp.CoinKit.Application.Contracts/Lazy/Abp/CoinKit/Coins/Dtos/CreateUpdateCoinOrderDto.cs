using System;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    [Serializable]
    public class CreateUpdateCoinOrderDto
    {
        public Guid CoinProductId { get; set; }

        public PaymentGateway? Gateway { get; set; }
    }
}