using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CoinKit.Coins
{
    public static class CoinOrderEfCoreQueryableExtensions
    {
        public static IQueryable<CoinOrder> IncludeDetails(this IQueryable<CoinOrder> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                 .Include(x => x.Product) // TODO: AbpHelper generated
                ;
        }
    }
}