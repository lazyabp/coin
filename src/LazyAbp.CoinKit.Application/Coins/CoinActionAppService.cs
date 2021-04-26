using System;
using LazyAbp.CoinKit.Permissions;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinActionAppService : CrudAppService<CoinAction, CoinActionDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCoinActionDto, CreateUpdateCoinActionDto>,
        ICoinActionAppService
    {
        protected override string GetPolicyName { get; set; } = CoinKitPermissions.CoinAction.Default;
        protected override string GetListPolicyName { get; set; } = CoinKitPermissions.CoinAction.Default;
        protected override string CreatePolicyName { get; set; } = CoinKitPermissions.CoinAction.Create;
        protected override string UpdatePolicyName { get; set; } = CoinKitPermissions.CoinAction.Update;
        protected override string DeletePolicyName { get; set; } = CoinKitPermissions.CoinAction.Delete;

        private readonly ICoinActionRepository _repository;
        
        public CoinActionAppService(ICoinActionRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
