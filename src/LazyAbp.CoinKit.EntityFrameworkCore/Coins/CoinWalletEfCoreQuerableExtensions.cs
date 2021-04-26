using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CoinKit.Coins
{
    public static class CoinWalletEfCoreQueryableExtensions
    {
        public static IQueryable<CoinWallet> IncludeDetails(this IQueryable<CoinWallet> queryable, bool include = true)
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