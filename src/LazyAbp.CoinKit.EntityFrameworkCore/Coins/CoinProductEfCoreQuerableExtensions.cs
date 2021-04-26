using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CoinKit.Coins
{
    public static class CoinProductEfCoreQueryableExtensions
    {
        public static IQueryable<CoinProduct> IncludeDetails(this IQueryable<CoinProduct> queryable, bool include = true)
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