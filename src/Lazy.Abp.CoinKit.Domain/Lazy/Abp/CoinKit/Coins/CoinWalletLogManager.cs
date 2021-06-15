using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Lazy.Abp.CoinKit.Coins
{
    public class CoinWalletLogManager : DomainService
    {
        private readonly ICoinWalletLogRepository _coinWalletLogRepository;

        public CoinWalletLogManager(ICoinWalletLogRepository coinWalletLogRepository)
        {
            _coinWalletLogRepository = coinWalletLogRepository;
        }

        public async Task<CoinWalletLog> WriteLogForInAsync(
            Guid? tenantId,
            Guid userId,
            string action,
            int amount,
            int currentBalance,
            string title,
            string description
        )
        {
            var log = new CoinWalletLog(GuidGenerator.Create(), tenantId, userId, action, false, amount, currentBalance, title, description);

            return await _coinWalletLogRepository.InsertAsync(log);
        }

        public async Task<CoinWalletLog> WriteLogForOutAsync(
            Guid? tenantId,
            Guid userId,
            string action,
            int amount,
            int currentBalance,
            string title,
            string description
        )
        {
            var log = new CoinWalletLog(GuidGenerator.Create(), tenantId, userId, action, true, amount, currentBalance, title, description);

            return await _coinWalletLogRepository.InsertAsync(log);
        }
    }
}
