using System;
using LazyAbp.CoinKit.Permissions;
using LazyAbp.CoinKit.Spreads.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Spreads
{
    public class SpreadUserAppService : CrudAppService<SpreadUser, SpreadUserDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSpreadUserDto, CreateUpdateSpreadUserDto>,
        ISpreadUserAppService
    {
        protected override string GetPolicyName { get; set; } = CoinKitPermissions.SpreadUser.Default;
        protected override string GetListPolicyName { get; set; } = CoinKitPermissions.SpreadUser.Default;
        protected override string CreatePolicyName { get; set; } = CoinKitPermissions.SpreadUser.Create;
        protected override string UpdatePolicyName { get; set; } = CoinKitPermissions.SpreadUser.Update;
        protected override string DeletePolicyName { get; set; } = CoinKitPermissions.SpreadUser.Delete;

        private readonly ISpreadUserRepository _repository;
        
        public SpreadUserAppService(ISpreadUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
