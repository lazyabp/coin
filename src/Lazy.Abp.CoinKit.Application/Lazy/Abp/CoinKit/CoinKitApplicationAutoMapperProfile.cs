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
            CreateMap<CoinActionCreateUpdateDto, CoinAction>(MemberList.Source);
            CreateMap<CoinOrder, CoinOrderDto>();
            CreateMap<CoinOrderCreateUpdateDto, CoinOrder>(MemberList.Source);
            CreateMap<CoinProduct, CoinProductDto>();
            CreateMap<CoinProductCreateUpdateDto, CoinProduct>(MemberList.Source);
            CreateMap<CoinWallet, CoinWalletDto>();
            CreateMap<CoinWalletCreateUpdateDto, CoinWallet>(MemberList.Source);
            CreateMap<CoinWalletLog, CoinWalletLogDto>();
            CreateMap<CoinWalletLogCreateUpdateDto, CoinWalletLog>(MemberList.Source);
            CreateMap<Coupon, CouponDto>();
            CreateMap<CouponCreateUpdateDto, Coupon>(MemberList.Source);
            CreateMap<SpreadInvite, SpreadInviteDto>();
            CreateMap<SpreadInviteCreateUpdateDto, SpreadInvite>(MemberList.Source);
            CreateMap<SpreadUser, SpreadUserDto>();
            CreateMap<SpreadUserCreateUpdateDto, SpreadUser>(MemberList.Source);
        }
    }
}
