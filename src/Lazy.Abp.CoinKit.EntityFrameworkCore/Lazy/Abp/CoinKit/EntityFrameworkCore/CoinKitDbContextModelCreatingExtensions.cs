using Lazy.Abp.CoinKit.Recharges;
using Lazy.Abp.CoinKit.Spreads;
using Lazy.Abp.CoinKit.Coupons;
using Lazy.Abp.CoinKit.Coins;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.CoinKit.EntityFrameworkCore
{
    public static class CoinKitDbContextModelCreatingExtensions
    {
        public static void ConfigureCoinKit(
            this ModelBuilder builder,
            Action<CoinKitModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CoinKitModelBuilderConfigurationOptions(
                CoinKitDbProperties.DbTablePrefix,
                CoinKitDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<CoinAction>(b =>
            {
                b.ToTable(options.TablePrefix + "CoinActions", options.Schema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });

            builder.Entity<CoinProduct>(b =>
            {
                b.ToTable(options.TablePrefix + "CoinProducts", options.Schema);
                b.ConfigureByConvention(); 
                

                /* Configure more properties here */
            });


            builder.Entity<CoinWallet>(b =>
            {
                b.ToTable(options.TablePrefix + "CoinWallets", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.UserId).IsUnique();
                /* Configure more properties here */
            });


            builder.Entity<CoinWalletLog>(b =>
            {
                b.ToTable(options.TablePrefix + "CoinWalletLogs", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.UserId);
                /* Configure more properties here */
            });


            builder.Entity<Coupon>(b =>
            {
                b.ToTable(options.TablePrefix + "Coupons", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.SerialNumber).IsUnique();
                /* Configure more properties here */
            });


            builder.Entity<SpreadInvite>(b =>
            {
                b.ToTable(options.TablePrefix + "SpreadInvites", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.UserId);
                /* Configure more properties here */
            });


            builder.Entity<SpreadUser>(b =>
            {
                b.ToTable(options.TablePrefix + "SpreadUsers", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.UserId).IsUnique();
                b.HasIndex(q => q.SpreadCode).IsUnique();
                /* Configure more properties here */
            });


            builder.Entity<CoinRechargeHistory>(b =>
            {
                b.ToTable(options.TablePrefix + "CoinRechargeHistories", options.Schema);
                b.ConfigureByConvention();

                b.HasIndex(q => q.UserId);
                /* Configure more properties here */
            });
        }
    }
}
