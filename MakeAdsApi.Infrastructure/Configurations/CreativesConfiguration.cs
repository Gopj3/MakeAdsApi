using MakeAdsApi.Domain.Entities.Ads.Creatives;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class CreativesConfiguration
{
    public static void ConfigureCreatives(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseCreative>().ToTable("BaseCreatives");
        modelBuilder.Entity<SingleCreative>().ToTable("SingleCreatives");
        modelBuilder.Entity<ABCreative>().ToTable("ABCreatives");
        modelBuilder.Entity<CarouselCreative>().ToTable("CarouselCreatives");
        modelBuilder.Entity<CarouselCreativeItem>().ToTable("CarouselCreativeItems");
        modelBuilder.Entity<AbCreativeMedia>().ToTable("ABCreativesMedia");

        modelBuilder.Entity<BaseCreative>().Property(x => x.Description).HasColumnType("text");
        modelBuilder.Entity<BaseCreative>().Property(x => x.Headline).HasColumnType("varchar(255)");
        modelBuilder.Entity<BaseCreative>().Property(x => x.Caption).HasColumnType("varchar(255)");
        modelBuilder.Entity<BaseCreative>().Property(x => x.Link).HasColumnType("varchar(255)");
        modelBuilder.Entity<BaseCreative>().Property(x => x.SocialMediaReference).HasColumnType("varchar(255)");

        modelBuilder.Entity<SingleCreative>().HasOne(x => x.Media).WithMany();
        modelBuilder.Entity<ABCreative>()
            .HasMany(x => x.AbCreativeMedias)
            .WithOne(x => x.AbCreative);
        
        modelBuilder.Entity<CarouselCreative>()
            .HasMany(x => x.Items)
            .WithOne(x => x.CarouselCreative);
        
        modelBuilder.Entity<CarouselCreativeItem>()
            .HasOne(x => x.Media)
            .WithMany();
    }
}