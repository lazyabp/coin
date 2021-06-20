using System;
using Lazy.Abp.CoinKit.Permissions;
using Lazy.Abp.CoinKit.Recharges.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Lazy.Abp.CoinKit.Recharges
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
        public async Task<PagedResultDto<CoinProductDto>> GetListAsync(CoinProductListRequestDto input)
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
        public async Task<CoinProductDto> CreateAsync(CoinProductCreateUpdateDto input)
        {
            var product = new CoinProduct(GuidGenerator.Create(), CurrentUser.TenantId, input.Name, input.Thumbnail,
                input.RetailPrice, input.SalePrice, input.CostCoins, input.Description, input.IsActive, input.DisplayOrder);

            product.SetSoldQuantity(input.SoldQuantity);

            await _repository.InsertAsync(product);

            return ObjectMapper.Map<CoinProduct, CoinProductDto>(product);
        }

        [Authorize(CoinKitPermissions.CoinProduct.Update)]
        public async Task<CoinProductDto> UpdateAsync(Guid id, CoinProductCreateUpdateDto input)
        {
            var product = await _repository.GetAsync(id);
            product.Update(input.Name, input.Thumbnail, input.RetailPrice, input.SalePrice, input.CostCoins, input.Description, input.IsActive, input.DisplayOrder);
            product.SetSoldQuantity(input.SoldQuantity);

            return ObjectMapper.Map<CoinProduct, CoinProductDto>(product);
        }

        [Authorize(CoinKitPermissions.CoinProduct.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
