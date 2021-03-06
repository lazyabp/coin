using System;
using System.Threading.Tasks;
using Lazy.Abp.CoinKit.Spreads.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.CoinKit.Spreads
{
    public interface ISpreadUserAppService : IApplicationService
    {
        Task<SpreadUserDto> GetMySpreadInfoAsync();

        Task<SpreadUserDto> GetBySpreadCodeAsync(string spreadCode);

        /// <summary>
        /// ????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<SpreadUserDto>> GetListAsync(SpreadUserListRequestDto input);

        /// <summary>
        /// ????
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<SpreadUserDto> UpdateAsync(Guid id, SpreadUserCreateUpdateDto input);

        Task SetInviterAsync(Guid id, Guid inviterUserId);

        Task SetInviterBySpreadCodeAsync(SetInviterRequestDto input);
    }
}