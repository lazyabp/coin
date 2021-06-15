using Lazy.Abp.CoinKit.Coins;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace Lazy.Abp.CoinKit.Recharges
{
    public class CoinRechargeHistoryManager : DomainService, IUnitOfWorkEnabled
    {
        private readonly ICoinRechargeHistoryRepository _repository;
        private readonly ICoinProductRepository _productRepository;
        private readonly ICoinWalletRepository _walletRepository;
        private readonly ICoinWalletLogRepository _walletLogRepository;

        public CoinRechargeHistoryManager(
            ICoinRechargeHistoryRepository repository,
            ICoinProductRepository productRepository,
            ICoinWalletRepository walletRepository,
            ICoinWalletLogRepository walletLogRepository
        )
        {
            _repository = repository;
            _productRepository = productRepository;
            _walletRepository = walletRepository;
            _walletLogRepository = walletLogRepository;
        }

        public async Task<CoinRechargeHistory> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<CoinRechargeHistory> GetAsync(Guid id, Guid? tenantId)
        {
            using (CurrentTenant.Change(tenantId))
            {
                return await _repository.GetAsync(id);
            }
        }
        
        /// <summary>
        /// 充值
        /// </summary>
        [UnitOfWork]
        public async Task<CoinRechargeHistory> RechargeAsync(
            Guid? tenantId,
            Guid userId,
            Guid coinProductId,
            int productQuantity,
            string orderId,
            int coinTotal,
            decimal paidAmount,
            string title,
            string description
        )
        {
            using (CurrentTenant.Change(tenantId))
            {
                var coinPurchased = new CoinRechargeHistory(GuidGenerator.Create(), tenantId, userId, coinProductId, productQuantity, orderId, coinTotal, paidAmount);

                await _repository.InsertAsync(coinPurchased);

                // 修改销售数量
                var product = await _productRepository.GetAsync(coinProductId);
                product.SetSoldQuantity(product.SoldQuantity + productQuantity);

                // 钱包
                var wallet = await _walletRepository.GetByUserIdAsync(userId);
                wallet.IncBalance(coinTotal);

                // 写日志
                var log = new CoinWalletLog(GuidGenerator.Create(), tenantId, userId, "Recharge", false, coinTotal, wallet.Balance, title, description);
                await _walletLogRepository.InsertAsync(log);

                return coinPurchased;
            }
        }

        /// <summary>
        /// 支付
        /// </summary>
        [UnitOfWork]
        public async Task<int> PayAsync(
            Guid? tenantId,
            Guid userId,
            int coinTotal,
            string title,
            string description,
            string typeName = "Pay"
        )
        {
            using (CurrentTenant.Change(tenantId))
            {
                // 钱包
                var wallet = await _walletRepository.GetByUserIdAsync(userId);
                wallet.DecBalance(coinTotal);

                // 写日志
                var log = new CoinWalletLog(GuidGenerator.Create(), tenantId, userId, typeName, true, coinTotal, wallet.Balance, title, description);
                await _walletLogRepository.InsertAsync(log);

                return wallet.Balance;
            }
        }

        /// <summary>
        /// 存（赚取，赠送等得到的消费点）
        /// </summary>
        [UnitOfWork]
        public async Task<int> DepositAsync(
            Guid? tenantId,
            Guid userId,
            int coinTotal,
            string title,
            string description,
            string typeName = "Deposit"
        )
        {
            using (CurrentTenant.Change(tenantId))
            {
                // 钱包
                var wallet = await _walletRepository.GetByUserIdAsync(userId);
                wallet.IncBalance(coinTotal);

                // 写日志
                var log = new CoinWalletLog(GuidGenerator.Create(), tenantId, userId, typeName, false, coinTotal, wallet.Balance, title, description);
                await _walletLogRepository.InsertAsync(log);

                return wallet.Balance;
            }
        }
    }
}
