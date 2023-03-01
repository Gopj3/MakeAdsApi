using MakeAdsApi.Domain.Entities.Ads;
using MakeAdsApi.Domain.Enums;
using MakeAdsApi.Domain.Enums.Ads;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class AdvertisesConfiguration
{
    public static void ConfigureAdvertises(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertise>().ToTable("Advertises");
        modelBuilder.Entity<Advertise>()
            .HasOne(x => x.Campaign)
            .WithOne();

        modelBuilder.Entity<Advertise>()
            .HasOne(x => x.AdSet)
            .WithOne();

        modelBuilder.Entity<Advertise>()
            .HasOne(x => x.Creative)
            .WithOne(x => x.Advertise);

        modelBuilder.Entity<Advertise>()
            .HasOne(x => x.Order)
            .WithMany(x => x.Advertises);

        modelBuilder.Entity<Advertise>()
            .Property(x => x.SocialMediaPlatform)
            .HasConversion(
                x => x.Value,
                x => AvailableSocialMedias.FromValue(x)
            );
        
        modelBuilder.Entity<Advertise>()
            .Property(x => x.InternalStatus)
            .HasConversion(
                x => x.Value,
                x => InternalStatus.FromValue(x)
            );
    }
}