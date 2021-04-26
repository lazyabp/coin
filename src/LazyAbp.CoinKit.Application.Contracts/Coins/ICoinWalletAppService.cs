using System;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Coins
{
    public interface ICoinWalletAppService :
        ICrudAppService< 
            CoinWalletDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCoinWalletDto,
            CreateUpdateCoinWalletDto>
    {

    }
}