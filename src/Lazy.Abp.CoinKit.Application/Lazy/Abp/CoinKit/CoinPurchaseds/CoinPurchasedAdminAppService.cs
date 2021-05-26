using Lazy.Abp.CoinKit.CoinPurchaseds.Dtos;
using Lazy.Abp.CoinKit.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.CoinPurchaseds
{
    public class CoinPurchasedAdminAppService : CoinKitAppService, ICoinPurchasedAdminAppService
    {
        private readonly ICoinPurchasedRepository _repository;
        
        public CoinPurchasedAdminAppService(ICoinPurchasedRepository repository)
        {
            _repository = repository;
        }

        [Authorize(CoinKitPermissions.CoinPurchased.Default)]
        public async Task<CoinPurchasedDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            return ObjectMapper.Map<CoinPurchased, CoinPurchasedDto>(result);
        }

        [Authorize(CoinKitPermissions.CoinPurchased.Default)]
        public async Task<PagedResultDto<CoinPurchasedDto>> GetListAsync(CoinPurchasedListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(null, input.CoinProductId,
                input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, null,
                input.CoinProductId, input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<CoinPurchasedDto>(
                totalCount,
                ObjectMapper.Map<List<CoinPurchased>, List<CoinPurchasedDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.CoinPurchased.Delete)]
        public Task DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
