using System;
using LazyAbp.CoinKit.Permissions;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinProductAppService : CrudAppService<CoinProduct, CoinProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCoinProductDto, CreateUpdateCoinProductDto>,
        ICoinProductAppService
    {
        protected override string GetPolicyName { get; set; } = CoinKitPermissions.CoinProduct.Default;
        protected override string GetListPolicyName { get; set; } = CoinKitPermissions.CoinProduct.Default;
        protected override string CreatePolicyName { get; set; } = CoinKitPermissions.CoinProduct.Create;
        protected override string UpdatePolicyName { get; set; } = CoinKitPermissions.CoinProduct.Update;
        protected override string DeletePolicyName { get; set; } = CoinKitPermissions.CoinProduct.Delete;

        private readonly ICoinProductRepository _repository;
        
        public CoinProductAppService(ICoinProductRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
