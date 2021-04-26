using System;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public interface ICoinProductAppService :
        ICrudAppService< 
            CoinProductDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCoinProductDto,
            CreateUpdateCoinProductDto>
    {

    }
}