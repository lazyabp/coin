using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinOrder : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public Guid CoinProductId { get; protected set; }

        public PaymentGateway? Gateway { get; private set; }

        public PaymentStatus Status { get; private set; }

        [MaxLength(CommonConsts.MaxLength128)]
        public string OrderNo { get; private set; }

        [MaxLength(CommonConsts.MaxLength128)]
        public string TradeNo { get; private set; }

        public DateTime? PaymentTime { get; private set; }

        [ForeignKey("CoinProductId")]
        public CoinProduct Product { get; private set; }

        public void SetAsCancelled()
        {
            if (Status == PaymentStatus.NotPaid)
            {
                Status = PaymentStatus.Cancelled;
            }
        }

        public void SetAsFailed()
        {
            Status = PaymentStatus.Failed;
        }

        public void SetAsPaid(string tradeNo)
        {
            if (Status == PaymentStatus.NotPaid)
            {
                Status = PaymentStatus.Paid;
                TradeNo = tradeNo;
                PaymentTime = DateTime.Now;
            }
        }

        public void SetAsCompleted()
        {
            if (Status == PaymentStatus.Paid)
            {
                Status = PaymentStatus.Completed;
            }
        }

        public void SetOrderNo(string orderNo)
        {
            if (Status == PaymentStatus.NotPaid)
            {
                OrderNo = orderNo;
            }
        }

        protected CoinOrder()
        {
        }

        public CoinOrder(
            Guid id,
            Guid? tenantId,
            Guid coinProductId,
            PaymentGateway? gateway,
            PaymentStatus status,
            string orderNo,
            string tradeNo,
            DateTime? paymentTime,
            CoinProduct product
        ) : base(id)
        {
            TenantId = tenantId;
            CoinProductId = coinProductId;
            Gateway = gateway;
            Status = status;
            OrderNo = orderNo;
            TradeNo = tradeNo;
            PaymentTime = paymentTime;
            Product = product;
        }
    }
}
