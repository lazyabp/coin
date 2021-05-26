using Lazy.Abp.CoinKit.Coins;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Lazy.Abp.CoinKit.Coupons;
using Lazy.Abp.CoinKit.Coupons.Dtos;
using Lazy.Abp.CoinKit.Spreads;
using Lazy.Abp.CoinKit.Spreads.Dtos;
using Lazy.Abp.CoinKit.CoinPurchaseds;
using Lazy.Abp.CoinKit.CoinPurchaseds.Dtos;
using AutoMapper;

namespace Lazy.Abp.CoinKit
{
    public class CoinKitApplicationAutoMapperProfile : Profile
    {
        public CoinKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CoinAction, CoinActionDto>();
            CreateMap<CoinProduct, CoinProductDto>();
            CreateMap<CoinWallet, CoinWalletDto>();
            CreateMap<CoinWalletLog, CoinWalletLogDto>();
            CreateMap<Coupon, CouponDto>();
            CreateMap<SpreadInvite, SpreadInviteDto>();
            CreateMap<SpreadUser, SpreadUserDto>();
            CreateMap<CoinPurchased, CoinPurchasedDto>();
        }
    }
}
