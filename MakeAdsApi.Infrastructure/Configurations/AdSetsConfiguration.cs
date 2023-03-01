using MakeAdsApi.Domain.Entities.Ads.AdSets;
using MakeAdsApi.Domain.Enums;
using MakeAdsApi.Domain.Enums.Ads;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class AdSetsConfiguration
{
    public static void ConfigureAdSets(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdSet>().ToTable("AdSets");
        modelBuilder.Entity<AdSetLocation>().ToTable("AdSetsLocations");

        modelBuilder.Entity<AdSet>().Property(x => x.Title).IsRequired().HasColumnType("varchar(255)");
        
        modelBuilder.Entity<AdSet>()
            .HasMany(x => x.AdSetLocations)
            .WithOne(x => x.AdSet);
        modelBuilder.Entity<AdSetLocation>().Property(x => x.Unit)
            .HasConversion(
                x => x.Value,
                x => DistanceMeasurementUnit.FromValue(x)
            );
        modelBuilder.Entity<AdSet>()
            .Property(x => x.SocialMediaPlatform)
            .HasConversion(
                x => x.Value,
                x => AvailableSocialMedias.FromValue(x)
            );
    }
}