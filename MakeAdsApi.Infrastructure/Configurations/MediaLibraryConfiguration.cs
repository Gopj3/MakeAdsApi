using MakeAdsApi.Domain.Entities.MediaLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MakeAdsApi.Infrastructure.Configurations;

internal static class MediaLibraryConfiguration
{
    public static void ConfigureMediaLibrary(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseMediaLibraryFile>().ToTable("BaseMediaLibraryFiles");
        modelBuilder.Entity<MediaLibraryImage>().ToTable("MediaLibraryImages");
        modelBuilder.Entity<MediaLibraryVideo>().ToTable("MediaLibraryVideos");
    }
}