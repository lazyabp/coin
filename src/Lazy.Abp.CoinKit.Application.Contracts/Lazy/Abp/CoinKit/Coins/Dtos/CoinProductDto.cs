using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    [Serializable]
    public class CoinProductDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Thumbnail { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int CostCoins { get; set; }

        public int SoldQuantity { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
    }
}