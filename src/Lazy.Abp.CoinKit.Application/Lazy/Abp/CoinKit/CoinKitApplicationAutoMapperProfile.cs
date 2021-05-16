using Lazy.Abp.CoinKit.Coins;
using Lazy.Abp.CoinKit.Coins.Dtos;
using Lazy.Abp.CoinKit.Coupons;
using Lazy.Abp.CoinKit.Coupons.Dtos;
using Lazy.Abp.CoinKit.Spreads;
using Lazy.Abp.CoinKit.Spreads.Dtos;
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
