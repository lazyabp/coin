using System;
using LazyAbp.CoinKit.Permissions;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinWalletAppService : CrudAppService<CoinWallet, CoinWalletDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCoinWalletDto, CreateUpdateCoinWalletDto>,
        ICoinWalletAppService
    {
        protected override string GetPolicyName { get; set; } = CoinKitPermissions.CoinWallet.Default;
        protected override string GetListPolicyName { get; set; } = CoinKitPermissions.CoinWallet.Default;
        protected override string CreatePolicyName { get; set; } = CoinKitPermissions.CoinWallet.Create;
        protected override string UpdatePolicyName { get; set; } = CoinKitPermissions.CoinWallet.Update;
        protected override string DeletePolicyName { get; set; } = CoinKitPermissions.CoinWallet.Delete;

        private readonly ICoinWalletRepository _repository;
        
        public CoinWalletAppService(ICoinWalletRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
