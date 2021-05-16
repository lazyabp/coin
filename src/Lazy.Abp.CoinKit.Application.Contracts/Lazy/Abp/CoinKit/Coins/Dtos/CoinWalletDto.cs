using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Coins.Dtos
{
    [Serializable]
    public class CoinWalletDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public int Balance { get; set; }

        public int LockedAmount { get; set; }
    }
}