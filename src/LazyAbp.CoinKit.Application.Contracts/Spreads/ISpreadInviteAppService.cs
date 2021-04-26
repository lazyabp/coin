using System;
using LazyAbp.CoinKit.Spreads.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Spreads
{
    public interface ISpreadInviteAppService :
        ICrudAppService< 
            SpreadInviteDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateSpreadInviteDto,
            CreateUpdateSpreadInviteDto>
    {

    }
}