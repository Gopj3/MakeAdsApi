using MakeAdsApi.Domain.Entities.Ads.Campaigns;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class CampaignsConfiguration
{
    public static void ConfigureCampaigns(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campaign>().ToTable("Campaigns");
    }
}