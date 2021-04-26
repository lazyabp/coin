using System;
using LazyAbp.CoinKit.Permissions;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinWalletLogAppService : CrudAppService<CoinWalletLog, CoinWalletLogDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCoinWalletLogDto, CreateUpdateCoinWalletLogDto>,
        ICoinWalletLogAppService
    {
        protected override string GetPolicyName { get; set; } = CoinKitPermissions.CoinWalletLog.Default;
        protected override string GetListPolicyName { get; set; } = CoinKitPermissions.CoinWalletLog.Default;
        protected override string CreatePolicyName { get; set; } = CoinKitPermissions.CoinWalletLog.Create;
        protected override string UpdatePolicyName { get; set; } = CoinKitPermissions.CoinWalletLog.Update;
        protected override string DeletePolicyName { get; set; } = CoinKitPermissions.CoinWalletLog.Delete;

        private readonly ICoinWalletLogRepository _repository;
        
        public CoinWalletLogAppService(ICoinWalletLogRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
