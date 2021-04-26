using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CoinKit.Spreads
{
    public static class SpreadUserEfCoreQueryableExtensions
    {
        public static IQueryable<SpreadUser> IncludeDetails(this IQueryable<SpreadUser> queryable, bool include = true)
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