using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CoinKit.Coins
{
    public static class CoinWalletLogEfCoreQueryableExtensions
    {
        public static IQueryable<CoinWalletLog> IncludeDetails(this IQueryable<CoinWalletLog> queryable, bool include = true)
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