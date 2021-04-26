using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CoinKit.Coins
{
    public static class CoinActionEfCoreQueryableExtensions
    {
        public static IQueryable<CoinAction> IncludeDetails(this IQueryable<CoinAction> queryable, bool include = true)
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