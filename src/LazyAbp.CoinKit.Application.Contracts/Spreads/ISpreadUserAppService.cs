using System;
using System.Threading.Tasks;
using LazyAbp.CoinKit.Spreads.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CoinKit.Spreads
{
    public interface ISpreadUserAppService : IApplicationService
    {
        Task<SpreadUserDto> GetMySpreadInfoAsync();

        Task<SpreadUserDto> GetBySpreadCodeAsync(string spreadCode);

        /// <summary>
        /// 管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<SpreadUserDto>> GetListAsync(GetSpreadUserListRequestDto input);

        /// <summary>
        /// 管理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<SpreadUserDto> UpdateAsync(Guid id, CreateUpdateSpreadUserDto input);

        Task SetInviterAsync(Guid id, Guid inviterUserId);

        Task SetInviterBySpreadCodeAsync(SetInviterRequestDto input);
    }
}