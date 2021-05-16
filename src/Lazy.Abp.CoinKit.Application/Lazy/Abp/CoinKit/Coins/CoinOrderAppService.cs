using System;
using Lazy.Abp.CoinKit.Permissions;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using System.Collections.Generic;

namespace Lazy.Abp.CoinKit.Coins
{
    public class CoinOrderAppService : ApplicationService, ICoinOrderAppService
    {
        private readonly ICoinOrderRepository _repository;
        
        public CoinOrderAppService(ICoinOrderRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public async Task<CoinOrderDto> GetAsync(Guid id)
        {
            var order = await _repository.GetAsync(id);

            return ObjectMapper.Map<CoinOrder, CoinOrderDto>(order);
        }

        [Authorize]
        public async Task<PagedResultDto<CoinOrderDto>> GetListAsync(GetCoinOrderListRequestDto input)
        {
            var count = await _repository.GetCountAsync(CurrentUser.GetId(), input.Gateway, 
                input.Status, input.CreationAfter, input.CreationBefore, input.Filter, input.IncludeDetails);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, 
                CurrentUser.GetId(), input.Gateway, input.Status, input.CreationAfter, input.CreationBefore, input.Filter, input.IncludeDetails);

            return new PagedResultDto<CoinOrderDto>(
                count,
                ObjectMapper.Map<List<CoinOrder>, List<CoinOrderDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.CoinOrder.Management)]
        public async Task<PagedResultDto<CoinOrderDto>> GetManagementListAsync(GetCoinOrderListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.UserId, input.Gateway,
                input.Status, input.CreationAfter, input.CreationBefore, input.Filter, input.IncludeDetails);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount,
                input.UserId, input.Gateway, input.Status, input.CreationAfter, input.CreationBefore, input.Filter, input.IncludeDetails);

            return new PagedResultDto<CoinOrderDto>(
                count,
                ObjectMapper.Map<List<CoinOrder>, List<CoinOrderDto>>(list)
            );
        }

        [Authorize]
        public async Task<CoinOrderDto> CreateAsync(CreateUpdateCoinOrderDto input)
        {
            var order = new CoinOrder(GuidGenerator.Create(), CurrentUser.TenantId, input.CoinProductId, input.Gateway);
            await _repository.InsertAsync(order);

            return ObjectMapper.Map<CoinOrder, CoinOrderDto>(order);
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
