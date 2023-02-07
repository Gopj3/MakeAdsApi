using MakeAdsApi.Domain.Entities.Ads.Medias;
using MakeAdsApi.Domain.Enums.Ads;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class MediasConfiguration
{
    public static void ConfigureMedias(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Media>().ToTable("Medias");
        modelBuilder.Entity<Media>().HasOne(x => x.File).WithOne();
        modelBuilder.Entity<Media>().Property(x => x.Type).HasConversion(
            x => x.Value,
            p => MediaType.FromValue(p)
        );
    }
}