using LazyAbp.CoinKit.Coins;
using LazyAbp.CoinKit.Coins.Dtos;
using LazyAbp.CoinKit.Coupons;
using LazyAbp.CoinKit.Coupons.Dtos;
using LazyAbp.CoinKit.Spreads;
using LazyAbp.CoinKit.Spreads.Dtos;
using AutoMapper;

namespace LazyAbp.CoinKit
{
    public class CoinKitApplicationAutoMapperProfile : Profile
    {
        public CoinKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CoinAction, CoinActionDto>();
            CreateMap<CreateUpdateCoinActionDto, CoinAction>(MemberList.Source);
            CreateMap<CoinOrder, CoinOrderDto>();
            CreateMap<CreateUpdateCoinOrderDto, CoinOrder>(MemberList.Source);
            CreateMap<CoinProduct, CoinProductDto>();
            CreateMap<CreateUpdateCoinProductDto, CoinProduct>(MemberList.Source);
            CreateMap<CoinWallet, CoinWalletDto>();
            CreateMap<CreateUpdateCoinWalletDto, CoinWallet>(MemberList.Source);
            CreateMap<CoinWalletLog, CoinWalletLogDto>();
            CreateMap<CreateUpdateCoinWalletLogDto, CoinWalletLog>(MemberList.Source);
            CreateMap<Coupon, CouponDto>();
            CreateMap<CreateUpdateCouponDto, Coupon>(MemberList.Source);
            CreateMap<SpreadInvite, SpreadInviteDto>();
            CreateMap<CreateUpdateSpreadInviteDto, SpreadInvite>(MemberList.Source);
            CreateMap<SpreadUser, SpreadUserDto>();
            CreateMap<CreateUpdateSpreadUserDto, SpreadUser>(MemberList.Source);
        }
    }
}
