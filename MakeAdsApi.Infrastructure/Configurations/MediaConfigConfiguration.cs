
using MakeAdsApi.Domain.Entities.SocialMedias;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

internal static class MediaConfigConfiguration
{
    public static void ConfigureMediaConfigs(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeltaUiTemplateConfig>()
            .HasOne(x => x.DeltaMediaConfig)
            .WithMany(x => x.DeltaUiTemplateConfigs);
    }    
}