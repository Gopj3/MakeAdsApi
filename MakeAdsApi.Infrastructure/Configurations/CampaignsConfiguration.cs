using MakeAdsApi.Domain.Entities.Ads.Campaigns;
using MakeAdsApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class CampaignsConfiguration
{
    public static void ConfigureCampaigns(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campaign>().ToTable("Campaigns");
        modelBuilder.Entity<Campaign>()
            .Property(x => x.SocialMediaPlatform)
            .HasConversion(
                x => x.Value,
                x => AvailableSocialMedias.FromValue(x)
            );
    }
}