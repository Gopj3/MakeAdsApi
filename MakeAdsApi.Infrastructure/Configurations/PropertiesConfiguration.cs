using MakeAdsApi.Domain.Entities.Properties;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Infrastructure.Configurations;

public static class PropertiesConfiguration
{
    public static void ConfigureProperties(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>().ToTable("Properties");
        modelBuilder.Entity<PropertyUser>().ToTable("PropertiesUsers");

        modelBuilder.Entity<Property>().Property(x => x.PropertyId).IsRequired();
        modelBuilder.Entity<Property>().Property(x => x.Address).IsRequired();
        modelBuilder.Entity<Property>().HasIndex(x => x.PropertyId).IsUnique();
        modelBuilder.Entity<Property>()
            .HasMany(x => x.Users)
            .WithOne(x => x.Property);
        modelBuilder.Entity<Property>()
            .HasMany(x => x.Orders)
            .WithOne(x => x.Property);
    }
}