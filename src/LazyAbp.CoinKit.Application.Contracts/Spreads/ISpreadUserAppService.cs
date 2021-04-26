using System;
using LazyAbp.CoinKit.Spreads.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Spreads
{
    public interface ISpreadUserAppService :
        ICrudAppService< 
            SpreadUserDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateSpreadUserDto,
            CreateUpdateSpreadUserDto>
    {

    }
}