using System;
using LazyAbp.CoinKit.Permissions;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinOrderAppService : CrudAppService<CoinOrder, CoinOrderDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCoinOrderDto, CreateUpdateCoinOrderDto>,
        ICoinOrderAppService
    {
        protected override string GetPolicyName { get; set; } = CoinKitPermissions.CoinOrder.Default;
        protected override string GetListPolicyName { get; set; } = CoinKitPermissions.CoinOrder.Default;
        protected override string CreatePolicyName { get; set; } = CoinKitPermissions.CoinOrder.Create;
        protected override string UpdatePolicyName { get; set; } = CoinKitPermissions.CoinOrder.Update;
        protected override string DeletePolicyName { get; set; } = CoinKitPermissions.CoinOrder.Delete;

        private readonly ICoinOrderRepository _repository;
        
        public CoinOrderAppService(ICoinOrderRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
