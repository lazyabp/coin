using System;
using LazyAbp.CoinKit.Permissions;
using LazyAbp.CoinKit.Coins.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace LazyAbp.CoinKit.Coins
{
    public class CoinProductAppService : ApplicationService, ICoinProductAppService
    {
        private readonly ICoinProductRepository _repository;
        
        public CoinProductAppService(ICoinProductRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public async Task<CoinProductDto> GetAsync(Guid id)
        {
            var product = await _repository.GetAsync(id);

            return ObjectMapper.Map<CoinProduct, CoinProductDto>(product);
        }

        [Authorize]
        public async Task<PagedResultDto<CoinProductDto>> GetListAsync(GetCoinProductListRequestDto input)
        {
            var count = await _repository.GetCountAsync(input.IsActive, input.MinPrice, input.MaxPrice, input.CreationAfter, input.CreationBefore, input.Filter);
            var list = await _repository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount,
                input.IsActive, input.MinPrice, input.MaxPrice, input.CreationAfter, input.CreationBefore, input.Filter);

            return new PagedResultDto<CoinProductDto>(
                count,
                ObjectMapper.Map<List<CoinProduct>, List<CoinProductDto>>(list)
            );
        }

        [Authorize(CoinKitPermissions.CoinProduct.Create)]
        public async Task<CoinProductDto> CreateAsync(CreateUpdateCoinProductDto input)
        {
            var product = new CoinProduct(GuidGenerator.Create(), CurrentUser.TenantId, input.Name, input.Thumbnail,
                input.RetailPrice, input.SalePrice, input.CostCoins, input.Description, input.IsActive, input.DisplayOrder);
            await _repository.InsertAsync(product);

            return ObjectMapper.Map<CoinProduct, CoinProductDto>(product);
        }

        [Authorize(CoinKitPermissions.CoinProduct.Update)]
        public async Task<CoinProductDto> UpdateAsync(Guid id, CreateUpdateCoinProductDto input)
        {
            var product = await _repository.GetAsync(id);
            product.Update(input.Name, input.Thumbnail, input.RetailPrice, input.SalePrice, input.CostCoins, input.Description, input.IsActive, input.DisplayOrder);

            return ObjectMapper.Map<CoinProduct, CoinProductDto>(product);
        }

        [Authorize(CoinKitPermissions.CoinProduct.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
