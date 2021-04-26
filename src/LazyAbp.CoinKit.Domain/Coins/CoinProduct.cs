using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinProduct : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        [MaxLength(CommonConsts.MaxLength255)]
        public string Name { get; private set; }

        [MaxLength(CommonConsts.MaxLength255)]
        public string Thumbnail { get; private set; }

        public decimal RetailPrice { get; private set; }

        public decimal SalePrice { get; private set; }

        public int CostCoins { get; private set; }

        public int SoldQuantity { get; private set; }

        public string Description { get; private set; }

        public bool IsActive { get; private set; }

        public int DisplayOrder { get; private set; }

        protected CoinProduct()
        {
        }

        public CoinProduct(
            Guid id,
            Guid? tenantId,
            string name,
            string thumbnail,
            decimal retailPrice,
            decimal salePrice,
            int costCoins,
            int soldQuantity,
            string description,
            bool isActive,
            int displayOrder
        ) : base(id)
        {
            TenantId = tenantId;
            Name = name;
            Thumbnail = thumbnail;
            RetailPrice = retailPrice;
            SalePrice = salePrice;
            CostCoins = costCoins;
            SoldQuantity = soldQuantity;
            Description = description;
            IsActive = isActive;
            DisplayOrder = displayOrder;
        }
    }
}
