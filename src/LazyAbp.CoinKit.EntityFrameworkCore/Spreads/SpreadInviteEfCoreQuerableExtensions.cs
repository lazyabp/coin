using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CoinKit.Spreads
{
    public static class SpreadInviteEfCoreQueryableExtensions
    {
        public static IQueryable<SpreadInvite> IncludeDetails(this IQueryable<SpreadInvite> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}