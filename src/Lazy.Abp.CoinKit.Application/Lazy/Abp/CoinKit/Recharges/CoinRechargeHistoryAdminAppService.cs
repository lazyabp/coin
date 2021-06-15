using Lazy.Abp.CoinKit.Recharges.Dtos;
using Lazy.Abp.CoinKit.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.CoinKit.Recharges
{
    public class CoinRechargeHistoryAdminAppService : CoinKitAppService, ICoinRechargeHistoryAdminAppService
    {
        private readonly ICoinRechargeHistoryRepository _repository;
        
        public CoinRechargeHistoryAdminAppService(ICoinRechargeHistoryRepository repository)
        {
            _repository = repository;
        }

        [Authorize(CoinKitPermissions.CoinRechargeHistory.Default)]
        public async Task<CoinRechargeHistoryDto> GetAsync(Guid id)
        {
            var result = await _repository.GetAsync(id);

            return ObjectMapper.Map<CoinRechargeHistory, CoinRechargeHistoryDto>(result);
        }

        [Authorize(CoinKitPermissions.CoinRechargeHistory.Default)]
        public async Task<PagedResultDto<CoinRechargeHistoryDto>> GetListAsync(CoinRechargeHistoryListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(null, input.CoinProductId,
                input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, null,
                input.CoinProductId, input.MinPaidAmount, input.MaxPaidAmount, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<CoinRechargeHistoryDto>(
                totalCount,
                ObjectMapper.Map<List<CoinRechargeHistory>, List<CoinRechargeHistoryDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.CoinRechargeHistory.Delete)]
        public Task DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}
