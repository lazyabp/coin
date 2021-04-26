using System;
using LazyAbp.CoinKit.Permissions;
using LazyAbp.CoinKit.Spreads.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Spreads
{
    public class SpreadInviteAppService : CrudAppService<SpreadInvite, SpreadInviteDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSpreadInviteDto, CreateUpdateSpreadInviteDto>,
        ISpreadInviteAppService
    {
        protected override string GetPolicyName { get; set; } = CoinKitPermissions.SpreadInvite.Default;
        protected override string GetListPolicyName { get; set; } = CoinKitPermissions.SpreadInvite.Default;
        protected override string CreatePolicyName { get; set; } = CoinKitPermissions.SpreadInvite.Create;
        protected override string UpdatePolicyName { get; set; } = CoinKitPermissions.SpreadInvite.Update;
        protected override string DeletePolicyName { get; set; } = CoinKitPermissions.SpreadInvite.Delete;

        private readonly ISpreadInviteRepository _repository;
        
        public SpreadInviteAppService(ISpreadInviteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
