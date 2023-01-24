using MakeAdsApi.Domain.Entities.Files;
using MakeAdsApi.Domain.Entities.Files.MediaLibrary;
using MakeAdsApi.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

internal static class MediaLibraryConfiguration
{
    public static void ConfigureMediaLibrary(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<File>().ToTable("Files");
        modelBuilder.Entity<File>().Property(x => x.PreSignedUrl).HasColumnType("varchar(768)");
        modelBuilder.Entity<BaseMediaLibraryFile>().ToTable("BaseMediaLibraryFiles");
        modelBuilder.Entity<MediaLibraryImage>().ToTable("MediaLibraryImages");
        modelBuilder.Entity<MediaLibraryVideo>().ToTable("MediaLibraryVideos");
        modelBuilder.Entity<UserProfileAvatar>().ToTable("UserProfileAvatars");
        modelBuilder.Entity<UserProfile>()
            .HasOne(x => x.Avatar)
            .WithOne(x => x.UserProfile);
    }
}